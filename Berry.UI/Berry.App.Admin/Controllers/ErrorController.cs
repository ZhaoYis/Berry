using System.Collections.Generic;
using System.Web.Mvc;

namespace Berry.App.Admin.Controllers
{
    /// <summary>
    /// 错误处理
    /// </summary>
    public class ErrorController : Controller
    {
        #region 视图功能

        /// <summary>
        /// 错误页面（异常页面）
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ActionResult ErrorMessage(string message)
        {
            Dictionary<string, string> modulesError = (Dictionary<string, string>)HttpContext.Application["error"];
            ViewData["Message"] = modulesError;
            return View();
        }

        /// <summary>
        /// 错误页面（错误路径404）
        /// </summary>
        /// <returns></returns>
        public ActionResult ErrorPath404()
        {
            return View();
        }

        /// <summary>
        /// 错误页面（升级浏览器软件）
        /// </summary>
        /// <returns></returns>
        public ActionResult ErrorBrowser()
        {
            return View();
        }

        #endregion 视图功能
    }
}