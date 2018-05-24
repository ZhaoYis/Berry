using System.Data.Entity.ModelConfiguration;
using Berry.Entity.PublicInfoManage;

namespace Berry.Entity.Mapping.PublicInfoManage
{
    /// <summary>
    /// 新闻中心
    /// </summary>
    public class NewsMap : EntityTypeConfiguration<NewsEntity>
    {
        public NewsMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_News");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
