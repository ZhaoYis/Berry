using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using System.Collections.Generic;

namespace Berry.IService.BaseManage
{
    /// <summary>
    /// 岗位管理
    /// </summary>
    public interface IPostService
    {
        #region 获取数据

        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetPostList();

        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetPostPageList(PaginationEntity pagination, string queryJson);

        /// <summary>
        /// 岗位列表(ALL)
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetAllPostList();

        /// <summary>
        /// 岗位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        RoleEntity GetPostEntity(string keyValue);

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 岗位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string enCode, string keyValue);

        /// <summary>
        /// 岗位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistFullName(string fullName, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemovePostByKey(string keyValue);

        /// <summary>
        /// 保存岗位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="postEntity">岗位实体</param>
        /// <returns></returns>
        void SavePost(string keyValue, RoleEntity postEntity);

        #endregion 提交数据
    }
}