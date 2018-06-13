using Berry.Entity.CommonEntity;
using Berry.Util;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Berry.App.CacheRefresh
{
    /// <summary>
    /// 对于Redis的缓存
    /// </summary>
    public class RedisRefresh
    {
        public void JobStart()
        {
            var cacheType = ConfigHelper.GetValue("CacheType");
            if (cacheType != "Redis") return;

            string configFile = AppDomain.CurrentDomain.BaseDirectory + "/XmlConfig/RedisRefresh.xml";
            List<RedisRefreshEntity> configs = CommonHelper.ConvertXmlToObject<RedisRefreshEntity>(configFile, "RedisRefresh");

            var properties = new NameValueCollection
            {
                ["author"] = "zhaoyi_dsx@163.com"
            };
            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler sched = sf.GetScheduler();

            List<Type> allInheirtFromIJob = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IJob))).ToList();
            foreach (RedisRefreshEntity config in configs)
            {
                Type jobType = allInheirtFromIJob.FirstOrDefault(s => s.Name == config.JobName);
                if (jobType == null) continue;

                IJobDetail job = JobBuilder.Create(jobType)
                                    .WithIdentity(config.JobIdentityName, config.JobGroup)
                                    .Build();
                ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                    .WithIdentity(config.TriggerIdentityName, config.JobGroup)
                                    .WithCronSchedule(config.CronExpression)
                                    .Build();

                foreach (PropertyInfo property in typeof(RedisRefreshEntity).GetProperties())
                {
                    job.JobDataMap.Put(property.Name, property.GetValue(config, null));
                }

                DateTimeOffset ft = sched.ScheduleJob(job, trigger);
                Trace.WriteLine(ft.DateTime);
            }
            sched.Start();
        }
    }
}