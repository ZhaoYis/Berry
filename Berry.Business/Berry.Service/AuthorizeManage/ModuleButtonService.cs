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
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId ) Order By SortCode");

            DbParameter[] parameter =
            {
                new SqlParameter("@UserId",SqlDbType.NVarChar,36)
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
    }
}