using System;
using System.Data.Entity.Infrastructure;

namespace Berry.Data.DbContext
{
    /// <summary>
    /// 数据库连接接口
    /// </summary>
    public interface IDbContext : IDisposable, IObjectContextAdapter
    {
    }
}