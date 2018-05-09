using Berry.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.BaseManage
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_User");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键

            #region 配置关系

            //this.Ignore(t => t.PK);

            #endregion 配置关系
        }
    }
}