
using Berry.Entity.AuthorizeManage;

namespace Berry.IService.AuthorizeManage
{
    /// <summary>
    /// 系统表单实例
    /// </summary>
    public interface IModuleFormInstanceService
    {
        #region 获取数据
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        ModuleFormInstanceEntity GetEntityByObjectId(string objectId);
        #endregion

        #region 提交数据
         /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        int SaveEntity(string keyValue, ModuleFormInstanceEntity entity);
        #endregion
    }
}
