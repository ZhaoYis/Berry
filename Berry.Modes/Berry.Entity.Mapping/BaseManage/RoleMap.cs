using Berry.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.BaseManage
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleMap : EntityTypeConfiguration<RoleEntity>
    {
        public RoleMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_Role");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}