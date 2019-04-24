using System;
using Berry.Entity.CustomManage;
using Berry.BLL.CustomManage;
using Berry.Util;
using Berry.WebControl;
using System.Web.Mvc;
using Berry.App.Admin.Handler;
using Berry.Entity.CommonEntity;

namespace Berry.App.Admin.Areas.CustomManage.Controllers
{
    /// <summary>
    /// 版 本：V1.0.0
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2019-01-10 14:55
    /// 描 述：微信配置
    /// </summary>
    public class WechatConfigController : BaseController
    {
        private WechatConfigBLL wechatconfigbll = new WechatConfigBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(PaginationEntity pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = wechatconfigbll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = wechatconfigbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = wechatconfigbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            wechatconfigbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, WechatConfigEntity entity)
        {
            wechatconfigbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }

        /// <summary>
        /// 添加自定义菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult AddCustomMenu(string keyValue, string json)
        {
            Tuple<bool, string> tuple = wechatconfigbll.AddCustomMenu(json, keyValue);
            if (tuple.Item1)
            {
                return Success(tuple.Item2);
            }
            else
            {
                return Error(tuple.Item2);
            }
        }
        #endregion
    }
}
