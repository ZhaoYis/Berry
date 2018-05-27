using System;
using System.Collections.Concurrent;
using Berry.Util;
using StackExchange.Redis;

namespace Berry.Cache
{
    /// <summary>
    /// ConnectionMultiplexer对象管理帮助类
    /// </summary>
    public static class RedisConnectionHelper
    {
        /// <summary>
        /// 系统自定义Key前缀
        /// </summary>
        public static readonly string SysCustomKey = ConfigHelper.GetValue("RedisSysCustomKeyPrefix");

        /// <summary>
        /// 127.0.0.1:6379,allowadmin=true
        /// </summary>
        private static readonly string RedisConnectionString = ConfigHelper.GetValue("RedisExchangeHosts");

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
        /// 缓存获取
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

        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            connectionString = connectionString ?? RedisConnectionString;
            ConnectionMultiplexer connect = ConnectionMultiplexer.Connect(connectionString);

            //注册如下事件
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