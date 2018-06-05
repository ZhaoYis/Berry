using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Berry.SOA.API.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "首页";

            return View();
        }

        /// <summary>
        /// 接口授权说明
        /// </summary>
        /// <returns></returns>
        public ActionResult ApiOAuth()
        {
            return View();
        }

        /// <summary>
        /// 错误码说明
        /// </summary>
        /// <returns></returns>
        public ActionResult ErrorCode()
        {
            return View();
        }


    }
}
