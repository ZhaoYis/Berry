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

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 授权功能视图
    /// </summary>
    public class ModuleColumnService : BaseService<ModuleColumnEntity>, IModuleColumnService
    {
        /// <summary>
        /// 根据用户ID获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId)
        {
            IEnumerable<ModuleColumnEntity> res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "根据用户ID获取授权功能视图-GetModuleColumnList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT  *
                            FROM    Base_ModuleColumn
                            WHERE   Id IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 3
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     Id = @Id ) )
                                            OR ObjectId = @Id )  Order By SortCode");

                    DbParameter[] parameter =
                    {
                        DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "Id", userId, DbType.String)
                    };
                    res = this.BaseRepository().FindList<ModuleColumnEntity>(conn, strSql.ToString(), parameter, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetList(string moduleId)
        {
            IEnumerable<ModuleColumnEntity> res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "视图列表-GetList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<ModuleColumnEntity>(conn, t => t.ModuleId == moduleId, tran).OrderBy(t => t.SortCode);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleColumnEntity GetEntity(string keyValue)
        {
            ModuleColumnEntity res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "视图实体-GetEntity", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindEntity<ModuleColumnEntity>(conn, keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList()
        {
            IEnumerable<ModuleColumnEntity> res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取所有授权功能视图-GetModuleColumnList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT * FROM Base_ModuleColumn Order By SortCode ASC");
                    res = this.BaseRepository().FindList<ModuleColumnEntity>(conn, strSql.ToString(), tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 添加视图
        /// </summary>
        /// <param name="moduleColumnEntity">视图实体</param>
        public void AddEntity(ModuleColumnEntity moduleColumnEntity)
        {
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "添加视图-AddEntity", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    moduleColumnEntity.Create();
                    int res = this.BaseRepository().Insert<ModuleColumnEntity>(conn, moduleColumnEntity, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }
    }
}