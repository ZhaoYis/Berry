using System;
using System.Collections.Generic;
using System.Timers;

namespace Berry.Cache
{
    /// <summary>
    /// 自定义缓存
    /// </summary>
    public class CustomCache : ICache
    {
        private static Dictionary<string, KeyValuePair<object, DateTime>> dict = new Dictionary<string, KeyValuePair<object, DateTime>>();
        /// <summary>
        /// 缓存Key集合
        /// </summary>
        private static readonly List<string> CacheKeyList = new List<string>();

        private static CustomCache CustomCacheInstance = new CustomCache();

        public static CustomCache GetCustomCacheInstance()
        {
            return CustomCacheInstance;
        }

        #region 缓存过期检测
        /// <summary>
        /// 默认一分钟
        /// </summary>
        private static Timer timer = new Timer(1 * 1 * 60 * 60);

        private CustomCache()
        {
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;

            timer.Start();
        }
        static CustomCache() { }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (KeyValuePair<string, KeyValuePair<object, DateTime>> pair in dict)
            {
                if (dict[pair.Key].Value < DateTime.Now)
                {
                    this.RemoveCache(pair.Key);
                }
            }
        }
        #endregion

        /// <summary>
        /// 写入缓存，单体，默认过期时间60分钟
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            if (!CacheKeyList.Contains(cacheKey))
            {
                CacheKeyList.Add(cacheKey);
            }
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
            dict.Add(cacheKey, new KeyValuePair<object, DateTime>(value, expireTime));
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
            dict.Add(cacheKey, new KeyValuePair<object, DateTime>(value, expireTime));
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey) where T : class
        {
            if (!this.HasExpire(cacheKey))
            {
                return (T)dict[cacheKey].Key;
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
            if (!this.HasExpire(cacheKey))
            {
                List<T> res = (List<T>)dict[cacheKey].Key;
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
        /// <param name="cacheKey">键</param>
        public void RemoveCache(string cacheKey)
        {
            dict.Remove(cacheKey);
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
            dict.Clear();
        }

        /// <summary>
        /// 确定当前Key是否过期
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HasExpire(string key)
        {
            if (dict.ContainsKey(key))
            {
                if (dict[key].Value > DateTime.Now)
                {
                    return true;
                }
                else
                {
                    this.RemoveCache(key);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}