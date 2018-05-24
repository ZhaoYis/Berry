using System.Collections.Generic;
using Berry.App.Admin.Handler;
using Berry.App.Cache;
using Berry.BLL.SystemManage;
using Berry.Code;
using Berry.Entity.SystemManage;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Berry.Extension;
using Berry.WebControl.Tree;

namespace Berry.App.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public class AreaController : BaseController
    {
        private AreaBLL areaBLL = new AreaBLL();
        private AreaCache areaCache = new AreaCache();

        #region 视图功能

        /// <summary>
        /// 区域管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 区域表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 区域详细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Detail()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <param name="value">当前主键</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string value)
        {
            string parentId = string.IsNullOrEmpty(value) ? "0" : value;
            var filterdata = areaCache.GetList(parentId).ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (filterdata.Count > 0)
            {
                foreach (AreaEntity item in filterdata)
                {
                    bool hasChildren = areaCache.GetList(item.Id).ToList().Count != 0;
                    sb.Append("{");
                    sb.Append("\"id\":\"" + item.Id + "\",");
                    sb.Append("\"text\":\"" + item.AreaName + "\",");
                    sb.Append("\"value\":\"" + item.Id + "\",");
                    sb.Append("\"isexpand\":false,");
                    sb.Append("\"complete\":false,");
                    sb.Append("\"hasChildren\":" + hasChildren.ToString().ToLower() + "");
                    sb.Append("},");
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return Content(sb.ToString());

            //var treeList = new List<TreeEntity>();
            //foreach (AreaEntity item in filterdata)
            //{
            //    TreeEntity tree = new TreeEntity();
            //    //bool hasChildren = areaCache.GetList(item.Id).ToList().Count != 0;
            //    bool hasChildren = filterdata.Count(t => t.ParentId == item.Id) != 0;
            //    tree.id = item.Id;
            //    tree.text = item.AreaName;
            //    tree.value = item.Id;
            //    tree.parentId = item.ParentId;
            //    tree.isexpand = true;
            //    tree.complete = true;
            //    tree.hasChildren = hasChildren;
            //    treeList.Add(tree);
            //}
            ////return Json(treeList, JsonRequestBehavior.AllowGet);
            //return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <param name="value">当前主键</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string value, string keyword)
        {
            string parentId = string.IsNullOrEmpty(value) ? "0" : value;
            var data = areaCache.GetList(parentId, keyword).ToList();
            return Content(data.TryToJson());
        }

        /// <summary>
        /// 区域列表（主要是绑定下拉框）
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetAreaListJson(string parentId)
        {
            var data = areaCache.GetAreaList(string.IsNullOrWhiteSpace(parentId) ? "0" : parentId);
            return Content(data.TryToJson());
        }

        /// <summary>
        /// 区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = areaCache.GetEntity(keyValue);
            return Content(data.TryToJson());
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除区域
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            areaBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 保存区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="areaEntity">区域实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, AreaEntity areaEntity)
        {
            areaBLL.SaveForm(keyValue, areaEntity);
            return Success("操作成功。");
        }

        #endregion 提交数据
    }
}