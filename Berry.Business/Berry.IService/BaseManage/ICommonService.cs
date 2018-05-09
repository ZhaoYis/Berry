using System.Data;

namespace Berry.IService.BaseManage
{
    /// <summary>
    /// 公共服务
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="type">CommandType</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, CommandType type);
    }
}