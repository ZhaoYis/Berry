using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace Berry.Cache
{
    /// <summary>
    /// WebCache
    /// </summary>
    public class WebCache : ICache
    {
        private readonly System.Web.Caching.Cache _cache = HttpRuntime.Cache;
        /// <summary>
        /// 缓存Key集合
        /// </summary>
        private static readonly List<string> CacheKeyList = new List<string>();

        private static WebCache WebCacheInstance = new WebCache();

        public static WebCache GetWebCacheInstance()
        {
            return WebCacheInstance;
        }

        private WebCache(){}

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
            if (!CacheKeyList.Contains(cacheKey))
            {
                CacheKeyList.Add(cacheKey);
            }
            _cache.Insert(cacheKey, value, null, expireTime, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 写入缓存，集合，默认过期时间60分钟
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
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
            if (!CacheKeyList.Contains(cacheKey))
            {
                CacheKeyList.Add(cacheKey);
            }
            _cache.Insert(cacheKey, value, null, expireTime, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey) where T : class
        {
            if (_cache[cacheKey] != null)
            {
                return _cache[cacheKey] as T;
            }
            return default(T);
        }

        /// <summary>
        /// 封装缓存写入、获取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">键</param>
        /// <param name="func">获取缓存数据方法</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey, Func<T> func) where T : class
        {
            T t = default(T);
            if (!this.HasExpire(cacheKey))
            {
                t = this.GetCache<T>(cacheKey);
            }
            else
            {
                t = func.Invoke();
                this.WriteCache<T>(t, cacheKey);
            }
            return t;
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="total">记录数</param>
        /// <returns></returns>
        public List<T> GetListCache<T>(string cacheKey, out long total) where T : class
        {
            if (_cache[cacheKey] != null)
            {
                List<T> res = (List<T>)_cache[cacheKey];
                total = res == null ? 0 : res.Count;
                return res;
            }
            total = 0;
            return default(List<T>);
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
            total = t.Count;
            return t;
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键，all代表清除所有</param>
        public void RemoveCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        /// <summary>
        /// 根据指定条件删除缓存（一般为指定Key的前缀或者后缀）
        /// </summary>
        /// <param name="func"></param>
        /// <example>RemoveCache(key => key.StartsWith("_USER"));</example>
        public void RemoveCache(Func<string, bool> func)
        {
            List<string> keyList = new List<string>();
            foreach (string key in CacheKeyList)
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
            IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                if (cacheEnum.Key != null) _cache.Remove(cacheEnum.Key.ToString());
            }
        }

        /// <summary>
        /// 确定当前Key是否过期
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HasExpire(string key)
        {
            return _cache[key] == null;
        }
    }
}