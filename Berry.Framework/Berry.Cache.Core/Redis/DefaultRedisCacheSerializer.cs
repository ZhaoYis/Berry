using System;
using Berry.Cache.Core.Base;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Berry.Cache.Core.Redis
{
    public class DefaultRedisCacheSerializer : BaseSerializer
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Deserialize<T>(RedisValue value)
        {
            if (!value.IsNullOrEmpty)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default(T);
        }

    }
}