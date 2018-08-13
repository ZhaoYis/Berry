using Berry.Entity.CustomManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.CustomManage
{
    /// <summary>
    /// 版 本：V1.0.0
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2018-08-13 22:13
    /// 描 述：用户需求
    /// </summary>
    public class UserDemandMap : EntityTypeConfiguration<UserDemandEntity>
    {
        public UserDemandMap()
        {
            #region 表、主键
            //表
            this.ToTable("Bus_UserDemand");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
