using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berry.Entity.CommonEntity
{
    public class RedisRefreshEntity
    {
        /// <summary>
        /// 设置项名称(唯一标识)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 作业分组名称
        /// </summary>
        public string JobGroup { get; set; }
        /// <summary>
        /// 作业身份名称
        /// </summary>
        public string JobIdentityName { get; set; }
        /// <summary>
        /// 触发器身份名称
        /// </summary>
        public string TriggerIdentityName { get; set; }
        /// <summary>
        /// 复杂任务cron表达式
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        ///过期时间，单位：分钟
        /// </summary>
        public int TimeSpan { get; set; }

    }
}
