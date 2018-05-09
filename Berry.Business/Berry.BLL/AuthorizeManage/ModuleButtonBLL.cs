using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;
using System.Collections.Generic;

namespace Berry.BLL.AuthorizeManage
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    public partial class ModuleButtonBLL : IModuleButtonBLL
    {
        private IModuleButtonService moduleButtonService = new ModuleButtonService();

        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId)
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
    }
}