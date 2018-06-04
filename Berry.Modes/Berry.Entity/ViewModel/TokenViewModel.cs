namespace Berry.Entity.ViewModel
{
    /// <summary>
    /// Token信息
    /// </summary>
    public class TokenViewModel
    {
        /// <summary>
        /// AppKey
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 用户名对应签名Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Token过期时间
        /// </summary>
        public string ExpireTime { get; set; }
    }
}