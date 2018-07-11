using System.Net.Http;
using Berry.SOA.API.ParameterModel;

namespace Berry.SOA.API.Controllers.Interface
{
    /// <summary>
    /// 微信登陆
    /// </summary>
    public interface IWeChatLogin
    {
        /// <summary>
        /// 微信登陆
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        HttpResponseMessage Login(WeChatLoginArgEntity arg);
    }
}