using Berry.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.AuthorizeManage
{
    /// <summary>
    /// 授权数据范围
    /// </summary>
    public class AuthorizeDataMap : EntityTypeConfiguration<AuthorizeDataEntity>
    {
        public AuthorizeDataMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_AuthorizeData");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}