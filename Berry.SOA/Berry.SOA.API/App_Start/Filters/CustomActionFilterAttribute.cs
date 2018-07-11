using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.Util;
using Berry.Util.JWT;

namespace Berry.SOA.API.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>在调用操作方法之前发生。</summary>
        /// <param name="actionContext">操作上下文。</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string isInterfaceSignature = ConfigHelper.GetValue("IsInterfaceSignature");
            if (isInterfaceSignature.ToLower() == "false") return;

            BaseJsonResult<string> resultMsg = null;
            //授权码
            string accessToken = string.Empty;
            //操作上下文请求信息
            HttpRequestMessage request = actionContext.Request;
            //数字签名数据
            if (request.Headers.Contains("Authorization"))
            {
                accessToken = HttpUtility.UrlDecode(request.Headers.GetValues("Authorization").FirstOrDefault());
            }

            //接受客户端预请求
            if (actionContext.Request.Method == HttpMethod.Options)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Accepted);
                return;
            }

            //忽略不需要授权的方法
            var attributes = actionContext.ActionDescriptor.GetCustomAttributes<IgnoreTokenAttribute>();
            if (attributes.Count > 0 && attributes[0].Ignore) return;

            //判断请求头是否包含以下参数
            if (string.IsNullOrEmpty(accessToken))
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.ParameterError,
                    Message = JsonObjectStatus.ParameterError.GetEnumDescription()
                };
                actionContext.Response = resultMsg.ToHttpResponseMessage();
                return;
            }

            //校验Token是否有效
            JWTPlayloadInfo playload = JWTHelper.CheckToken(accessToken);
            if (playload == null)
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.TokenInvalid,
                    Message = JsonObjectStatus.TokenInvalid.GetEnumDescription()
                };
                actionContext.Response = resultMsg.ToHttpResponseMessage();
                return;
            }
            else
            {
                //校验当前用户是否能够操作某些特定方法（比如更新用户信息）
                if (!attributes[0].Ignore)
                {
                    if (!string.IsNullOrEmpty(playload.aud) && playload.aud.Equals("guest"))
                    {
                        resultMsg = new BaseJsonResult<string>
                        {
                            Status = (int)JsonObjectStatus.Unauthorized,
                            Message = JsonObjectStatus.Unauthorized.GetEnumDescription()
                        };
                        actionContext.Response = resultMsg.ToHttpResponseMessage();
                        return;
                    }
                }
            }

            base.OnActionExecuting(actionContext);
        }
    }
}