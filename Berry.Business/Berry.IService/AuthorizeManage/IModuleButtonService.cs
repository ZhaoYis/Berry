using Berry.Entity.AuthorizeManage;
using System.Collections.Generic;

namespace Berry.IService.AuthorizeManage
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    public interface IModuleButtonService
    {
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId);

        /// <summary>
        /// 获取所有功能按钮
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetModuleButtonList();
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetList(string moduleId);
        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleButtonEntity GetEntity(string keyValue);

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="moduleButtonEntity">按钮实体</param>
        void AddEntity(ModuleButtonEntity moduleButtonEntity);
    }
}