using Berry.App.Admin.Handler;
using Berry.BLL.SystemManage;
using Berry.Code;
using Berry.Entity.SystemManage;
using Berry.WebControl;
using Berry.WebControl.GridTree;
using Berry.WebControl.Tree;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Berry.Extension;

namespace Berry.App.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 数据字典分类
    /// </summary>
    public class DataItemController : BaseController
    {
        private DataItemBLL dataItemBLL = new DataItemBLL();

        #region 视图功能

        /// <summary>
        /// 分类管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分类表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string keyword)
        {
            var data = dataItemBLL.GetDataItemList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.ItemName.Contains(keyword), "");
            }
            var treeList = new List<TreeEntity>();
            foreach (DataItemEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) != 0;
                tree.id = item.Id;
                tree.text = item.ItemName;
                tree.value = item.ItemCode;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.Attribute = "isTree";
                tree.AttributeValue = item.IsTree.ToString();
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            //return Json(treeList, JsonRequestBehavior.AllowGet);
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetTreeListJson(string keyword)
        {
            var data = dataItemBLL.GetDataItemList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.ItemName.Contains(keyword), "");
            }
            var treeList = new List<TreeGridEntity>();
            foreach (DataItemEntity item in data)
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
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = dataItemBLL.GetEntityByKey(keyValue);
            return Content(data.TryToJson());
        }

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="ItemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistItemCode(string ItemCode, string keyValue)
        {
            bool IsOk = dataItemBLL.ExistItemCode(ItemCode, keyValue);
            return Content(IsOk.ToString());
        }

        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="ItemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistItemName(string ItemName, string keyValue)
        {
            bool IsOk = dataItemBLL.ExistItemName(ItemName, keyValue);
            return Content(IsOk.ToString());
        }

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            dataItemBLL.RemoveDataItemByKey(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, DataItemEntity dataItemEntity)
        {
            dataItemBLL.SaveDataItem(keyValue, dataItemEntity);
            return Success("操作成功。");
        }

        #endregion 提交数据
    }
}