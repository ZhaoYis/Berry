using System;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;

namespace Berry.SOA.API.Filters
{
    /// <summary>
    /// 控制器拦截器
    /// </summary>
    public class ActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 输入拦截器
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var m in actionContext.ModelState)
                {
                    string[] key = m.Key.Split(".".ToCharArray());
                    string err = key.Length == 2 ? key[1] + "^" : "";

                    ModelErrorCollection errors = m.Value.Errors;
                    foreach (ModelError error in errors)
                    {
                        err += error.ErrorMessage + ",";
                    }
                    err = err.Substring(0, err.Length - 1) + "|";
                    sb.Append(err);
                }

                HttpResponseMessage response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
                response.StatusCode = actionContext.Response.StatusCode;
                response.Content = new StringContent(
                    new BaseJsonResult<string>
                    {
                        Status = (int)JsonObjectStatus.Fail,
                        Data = null,
                        Message = sb.ToString().Substring(0, sb.ToString().Length - 1),
                        BackUrl = null
                    }.TryToJson(), Encoding.UTF8, "application/json");
            }
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 输出拦截器
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                actionExecutedContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                actionExecutedContext.Response.Content = new StringContent(
                         new BaseJsonResult<string>
                         {
                             Status = (int)JsonObjectStatus.Exception,
                             Data = null,
                             Message = actionExecutedContext.Exception.Message,
                             BackUrl = null
                         }.TryToJson(), Encoding.UTF8, "application/json");
            }
            else
            {
                if (actionExecutedContext.Response.Content == null)
                {
                    //actionExecutedContext.Response.Content = new StringContent(
                    // JsonConvert.SerializeObject(new ResultPacket()
                    // {
                    //     IsError = false,
                    //     ResponseData = null
                    // }));
                }
                else
                {
                    object result;
                    if (actionExecutedContext.Response.Content is ObjectContent)
                        result = (actionExecutedContext.Response.Content as ObjectContent).Value;
                    else
                        result = System.Text.Encoding.UTF8.GetString(actionExecutedContext.Response.Content.ReadAsByteArrayAsync().Result);

                    actionExecutedContext.Response.Content = new StringContent(result.TryToJson(), Encoding.UTF8, "application/json");
                }
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}