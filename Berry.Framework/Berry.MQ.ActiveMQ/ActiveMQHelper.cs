#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.MQ.ActiveMQ
* 项目描述 ：
* 类 名 称 ：ActiveMQHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.MQ.ActiveMQ
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/30 20:18:46
* 更新时间 ：2019/3/30 20:18:46
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using System;

namespace Berry.MQ.ActiveMQ
{
    /// <summary>
    /// 功能描述    ：ActiveMQHelper
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/30 20:18:46 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/30 20:18:46 
    /// </summary>
    public class ActiveMQHelper
    {
        private IConnectionFactory _factory;
        private IConnection _connection;
        private ISession _session;
        private IMessageProducer _prod;
        private IMessageConsumer _consumer;
        private ITextMessage _textMessage;

        private bool _isTopic = false;
        private bool _hasSelector = false;

        private readonly IActiveMQMsgHandler _msgHandler;
        private ActiveMQEventSource _eventSource;

        /// <summary>
        /// 业务名称
        /// </summary>
        private string BusinessName { get; set; } = "DEFAULT";

        /// <summary>
        /// 初始化
        /// </summary>
        public ActiveMQHelper(IActiveMQMsgHandler msgHandler = null, bool isNeedPwd = false)
        {
            try
            {
                if (msgHandler == null)
                {
                    msgHandler = new DefaultActiveMQMsgHandler();
                }
                _msgHandler = msgHandler;

                //初始化工厂
                _factory = new ConnectionFactory(ActiveMQConfig.CONNECTION_INFO);

                //通过工厂建立连接
                if (!isNeedPwd)
                {
                    _connection = _factory.CreateConnection();
                }
                else
                {
                    _connection = _factory.CreateConnection(ActiveMQConfig.MQ_ACCOUNT, ActiveMQConfig.MQ_PWD);
                }

                _connection.ClientId = ActiveMQConfig.CLIENT_ID;
                _connection.Start();
                //通过连接创建Session会话
                _session = _connection.CreateSession();
            }
            catch (Exception e)
            {
                //引发事件
                _eventSource.RaiseErroeMsgEvent(this.BusinessName, e.Message);
            }
        }

        ~ActiveMQHelper()
        {
            //this.ShutDown();
        }

        //mymq.InitQueueOrTopic(topic: false, name: "myqueue", selector: false);
        //mymq.InitQueueOrTopic(topic: false, name: "seletorqueue", selector: true); 
        //mymq.InitQueueOrTopic(topic: true, name: "noselectortopic", selector: false);
        //mymq.InitQueueOrTopic(topic: true, name: "selectortopic", selector: true);

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="topic">选择是否是Topic</param>
        /// <param name="name">队列名</param>
        /// <param name="selector">是否设置过滤</param>
        public bool InitQueueOrTopic(bool topic, string name, bool selector = false)
        {
            bool isInitSucc = true;
            _eventSource = new ActiveMQEventSource();
            ActiveMQMsgEventListener msgEventListener = new ActiveMQMsgEventListener(_msgHandler);

            try
            {
                //订阅事件
                msgEventListener.Subscribe(_eventSource);
                this.BusinessName = name;

                //通过会话创建生产者、消费者
                if (topic)
                {
                    _prod = _session.CreateProducer(new ActiveMQTopic(this.BusinessName));
                    if (selector)
                    {
                        _consumer = _session.CreateDurableConsumer(new ActiveMQTopic(this.BusinessName), ActiveMQConfig.CLIENT_ID, ActiveMQConfig.ACTIVEMQ_SELECTOR, false);
                        _consumer.Listener += new MessageListener(this.OnMessageReceived);
                        _hasSelector = true;
                    }
                    else
                    {
                        _consumer = _session.CreateDurableConsumer(new ActiveMQTopic(this.BusinessName), ActiveMQConfig.CLIENT_ID, null, false);
                        _consumer.Listener += new MessageListener(this.OnMessageReceived);
                        _hasSelector = false;
                    }
                    _isTopic = true;
                }
                else
                {
                    _prod = _session.CreateProducer(new ActiveMQQueue(this.BusinessName));
                    if (selector)
                    {
                        _consumer = _session.CreateConsumer(new ActiveMQQueue(this.BusinessName), ActiveMQConfig.ACTIVEMQ_SELECTOR);
                        _consumer.Listener += new MessageListener(this.OnMessageReceived);
                        _hasSelector = true;
                    }
                    else
                    {
                        _consumer = _session.CreateConsumer(new ActiveMQQueue(this.BusinessName));
                        _consumer.Listener += new MessageListener(this.OnMessageReceived);
                        _hasSelector = false;
                    }
                    _isTopic = false;
                }
                //创建一个发送的消息对象
                _textMessage = _prod.CreateTextMessage();
            }
            catch (Exception e)
            {
                isInitSucc = false;
                //引发事件
                _eventSource.RaiseErroeMsgEvent(this.BusinessName, e.Message);
            }
            return isInitSucc;
        }

        /// <summary>
        /// 接收ActiveMQ消息
        /// </summary>
        /// <param name="receivedMsg"></param>
        private void OnMessageReceived(IMessage receivedMsg)
        {
            if (receivedMsg is IObjectMessage)
            {
                var message = receivedMsg as IObjectMessage;
            }

            if (receivedMsg is ITextMessage)
            {
                var message = receivedMsg as ITextMessage;
                //引发事件
                _eventSource.RaiseNewMsgEvent(this.BusinessName, message.Text);
            }

            if (receivedMsg is IBytesMessage)
            {
                var message = receivedMsg as IBytesMessage;
            }

            if (receivedMsg is IMapMessage)
            {
                var message = receivedMsg as IMapMessage;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="msgId"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public bool SendMessage(string message, string msgId = "defult", MsgPriority priority = MsgPriority.Normal)
        {
            bool sendSuccess = false;
            if (_prod == null)
            {
                //引发事件
                _eventSource.RaiseErroeMsgEvent(this.BusinessName, "call InitQueueOrTopic() first！！！");
                return sendSuccess;
            }

            Console.WriteLine("Begin send messages...");

            //给这个对象赋实际的消息
            _textMessage.NMSCorrelationID = msgId;
            _textMessage.Properties["MyID"] = msgId;
            _textMessage.NMSMessageId = msgId;
            _textMessage.Text = message;

            if (_isTopic)
            {
                sendSuccess = this.ProducerSubcriber(message, priority);
            }
            else
            {
                sendSuccess = this.P2P(message, priority);
            }
            return sendSuccess;
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            if (_prod == null)
            {
                //引发事件
                _eventSource.RaiseErroeMsgEvent(this.BusinessName, "call InitQueueOrTopic() first！！！");
                return "";
            }

            Console.WriteLine("Begin receive messages...");
            ITextMessage revMessage = null;
            try
            {
                //同步阻塞10ms,没消息就直接返回null,注意此处时间不能设太短，否则还没取到消息就直接返回null了！！！
                revMessage = _consumer.Receive(new TimeSpan(TimeSpan.TicksPerMillisecond * 10)) as ITextMessage;
            }
            catch (Exception e)
            {
                //引发事件
                _eventSource.RaiseErroeMsgEvent(this.BusinessName, e.Message);
            }

            if (revMessage == null)
            {
                //引发事件
                _eventSource.RaiseErroeMsgEvent(this.BusinessName, "No message received！");
                return "";
            }
            else
            {
                Console.WriteLine("Received message with Correlation ID: " + revMessage.NMSCorrelationID);
                //Console.WriteLine("Received message with Properties'ID: " + revMessage.Properties["MyID"]);
                Console.WriteLine("Received message with text: " + revMessage.Text);
            }

            return revMessage.Text;
        }

        /// <summary>
        /// P2P模式，一个生产者对应一个消费者
        /// </summary>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        private bool P2P(string message, MsgPriority priority)
        {
            bool sendSuccess = true;
            try
            {
                if (_hasSelector)
                {
                    //设置消息对象的属性，这个很重要，是Queue的过滤条件，也是P2P消息的唯一指定属性
                    _textMessage.Properties.SetString("filter", "demo");  //P2P模式
                }
                _prod.Priority = priority;
                //设置持久化
                _prod.DeliveryMode = MsgDeliveryMode.Persistent;
                //生产者把消息发送出去，几个枚举参数MsgDeliveryMode是否持久化，MsgPriority消息优先级别，存活时间，当然还有其他重载
                _prod.Send(_textMessage, MsgDeliveryMode.Persistent, priority, TimeSpan.MinValue);
            }
            catch (Exception e)
            {
                sendSuccess = false;
                //引发事件
                _eventSource.RaiseErroeMsgEvent(this.BusinessName, e.Message);
            }
            return sendSuccess;
        }

        /// <summary>
        /// 发布订阅模式，一个生产者多个消费者 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        private bool ProducerSubcriber(string message, MsgPriority priority)
        {
            bool sendSuccess = true;
            try
            {
                _prod.Priority = priority;
                //设置持久化,如果DeliveryMode没有设置或者设置为NON_PERSISTENT，那么重启MQ之后消息就会丢失
                _prod.DeliveryMode = MsgDeliveryMode.Persistent;
                _prod.Send(_textMessage, MsgDeliveryMode.Persistent, priority, TimeSpan.MinValue);
                //System.Threading.Thread.Sleep(1000);  
            }
            catch (Exception e)
            {
                sendSuccess = false;
                //引发事件
                _eventSource.RaiseErroeMsgEvent(this.BusinessName, e.Message);
            }
            return sendSuccess;
        }

        /// <summary>
        /// 去掉消息头
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string RemoveMsgHeader(string msg, string name)
        {
            msg = msg.Trim();

            //去掉消息头
            int index = msg.IndexOf("<" + name, StringComparison.Ordinal);
            if (index > 0)
            {
                string temp = msg.Substring(0, index);
                msg = msg.Substring(index, msg.Length - temp.Length);
                msg = msg.Trim();
            }

            return msg;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void ShutDown()
        {
            Console.WriteLine("Close connection and session...");
            _session.Close();
            _connection.Close();
        }
    }
}
