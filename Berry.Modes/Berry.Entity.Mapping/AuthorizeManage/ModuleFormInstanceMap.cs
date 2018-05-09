using Berry.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.AuthorizeManage
{
    /// <summary>
    /// 系统表单
    /// </summary>
    public class ModuleFormInstanceMap : EntityTypeConfiguration<ModuleFormInstanceEntity>
    {
        public ModuleFormInstanceMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_ModuleFormInstance");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}