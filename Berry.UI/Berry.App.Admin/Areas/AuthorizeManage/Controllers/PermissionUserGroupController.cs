using Berry.App.Admin.Handler;
using Berry.App.Cache;
using Berry.BLL.AuthorizeManage;
using Berry.BLL.BaseManage;
using Berry.Code;
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
    /// 用户组权限
    /// </summary>
    public class PermissionUserGroupController : BaseController
    {
        private OrganizeBLL organizeBLL = new OrganizeBLL();
        private DepartmentBLL departmentBLL = new DepartmentBLL();
        private DepartmentCache departmentCache = new DepartmentCache();
        private RoleBLL roleBLL = new RoleBLL();
        private UserBLL userBLL = new UserBLL();
        private ModuleBLL moduleBLL = new ModuleBLL();
        private ModuleButtonBLL moduleButtonBLL = new ModuleButtonBLL();
        private ModuleColumnBLL moduleColumnBLL = new ModuleColumnBLL();
        private PermissionBLL permissionBLL = new PermissionBLL();

        #region 视图功能

        /// <summary>
        /// 用户组权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AllotAuthorize()
        {
            return View();
        }

        /// <summary>
        /// 用户组成员
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
        /// <param name="userGroupId">用户组Id</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetDepartmentTreeJson(string userGroupId)
        {
            var roleEntity = roleBLL.GetRoleEntity(userGroupId);
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
        /// <param name="userGroupId">用户组Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserListJson(string userGroupId)
        {
            var existMember = permissionBLL.GetMemberList(userGroupId).ToList();
            var userdata = userBLL.GetTable();
            userdata.Columns.Add("ischeck", Type.GetType("System.Int32"));//自定义添加一列 判断是否勾选
            foreach (DataRow item in userdata.Rows)
            {
                string userId = item["userid"].ToString();
                item["ischeck"] = existMember.Count(t => t.UserId == userId);
            }
            userdata = userdata.DataFilter("", "ischeck desc");
            return Content(userdata.TryToJson());
        }

        /// <summary>
        /// 系统功能列表
        /// </summary>
        /// <param name="userGroupId">用户组Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleTreeJson(string userGroupId)
        {
            var existModule = permissionBLL.GetModuleList(userGroupId);
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
        /// <param name="userGroupId">用户组Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleButtonTreeJson(string userGroupId)
        {
            var existModuleButton = permissionBLL.GetModuleButtonList(userGroupId).ToList();
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
        /// <param name="userGroupId">用户组Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleColumnTreeJson(string userGroupId)
        {
            var existModuleColumn = permissionBLL.GetModuleColumnList(userGroupId).ToList();
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
        /// <param name="userGroupId">用户组Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OrganizeTreeJson(string userGroupId)
        {
            var existAuthorizeData = permissionBLL.GetAuthorizeDataList(userGroupId).ToList();
            var organizedata = organizeBLL.GetOrganizeList().ToList();
            var departmentdata = departmentCache.GetList().ToList();
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
        /// 保存用户组成员
        /// </summary>
        /// <param name="userGroupId">用户组Id</param>
        /// <param name="userIds">成员Id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveMember(string userGroupId, string userIds)
        {
            permissionBLL.SaveMember(AuthorizeTypeEnum.UserGroup, userGroupId, new []{ userIds });
            return Success("保存成功。");
        }

        /// <summary>
        /// 保存用户组授权
        /// </summary>
        /// <param name="userGroupId">用户组Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataJson">数据权限</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveAuthorize(string userGroupId, string moduleIds, string moduleButtonIds, string moduleColumnIds, string authorizeDataJson)
        {
            List<AuthorizeDataEntity> authorize = authorizeDataJson.JsonToList<AuthorizeDataEntity>();
            permissionBLL.SaveAuthorize(AuthorizeTypeEnum.UserGroup, userGroupId, new[] { moduleIds }, new[] { moduleButtonIds }, new[] { moduleColumnIds }, authorize);
            return Success("保存成功。");
        }

        #endregion 提交数据
    }
}