using System;
using Berry.Code;

namespace Berry.Log
{
    /// <summary>
    /// 通用基类日志处理
    /// </summary>
    public class BaseLogger : ILogger
    {
        /// <summary>
        /// 日志处理，无返回值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc">方法名称</param>
        /// <param name="errorHandel">异常处理方式</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        public virtual void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null)
        {
            LogHelper.Logger(type, desc, tryHandel, catchHandel, finallHandel);
        }

        ///// <summary>
        ///// 日志处理，有返回值
        ///// </summary>
        ///// <typeparam name="TR"></typeparam>
        ///// <param name="type"></param>
        ///// <param name="desc"></param>
        ///// <param name="tryHandel"></param>
        ///// <param name="catchHandel"></param>
        ///// <param name="finallHandel"></param>
        ///// <param name="errorHandel"></param>
        //public virtual TR Logger<TR>(Type type, string desc, Func<TR> tryHandel, Func<Exception, TR> catchHandel = null, Action finallHandel = null,
        //    ErrorHandel errorHandel = ErrorHandel.Throw)
        //{
        //    return LogHelper.Logger(type, desc, errorHandel, tryHandel, catchHandel, finallHandel);
        //}
    }
}