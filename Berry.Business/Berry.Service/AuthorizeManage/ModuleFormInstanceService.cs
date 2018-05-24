using Berry.Data.Repository;
using Berry.Entity.AuthorizeManage;
using Berry.Extension;
using Berry.IService.AuthorizeManage;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 系统表单实例
    /// </summary>
    public class ModuleFormInstanceService : RepositoryFactory,IModuleFormInstanceService
    {
        #region 获取数据
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public ModuleFormInstanceEntity GetEntityByObjectId(string objectId)
        {
            return this.BaseRepository().FindEntity<ModuleFormInstanceEntity>(t => t.ObjectId == objectId);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormInstanceEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                return this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                return this.BaseRepository().Update(entity);
            }
        }
        #endregion
    }
}
