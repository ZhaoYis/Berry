using Berry.Cache.Core.Memcached;
using Berry.Cache.Core.MemoryCache;
using Berry.Cache.Core.Redis;
using Berry.Cache.Core.Runtime;

namespace Berry.Cache.Core.Base
{
    /// <summary>
    /// 缓存工厂类
    /// </summary>
    public class CacheFactory
    {
        /// <summary>
        /// 默认使用运行时缓存
        /// </summary>
        public static CacheType CacheType = CacheType.Runtime;

        /// <summary>
        /// 定义通用访问入口，默认使用运行时缓存
        /// </summary>
        /// <returns></returns>
        public static ICacheService GetCache()
        {
            switch (CacheType)
            {
                case CacheType.Runtime:
                    return RuntimeCacheService.GetCacheInstance();
                case CacheType.Redis:
                    return RedisCacheService.GetCacheInstance();
                case CacheType.Memcached:
                    return MemcachedCacheService.GetCacheInstance();
                case CacheType.MemoryCache:
                    return MemoryCacheService.GetCacheInstance();
                default:
                    return RuntimeCacheService.GetCacheInstance();
            }
        }
    }
}