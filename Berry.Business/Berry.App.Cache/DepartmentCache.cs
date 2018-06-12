using System;
using Berry.BLL.BaseManage;
using Berry.Cache;
using Berry.Entity.BaseManage;
using System.Collections.Generic;
using System.Linq;

namespace Berry.App.Cache
{
    /// <summary>
    /// 部门信息缓存
    /// </summary>
    public class DepartmentCache
    {
        private DepartmentBLL busines = new DepartmentBLL();

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetList()
        {
            List<DepartmentEntity> cacheList = CacheFactory.GetCacheInstance().GetListCache<DepartmentEntity>(busines.CacheKey,out long total);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = busines.GetDepartmentList().ToList();
                CacheFactory.GetCacheInstance().WriteListCache<DepartmentEntity>(cacheList, busines.CacheKey);
            }
            return cacheList;
        }

        /// <summary>
        /// 根据机构ID获取部门列表
        /// </summary>
        /// <param name="organizeId">机构Id</param>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetDepartmentList(string organizeId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                data = data.Where(t => t.OrganizeId == organizeId);
            }
            return data;
        }

        /// <summary>
        /// 根据部门ID获取部门详细信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public DepartmentEntity GetDepartmentEntity(string departmentId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(departmentId))
            {
                var d = data.Where(t => t.Id == departmentId).ToList<DepartmentEntity>();
                if (d.Count > 0)
                {
                    return d[0];
                }
            }
            return new DepartmentEntity();
        }
    }
}