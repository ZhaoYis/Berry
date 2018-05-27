﻿using System.Web.Mvc;
using Berry.App.Admin.Handler;
using Berry.BLL.SystemManage;
using Berry.Code;
using Berry.Entity.SystemManage;

namespace Berry.App.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 数据库备份
    /// </summary>
    public class DataBaseBackupController : BaseController
    {
        private DataBaseBackupBLL dataBaseBackupBLL = new DataBaseBackupBLL();

        #region 视图功能
        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 数据库备份表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 库备份列表
        /// </summary>
        /// <param name="dataBaseLinkId">连接库Id</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string dataBaseLinkId, string queryJson)
        {
            var data = dataBaseBackupBLL.GetList(dataBaseLinkId, queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 库备份文件路径列表
        /// </summary>
        /// <param name="databaseBackupId">计划Id</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetPathListJson(string databaseBackupId)
        {
            var data = dataBaseBackupBLL.GetPathList(databaseBackupId);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 库备份实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = dataBaseBackupBLL.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除库备份
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            dataBaseBackupBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存库备份表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataBaseBackupEntity">库备份实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, DataBaseBackupEntity dataBaseBackupEntity)
        {
            dataBaseBackupBLL.SaveForm(keyValue, dataBaseBackupEntity);
            return Success("操作成功。");
        }
        #endregion
    }
}
