using Berry.Entity.CustomManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.CustomManage
{
    /// <summary>
    /// 版 本：V1.0.0
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2019-01-10 14:55
    /// 描 述：微信配置
    /// </summary>
    public class WechatConfigMap : EntityTypeConfiguration<WechatConfigEntity>
    {
        public WechatConfigMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_WechatConfig");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
