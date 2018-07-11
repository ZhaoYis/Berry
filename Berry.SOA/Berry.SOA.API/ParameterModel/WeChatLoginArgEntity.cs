using System.ComponentModel.DataAnnotations;

namespace Berry.SOA.API.ParameterModel
{
    /// <summary>
    /// 微信登陆传回服务器参数
    /// </summary>
    public class WeChatLoginArgEntity : BaseParameterEntity
    {
        /// <summary>
        ///  接口调用凭证
        /// </summary>
        [Required(ErrorMessage = "接口调用凭证不能为空")]
        public string access_token { get; set; }
        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        public string expires_in { get; set; }
        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        public string refresh_token { get; set; }
        /// <summary>
        /// 授权用户唯一标识
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string scope { get; set; }
        /// <summary>
        /// 当且仅当该网站应用已获得该用户的userinfo授权时，才会出现该字段。
        /// </summary>
        public string unionid { get; set; }
    }
}