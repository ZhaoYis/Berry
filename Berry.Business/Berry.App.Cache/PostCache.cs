using System;
using Berry.BLL.BaseManage;
using Berry.Cache;
using Berry.Entity.BaseManage;
using System.Collections.Generic;
using System.Linq;

namespace Berry.App.Cache
{
    /// <summary>
    /// 岗位信息缓存
    /// </summary>
    public class PostCache
    {
        private PostBLL busines = new PostBLL();

        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            var cacheList = CacheFactory.GetCacheInstance().GetCache<List<RoleEntity>>(busines.CacheKey);
            if (cacheList == null)
            {
                cacheList = busines.GetPostList().ToList();
                CacheFactory.GetCacheInstance().WriteCache(cacheList, busines.CacheKey);
            }
            return cacheList;
        }

        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <param name="organizeId">机构Id</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList(string organizeId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                data = data.Where(t => t.OrganizeId == organizeId);
            }
            return data;
        }
    }
}