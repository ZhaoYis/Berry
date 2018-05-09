using Berry.Entity.BaseManage;
using System.Collections.Generic;

namespace Berry.IService.BaseManage
{
    public interface IDepartmentService
    {
        #region 获取数据

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<DepartmentEntity> GetDepartmentList();

        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DepartmentEntity GetDepartmentEntity(string keyValue);

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        /// <param name="DepartmentName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistFullName(string DepartmentName, string keyValue);

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string enCode, string keyValue);

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistShortName(string shortName, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveDepartmentByKey(string keyValue);

        /// <summary>
        /// 保存部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        void AddDepartment(string keyValue, DepartmentEntity departmentEntity);

        #endregion 提交数据
    }
}