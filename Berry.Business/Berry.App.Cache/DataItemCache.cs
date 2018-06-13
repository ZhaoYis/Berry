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
            List<DataItemViewModel> cacheList = CacheFactory.GetCacheInstance().GetListCache<DataItemViewModel>(_dataItemDetailBll.CacheKey, out long total);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = _dataItemDetailBll.GetDataItemList().ToList();
                //以集合的方式存在缓存下面
                CacheFactory.GetCacheInstance().WriteListCache<DataItemViewModel>(cacheList, _dataItemDetailBll.CacheKey);

                //以单体的形式存在缓存下面
                //foreach (DataItemViewModel model in cacheList)
                //{
                //    CacheFactory.GetCacheInstance().WriteCache<DataItemViewModel>(model, _dataItemDetailBll.CacheKey);
                //}
            }
            return cacheList;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <returns></returns>
        public void RefreshCache(DateTime expireTime)
        {
            bool hasExpire = CacheFactory.GetCacheInstance().HasExpire(_dataItemDetailBll.CacheKey);
            if (!hasExpire)
            {
                var cacheList = _dataItemDetailBll.GetDataItemList().ToList();
                //以集合的方式存在缓存下面
                CacheFactory.GetCacheInstance().WriteListCache<DataItemViewModel>(cacheList, _dataItemDetailBll.CacheKey, expireTime);

                //以单体的形式存在缓存下面
                //foreach (DataItemViewModel model in cacheList)
                //{
                //    CacheFactory.GetCacheInstance().WriteCache<DataItemViewModel>(model, _dataItemDetailBll.CacheKey);
                //}
            }
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