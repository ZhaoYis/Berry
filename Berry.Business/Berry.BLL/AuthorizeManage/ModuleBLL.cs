using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;
using System.Collections.Generic;
using System.Linq;
using Berry.Extension;

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

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetSortCode()
        {
            return _moduleService.GetSortCode();
        }

        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="parentId">父级主键</param>
        /// <returns></returns>
        public List<ModuleEntity> GetList(string parentId = "")
        {
            var data = _moduleService.GetList("").ToList();
            if (!string.IsNullOrEmpty(parentId))
            {
                data = data.FindAll(t => t.ParentId == parentId);
            }
            return data;
        }

        /// <summary>
        /// 获取功能实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleEntity GetEntity(string keyValue)
        {
            return _moduleService.GetEntity(keyValue);
        }

        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _moduleService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            return _moduleService.ExistFullName(fullName, keyValue);
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            //判断是否存在子级
            List<ModuleEntity> moduleList = _moduleService.GetList(keyValue).ToList();
            if (moduleList.Count > 1)
            {
                //遍历删除
                foreach (ModuleEntity entity in moduleList)
                {
                    if (!string.IsNullOrEmpty(entity.Id))
                        _moduleService.RemoveForm(entity.Id);
                }
            }
            else
            {
                _moduleService.RemoveForm(keyValue);
            }
        }

        /// <summary>
        /// 保存表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonListJson">按钮实体列表</param>
        /// <param name="moduleColumnListJson">视图实体列表</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ModuleEntity moduleEntity, string moduleButtonListJson, string moduleColumnListJson)
        {
            var moduleButtonList = moduleButtonListJson.JsonToList<ModuleButtonEntity>();
            var moduleColumnList = moduleColumnListJson.JsonToList<ModuleColumnEntity>();
            
            _moduleService.SaveForm(keyValue, moduleEntity, moduleButtonList, moduleColumnList);
        }
    }
}