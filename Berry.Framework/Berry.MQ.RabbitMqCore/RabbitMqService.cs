using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Berry.Extension;
using Berry.Log;
using Berry.MQ.RabbitMqCore.RabbitMqProxyConfig;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Berry.MQ.RabbitMqCore
{
    /// <summary>
    /// RabbitMQ.Client原生封装类
    /// </summary>
    public sealed class RabbitMqService : BaseLogger, IDisposable
    {
        #region 调用方式
        /**
         * 使用方法如下：
         *
         * 消息发布者：
         var rabbitMqProxy = new RabbitMqService(new MqConfig
            {
                AutomaticRecoveryEnabled = true,
                HeartBeat = 60,
                NetworkRecoveryInterval = new TimeSpan(60),
                Host = "localhost",
                UserName = "guest",
                Password = "guest"
            });

            var log = new MessageModel
                {
                    CreateDateTime = DateTime.Now,
                    Msg = "消息：" + i
                };
            rabbitMqProxy.Publish(log, ExchangeTypeCode.Direct);
         *
         * 消息消费者：
         public class MainService
            {
                private readonly RabbitMqService _rabbitMqProxy;

                public MainService()
                {
                    _rabbitMqProxy = new RabbitMqService(new MqConfig
                    {
                        AutomaticRecoveryEnabled = true,
                        HeartBeat = 60,
                        NetworkRecoveryInterval = new TimeSpan(60),
                        Host = "localhost",
                        UserName = "guest",
                        Password = "guest"
                    });
                }

                public bool Start()
                {
                    _rabbitMqProxy.Subscribe<MessageModel>(msg =>
                    {
                        var json = msg.ToJson();
                        Console.WriteLine(json);
                    }, ExchangeTypeCode.Direct);

                    return true;
                }

                public bool Stop()
                {
                    _rabbitMqProxy.Dispose();
                    return true;
                }
            }

         * 以服务的方式进行寄宿：
         HostFactory.Run(config =>
            {
                config.SetServiceName("serviceName".ValueOfAppSetting());

                config.Service<MainService>(ser =>
                {
                    ser.ConstructUsing(name => new MainService());
                    ser.WhenStarted((service, control) => service.Start());
                    ser.WhenStopped((service, control) => service.Stop());
                });
            });
         *
         */ 
        #endregion
        
        #region 初始化

        /// <summary>
        /// RabbitMQ建议客户端线程之间不要共用Model，至少要保证共用Model的线程发送消息必须是串行的，但是建议尽量共用Connection。
        /// </summary>
        private static readonly ConcurrentDictionary<string, IModel> ModelDic = new ConcurrentDictionary<string, IModel>();

        private static RabbitMqAttribute _rabbitMqAttribute;

        private const string RabbitMqAttribute = "RabbitMqAttribute";

        private static IConnection _conn;

        /// <summary>
        /// 对象锁
        /// </summary>
        private static readonly object LockObj = new object();

        /// <summary>
        /// 开启RabbitMQ服务
        /// </summary>
        /// <param name="config"></param>
        public RabbitMqService(MqConfig config)
        {
            OpenRabbitMqService(config);
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="config"></param>
        private static void OpenRabbitMqService(MqConfig config)
        {
            if (_conn != null && _conn.IsOpen)
            {
                return;
            }

            lock (LockObj)
            {
                config.NetworkRecoveryInterval = TimeSpan.FromSeconds(10);

                var factory = new ConnectionFactory
                {
                    //设置主机名
                    HostName = config.Host,
                    //设置心跳时间
                    RequestedHeartbeat = config.HeartBeat,
                    //设置自动重连
                    AutomaticRecoveryEnabled = config.AutomaticRecoveryEnabled,
                    //重连时间
                    NetworkRecoveryInterval = config.NetworkRecoveryInterval,
                    //用户名
                    UserName = config.UserName,
                    //密码
                    Password = config.Password,
                    //虚拟主机
                    VirtualHost = config.VirtualHost
                };

                _conn = _conn ?? factory.CreateConnection();
            }
        }

        /// <summary>
        /// 获取自定义的RabbitMq队列信息实体特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private RabbitMqAttribute GetRabbitMqAttribute<T>()
        {
            if (_rabbitMqAttribute == null)
            {
                var typeOfT = typeof(T);
                _rabbitMqAttribute = typeOfT.GetCustomAttribute<RabbitMqAttribute>();
            }

            return _rabbitMqAttribute;
        }

        #endregion 初始化

        #region 交换器声明

        /// <summary>
        /// 交换器声明
        /// </summary>
        /// <param name="iModel"></param>
        /// <param name="exchange">交换器</param>
        /// <param name="type">交换器类型：
        /// 1、Direct Exchange – 处理路由键。需要将一个队列绑定到交换机上，要求该消息与一个特定的路由键完全
        /// 匹配。这是一个完整的匹配。如果一个队列绑定到该交换机上要求路由键 “dog”，则只有被标记为“dog”的
        /// 消息才被转发，不会转发dog.puppy，也不会转发dog.guard，只会转发dog
        /// 2、Fanout Exchange – 不处理路由键。你只需要简单的将队列绑定到交换机上。一个发送到交换机的消息都
        /// 会被转发到与该交换机绑定的所有队列上。很像子网广播，每台子网内的主机都获得了一份复制的消息。Fanout
        /// 交换机转发消息是最快的。
        /// 3、Topic Exchange – 将路由键和某模式进行匹配。此时队列需要绑定要一个模式上。符号“#”匹配一个或多
        /// 个词，符号“*”匹配不多不少一个词。因此“audit.#”能够匹配到“audit.irs.corporate”，但是“audit.*”
        /// 只会匹配到“audit.irs”。</param>
        /// <param name="durable">持久化</param>
        /// <param name="autoDelete">自动删除</param>
        /// <param name="arguments">参数</param>
        private static void ExchangeDeclare(IModel iModel, string exchange, string type, bool durable = true, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            exchange = string.IsNullOrWhiteSpace(exchange) ? "RabbitMq.Direct.DefaultExchangeName" : exchange.Trim();

            iModel.ExchangeDeclare(exchange, type, durable, autoDelete, arguments);
        }

        #endregion 交换器声明

        #region 队列声明

        /// <summary>
        /// 队列声明
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="queue">队列名称</param>
        /// <param name="durable">持久化</param>
        /// <param name="exclusive">排他队列，如果一个队列被声明为排他队列，该队列仅对首次声明它的连接可见，
        /// 并在连接断开时自动删除。这里需要注意三点：其一，排他队列是基于连接可见的，同一连接的不同信道是可
        /// 以同时访问同一个连接创建的排他队列的。其二，“首次”，如果一个连接已经声明了一个排他队列，其他连
        /// 接是不允许建立同名的排他队列的，这个与普通队列不同。其三，即使该队列是持久化的，一旦连接关闭或者
        /// 客户端退出，该排他队列都会被自动删除的。这种队列适用于只限于一个客户端发送读取消息的应用场景。</param>
        /// <param name="autoDelete">自动删除</param>
        /// <param name="arguments">参数</param>
        private static void QueueDeclare(IModel channel, string queue, bool durable = true, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            queue = string.IsNullOrWhiteSpace(queue) ? "RabbitMq.Direct.DefaultQueueName" : queue.Trim();
            channel.QueueDeclare(queue, durable, exclusive, autoDelete, arguments);
        }

        #endregion 队列声明

        #region 获取Model

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="exchange">交换机名称</param>
        /// <param name="queue">队列名称</param>
        /// <param name="routingKey"></param>
        /// <param name="type">交换机类型</param>
        /// <param name="isProperties">是否持久化</param>
        /// <returns></returns>
        private IModel GetModel(string exchange, string queue, string routingKey, string type, bool isProperties = false)
        {
            return ModelDic.GetOrAdd(queue, key =>
              {
                  var model = _conn.CreateModel();
                  //声明交换器
                  ExchangeDeclare(model, exchange, type, isProperties);
                  //声明队列
                  QueueDeclare(model, queue, isProperties);
                  model.QueueBind(queue, exchange, routingKey);
                  ModelDic[queue] = model;
                  return model;
              });
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="queue">队列名称</param>
        /// <param name="isProperties"></param>
        /// <returns></returns>
        private IModel GetModel(string queue, bool isProperties = false)
        {
            return ModelDic.GetOrAdd(queue, value =>
             {
                 var model = _conn.CreateModel();
                 //声明队列
                 QueueDeclare(model, queue, isProperties);
                 //每次消费的消息数
                 model.BasicQos(0, 1, false);
                 ModelDic[queue] = model;
                 return model;
             });
        }

        #endregion 获取Model

        #region 发布消息

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="command">指令</param>
        /// <param name="type">交换机类型</param>
        /// <returns></returns>
        public void Publish<T>(T command, string type = ExchangeTypeCode.Direct) where T : class
        {
            var queueInfo = this.GetRabbitMqAttribute<T>();

            if (queueInfo == null)
            {
                throw new ArgumentException(RabbitMqAttribute);
            }

            var body = command.TryToJson();
            var exchange = queueInfo.ExchangeName;
            var queue = queueInfo.QueueName;
            var routingKey = queueInfo.RoutingKey;
            var isProperties = queueInfo.IsProperties;

            this.Publish(exchange, queue, routingKey, body, type, isProperties);
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="exchange">交换机名称</param>
        /// <param name="queue">队列名</param>
        /// <param name="routingKey">路由键</param>
        /// <param name="body">队列信息</param>
        /// <param name="type">交换机类型</param>
        /// <param name="isProperties">是否持久化</param>
        /// <returns></returns>
        private void Publish(string exchange, string queue, string routingKey, string body, string type, bool isProperties = false)
        {
            var channel = GetModel(exchange, queue, routingKey, type, isProperties);
            var properties = channel.CreateBasicProperties();
            //DeliveryMode等于2就说明这个消息是持久化的。1是默认是，不是持久的。
            properties.DeliveryMode = isProperties ? (byte)2 : (byte)1;
            properties.Persistent = true;

            Logger(this.GetType(), "发布消息-Publish", () =>
            {
                channel.BasicPublish(exchange, routingKey, properties, body.SerializeUtf8());
            }, e =>
            {

            });
        }

        /// <summary>
        /// 发布消息到死信队列
        /// </summary>
        /// <param name="queue">死信队列名称</param>
        /// <param name="body">死信信息</param>
        /// <param name="type">交换机类型</param>
        /// <param name="ex">异常</param>
        /// <returns></returns>
        private void PublishToDead<T>(string queue, string body, string type, Exception ex) where T : class
        {
            var queueInfo = this.GetRabbitMqAttribute<T>();
            if (queueInfo == null)
            {
                throw new ArgumentException(RabbitMqAttribute);
            }

            var deadLetterExchange = queueInfo.ExchangeName;
            var deadLetterRoutingKey = queueInfo.RoutingKey;
            string deadLetterQueue = queueInfo.QueueName;
            var isProperties = queueInfo.IsProperties;

            var deadLetterBody = new DeadLetterQueue
            {
                Body = body,
                CreateDateTime = DateTime.Now,
                ExceptionMsg = ex.Message,
                Queue = queue,
                RoutingKey = deadLetterRoutingKey,
                Exchange = deadLetterExchange
            };

            this.Publish(deadLetterExchange, deadLetterQueue, deadLetterRoutingKey, deadLetterBody.TryToJson(), type, isProperties);
        }

        #endregion 发布消息

        #region 订阅消息

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler">消费处理</param>
        /// <param name="type">交换机类型</param>
        public void Subscribe<T>(Action<T> handler, string type = ExchangeTypeCode.Direct) where T : class
        {
            var queueInfo = this.GetRabbitMqAttribute<T>();
            if (queueInfo == null)
            {
                throw new ArgumentException(RabbitMqAttribute);
            }

            var isDeadLetter = typeof(T) == typeof(DeadLetterQueue);

            this.Subscribe(queueInfo.QueueName, queueInfo.IsProperties, handler, type, isDeadLetter);
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queue">队列名称</param>
        /// <param name="isProperties"></param>
        /// <param name="handler">消费处理</param>
        /// <param name="type">交换机类型</param>
        /// <param name="isDeadLetter">是否死信</param>
        private void Subscribe<T>(string queue, bool isProperties, Action<T> handler, string type, bool isDeadLetter) where T : class
        {
            //队列声明
            var channel = this.GetModel(queue, isProperties);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var msgStr = body.DeserializeUtf8();
                var msg = msgStr.JsonToEntity<T>();

                Logger(this.GetType(), "接收消息-Subscribe", () =>
                {
                    handler(msg);
                }, e =>
                {
                    if (!isDeadLetter)
                    {
                        PublishToDead<DeadLetterQueue>(queue, msgStr, type, e);
                    }
                }, () =>
                {
                    channel.BasicAck(ea.DeliveryTag, false);
                });
            };
            channel.BasicConsume(queue, false, consumer);
        }

        #endregion 订阅消息

        #region 获取消息

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler">消费处理</param>
        /// <param name="type">交换机类型</param>
        public void Pull<T>(Action<T> handler, string type = ExchangeTypeCode.Direct) where T : class
        {
            var queueInfo = this.GetRabbitMqAttribute<T>();
            if (queueInfo == null)
            {
                throw new ArgumentException("RabbitMqAttribute");
            }

            this.Pull(queueInfo.ExchangeName, queueInfo.QueueName, queueInfo.RoutingKey, handler, type);
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exchange">交换机名称</param>
        /// <param name="queue">队列名</param>
        /// <param name="routingKey">路由键</param>
        /// <param name="handler">消费处理</param>
        /// <param name="type">交换机类型</param>
        private void Pull<T>(string exchange, string queue, string routingKey, Action<T> handler, string type) where T : class
        {
            var channel = this.GetModel(exchange, queue, routingKey, type);

            var result = channel.BasicGet(queue, false);
            if (result == null)
            {
                return;
            }

            var msg = result.Body.DeserializeUtf8().JsonToEntity<T>();

            Logger(this.GetType(), "获取消息-Pull", () =>
            {
                handler(msg);
            }, e =>
            {

            }, () =>
            {
                channel.BasicAck(result.DeliveryTag, false);
            });
        }

        #endregion 获取消息

        #region RPC

        #region RPC客户端

        /// <summary>
        /// RPC客户端
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">指令</param>
        /// <param name="type">交换机类型</param>
        /// <returns></returns>
        public string RpcClient<T>(T command, string type = ExchangeTypeCode.Direct) where T : class
        {
            var queueInfo = this.GetRabbitMqAttribute<T>();

            if (queueInfo == null)
            {
                throw new ArgumentException("RabbitMqAttribute");
            }

            var body = command.TryToJson();
            var exchange = queueInfo.ExchangeName;
            var queue = queueInfo.QueueName;
            var routingKey = queueInfo.RoutingKey;
            var isProperties = queueInfo.IsProperties;

            return this.RpcClient(exchange, queue, routingKey, body, type, isProperties);
        }

        /// <summary>
        /// RPC客户端
        /// </summary>
        /// <param name="exchange">交换机名称</param>
        /// <param name="queue">队列名</param>
        /// <param name="routingKey">路由键</param>
        /// <param name="body">消息体</param>
        /// <param name="type">交换机类型</param>
        /// <param name="isProperties"></param>
        /// <returns></returns>
        private string RpcClient(string exchange, string queue, string routingKey, string body, string type, bool isProperties = false)
        {
            var channel = this.GetModel(exchange, queue, routingKey, type, isProperties);

            var consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume(queue, true, consumer);

            try
            {
                var correlationId = Guid.NewGuid().ToString();
                var basicProperties = channel.CreateBasicProperties();
                basicProperties.ReplyTo = queue;
                basicProperties.CorrelationId = correlationId;

                channel.BasicPublish(exchange, routingKey, basicProperties, body.SerializeUtf8());

                var sw = Stopwatch.StartNew();
                while (true)
                {
                    var ea = consumer.Queue.Dequeue();
                    if (ea.BasicProperties.CorrelationId == correlationId)
                    {
                        return ea.Body.DeserializeUtf8();
                    }

                    if (sw.ElapsedMilliseconds > 30000)
                    {
                        throw new Exception("等待响应超时");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion RPC客户端

        #region RPC服务端

        /// <summary>
        /// RPC服务端
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        public void RpcService<T>(Func<T, T> handler) where T : class
        {
            var queueInfo = this.GetRabbitMqAttribute<T>();
            if (queueInfo == null)
            {
                throw new ArgumentException("RabbitMqAttribute");
            }

            var isDeadLetter = typeof(T) == typeof(DeadLetterQueue);

            this.RpcService(queueInfo.ExchangeName, queueInfo.QueueName, queueInfo.IsProperties, handler, isDeadLetter);
        }

        /// <summary>
        /// RPC服务端
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exchange">交换机名称</param>
        /// <param name="queue">队列名</param>
        /// <param name="isProperties">是否持久化</param>
        /// <param name="handler"></param>
        /// <param name="isDeadLetter">是否死信</param>
        private void RpcService<T>(string exchange, string queue, bool isProperties, Func<T, T> handler, bool isDeadLetter)
        {
            //队列声明
            var channel = this.GetModel(queue, isProperties);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var msgStr = body.DeserializeUtf8();
                var msg = msgStr.JsonToEntity<T>();

                var props = ea.BasicProperties;
                var replyProps = channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                Logger(this.GetType(), "RPC服务端-RpcService", () =>
                {
                    handler(msg);
                }, e =>
                {

                }, () =>
                {
                    channel.BasicPublish(exchange, props.ReplyTo, replyProps, msg.TryToJson().SerializeUtf8());
                    channel.BasicAck(ea.DeliveryTag, false);
                });
            };
            channel.BasicConsume(queue, false, consumer);
        }

        #endregion RPC服务端

        #endregion RPC

        #region 释放资源

        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            foreach (var item in ModelDic)
            {
                item.Value.Dispose();
            }
            _conn.Dispose();
        }

        #endregion 释放资源

    }
}