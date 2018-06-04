using System;

namespace Berry.SOA.API.Caching
{
    public class ThrottleEntry
    {
        /// <summary>
        /// 第一次请求开始时间
        /// </summary>
        public DateTime PeriodStart { get; set; }
        /// <summary>
        /// 请求次数
        /// </summary>
        public long Requests { get; set; }

        public ThrottleEntry()
        {
            PeriodStart = DateTime.UtcNow;
            Requests = 0;
        }
    }
}