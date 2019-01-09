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
    /// 角色管理
    /// </summary>
    public class RoleService : BaseService<RoleEntity>, IRoleService
    {
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRoleList()
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetRoleList-角色列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<RoleEntity>(conn, t => t.Category == 1 && t.EnabledMark == true && t.DeleteMark == false, tran);
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
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRolePageList(PaginationEntity pagination, string queryJson)
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetRolePageList-角色列表", () =>
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
                    expression = expression.And(t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true);
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
        /// 角色列表all
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllRoleList()
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetAllRoleList-角色列表all", () =>
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
        /// 角色实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetRoleEntity(string keyValue)
        {
            RoleEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetRoleEntity-角色实体", () =>
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
        /// 角色编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistEnCode-角色编号不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<RoleEntity> data = this.BaseRepository().FindList<RoleEntity>(conn, t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true && t.EnCode == enCode, tran).ToList();
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
        /// 角色名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistFullName-角色名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<RoleEntity> data = this.BaseRepository().FindList<RoleEntity>(conn, t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true && t.FullName == fullName, tran).ToList();
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
        /// 删除角色
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveRoleByKey(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveRoleByKey-删除角色", () =>
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
        /// 保存角色表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="roleEntity">角色实体</param>
        /// <returns></returns>
        public void SaveRole(string keyValue, RoleEntity roleEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveRole-保存角色表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        roleEntity.Modify(keyValue);

                        int res = this.BaseRepository().Update<RoleEntity>(conn, roleEntity, tran);
                    }
                    else
                    {
                        roleEntity.Create();
                        roleEntity.Category = 1;

                        int res = this.BaseRepository().Insert<RoleEntity>(conn, roleEntity, tran);
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
                                            WHERE o.FullName is not null and r.Category = 1 and r.EnabledMark = 1 and r.DeleteMark = 0
                                            ORDER BY o.FullName, r.SortCode";

        #endregion SQL语句
    }
}