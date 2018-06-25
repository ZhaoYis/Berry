using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Berry.SignalRService.Models;

namespace Berry.SignalRService.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LoadUserInfo()
        {
            ConcurrentDictionary<string, string> dic = ChatsHub.GetAllUserListDict();

            return Json(dic, JsonRequestBehavior.AllowGet);
        }
    }
}