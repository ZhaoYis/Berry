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
    /// 版 本：V1.0.0
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2019-01-10 14:55
    /// 描 述：微信配置
    /// </summary>
    public class WechatConfigBLL : BaseBLL<WechatConfigEntity>, IWechatConfigBLL
    {
        private IWechatConfigService service = new WechatConfigService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<WechatConfigEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<WechatConfigEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public WechatConfigEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        /// <summary>
        /// 根据机构ID获取授权信息
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public WechatConfigEntity GetEntityByOrgId(string orgId)
        {
            return service.GetEntityByOrgId(orgId);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            service.RemoveForm(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, WechatConfigEntity entity)
        {
            service.SaveForm(keyValue, entity);
        }

        /// <summary>
        /// 添加自定义菜单
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
