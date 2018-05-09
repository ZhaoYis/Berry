using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.IBLL.BaseManage;
using Berry.IService.BaseManage;
using Berry.Service.BaseManage;
using System.Collections.Generic;

namespace Berry.BLL.BaseManage
{
    /// <summary>
    /// 用户组管理
    /// </summary>
    public class UserGroupBLL : IUserGroupBLL
    {
        private readonly IUserGroupService _userGroupService = new UserGroupService();

        /// <summary>
        /// 缓存key
        /// </summary>
        public string CacheKey = "__UserGroupCacheKey";

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetUserGroupList()
        {
            return _userGroupService.GetUserGroupList();
        }

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            return _userGroupService.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 用户组列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllUserGroupList()
        {
            return _userGroupService.GetAllUserGroupList();
        }

        /// <summary>
        /// 用户组实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetUserGroupEntity(string keyValue)
        {
            return _userGroupService.GetUserGroupEntity(keyValue);
        }

        /// <summary>
        /// 组编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _userGroupService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 组名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            return _userGroupService.ExistFullName(fullName, keyValue);
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveUserGroupByKey(string keyValue)
        {
            _userGroupService.RemoveUserGroupByKey(keyValue);
        }

        /// <summary>
        /// 保存用户组表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userGroupEntity">用户组实体</param>
        /// <returns></returns>
        public void SaveUserGroup(string keyValue, RoleEntity userGroupEntity)
        {
            _userGroupService.SaveUserGroup(keyValue, userGroupEntity);
        }
    }
}