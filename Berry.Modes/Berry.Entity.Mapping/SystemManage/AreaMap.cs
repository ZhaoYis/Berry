using System.Data.Entity.ModelConfiguration;
using Berry.Entity.SystemManage;

namespace Berry.Entity.Mapping.SystemManage
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public class AreaMap : EntityTypeConfiguration<AreaEntity>
    {
        public AreaMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_Area");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
