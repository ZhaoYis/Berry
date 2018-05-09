using Berry.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.SystemManage
{
    /// <summary>
    /// 数据字典明细
    /// </summary>
    public class DataItemDetailMap : EntityTypeConfiguration<DataItemDetailEntity>
    {
        public DataItemDetailMap()
        {
            #region 表、主键

            //表
            this.ToTable("Base_DataItemDetail");
            //主键
            this.HasKey(t => t.Id);

            #endregion 表、主键
        }
    }
}