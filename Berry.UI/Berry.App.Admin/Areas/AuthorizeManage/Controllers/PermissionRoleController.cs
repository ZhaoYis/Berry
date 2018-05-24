using Berry.App.Admin.Handler;
using Berry.App.Cache;
using Berry.BLL.AuthorizeManage;
using Berry.BLL.BaseManage;
using Berry.Code;
using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.BaseManage;
using Berry.Extension;
using Berry.WebControl.Tree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Berry.App.Admin.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 角色权限
    /// </summary>
    public class PermissionRoleController : BaseController
    {
        private OrganizeBLL organizeBLL = new OrganizeBLL();
        private DepartmentBLL departmentBLL = new DepartmentBLL();
        private DepartmentCache departmentCache = new DepartmentCache();
        private RoleBLL roleBLL = new RoleBLL();
        private UserBLL userBLL = new UserBLL();
        private PermissionBLL permissionBLL = new PermissionBLL();
        //private AuthorizeBLL authorizeBLL = new AuthorizeBLL();
        private ModuleBLL moduleBll = new ModuleBLL();
        private ModuleButtonBLL moduleButtonBll = new ModuleButtonBLL();
        private ModuleColumnBLL moduleColumnBll = new ModuleColumnBLL();

        #region 视图功能

        /// <summary>
        /// 角色权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AllotAuthorize()
        {
            return View();
        }

        /// <summary>
        /// 角色成员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AllotMember()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetDepartmentTreeJson(string roleId)
        {
            var roleEntity = roleBLL.GetRoleEntity(roleId);
            var organizeEntity = organizeBLL.GetOrganizeEntity(roleEntity.OrganizeId);
            var data = departmentCache.GetDepartmentList(roleEntity.OrganizeId).ToList();

            var treeList = new List<TreeEntity>();
            TreeEntity tree = new TreeEntity();
            tree.id = organizeEntity.Id;
            tree.text = organizeEntity.FullName;
            tree.value = organizeEntity.Id;
            tree.isexpand = true;
            tree.complete = true;
            tree.hasChildren = true;
            tree.parentId = "0";
            treeList.Add(tree);
            foreach (DepartmentEntity item in data)
            {
                tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) != 0;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                tree.parentId = item.ParentId == "0" ? roleEntity.OrganizeId : item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserListJson(string roleId)
        {
            var existMember = permissionBLL.GetMemberList(roleId).ToList();
            var userdata = userBLL.GetTable();
            userdata.Columns.Add("ischeck", Type.GetType("System.Int32"));
            userdata.Columns.Add("isdefault", Type.GetType("System.Int32"));
            foreach (DataRow item in userdata.Rows)
            {
                string userId = item["userid"].ToString();
                int ischeck = existMember.Count(t => t.UserId == userId);
                item["ischeck"] = ischeck;
                if (ischeck > 0)
                {
                    item["isdefault"] = existMember.First(t => t.UserId == userId).IsDefault;
                }
                else
                {
                    item["isdefault"] = 0;
                }
            }
            userdata = userdata.DataFilter("", "ischeck desc");
            return Content(userdata.TryToJson());
        }

        /// <summary>
        /// 系统功能列表
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleTreeJson(string roleId)
        {
            var existModule = permissionBLL.GetModuleList(roleId).ToList();
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = moduleBll.GetModuleList(userId).ToList();
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
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleButtonTreeJson(string roleId)
        {
            var existModuleButton = permissionBLL.GetModuleButtonList(roleId).ToList();
            string userId = OperatorProvider.Provider.Current().UserId;
            var moduleData = moduleBll.GetModuleList(userId).ToList();
            var moduleButtonData = moduleButtonBll.GetModuleButtonList(userId).ToList();
            var treeList = new List<TreeEntity>();

            foreach (ModuleEntity item in moduleData)
            {
                if (item.IsMenu == true)
                {
                    bool hasChildren = moduleButtonData.Count(t => t.ModuleId == item.Id) != 0;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
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
                if (item.ParentId == "0")
                {
                    tree.parentId = item.ModuleId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
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
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleColumnTreeJson(string roleId)
        {
            var existModuleColumn = permissionBLL.GetModuleColumnList(roleId).ToList();
            string userId = OperatorProvider.Provider.Current().UserId;
            var moduleData = moduleBll.GetModuleList(userId);
            var moduleColumnData = moduleColumnBll.GetModuleColumnList(userId).ToList();
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
                tree.parentId = item.ParentId == "0" ? item.ModuleId : item.ParentId;
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
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OrganizeTreeJson(string roleId)
        {
            var existAuthorizeData = permissionBLL.GetAuthorizeDataList(roleId).ToList();
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
            var JsonData = new
            {
                authorizeType = authorizeType,
                authorizeData = existAuthorizeData,
                treeJson = treeList.TreeToJson(),
            };
            return Content(JsonData.TryToJson());
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存角色成员
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="userIds">成员Id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveMember(string roleId, string userIds)
        {
            permissionBLL.SaveMember(AuthorizeTypeEnum.Role, roleId, new []{ userIds });
            return Success("保存成功。");
        }

        /// <summary>
        /// 保存角色授权
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataJson">数据权限</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveAuthorize(string roleId, string moduleIds, string moduleButtonIds, string moduleColumnIds, string authorizeDataJson)
        {
            List<AuthorizeDataEntity> authorize = authorizeDataJson.JsonToList<AuthorizeDataEntity>();
            permissionBLL.SaveAuthorize(AuthorizeTypeEnum.Role, roleId, new[] { moduleIds }, new[] { moduleButtonIds }, new[] { moduleColumnIds }, authorize);
            return Success("保存成功。");
        }

        #endregion 提交数据
    }
}