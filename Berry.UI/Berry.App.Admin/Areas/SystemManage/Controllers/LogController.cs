using Berry.App.Admin.Handler;
using Berry.BLL.SystemManage;
using Berry.Code;
using Berry.Util;
using System.Web.Mvc;
using Berry.Entity.CommonEntity;
using Berry.Extension;

namespace Berry.App.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class LogController : BaseController
    {
        private LogBLL logBll = new LogBLL();

        #region 视图功能

        /// <summary>
        /// 日志管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveLog()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 日志列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(PaginationEntity pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = logBll.GetPageList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.TryToJson());
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveLog(int categoryId, string keepTime)
        {
            logBll.RemoveLog(categoryId, keepTime);
            return Success("清空成功。");
        }

        #endregion 提交数据
    }
}