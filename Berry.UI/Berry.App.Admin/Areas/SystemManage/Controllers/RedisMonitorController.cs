using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Berry.App.Admin.Handler;
using Berry.Cache.Core.Model;
using Berry.Cache.Core.Redis;

namespace Berry.App.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// Redis监控
    /// </summary>
    public class RedisMonitorController : BaseController
    {
        // GET: SystemManage/RedisMonitor

        #region 视图

        public ActionResult Index()
        {
            var redisServers = RedisServerConfig.RedisServers;
            ViewBag.RedisServers = redisServers;
            return View();
        }

        public ActionResult Details(string serverId)
        {
            return View();
        }

        public ActionResult SimpleDetails(string serverId)
        {
            return PartialView();
        }

        public ActionResult RichDetails(string serverId)
        {
            var result = RedisHelper.GetRedisInfo(serverId);
            ViewBag.InfoMsg = result;
            return PartialView();
        }

        public ActionResult InfoInstructions()
        {
            return View();
        }

        public ActionResult Clients(string serverId)
        {
            return PartialView();
        }

        public ActionResult GetClients(string serverId)
        {
            var result = RedisHelper.GetClients(serverId);
            ViewBag.Clients = result;
            return PartialView();
        }

        public ActionResult BaseRedisStatus(string serverId)
        {
            RedisServerModel model = RedisServerConfig.RedisServers.FirstOrDefault(p => p.ServerId == serverId);
            var serverResponse = RedisHelper.GetRedisServerResponse(serverId);
            ViewBag.RedisServer = model;
            ViewBag.ServerResponse = serverResponse;
            return PartialView();
        }

        #endregion 视图

        #region 方法

        public ActionResult GetRedisStatus(string serverId)
        {
            var model = RedisHelper.GetRedisServerResponse(serverId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SimpleDetailsData(string serverId)
        {
            var result = RedisHelper.GetRedisInfoRow(serverId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RichDetailsData(string serverId)
        {
            var result = RedisHelper.GetRedisInfo(serverId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 更新读取配置文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RefreshServerConfig()
        {
            RedisServerConfig.LoadConfig();
            return Content("刷新成功");
        }

        #endregion 方法

        /// <summary>
        /// 出去字母后判断是否为数值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool RelaceIsNum(string value)
        {
            var newValue = Regex.Replace(value, "[a-zA-Z]", "");
            decimal num;
            return decimal.TryParse(newValue, out num);
        }
    }
}