using System;
using System.Web.Mvc;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.Log;

namespace Berry.SOA.API.Attributes
{
    /// <summary>
    /// 自定义全局异常处理
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomHandlerError : HandleErrorAttribute
    {
        private static LogHelper _logHelper = new LogHelper(typeof(CustomHandlerError));

        /// <summary>在发生异常时调用。</summary>
        /// <param name="filterContext">操作筛选器上下文。</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="filterContext" /> 参数为 null。</exception>
        public override void OnException(ExceptionContext filterContext)
        {
            var context = filterContext.HttpContext;
            var exception = filterContext.Exception;

            if (!filterContext.ExceptionHandled)
            {
                LogMessage logMessage = new LogMessage
                {
                    OperationTime = DateTime.Now,
                    Url = context.Request.RawUrl,
                    Ip = context.Request.UserHostAddress,
                    Host = context.Request.UserHostName,
                    Browser = context.Request.Browser.Browser,
                    UserAgent = context.Request.UserAgent,
                    ExceptionInfo = exception.InnerException == null ? exception.Message : exception.InnerException.Message,
                    ExceptionSource = exception.Source,
                    ExceptionRemark = exception.StackTrace
                };
                string strMessage = LogFormat.ExceptionFormat(logMessage);
                _logHelper.Error(strMessage);
                
                filterContext.ExceptionHandled = true;
            }

            filterContext.Result = new ContentResult { Content = new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Error, Message = exception.Message }.TryToJson() };

            //base.OnException(filterContext);
        }
    }
}