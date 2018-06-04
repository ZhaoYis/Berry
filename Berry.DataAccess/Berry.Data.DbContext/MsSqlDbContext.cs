using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Berry.Data.DbContext
{
    /// <summary>
    /// 数据访问(SqlServer) 上下文
    /// </summary>
    public class MsSqlDbContext : System.Data.Entity.DbContext, IDbContext
    {
        #region 构造函数

        /// <summary>
        /// 初始化一个 使用指定数据连接名称或连接串 的数据访问上下文类 的新实例
        /// </summary>
        /// <param name="connString"></param>
        public MsSqlDbContext(string connString) : base(connString)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        #endregion 构造函数

        #region 重载

        /// <summary>
        /// 创建模型时的操作
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string assembleFileName = AppDomain.CurrentDomain.BaseDirectory + "bin/Berry.Entity.Mapping.dll";
            Assembly asm = Assembly.LoadFile(assembleFileName);
            var typesToRegister = asm.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        #endregion 重载
    }
}