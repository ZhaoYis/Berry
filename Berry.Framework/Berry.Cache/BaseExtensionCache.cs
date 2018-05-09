using System.Collections.Generic;

namespace Berry.Cache
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public abstract class BaseExtensionCache
    {
        /// <summary>
        /// 写入缓存，集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        public abstract void WriteCacheList<T>(List<T> value, string cacheKey) where T : class;
    }
}