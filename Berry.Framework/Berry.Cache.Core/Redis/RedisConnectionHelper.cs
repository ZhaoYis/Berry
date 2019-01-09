using System;
using System.Collections.Concurrent;
using StackExchange.Redis;

namespace Berry.Cache.Core.Redis
{
    /// <summary>
    /// Redis连接帮助类
    /// </summary>
    public static class RedisConnectionHelper
    {
        #region 连接字符串配置项
        //abortConnect={bool} 如果是true，Connect方法在链接不到有效的服务器的时候不会创建一个链接实例
        //allowAdmin={bool}  启用被认定为是有风险的一些命令
        //channelPrefix={string} 所有的发布订阅频道的前缀
        //connectRetry={int} 在初始化 Connect 失败的时候重新尝试进行链接的次数
        //connectTimeout={int} 链接超时时间(ms)
        //configChannel={string} 用于传递配置改变信息的广播频道
        //defaultDatabase={int} 默认的数据库序数, 从1到-1
        //keepAlive={int} 发送信息以保持sockets在线的间隔时间
        //name={string} 在redis内用于判别不同链接客户端
        //password={string} 密码
        //proxy={proxy type} 代理类型(如果有的话); 如 "twemproxy"
        //resolveDns={bool} 指定DNS解析服务器， 推荐明确指出，而不是采用默认的
        //serviceName ={string} 当前没有实现（用于sentinel模式）
        //ssl={bool} 使用SSL加密
        //sslHost={string} 在服务器证书上注册SSL主机身份标识
        //syncTimeout={int} 同步操作的超时时间(ms)
        //tiebreaker={string} 多主机服务器部署情形下中用于选择出master服务的Key
        //version={string} Redis版本(用于从服务器获取不到此信息时)
        //writeBuffer={int} 输出缓存大小 
        #endregion

        /// <summary>
        /// 连接字符串
        /// </summary>
        private static readonly string RedisConnectionString = "127.0.0.1:6379,allowadmin=true,abortConnect=true,connectRetry=5";

        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object Locker = new object();

        /// <summary>
        /// 连接
        /// </summary>
        private static ConnectionMultiplexer _instance;

        /// <summary>
        /// 缓存
        /// </summary>
        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionCache = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        /// <summary>
        /// 日志
        /// </summary>
        //private static LogHelper logHelper = new LogHelper(typeof(RedisConnectionHelper));

        /// <summary>
        /// 单例获取
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null || !_instance.IsConnected)
                        {
                            _instance = GetManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 连接器
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static ConnectionMultiplexer GetConnectionMultiplexer(string connectionString)
        {
            if (!ConnectionCache.ContainsKey(connectionString))
            {
                ConnectionCache[connectionString] = GetManager(connectionString);
            }
            return ConnectionCache[connectionString];
        }

        /// <summary>
        /// 获取Redis连接对象
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            connectionString = connectionString ?? RedisConnectionString;
            ConnectionMultiplexer connect = ConnectionMultiplexer.Connect(connectionString);

            //注册事件
            connect.ConnectionFailed += MuxerConnectionFailed;
            connect.ConnectionRestored += MuxerConnectionRestored;
            connect.ErrorMessage += MuxerErrorMessage;
            connect.ConfigurationChanged += MuxerConfigurationChanged;
            connect.HashSlotMoved += MuxerHashSlotMoved;
            connect.InternalError += MuxerInternalError;

            return connect;
        }

        /// <summary>
        /// 获取Redis连接对象
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private static ConnectionMultiplexer GetManager(ConfigurationOptions configuration)
        {
            ConnectionMultiplexer connect = ConnectionMultiplexer.Connect(configuration);

            //注册事件
            connect.ConnectionFailed += MuxerConnectionFailed;
            connect.ConnectionRestored += MuxerConnectionRestored;
            connect.ErrorMessage += MuxerErrorMessage;
            connect.ConfigurationChanged += MuxerConfigurationChanged;
            connect.HashSlotMoved += MuxerHashSlotMoved;
            connect.InternalError += MuxerInternalError;

            return connect;
        }

        #region 事件

        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged(object sender, EndPointEventArgs e)
        {
            Console.WriteLine("Configuration changed: " + e.EndPoint);

            //logHelper.Info("Redis配置文件发生更改（MuxerConfigurationChanged），EndPoint：" + e.EndPoint);
        }

        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            Console.WriteLine("ErrorMessage: " + e.Message);

            //logHelper.Info("Redis出现错误（MuxerErrorMessage），错误信息：" + e.Message);
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine("ConnectionRestored: " + e.EndPoint);

            //logHelper.Error("Redis重新建立连接之前的错误（MuxerConnectionRestored），EndPoint：" + e.EndPoint);
        }

        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine("重新连接：Endpoint failed: " + e.EndPoint + ", " + e.FailureType + (e.Exception == null ? "" : (", " + e.Exception.Message)));

            //logHelper.Error("Redis重新连接失败（MuxerConnectionFailed）：Endpoint：" + e.EndPoint + ", FailureType：" + e.FailureType + (e.Exception == null ? "" : (",ExceptionMessage：" + e.Exception.Message)));
        }

        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            Console.WriteLine("HashSlotMoved:NewEndPoint" + e.NewEndPoint + ", OldEndPoint" + e.OldEndPoint);

            //logHelper.Info("Redis出现错误（MuxerHashSlotMoved），NewEndPoint：" + e.NewEndPoint + ", OldEndPoint：" + e.OldEndPoint);
        }

        /// <summary>
        /// Redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            Console.WriteLine("InternalError:Message" + e.Exception.Message);

            //logHelper.Error("Redis类库错误（MuxerInternalError），Message：" + e.Exception.Message);
        }

        #endregion 事件
    }
}