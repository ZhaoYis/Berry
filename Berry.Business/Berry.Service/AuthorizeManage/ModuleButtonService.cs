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
    /// 系统按钮
    /// </summary>
    public class ModuleButtonService : BaseService, IModuleButtonService
    {
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  Id
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     Id = @Id ) )
                                            OR ObjectId = @Id ) Order By SortCode");

            DbParameter[] parameter =
            {
                //new SqlParameter("@Id",SqlDbType.NVarChar,36)
                DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "Id", userId, DbType.String)
            };

            IEnumerable<ModuleButtonEntity> res = this.BaseRepository().FindList<ModuleButtonEntity>(strSql.ToString(), parameter);

            return res;
        }

        /// <summary>
        /// 获取所有功能按钮
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM Base_ModuleButton  Order By SortCode ASC");

            IEnumerable<ModuleButtonEntity> res = this.BaseRepository().FindList<ModuleButtonEntity>(strSql.ToString());

            return res;
        }

        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetList(string moduleId)
        {
            var expression = LambdaExtension.True<ModuleButtonEntity>();
            expression = expression.And(t => t.ModuleId == moduleId);
            return this.BaseRepository().FindList(expression).OrderBy(t => t.SortCode).ToList();
        }

        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleButtonEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<ModuleButtonEntity>(keyValue);
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="moduleButtonEntity">按钮实体</param>
        public void AddEntity(ModuleButtonEntity moduleButtonEntity)
        {
            moduleButtonEntity.Create();
            this.BaseRepository().Insert<ModuleButtonEntity>(moduleButtonEntity);
        }
    }
}