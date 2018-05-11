using Berry.BLL.BaseManage;
using Berry.Cache;
using Berry.Entity.BaseManage;
using System.Collections.Generic;
using System.Linq;

namespace Berry.App.Cache
{
    /// <summary>
    /// 角色信息缓存
    /// </summary>
    public class RoleCache
    {
        private RoleBLL busines = new RoleBLL();

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            IEnumerable<RoleEntity> cacheList = CacheFactory.GetCacheInstance().GetCache<IEnumerable<RoleEntity>>(busines.CacheKey);
            if (cacheList == null)
            {
                cacheList = busines.GetRoleList();
                CacheFactory.GetCacheInstance().WriteCache(cacheList, busines.CacheKey);
            }
            return cacheList;
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="organizeId">机构Id</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRoleList(string organizeId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                data = data.Where(t => t.OrganizeId == organizeId);
            }
            return data;
        }

        /// <summary>
        /// 角色实体
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleEntity GetRoleEntity(string roleId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(roleId))
            {
                var d = data.Where(t => t.Id == roleId).ToList<RoleEntity>();
                if (d.Count > 0)
                {
                    return d[0];
                }
            }
            return new RoleEntity();
        }
    }
}