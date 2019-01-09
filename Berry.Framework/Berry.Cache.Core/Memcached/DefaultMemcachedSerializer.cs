using Berry.Cache.Core.Base;
using Newtonsoft.Json;

namespace Berry.Cache.Core.Memcached
{
    public class DefaultMemcachedSerializer : BaseSerializer
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Deserialize<T>(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default(T);
        }
    }
}