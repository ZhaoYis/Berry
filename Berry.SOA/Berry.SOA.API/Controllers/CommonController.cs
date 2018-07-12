using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.SOA.API.Controllers.Base;
using Berry.SOA.API.Controllers.Interface;
using Berry.SOA.API.ParameterModel;
using Berry.Util.JWT;

namespace Berry.SOA.API.Controllers
{
    /// <summary>
    /// 公共接口
    /// </summary>
    public class CommonController : BaseApiController, ICommon
    {
        #region 获取Token（JWT实现方式）

        /// <summary>
        /// 获取授权Token
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreToken(true)]
        public HttpResponseMessage GetJWTToken(GetTokenArgEntity arg)
        {
            BaseJsonResult<string> resultMsg = this.GetBaseJsonResult<string>();

            Logger(this.GetType(), "获取授权Token-GetJWTToken", () =>
            {
                if (!string.IsNullOrEmpty(arg.t))
                {
                    //TODO 根据UserID校验用户是否存在
                    if (true)
                    {
                        JWTPlayloadInfo playload = new JWTPlayloadInfo
                        {
                            iss = "Berry.Service",
                            sub = arg.Account,
                            aud = arg.UserId
                        };
                        string token = JWTHelper.GetToken(playload);

                        resultMsg = this.GetBaseJsonResult<string>(token, JsonObjectStatus.Success);
                    }
                    else
                    {
                        resultMsg = this.GetBaseJsonResult<string>("", JsonObjectStatus.UserNotExist);
                    }
                }
                else
                {
                    resultMsg = this.GetBaseJsonResult<string>("", JsonObjectStatus.Fail, "，请求参数有误。");
                }
            }, e =>
            {
                resultMsg = this.GetBaseJsonResult<string>("", JsonObjectStatus.Exception, "，异常信息：" + e.Message);
            });

            return resultMsg.ToHttpResponseMessage();
        }

        #endregion

    }
}
