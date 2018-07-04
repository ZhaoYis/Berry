using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;

namespace Berry.SignalRService.Schedu.Jobs
{
    /// <summary>
    /// Quartz任务管理类
    /// </summary>
    public static class QuartzUtil
    {
        private static ISchedulerFactory sf = null;
        private static IScheduler sched = null;

        static QuartzUtil()
        {
            sf = new StdSchedulerFactory();
            sched = sf.GetScheduler();
            sched.Start();
        }

        /// <summary>
        /// 添加Job 并且以定点的形式运行 不带参数的cron表达式新建job
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JobName"></param>
        /// <param name="CronTime"></param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string JobName, string CronTime) where T : IJob
        {
            return AddJob<T>(JobName, CronTime, null);
        }

        /// <summary>
        /// 添加Job 并且以定点的形式运行  参数为Cron表达式，可传参数。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName">keyName</param>
        /// <param name="cronTime">Cron表达式</param>
        /// <param name="jobDataMap">传递的参数</param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string jobName, string cronTime, JobDataMap jobDataMap) where T : IJob
        {
            IJobDetail jobCheck = JobBuilder.Create<T>().WithIdentity(jobName, jobName + "_Group").SetJobData(jobDataMap).Build();//.UsingJobData("connIds", connIds).Build();
            ICronTrigger cronTrigger = new CronTriggerImpl(jobName + "_CronTrigger", jobName + "_TriggerGroup", cronTime);

            if (sched.CheckExists(new JobKey(jobName, jobName + "_Group")))
            {
                sched.ResumeJob(new JobKey(jobName, jobName + "_Group"));
            }
            else
            {
                return sched.ScheduleJob(jobCheck, cronTrigger);
            }
            return new DateTimeOffset(DateTime.Now);
        }

        /// <summary>
        /// 添加Job 并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JobName"></param>
        /// <param name="SimpleTime">毫秒数</param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string JobName, int SimpleTime) where T : IJob
        {
            return AddJob<T>(JobName, DateTime.UtcNow.AddMilliseconds(1), TimeSpan.FromMilliseconds(SimpleTime));
        }

        /// <summary>
        /// 添加Job 并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JobName"></param>
        /// <param name="SimpleTime">毫秒数</param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string JobName, DateTimeOffset StartTime, int SimpleTime) where T : IJob
        {
            return AddJob<T>(JobName, StartTime, TimeSpan.FromMilliseconds(SimpleTime));
        }

        /// <summary>
        /// 添加Job 并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JobName"></param>
        /// <param name="SimpleTime"></param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string JobName, DateTimeOffset StartTime, TimeSpan SimpleTime) where T : IJob
        {
            return AddJob<T>(JobName, StartTime, SimpleTime, new Dictionary<string, object>());
        }

        /// <summary>
        /// 添加Job 并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JobName"></param>
        /// <param name="StartTime"></param>
        /// <param name="SimpleTime">毫秒数</param>
        /// <param name="jobDataMap"></param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string JobName, DateTimeOffset StartTime, int SimpleTime, string MapKey, object MapValue) where T : IJob
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add(MapKey, MapValue);
            return AddJob<T>(JobName, StartTime, TimeSpan.FromMilliseconds(SimpleTime), map);
        }

        /// <summary>
        /// 添加Job 并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JobName">JobKey</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="SimpleTime">时间差</param>
        /// <param name="jobDataMap">传递的参数</param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string JobName, DateTimeOffset StartTime, TimeSpan SimpleTime, Dictionary<string, object> map) where T : IJob
        {
            IJobDetail jobCheck = JobBuilder.Create<T>().WithIdentity(JobName, JobName + "_Group").Build();
            jobCheck.JobDataMap.PutAll(map);
            ISimpleTrigger triggerCheck = new SimpleTriggerImpl(JobName + "_SimpleTrigger", JobName + "_TriggerGroup",
                                        StartTime,
                                        null,
                                        SimpleTriggerImpl.RepeatIndefinitely,
                                        SimpleTime);
            return sched.ScheduleJob(jobCheck, triggerCheck);
        }

        /// <summary>
        /// 修改触发器时间,需要job名,以及修改结果
        /// CronTriggerImpl类型触发器
        /// </summary>
        public static void UpdateTime(string jobName, string CronTime)
        {
            TriggerKey TKey = new TriggerKey(jobName + "_CronTrigger", jobName + "_TriggerGroup");
            CronTriggerImpl cti = sched.GetTrigger(TKey) as CronTriggerImpl;
            cti.CronExpression = new CronExpression(CronTime);
            sched.RescheduleJob(TKey, cti);
        }

        /// <summary>
        /// 修改触发器时间,需要job名,以及修改结果
        /// SimpleTriggerImpl类型触发器
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="SimpleTime">分钟数</param>
        public static void UpdateTime(string jobName, int SimpleTime)
        {
            UpdateTime(jobName, TimeSpan.FromMinutes(SimpleTime));
        }

        /// <summary>
        /// 修改触发器时间,需要job名,以及修改结果
        /// SimpleTriggerImpl类型触发器
        /// </summary>
        public static void UpdateTime(string jobName, TimeSpan SimpleTime)
        {
            TriggerKey TKey = new TriggerKey(jobName + "_SimpleTrigger", jobName + "_TriggerGroup");
            SimpleTriggerImpl sti = sched.GetTrigger(TKey) as SimpleTriggerImpl;
            sti.RepeatInterval = SimpleTime;
            sched.RescheduleJob(TKey, sti);
        }

        /// <summary>
        /// 暂停所有Job
        /// </summary>
        public static void PauseAll()
        {
            sched.PauseAll();
        }

        /// <summary>
        /// 恢复所有Job
        /// </summary>
        public static void ResumeAll()
        {
            sched.ResumeAll();
        }

        /// <summary>
        /// 暂停某个任务
        /// </summary>
        /// <param name="JobName"></param>
        public static void PauseJob(string JobName)
        {
            JobKey jk = new JobKey(JobName);
            sched.PauseJob(jk);
        }

        /// <summary>
        /// 恢复指定的Job
        /// </summary>
        /// <param name="JobKey"></param>
        public static void ResumeJob(string JobName)
        {
            JobKey jk = new JobKey(JobName);
            sched.ResumeJob(jk);
        }

        /// <summary>
        /// 删除Job
        /// </summary>
        /// <param name="JobName"></param>
        public static void DeleteJob(string JobName)
        {
            JobKey jk = new JobKey(JobName);
            sched.DeleteJob(jk);
        }

        /// <summary>
        /// 卸载定时器
        /// </summary>
        /// <param name="waitForJobsToComplete">是否等待job执行完成</param>
        public static void Shutdown(bool waitForJobsToComplete)
        {
            sched.Shutdown(waitForJobsToComplete);
        }
    }
}