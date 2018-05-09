using Berry.Entity.BaseManage;
using Berry.IBLL.BaseManage;
using Berry.IService.BaseManage;
using Berry.Service.BaseManage;
using System.Collections.Generic;

namespace Berry.BLL.BaseManage
{
    /// <summary>
    /// 机构管理
    /// </summary>
    public partial class OrganizeBLL : IOrganizeBLL
    {
        private readonly IOrganizeService _organizeService = new OrganizeService();

        /// <summary>
        /// 缓存key
        /// </summary>
        public string CacheKey = "__OrganizeCacheKey";

        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrganizeEntity> GetOrganizeList()
        {
            return _organizeService.GetOrganizeList();
        }

        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public OrganizeEntity GetOrganizeEntity(string keyValue)
        {
            return _organizeService.GetOrganizeEntity(keyValue);
        }

        /// <summary>
        /// 公司名称不能重复
        /// </summary>
        /// <param name="organizeName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string organizeName, string keyValue)
        {
            return _organizeService.ExistFullName(organizeName, keyValue);
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _organizeService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            return _organizeService.ExistShortName(shortName, keyValue);
        }

        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveOrganizeByKey(string keyValue)
        {
            _organizeService.RemoveOrganizeByKey(keyValue);
        }

        /// <summary>
        /// 保存机构表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="organizeEntity">机构实体</param>
        /// <returns></returns>
        public void AddOrganize(string keyValue, OrganizeEntity organizeEntity)
        {
            _organizeService.AddOrganize(keyValue, organizeEntity);
        }
    }
}