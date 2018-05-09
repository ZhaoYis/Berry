using Berry.Entity.AuthorizeManage;
using System.Collections.Generic;

namespace Berry.IBLL.AuthorizeManage
{
    /// <summary>
    /// 系统视图
    /// </summary>
    public partial interface IModuleColumnBLL
    {
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId);
    }
}