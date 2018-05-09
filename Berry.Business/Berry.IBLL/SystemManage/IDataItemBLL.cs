using Berry.Entity.SystemManage;
using System.Collections.Generic;

namespace Berry.IBLL.SystemManage
{
    /// <summary>
    /// 数据字典分类
    /// </summary>
    public interface IDataItemBLL
    {
        #region 获取数据

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataItemEntity> GetDataItemList();

        /// <summary>
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DataItemEntity GetEntityByKey(string keyValue);

        /// <summary>
        /// 根据分类编号获取实体对象
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <returns></returns>
        DataItemEntity GetEntityByCode(string itemCode);

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistItemCode(string itemCode, string keyValue);

        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistItemName(string itemName, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveDataItemByKey(string keyValue);

        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        void SaveDataItem(string keyValue, DataItemEntity dataItemEntity);

        #endregion 提交数据
    }
}