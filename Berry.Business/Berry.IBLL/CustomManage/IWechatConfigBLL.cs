using System;
using Berry.Entity.CustomManage;
using Berry.Entity.CommonEntity;
using System.Collections.Generic;

namespace Berry.IBLL.CustomManage
{
    /// <summary>
    /// 版 本：V1.0.0
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2019-01-10 14:55
    /// 描 述：微信配置
    /// </summary>
    public interface IWechatConfigBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<WechatConfigEntity> GetPageList(PaginationEntity pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<WechatConfigEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        WechatConfigEntity GetEntity(string keyValue);

        /// <summary>
        /// 根据机构ID获取授权信息
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        WechatConfigEntity GetEntityByOrgId(string orgId);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveForm(string keyValue, WechatConfigEntity entity);

        /// <summary>
        /// 添加自定义菜单
        /// </summary>
        /// <param name="json"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Tuple<bool, string> AddCustomMenu(string json, string keyValue);
        #endregion
    }
}
