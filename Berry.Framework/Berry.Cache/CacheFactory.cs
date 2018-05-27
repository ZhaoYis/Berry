using Berry.Util;

namespace Berry.Cache
{
    /// <summary>
    /// 缓存工厂
    /// </summary>
    public class CacheFactory
    {
        private static readonly string CacheType;

        static CacheFactory()
        {
            CacheType = ConfigHelper.GetValue("CacheType");
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <returns></returns>
        public static ICache GetCacheInstance()
        {
            switch (CacheType)
            {
                case "Redis":
                    return new RedisCache();

                case "WebCache":
                    return new WebCache();

                default:
                    return new WebCache();
            }
        }
    }
}