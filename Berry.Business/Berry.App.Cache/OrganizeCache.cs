using System;
using Berry.BLL.BaseManage;
using Berry.Cache;
using Berry.Entity.BaseManage;
using System.Collections.Generic;
using System.Linq;
using Berry.Cache.Core.Base;

namespace Berry.App.Cache
{
    /// <summary>
    /// 组织架构缓存
    /// </summary>
    public class OrganizeCache
    {
        private OrganizeBLL busines = new OrganizeBLL();

        /// <summary>
        /// 组织列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrganizeEntity> GetOrganizList()
        {
            var cacheList = CacheFactory.GetCache().Get<List<OrganizeEntity>>(busines.CacheKey);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = busines.GetOrganizeList().ToList();
                CacheFactory.GetCache().Add(busines.CacheKey, cacheList);
            }
            return cacheList;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <returns></returns>
        public void RefreshCache(TimeSpan expireTime)
        {
            bool hasExpire = CacheFactory.GetCache().Exists(busines.CacheKey);
            if (!hasExpire)
            {
                var cacheList = busines.GetOrganizeList().ToList();
                CacheFactory.GetCache().Add(busines.CacheKey, cacheList, expireTime);
            }
        }

        /// <summary>
        /// 组织列表
        /// </summary>
        /// <param name="organizeId">机构Id</param>
        /// <returns></returns>
        public OrganizeEntity GetOrganizEntity(string organizeId)
        {
            var data = this.GetOrganizList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                var d = data.Where(t => t.Id == organizeId).ToList<OrganizeEntity>();
                if (d.Count > 0)
                {
                    return d[0];
                }
            }
            return new OrganizeEntity();
        }
    }
}