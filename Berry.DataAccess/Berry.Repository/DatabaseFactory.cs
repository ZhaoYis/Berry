using System;
using System.Reflection;
using Berry.Code;
using Berry.IOC;
using Berry.Log;
using Microsoft.Practices.Unity;

namespace Berry.Data.Repository
{
    /// <summary>
    /// 仓储模型工厂
    /// </summary>
    public class DatabaseFactory : BaseLogger
    {
        //private static volatile IDatabase database = null;
        /// <summary>
        /// 默认连接字符串配置项名称
        /// </summary>
        private const string BaseConnStringName = "MsSqlBaseDbConnectionString";
        /// <summary>
        /// IDatabase实现类的构造函数参数名
        /// </summary>
        private const string BaseParameterName = "connStringName";

        /// <summary>
        /// 定义仓储，默认
        /// </summary>
        /// <returns></returns>
        protected IDatabase BaseRepository()
        {
            IDatabase database = null;
            this.Logger(this.GetType(), "定义仓储，默认-BaseRepository", () =>
            {
                UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                //特别注意：此处的 connStringName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, BaseConnStringName);

                string mapToName = UnityIocHelper.GetmapToByName("DbContainer", "DatabaseType");
                DatabaseType dbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), mapToName, true);
                DbHandlingCenter.DbType = dbType;

                database = helper.GetService<IDatabase>(parm);
            }, e =>
            {

            });
            return database;
        }

        /// <summary>
        /// 定义仓储，带参
        /// </summary>
        /// <param name="connStringName">连接字符串配置项名称</param>
        /// <returns></returns>
        protected IDatabase BaseRepository(string connStringName)
        {
            IDatabase database = null;
            this.Logger(this.GetType(), "定义仓储，带参-BaseRepository", () =>
            {
                UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                //特别注意：此处的 connStringName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, connStringName);

                string mapToName = UnityIocHelper.GetmapToByName("DbContainer", "DatabaseType");
                DatabaseType dbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), mapToName, true);
                DbHandlingCenter.DbType = dbType;

                database = helper.GetService<IDatabase>(parm);
            }, e =>
            {

            });
            return database;
        }

        /// <summary>
        /// 定义仓储，带参
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        protected IDatabase BaseRepository(DatabaseType dbType)
        {
            IDatabase database = null;
            this.Logger(this.GetType(), "定义仓储，带参-BaseRepository", () =>
            {
                UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                //特别注意：此处的 connStringName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, BaseConnStringName);

                DbHandlingCenter.DbType = dbType;

                database = helper.GetService<IDatabase>(parm);
            }, e =>
            {

            });
            return database;
        }

        /// <summary>
        /// 定义仓储，带参
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connStringName">连接字符串配置项名称</param>
        /// <returns></returns>
        protected IDatabase BaseRepository(DatabaseType dbType, string connStringName)
        {
            IDatabase database = null;
            this.Logger(this.GetType(), "定义仓储，带参-BaseRepository", () =>
            {
                UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                //特别注意：此处的 connStringName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, connStringName);

                DbHandlingCenter.DbType = dbType;

                database = helper.GetService<IDatabase>(parm);
            }, e =>
            {

            });
            return database;
        }

        /// <summary>
        /// 通过反射创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyString"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private T CreateInstence<T>(string assemblyString, string typeName) where T : class, IDatabase
        {
            Assembly assembly = Assembly.Load(assemblyString);

            return assembly.CreateInstance(typeName, false) as T;
        }
    }
}