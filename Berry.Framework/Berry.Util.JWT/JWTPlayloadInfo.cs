using System;

namespace Berry.Util.JWT
{
    /// <summary>
    /// JWT载荷实体
    /// </summary>
    public sealed class JWTPlayloadInfo
    {
        /// <summary>
        /// jwt签发者
        /// </summary>
        public string iss { get; set; } = "Berry.Service";
        /// <summary>
        /// jwt所面向的用户
        /// </summary>
        public string sub { get; set; } = "ALL";
        /// <summary>
        /// 接收jwt的一方
        /// </summary>
        public string aud { get; set; } = "guest";
        /// <summary>
        /// jwt的签发时间
        /// </summary>
        public string iat { get; set; } = DateTimeHelper.GetTimeStamp(DateTime.Now).ToString();
        /// <summary>
        /// jwt的过期时间，这个过期时间必须要大于签发时间.默认60分钟
        /// </summary>
        public string exp { get; set; }
        /// <summary>
        /// 定义在什么时间之前，该jwt都是不可用的.
        /// </summary>
        public int nbf { get; set; }
        /// <summary>
        /// jwt的唯一身份标识，主要用来作为一次性token,从而回避重放攻击。
        /// </summary>
        public string jti { get; set; } = CommonHelper.GetGuid();
        /// <summary>
        /// 用户ID。自定义字段
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 扩展字段。自定义字段
        /// </summary>
        public string extend { get; set; }
    }
}