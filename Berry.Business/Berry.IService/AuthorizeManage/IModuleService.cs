using Berry.Entity.AuthorizeManage;
using System.Collections.Generic;

namespace Berry.IService.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public interface IModuleService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetModuleList(string userId);

        /// <summary>
        /// 获取所有授权功能
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetModuleList();
    }
}