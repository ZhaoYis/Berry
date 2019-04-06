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
    /// 版 本：V1.0.0
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2019-01-10 14:55
    /// 描 述：微信配置
    /// </summary>
    public class WechatConfigService : BaseService<WechatConfigEntity>, IWechatConfigService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<WechatConfigEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            IEnumerable<WechatConfigEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPageList-获取列表", () =>
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
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<WechatConfigEntity> GetList(string queryJson)
        {
            IEnumerable<WechatConfigEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPageList-获取列表", () =>
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
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public WechatConfigEntity GetEntity(string keyValue)
        {
            WechatConfigEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-获取实体", () =>
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
        /// 根据机构ID获取授权信息
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public WechatConfigEntity GetEntityByOrgId(string orgId)
        {
            WechatConfigEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntityByOrgId-根据机构ID获取授权信息", () =>
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

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveForm-删除数据", () =>
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
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, WechatConfigEntity entity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-保存表单（新增、修改）", () =>
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
        /// 添加微信自定义菜单
        /// </summary>
        public Tuple<bool, string> AddCustomMenu(string json, string keyValue)
        {
            //string orgId = ConfigHelper.GetValue("OrgId");
            WechatConfigEntity wechatConfig = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "AddCustomMenu-获取微信配置信息", () =>
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

                //是否能正确获取token检查是否输入正确
                string token = AccessTokenContainer.TryGetAccessToken(wechatConfig.AppId, wechatConfig.AppSecret);
                if (string.IsNullOrEmpty(token))
                {
                    return new Tuple<bool, string>(false, "微信认证失败，请检查微信Appid与AppSecret是否正确！");
                }

                //创建菜单
                ButtonGroup menuButtonGroup = new ButtonGroup();
                menuButtonGroup.button.Add(new SingleViewButton()
                {
                    url = baseUrl + "/home",
                    name = "首页",
                    type = "view"
                });
                menuButtonGroup.button.Add(new SingleViewButton()
                {
                    url = baseUrl + "/personage",
                    name = "个人中心",
                    type = "view"
                });

                //SubButton my = new SubButton()
                //{
                //    name = "我的"
                //};
                //my.sub_button.Add(new SingleViewButton()
                //{
                //    url = baseUrl + "Web/pages/user_center.html",
                //    name = "会员中心",
                //    type = "view"
                //});
                //menuButtonGroup.button.Add(my);

                var menuResult = CommonApi.CreateMenu(wechatConfig.AppId, menuButtonGroup);
                if (menuResult.errcode != 0)
                {
                    return new Tuple<bool, string>(false, "创建微信菜单失败，请重试！");
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

                    return new Tuple<bool, string>(true, "创建微信菜单成功！");
                }
            }
            else
            {
                return new Tuple<bool, string>(false, "自定义菜单发布失败，未找到微信授权信息");
            }
        }

        #endregion
    }
}
