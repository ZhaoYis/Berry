using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.IService.BaseManage;
using Berry.Service.Base;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Berry.Service.BaseManage
{
    /// <summary>
    /// 岗位管理
    /// </summary>
    public class PostService : BaseService, IPostService
    {
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPostList()
        {
            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(t => t.Category == 2 && t.EnabledMark == true && t.DeleteMark == false);
            res = res.OrderByDescending(r => r.CreateDate);

            return res;
        }

        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPostPageList(PaginationEntity pagination, string queryJson)
        {
            var expression = LambdaExtension.True<RoleEntity>();
            JObject queryParam = queryJson.TryToJObject();
            if (queryParam != null)
            {
                string enCode = queryParam["EnCode"].ToString();
                string fullName = queryParam["FullName"].ToString();

                if (!string.IsNullOrEmpty(enCode))
                {
                    expression = expression.And(t => t.EnCode.Contains(enCode));
                }

                if (!string.IsNullOrEmpty(fullName))
                {
                    expression = expression.And(t => t.FullName.Contains(fullName));
                }
            }
            expression = expression.And(t => t.Category == 2 && t.DeleteMark == false && t.EnabledMark == true);

            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(expression, pagination);

            return res;
        }

        /// <summary>
        /// 岗位列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllPostList()
        {
            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(GetAllUserGroupSQL.ToString());

            return res;
        }

        /// <summary>
        /// 岗位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetPostEntity(string keyValue)
        {
            RoleEntity res = this.BaseRepository().FindEntity<RoleEntity>(keyValue);

            return res;
        }

        /// <summary>
        /// 岗位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(t => t.Category == 2 && t.DeleteMark == false && t.EnabledMark == true && t.EnCode == enCode).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 岗位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(t => t.Category == 2 && t.DeleteMark == false && t.EnabledMark == true && t.FullName == fullName).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemovePostByKey(string keyValue)
        {
            int res = this.BaseRepository().Delete<RoleEntity>(keyValue);
        }

        /// <summary>
        /// 保存岗位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="postEntity">岗位实体</param>
        /// <returns></returns>
        public void SavePost(string keyValue, RoleEntity postEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                postEntity.Modify(keyValue);

                int res = this.BaseRepository().Update<RoleEntity>(postEntity);
            }
            else
            {
                postEntity.Create();
                postEntity.Category = 2;

                int res = this.BaseRepository().Insert<RoleEntity>(postEntity);
            }
        }

        #region SQL语句

        /// <summary>
        /// 用户组列表
        /// </summary>
        private const string GetAllUserGroupSQL = @"SELECT  r.Id ,
				                                            o.FullName AS OrganizeId ,
				                                            r.Category ,
				                                            r.EnCode ,
				                                            r.FullName ,
				                                            r.SortCode ,
				                                            r.EnabledMark ,
				                                            r.Description ,
				                                            r.CreateDate,
                                                            r.DeleteMark
                                            FROM    Base_Role r
				                                            LEFT JOIN Base_Organize o ON o.Id = r.OrganizeId
                                            WHERE o.FullName is not null and r.Category = 2 and r.EnabledMark = 1 and r.DeleteMark = 0
                                            ORDER BY o.FullName, r.SortCode";

        #endregion SQL语句
    }
}