using System.Net;
using System.Net.Http;
using System.Web.Http;
using Berry.Code;
using Berry.Entity;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.SOA.API.Controllers.Base;
using Berry.SOA.API.Controllers.Interface;
using Berry.SOA.API.ParameterModel;
using Berry.Util;

namespace Berry.SOA.API.Controllers
{
    /// <summary>
    /// 微信登陆
    /// </summary>
    public class WeChatLoginController : BaseApiController, IWeChatLogin
    {
        private static HttpHelper httpHelper = new HttpHelper();

        /// <summary>
        /// 微信登陆
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual HttpResponseMessage Login(WeChatLoginArgEntity arg)
        {
            BaseJsonResult<WeChatUserInfoEntity> resultMsg = null;

            Logger(this.GetType(), "微信登陆-Login", () =>
            {
                if (this.CheckBaseArgument(arg, out resultMsg))
                {
                    HttpItem httpItem = new HttpItem
                    {
                        Url = string.Format(WeChatBaseInfo.I_GET_USER_INFO, arg.access_token, arg.openid, "zh_CN"),
                        Method = "GET",
                        ContentType = "application/json"
                    };
                    HttpResult result = httpHelper.GetHtml(httpItem);
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        if (!string.IsNullOrEmpty(result.Html))
                        {
                            BaseJsonResult<WeChatUserInfoEntity> jsonResult = this.PreprocessingWeChatData<WeChatUserInfoEntity>(result.Html);
                            if (jsonResult.Status == (int)JsonObjectStatus.Success && jsonResult.Data != null)
                            {
                                WeChatUserInfoEntity userInfo = jsonResult.Data;
                                resultMsg = this.GetBaseJsonResult<WeChatUserInfoEntity>(userInfo, JsonObjectStatus.Success);
                            }
                            else
                            {
                                resultMsg = jsonResult;
                            }
                        }
                    }
                }
            }, e =>
            {
                resultMsg = this.GetBaseJsonResult<WeChatUserInfoEntity>(JsonObjectStatus.Exception, "，异常信息：" + e.Message);
            });

            return resultMsg.TryToHttpResponseMessage();
        }
    }
}
