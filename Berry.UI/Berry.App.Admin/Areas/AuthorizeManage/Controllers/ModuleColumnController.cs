using Berry.App.Admin.Handler;
using Berry.BLL.AuthorizeManage;
using Berry.Entity.AuthorizeManage;
using Berry.Extension;
using System.Linq;
using System.Web.Mvc;

namespace Berry.App.Admin.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 系统视图
    /// </summary>
    public class ModuleColumnController : BaseController
    {
        private ModuleColumnBLL moduleColumnBLL = new ModuleColumnBLL();

        #region 视图功能

        /// <summary>
        /// 视图表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BatchAdd()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string moduleId)
        {
            var data = moduleColumnBLL.GetList(moduleId);
            return Content(data.TryToJson());
        }

        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetTreeListJson(string moduleId)
        {
            var data = moduleColumnBLL.GetList(moduleId);
            if (data != null)
            {
                return Content(data.TryToJson());
            }
            return null;
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 视图列表Json转换视图树形Json
        /// </summary>
        /// <param name="moduleColumnJson">视图列表</param>
        /// <returns>返回树形列表Json</returns>
        [HttpPost]
        public ActionResult ListToListTreeJson(string moduleColumnJson)
        {
            var data = moduleColumnJson.JsonToList<ModuleColumnEntity>().OrderBy(m => m.SortCode);
            return Content(data.TryToJson());
        }

        #endregion 提交数据
    }
}