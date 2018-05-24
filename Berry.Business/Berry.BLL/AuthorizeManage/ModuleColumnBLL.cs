using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;
using System.Collections.Generic;
using System.Linq;

namespace Berry.BLL.AuthorizeManage
{
    /// <summary>
    /// 授权视图数据
    /// </summary>
    public partial class ModuleColumnBLL : IModuleColumnBLL
    {
        private IModuleColumnService moduleColumnService = new ModuleColumnService();

        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return moduleColumnService.GetModuleColumnList();
            }
            else
            {
                return moduleColumnService.GetModuleColumnList(userId);
            }
        }
        
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<ModuleColumnEntity> GetList(string moduleId)
        {
            return moduleColumnService.GetList(moduleId).ToList();
        }
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleColumnEntity GetEntity(string keyValue)
        {
            return moduleColumnService.GetEntity(keyValue);
        }

        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList()
        {
            return moduleColumnService.GetModuleColumnList();
        }
        
        /// <summary>
        /// 复制视图 
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="moduleId">功能主键</param>
        /// <returns></returns>
        public void CopyForm(string keyValue, string moduleId)
        {
            ModuleColumnEntity moduleColumnEntity = this.GetEntity(keyValue);
            moduleColumnEntity.ModuleId = moduleId;
            moduleColumnService.AddEntity(moduleColumnEntity);
        }
    }
}