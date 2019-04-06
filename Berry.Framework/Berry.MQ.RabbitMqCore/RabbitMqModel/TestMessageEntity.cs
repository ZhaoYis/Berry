using Berry.MQ.RabbitMqCore.RabbitMqProxyConfig;

namespace Berry.MQ.RabbitMqCore.RabbitMqModel
{
    /// <summary>
    /// 测试
    /// </summary>
    [RabbitMq("RabbitMq.Direct.QueueName.Test", ExchangeName = "RabbitMq.Direct.ExchangeName.Test", RoutingKey = "RabbitMq.Direct.RoutingKey.Test", IsProperties = false)]
    public class TestMessageEntity : BaseMqMessageEntity
    {
        /// <summary>
        /// 基础消息模型
        /// </summary>
        /// <param name="body">数据包</param>
        public TestMessageEntity(string body) : base(body)
        {
            
        }

    }
}