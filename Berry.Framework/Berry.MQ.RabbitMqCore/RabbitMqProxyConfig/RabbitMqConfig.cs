using System;

namespace Berry.MQ.RabbitMqCore.RabbitMqProxyConfig
{
    /// <summary>
    /// 配置
    /// </summary>
    public class MqConfig
    {
        /// <summary>
        /// 默认配置
        /// </summary>
        public MqConfig()
        {
            this.Host = "localhost";
            this.VirtualHost = "/";
            this.HeartBeat = 30;
            this.AutomaticRecoveryEnabled = true;
            this.NetworkRecoveryInterval = new TimeSpan(100);
            this.UserName = "guest";
            this.Password = "guest";
        }

        /// <summary>
        /// 自定义账户密码
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        public MqConfig(string userName, string password)
        {
            this.Host = "localhost";
            this.VirtualHost = "/";
            this.HeartBeat = 30;
            this.AutomaticRecoveryEnabled = true;
            this.NetworkRecoveryInterval = new TimeSpan(100);
            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        /// 主机地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 虚拟主机
        /// </summary>
        public string VirtualHost { get; set; }

        /// <summary>
        /// 心跳检测时间
        /// </summary>
        public ushort HeartBeat { get; set; }

        /// <summary>
        /// 是否自动重连
        /// </summary>
        public bool AutomaticRecoveryEnabled { get; set; }

        /// <summary>
        /// 重连时间
        /// </summary>
        public TimeSpan NetworkRecoveryInterval { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// 交换器类型
    /// </summary>
    public static class ExchangeTypeCode
    {
        /// <summary>
        /// 处理路由键。需要将一个队列绑定到交换机上，要求该消息与一个特定的路由键完全
        /// 匹配。这是一个完整的匹配。如果一个队列绑定到该交换机上要求路由键 “dog”，则只有被标记为“dog”的
        /// 消息才被转发，不会转发dog.puppy，也不会转发dog.guard，只会转发dog
        /// </summary>
        public const string Direct = "direct";
        /// <summary>
        /// 不处理路由键。你只需要简单的将队列绑定到交换机上。一个发送到交换机的消息都
        /// 会被转发到与该交换机绑定的所有队列上。很像子网广播，每台子网内的主机都获得了一份复制的消息。Fanout
        /// 交换机转发消息是最快的。
        /// </summary>
        public const string Fanout = "fanout";
        /// <summary>
        /// 将路由键和某模式进行匹配。此时队列需要绑定要一个模式上。符号“#”匹配一个或多
        /// 个词，符号“*”匹配不多不少一个词。因此“audit.#”能够匹配到“audit.irs.corporate”，但是“audit.*”
        /// 只会匹配到“audit.irs”。
        /// </summary>
        public const string Topic = "topic";
    }
}