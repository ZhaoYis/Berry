namespace Berry.Entity.ViewModel
{
    /// <summary>
    /// Token对象
    /// </summary>
    public class AccessTokenDto
    {
        /// <summary>
        /// Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public string ExpiryTime { get; set; }
    }
}