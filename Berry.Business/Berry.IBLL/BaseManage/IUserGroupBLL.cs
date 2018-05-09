using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using System.Collections.Generic;

namespace Berry.IBLL.BaseManage
{
    /// <summary>
    /// 用户组管理
    /// </summary>
    public interface IUserGroupBLL
    {
        #region 获取数据

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetUserGroupList();

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetPageList(PaginationEntity pagination, string queryJson);

        /// <summary>
        /// 用户组列表(ALL)
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetAllUserGroupList();

        /// <summary>
        /// 用户组实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        RoleEntity GetUserGroupEntity(string keyValue);

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 组编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string enCode, string keyValue);

        /// <summary>
        /// 组名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistFullName(string fullName, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveUserGroupByKey(string keyValue);

        /// <summary>
        /// 保存用户组表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userGroupEntity">用户组实体</param>
        /// <returns></returns>
        void SaveUserGroup(string keyValue, RoleEntity userGroupEntity);

        #endregion 提交数据
    }
}