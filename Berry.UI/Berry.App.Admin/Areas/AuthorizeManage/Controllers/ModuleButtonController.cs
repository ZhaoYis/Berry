using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Berry.App.Admin.Handler;
using Berry.BLL.AuthorizeManage;
using Berry.Code;
using Berry.Entity;
using Berry.Entity.AuthorizeManage;
using Berry.Extension;
using Berry.Util;
using Berry.WebControl.GridTree;
using Berry.WebControl.Tree;

namespace Berry.App.Admin.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    public class ModuleButtonController : BaseController
    {
        private ModuleButtonBLL moduleButtonBLL = new ModuleButtonBLL();

        #region 视图功能
        /// <summary>
        /// 按钮表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 选择系统功能
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OptionModule()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 按钮列表 
        /// </summary>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string moduleId)
        {
            var data = moduleButtonBLL.GetListByModuleId(moduleId);
            return Content(data.TryToJson());
        }
        /// <summary>
        /// 按钮列表 
        /// </summary>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetTreeListJson(string moduleId)
        {
            var data = moduleButtonBLL.GetListByModuleId(moduleId);
            if (data != null)
            {
                var treeList = new List<TreeGridEntity>();
                foreach (ModuleButtonEntity item in data)
                {
                    bool hasChildren = data.Count(t => t.ParentId == item.Id) != 0;
                    TreeGridEntity tree = new TreeGridEntity
                    {
                        id = item.Id,
                        parentId = item.ParentId,
                        expanded = true,
                        hasChildren = hasChildren,
                        entityJson = item.TryToJson()
                    };
                    treeList.Add(tree);
                }
                return Content(treeList.TreeJson());
            }
            return null;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 按钮列表Json转换按钮树形Json 
        /// </summary>
        /// <param name="moduleButtonJson">按钮列表</param>
        /// <returns>返回树形Json</returns>
        [HttpPost]
        public ActionResult ListToTreeJson(string moduleButtonJson)
        {
            var data = moduleButtonJson.JsonToList<ModuleButtonEntity>().OrderBy(b => b.SortCode).ToList();

            var treeList = new List<TreeEntity>();
            foreach (ModuleButtonEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) != 0;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.ModuleId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 按钮列表Json转换按钮树形Json 
        /// </summary>
        /// <param name="moduleButtonJson">按钮列表</param>
        /// <returns>返回树形列表Json</returns>
        [HttpPost]
        public ActionResult ListToListTreeJson(string moduleButtonJson)
        {
            var data = moduleButtonJson.JsonToList<ModuleButtonEntity>().OrderBy(b => b.SortCode).ToList();
            var treeList = new List<TreeGridEntity>();
            foreach (ModuleButtonEntity item in data)
            {
                TreeGridEntity tree = new TreeGridEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) != 0;
                tree.id = item.Id;
                tree.parentId = item.ParentId;
                tree.expanded = true;
                tree.hasChildren = hasChildren;
                tree.entityJson = item.TryToJson();
                treeList.Add(tree);
            }
            return Content(treeList.TreeJson());
        }
        /// <summary>
        /// 复制按钮
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="moduleId">功能主键</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CopyForm(string keyValue, string moduleId)
        {
            moduleButtonBLL.CopyForm(keyValue, moduleId);
            return Content(new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Success, Message = "复制成功。" }.TryToJson());
        }
        #endregion
    }
}
