using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Berry.Code;
using Berry.Entity;
using Berry.Entity.ViewModel;
using Berry.Extension;
using Berry.SOA.API.Controllers.Base;
using Berry.SOA.API.Controllers.Interface;
using Berry.SOA.API.ParameterModel;
using Berry.Util;
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
        [Route("api/Common/GetAuthorizationToken")]
        public HttpResponseMessage GetAuthorizationToken(GetTokenArgEntity arg)
        {
            BaseJsonResult<AccessTokenDto> resultMsg = null;

            Logger(this.GetType(), "获取授权Token-GetAuthorizationToken", () =>
            {
                if (this.CheckBaseArgument(arg, out resultMsg))
                {
                    if (arg.Account.Equals("guest") && arg.UserId.Equals("guest"))
                    {
                        JWTPlayloadInfo playload = new JWTPlayloadInfo
                        {
                            iss = "S_COMMON_TOKTN",
                            sub = arg.Account,
                            aud = arg.UserId,
                            userid = CommonHelper.GetGuid(),
                            extend = "PUBLIC_TOKTN"
                        };
                        string token = JWTHelper.GetToken(playload);

                        AccessTokenDto access = new AccessTokenDto
                        {
                            AccessToken = token,
                            ExpiryTime = playload.exp
                        };

                        resultMsg = this.GetBaseJsonResult<AccessTokenDto>(access, JsonObjectStatus.Success);
                    }
                    else
                    {
                        //TODO 根据UserID校验用户是否存在
                        //JWTPlayloadInfo playload = new JWTPlayloadInfo
                        //{
                        //    iss = "S_USER_TOKTN",
                        //    sub = arg.Account,
                        //    aud = arg.UserId,
                        //    userid = CommonHelper.GetGuid(),
                        //    extend = "USER_TOKTN"
                        //};
                        //string token = JWTHelper.GetToken(playload);

                        //AccessTokenDto access = new AccessTokenDto
                        //{
                        //    AccessToken = token,
                        //    ExpiryTime = playload.exp
                        //};
                        //resultMsg = this.GetBaseJsonResult<AccessTokenDto>(access, JsonObjectStatus.Success);

                        resultMsg = this.GetBaseJsonResult<AccessTokenDto>(JsonObjectStatus.UserNotExist);
                    }
                }
            }, e =>
            {
                resultMsg = this.GetBaseJsonResult<AccessTokenDto>(JsonObjectStatus.Exception, "，异常信息：" + e.Message);
            });

            return resultMsg.TryToHttpResponseMessage();
        }

        #endregion

        #region 刷新Token

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreToken(true)]
        [Route("api/Common/RefreshAuthorizationToken")]
        public HttpResponseMessage RefreshAuthorizationToken(GetTokenArgEntity arg)
        {
            BaseJsonResult<string> resultMsg = null;

            Logger(this.GetType(), "刷新Token-RefreshAuthorizationToken", () =>
            {
                if (this.CheckBaseArgument(arg, out resultMsg))
                {
                    JWTHelper.CheckTokenHasExpiry(arg.UserId, arg.Account);

                    resultMsg = this.GetBaseJsonResult<string>("Token刷新成功", JsonObjectStatus.Success);
                }
            }, e =>
            {
                resultMsg = this.GetBaseJsonResult<string>(JsonObjectStatus.Exception, "，异常信息：" + e.Message);
            });

            return resultMsg.TryToHttpResponseMessage();
        }

        #endregion 刷新Token
    }
}
