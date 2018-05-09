using Berry.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.SystemManage
{
    /// <summary>
    /// 数据字典分类
    /// </summary>
    public class DataItemMap : EntityTypeConfiguration<DataItemEntity>
    {
        public DataItemMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_DataItem");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}