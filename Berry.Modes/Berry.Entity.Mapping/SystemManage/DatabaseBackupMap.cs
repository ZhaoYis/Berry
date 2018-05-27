using System.Data.Entity.ModelConfiguration;
using Berry.Entity.SystemManage;

namespace Berry.Entity.Mapping.SystemManage
{
    /// <summary>
    /// 数据库备份
    /// </summary>
    public class DataBaseBackupMap : EntityTypeConfiguration<DataBaseBackupEntity>
    {
        public DataBaseBackupMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_DatabaseBackup");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
