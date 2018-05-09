using Berry.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.BaseManage
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public class DepartmentMap : EntityTypeConfiguration<DepartmentEntity>
    {
        public DepartmentMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_Department");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}