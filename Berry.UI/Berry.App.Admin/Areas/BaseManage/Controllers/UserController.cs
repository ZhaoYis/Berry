using Berry.App.Admin.Handler;
using Berry.App.Cache;
using Berry.BLL.AuthorizeManage;
using Berry.BLL.BaseManage;
using Berry.Code;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.Util;
using Berry.WebControl;
using Berry.WebControl.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Berry.App.Admin.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : BaseController
    {
        private UserBLL userBLL = new UserBLL();
        private UserCache userCache = new UserCache();
        //private OrganizeBLL organizeBLL = new OrganizeBLL();
        private OrganizeCache organizeCache = new OrganizeCache();
        //private DepartmentBLL departmentBLL = new DepartmentBLL();
        private DepartmentCache departmentCache = new DepartmentCache();
        private ModuleFormInstanceBLL moduleFormInstanceBll = new ModuleFormInstanceBLL();

        #region 视图功能

        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 用户表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RevisePassword()
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+部门+用户树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string keyword)
        {
            var organizedata = organizeCache.GetOrganizList().ToList();
            var departmentdata = departmentCache.GetList().ToList();
            var userdata = userCache.GetList();
            var treeList = new List<TreeEntity>();

            foreach (OrganizeEntity item in organizedata)
            {
                #region 机构

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
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Organize";
                treeList.Add(tree);

                #endregion 机构
            }
            foreach (DepartmentEntity item in departmentdata)
            {
                #region 部门

                TreeEntity tree = new TreeEntity();
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Id;
                tree.parentId = item.ParentId == "0" ? item.OrganizeId : item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Department";
                treeList.Add(tree);

                #endregion 部门
            }
            foreach (UserEntity item in userdata)
            {
                #region 用户

                TreeEntity tree = new TreeEntity();
                tree.id = item.Id;
                tree.text = item.RealName;
                tree.value = item.Account;
                tree.parentId = item.DepartmentId;
                tree.title = item.RealName + "（" + item.Account + "）";
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = false;
                tree.Attribute = "Sort";
                tree.AttributeValue = "User";
                tree.img = "fa fa-user";
                treeList.Add(tree);

                #endregion 用户
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                treeList = treeList.TreeWhere(t => t.text.Contains(keyword), "id", "parentId");
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <returns>返回用户列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string departmentId)
        {
            var data = userCache.GetUserList(departmentId);
            return Content(data.TryToJson());
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(PaginationEntity pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = userBLL.GetPageList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.TryToJson());
        }

        /// <summary>
        /// 用户实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = userBLL.QueryUserByUserId(keyValue);
            return Content(data.TryToJson());
        }

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="Account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistAccount(string Account, string keyValue)
        {
            bool IsOk = userBLL.ExistAccount(Account, keyValue);
            return Content(IsOk.ToString());
        }

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            if (keyValue == "System")
            {
                throw new Exception("当前账户不能删除");
            }
            userBLL.RemoveUserByKey(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="strUserEntity">用户实体</param>
        /// <param name="formInstanceId"></param>
        /// <param name="strModuleFormInstanceEntity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strUserEntity, string formInstanceId, string strModuleFormInstanceEntity)
        {
            UserEntity userEntity = strUserEntity.JsonToEntity<UserEntity>();
            ModuleFormInstanceEntity moduleFormInstanceEntity = strModuleFormInstanceEntity.JsonToEntity<ModuleFormInstanceEntity>();

            string objectId;
            bool isSucc = userBLL.AddUser(keyValue, userEntity, out objectId);
            moduleFormInstanceEntity.ObjectId = objectId;
            moduleFormInstanceBll.SaveEntity(formInstanceId, moduleFormInstanceEntity);

            return Success("操作成功。");
        }

        /// <summary>
        /// 保存重置修改密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveRevisePassword(string keyValue, string password)
        {
            if (keyValue == "System")
            {
                throw new Exception("当前账户不能重置密码");
            }
            string key = CommonHelper.GetGuid();
            string md5 = Md5Helper.Md5(password);
            string realPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(md5, key));

            userBLL.RevisePassword(keyValue, realPassword, key);
            return Success("密码修改成功，请牢记新密码。");
        }

        /// <summary>
        /// 禁用账户
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DisabledAccount(string keyValue)
        {
            if (keyValue == "System")
            {
                throw new Exception("当前账户不禁用");
            }
            userBLL.UpdateUserState(keyValue, 0);
            return Success("账户禁用成功。");
        }

        /// <summary>
        /// 启用账户
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EnabledAccount(string keyValue)
        {
            userBLL.UpdateUserState(keyValue, 1);
            return Success("账户启用成功。");
        }

        #endregion 提交数据

        #region 数据导出

        /// <summary>
        /// 导出用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportUserList()
        {
            userBLL.GetExportList();
            return Success("导出成功。");
        }

        #endregion 数据导出
    }
}