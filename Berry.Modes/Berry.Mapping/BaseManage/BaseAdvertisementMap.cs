using Berry.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2018-05-28 23:00
    /// 描 述：Base_Advertisement
    /// </summary>
    public class BaseAdvertisementMap : EntityTypeConfiguration<BaseAdvertisementEntity>
    {
        public BaseAdvertisementMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_Advertisement");
            //主键
            this.HasKey(t => t.PK);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
