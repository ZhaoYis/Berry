using Berry.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.SystemManage
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class LogMap : EntityTypeConfiguration<LogEntity>
    {
        public LogMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_Log");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}