using Berry.Code;

namespace Berry.Data.Repository
{
    /// <summary>
    /// 定义仓储模型工厂
    /// </summary>
    public class RepositoryFactory
    {
        /// <summary>
        /// 定义仓储，自定义
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        protected IRepository BaseRepository(string connString)
        {
            return new Repository(DbFactory.Base(connString, DatabaseType.SqlServer));
        }

        /// <summary>
        /// 定义仓储（基础库）
        /// </summary>
        /// <returns></returns>
        protected IRepository BaseRepository(DatabaseLinksEnum link = DatabaseLinksEnum.Base)
        {
            switch (link)
            {
                case DatabaseLinksEnum.Base:
                    return new Repository(DbFactory.Base());

                default:
                    return new Repository(DbFactory.Base());
            }
        }
    }
}