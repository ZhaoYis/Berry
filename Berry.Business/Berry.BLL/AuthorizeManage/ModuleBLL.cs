using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;
using System.Collections.Generic;

namespace Berry.BLL.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public partial class ModuleBLL : IModuleBLL
    {
        private readonly IModuleService _moduleService = new ModuleService();

        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return _moduleService.GetModuleList();
            }
            else
            {
                return _moduleService.GetModuleList(userId);
            }
        }
    }
}