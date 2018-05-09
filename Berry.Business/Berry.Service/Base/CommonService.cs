using Berry.IService.BaseManage;
using System.Data;

namespace Berry.Service.Base
{
    /// <summary>
    /// 公共服务
    /// </summary>
    public class CommonService : BaseService, ICommonService
    {
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="type">CommandType</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, CommandType type)
        {
            return null;
        }
    }
}