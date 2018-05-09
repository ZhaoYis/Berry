using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;
using System.Collections.Generic;

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
    }
}