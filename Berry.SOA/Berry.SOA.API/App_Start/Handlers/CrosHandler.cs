using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.SOA.API.Handlers
{
    /// <summary>
    /// 解决自定义请求头下的跨域问题
    /// <example>调用方式：在Global.asax文件的Application_Start方法添加GlobalConfiguration.Configuration.MessageHandlers.Add(new CrosHandler());</example>
    /// </summary>
    public class CrosHandler : DelegatingHandler
    {
        private const string Origin = "Origin";
        private const string AccessControlRequestMethod = "Access-Control-Request-Method";
        private const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        private const string AccessControlAllowOrign = "Access-Control-Allow-Origin";
        private const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        private const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
        private const string AccessControlAllowCredentials = "Access-Control-Allow-Credentials";
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isCrosRequest = request.Headers.Contains(Origin);
            //是否预请求
            bool isPrefilightRequest = request.Method == HttpMethod.Options;
            if (isCrosRequest)
            {
                Task<HttpResponseMessage> taskResult = null;
                if (isPrefilightRequest)
                {
                    taskResult = Task.Factory.StartNew<HttpResponseMessage>(() =>
                    {
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Accepted);
                        response.Headers.Add(AccessControlAllowOrign, request.Headers.GetValues(Origin).FirstOrDefault());

                        string method = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                        if (!string.IsNullOrEmpty(method))
                        {
                            response.Headers.Add(AccessControlAllowMethods, method);
                        }

                        string headers = string.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders));
                        if (!string.IsNullOrEmpty(headers))
                        {
                            response.Headers.Add(AccessControlAllowHeaders, headers);
                        }

                        response.Headers.Add(AccessControlAllowCredentials, "true");
                        return response;
                    }, cancellationToken);
                }
                else
                {
                    taskResult = base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(t =>
                    {
                        var response = t.Result;
                        response.Headers.Add(AccessControlAllowOrign, request.Headers.GetValues(Origin).FirstOrDefault());
                        response.Headers.Add(AccessControlAllowCredentials, "true");
                        return response;
                    }, cancellationToken);
                }
                return taskResult;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}