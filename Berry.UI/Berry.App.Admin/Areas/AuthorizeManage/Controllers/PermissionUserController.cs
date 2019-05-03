using Berry.App.Admin.Handler;
using Berry.BLL.AuthorizeManage;
using Berry.BLL.BaseManage;
using Berry.Code;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.BaseManage;
using Berry.Extension;
using Berry.WebControl.Tree;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Berry.App.Admin.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 用户权限
    /// </summary>
    public class PermissionUserController : BaseController
    {
        private OrganizeBLL organizeBLL = new OrganizeBLL();
        private DepartmentBLL departmentBLL = new DepartmentBLL();
        //private RoleBLL roleBLL = new RoleBLL();
        //private UserBLL userBLL = new UserBLL();
        private ModuleBLL moduleBLL = new ModuleBLL();
        private ModuleButtonBLL moduleButtonBLL = new ModuleButtonBLL();
        private ModuleColumnBLL moduleColumnBLL = new ModuleColumnBLL();
        private PermissionBLL permissionBLL = new PermissionBLL();

        #region 视图功能

        /// <summary>
        /// 用户权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AllotAuthorize()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 系统功能列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleTreeJson(string userId)
        {
            var existModule = permissionBLL.GetModuleList(userId);
            var data = moduleBLL.GetList();
            var treeList = new List<TreeEntity>();

            foreach (ModuleEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) != 0;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                tree.title = "";
                tree.checkstate = existModule.Count(t => t.ItemId == item.Id);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                tree.img = item.Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 系统按钮列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleButtonTreeJson(string userId)
        {
            var existModuleButton = permissionBLL.GetModuleButtonList(userId).ToList();
            var moduleData = moduleBLL.GetList();
            var moduleButtonData = moduleButtonBLL.GetList();
            var treeList = new List<TreeEntity>();
            foreach (ModuleEntity item in moduleData)
            {
                TreeEntity tree = new TreeEntity();
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                tree.checkstate = existModuleButton.Count(t => t.ItemId == item.Id);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                tree.parentId = item.ParentId;
                tree.img = item.Icon;
                treeList.Add(tree);
            }

            foreach (ModuleButtonEntity item in moduleButtonData)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = moduleButtonData.Count(t => t.ParentId == item.Id) != 0;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                tree.parentId = item.ParentId == "0" ? item.ModuleId : item.ParentId;
                tree.checkstate = existModuleButton.Count(t => t.ItemId == item.Id);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.img = "fa fa-wrench " + item.ModuleId;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 系统视图列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleColumnTreeJson(string userId)
        {
            var existModuleColumn = permissionBLL.GetModuleColumnList(userId).ToList();
            var moduleData = moduleBLL.GetList();
            var moduleColumnData = moduleColumnBLL.GetModuleColumnList().ToList();
            var treeList = new List<TreeEntity>();

            foreach (ModuleEntity item in moduleData)
            {
                TreeEntity tree = new TreeEntity();
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                tree.checkstate = existModuleColumn.Count(t => t.ItemId == item.Id);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                tree.parentId = item.ParentId;
                tree.img = item.Icon;
                treeList.Add(tree);
            }
            foreach (ModuleColumnEntity item in moduleColumnData)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = moduleColumnData.Count(t => t.ParentId == item.Id) != 0;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                if (item.ParentId == "0")
                {
                    tree.parentId = item.ModuleId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
                tree.checkstate = existModuleColumn.Count(t => t.ItemId == item.Id);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.img = "fa fa-filter " + item.ModuleId;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 数据权限列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OrganizeTreeJson(string userId)
        {
            var existAuthorizeData = permissionBLL.GetAuthorizeDataList(userId).ToList();
            var organizedata = organizeBLL.GetOrganizeList().ToList();
            var departmentdata = departmentBLL.GetDepartmentList().ToList();
            var treeList = new List<TreeEntity>();

            foreach (OrganizeEntity item in organizedata)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.Id) != 0;
                if (hasChildren == false)
                {
                    hasChildren = departmentdata.Count(t => t.OrganizeId == item.Id) != 0;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                tree.parentId = item.ParentId;
                tree.img = item.ParentId == "0" ? "fa fa-sitemap" : "fa fa-home";
                tree.checkstate = existAuthorizeData.Count(t => t.ResourceId == item.Id);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            foreach (DepartmentEntity item in departmentdata)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = departmentdata.Count(t => t.ParentId == item.Id) != 0;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                if (item.ParentId == "0")
                {
                    tree.parentId = item.OrganizeId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
                tree.checkstate = existAuthorizeData.Count(t => t.ResourceId == item.Id);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.img = "fa fa-umbrella";
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            int authorizeType = -1;
            if (existAuthorizeData.ToList().Count > 0)
            {
                authorizeType = existAuthorizeData.ToList()[0].AuthorizeType.ToInt();
            }
            var jsonData = new
            {
                authorizeType = authorizeType,
                authorizeData = existAuthorizeData,
                treeJson = treeList.TreeToJson(),
            };
            return Content(jsonData.TryToJson());
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存用户授权
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataJson">数据权限</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveAuthorize(string userId, string moduleIds, string moduleButtonIds, string moduleColumnIds, string authorizeDataJson)
        {
            //List<AuthorizeDataEntity> authorize = authorizeDataJson.JsonToList<AuthorizeDataEntity>();

            permissionBLL.SaveAuthorize(AuthorizeTypeEnum.User, userId, moduleIds, moduleButtonIds, moduleColumnIds, authorizeDataJson);
            return Success("保存成功。");
        }

        #endregion 提交数据
    }
}