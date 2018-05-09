using Berry.Code;

namespace Berry.Data.Repository
{
    /// <summary>
    /// 定义仓储模型工厂
    /// </summary>
    /// <typeparam name="T">动态实体类型</typeparam>
    public class RepositoryFactory<T> where T : class, new()
    {
        /// <summary>
        /// 定义仓储，自定义
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        public IRepository<T> BaseRepository(string connString)
        {
            return new Repository<T>(DbFactory.Base(connString, DatabaseType.SqlServer));
        }

        /// <summary>
        /// 定义仓储（基础库）
        /// </summary>
        /// <returns></returns>
        public IRepository<T> BaseRepository(DatabaseLinksEnum link = DatabaseLinksEnum.Base)
        {
            switch (link)
            {
                case DatabaseLinksEnum.Base:
                    return new Repository<T>(DbFactory.Base());

                default:
                    return new Repository<T>(DbFactory.Base());
            }
        }
    }
}