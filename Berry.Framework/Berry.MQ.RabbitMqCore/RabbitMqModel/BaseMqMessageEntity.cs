using System;
using System.Security.Cryptography;
using System.Text;

namespace Berry.MQ.RabbitMqCore.RabbitMqModel
{
    /// <summary>
    /// 基础消息模型
    /// </summary>
    public class BaseMqMessageEntity
    {
        /// <summary>
        /// 基础消息模型
        /// </summary>
        public BaseMqMessageEntity()
        {
        }

        /// <summary>
        /// 基础消息模型（默认初始化方式，可以自定义签名计算方式）
        /// </summary>
        /// <remarks>签名计算方式：MD5（{秒级时间戳}{数据包}{秒级时间戳}）</remarks>
        /// <param name="body">数据包</param>
        public BaseMqMessageEntity(string body)
        {
            this.Body = body;
            this.CreateTime = this.GetTimeStamp(DateTime.Now).ToString();
            this.Sign = this.GetSign(this.CreateTime + this.Body + this.CreateTime);
        }

        /// <summary>
        /// 数据包
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; private set; }

        /// <summary>
        /// 消息MD5
        /// </summary>
        public string Sign { get; private set; }

        #region 计算默认签名字符串（可以自定义签名计算方式）

        /// <summary>
        /// 计算默认签名字符串（可以自定义签名计算方式）
        /// <remarks>默认签名计算方式：MD5（{秒级时间戳}{数据包}{秒级时间戳}），长度32位</remarks>
        /// </summary>
        /// <param name="source">待签字符串</param>
        /// <returns></returns>
        protected virtual string GetSign(string source)
        {
            return this.Md5(source, "x2");
        }
        #endregion

        #region MD5加密

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source">加密字符</param>
        /// <param name="len">加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位</param>
        /// <returns></returns>
        private string Md5(string source, string len = "x2")
        {
            if (string.IsNullOrEmpty(source)) return "";

            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(sor);

            StringBuilder builder = new StringBuilder();
            foreach (byte s in result)
            {
                builder.Append(s.ToString(len));
            }
            return builder.ToString();
        }

        #endregion

        #region DateTime时间格式转换为Unix时间戳格式

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式，单位：秒
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        protected long GetTimeStamp(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }
        #endregion
    }
}