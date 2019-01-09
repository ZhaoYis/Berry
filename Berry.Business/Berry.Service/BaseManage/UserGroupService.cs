using System;
using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.IService.BaseManage;
using Berry.Service.Base;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Berry.Service.BaseManage
{
    /// <summary>
    /// 用户组管理
    /// </summary>
    public class UserGroupService : BaseService<RoleEntity>, IUserGroupService
    {
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetUserGroupList()
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetUserGroupList-用户组列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<RoleEntity>(conn, t => t.Category == 4 && t.EnabledMark == true && t.DeleteMark == false, tran);
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
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPageList-用户组列表", () =>
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
                    expression = expression.And(t => t.Category == 4 && t.DeleteMark == false && t.EnabledMark == true);
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
        /// 用户组列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllUserGroupList()
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetAllUserGroupList-用户组列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
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
        /// 用户组实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetUserGroupEntity(string keyValue)
        {
            RoleEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetUserGroupEntity-用户组实体", () =>
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
        /// 组编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistEnCode-组编号不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<RoleEntity> data = this.BaseRepository().FindList<RoleEntity>(conn, t => t.Category == 4 && t.DeleteMark == false && t.EnabledMark == true && t.EnCode == enCode, tran).ToList();
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
        /// 组名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistFullName-组名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<RoleEntity> data = this.BaseRepository().FindList<RoleEntity>(conn, t => t.Category == 4 && t.DeleteMark == false && t.EnabledMark == true && t.FullName == fullName, tran).ToList();
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
        /// 删除用户组
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveUserGroupByKey(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveUserGroupByKey-删除用户组", () =>
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
        /// 保存用户组表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userGroupEntity">用户组实体</param>
        /// <returns></returns>
        public void SaveUserGroup(string keyValue, RoleEntity userGroupEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveRole-保存角色表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        userGroupEntity.Modify(keyValue);

                        int res = this.BaseRepository().Update<RoleEntity>(conn, userGroupEntity, tran);
                    }
                    else
                    {
                        userGroupEntity.Create();
                        userGroupEntity.Category = 4;

                        int res = this.BaseRepository().Insert<RoleEntity>(conn, userGroupEntity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
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
                                            WHERE o.FullName is not null and r.Category = 4 and r.EnabledMark = 1 and r.DeleteMark = 0
                                            ORDER BY o.FullName, r.SortCode";

        #endregion SQL语句
    }
}