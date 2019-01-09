using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.IService.BaseManage;
using Berry.Service.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Berry.Service.BaseManage
{
    /// <summary>
    /// 岗位管理
    /// </summary>
    public class PostService : BaseService<RoleEntity>, IPostService
    {
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPostList()
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPostList-岗位列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<RoleEntity>(conn, t => t.Category == 2 && t.EnabledMark == true && t.DeleteMark == false, tran);
                    res = res.OrderByDescending(r => r.CreateDate);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
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
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPostPageList-岗位列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

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

                    Tuple<IEnumerable<RoleEntity>, int> tuple = this.BaseRepository().FindList<RoleEntity>(conn, expression, pagination.sidx, pagination.sord.ToLower() == "asc", pagination.rows, pagination.page, tran);
                    pagination.records = tuple.Item2;
                    res = tuple.Item1;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 岗位列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllPostList()
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetAllPostList-岗位列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    string GetAllUserGroupSQL = @"SELECT  r.Id ,
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
                    res = this.BaseRepository().FindList<RoleEntity>(conn, GetAllUserGroupSQL.ToString(), tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 岗位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetPostEntity(string keyValue)
        {
            RoleEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPostEntity-岗位实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindEntity<RoleEntity>(conn, keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
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
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistEnCode-岗位编号不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(conn, t => t.Category == 2 && t.DeleteMark == false && t.EnabledMark == true && t.EnCode == enCode, tran).ToList();
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }
                    res = data.Count > 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 岗位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistFullName-岗位名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(conn, t => t.Category == 2 && t.DeleteMark == false && t.EnabledMark == true && t.FullName == fullName, tran).ToList();
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }
                    res = data.Count > 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemovePostByKey(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemovePostByKey-删除岗位", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    int res = this.BaseRepository().Delete<RoleEntity>(conn, keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存岗位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="postEntity">岗位实体</param>
        /// <returns></returns>
        public void SavePost(string keyValue, RoleEntity postEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SavePost-保存岗位表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        postEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<RoleEntity>(conn, postEntity, tran);
                    }
                    else
                    {
                        postEntity.Create();
                        postEntity.Category = 2;
                        int res = this.BaseRepository().Insert<RoleEntity>(conn, postEntity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }
    }
}