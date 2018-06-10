using System.Net.Http;
using System.Web.Http;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.SOA.API.Controllers.Base;
using Berry.SOA.API.ParameterModel;

namespace Berry.SOA.API.Controllers.V1
{
    /// <summary>
    /// API测试控制器，版本：V1.0
    /// </summary>
    public class TestController : BaseApiController
    {
        /// <summary>
        /// 测试是否连接成功
        /// </summary>
        /// <param name="arg">测试参数</param>
        /// <returns>请求成功则返回成功状态信息</returns>
        [HttpPost]
        public virtual HttpResponseMessage HelloWorld(TestApiArgEntity arg)
        {
            BaseJsonResult<string> resultMsg = new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Error, Message = "服务器未知错误。", Data = null };

            Logger(typeof(TestController), "测试是否连接成功-HelloWorld", () =>
            {
                 if (!string.IsNullOrEmpty(arg.t))
                 {
                    //TODO DoSomething

                    resultMsg = new BaseJsonResult<string>
                     {
                         Status = (int)JsonObjectStatus.Success,
                         Data = "传入参数为：" + arg.TryToJson(),
                         Message = JsonObjectStatus.Success.GetEnumDescription() + "，当前版本：V1",
                         BackUrl = null
                     };
                 }
                 else
                 {
                     resultMsg = new BaseJsonResult<string>
                     {
                         Status = (int)JsonObjectStatus.Fail,
                         Data = null,
                         Message = JsonObjectStatus.Fail.GetEnumDescription() + "，请求参数有误。",
                         BackUrl = null
                     };
                 }
             }, e =>
             {
                 resultMsg = new BaseJsonResult<string>
                 {
                     Status = (int)JsonObjectStatus.Exception,
                     Data = null,
                     Message = JsonObjectStatus.Exception.GetEnumDescription() + "，异常信息：" + e.Message,
                     BackUrl = null
                 };
             });

            return resultMsg.TryToJson().ToHttpResponseMessage();
        }

        [HttpGet]
        public string GetIndex()
        {
            return "这是v1版本的Index";
        }
    }
}
