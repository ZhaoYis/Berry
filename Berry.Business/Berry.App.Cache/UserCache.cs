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
    /// 用户信息缓存
    /// </summary>
    public class UserCache
    {
        private UserBLL busines = new UserBLL();

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetList()
        {
            var cacheList = CacheFactory.GetCache().Get<List<UserEntity>>(busines.CacheKey);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = busines.GetUserList().ToList();
                CacheFactory.GetCache().Add(busines.CacheKey, cacheList);
            }
            return cacheList;
        }

        /// <summary>
        /// 根据部门ID获取用户列表
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetUserList(string departmentId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(departmentId))
            {
                data = data.Where(t => t.DepartmentId == departmentId);
            }
            return data;
        }
    }
}