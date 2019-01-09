using Berry.Cache.Core.Base;

namespace Berry.Cache.Core.RegisterService
{
    /// <summary>
    /// 具体注册服务
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// 使用Redis缓存
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IRegisterService UseRedisCache(this IRegisterService service)
        {
            CacheFactory.CacheType = CacheType.Redis;
            return service;
        }

        /// <summary>
        /// 使用运行时缓存
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IRegisterService UseRuntimeCache(this IRegisterService service)
        {
            CacheFactory.CacheType = CacheType.Runtime;
            return service;
        }

        /// <summary>
        /// 使用Memcache缓存
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IRegisterService UseMemcachedCache(this IRegisterService service)
        {
            CacheFactory.CacheType = CacheType.Memcached;
            return service;
        }

        /// <summary>
        /// 使用MemoryCache缓存
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IRegisterService UseMemoryCache(this IRegisterService service)
        {
            CacheFactory.CacheType = CacheType.MemoryCache;
            return service;
        }
    }
}