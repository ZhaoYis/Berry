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
            var cacheList = CacheFactory.GetCache().Get<List<RoleEntity>>(busines.CacheKey);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = busines.GetPostList().ToList();
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
                var cacheList = busines.GetPostList().ToList();
                CacheFactory.GetCache().Add(busines.CacheKey, cacheList, expireTime);
            }
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