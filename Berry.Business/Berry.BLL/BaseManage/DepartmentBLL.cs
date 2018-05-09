using Berry.Entity.BaseManage;
using Berry.IBLL.BaseManage;
using Berry.IService.BaseManage;
using Berry.Service.BaseManage;
using System.Collections.Generic;

namespace Berry.BLL.BaseManage
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public class DepartmentBLL : IDepartmentBLL
    {
        private readonly IDepartmentService _departmentService = new DepartmentService();

        /// <summary>
        /// 缓存key
        /// </summary>
        public string CacheKey = "__DepartmentCacheKey";

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetDepartmentList()
        {
            return _departmentService.GetDepartmentList();
        }

        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DepartmentEntity GetDepartmentEntity(string keyValue)
        {
            return _departmentService.GetDepartmentEntity(keyValue);
        }

        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        /// <param name="departmentName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string departmentName, string keyValue)
        {
            return _departmentService.ExistFullName(departmentName, keyValue);
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _departmentService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            return _departmentService.ExistShortName(shortName, keyValue);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDepartmentByKey(string keyValue)
        {
            _departmentService.RemoveDepartmentByKey(keyValue);
        }

        /// <summary>
        /// 保存部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        public void AddDepartment(string keyValue, DepartmentEntity departmentEntity)
        {
            _departmentService.AddDepartment(keyValue, departmentEntity);
        }
    }
}