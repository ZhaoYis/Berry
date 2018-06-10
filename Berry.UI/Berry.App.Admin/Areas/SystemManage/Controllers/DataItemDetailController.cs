using Berry.App.Admin.Handler;
using Berry.App.Cache;
using Berry.BLL.SystemManage;
using Berry.Code;
using Berry.Entity.SystemManage;
using Berry.Entity.ViewModel;
using Berry.Extension;
using Berry.WebControl;
using Berry.WebControl.GridTree;
using Berry.WebControl.Tree;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Berry.Util;

namespace Berry.App.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 数据字典明细
    /// </summary>
    public class DataItemDetailController : BaseController
    {
        private DataItemDetailBLL dataItemDetailBLL = new DataItemDetailBLL();
        private DataItemCache dataItemCache = new DataItemCache();

        #region 视图功能

        /// <summary>
        /// 明细管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 明细表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 明细详细
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
        /// 明细列表
        /// </summary>
        /// <param name="itemId">分类Id</param>
        /// <param name="condition">条件</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetTreeListJson(string itemId, string condition, string keyword)
        {
            var data = dataItemDetailBLL.GetDataItemDetailList(itemId).ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                #region 多条件查询

                switch (condition)
                {
                    case "ItemName":        //项目名
                        data = data.TreeWhere(t => t.ItemName.Contains(keyword), "ItemDetailId");
                        break;

                    case "ItemValue":      //项目值
                        data = data.TreeWhere(t => t.ItemValue.Contains(keyword), "ItemDetailId");
                        break;

                    case "SimpleSpelling": //拼音
                        data = data.TreeWhere(t => t.SimpleSpelling.Contains(keyword), "ItemDetailId");
                        break;

                    default:
                        break;
                }

                #endregion 多条件查询
            }
            var treeList = new List<TreeGridEntity>();
            foreach (DataItemDetailEntity item in data)
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
        /// 明细实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = dataItemDetailBLL.GetDataItemDetailEntity(keyValue);
            return Content(data.TryToJson());
        }

        /// <summary>
        /// 获取数据字典列表（绑定控件）
        /// </summary>
        /// <param name="EnCode">代码</param>
        /// <returns>返回列表树Json</returns>
        [HttpGet]
        public ActionResult GetDataItemTreeJson(string EnCode)
        {
            var data = dataItemCache.GetDataItemList(EnCode);
            var treeList = new List<TreeEntity>();
            foreach (DataItemViewModel item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.ItemDetailId) != 0;
                tree.id = item.ItemDetailId;
                tree.text = item.ItemName;
                tree.value = item.ItemValue;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 获取数据字典列表（绑定控件）
        /// </summary>
        /// <param name="EnCode">代码</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetDataItemListJson(string EnCode)
        {
            var data = dataItemCache.GetDataItemList(EnCode);
            return Content(data.TryToJson());
        }

        /// <summary>
        /// 获取数据字典子列表（绑定控件）
        /// </summary>
        /// <param name="EnCode">代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns>返回列表Json</returns>
        public ActionResult GetSubDataItemListJson(string EnCode, string ItemValue)
        {
            var data = dataItemCache.GetSubDataItemList(EnCode, ItemValue);
            return Content(data.TryToJson());
        }

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 项目值不能重复
        /// </summary>
        /// <param name="ItemValue">项目值</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistItemValue(string ItemValue, string keyValue, string itemId)
        {
            bool IsOk = dataItemDetailBLL.ExistItemValue(ItemValue, keyValue, itemId);
            return Content(IsOk.ToString());
        }

        /// <summary>
        /// 项目名不能重复
        /// </summary>
        /// <param name="ItemName">项目名</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistItemName(string ItemName, string keyValue, string itemId)
        {
            bool IsOk = dataItemDetailBLL.ExistItemName(ItemName, keyValue, itemId);
            return Content(IsOk.ToString());
        }

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            dataItemDetailBLL.RemoveDataItemDetailByKey(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 保存明细表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemDetailEntity">明细实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, DataItemDetailEntity dataItemDetailEntity)
        {
            dataItemDetailEntity.SimpleSpelling = PinYinHelper.GetPinYinSimple(dataItemDetailEntity.ItemName);
            dataItemDetailBLL.SaveDataItemDetail(keyValue, dataItemDetailEntity);
            return Success("操作成功。");
        }

        #endregion 提交数据
    }
}