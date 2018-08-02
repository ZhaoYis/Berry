using System;

namespace Berry.Util
{
    /// <summary>
    /// 全局ID生成器
    /// </summary>
    public sealed class GlobalIDGeneratorHelper
    {
        private readonly long _workerId;
        private readonly long _datacenterId;
        private long _sequence = 0L;

        private const long Twepoch = 1288834974657L;

        private const long WorkerIdBits = 5L;
        private const long DatacenterIdBits = 5L;
        private const long MaxWorkerId = -1L ^ (-1L << (int)WorkerIdBits);
        private const long MaxDatacenterId = -1L ^ (-1L << (int)DatacenterIdBits);
        private const long SequenceBits = 12L;

        private const long WorkerIdShift = SequenceBits;
        private const long DatacenterIdShift = SequenceBits + WorkerIdBits;
        private const long TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;
        private readonly long SequenceMask = -1L ^ (-1L << (int)SequenceBits);

        private long _lastTimestamp = -1L;

        private static readonly object SyncRoot = new object();

        public GlobalIDGeneratorHelper(long workerId, long datacenterId)
        {
            if (workerId > MaxWorkerId || workerId < 0)
            {
                throw new ArgumentException(string.Format("worker Id can't be greater than %d or less than 0", MaxWorkerId));
            }
            if (datacenterId > MaxDatacenterId || datacenterId < 0)
            {
                throw new ArgumentException(string.Format("datacenter Id can't be greater than %d or less than 0", MaxDatacenterId));
            }

            this._workerId = workerId;
            this._datacenterId = datacenterId;
        }

        /// <summary>
        /// 计算下一个ID
        /// </summary>
        /// <returns></returns>
        public long NextId()
        {
            lock (SyncRoot)
            {
                long timestamp = GetTimestampUtcNow();
                //校验时间戳
                if (timestamp < _lastTimestamp)
                {
                    throw new ApplicationException(string.Format("时钟向后移动，拒绝为{0}毫秒生成ID", _lastTimestamp - timestamp));
                }

                if (_lastTimestamp == timestamp)
                {
                    _sequence = (_sequence + 1) & SequenceMask;
                    if (_sequence == 0)
                    {
                        timestamp = TilNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    _sequence = 0L;
                }

                _lastTimestamp = timestamp;

                return ((timestamp - Twepoch) << (int)TimestampLeftShift) | (_datacenterId << (int)DatacenterIdShift) | (_workerId << (int)WorkerIdShift) | _sequence;
            }
        }

        /// <summary>
        /// 获取下一个时间戳
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        private long TilNextMillis(long lastTimestamp)
        {
            long timestamp = GetTimestampUtcNow();
            while (timestamp <= lastTimestamp)
            {
                timestamp = GetTimestampUtcNow();
            }
            return timestamp;
        }

        /// <summary>
        /// 计算当前时间戳
        /// </summary>
        /// <returns></returns>
        private long GetTimestampUtcNow()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
    }
}