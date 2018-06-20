using System;
using System.Net.Http;
using System.Text;

namespace Berry.Extension
{
    public static class HttpRequestMessageExtension
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";

        [Obsolete("See IsLocal at HttpRequestMessageExtensions Version 5.0.0.0")]
        public static bool IsLocal(this HttpRequestMessage request)
        {
            Lazy<bool> localFlag = request.Properties["MS_IsLocal"] as Lazy<bool>;
            return localFlag != null && localFlag.Value;
        }
        
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            //Web-hosting
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    string res = ctx.Request.UserHostAddress;
                    res = res.Equals("::1") ? "127.0.0.1" : res;

                    return res;
                }
            }
            //Self-hosting
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    string res = remoteEndpoint.Address;
                    res = res.Equals("::1") ? "127.0.0.1" : res;

                    return res;
                }
            }
            //Owin-hosting
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic ctx = request.Properties[OwinContext];
                if (ctx != null)
                {
                    string res = ctx.Request.RemoteIpAddress;
                    res = res.Equals("::1") ? "127.0.0.1" : res;

                    return res;
                }
            }
            return "localhost";
        }

        /// <summary>
        /// Http返回消息
        /// </summary>
        /// <param name="obj">对象或者Json字符串</param>
        /// <returns></returns>
        public static HttpResponseMessage ToHttpResponseMessage(this object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                str = obj.TryToJson();
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json")
            };
            return result;
        }
    }
}