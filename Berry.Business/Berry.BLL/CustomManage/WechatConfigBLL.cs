using Berry.Entity.CustomManage;
using Berry.IService.CustomManage;
using Berry.Service.CustomManage;
using Berry.IBLL.CustomManage;
using Berry.Entity.CommonEntity;
using System.Collections.Generic;
using System;
using Berry.BLL.Base;

namespace Berry.BLL.CustomManage
{
    /// <summary>
    /// �� ����V1.0.0
    /// Copyright (c) 2017-2018
    /// �� ������ʦ��
    /// �� �ڣ�2019-01-10 14:55
    /// �� ����΢������
    /// </summary>
    public class WechatConfigBLL : BaseBLL<WechatConfigEntity>, IWechatConfigBLL
    {
        private IWechatConfigService service = new WechatConfigService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<WechatConfigEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<WechatConfigEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public WechatConfigEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        /// <summary>
        /// ���ݻ���ID��ȡ��Ȩ��Ϣ
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public WechatConfigEntity GetEntityByOrgId(string orgId)
        {
            return service.GetEntityByOrgId(orgId);
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            service.RemoveForm(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, WechatConfigEntity entity)
        {
            service.SaveForm(keyValue, entity);
        }

        /// <summary>
        /// ����Զ���˵�
        /// </summary>
        /// <param name="json"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Tuple<bool, string> AddCustomMenu(string json, string keyValue)
        {
            return service.AddCustomMenu(json, keyValue);
        }

        #endregion
    }
}
