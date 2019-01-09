using Berry.IService;
using Berry.Service.Base;

namespace Berry.Service
{
    /// <summary>
    /// 通用服务
    /// </summary>
    public class CommonService<T> : BaseService<T>, ICommonService<T> where T : class
    {

    }
}