using Berry.Entity.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public class ModuleService : BaseService, IModuleService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )
                            AND EnabledMark = 1  AND DeleteMark = 0 Order By SortCode");

            DbParameter[] parameter =
            {
                new SqlParameter("@UserId",SqlDbType.NVarChar,36)
            };

            IEnumerable<ModuleEntity> res = this.BaseRepository().FindList<ModuleEntity>(strSql.ToString(), parameter).ToList();

            return res;
        }

        /// <summary>
        /// 获取所有授权功能
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM Base_Module WHERE EnabledMark = 1 AND DeleteMark = 0 Order By SortCode");

            IEnumerable<ModuleEntity> res = this.BaseRepository().FindList<ModuleEntity>(strSql.ToString());

            return res;
        }
    }
}