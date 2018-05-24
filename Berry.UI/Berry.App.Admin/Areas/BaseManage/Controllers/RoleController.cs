using Berry.App.Admin.Handler;
using Berry.App.Cache;
using Berry.BLL.BaseManage;
using Berry.Code;
using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.Util;
using System.Web.Mvc;

namespace Berry.App.Admin.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : BaseController
    {
        private RoleBLL roleBLL = new RoleBLL();
        private RoleCache roleCache = new RoleCache();

        #region 视图功能

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 角色表单
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
        /// 角色列表
        /// </summary>
        /// <param name="organizeId">机构Id</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string organizeId)
        {
            var data = roleCache.GetRoleList(organizeId);
            return Content(data.TryToJson());
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(PaginationEntity pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = roleBLL.GetRolePageList(pagination, queryJson);
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
        /// 角色实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = roleBLL.GetRoleEntity(keyValue);
            return Content(data.TryToJson());
        }

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 角色编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistEnCode(string EnCode, string keyValue)
        {
            bool IsOk = roleBLL.ExistEnCode(EnCode, keyValue);
            return Content(IsOk.ToString());
        }

        /// <summary>
        /// 角色名称不能重复
        /// </summary>
        /// <param name="FullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistFullName(string FullName, string keyValue)
        {
            bool IsOk = roleBLL.ExistFullName(FullName, keyValue);
            return Content(IsOk.ToString());
        }

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            roleBLL.RemoveRoleByKey(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 保存角色表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="roleEntity">角色实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, RoleEntity roleEntity)
        {
            roleBLL.SaveRole(keyValue, roleEntity);
            return Success("操作成功。");
        }

        #endregion 提交数据
    }
}