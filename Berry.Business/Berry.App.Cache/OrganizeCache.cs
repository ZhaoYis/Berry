using System;
using Berry.BLL.BaseManage;
using Berry.Cache;
using Berry.Entity.BaseManage;
using System.Collections.Generic;
using System.Linq;

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
            var cacheList = CacheFactory.GetCacheInstance().GetListCache<OrganizeEntity>(busines.CacheKey, out long toatl);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = busines.GetOrganizeList().ToList();
                CacheFactory.GetCacheInstance().WriteListCache<OrganizeEntity>(cacheList, busines.CacheKey);
            }
            return cacheList;
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