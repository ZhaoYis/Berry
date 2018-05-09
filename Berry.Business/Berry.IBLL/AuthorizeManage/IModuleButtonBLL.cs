using Berry.Entity.AuthorizeManage;
using System.Collections.Generic;

namespace Berry.IBLL.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public partial interface IModuleButtonBLL
    {
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId);
    }
}