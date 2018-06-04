using System;
using System.Reflection;
using System.Web.Http;
using Berry.Code;
using Berry.Log;
using Berry.SOA.API.Filters;

namespace Berry.SOA.API.Controllers.Base
{
    /// <summary>
    /// 基控Api制器
    /// </summary>
    //[RequireHttps]
    //[RequestAuthorize]
    [TimingActionFilter]
    public abstract class BaseApiController : ApiController, ILogger
    {
        #region 系统日志
        /// <summary>
        /// 系统日志 主动调用
        /// </summary>
        protected readonly LogHelper _logHelper = new LogHelper(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 利用Action委托封装Log4net对日志的处理
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc">方法名称</param>
        /// <param name="errorHandel">异常处理方式</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        public void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null, ErrorHandel errorHandel = ErrorHandel.Throw)
        {
            LogHelper.Logger(type, desc, errorHandel, tryHandel, catchHandel, finallHandel);
        }
        #endregion
    }
}
