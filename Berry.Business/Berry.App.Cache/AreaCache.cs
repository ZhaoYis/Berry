using System;
using System.Collections.Generic;
using System.Linq;
using Berry.BLL.SystemManage;
using Berry.Cache;
using Berry.Entity.SystemManage;

namespace Berry.App.Cache
{
    /// <summary>
    /// 区域数据缓存
    /// </summary>
    public class AreaCache
    {
        private AreaBLL areaBll = new AreaBLL();

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <returns></returns>
        private IEnumerable<AreaEntity> GetList()
        {
            var cacheList = CacheFactory.GetCacheInstance().GetListCache<AreaEntity>(areaBll.CacheKey, out long total);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = areaBll.GetList().ToList();
                //以集合的方式存在缓存下面
                //CacheFactory.GetCacheInstance().WriteListCache<AreaEntity>(cacheList, areaBll.CacheKey);

                //以单体的形式存在缓存下面
                foreach (AreaEntity model in cacheList)
                {
                    CacheFactory.GetCacheInstance().WriteCache<AreaEntity>(model, areaBll.CacheKey);
                }
            }
            return cacheList;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <returns></returns>
        public void RefreshCache(DateTime expireTime)
        {
            bool hasExpire = CacheFactory.GetCacheInstance().HasExpire(areaBll.CacheKey);
            if (!hasExpire)
            {
                var cacheList = areaBll.GetList().ToList();
                //以集合的方式存在缓存下面
                //CacheFactory.GetCacheInstance().WriteListCache<AreaEntity>(cacheList, areaBll.CacheKey);

                //以单体的形式存在缓存下面
                foreach (AreaEntity model in cacheList)
                {
                    CacheFactory.GetCacheInstance().WriteCache<AreaEntity>(model, areaBll.CacheKey, expireTime);
                }
            }
        }

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns></returns>
        public IEnumerable<AreaEntity> GetList(string parentId, string keyword = "")
        {
            List<AreaEntity> data = this.GetList().ToList();
            if (!string.IsNullOrEmpty(parentId))
            {
                data = data.Where(d => d.ParentId == parentId).ToList();
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(t => t.AreaCode.Contains(keyword) || t.AreaName.Contains(keyword)).ToList();
            }

            return data.OrderBy(t => t.CreateDate).ToList();
        }

        /// <summary>
        /// 区域列表（主要是给绑定数据源提供的）
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <returns></returns>
        public IEnumerable<AreaEntity> GetAreaList(string parentId)
        {
            return this.GetList().Where(t => t.EnabledMark == true && t.DeleteMark == false && t.ParentId == parentId);
        }

        /// <summary>
        /// 区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AreaEntity GetEntity(string keyValue)
        {
            List<AreaEntity> data = this.GetList().ToList();
            return data.FirstOrDefault(d => d.Id == keyValue);
        }
    }
}