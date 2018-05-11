using Berry.Code;
using Berry.IOC;
using Microsoft.Practices.Unity;
using System;

namespace Berry.Data.Repository
{
    /// <summary>
    /// 数据库建立工厂
    /// </summary>
    public static class DbFactory
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IDatabase Base(string connString, DatabaseType dbType)
        {
            SqlHelper.DbType = dbType;

            ResolverOverride parConnStr = new ParameterOverride("connString", connString);
            ResolverOverride parDbType = new ParameterOverride("dbType", dbType.ToString());

            IDatabase database = UnityIocHelper.DbInstance.GetService<IDatabase>(parConnStr, parDbType);

            return database;
        }

        /// <summary>
        /// 连接基础库
        /// </summary>
        /// <returns></returns>
        public static IDatabase Base()
        {
            string mapToName = UnityIocHelper.GetmapToByName("DbContainer", "IDbContext");
            DatabaseType dbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), mapToName, true);
            SqlHelper.DbType = dbType;

            ResolverOverride parConnStr = new ParameterOverride("connString", "MsSqlBaseDbConnectionString");
            ResolverOverride parDbType = new ParameterOverride("dbType", dbType.ToString());

            IDatabase database = UnityIocHelper.DbInstance.GetService<IDatabase>(parConnStr, parDbType);

            return database;
        }
    }
}