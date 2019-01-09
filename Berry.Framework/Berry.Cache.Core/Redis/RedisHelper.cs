using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Berry.Cache.Core.Model;
using StackExchange.Redis;

namespace Berry.Cache.Core.Redis
{
    /// <summary>
    /// Redis操作
    /// </summary>
    public class RedisHelper
    {
        /// <summary>
        /// 数据库编号
        /// </summary>
        private int DbNum { get; }

        /// <summary>
        /// 连接
        /// </summary>
        private readonly ConnectionMultiplexer _conn;
        /// <summary>
        /// 序列化操作类
        /// </summary>
        private readonly DefaultRedisCacheSerializer _serializer;

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbNum">数据库编号</param>
        public RedisHelper(int dbNum = 0) : this(dbNum, null)
        {
            _serializer = new DefaultRedisCacheSerializer();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbNum">数据库编号</param>
        /// <param name="readWriteHosts">链接地址</param>
        public RedisHelper(int dbNum, string readWriteHosts)
        {
            this.DbNum = dbNum;
            this._conn = string.IsNullOrWhiteSpace(readWriteHosts) ? RedisConnectionHelper.Instance : RedisConnectionHelper.GetConnectionMultiplexer(readWriteHosts);
            _serializer = new DefaultRedisCacheSerializer();
        }

        #endregion 构造函数

        #region String

        #region 同步方法

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public bool StringSet(string key, string value, TimeSpan? expiry = default(TimeSpan?))
        {
            return Do(db =>
            {
                bool isSucc = db.StringSet(key, value, expiry);
                return isSucc;
            });
        }

        /// <summary>
        /// 保存多个key value
        /// </summary>
        /// <param name="keyValues">键值对</param>
        /// <returns></returns>
        public bool StringSet(List<KeyValuePair<RedisKey, RedisValue>> keyValues)
        {
            List<KeyValuePair<RedisKey, RedisValue>> newkeyValues =
                keyValues.Select(p => new KeyValuePair<RedisKey, RedisValue>(p.Key, p.Value)).ToList();
            return Do(db => db.StringSet(newkeyValues.ToArray()));
        }

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool StringSet<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?))
        {
            string json = _serializer.Serialize(obj);
            return Do(db => db.StringSet(key, json, expiry));
        }

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        public string StringGet(string key)
        {
            return Do(db => db.StringGet(key));
        }

        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T StringGet<T>(string key)
        {
            return Do(db =>
            {
                RedisValue value = db.StringGet(key);
                T res = _serializer.Deserialize<T>(value);
                return res;
            });
        }

        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        public double StringIncrement(string key, double val = 1)
        {
            return Do(db => db.StringIncrement(key, val));
        }

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        public double StringDecrement(string key, double val = 1)
        {
            return Do(db => db.StringDecrement(key, val));
        }

        #endregion 同步方法

        #region 异步方法

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry = default(TimeSpan?))
        {
            return await Do(db => db.StringSetAsync(key, value, expiry));
        }

        /// <summary>
        /// 保存多个key value
        /// </summary>
        /// <param name="keyValues">键值对</param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync(List<KeyValuePair<RedisKey, RedisValue>> keyValues)
        {
            List<KeyValuePair<RedisKey, RedisValue>> newkeyValues =
                keyValues.Select(p => new KeyValuePair<RedisKey, RedisValue>(p.Key, p.Value)).ToList();
            return await Do(db => db.StringSetAsync(newkeyValues.ToArray()));
        }

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?))
        {
            string json = _serializer.Serialize(obj);
            return await Do(db => db.StringSetAsync(key, json, expiry));
        }

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        public async Task<string> StringGetAsync(string key)
        {
            return await Do(db => db.StringGetAsync(key));
        }

        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> StringGetAsync<T>(string key)
        {
            string result = await Do(db => db.StringGetAsync(key));
            return _serializer.Deserialize<T>(result);
        }

        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        public async Task<double> StringIncrementAsync(string key, double val = 1)
        {
            return await Do(db => db.StringIncrementAsync(key, val));
        }

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        public async Task<double> StringDecrementAsync(string key, double val = 1)
        {
            return await Do(db => db.StringDecrementAsync(key, val));
        }

        #endregion 异步方法

        #endregion String

        #region 发布订阅

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="subChannel">通道名称</param>
        /// <param name="handler">处理消息</param>
        public void Subscribe(string subChannel, Action<RedisChannel, RedisValue> handler = null)
        {
            ISubscriber sub = _conn.GetSubscriber();
            sub.Subscribe(subChannel, (channel, message) =>
            {
                if (handler == null)
                {
                    Console.WriteLine("通道：" + subChannel + " 订阅收到消息===>" + message);
                }
                else
                {
                    handler(channel, message);
                }
            });
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <typeparam name="T">消息类型</typeparam>
        /// <param name="channel">通道名称</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public long Publish<T>(string channel, T msg)
        {
            ISubscriber sub = _conn.GetSubscriber();
            return sub.Publish(channel, _serializer.Serialize(msg));
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="channel">通道名称</param>
        public void Unsubscribe(string channel)
        {
            ISubscriber sub = _conn.GetSubscriber();
            sub.Unsubscribe(channel);
        }

        /// <summary>
        /// 取消全部订阅
        /// </summary>
        public void UnsubscribeAll()
        {
            ISubscriber sub = _conn.GetSubscriber();
            sub.UnsubscribeAll();
        }

        #endregion 发布订阅

        #region Key管理

        /// <summary>
        /// 获取所有Key
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys()
        {
            EndPoint[] endpoints = _conn.GetEndPoints();
            List<string> keyList = new List<string>();
            foreach (EndPoint ep in endpoints)
            {
                var server = _conn.GetServer(ep);
                var keys = server.Keys(DbNum, "*");
                foreach (var item in keys)
                {
                    keyList.Add((string)item);
                }
            }
            return keyList;
        }

        /// <summary>
        /// 删除单个key
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns>是否删除成功</returns>
        public bool KeyDelete(string key)
        {
            return Do(db => db.KeyDelete(key));
        }

        /// <summary>
        /// 判断key是否存储
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            return Do(db => db.KeyExists(key));
        }

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        public bool KeyRename(string key, string newKey)
        {
            return Do(db => db.KeyRename(key, newKey));
        }

        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool KeyExpire(string key, TimeSpan? expiry = default(TimeSpan?))
        {
            return Do(db => db.KeyExpire(key, expiry));
        }

        #endregion Key管理

        #region 辅助方法

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        private T Do<T>(Func<IDatabase, T> func)
        {
            var database = _conn.GetDatabase(DbNum);
            return func(database);
        }

        /// <summary>
        /// 批量转换成RedisKey
        /// </summary>
        /// <param name="redisKeys"></param>
        /// <returns></returns>
        private RedisKey[] ConvertRedisKeys(List<string> redisKeys)
        {
            return redisKeys.Select(redisKey => (RedisKey)redisKey).ToArray();
        }

        #endregion 辅助方法

        #region Redis管理辅助方法

        /// <summary>
        /// 获取服务器响应状态
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public static RedisServerResponseModel GetRedisServerResponse(string serverId)
        {
            RedisServerResponseModel result = null;
            RedisServerModel model = RedisServerConfig.RedisServers.FirstOrDefault(p => p.ServerId == serverId);
            if (model != null)
            {
                result = new RedisServerResponseModel() { ServerId = serverId };
                try
                {
                    var server = GetRedisServer(model.ServerHost);
                    var pingTime = server.Ping();
                    result.IsConnection = true;
                    result.Status = "连接成功";
                    result.ResponseTime = Math.Round(pingTime.TotalMilliseconds, 4);
                }
                catch (Exception ex)
                {
                    result.IsConnection = false;
                    result.Status = $"连接失败，原因:{ex.Message}";
                }
            }
            return result;
        }

        public static IServer GetRedisServer(string readWriteHosts)
        {
            string hostAndPort = readWriteHosts.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
            return RedisConnectionHelper.GetConnectionMultiplexer(readWriteHosts).GetServer(hostAndPort);
        }

        /// <summary>
        /// 获取服务器信息
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, string>> GetRedisInfo(string serverId)
        {
            Dictionary<string, Dictionary<string, string>> infoResponse = null;
            try
            {
                RedisServerModel model = RedisServerConfig.RedisServers.FirstOrDefault(p => p.ServerId == serverId);
                if (model != null)
                {
                    var server = GetRedisServer(model.ServerHost);
                    infoResponse = server.Info().ToDictionary(p => p.Key, p => p.ToDictionary(x => x.Key, x => x.Value));
                }
            }
            catch (Exception ex)
            {
                //_helper.Error("GetRedisInfo方法异常", ex);
            }
            return infoResponse;
        }

        /// <summary>
        /// 获取服务器原始内容信息
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public static string GetRedisInfoRow(string serverId)
        {
            try
            {
                RedisServerModel model = RedisServerConfig.RedisServers.FirstOrDefault(p => p.ServerId == serverId);
                if (model != null)
                {
                    var server = GetRedisServer(model.ServerHost);
                    var infoResponse = server.InfoRaw();
                    return WithInfoRaw(infoResponse);
                }
            }
            catch (Exception ex)
            {
                return $"请求失败,原因：{ex.Message}";
            }
            return "";
        }

        /// <summary>
        /// 获取客户端信息
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public static List<ClientInfoModel> GetClients(string serverId)
        {
            List<ClientInfoModel> clients = new List<ClientInfoModel>();
            try
            {
                RedisServerModel model = RedisServerConfig.RedisServers.FirstOrDefault(p => p.ServerId == serverId);
                if (model != null)
                {
                    var server = GetRedisServer(model.ServerHost);
                    clients = server.ClientList().Select(ConvertClientInfoModel).OrderBy(p => p.Host).ThenBy(p => p.Port).ToList();
                }
            }
            catch (Exception ex)
            {
                //_helper.Error("GetClients方法异常", ex);
            }
            return clients;
        }

        #region 辅助方法

        private static ClientInfoModel ConvertClientInfoModel(ClientInfo model)
        {
            return new ClientInfoModel()
            {
                AgeSeconds = model.AgeSeconds,
                Database = model.Database,
                Host = model.Host,
                IdleSeconds = model.IdleSeconds,
                LastCommand = model.LastCommand,
                PatternSubscriptionCount = model.PatternSubscriptionCount,
                Port = model.Port,
                Raw = model.Raw,
                SubscriptionCount = model.SubscriptionCount,
                TransactionCommandLength = model.TransactionCommandLength
            };
        }

        private static string WithInfoRaw(string infoResponse)
        {
            return infoResponse.Replace("\r\n", "<br/>");
        }

        #endregion 辅助方法

        #endregion
    }
}