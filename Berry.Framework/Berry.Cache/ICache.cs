using System;
using System.Collections.Generic;

namespace Berry.Cache
{
    /// <summary>
    /// 缓存基础接口
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 写入缓存，单体，默认过期时间10分钟
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        void WriteCache<T>(T value, string cacheKey) where T : class;

        /// <summary>
        /// 写入缓存，单体
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class;

        /// <summary>
        /// 写入缓存，集合，默认过期时间10分钟
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        void WriteListCache<T>(List<T> value, string cacheKey) where T : class;

        /// <summary>
        /// 写入缓存，集合
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        void WriteListCache<T>(List<T> value, string cacheKey, DateTime expireTime) where T : class;

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        T GetCache<T>(string cacheKey) where T : class;

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="total">记录数</param>
        /// <returns></returns>
        List<T> GetListCache<T>(string cacheKey,out long total) where T : class;

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        void RemoveCache(string cacheKey);

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        void RemoveCache();

        /// <summary>
        /// 确定当前Key是否过期
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HasExpire(string key);
    }
}