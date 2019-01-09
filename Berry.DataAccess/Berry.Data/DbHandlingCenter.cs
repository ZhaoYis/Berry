using Berry.Code;

namespace Berry.Data
{
    public class DbHandlingCenter
    {
        public DbHandlingCenter()
        {
            DbType = DatabaseType.SqlServer;
        }

        /// <summary>
        /// 当前操作的数据库类型
        /// </summary>
        public static DatabaseType DbType { get; set; }
    }
}