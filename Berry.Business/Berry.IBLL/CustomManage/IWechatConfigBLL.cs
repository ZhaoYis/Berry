using System;
using Berry.Entity.CustomManage;
using Berry.Entity.CommonEntity;
using System.Collections.Generic;

namespace Berry.IBLL.CustomManage
{
    /// <summary>
    /// �� ����V1.0.0
    /// Copyright (c) 2017-2018
    /// �� ������ʦ��
    /// �� �ڣ�2019-01-10 14:55
    /// �� ����΢������
    /// </summary>
    public interface IWechatConfigBLL
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<WechatConfigEntity> GetPageList(PaginationEntity pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<WechatConfigEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        WechatConfigEntity GetEntity(string keyValue);

        /// <summary>
        /// ���ݻ���ID��ȡ��Ȩ��Ϣ
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        WechatConfigEntity GetEntityByOrgId(string orgId);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string keyValue, WechatConfigEntity entity);

        /// <summary>
        /// ����Զ���˵�
        /// </summary>
        /// <param name="json"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Tuple<bool, string> AddCustomMenu(string json, string keyValue);
        #endregion
    }
}
