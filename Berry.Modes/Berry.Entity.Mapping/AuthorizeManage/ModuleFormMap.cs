using Berry.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.AuthorizeManage
{
    /// <summary>
    /// 系统表单
    /// </summary>
    public class ModuleFormMap : EntityTypeConfiguration<ModuleFormEntity>
    {
        public ModuleFormMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_ModuleForm");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}