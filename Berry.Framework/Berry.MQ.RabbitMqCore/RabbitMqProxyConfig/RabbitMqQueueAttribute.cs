using System;

namespace Berry.MQ.RabbitMqCore.RabbitMqProxyConfig
{
    /// <summary>
    /// 自定义的RabbitMq队列信息实体特性
    /// </summary>
    public class RabbitMqAttribute : Attribute
    {
        public RabbitMqAttribute(string queueName)
        {
            QueueName = queueName;
        }

        /// <summary>
        /// 交换机名称
        /// </summary>
        public string ExchangeName { get; set; }

        /// <summary>
        /// 路由关键字.格式必须是以点号“.”分割的字符表，最长不能超过255 bytes
        /// <para>*(星号)代表任意一个单词</para>
        /// <para>#(hash)0个或多个单词</para>
        /// </summary>
        public string RoutingKey { get; set; }

        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueueName { get; private set; }

        /// <summary>
        /// 是否持久化
        /// </summary>
        public bool IsProperties { get; set; }
    }
}