using Berry.Entity.BaseManage;
using Berry.Extension;
using Berry.IService.BaseManage;
using Berry.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Berry.Service.BaseManage
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetDepartmentList()
        {
            List<DepartmentEntity> res = this.BaseRepository().FindList<DepartmentEntity>(d => d.DeleteMark == false)
                .OrderByDescending(d => d.CreateDate).ToList();

            return res;
        }

        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DepartmentEntity GetDepartmentEntity(string keyValue)
        {
            DepartmentEntity res = this.BaseRepository().FindEntity<DepartmentEntity>(keyValue);

            return res;
        }

        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        /// <param name="departmentName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string departmentName, string keyValue)
        {
            List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(t => t.FullName == departmentName).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(t => t.EnCode == enCode).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(t => t.ShortName == shortName).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDepartmentByKey(string keyValue)
        {
            int count = this.BaseRepository().FindList<DepartmentEntity>(t => t.ParentId == keyValue).Count();
            if (count > 0)
            {
                throw new Exception("当前所选数据有子节点数据！");
            }

            int res = this.BaseRepository().Delete<DepartmentEntity>(keyValue);
        }

        /// <summary>
        /// 保存部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        public void AddDepartment(string keyValue, DepartmentEntity departmentEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                departmentEntity.Modify(keyValue);

                int res = this.BaseRepository().Update<DepartmentEntity>(departmentEntity);
            }
            else
            {
                departmentEntity.Create();

                int res = this.BaseRepository().Insert<DepartmentEntity>(departmentEntity);
            }
        }
    }
}