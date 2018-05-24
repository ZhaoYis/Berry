using Berry.Code;
using Berry.Code.Operator;
using Berry.Entity;
using Berry.Entity.SystemManage;
using Berry.Extension;
using Berry.Log;
using Berry.Util;
using System;
using System.Web;
using System.Web.Mvc;

namespace Berry.App.Admin.Handler
{
    /// <summary>
    /// 错误日志（Controller发生异常时会执行这里）
    /// </summary>
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 控制器方法中出现异常，会调用该方法捕获异常
        /// </summary>
        /// <param name="context">提供使用</param>
        public override void OnException(ExceptionContext context)
        {
            WriteLog(context);
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new ContentResult { Content = new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Error, Message = context.Exception.Message }.TryToJson() };
        }

        /// <summary>
        /// 写入日志（log4net）
        /// </summary>
        /// <param name="context">提供使用</param>
        private void WriteLog(ExceptionContext context)
        {
            if (context == null) return;
            if (OperatorProvider.Provider.IsOverdue()) return;

            //var log = LogFactory.GetLogger(context.Controller.ToString());
            LogHelper logHelper = new LogHelper(context.Controller.ToString());

            Exception error = context.Exception;
            LogMessage logMessage = new LogMessage
            {
                OperationTime = DateTimeHelper.Now,
                Url = HttpContext.Current.Request.RawUrl,
                Class = context.Controller.ToString(),
                Ip = NetHelper.Ip,
                Host = NetHelper.Host,
                Browser = NetHelper.Browser,
                UserName = OperatorProvider.Provider.Current().Account + "（" + OperatorProvider.Provider.Current().UserName + "）"
            };
            logMessage.ExceptionInfo = error.InnerException == null ? error.Message : error.InnerException.Message;
            //logMessage.ExceptionSource = Error.Source;
            //logMessage.ExceptionRemark = Error.StackTrace;
            string strMessage = LogFormat.ExceptionFormat(logMessage);

            logHelper.Error(strMessage);

            //LogEntity logEntity = new LogEntity
            //{
            //    CategoryId = (int)CategoryType.Exception,
            //    OperateTypeId = ((int)OperationType.Exception).ToString(),
            //    OperateType = OperationType.Exception.GetEnumDescription(),
            //    OperateAccount = logMessage.UserName,
            //    OperateUserId = OperatorProvider.Provider.Current().UserId,
            //    ExecuteResult = -1,
            //    ExecuteResultJson = strMessage
            //};
            //logEntity.WriteLog();

            //SendMail(strMessage);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        private void SendMail(string body)
        {
            bool errorToMail = ConfigHelper.GetValue("ErrorToMail").ToBool();
            if (errorToMail == true)
            {
                string systemName = ConfigHelper.GetValue("SoftName");//系统名称
                string address = ConfigHelper.GetValue("ErrorReportTo");
                MailHelper.Send(address, systemName + " - 发生异常", body.Replace("-", ""));
            }
        }
    }
}