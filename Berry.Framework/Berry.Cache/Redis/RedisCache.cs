using System;
using System.Collections.Generic;

namespace Berry.Cache.Redis
{
    /// <summary>
    /// Redis缓存
    /// </summary>
    public class RedisCache : BaseExtensionCache, ICache
    {
        #region 接口实现

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            RedisHelper.Set(cacheKey, value, expireTime);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            //RedisCache.Set(cacheKey, value);
            WriteCache(value, cacheKey, DateTime.Now.AddMinutes(10));
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey) where T : class
        {
            return RedisHelper.Get<T>(cacheKey);
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键，all表示清除所有</param>
        public void RemoveCache(string cacheKey)
        {
            if (cacheKey.ToLower().Equals("all"))
            {
                this.RemoveCache();
            }
            else
            {
                RedisHelper.Remove(cacheKey);
            }
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveCache()
        {
            RedisHelper.RemoveAll();
        }

        #endregion 接口实现

        /// <summary>
        /// 写入缓存，集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        public override void WriteCacheList<T>(List<T> value, string cacheKey)
        {
            throw new NotImplementedException();
        }
    }
}