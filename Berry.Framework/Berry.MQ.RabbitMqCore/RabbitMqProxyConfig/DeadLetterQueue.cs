using System;

namespace Berry.MQ.RabbitMqCore.RabbitMqProxyConfig
{
    /// <summary>
    /// 死信队列实体
    /// </summary>
    [RabbitMq("Dead-Letter-{Queue}", ExchangeName = "Dead-Letter-{Exchange}", RoutingKey = "Dead-Letter-{RoutingKey}")]
    public class DeadLetterQueue
    {
        /// <summary>
        /// 死信信息
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 消息交换机,它指定消息按什么规则,路由到哪个队列
        /// </summary>
        public string Exchange { get; set; }
        /// <summary>
        /// 消息的载体,每个消息都会被投到一个或多个队列。 
        /// </summary>
        public string Queue { get; set; }
        /// <summary>
        /// 路由关键字,exchange根据这个关键字进行消息投递
        /// </summary>
        public string RoutingKey { get; set; }
        /// <summary>
        /// 重试次数
        /// </summary>
        public int RetryCount { get; set; }
        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionMsg { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}