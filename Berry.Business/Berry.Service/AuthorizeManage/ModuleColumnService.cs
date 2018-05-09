using Berry.Entity.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

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
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 3
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )  Order By SortCode");

            DbParameter[] parameter =
            {
                new SqlParameter("@UserId",SqlDbType.NVarChar,36)
            };

            IEnumerable<ModuleColumnEntity> res = this.BaseRepository().FindList<ModuleColumnEntity>(strSql.ToString(), parameter);

            return res;
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
    }
}