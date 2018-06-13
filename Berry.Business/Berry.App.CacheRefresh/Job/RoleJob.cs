using System.Diagnostics;
using Berry.App.Cache;
using Quartz;

namespace Berry.App.CacheRefresh.Job
{
    public class RoleJob : JobHelper, IJob
    {
        /// <summary>
        /// 这里是作业调度每次定时执行方法
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            var config = reHelper.GetConfigFromDataMap(context.JobDetail.JobDataMap);
            Trace.WriteLine("开始刷新RoleCache,cron表达式：" + config.CronExpression);

            new RoleCache().RefreshCache(reHelper.GetExpireTime(config.TimeSpan));
        }
    }
}