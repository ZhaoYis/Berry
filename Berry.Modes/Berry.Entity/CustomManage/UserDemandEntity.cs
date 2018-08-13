using System;
using System.ComponentModel.DataAnnotations.Schema;
using Berry.Code;
using Berry.Code.Operator;
using Berry.Util;

namespace Berry.Entity.CustomManage
{
    /// <summary>
    /// �� ����V1.0.0
    /// Copyright (c) 2017-2018
    /// �� ������ʦ��
    /// �� �ڣ�2018-08-13 22:13
    /// �� �����û�����
    /// </summary>
    [Table("Bus_UserDemand")]
    public class UserDemandEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        /// <summary>
        /// ��Ҫ����
        /// </summary>
        /// <returns></returns>
        public string MainContent { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string Category { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        public string CategoryId { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public bool IsDelete { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.Id = CommonHelper.GetGuid().ToString();
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.IsDelete = false;
        }

        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Id = keyValue;
        }
        #endregion
    }
}