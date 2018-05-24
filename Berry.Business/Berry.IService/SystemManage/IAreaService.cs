using System.Collections.Generic;
using Berry.Entity.SystemManage;

namespace Berry.IService.SystemManage
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public interface IAreaService
    {
        #region 获取数据
        /// <summary>
        /// 区域列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<AreaEntity> GetList();
        /// <summary>
        /// 区域列表
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns></returns>
        IEnumerable<AreaEntity> GetList(string parentId, string keyword);
        /// <summary>
        /// 区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        AreaEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除区域
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="areaEntity">区域实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, AreaEntity areaEntity);
        #endregion
    }
}
