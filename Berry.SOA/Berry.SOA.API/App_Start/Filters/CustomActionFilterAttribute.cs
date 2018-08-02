using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.Log;
using Berry.Util;
using Berry.Util.JWT;

namespace Berry.SOA.API.Filters
{
    /// <summary>
    /// 接口授权验证
    /// </summary>
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        #region 初始化
        /// <summary>
        /// 日志
        /// </summary>
        private readonly LogHelper _logHelper = new LogHelper(typeof(CustomActionFilterAttribute));

        /// <summary>
        /// 私钥
        /// </summary>
        private static string PrivateKey;
        /// <summary>
        /// 公钥
        /// </summary>
        private static string PublicKey;
        static CustomActionFilterAttribute()
        {
            string path = DirFileHelper.MapPath("SecretKey\\api.privateKey.key");
            PrivateKey = DirFileHelper.ReadAllText(path);

            path = DirFileHelper.MapPath("SecretKey\\api.publicKey.key");
            PublicKey = DirFileHelper.ReadAllText(path);
        }
        #endregion

        /// <summary>在调用操作方法之前发生。</summary>
        /// <param name="actionContext">操作上下文。</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string isInterfaceSignature = ConfigHelper.GetValue("IsInterfaceSignature");
            if (isInterfaceSignature.ToLower() == "false") return;

            BaseJsonResult<string> resultMsg = null;
            //授权码，指纹，时间戳，8位随机数
            string accessToken = string.Empty, signature = string.Empty, timestamp = string.Empty, nonce = string.Empty;

            //操作上下文请求信息
            HttpRequestMessage request = actionContext.Request;
            //请求方法
            string method = request.Method.Method;

            #region 接受客户端预请求
            //接受客户端预请求
            if (actionContext.Request.Method == HttpMethod.Options)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Accepted);
                return;
            }
            #endregion

            #region 忽略不需要授权的方法
            //忽略不需要授权的方法
            var attributes = actionContext.ActionDescriptor.GetCustomAttributes<IgnoreTokenAttribute>();
            if (attributes.Count == 0 || (attributes.Count > 0 && attributes[0].Ignore)) return;
            #endregion

            _logHelper.Debug("*************************授权开始*************************\r\n");
            _logHelper.Debug("鉴权地址：" + actionContext.Request.RequestUri + "\r\n");

            #region 获取请求头信息
            //授权Token
            if (request.Headers.Contains("Authorization"))
            {
                accessToken = HttpUtility.UrlDecode(request.Headers.GetValues("Authorization").FirstOrDefault());

                _logHelper.Debug("Authorization：" + accessToken + "\r\n");
            }
            ////指纹
            //if (request.Headers.Contains("Signature"))
            //{
            //    signature = HttpUtility.UrlDecode(request.Headers.GetValues("Signature").FirstOrDefault());

            //    _logHelper.Debug("Signature：" + signature + "\r\n");
            //}
            #endregion

            #region 判断请求头是否包含以下参数
            //判断请求头是否包含以下参数
            if (string.IsNullOrEmpty(accessToken))
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.ParameterError,
                    Message = JsonObjectStatus.ParameterError.GetEnumDescription()
                };
                actionContext.Response = resultMsg.TryToHttpResponseMessage();

                _logHelper.Debug("*************************授权结束（请求头参数不完整）*************************\r\n");
                return;
            }
            #endregion

            #region 校验参数是否被篡改
            ////校验参数是否被篡改
            //Dictionary<string, object> actionArguments = null;
            //switch (method)
            //{
            //    case "POST":
            //        actionArguments = actionContext.ActionArguments;
            //        KeyValuePair<string, object> keyValuePair = actionArguments.FirstOrDefault();
            //        actionArguments = keyValuePair.Value.Object2Dictionary();
            //        break;
            //    case "GET":
            //        actionArguments = actionContext.ActionArguments;
            //        break;
            //}

            //bool isSucc = this.CheckSignature(signature, actionArguments);
            //if (!isSucc)
            //{
            //    resultMsg = new BaseJsonResult<string>
            //    {
            //        Status = (int)JsonObjectStatus.ParameterManipulation,
            //        Message = JsonObjectStatus.ParameterManipulation.GetEnumDescription()
            //    };
            //    actionContext.Response = resultMsg.TryToHttpResponseMessage();

            //    _logHelper.Debug("*************************授权结束（请求参数被篡改或指纹有误）*************************\r\n");

            //    return;
            //}
            #endregion

            #region 校验Token是否有效
            //校验Token是否有效
            JWTPlayloadInfo playload = JWTHelper.CheckToken(accessToken);
            if (playload == null)
            {
                _logHelper.Debug("校验Token是否有效：TOKEN失效\r\n");

                resultMsg = new BaseJsonResult<string>
                {
                    Status = (int)JsonObjectStatus.TokenInvalid,
                    Message = JsonObjectStatus.TokenInvalid.GetEnumDescription()
                };
                actionContext.Response = resultMsg.TryToHttpResponseMessage();

                _logHelper.Debug("*************************授权结束（TOKEN失效）*************************\r\n");

                return;
            }
            else
            {
                //TODO 等系统开放了登陆，取消此段代码注释
                //校验当前用户是否能够操作某些特定方法（比如更新用户信息）
                //if (!attributes[0].Ignore)
                //{
                //    if (!string.IsNullOrEmpty(playload.aud) && playload.aud.Equals("guest"))
                //    {
                //        resultMsg = new BaseJsonResult<string>
                //        {
                //            Status = (int)JsonObjectStatus.Unauthorized,
                //            Message = JsonObjectStatus.Unauthorized.GetEnumDescription()
                //        };
                //        actionContext.Response = resultMsg.TryToHttpResponseMessage();
                //        return;
                //    }
                //}
            }
            #endregion

            _logHelper.Debug("*************************授权结束*************************\r\n");

            //base.OnActionExecuting(actionContext);
        }

        #region 指纹校验
        /// <summary>
        /// 指纹校验
        /// </summary>
        /// <param name="signature">客户端传回的指纹</param>
        /// <param name="actionArguments">请求参数</param>
        /// <returns></returns>
        private bool CheckSignature(string signature, Dictionary<string, object> actionArguments)
        {
            //if (string.IsNullOrEmpty(signature)) return false;
            if (actionArguments != null)
            {
                _logHelper.Debug("开始Signature校验，参数个数：" + actionArguments.Count + "。\r\n");

                //1-获取参数字符串，并按参数名升序排序，最后统一转成小写，形如：a1b2c3
                string argString = this.GetArgumentString(actionArguments);
                _logHelper.Debug("1-获取参数字符串，并按参数名升序排序，最后统一转成小写：" + argString + "\r\n");

                //2-取参数字符串的md5
                string sign = Md5Helper.Md5(argString);
                _logHelper.Debug("2-取参数字符串的md5：" + sign + "\r\n");

                //3-【客户端】使用公钥加密参数字符串的md5后传回服务器
                string signEncrypt = RSAEncryptHelper.EncryptString(sign, PublicKey);
                _logHelper.Debug("3-使用公钥加密参数字符串的md5（服务器计算的值）：" + signEncrypt + "\r\n");

                //4-使用私钥解密客户端传回的指纹
                signature = this.GetSignature(signature);
                _logHelper.Debug("4-使用私钥解密客户端传回的指纹：" + signature + "\r\n");

                _logHelper.Debug("5-校验指纹信息：" + (sign == signature).ToString() + "\r\n");
                return sign == signature;
            }
            return false;
        }

        /// <summary>
        /// 获取参数字符串，并按参数名升序排序，形如：a1b2c3
        /// </summary>
        /// <param name="actionArguments"></param>
        /// <returns></returns>
        private string GetArgumentString(Dictionary<string, object> actionArguments)
        {
            StringBuilder builder = new StringBuilder();

            actionArguments = actionArguments.OrderBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);

            foreach (KeyValuePair<string, object> pair in actionArguments)
            {
                string key = pair.Key;
                string value = pair.Value == null ? "" : pair.Value.ToString();
                builder.Append(string.Format("{0}{1}", key, value));
            }

            return builder.ToString().ToLower();
        }

        /// <summary>
        /// 计算指纹
        /// </summary>
        /// <param name="signature">客户端传回的指纹</param>
        /// <returns></returns>
        private string GetSignature(string signature)
        {
#if DEBUG
            var keys = RSAEncryptHelper.GetRSAKey();
            string publicKey = keys.PublicKey;
            string privateKey = keys.PrivateKey;
            Trace.WriteLine("publicKey：" + publicKey);
            Trace.WriteLine("privateKey：" + privateKey);
#endif

            //解密私钥客户端传回的指纹
            string argSignString = RSAEncryptHelper.DecryptString(signature, PrivateKey);
            _logHelper.Debug("*使用私钥解密客户端传回的指纹*：" + argSignString + "\r\n");

            //取解密后字符串的md5
            //string md5 = Md5Helper.Md5(argSignString);

            return argSignString;
        }

        #endregion
    }
}