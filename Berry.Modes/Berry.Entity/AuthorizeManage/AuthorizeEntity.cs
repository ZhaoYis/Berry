using Berry.Code.Operator;
using Berry.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Berry.Entity.AuthorizeManage
{
    /// <summary>
    /// 授权功能
    /// </summary>
    [Table("Base_Authorize")]
    public class AuthorizeEntity : BaseEntity
    {
        #region 扩展操作

        public override void Create()
        {
            this.Id = CommonHelper.GetGuid();
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
        }

        #endregion 扩展操作

        /// <summary>
        /// 对象分类:1-部门 2-角色 3-岗位 4-职位 5-工作组
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// 对象主键
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// 项目类型:1-菜单 2-按钮 3-视图 4-表单
        /// </summary>
        public int ItemType { get; set; }

        /// <summary>
        /// 项目主键
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 创建时间
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
    }
}