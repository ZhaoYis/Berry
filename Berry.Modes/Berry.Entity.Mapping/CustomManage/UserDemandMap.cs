using Berry.Entity.CustomManage;
using System.Data.Entity.ModelConfiguration;

namespace Berry.Entity.Mapping.CustomManage
{
    /// <summary>
    /// �� ����V1.0.0
    /// Copyright (c) 2017-2018
    /// �� ������ʦ��
    /// �� �ڣ�2018-08-13 22:13
    /// �� �����û�����
    /// </summary>
    public class UserDemandMap : EntityTypeConfiguration<UserDemandEntity>
    {
        public UserDemandMap()
        {
            #region ������
            //��
            this.ToTable("Bus_UserDemand");
            //����
            this.HasKey(t => t.Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
