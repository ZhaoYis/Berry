﻿using System;
using Berry.BLL.BaseManage;
using Berry.Cache;
using Berry.Entity.BaseManage;
using System.Collections.Generic;
using System.Linq;
using Berry.Cache.Core.Base;

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
            List<DepartmentEntity> cacheList = CacheFactory.GetCache().Get<List<DepartmentEntity>>(busines.CacheKey);
            if (cacheList == null || cacheList.Count == 0)
            {
                cacheList = busines.GetDepartmentList().ToList();
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
                var cacheList = busines.GetDepartmentList().ToList();
                CacheFactory.GetCache().Add(busines.CacheKey, cacheList, expireTime);
            }
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