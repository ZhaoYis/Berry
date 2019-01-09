using Berry.BLL.Base;
using Berry.IBLL;

namespace Berry.BLL
{
    /// <summary>
    /// 通用BLL
    /// </summary>
    public class CommonBLL<T> : BaseBLL<T>, ICommonBLL<T> where T : class
    {

    }
}