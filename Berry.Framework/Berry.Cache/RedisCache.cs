using System;
using System.Collections;
using System.Collections.Generic;

namespace Berry.Cache
{
    public class RedisCache : ICache
    {
        private static RedisHelper redisHelper = new RedisHelper();

        /// <summary>
        /// 写入缓存，单体，默认过期时间10分钟
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            WriteCache<T>(value, cacheKey, DateTime.Now.AddMinutes(10));
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            Type type = typeof(T);
            TimeSpan span = expireTime - DateTime.Now;
            if (type == typeof(string))
            {
                redisHelper.StringSet<T>(cacheKey, value, span);
            }else if (type == typeof(T))
            {
                redisHelper.ListRightPush<T>(cacheKey, value);
            }
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void WriteCache<T>(List<T> value, string cacheKey, DateTime expireTime) where T : class
        {
            redisHelper.ListRightPush<List<T>>(cacheKey, value);
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey) where T : class
        {
            Type type = typeof(T);
            T res = null;
            if (type == typeof(string))
            {
                res = redisHelper.StringGet(cacheKey) as T;
            }
            else if (type == typeof(T))
            {
                res = redisHelper.ListRightPop<T>(cacheKey) as T;
            }
            return res;
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="total">记录数</param>
        /// <returns></returns>
        public List<T> GetCache<T>(string cacheKey, out long total) where T : class
        {
            List<T> res = redisHelper.ListRightPop<T>(cacheKey) as List<T>;
            total = redisHelper.ListLength(cacheKey);

            return res;
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public void RemoveCache(string cacheKey)
        {
            redisHelper.KeyDelete(cacheKey);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveCache()
        {
            throw new NotImplementedException();
        }
    }
}