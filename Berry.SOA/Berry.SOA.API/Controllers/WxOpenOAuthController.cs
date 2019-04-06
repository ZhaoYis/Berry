using Berry.BLL.CustomManage;
using Berry.Entity.CustomManage;
using Berry.Extension;
using Berry.SOA.API.Controllers.Base;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Containers;
using System;
using System.Web.Mvc;
using Berry.Util;

namespace Berry.SOA.API.Controllers
{
    /// <summary>
    /// 微信授权
    /// </summary>
    public class WxOpenOAuthController : BaseController
    {
        /// <summary>
        /// 微信配置
        /// </summary>
        private WechatConfigBLL wechatconfigbll = new WechatConfigBLL();
        /// <summary>
        /// 微信配置信息
        /// </summary>
        private WechatConfigBLL wechatConfigBll = new WechatConfigBLL();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取授权URL，SCOPE为snsapi_userinfo
        /// </summary>
        public ActionResult GetAuthorizeUrlWithUserInfo(string orgId, string returnUrl)
        {
            if (string.IsNullOrEmpty(orgId))
            {
                return Content("机构ID为空，无法拉取授权！");
            }

            WechatConfigEntity wechatConfig = wechatconfigbll.GetEntityByOrgId(orgId);
            if (wechatConfig != null)
            {
                if (!string.IsNullOrEmpty(wechatConfig.AppId) && !string.IsNullOrEmpty(wechatConfig.AppSecret) && !string.IsNullOrEmpty(wechatConfig.AuthDomainUrl))
                {
                    var state = DateTime.Now.Millisecond.ToString() + "_" + orgId;//随机数，用于识别请求可靠性
                    Session["State"] = state;//储存随机数到Session

                    string callback = wechatConfig.AuthDomainUrl + "/WxOpenOAuth/UserInfoCallback?returnUrl=" + returnUrl.UrlEncode();
                    string authUrl = Senparc.Weixin.MP.AdvancedAPIs.OAuthApi.GetAuthorizeUrl(wechatConfig.AppId, callback, state, OAuthScope.snsapi_userinfo);
                    ViewData["UrlUserInfo"] = authUrl;
                    return Redirect(authUrl);
                }
                else
                {
                    return Content("授权信息未配置，无法拉取授权！");
                }
            }
            else
            {
                return Content("机构不存在，无法拉取授权！");
            }
        }

        /// <summary>
        /// OAuthScope.snsapi_base方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult UserInfoCallback(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权,暂时无法使用该系统！");
            }

            if (string.IsNullOrEmpty(state) || state != Session["State"] as string)
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下，
                //建议用完之后就清空，将其一次性使用
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            OAuthAccessTokenResult result = null;
            string orgId = state.Split('_')[1];
            WechatConfigEntity wechatConfig = wechatconfigbll.GetEntityByOrgId(orgId);

            //通过，用code换取access_token
            try
            {
                result = OAuthApi.GetAccessToken(wechatConfig.AppId, wechatConfig.AppSecret, code);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }
            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            Session["OAuthAccessTokenStartTime"] = DateTime.Now;
            Session["OAuthAccessToken"] = result;

            //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息
            try
            {
                OAuthUserInfo userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                Uri uri = new Uri(returnUrl);
                try
                {
                    //TODO 保存用户基本信息
                }
                catch (Exception ex)
                {
                    return Content("保存用户基础信息失败！错误：" + ex.Message);
                }
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    //return Redirect(returnUrl); 
                    string callbackUrl = string.Format("{0}{1}{2}", returnUrl, string.IsNullOrEmpty(uri.Query) ? "?" : "&", "userId=" + userInfo.openid);
                    //ViewData["CallbackUrl"] = callbackUrl;
                    AccessTokenContainer.Register(wechatConfig.AppId, wechatConfig.AppSecret);
                    return Redirect(callbackUrl);
                }
                return Content("未能正确打开页面，请联系管理员！");
            }
            catch (ErrorJsonResultException ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 获取用户注册状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orgId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult GetUserRegisterStatus(string userId, string orgId, string returnUrl)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return Content("用户ID不能为空，无法进行授权");
            }

            //获取微信配置信息
            WechatConfigEntity wechatConfig = wechatConfigBll.GetEntityByOrgId(orgId);
            if (wechatConfig == null)
            {
                return Content("系统尚未配置微信授权信息，无法进行授权");
            }

            //TODO 自己的实际业务
            return Redirect(returnUrl);
        }
    }
}
