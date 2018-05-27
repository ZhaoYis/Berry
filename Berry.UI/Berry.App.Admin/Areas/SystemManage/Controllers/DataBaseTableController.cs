using Berry.App.Admin.Handler;
using Berry.BLL.SystemManage;
using Berry.Code;
using Berry.Util;
using Berry.WebControl.Tree;
using Lottomat.Application.Entity.SystemManage;
using System.Collections.Generic;
using System.Web.Mvc;
using Berry.Entity.CommonEntity;

namespace Berry.App.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 据库表管理
    /// </summary>
    public class DataBaseTableController : BaseController
    {
        private DataBaseTableBLL dataBaseTableBLL = new DataBaseTableBLL();
        //private DataBaseLinkBLL databaseLinkBLL = new DataBaseLinkBLL();

        #region 视图功能

        /// <summary>
        /// 数据库管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 数据表表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 打开表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult TableData()
        {
            return View();
        }

        /// <summary>
        /// 数据表字段表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FieldForm()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 数据库表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableListJson(string dataBaseLinkId, string keyword)
        {
            var data = dataBaseTableBLL.GetTableList(dataBaseLinkId, keyword);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 数据库表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <param name="nameId">字段Id</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTableFiledTreeJson(string dataBaseLinkId, string tableName, string nameId)
        {
            List<string> nameArray = new List<string>();
            if (!string.IsNullOrEmpty(nameId))
            {
                nameArray = new List<string>(nameId.Split(','));
            }

            var data = dataBaseTableBLL.GetTableFiledList(dataBaseLinkId, tableName);
            var treeList = new List<TreeEntity>();
            TreeEntity tree = new TreeEntity();
            tree.id = tableName;
            tree.text = tableName;
            tree.value = tableName;
            tree.parentId = "0";
            tree.img = "fa fa-list-alt";
            tree.isexpand = true;
            tree.complete = true;
            tree.hasChildren = true;
            treeList.Add(tree);
            foreach (DataBaseTableFieldEntity item in data)
            {
                tree = new TreeEntity();
                tree.id = item.column;
                tree.text = item.remark + "（" + item.column + "）";
                tree.value = item.remark;
                tree.parentId = tableName;
                tree.img = "fa fa-wrench";
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = nameArray.Contains(item.column) == true ? 1 : 0;
                tree.hasChildren = false;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 数据库表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableFiledListJson(string dataBaseLinkId, string tableName)
        {
            var data = dataBaseTableBLL.GetTableFiledList(dataBaseLinkId, tableName);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableDataListJson(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, PaginationEntity pagination)
        {
            var watch = CommonHelper.TimerStart();
            var data = dataBaseTableBLL.GetTableDataList(dataBaseLinkId, tableName, switchWhere, logic, keyword, pagination);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDescription">表说明</param>
        /// <param name="fieldListJson">字段列表Json</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string dataBaseLinkId, string tableName, string tableDescription, string fieldListJson)
        {
            dataBaseTableBLL.SaveForm(dataBaseLinkId, tableName, tableDescription, fieldListJson);
            return Success("操作成功。");
        }

        #endregion 提交数据
    }
}