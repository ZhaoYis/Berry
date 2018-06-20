using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.Log;
using Berry.SOA.API.Attributes;
using Berry.SOA.API.Filters;

namespace Berry.SOA.API.Controllers.Base
{
    /// <summary>
    /// 基控Api制器
    /// </summary>
    //[RequireHttps]
    //[RequestAuthorize]
    [TimingActionFilter]
    public abstract class BaseApiController : ApiController, ILogger
    {
        #region 系统日志
        /// <summary>
        /// 系统日志 主动调用
        /// </summary>
        protected readonly LogHelper _logHelper = new LogHelper(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 利用Action委托封装Log4net对日志的处理
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc">方法名称</param>
        /// <param name="errorHandel">异常处理方式</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        [IngoreAction]
        public void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null, ErrorHandel errorHandel = ErrorHandel.Throw)
        {
            LogHelper.Logger(type, desc, errorHandel, tryHandel, catchHandel, finallHandel);
        }
        #endregion

        #region 调用微信接口返回的数据进行预处理
        /// <summary>
        /// 调用微信接口返回的数据进行预处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        protected BaseJsonResult<T> PreprocessingWeChatData<T>(string json) where T : class, new()
        {
            BaseJsonResult<T> res = new BaseJsonResult<T> { Status = (int)JsonObjectStatus.Fail, Data = null, Message = "未知错误" };
            if (string.IsNullOrEmpty(json)) return res;

            if (json.Contains("errcode") || json.Contains("errmsg"))
            {
                BaseJsonResult4WeChatErr weChatErr = json.JsonToEntity<BaseJsonResult4WeChatErr>();
                if (weChatErr != null)
                {
                    res = new BaseJsonResult<T>
                    {
                        Status = (int)JsonObjectStatus.Fail,
                        Data = null,
                        Message = JsonObjectStatus.Fail.GetEnumDescription() + ".微信接口返回错误码[详情请参考：https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1433747234]为：" + weChatErr.errcode + "，错误消息为：" + weChatErr.errmsg
                    };
                }
            }
            else
            {
                T t = json.JsonToEntity<T>();
                if (t != null)
                {
                    res = new BaseJsonResult<T>
                    {
                        Status = (int)JsonObjectStatus.Success,
                        Data = t,
                        Message = JsonObjectStatus.Success.GetEnumDescription()
                    };
                }
            }
            return res;
        }
        #endregion
    }
}
