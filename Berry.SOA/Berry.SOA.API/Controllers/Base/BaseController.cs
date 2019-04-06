using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.Log;
using System;
using System.Web.Mvc;

namespace Berry.SOA.API.Controllers.Base
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public abstract class BaseController : Controller, ILogger
    {
        #region 系统日志
        ///// <summary>
        ///// 系统日志 主动调用
        ///// </summary>
        //private readonly LogHelper _logHelper = new LogHelper(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 系统日志 对try块进行了封装
        /// </summary>
        /// <param name="type"></param>
        /// <param name="function">方法名称</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        public void Logger(Type type, string function, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null)
        {
            LogHelper.Logger(type, function, tryHandel, catchHandel, finallHandel);
        }
        #endregion

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult ToJsonResult(object data)
        {
            return Content(data.TryToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            return Content(new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Success, Message = message }.TryToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <param name="backUrl">跳转地址</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, object data, string backUrl)
        {
            return Content(new BaseJsonResult<object> { Status = (int)JsonObjectStatus.Success, Message = message, Data = data, BackUrl = backUrl }.TryToJson());
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            return Content(new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Fail, Message = message }.TryToJson());
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message, object data)
        {
            return Content(new BaseJsonResult<object> { Status = (int)JsonObjectStatus.Fail, Message = message, Data = data }.TryToJson());
        }
    }
}
