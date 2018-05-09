using Berry.Entity.SystemManage;
using Berry.Entity.ViewModel;
using System.Collections.Generic;

namespace Berry.IService.SystemManage
{
    /// <summary>
    /// 数据字典明细
    /// </summary>
    public interface IDataItemDetailService
    {
        #region 获取数据

        /// <summary>
        /// 明细列表
        /// </summary>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        IEnumerable<DataItemDetailEntity> GetDataItemDetailList(string itemId);

        /// <summary>
        /// 明细实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DataItemDetailEntity GetDataItemDetailEntity(string keyValue);

        /// <summary>
        /// 获取数据字典列表（给绑定下拉框提供的）
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataItemViewModel> GetDataItemList();

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 项目值不能重复
        /// </summary>
        /// <param name="itemValue">项目值</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        bool ExistItemValue(string itemValue, string keyValue, string itemId);

        /// <summary>
        /// 项目名不能重复
        /// </summary>
        /// <param name="itemName">项目名</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        bool ExistItemName(string itemName, string keyValue, string itemId);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveDataItemDetailByKey(string keyValue);

        /// <summary>
        /// 保存明细表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemDetailEntity">明细实体</param>
        /// <returns></returns>
        void SaveDataItemDetail(string keyValue, DataItemDetailEntity dataItemDetailEntity);

        #endregion 提交数据
    }
}