using Berry.Code.Operator;
using Berry.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Berry.Entity.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    [Table("Base_Module")]
    public class ModuleEntity : BaseEntity
    {
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

        #endregion 扩展操作

        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 导航地址
        /// </summary>
        public string UrlAddress { get; set; }

        /// <summary>
        /// 导航目标
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 菜单选项
        /// </summary>
        public bool? IsMenu { get; set; }

        /// <summary>
        /// 允许展开
        /// </summary>
        public bool? AllowExpand { get; set; }

        /// <summary>
        /// 是否公开
        /// </summary>
        public bool? IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public bool? AllowDelete { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifyUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifyUserName { get; set; }
    }
}