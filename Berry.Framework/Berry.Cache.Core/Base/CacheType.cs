namespace Berry.Cache.Core.Base
{
    /// <summary>
    /// 支持缓存类型
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// 运行时缓存
        /// </summary>
        Runtime,
        /// <summary>
        /// Redis
        /// </summary>
        Redis,
        /// <summary>
        /// Memcache
        /// </summary>
        Memcached,
        /// <summary>
        /// 微软自带MemoryCache
        /// </summary>
        MemoryCache
    }
}