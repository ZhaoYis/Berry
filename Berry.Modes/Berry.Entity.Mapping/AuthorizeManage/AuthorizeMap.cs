using Berry.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.AuthorizeManage
{
    /// <summary>
    /// 授权功能
    /// </summary>
    public class AuthorizeMap : EntityTypeConfiguration<AuthorizeEntity>
    {
        public AuthorizeMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_Authorize");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}