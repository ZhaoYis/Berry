using System;
using Berry.Entity.CustomManage;
using Berry.IService.CustomManage;
using Berry.Entity.CommonEntity;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Berry.Extension;
using Berry.Service.Base;
using Berry.Util;
using Newtonsoft.Json.Linq;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities.Menu;

namespace Berry.Service.CustomManage
{
    /// <summary>
    /// �� ����V1.0.0
    /// Copyright (c) 2017-2018
    /// �� ������ʦ��
    /// �� �ڣ�2019-01-10 14:55
    /// �� ����΢������
    /// </summary>
    public class WechatConfigService : BaseService<WechatConfigEntity>, IWechatConfigService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<WechatConfigEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            IEnumerable<WechatConfigEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPageList-��ȡ�б�", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<WechatConfigEntity>();
                    JObject queryParam = queryJson.TryToJObject();
                    if (queryParam != null)
                    {
                        if (!queryParam["AppSecret"].IsEmpty())
                        {
                            string AppSecret = queryParam["AppSecret"].ToString();
                            expression = expression.And(t => t.AppSecret.Contains(AppSecret));
                        }
                    }
                    expression = expression.And(c => c.DeleteMark == false);
                    Tuple<IEnumerable<WechatConfigEntity>, int> tuple = this.BaseRepository().FindList<WechatConfigEntity>(conn, expression, pagination.sidx, pagination.sord.ToLower() == "asc", pagination.rows, pagination.page, tran);
                    pagination.records = tuple.Item2;
                    res = tuple.Item1;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<WechatConfigEntity> GetList(string queryJson)
        {
            IEnumerable<WechatConfigEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPageList-��ȡ�б�", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<WechatConfigEntity>();
                    JObject queryParam = queryJson.TryToJObject();
                    if (queryParam != null)
                    {
                        if (!queryParam["AppSecret"].IsEmpty())
                        {
                            string AppSecret = queryParam["AppSecret"].ToString();
                            expression = expression.And(t => t.AppSecret.Contains(AppSecret));
                        }
                    }
                    expression = expression.And(c => c.DeleteMark == false);
                    res = this.BaseRepository().FindList<WechatConfigEntity>(conn, expression, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public WechatConfigEntity GetEntity(string keyValue)
        {
            WechatConfigEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-��ȡʵ��", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<WechatConfigEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// ���ݻ���ID��ȡ��Ȩ��Ϣ
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public WechatConfigEntity GetEntityByOrgId(string orgId)
        {
            WechatConfigEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntityByOrgId-���ݻ���ID��ȡ��Ȩ��Ϣ", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<WechatConfigEntity>(conn, o => o.OrganizeId == orgId && o.EnabledMark == true && o.DeleteMark == false, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveForm-ɾ������", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    int res = this.BaseRepository().Delete<WechatConfigEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, WechatConfigEntity entity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-��������������޸ģ�", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        entity.Modify(keyValue);
                        int res = this.BaseRepository().Update<WechatConfigEntity>(conn, entity, tran);
                    }
                    else
                    {
                        entity.Create();
                        int res = this.BaseRepository().Insert<WechatConfigEntity>(conn, entity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// ���΢���Զ���˵�
        /// </summary>
        public Tuple<bool, string> AddCustomMenu(string json, string keyValue)
        {
            //string orgId = ConfigHelper.GetValue("OrgId");
            WechatConfigEntity wechatConfig = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "AddCustomMenu-��ȡ΢��������Ϣ", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    wechatConfig = this.BaseRepository().FindEntity<WechatConfigEntity>(conn, o => o.Id == keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });

            if (wechatConfig != null)
            {
                string baseUrl = wechatConfig.WxDomainUrl;
                if (baseUrl.EndsWith("/")) baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);

                //�Ƿ�����ȷ��ȡtoken����Ƿ�������ȷ
                string token = AccessTokenContainer.TryGetAccessToken(wechatConfig.AppId, wechatConfig.AppSecret);
                if (string.IsNullOrEmpty(token))
                {
                    return new Tuple<bool, string>(false, "΢����֤ʧ�ܣ�����΢��Appid��AppSecret�Ƿ���ȷ��");
                }

                //�����˵�
                ButtonGroup menuButtonGroup = new ButtonGroup();
                menuButtonGroup.button.Add(new SingleViewButton()
                {
                    url = baseUrl + "/home",
                    name = "��ҳ",
                    type = "view"
                });
                menuButtonGroup.button.Add(new SingleViewButton()
                {
                    url = baseUrl + "/personage",
                    name = "��������",
                    type = "view"
                });

                //SubButton my = new SubButton()
                //{
                //    name = "�ҵ�"
                //};
                //my.sub_button.Add(new SingleViewButton()
                //{
                //    url = baseUrl + "Web/pages/user_center.html",
                //    name = "��Ա����",
                //    type = "view"
                //});
                //menuButtonGroup.button.Add(my);

                var menuResult = CommonApi.CreateMenu(wechatConfig.AppId, menuButtonGroup);
                if (menuResult.errcode != 0)
                {
                    return new Tuple<bool, string>(false, "����΢�Ų˵�ʧ�ܣ������ԣ�");
                }
                else
                {
                    this.SaveForm(wechatConfig.Id, new WechatConfigEntity
                    {
                        HasCustomMenu = true,
                        CustomMenuJson = menuButtonGroup.TryToJson(),
                        DeleteMark = false,
                        EnabledMark = true
                    });

                    return new Tuple<bool, string>(true, "����΢�Ų˵��ɹ���");
                }
            }
            else
            {
                return new Tuple<bool, string>(false, "�Զ���˵�����ʧ�ܣ�δ�ҵ�΢����Ȩ��Ϣ");
            }
        }

        #endregion
    }
}
