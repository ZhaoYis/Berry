using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.IBLL.BaseManage;
using Berry.IService.BaseManage;
using Berry.Service.BaseManage;
using System.Collections.Generic;

namespace Berry.BLL.BaseManage
{
    /// <summary>
    /// 岗位管理
    /// </summary>
    public class PostBLL : IPostBLL
    {
        private readonly IPostService _postService = new PostService();

        /// <summary>
        /// 缓存key
        /// </summary>
        public string CacheKey = "__PostCacheKey";

        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPostList()
        {
            return _postService.GetPostList();
        }

        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPostPageList(PaginationEntity pagination, string queryJson)
        {
            return _postService.GetPostPageList(pagination, queryJson);
        }

        /// <summary>
        /// 岗位列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllPostList()
        {
            return _postService.GetAllPostList();
        }

        /// <summary>
        /// 岗位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetPostEntity(string keyValue)
        {
            return _postService.GetPostEntity(keyValue);
        }

        /// <summary>
        /// 岗位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _postService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 岗位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            return _postService.ExistFullName(fullName, keyValue);
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemovePostByKey(string keyValue)
        {
            _postService.RemovePostByKey(keyValue);
        }

        /// <summary>
        /// 保存岗位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="postEntity">岗位实体</param>
        /// <returns></returns>
        public void SavePost(string keyValue, RoleEntity postEntity)
        {
            _postService.SavePost(keyValue, postEntity);
        }
    }
}