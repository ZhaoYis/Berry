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
using Berry.SOA.API.ParameterModel;
using Berry.Util;

namespace Berry.SOA.API.Controllers.Base
{
    /// <summary>
    /// 基控Api制器
    /// </summary>
    //[RequireHttps]
    [TimingActionFilter]
    public abstract class BaseApiController : ApiController, ILogger
    {
        #region 系统日志
        /// <summary>
        /// 系统日志 主动调用
        /// </summary>
        protected readonly LogHelper LogHelper = new LogHelper(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 利用Action委托封装Log4net对日志的处理
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc">方法名称</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        [IngoreAction]
        public void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null)
        {
            LogHelper.Logger(type, desc, tryHandel, catchHandel, finallHandel);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取公共返回消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">数据</param>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected BaseJsonResult<T> GetBaseJsonResult<T>(T data = default(T), JsonObjectStatus status = JsonObjectStatus.Error, string message = "") where T : class
        {
            BaseJsonResult<T> resultMsg = new BaseJsonResult<T>
            {
                Status = (int)status,
                Message = $"{status.GetEnumDescription()}{message}",
                Data = data
            };
            return resultMsg;
        }

        /// <summary>
        /// 获取公共返回消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected BaseJsonResult<T> GetBaseJsonResult<T>(JsonObjectStatus status = JsonObjectStatus.Error, string message = "") where T : class
        {
            BaseJsonResult<T> resultMsg = new BaseJsonResult<T>
            {
                Status = (int)status,
                Message = $"{status.GetEnumDescription()}{message}",
            };
            return resultMsg;
        }

        /// <summary>
        /// 校验接口基类参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected bool CheckBaseArgument<T>(BaseParameterEntity parameter, out BaseJsonResult<T> result)
        {
            if (string.IsNullOrEmpty(parameter.t))
            {
                result = new BaseJsonResult<T> { Status = (int)JsonObjectStatus.Fail, Message = "时间戳不能为空。" };
                return false;
            }
            else
            {
                if (!parameter.t.CheckTimeStamp())
                {
                    result = new BaseJsonResult<T> { Status = (int)JsonObjectStatus.Fail, Message = "时间戳有误。" };
                    return false;
                }
                else
                {
                    result = new BaseJsonResult<T> { Status = (int)JsonObjectStatus.Success };
                    return true;
                }
            }
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
