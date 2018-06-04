using System.Linq;
using System.Web.Http;

namespace Berry.SOA.API.Attributes
{
    /// <summary>
    /// 自定义此特性用于接口的身份验证
    /// </summary>
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;

            if (authorization != null && authorization.Parameter != null)
            {
                //获取授权信息
                var encryptTicket = authorization.Parameter;
                if (this.ValidateAppKey(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    base.HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous)
                    base.OnAuthorization(actionContext);
                else
                    base.HandleUnauthorizedRequest(actionContext);
            }
        }

        /// <summary>
        /// 校验授权信息
        /// </summary>
        /// <param name="encryptTicket"></param>
        /// <returns></returns>
        private bool ValidateAppKey(string encryptTicket)
        {
            return true;
        }
    }
}