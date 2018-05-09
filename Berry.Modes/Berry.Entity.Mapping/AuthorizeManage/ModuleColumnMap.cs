using Berry.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.AuthorizeManage
{
    /// <summary>
    /// 系统视图
    /// </summary>
    public class ModuleColumnMap : EntityTypeConfiguration<ModuleColumnEntity>
    {
        public ModuleColumnMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_ModuleColumn");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}