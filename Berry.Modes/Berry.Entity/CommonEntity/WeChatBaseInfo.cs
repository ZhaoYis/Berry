namespace Berry.Entity.CommonEntity
{
    /// <summary>
    /// 微信基础信息
    /// </summary>
    public class WeChatBaseInfo
    {
        #region 基础信息
        /// <summary>
        /// 应用唯一标识，在微信开放平台提交应用审核通过后获得
        /// </summary>
        public const string APP_ID = "";

        /// <summary>
        /// 应用密钥AppSecret，在微信开放平台提交应用审核通过后获得
        /// </summary>
        public const string APP_SECRET = "";
        #endregion

        #region 接口
        /// <summary>
        /// 微信公众平台接口地址
        /// </summary>
        private const string BASE_WE_CHAT_PUBLIC_API_URL = "https://api.weixin.qq.com";

        /// <summary>
        /// 拉取用户信息
        /// <para>{0}:网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同</para>
        /// <para>{1}:用户的唯一标识</para>
        /// <para>{2}:返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</para>
        /// </summary>
        public const string I_GET_USER_INFO = BASE_WE_CHAT_PUBLIC_API_URL + "/sns/userinfo?access_token={0}&openid={1}&lang={2}";

        #endregion
    }
}