using Berry.Code;
using Berry.Code.Operator;
using System.Web.Mvc;
using Berry.Util;

namespace Berry.App.Admin.Handler
{
    /// <summary>
    /// 登录认证（会话验证组件）
    /// </summary>
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        private readonly LoginMode _customMode;

        /// <summary>默认构造</summary>
        /// <param name="mode">认证模式</param>
        public HandlerLoginAttribute(LoginMode mode)
        {
            _customMode = mode;
        }

        /// <summary>
        /// 响应前执行登录验证,查看当前用户是否有效
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //登录拦截是否忽略
            if (_customMode == LoginMode.Ignore)
            {
                return;
            }
            //登录是否过期
            if (OperatorProvider.Provider.IsOverdue())
            {
                CookieHelper.WriteCookie("__login_error__", "1");//登录已超时,请重新登录
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
            //是否已登录
            var onLine = OperatorProvider.Provider.IsOnLine();
            if (onLine == 0)
            {
                CookieHelper.WriteCookie("__login_error__", "2");//您的帐号已在其它地方登录,请重新登录
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
            else if (onLine == -1)
            {
                CookieHelper.WriteCookie("__login_error__", "-1");//缓存已超时,请重新登录
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
        }
    }
}