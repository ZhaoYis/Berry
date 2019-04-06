using System;
using System.ComponentModel.DataAnnotations.Schema;
using Berry.Code;
using Berry.Code.Operator;
using Berry.Util;

namespace Berry.Entity.CustomManage
{
    /// <summary>
    /// 版 本：V1.0.0
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2019-01-10 14:55
    /// 描 述：微信配置
    /// </summary>
    [Table("Base_WechatConfig")]
    public class WechatConfigEntity : BaseEntity
    {
        #region 实体成员
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
        /// 授权域名
        /// </summary>
        /// <returns></returns>
        public string AuthDomainUrl { get; set; }
        /// <summary>
        /// 微信项目发布地址
        /// </summary>
        /// <returns></returns>
        public string WxDomainUrl { get; set; }
        /// <summary>
        /// 机构ID
        /// </summary>
        /// <returns></returns>
        public string OrganizeId { get; set; }
        /// <summary>
        /// 是否已经自定义了菜单
        /// </summary>
        public bool HasCustomMenu { get; set; }
        /// <summary>
        /// 自定义菜单JSON数据
        /// </summary>
        public string CustomMenuJson { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <returns></returns>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 启用标志
        /// </summary>
        /// <returns></returns>
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改人ID
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
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
        /// 编辑调用
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