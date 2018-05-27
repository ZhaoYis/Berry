using Berry.App.Admin.Handler;
using Berry.BLL.SystemManage;
using Berry.Code;
using Berry.Entity.SystemManage;
using Berry.WebControl.Tree;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Berry.Util;

namespace Berry.App.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 数据库连接管理
    /// </summary>
    public class DataBaseLinkController : BaseController
    {
        private DataBaseLinkBLL databaseLinkBLL = new DataBaseLinkBLL();

        #region 视图功能

        /// <summary>
        /// 库连接管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 库连接表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string keyword)
        {
            var data = databaseLinkBLL.GetList().ToList();

            var dataIp = data.Distinct(new ComparintTools<DataBaseLinkEntity>("ServerAddress"));
            var treeList = new List<TreeEntity>();
            foreach (DataBaseLinkEntity item in dataIp)
            {
                TreeEntity tree = new TreeEntity();
                tree.id = item.ServerAddress;
                tree.text = item.ServerAddress;
                tree.value = item.ServerAddress;
                tree.parentId = "0";
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                treeList.Add(tree);
            }
            foreach (DataBaseLinkEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                tree.id = item.Id;
                tree.text = item.DBAlias;
                tree.value = item.Id;
                tree.title = item.DBName;
                tree.parentId = item.ServerAddress;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = false;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string keyword)
        {
            var data = databaseLinkBLL.GetList();
            //测试环境防止用户获得连接串
            //foreach (var item in data)
            //{
            //    item.ServerAddress = "******";
            //    item.DbConnection = "******";
            //}
            return ToJsonResult(data);
        }

        /// <summary>
        /// 库连接实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = databaseLinkBLL.GetEntity(keyValue);
            //测试环境防止用户获得连接串
            //data.ServerAddress = "******";
            //data.DbConnection = "******";
            return ToJsonResult(data);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            databaseLinkBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity)
        {
            //测试环境防止用户修改连接串
            if (!string.IsNullOrEmpty(keyValue))
            {
                return Success("测试环境，修改数据库连接无效。");
            }
            databaseLinkBLL.SaveForm(keyValue, databaseLinkEntity);
            return Success("操作成功。");
        }

        #endregion 提交数据
    }
}