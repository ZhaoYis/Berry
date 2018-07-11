using System.Net.Http;
using System.Web.Http;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.SOA.API.Controllers.Base;
using Berry.SOA.API.ParameterModel;
using Berry.Util.JWT;

namespace Berry.SOA.API.Controllers
{
    /// <summary>
    /// API测试控制器
    /// </summary>
    public class TestController : BaseApiController
    {
        /// <summary>
        /// 测试是否连接成功
        /// </summary>
        /// <param name="arg">测试参数</param>
        /// <returns>请求成功则返回成功状态信息</returns>
        [HttpPost]
        [IgnoreToken(false)]
        public virtual HttpResponseMessage HelloWorld(TestApiArgEntity arg)
        {
            BaseJsonResult<string> resultMsg = this.GetBaseJsonResult<string>();

            Logger(this.GetType(), "测试是否连接成功-HelloWorld", () =>
            {
                if (!string.IsNullOrEmpty(arg.t))
                {
                    //TODO DoSomething

                    resultMsg = this.GetBaseJsonResult<string>(arg.TryToJson(), JsonObjectStatus.Success);
                }
                else
                {
                    resultMsg = this.GetBaseJsonResult<string>(arg.TryToJson(), JsonObjectStatus.Fail, "，请求参数有误。");
                }
            }, e =>
            {
                resultMsg = this.GetBaseJsonResult<string>("", JsonObjectStatus.Exception, "，异常信息：" + e.Message);
            });

            return resultMsg.ToHttpResponseMessage();
        }

    }
}
