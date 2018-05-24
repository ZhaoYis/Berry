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
        /// 获取所有授权功能按钮
        /// </summary>
        /// <returns></returns>
        List<ModuleButtonEntity> GetList();

        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetListByUserId(string userId);
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetListByModuleId(string moduleId);
        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleButtonEntity GetEntity(string keyValue);
    }
}