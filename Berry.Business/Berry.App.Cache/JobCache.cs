using System;
using System.Collections.Generic;
using System.Linq;
using Berry.BLL.BaseManage;
using Berry.Cache;
using Berry.Entity.BaseManage;

namespace Berry.App.Cache
{
    /// <summary>
    /// 职位信息缓存
    /// </summary>
    public class JobCache
    {
        private JobBLL busines = new JobBLL();

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <returns></returns>
        private IEnumerable<RoleEntity> GetList()
        {
            List<RoleEntity> cacheList = CacheFactory.GetCacheInstance().GetListCache<RoleEntity>(busines.CacheKey, out long total);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = busines.GetList().ToList();

                CacheFactory.GetCacheInstance().WriteListCache<RoleEntity>(cacheList, busines.CacheKey);
            }
            return cacheList;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <returns></returns>
        public void RefreshCache(DateTime expireTime)
        {
            bool hasExpire = CacheFactory.GetCacheInstance().HasExpire(busines.CacheKey);
            if (!hasExpire)
            {
                var cacheList = busines.GetList().ToList();
                CacheFactory.GetCacheInstance().WriteListCache<RoleEntity>(cacheList, busines.CacheKey, expireTime);
            }
        }

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="organizeId">机构Id</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList(string organizeId)
        {
            IEnumerable<RoleEntity> data = this.GetList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                data = data.Where(t => t.OrganizeId == organizeId);
            }
            return data;
        }

    }
}
