using Berry.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2017-2018
    /// �� ������ʦ��
    /// �� �ڣ�2018-05-28 23:00
    /// �� ����Base_Advertisement
    /// </summary>
    public class BaseAdvertisementMap : EntityTypeConfiguration<BaseAdvertisementEntity>
    {
        public BaseAdvertisementMap()
        {
            #region ������
            //��
            this.ToTable("Base_Advertisement");
            //����
            this.HasKey(t => t.PK);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
