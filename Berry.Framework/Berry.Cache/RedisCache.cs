using System;
using System.Collections;
using System.Collections.Generic;

namespace Berry.Cache
{
    public class RedisCache : ICache
    {
        private static RedisHelper redisHelper = new RedisHelper();

        private static RedisCache RedisCacheInstance = new RedisCache();

        public static RedisCache GetRedisCacheInstance()
        {
            return RedisCacheInstance;
        }

        private RedisCache(){}

        /// <summary>
        /// 写入缓存，单体，默认过期时间60分钟
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            WriteCache<T>(value, cacheKey, DateTime.Now.AddMinutes(60));
        }

        /// <summary>
        /// 写入缓存，单体
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            TimeSpan span = expireTime - DateTime.Now;

            Type type = typeof(T);
            if (type == typeof(string))
            {
                redisHelper.StringSet<T>(cacheKey, value, span);
            }
            else if (type == typeof(T))
            {
                redisHelper.ListRightPush<T>(cacheKey, value);

                redisHelper.KeyExpire(cacheKey, span);
            }
        }

        /// <summary>
        /// 写入缓存，集合，默认过期时间60分钟
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        public void WriteListCache<T>(List<T> value, string cacheKey) where T : class
        {
            WriteListCache<T>(value, cacheKey, DateTime.Now.AddMinutes(60));
        }

        /// <summary>
        /// 写入缓存，集合
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void WriteListCache<T>(List<T> value, string cacheKey, DateTime expireTime) where T : class
        {
            TimeSpan span = expireTime - DateTime.Now;

            redisHelper.ListRightPush<List<T>>(cacheKey, value);

            redisHelper.KeyExpire(cacheKey, span);
        }

        /// <summary>
        /// 读取缓存，单体
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
                res = redisHelper.ListRange<T>(cacheKey) as T;
            }
            return res;
        }

        /// <summary>
        /// 封装缓存写入、获取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">键</param>
        /// <param name="func">获取缓存数据方法</param>
        /// <param name="expireTime">到期时间</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey, Func<T> func, DateTime expireTime) where T : class
        {
            T t = default(T);
            if (this.HasExpire(cacheKey))
            {
                t = this.GetCache<T>(cacheKey);
            }
            else
            {
                t = func.Invoke();
                this.WriteCache<T>(t, cacheKey, expireTime);
            }
            return t;
        }

        /// <summary>
        /// 读取缓存，集合
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="total">当前Key下面缓存记录数</param>
        /// <returns></returns>
        public List<T> GetListCache<T>(string cacheKey, out long total) where T : class
        {
            List<T> res = redisHelper.ListRange<T>(cacheKey) as List<T>;
            total = redisHelper.ListLength(cacheKey);

            return res;
        }

        /// <summary>
        /// 封装缓存写入、获取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">键</param>
        /// <param name="func">获取缓存数据方法</param>
        /// <param name="total">记录数</param>
        /// <returns></returns>
        public List<T> GetListCache<T>(string cacheKey, Func<List<T>> func, out long total) where T : class
        {
            List<T> t = default(List<T>);
            if (!this.HasExpire(cacheKey))
            {
                t = this.GetListCache<T>(cacheKey, out total);
            }
            else
            {
                t = func.Invoke();
                this.WriteListCache(t, cacheKey);
            }
            total = redisHelper.ListLength(cacheKey);
            return t;
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
        /// 根据指定条件删除缓存（一般为指定Key的前缀或者后缀）
        /// </summary>
        /// <param name="func"></param>
        /// <example>RemoveCache(key => key.StartsWith("_USER"));</example>
        public void RemoveCache(Func<string, bool> func)
        {
            List<string> keyList = new List<string>();
            List<string> allKeysList = redisHelper.GetKeys();
            foreach (string key in allKeysList)
            {
                if (func.Invoke(key))
                {
                    keyList.Add(key);
                }
            }

            keyList.ForEach(this.RemoveCache);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveCache()
        {
            List<string> keys = redisHelper.GetKeys();
            foreach (string key in keys)
            {
                redisHelper.KeyDelete(key);
            }
        }

        /// <summary>
        /// 确定当前Key是否过期
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HasExpire(string key)
        {
            return redisHelper.KeyExists(key);
        }
    }
}