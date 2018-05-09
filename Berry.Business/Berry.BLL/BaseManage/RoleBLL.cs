using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.IBLL.BaseManage;
using Berry.IService.BaseManage;
using Berry.Service.BaseManage;
using System.Collections.Generic;

namespace Berry.BLL.BaseManage
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleBLL : IRoleBLL
    {
        private readonly IRoleService _roleService = new RoleService();

        /// <summary>
        /// 缓存key
        /// </summary>
        public string CacheKey = "__RoleCacheKey";

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRoleList()
        {
            return _roleService.GetRoleList();
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRolePageList(PaginationEntity pagination, string queryJson)
        {
            return _roleService.GetRolePageList(pagination, queryJson);
        }

        /// <summary>
        /// 角色列表all
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllRoleList()
        {
            return _roleService.GetAllRoleList();
        }

        /// <summary>
        /// 角色实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetRoleEntity(string keyValue)
        {
            return _roleService.GetRoleEntity(keyValue);
        }

        /// <summary>
        /// 角色编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _roleService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 角色名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            return _roleService.ExistFullName(fullName, keyValue);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveRoleByKey(string keyValue)
        {
            _roleService.RemoveRoleByKey(keyValue);
        }

        /// <summary>
        /// 保存角色表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="roleEntity">角色实体</param>
        /// <returns></returns>
        public void SaveRole(string keyValue, RoleEntity roleEntity)
        {
            _roleService.SaveRole(keyValue, roleEntity);
        }
    }
}