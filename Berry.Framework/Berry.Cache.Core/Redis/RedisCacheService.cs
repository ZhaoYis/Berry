using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Berry.Cache.Core.Base;

namespace Berry.Cache.Core.Redis
{
    /// <summary>
    /// Redis缓存实现
    /// </summary>
    public class RedisCacheService : BaseCacheService, ICacheService
    {
        #region 实例
        /// <summary>
        /// 实例
        /// </summary>
        private static readonly ICacheService CacheService = null;
        /// <summary>
        /// Redis操作帮助类
        /// </summary>
        private static readonly RedisHelper redisHelper = new RedisHelper();

        private RedisCacheService()
        {
        }

        static RedisCacheService()
        {
            CacheService = new RedisCacheService();
        }

        #endregion

        #region 基础操作

        /// <summary>
        /// 默认缓存Key前缀
        /// </summary>
        protected override string DefaultCacheKeyPrefix
        {
            get { return "Default"; }
        }

        /// <summary>
        /// 获取缓存操作实例
        /// </summary>
        /// <returns></returns>
        public static ICacheService GetCacheInstance()
        {
            return CacheService;
        }

        /// <summary>
        /// 组装带前缀的缓存Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override string GetCacheKey(string key)
        {
            return string.Format("{0}:{1}", this.DefaultCacheKeyPrefix, key);
        }

        #endregion

        #region 验证缓存项是否存在

        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return redisHelper.KeyExists(this.GetCacheKey(key));
        }

        /// <summary>
        /// 验证缓存项是否存在（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(string key)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Exists(key);
            });
        }
        #endregion

        #region 添加缓存

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public bool Add(string key, object value)
        {
            return redisHelper.StringSet(this.GetCacheKey(key), value, DefaultExpireTime);
        }

        /// <summary>
        /// 添加缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Add(key, value);
            });
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan? expiresSliding, TimeSpan? expiressAbsoulte)
        {
            return redisHelper.StringSet(key, value, expiresSliding ?? expiressAbsoulte ?? DefaultExpireTime);
        }

        /// <summary>
        /// 添加缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value, TimeSpan? expiresSliding, TimeSpan? expiressAbsoulte)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Add(key, value, expiresSliding, expiressAbsoulte);
            });
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan? expiresIn, bool isSliding = false)
        {
            if (!isSliding)
            {
                return redisHelper.StringSet(this.GetCacheKey(key), value, expiresIn);
            }
            else
            {
                if (this.Exists(key))
                {
                    return this.Replace(key, value);
                }
                else
                {
                    return redisHelper.StringSet(this.GetCacheKey(key), value, expiresIn);
                }
            }
        }

        /// <summary>
        /// 添加缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value, TimeSpan? expiresIn, bool isSliding = false)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Add(key, value, expiresIn, isSliding);
            });
        }

        #endregion

        #region 删除缓存

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return redisHelper.KeyDelete(this.GetCacheKey(key));
        }

        /// <summary>
        /// 删除缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<bool> RemoveAsync(string key)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Remove(key);
            });
        }

        /// <summary>
        /// 根据指定条件删除缓存（一般为指定Key的前缀或者后缀）
        /// </summary>
        /// <param name="func"></param>
        /// <example>Remove(key => key.StartsWith("_USER"));</example>
        public void Remove(Func<string, bool> func)
        {
            List<string> keys = new List<string>();
            foreach (string key in redisHelper.GetKeys())
            {
                if (func.Invoke(key))
                {
                    keys.Add(key);
                }
            }
            this.RemoveAll(keys);
        }

        /// <summary>
        /// 根据指定条件删除缓存（一般为指定Key的前缀或者后缀）（异步方式）
        /// </summary>
        /// <param name="func"></param>
        /// <example>Remove(key => key.StartsWith("_USER"));</example>
        public Task RemoveAsync(Func<string, bool> func)
        {
            return Task.Factory.StartNew(() =>
            {
                this.Remove(func);
            });
        }

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public void RemoveAll(List<string> keys)
        {
            if (keys != null && keys.Any())
            {
                foreach (string key in keys)
                {
                    this.Remove(key);
                }
            }
        }

        /// <summary>
        /// 批量删除缓存（异步方式）
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public Task RemoveAllAsync(List<string> keys)
        {
            return Task.Factory.StartNew(() =>
            {
                this.RemoveAll(keys);
            });
        }

        /// <summary>
        /// 删除所有缓存
        /// </summary>
        public void RemoveAll()
        {
            List<string> keys = redisHelper.GetKeys();
            this.RemoveAll(keys);
        }

        /// <summary>
        /// 删除所有缓存（异步方式）
        /// </summary>
        /// <returns></returns>
        public Task RemoveAllAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                this.RemoveAll();
            });
        }

        #endregion

        #region 获取缓存

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            T value = redisHelper.StringGet<T>(this.GetCacheKey(key));
            return value;
        }

        /// <summary>
        /// 获取缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string key) where T : class
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Get<T>(key);
            });
        }

        /// <summary>
        /// 封装缓存写入、获取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="func">获取缓存数据方法</param>
        /// <param name="expiresIn">到期时间</param>
        /// <returns></returns>
        public T Get<T>(string key, Func<T> func, TimeSpan? expiresIn) where T : class
        {
            T t = default(T);
            if (this.Exists(key))
            {
                t = this.Get<T>(key);
            }
            else
            {
                t = func.Invoke();
                this.Add(key, t, expiresIn);
            }
            return t;
        }

        /// <summary>
        /// 封装缓存写入、获取方法（异步方式）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="func">获取缓存数据方法</param>
        /// <param name="expiresIn">到期时间</param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string key, Func<T> func, TimeSpan? expiresIn) where T : class
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Get(key, func, expiresIn);
            });
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public object Get(string key)
        {
            object o = redisHelper.StringGet(this.GetCacheKey(key));
            return o;
        }

        /// <summary>
        /// 获取缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<object> GetAsync(string key)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Get(key);
            });
        }

        /// <summary>
        /// 获取缓存集合
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public Dictionary<string, object> GetAll(List<string> keys)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            if (keys != null && keys.Any())
            {
                foreach (string key in keys)
                {
                    object o = this.Get(key);
                    if (!res.ContainsKey(this.GetCacheKey(key)))
                    {
                        res.Add(this.GetCacheKey(key), o);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 获取缓存集合（异步方式）
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public Task<Dictionary<string, object>> GetAllAsync(List<string> keys)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.GetAll(keys);
            });
        }

        #endregion

        #region 修改缓存

        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <returns></returns>
        public bool Replace(string key, object value)
        {
            if (redisHelper.KeyExists(this.GetCacheKey(key)))
            {
                redisHelper.KeyDelete(this.GetCacheKey(key));
                return this.Add(key, value);
            }
            else
            {
                return this.Add(key, value);
            }
        }

        /// <summary>
        /// 修改缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <returns></returns>
        public Task<bool> ReplaceAsync(string key, object value)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Replace(key, value);
            });
        }

        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public bool Replace(string key, object value, TimeSpan? expiresSliding, TimeSpan? expiressAbsoulte)
        {
            if (redisHelper.KeyExists(this.GetCacheKey(key)))
            {
                redisHelper.KeyDelete(this.GetCacheKey(key));
                return this.Add(key, value, expiresSliding, expiressAbsoulte);
            }
            else
            {
                return this.Add(key, value, expiresSliding, expiressAbsoulte);
            }
        }

        /// <summary>
        /// 修改缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public Task<bool> ReplaceAsync(string key, object value, TimeSpan? expiresSliding, TimeSpan? expiressAbsoulte)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Replace(key, value, expiresSliding, expiressAbsoulte);
            });
        }

        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        public bool Replace(string key, object value, TimeSpan? expiresIn, bool isSliding = false)
        {
            if (redisHelper.KeyExists(this.GetCacheKey(key)))
            {
                redisHelper.KeyDelete(this.GetCacheKey(key));
                return this.Add(key, value, expiresIn, isSliding);
            }
            else
            {
                return this.Add(key, value, expiresIn, isSliding);
            }
        }

        /// <summary>
        /// 修改缓存（异步方式）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        public Task<bool> ReplaceAsync(string key, object value, TimeSpan? expiresIn, bool isSliding = false)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Replace(key, value, expiresIn, isSliding);
            });
        }
        #endregion
    }
}