using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.Util;

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

                var resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.ParameterError,
                    Message = sb.ToString().Substring(0, sb.ToString().Length - 1),
                };

                actionContext.Response = resultMsg.TryToHttpResponseMessage();
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
                var resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.Exception,
                    Message = actionExecutedContext.Exception.Message,
                };

                actionExecutedContext.Response = resultMsg.TryToHttpResponseMessage();
            }
            else
            {
                if (actionExecutedContext.Response.Content == null)
                {
                    var resultMsg = new BaseJsonResult<string>
                    {
                        Status = (int)JsonObjectStatus.Error,
                        Message = "HTTP响应消息内容为空",
                    };
                    actionExecutedContext.Response = resultMsg.TryToHttpResponseMessage();
                }
                else
                {
                    string result;
                    long resultLength = 0;
                    if (actionExecutedContext.Response.Content is ObjectContent)
                    {
                        result = ((ObjectContent)actionExecutedContext.Response.Content).Value.ToString();
                    }
                    else
                    {
                        byte[] ctx = actionExecutedContext.Response.Content.ReadAsByteArrayAsync().Result;
                        //resultLength = ctx.LongLength;
                        result = Encoding.UTF8.GetString(ctx);
                    }

                    var Headers = actionExecutedContext.ActionContext.Request.Headers;
                    var AcceptEncoding = Headers.AcceptEncoding;
                    if (AcceptEncoding != null && AcceptEncoding.Contains(new StringWithQualityHeaderValue("gzip")))
                    {
                        byte[] body = Encoding.UTF8.GetBytes(result.ToString());
                        byte[] compressedData = GZipHelper.GZipCompress(body);

                        actionExecutedContext.Response.Content = new ByteArrayContent(compressedData);
                        actionExecutedContext.Response.Content.Headers.Remove("Content-Type");
                        actionExecutedContext.Response.Content.Headers.Add("Content-Encoding", "gzip");
                        actionExecutedContext.Response.Content.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    }
                    else if (AcceptEncoding != null && AcceptEncoding.Contains(new StringWithQualityHeaderValue("deflate")))
                    {
                        byte[] body = Encoding.UTF8.GetBytes(result.ToString());
                        byte[] compressedData = GZipHelper.DeflateCompress(body);

                        actionExecutedContext.Response.Content = new ByteArrayContent(compressedData);
                        actionExecutedContext.Response.Content.Headers.Remove("Content-Type");
                        actionExecutedContext.Response.Content.Headers.Add("Content-Encoding", "deflate");
                        actionExecutedContext.Response.Content.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    }
                    else
                    {
                        actionExecutedContext.Response = result.TryToHttpResponseMessage();
                    }

                    //if (resultLength > 1024)
                    //{

                    //}
                    //else
                    //{
                    //    actionExecutedContext.Response.Content = new StringContent(result.TryToJson(), Encoding.UTF8, "application/json");
                    //}
                }
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}