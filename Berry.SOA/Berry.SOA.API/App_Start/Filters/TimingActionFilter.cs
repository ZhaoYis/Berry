using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Berry.SOA.API.Filters
{
    /// <summary>
    /// 接口执行时间监控
    /// </summary>
    public class TimingActionFilter : ActionFilterAttribute
    {
        private const string Key = "__action_duration__";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (SkipLogging(actionContext))
            {
                return;
            }
            Stopwatch stopWatch = new Stopwatch();
            actionContext.Request.Properties[Key] = stopWatch;
            stopWatch.Start();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (!actionExecutedContext.Request.Properties.ContainsKey(Key))
            {
                return;
            }

            Stopwatch stopWatch = actionExecutedContext.Request.Properties[Key] as Stopwatch;
            if (stopWatch != null)
            {
                stopWatch.Stop();
                string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                string controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                controllerName = controllerName.Replace("Controller", "");
                string url = "/api/" + controllerName + "/" + actionName + "";
                
                Trace.WriteLine(string.Format("调用了地址为{0}的API接口，耗时{1}毫秒", url, stopWatch.Elapsed.TotalMilliseconds));
            }
        }

        /// <summary>
        /// 是否跳过
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        private static bool SkipLogging(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<NoLogAttribute>().Any() ||
                   actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<NoLogAttribute>().Any();
        }
    }

    /// <summary>
    /// 不记录调用时间特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class NoLogAttribute : System.Attribute
    {
        
    }
}