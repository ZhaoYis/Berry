using Berry.Entity.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Berry.Data.Extension;
using Berry.Extension;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 授权功能视图
    /// </summary>
    public class ModuleColumnService : BaseService, IModuleColumnService
    {
        /// <summary>
        /// 根据用户ID获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleColumn
                            WHERE   ModuleColumnId IN (
                                    SELECT  Id
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 3
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     Id = @Id ) )
                                            OR ObjectId = @UserId )  Order By SortCode");

            DbParameter[] parameter =
            {
                //new SqlParameter("@Id",SqlDbType.NVarChar,36)
                DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "Id", userId, DbType.String)
            };

            IEnumerable<ModuleColumnEntity> res = this.BaseRepository().FindList<ModuleColumnEntity>(strSql.ToString(), parameter);

            return res;
        }

        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetList(string moduleId)
        {
            return this.BaseRepository().FindList<ModuleColumnEntity>(t => t.ModuleId == moduleId).OrderBy(t => t.SortCode);
        }

        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleColumnEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<ModuleColumnEntity>(keyValue);
        }

        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM Base_ModuleColumn Order By SortCode ASC");

            IEnumerable<ModuleColumnEntity> res = this.BaseRepository().FindList<ModuleColumnEntity>(strSql.ToString());

            return res;
        }

        /// <summary>
        /// 添加视图
        /// </summary>
        /// <param name="moduleColumnEntity">视图实体</param>
        public void AddEntity(ModuleColumnEntity moduleColumnEntity)
        {
            moduleColumnEntity.Create();
            this.BaseRepository().Insert<ModuleColumnEntity>(moduleColumnEntity);
        }
    }
}