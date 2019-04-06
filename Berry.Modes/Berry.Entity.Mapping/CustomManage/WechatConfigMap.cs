using Berry.Entity.CustomManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.CustomManage
{
    /// <summary>
    /// �� ����V1.0.0
    /// Copyright (c) 2017-2018
    /// �� ������ʦ��
    /// �� �ڣ�2019-01-10 14:55
    /// �� ����΢������
    /// </summary>
    public class WechatConfigMap : EntityTypeConfiguration<WechatConfigEntity>
    {
        public WechatConfigMap()
        {
            #region ������
            //��
            this.ToTable("Base_WechatConfig");
            //����
            this.HasKey(t => t.Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
