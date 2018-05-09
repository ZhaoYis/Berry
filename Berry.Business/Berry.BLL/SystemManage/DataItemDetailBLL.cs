using Berry.Entity.SystemManage;
using Berry.Entity.ViewModel;
using Berry.IBLL.SystemManage;
using Berry.IService.SystemManage;
using Berry.Service.SystemManage;
using System.Collections.Generic;

namespace Berry.BLL.SystemManage
{
    /// <summary>
    /// 数据字典明细
    /// </summary>
    public class DataItemDetailBLL : IDataItemDetailBLL
    {
        private readonly IDataItemDetailService _dataItemDetailService = new DataItemDetailService();

        /// <summary>
        /// 缓存key
        /// </summary>
        public string CacheKey = "__DataItemDetailCacheKey";

        /// <summary>
        /// 明细列表
        /// </summary>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public IEnumerable<DataItemDetailEntity> GetDataItemDetailList(string itemId)
        {
            return _dataItemDetailService.GetDataItemDetailList(itemId);
        }

        /// <summary>
        /// 明细实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemDetailEntity GetDataItemDetailEntity(string keyValue)
        {
            return _dataItemDetailService.GetDataItemDetailEntity(keyValue);
        }

        /// <summary>
        /// 获取数据字典列表（给绑定下拉框提供的）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetDataItemList()
        {
            return _dataItemDetailService.GetDataItemList();
        }

        /// <summary>
        /// 项目值不能重复
        /// </summary>
        /// <param name="itemValue">项目值</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public bool ExistItemValue(string itemValue, string keyValue, string itemId)
        {
            return _dataItemDetailService.ExistItemValue(itemValue, keyValue, itemId);
        }

        /// <summary>
        /// 项目名不能重复
        /// </summary>
        /// <param name="itemName">项目名</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue, string itemId)
        {
            return _dataItemDetailService.ExistItemName(itemName, keyValue, itemId);
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDataItemDetailByKey(string keyValue)
        {
            _dataItemDetailService.RemoveDataItemDetailByKey(keyValue);
        }

        /// <summary>
        /// 保存明细表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemDetailEntity">明细实体</param>
        /// <returns></returns>
        public void SaveDataItemDetail(string keyValue, DataItemDetailEntity dataItemDetailEntity)
        {
            _dataItemDetailService.SaveDataItemDetail(keyValue, dataItemDetailEntity);
        }
    }
}