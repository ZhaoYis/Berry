using Berry.BLL.AuthorizeManage;
using Berry.Code;
using Berry.Code.Operator;
using Berry.Util;
using System.Web;
using System.Web.Mvc;
using Berry.Extension;

namespace Berry.App.Admin.Handler
{
    /// <summary>
    /// （权限认证+安全）拦截组件
    /// </summary>
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        private PermissionMode _customMode;
        private static AuthorizeBLL authorizeBll = new AuthorizeBLL();

        /// <summary>默认构造</summary>
        /// <param name="mode">认证模式</param>
        public HandlerAuthorizeAttribute(PermissionMode mode)
        {
            _customMode = mode;
        }

        /// <summary>
        /// 权限认证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //是否超级管理员
            if (OperatorProvider.Provider.Current().IsSystem)
            {
                return;
            }
            //是否忽略
            if (_customMode == PermissionMode.Ignore)
            {
                return;
            }
            //忽略匿名操作
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            //IP过滤
            if (!this.FilterIP())
            {
                ContentResult content = new ContentResult();
                content.Content = "<script type='text/javascript'>alert('很抱歉！您当前所在IP被系统拒绝访问！');top.Loading(false);</script>";
                filterContext.Result = content;
                return;
            }
            //时段过滤
            if (!this.FilterTime())
            {
                ContentResult content = new ContentResult();
                content.Content = "<script type='text/javascript'>alert('很抱歉！系统不允许您在当前时段访问！');top.Loading(false);</script>";
                filterContext.Result = content;
                return;
            }
            //认证执行
            if (!this.ActionAuthorize(filterContext))
            {
                ContentResult content = new ContentResult();
                content.Content = "<script type='text/javascript'>alert('很抱歉！您的权限不足，访问被拒绝！');top.Loading(false);</script>";
                filterContext.Result = content;
                return;
            }
        }

        /// <summary>
        /// IP过滤
        /// </summary>
        /// <returns></returns>
        private bool FilterIP()
        {
            //bool isFilterIP = ConfigHelper.GetValue("FilterIP").ToBool();
            //if (isFilterIP == true)
            //{
            //    return new FilterIPBLL().FilterIP();
            //}
            return true;
        }

        /// <summary>
        /// 时段过滤
        /// </summary>
        /// <returns></returns>
        private bool FilterTime()
        {
            //bool isFilterIP = ConfigHelper.GetValue("FilterTime").ToBool();
            //if (isFilterIP == true)
            //{
            //    return new FilterTimeBLL().FilterTime();
            //}
            return true;
        }

        /// <summary>
        /// 执行权限认证
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        private bool ActionAuthorize(ActionExecutingContext filterContext)
        {
            string currentUrl = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            string userId = OperatorProvider.Provider.Current().UserId;
            string currentModuleId = OperatorProvider.CurrentModuleId;

            return authorizeBll.ActionAuthorize(userId, currentModuleId, currentUrl);
        }
    }
}