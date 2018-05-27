using System;
using Berry.BLL.SystemManage;
using Berry.Cache;
using Berry.Entity.SystemManage;
using Berry.Entity.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Berry.App.Cache
{
    /// <summary>
    /// 数据字典缓存
    /// </summary>
    public class DataItemCache
    {
        /// <summary>
        /// 字典详细
        /// </summary>
        private DataItemDetailBLL _dataItemDetailBll = new DataItemDetailBLL();

        /// <summary>
        /// 字典分类
        /// </summary>
        private static DataItemBLL _dataItemBll = new DataItemBLL();

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetDataItemList()
        {
            List<DataItemViewModel> cacheList = CacheFactory.GetCacheInstance().GetCache<List<DataItemViewModel>>(_dataItemDetailBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _dataItemDetailBll.GetDataItemList().ToList();
                CacheFactory.GetCacheInstance().WriteCache(cacheList, _dataItemDetailBll.CacheKey);
            }
            return cacheList;
        }

        /// <summary>
        /// 根据编码获取项目
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataItemEntity GetDataItemEntityByCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                DataItemEntity entity = CacheFactory.GetCacheInstance().GetCache<DataItemEntity>("__" + code);
                if (entity == null)
                {
                    entity = _dataItemBll.GetEntityByCode(code);
                    CacheFactory.GetCacheInstance().WriteCache(entity, "__" + code);
                }
                return entity;
            }
            return default(DataItemEntity);
        }

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="enCode">分类代码，多个用|隔开</param>
        /// <returns></returns>
        public List<DataItemViewModel> GetDataItemList(string enCode)
        {
            string[] codeArr = enCode.Split("|".ToArray());

            return this.GetDataItemList().Where(t => codeArr.Contains(t.EnCode) && t.EnabledMark == true).ToList();
        }

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="enCode">分类代码</param>
        /// <param name="itemValue">项目值</param>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetSubDataItemList(string enCode, string itemValue)
        {
            IEnumerable<DataItemViewModel> data = this.GetDataItemList().Where(t => t.EnCode == enCode);
            IEnumerable<DataItemViewModel> dataItemModels = data as DataItemViewModel[] ?? data.ToArray();
            string itemDetailId = dataItemModels.First(t => t.ItemValue == itemValue).ItemDetailId;
            return dataItemModels.Where(t => t.ParentId == itemDetailId);
        }

        /// <summary>
        /// 根据itemvalue 获取实体
        /// </summary>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DataItemViewModel GetItemDetailByItemValue(string itemValue)
        {
            DataItemViewModel data = this.GetDataItemList().First(t => t.ItemValue == itemValue);
            return data;
        }

        /// <summary>
        /// 项目值转换名称
        /// </summary>
        /// <param name="enCode">分类代码</param>
        /// <param name="itemValue">项目值</param>
        /// <returns></returns>
        public string ToItemName(string enCode, string itemValue)
        {
            IEnumerable<DataItemViewModel> data = this.GetDataItemList().Where(t => t.EnCode == enCode);
            return data.First(t => t.ItemValue == itemValue).ItemName;
        }
    }
}