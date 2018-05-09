using Berry.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public class ModuleMap : EntityTypeConfiguration<ModuleEntity>
    {
        public ModuleMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_Module");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}