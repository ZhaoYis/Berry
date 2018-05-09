using Berry.Data.Repository;

namespace Berry.Service.Base
{
    /// <summary>
    /// 基类Service，泛型
    /// </summary>
    public class BaseService<T> : RepositoryFactory<T> where T : class, new()
    {
    }
}