using Berry.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Berry.Entity.SystemManage
{
    /// <summary>
    /// 系统日志
    /// </summary>
    [Table("Base_Log")]
    public class LogEntity : BaseEntity
    {
        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = CommonHelper.GetGuid().ToString();
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
        }

        #endregion 扩展操作

        #region 实体成员

        /// <summary>
        /// 分类Id 1-登陆2-访问3-操作4-异常
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// 来源对象主键
        /// </summary>
        public string SourceObjectId { get; set; }

        /// <summary>
        /// 来源日志内容
        /// </summary>
        public string SourceContentJson { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperateTime { get; set; }

        /// <summary>
        /// 操作用户Id
        /// </summary>
        public string OperateUserId { get; set; }

        /// <summary>
        /// 操作用户
        /// </summary>
        public string OperateAccount { get; set; }

        /// <summary>
        /// 操作类型Id
        /// </summary>
        public string OperateTypeId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperateType { get; set; }

        /// <summary>
        /// 系统功能主键
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// 系统功能
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// IP地址所在城市
        /// </summary>
        public string IPAddressName { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 执行结果状态
        /// </summary>
        public int? ExecuteResult { get; set; }

        /// <summary>
        /// 执行结果信息
        /// </summary>
        public string ExecuteResultJson { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public bool DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public bool EnabledMark { get; set; }

        #endregion 实体成员
    }
}