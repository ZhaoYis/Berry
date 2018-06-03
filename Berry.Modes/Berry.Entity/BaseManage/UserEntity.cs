using Berry.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Berry.Entity.BaseManage
{
    /// <summary>
    /// 用户实体
    /// </summary>
    [Table("Base_User")]
    [Serializable]
    public class UserEntity : BaseEntity
    {
        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = CommonHelper.GetGuid().ToString();
            this.CreateDate = DateTime.Now;
            //this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            //this.CreateUserName = OperatorProvider.Provider.Current().UserName;
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
            //this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            //this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }

        #endregion 扩展操作
        
        /// <summary>
        /// 用户编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 登录账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 密码秘钥
        /// </summary>
        public string Secretkey { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 呢称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadIcon { get; set; }

        /// <summary>
        /// 快速查询
        /// </summary>
        public string QuickQuery { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        public string SimpleSpelling { get; set; }

        /// <summary>
        /// 性别 1-男 2-女 3-未知
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// QQ号
        /// </summary>
        public string OICQ { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WeChat { get; set; }

        /// <summary>
        /// MSN
        /// </summary>
        public string MSN { get; set; }

        /// <summary>
        /// 主管主键
        /// </summary>
        public string ManagerId { get; set; }

        /// <summary>
        /// 主管
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// 机构主键
        /// </summary>
        public string OrganizeId { get; set; }

        /// <summary>
        /// 部门主键
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// 角色主键
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 岗位主键
        /// </summary>
        public string DutyId { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        public string DutyName { get; set; }

        /// <summary>
        /// 职位主键
        /// </summary>
        public string PostId { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        public string PostName { get; set; }

        /// <summary>
        /// 工作组主键
        /// </summary>
        public string WorkGroupId { get; set; }

        /// <summary>
        /// 安全级别
        /// </summary>
        public int? SecurityLevel { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public int? UserOnLine { get; set; }

        /// <summary>
        /// 单点登录标识
        /// </summary>
        public int? OpenId { get; set; }

        /// <summary>
        /// 密码提示问题
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// 密码提示答案
        /// </summary>
        public string AnswerQuestion { get; set; }

        /// <summary>
        /// 允许多用户同时登录
        /// </summary>
        public int? CheckOnLine { get; set; }

        /// <summary>
        /// 允许登录时间开始
        /// </summary>
        public DateTime? AllowStartTime { get; set; }

        /// <summary>
        /// 允许登录时间结束
        /// </summary>
        public DateTime? AllowEndTime { get; set; }

        /// <summary>
        /// 暂停用户开始日期
        /// </summary>
        public DateTime? LockStartDate { get; set; }

        /// <summary>
        /// 暂停用户结束日期
        /// </summary>
        public DateTime? LockEndDate { get; set; }

        /// <summary>
        /// 第一次访问时间
        /// </summary>
        public DateTime? FirstVisit { get; set; }

        /// <summary>
        /// 上一次访问时间
        /// </summary>
        public DateTime? PreviousVisit { get; set; }

        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime? LastVisit { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LogOnCount { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public bool DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public bool EnabledMark { get; set; }

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
    
    ///// <summary>
    ///// 实体对象映射关系  
    ///// </summary>
    //[Serializable]
    //public sealed class UserMap : ClassMapper<UserEntity>
    //{
    //    public UserMap()
    //    {
    //        base.Table("Base_User");
    //        Map(f => f.PK).Ignore();//设置忽略
    //        Map(f => f.Id).Key(KeyType.NotAKey);//设置主键  (如果主键名称不包含字母“ID”，请设置)      
    //        this.AutoMap();
    //    }
    //}
}