using System;
using Berry.Entity.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Berry.Data.Extension;
using Berry.Extension;
using Berry.Util;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public class ModuleService : BaseService<ModuleEntity>, IModuleService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList(string userId)
        {
            IEnumerable<ModuleEntity> res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取授权功能-GetModuleList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT  *
                            FROM    Base_Module
                            WHERE   Id IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @Id ) )
                                            OR ObjectId = @Id )
                            AND EnabledMark = 1  AND DeleteMark = 0 Order By SortCode");

                    //DbParameter[] parameter =
                    //{
                    //    //new SqlParameter("@Id",SqlDbType.NVarChar,36)
                    //    DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "Id", userId, DbType.String)
                    //};
                    res = this.BaseRepository().FindList<ModuleEntity>(conn, strSql.ToString(), new { Id = userId }, tran).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 获取所有授权功能
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList()
        {
            IEnumerable<ModuleEntity> res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取所有授权功能-GetModuleList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT * FROM Base_Module AS m WHERE EnabledMark = 1 AND DeleteMark = 0 Order By SortCode");
                    res = this.BaseRepository().FindList<ModuleEntity>(conn, strSql.ToString(), tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetSortCode()
        {
            int res = 100001;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取所有功能按钮-GetModuleButtonList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    int sortCode = this.BaseRepository().FindList<ModuleEntity>(conn, m => m.DeleteMark == false, tran).Max(t => t.SortCode).TryToInt32();
                    if (!string.IsNullOrEmpty(sortCode.ToString()))
                    {
                        res = sortCode + 1;
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
        /// 功能列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetList(string parentId)
        {
            IEnumerable<ModuleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetList-功能列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    if (!string.IsNullOrEmpty(parentId))
                    {
                        parentId = StringHelper.SqlFilters(parentId);
                        strSql.Append("SELECT * FROM Base_Module Where ParentId ='" + parentId + "' Order By SortCode");
                    }
                    else
                    {
                        strSql.Append("SELECT * FROM Base_Module Order By SortCode");
                    }

                    res = this.BaseRepository().FindList<ModuleEntity>(conn, strSql.ToString(), tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 功能实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleEntity GetEntity(string keyValue)
        {
            ModuleEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-功能实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindEntity<ModuleEntity>(conn, keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistEnCode-功能编号不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<ModuleEntity>();
                    expression = expression.And(t => t.EnCode == enCode);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        expression = expression.And(t => t.Id != keyValue);
                    }

                    res = this.BaseRepository().FindList<ModuleEntity>(conn, expression, tran).ToList().Count == 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistFullName-功能名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<ModuleEntity>();
                    expression = expression.And(t => t.FullName == fullName);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        expression = expression.And(t => t.Id != keyValue);
                    }

                    res = this.BaseRepository().FindList<ModuleEntity>(conn, expression, tran).ToList().Count == 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveForm-删除功能", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    int count = this.BaseRepository().FindList<ModuleEntity>(conn, t => t.ParentId == keyValue, tran).Count();
                    if (count > 0)
                    {
                        throw new Exception("当前所选数据有子节点数据！");
                    }
                    //删除模块
                    this.BaseRepository().Delete<ModuleEntity>(conn, keyValue, tran);
                    //删除按钮
                    this.BaseRepository().Delete<ModuleButtonEntity>(conn, t => t.ModuleId == keyValue, tran);
                    //删除视图
                    this.BaseRepository().Delete<ModuleColumnEntity>(conn, t => t.ModuleId == keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonList">按钮实体列表</param>
        /// <param name="moduleColumnList">视图实体列表</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ModuleEntity moduleEntity, List<ModuleButtonEntity> moduleButtonList, List<ModuleColumnEntity> moduleColumnList)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-保存表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    int res = -1;
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        res = this.BaseRepository().Update<ModuleEntity>(conn,moduleEntity, tran);
                    }
                    else
                    {
                        moduleEntity.Create();
                        res = this.BaseRepository().Insert(conn, moduleEntity, tran);
                    }

                    res = this.BaseRepository().Delete<ModuleButtonEntity>(conn, t => t.ModuleId == keyValue, tran);
                    if (moduleButtonList != null)
                    {
                        List<ModuleButtonEntity> temp = new List<ModuleButtonEntity>();
                        foreach (ModuleButtonEntity buttonEntity in moduleButtonList)
                        {
                            buttonEntity.Create();
                            temp.Add(buttonEntity);
                        }
                        res = this.BaseRepository().Insert<ModuleButtonEntity>(conn, temp, tran);
                    }

                    res = this.BaseRepository().Delete<ModuleColumnEntity>(conn, t => t.ModuleId == keyValue, tran);
                    if (moduleColumnList != null)
                    {
                        List<ModuleColumnEntity> temp = new List<ModuleColumnEntity>();
                        foreach (ModuleColumnEntity columnEntity in moduleColumnList)
                        {
                            columnEntity.Create();
                            temp.Add(columnEntity);
                        }
                        res = this.BaseRepository().Insert<ModuleColumnEntity>(conn, temp, tran);
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