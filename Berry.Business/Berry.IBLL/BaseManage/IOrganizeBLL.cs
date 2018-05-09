using Berry.Entity.BaseManage;
using System.Collections.Generic;

namespace Berry.IBLL.BaseManage
{
    /// <summary>
    /// 机构管理
    /// </summary>
    public partial interface IOrganizeBLL
    {
        #region 获取数据

        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrganizeEntity> GetOrganizeList();

        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        OrganizeEntity GetOrganizeEntity(string keyValue);

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 公司名称不能重复
        /// </summary>
        /// <param name="organizeName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistFullName(string organizeName, string keyValue);

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string enCode, string keyValue);

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistShortName(string shortName, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveOrganizeByKey(string keyValue);

        /// <summary>
        /// 保存机构表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="organizeEntity">机构实体</param>
        /// <returns></returns>
        void AddOrganize(string keyValue, OrganizeEntity organizeEntity);

        #endregion 提交数据
    }
}