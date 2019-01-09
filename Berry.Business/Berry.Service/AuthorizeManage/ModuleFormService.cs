using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using Berry.Data.Extension;
using Berry.Data.Repository;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using Newtonsoft.Json.Linq;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 系统表单
    /// </summary>
    public class ModuleFormService : BaseService<ModuleFormEntity>, IModuleFormService
    {
        #region 获取数据
        /// <summary>
        /// 获取分页数据(管理页面调用)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetPageList(PaginationEntity pagination, string queryJson)
        {
            DataTable res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取所有功能按钮-GetModuleButtonList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT
	                                m.Id,
	                                m.ModuleId,
	                                m1.FullName as ModuleName,
	                                m.EnCode,
	                                m.FullName,
	                                m.SortCode,
	                                m.DeleteMark,
	                                m.EnabledMark,
	                                m.Description,
	                                m.CreateDate,
	                                m.CreateUserId,
	                                m.CreateUserName,
	                                m.ModifyDate,
	                                m.ModifyUserId,
	                                m.ModifyUserName
                                FROM
	                                Base_ModuleForm m
                                LEFT JOIN Base_Module m1 ON m1.Id = m.ModuleId
                                WHERE m.DeleteMark = 0");

                    List<DbParameter> parameter = new List<DbParameter>();
                    JObject queryParam = queryJson.TryToJObject();
                    if (queryParam != null)
                    {
                        if (!string.IsNullOrEmpty(queryParam["Keyword"].ToString()))//关键字查询
                        {
                            string keyord = queryParam["Keyword"].ToString();
                            strSql.Append(@" AND ( m1.FullName LIKE @keyword 
                                        or m.FullName LIKE @keyword 
                                        or m.CreateUserName LIKE @keyword )");

                            parameter.Add(DbParameters.CreateDbParameter("@keyword", '%' + keyord + '%'));
                        }
                    }

                    Tuple<DataTable, int> data = this.BaseRepository().FindTable(conn, strSql.ToString(), parameter, pagination.sidx, pagination.sord.ToLower() == "asc", pagination.rows, pagination.page);
                    pagination.records = data.Item2;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });

            return res;
        }
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ModuleFormEntity GetEntity(string keyValue)
        {
            ModuleFormEntity res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取一个实体类-GetEntity", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindEntity<ModuleFormEntity>(conn, keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        /// <summary>
        /// 通过模块Id获取系统表单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public ModuleFormEntity GetEntityByModuleId(string moduleId)
        {
            ModuleFormEntity res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "通过模块Id获取系统表单-GetEntityByModuleId", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<ModuleFormEntity>();
                    expression = expression.And(t => t.ModuleId == moduleId);
                    res = this.BaseRepository().FindEntity<ModuleFormEntity>(conn, expression, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        /// <summary>
        /// 判断模块是否已经有系统表单
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public bool IsExistModuleId(string keyValue, string moduleId)
        {
            bool res = false;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "判断模块是否已经有系统表单-IsExistModuleId", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<ModuleFormEntity>();
                    if (string.IsNullOrEmpty(keyValue))
                    {
                        expression = expression.And(t => t.ModuleId == moduleId);
                    }
                    else
                    {
                        expression = expression.And(t => t.ModuleId == moduleId && t.Id != keyValue);
                    }
                    ModuleFormEntity entity = this.BaseRepository().FindEntity<ModuleFormEntity>(conn, expression, tran);
                    res = entity != null;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormEntity entity)
        {
            int res = 0;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "保存一个实体-SaveEntity", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (string.IsNullOrEmpty(keyValue))
                    {
                        entity.Create();
                        res = this.BaseRepository().Insert(conn, entity, tran);
                    }
                    else
                    {
                        entity.Modify(keyValue);
                        res = this.BaseRepository().Update(conn, entity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        /// <summary>
        /// 虚拟删除一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int VirtualDelete(string keyValue)
        {
            int res = 0;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "虚拟删除一个实体-VirtualDelete", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    ModuleFormEntity entity = this.BaseRepository().FindEntity<ModuleFormEntity>(conn, keyValue, tran);
                    if (entity != null)
                    {
                        entity.DeleteMark = true;
                        res = this.BaseRepository().Update(conn, entity, tran);
                    }
                    else
                    {
                        throw new Exception("没有该记录无法删除");
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        #endregion
    }
}
