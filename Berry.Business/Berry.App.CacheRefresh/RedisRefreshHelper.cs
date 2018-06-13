using Berry.Entity.CommonEntity;
using Quartz;
using System;
using System.Reflection;
using Berry.Extension;

namespace Berry.App.CacheRefresh
{
    public class RedisRefreshHelper
    {
        /// <summary>
        /// 得到过期时间
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public DateTime GetExpireTime(int timeSpan)
        {
            DateTime time = DateTime.Now;
            if (timeSpan > 0)
            {
                time = DateTime.Now.AddMinutes(timeSpan.TryToInt32());
            }
            else
            {
                time = DateTime.Now.AddMinutes(new Random().Next(10, 20));
            }
            return time;
        }

        /// <summary>
        /// 从作业数据地图中获取配置信息
        /// </summary>
        /// <param name="datamap">作业数据地图</param>
        /// <returns></returns>
        public RedisRefreshEntity GetConfigFromDataMap(JobDataMap datamap)
        {
            var config = new RedisRefreshEntity();
            var properties = typeof(RedisRefreshEntity).GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType == typeof(string))
                    info.SetValue(config, datamap.GetString(info.Name), null);
                else if (info.PropertyType == typeof(Int32))
                    info.SetValue(config, datamap.GetInt(info.Name), null);
            }
            return config;
        }
    }
}