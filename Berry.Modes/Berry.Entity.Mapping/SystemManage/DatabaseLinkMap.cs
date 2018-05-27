using System.Data.Entity.ModelConfiguration;
using Berry.Entity.SystemManage;

namespace Berry.Entity.Mapping.SystemManage
{
    /// <summary>
    /// 数据库连接管理
    /// </summary>
    public class DataBaseLinkMap : EntityTypeConfiguration<DataBaseLinkEntity>
    {
        public DataBaseLinkMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_DatabaseLink");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
