using System.Net.Http;
using Berry.SOA.API.ParameterModel;

namespace Berry.SOA.API.Controllers.Interface
{
    /// <summary>
    /// 公共接口
    /// </summary>
    public interface ICommon
    {
        /// <summary>
        /// 获取授权Token
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        HttpResponseMessage GetAuthorizationToken(GetTokenArgEntity arg);

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        HttpResponseMessage RefreshAuthorizationToken(GetTokenArgEntity arg);
    }
}