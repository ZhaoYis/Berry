using Berry.Entity.AuthorizeManage;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;

namespace Berry.BLL.AuthorizeManage
{
    /// <summary>
    /// 系统表单实例
    /// </summary>
    public class ModuleFormInstanceBLL : IModuleFormInstanceBLL
    {
        private IModuleFormInstanceService server = new ModuleFormInstanceService();

        #region 获取数据
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public ModuleFormInstanceEntity GetEntityByObjectId(string objectId)
        {
            if (!string.IsNullOrEmpty(objectId))
            {
                return server.GetEntityByObjectId(objectId);
            }
            else
            {
                return null;
            }
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
            return server.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}
