using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Berry.Cache;
using Berry.Code;
using Berry.Entity;
using Berry.Entity.ViewModel;
using Berry.Extension;
using Berry.Util;

namespace Berry.SOA.API.Filters
{
    /// <summary>
    /// 验证
    /// </summary>
    public class ApiSecurityFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 正在请求时
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string isInterfaceSignature = ConfigHelper.GetValue("IsInterfaceSignature");
            if (isInterfaceSignature == "false")
            {
                base.OnActionExecuting(actionContext);
                return;
            }

            BaseJsonResult<string> resultMsg = null;
            //操作上下文请求信息
            HttpRequestMessage request = actionContext.Request;
            //请求方法
            //string method = request.Method.Method;
            string appkey = string.Empty, timestamp = string.Empty, nonce = string.Empty, access_token = string.Empty;

            //string authority = request.RequestUri.Authority;
            //string host = request.RequestUri.Host;
            //string port = request.RequestUri.Port.ToString();
            //if (request.IsLocal())
            //{
            //}

            //参数列表
            //Dictionary<string, object> dictionary = actionContext.ActionArguments;
            //if (dictionary.ContainsKey("arg"))
            //{

            //}

            //用户编号
            if (request.Headers.Contains("AppKey"))
            {
                appkey = HttpUtility.UrlDecode(request.Headers.GetValues("AppKey").FirstOrDefault());
            }
            //时间戳
            if (request.Headers.Contains("TimeStamp"))
            {
                timestamp = HttpUtility.UrlDecode(request.Headers.GetValues("TimeStamp").FirstOrDefault());
            }
            //随机数
            if (request.Headers.Contains("Nonce"))
            {
                nonce = HttpUtility.UrlDecode(request.Headers.GetValues("Nonce").FirstOrDefault());
            }
            //数字签名数据
            if (request.Headers.Contains("Authorization"))
            {
                access_token = HttpUtility.UrlDecode(request.Headers.GetValues("Authorization").FirstOrDefault());
            }

            //接受客户端预请求
            if (actionContext.Request.Method == HttpMethod.Options)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Accepted);
                base.OnActionExecuting(actionContext);
                return;
            }

            //GetToken和Login方法不需要进行签名验证
            string[] exceptRequest = GlobalConstCode.NOT_NEED_DIGITAL_SIGNATURE;
            if (exceptRequest.Contains(actionContext.ActionDescriptor.ActionName))
            {
                if (string.IsNullOrEmpty(appkey) || string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(nonce))
                {
                    resultMsg = new BaseJsonResult<string>
                    {
                        Status = (int)JsonObjectStatus.ParameterError,
                        Message = JsonObjectStatus.ParameterError.GetEnumDescription(),
                        Data = ""
                    };
                    actionContext.Response = resultMsg.TryToJson().ToHttpResponseMessage();
                    base.OnActionExecuting(actionContext);
                    return;
                }
                else
                {
                    base.OnActionExecuting(actionContext);
                    return;
                }

                //base.OnActionExecuting(actionContext);
                //return;
            }

            //判断请求头是否包含以下参数
            if (string.IsNullOrEmpty(appkey) || string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(nonce) || string.IsNullOrEmpty(access_token))
            //if (string.IsNullOrEmpty(access_token) || string.IsNullOrEmpty(appkey))
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.ParameterError,
                    Message = JsonObjectStatus.ParameterError.GetEnumDescription(),
                    Data = ""
                };
                actionContext.Response = resultMsg.TryToJson().ToHttpResponseMessage();
                base.OnActionExecuting(actionContext);
                return;
            }

            //判断当前时间戳是否有效
            long now = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            //客户端传入得时间戳
            long qeruest = 0;
            bool timespanvalidate = long.TryParse(timestamp, out qeruest);
            //当前时间必与请求时间差应在1分钟以内才算有效时间戳，防止伪造时间戳
            bool falg = (now - qeruest) < 1 * 60;
            //如果时间差大于1分钟或者时间戳转换失败则视为无效时间戳
            if (!falg || !timespanvalidate)
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.UrlExpireError,
                    Message = JsonObjectStatus.UrlExpireError.GetEnumDescription(),
                    Data = ""
                };
                actionContext.Response = resultMsg.TryToJson().ToHttpResponseMessage();
                base.OnActionExecuting(actionContext);
                return;
            }

            //判断token是否有效
            TokenViewModel token = CacheFactory.GetCacheInstance().GetCache<TokenViewModel>(appkey);
            string serveraccesstoken = "AccessToken ";
            if (token == null)
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.TokenInvalid,
                    Message = JsonObjectStatus.TokenInvalid.GetEnumDescription(),
                    Data = ""
                };
                actionContext.Response = resultMsg.TryToJson().ToHttpResponseMessage();
                base.OnActionExecuting(actionContext);
                return;
            }
            else
            {
                serveraccesstoken += token.AccessToken;
            }

            #region 请求参数签名，GET请求即参数不带?、&、=符号，如id1nametest;POST请求将数据序列化成Json字符串
            //请求参数签名，GET请求即参数不带?、&、=符号，如id1nametest;POST请求将数据序列化成Json字符串
            //string data;
            //switch (method)//根据请求类型拼接参数
            //{
            //    case "POST":
            //        Stream stream = HttpContext.Current.Request.InputStream;
            //        StreamReader streamReader = new StreamReader(stream);
            //        data = streamReader.ReadToEnd();
            //        break;
            //    case "GET":
            //        NameValueCollection form = HttpContext.Current.Request.QueryString;
            //        //第一步：取出所有get参数
            //        IDictionary<string, string> parameters = new Dictionary<string, string>();
            //        for (int f = 0; f < form.Count; f++)
            //        {
            //            string key = form.Keys[f];
            //            parameters.Add(key, form[key]);
            //        }

            //        // 第二步：把字典按Key的字母顺序排序
            //        IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            //        // ReSharper disable once GenericEnumeratorNotDisposed
            //        IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            //        // 第三步：把所有参数名和参数值串在一起
            //        StringBuilder query = new StringBuilder();
            //        while (dem.MoveNext())
            //        {
            //            string key = dem.Current.Key;
            //            string value = dem.Current.Value;
            //            if (!string.IsNullOrEmpty(key))
            //            {
            //                query.Append(key).Append(value);
            //            }
            //        }
            //        data = query.ToString();
            //        break;
            //    default:
            //        resultMsg = new BaseJson<string>
            //        {
            //            Status = (int)JsonObjectStatus.HttpMehtodError,
            //            Message = JsonObjectStatus.HttpMehtodError.GetEnumDescription(),
            //            Data = ""
            //        };
            //        actionContext.Response = resultMsg.ToJson().ToHttpResponseMessage();
            //        base.OnActionExecuting(actionContext);
            //        return;
            //}

            #endregion

            //校验签名信息
            bool result = SignExtension.ValidateSign(appkey, nonce, timestamp, serveraccesstoken, access_token);
            if (!result)
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.HttpRequestError,
                    Message = JsonObjectStatus.HttpRequestError.GetEnumDescription(),
                    Data = ""
                };
                actionContext.Response = resultMsg.TryToJson().ToHttpResponseMessage();
                base.OnActionExecuting(actionContext);
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }

        /// <summary>
        /// 请求完成时
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

    }
}