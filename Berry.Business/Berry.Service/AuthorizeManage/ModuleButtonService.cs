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
    /// 系统按钮
    /// </summary>
    public class ModuleButtonService : BaseService<ModuleButtonEntity>, IModuleButtonService
    {
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId)
        {
            IEnumerable<ModuleButtonEntity> res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取授权功能按钮-GetModuleButtonList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT  *
                            FROM    Base_ModuleButton
                            WHERE   Id IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @Id ) )
                                            OR ObjectId = @Id ) Order By SortCode");

                    //DbParameter[] parameter =
                    //{
                    //    //new SqlParameter("@Id",SqlDbType.NVarChar,36)
                    //    DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "Id", userId, DbType.String)
                    //};
                    res = this.BaseRepository().FindList<ModuleButtonEntity>(conn, strSql.ToString(), new { Id = userId }, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });

            return res;
        }

        /// <summary>
        /// 获取所有功能按钮
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList()
        {
            IEnumerable<ModuleButtonEntity> res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取所有功能按钮-GetModuleButtonList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT * FROM Base_ModuleButton  Order By SortCode ASC");
                    res = this.BaseRepository().FindList<ModuleButtonEntity>(conn, strSql.ToString(), tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });

            return res;
        }

        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetList(string moduleId)
        {
            IEnumerable<ModuleButtonEntity> res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "按钮列表-GetList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<ModuleButtonEntity>();
                    expression = expression.And(t => t.ModuleId == moduleId);
                    res = this.BaseRepository().FindList(conn, expression, tran).OrderBy(t => t.SortCode).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleButtonEntity GetEntity(string keyValue)
        {
            ModuleButtonEntity res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "按钮实体-GetEntity", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindEntity<ModuleButtonEntity>(conn, keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="moduleButtonEntity">按钮实体</param>
        public void AddEntity(ModuleButtonEntity moduleButtonEntity)
        {
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "添加按钮-AddEntity", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    moduleButtonEntity.Create();
                    int res = this.BaseRepository().Insert<ModuleButtonEntity>(conn, moduleButtonEntity, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });

        }
    }
}