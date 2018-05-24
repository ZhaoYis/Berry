using System.Data;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.CommonEntity;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;

namespace Berry.BLL.AuthorizeManage
{
    /// <summary>
    /// 系统表单
    /// </summary>
    public class ModuleFormBLL : IModuleFormBLL
    {
        private IModuleFormService server = new ModuleFormService();

        #region 获取数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetPageList(PaginationEntity pagination, string queryJson)
        {
            return server.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ModuleFormEntity GetEntity(string keyValue)
        {
            return server.GetEntity(keyValue);
        }
        /// <summary>
        /// 通过模块Id获取系统表单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public ModuleFormEntity GetEntityByModuleId(string moduleId)
        {
            return server.GetEntityByModuleId(moduleId);
        }
        /// <summary>
        /// 判断模块是否已经有系统表单
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public bool IsExistModuleId(string keyValue, string moduleId)
        {
            return server.IsExistModuleId(keyValue, moduleId);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormEntity entity)
        {
            return server.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 虚拟删除一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int VirtualDelete(string keyValue)
        {
            return server.VirtualDelete(keyValue);
        }
        #endregion
    }
}
