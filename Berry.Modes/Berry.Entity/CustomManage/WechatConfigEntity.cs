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
    /// �� �ڣ�2019-01-10 14:55
    /// �� ����΢������
    /// </summary>
    [Table("Base_WechatConfig")]
    public class WechatConfigEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// AppId
        /// </summary>
        /// <returns></returns>
        public string AppId { get; set; }
        /// <summary>
        /// AppSecret
        /// </summary>
        /// <returns></returns>
        public string AppSecret { get; set; }
        /// <summary>
        /// ��Ȩ����
        /// </summary>
        /// <returns></returns>
        public string AuthDomainUrl { get; set; }
        /// <summary>
        /// ΢����Ŀ������ַ
        /// </summary>
        /// <returns></returns>
        public string WxDomainUrl { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        public string OrganizeId { get; set; }
        /// <summary>
        /// �Ƿ��Ѿ��Զ����˲˵�
        /// </summary>
        public bool HasCustomMenu { get; set; }
        /// <summary>
        /// �Զ���˵�JSON����
        /// </summary>
        public string CustomMenuJson { get; set; }
        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <returns></returns>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// ���ñ�־
        /// </summary>
        /// <returns></returns>
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// �޸���ID
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// �޸���
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
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
            this.DeleteMark = false;
            this.EnabledMark = true;
        }

        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Id = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}