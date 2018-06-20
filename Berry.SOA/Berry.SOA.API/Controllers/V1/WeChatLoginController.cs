using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Berry.Code;
using Berry.Entity;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.SOA.API.Controllers.Base;
using Berry.SOA.API.ParameterModel;
using Berry.Util;

namespace Berry.SOA.API.Controllers.V1
{
    /// <summary>
    /// 微信登陆
    /// </summary>
    public class WeChatLoginController : BaseApiController
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
            BaseJsonResult<WeChatUserInfoEntity> resultMsg = new BaseJsonResult<WeChatUserInfoEntity> { Status = (int)JsonObjectStatus.Error, Message = "服务器未知错误。", Data = null };

            Logger(typeof(WeChatLoginController), "微信登陆-Login", () =>
            {
                if (!string.IsNullOrEmpty(arg.t) && arg.t.CheckTimeStamp())
                {
                    if (!string.IsNullOrEmpty(arg.access_token))
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
                                    resultMsg = new BaseJsonResult<WeChatUserInfoEntity>
                                    {
                                        Status = (int)JsonObjectStatus.Success,
                                        Data = userInfo,
                                        Message = JsonObjectStatus.Success.GetEnumDescription(),
                                        BackUrl = null
                                    };
                                }
                                else
                                {
                                    resultMsg = jsonResult;
                                }
                            }
                        }
                    }
                    else
                    {
                        resultMsg = new BaseJsonResult<WeChatUserInfoEntity>
                        {
                            Status = (int)JsonObjectStatus.Fail,
                            Data = null,
                            Message = JsonObjectStatus.Fail.GetEnumDescription() + "，请求参数[access_token]不能为空。",
                            BackUrl = null
                        };
                    }
                }
                else
                {
                    resultMsg = new BaseJsonResult<WeChatUserInfoEntity>
                    {
                        Status = (int)JsonObjectStatus.Fail,
                        Data = null,
                        Message = JsonObjectStatus.Fail.GetEnumDescription() + "，请求参数有误。",
                        BackUrl = null
                    };
                }
            }, e =>
            {
                resultMsg = new BaseJsonResult<WeChatUserInfoEntity>
                {
                    Status = (int)JsonObjectStatus.Exception,
                    Data = null,
                    Message = JsonObjectStatus.Exception.GetEnumDescription() + "，异常信息：" + e.Message,
                    BackUrl = null
                };
            });

            return resultMsg.TryToJson().ToHttpResponseMessage();
        }
    }
}
