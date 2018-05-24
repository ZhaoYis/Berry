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
    /// 系统按钮
    /// </summary>
    public partial class ModuleButtonBLL : IModuleButtonBLL
    {
        private IModuleButtonService moduleButtonService = new ModuleButtonService();

        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <returns></returns>
        public List<ModuleButtonEntity> GetList()
        {
            return moduleButtonService.GetModuleButtonList().ToList();
        }

        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetListByUserId(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return moduleButtonService.GetModuleButtonList();
            }
            else
            {
                return moduleButtonService.GetModuleButtonList(userId);
            }
        }

        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetListByModuleId(string moduleId)
        {
            return moduleButtonService.GetList(moduleId);
        }

        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleButtonEntity GetEntity(string keyValue)
        {
            return moduleButtonService.GetEntity(keyValue);
        }

        /// <summary>
        /// 复制按钮
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="moduleId">功能主键</param>
        /// <returns></returns>
        public void CopyForm(string keyValue, string moduleId)
        {
            ModuleButtonEntity moduleButtonEntity = this.GetEntity(keyValue);
            moduleButtonEntity.ModuleId = moduleId;
            moduleButtonService.AddEntity(moduleButtonEntity);
        }
    }
}