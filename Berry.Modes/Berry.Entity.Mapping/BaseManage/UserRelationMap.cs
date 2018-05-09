using Berry.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.BaseManage
{
    /// <summary>
    /// 用户关系
    /// </summary>
    public class UserRelationMap : EntityTypeConfiguration<UserRelationEntity>
    {
        public UserRelationMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_UserRelation");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}