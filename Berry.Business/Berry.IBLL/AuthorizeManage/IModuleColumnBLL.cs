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
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        List<ModuleColumnEntity> GetList(string moduleId);
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleColumnEntity GetEntity(string keyValue);
        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleColumnEntity> GetModuleColumnList();
    }
}