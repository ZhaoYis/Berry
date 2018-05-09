using Berry.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.BaseManage
{
    /// <summary>
    /// 机构管理
    /// </summary>
    public class OrganizeMap : EntityTypeConfiguration<OrganizeEntity>
    {
        public OrganizeMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_Organize");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}