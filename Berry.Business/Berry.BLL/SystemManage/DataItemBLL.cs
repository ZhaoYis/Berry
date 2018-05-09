using Berry.Entity.SystemManage;
using Berry.IBLL.SystemManage;
using Berry.IService.SystemManage;
using Berry.Service.SystemManage;
using System.Collections.Generic;

namespace Berry.BLL.SystemManage
{
    /// <summary>
    /// 数据字典分类
    /// </summary>
    public class DataItemBLL : IDataItemBLL
    {
        private readonly IDataItemService _dataItemService = new DataItemService();

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemEntity> GetDataItemList()
        {
            return _dataItemService.GetDataItemList();
        }

        /// <summary>
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByKey(string keyValue)
        {
            return _dataItemService.GetEntityByKey(keyValue);
        }

        /// <summary>
        /// 根据分类编号获取实体对象
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByCode(string itemCode)
        {
            return _dataItemService.GetEntityByCode(itemCode);
        }

        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemCode(string itemCode, string keyValue)
        {
            return _dataItemService.ExistItemCode(itemCode, keyValue);
        }

        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue)
        {
            return _dataItemService.ExistItemName(itemName, keyValue);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDataItemByKey(string keyValue)
        {
            _dataItemService.RemoveDataItemByKey(keyValue);
        }

        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        public void SaveDataItem(string keyValue, DataItemEntity dataItemEntity)
        {
            _dataItemService.SaveDataItem(keyValue, dataItemEntity);
        }
    }
}