namespace Berry.SOA.API.Caching
{
    public interface IThrottleStore
    {
        /// <summary>
        /// 获取字典的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        bool TryGetValue(string key, out ThrottleEntry entry);
        /// <summary>
        /// 计算访问量
        /// </summary>
        /// <param name="key"></param>
        void IncrementRequests(string key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        void Rollover(string key);
        void Clear();
    }
}
