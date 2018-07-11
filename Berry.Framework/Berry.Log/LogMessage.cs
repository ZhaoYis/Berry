using System;

namespace Berry.Log
{
    /// <summary>
    /// 日志实体
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; } = DateTime.Now;
        /// <summary>
        /// Url地址
        /// </summary>
        public string Url { get; set; } = "[缺省项]";
        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; } = "[缺省项]";
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; } = "[缺省项]";
        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; } = "[缺省项]";
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; } = "[缺省项]";
        /// <summary>
        /// UserAgent
        /// </summary>
        public string UserAgent { get; set; } = "[缺省项]";
        /// <summary>
        /// 操作人
        /// </summary>
        public string UserName { get; set; } = "[缺省项]";
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = "[缺省项]";
        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionInfo { get; set; } = "[缺省项]";
        /// <summary>
        /// 异常来源
        /// </summary>
        public string ExceptionSource { get; set; } = "[缺省项]";
        /// <summary>
        /// 异常信息备注
        /// </summary>
        public string ExceptionRemark { get; set; } = "[缺省项]";
    }
}