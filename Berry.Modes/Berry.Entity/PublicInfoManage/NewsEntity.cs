using System;
using System.ComponentModel.DataAnnotations.Schema;
using Berry.Code.Operator;
using Berry.Util;

namespace Berry.Entity.PublicInfoManage
{
    /// <summary>
    /// 新闻中心
    /// </summary>
    [Table("Base_News")]
    public class NewsEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 类型（1-新闻2-公告）
        /// </summary>		
        public int? TypeId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>		
        public string ParentId { get; set; }
        /// <summary>
        /// 所属类别
        /// </summary>		
        public string Category { get; set; }
        /// <summary>
        /// 所属类别Id
        /// </summary>		
        public string CategoryId { get; set; }
        /// <summary>
        /// 完整标题
        /// </summary>		
        public string FullHead { get; set; }
        /// <summary>
        /// 标题颜色
        /// </summary>		
        public string FullHeadColor { get; set; }
        /// <summary>
        /// 简略标题
        /// </summary>		
        public string BriefHead { get; set; }
        /// <summary>
        /// 作者
        /// </summary>		
        public string AuthorName { get; set; }
        /// <summary>
        /// 编辑
        /// </summary>		
        public string CompileName { get; set; }
        /// <summary>
        /// Tag词
        /// </summary>		
        public string TagWord { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>		
        public string Keyword { get; set; }
        /// <summary>
        /// 来源
        /// </summary>		
        public string SourceName { get; set; }
        /// <summary>
        /// 来源地址
        /// </summary>		
        public string SourceAddress { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>		
        public string NewsContent { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>		
        public int? PV { get; set; }
        ///// <summary>
        ///// 评论数
        ///// </summary>
        //public int? CommentingNum { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>		
        public DateTime? ReleaseTime { get; set; }
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
        /// <summary>
        /// 是否热门
        /// </summary>
        public bool? IsHot { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool? IsStick { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool? IsRecommend { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = CommonHelper.GetGuid().ToString();
            this.CreateDate = DateTimeHelper.Now;
            this.ReleaseTime = DateTimeHelper.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.DeleteMark = false;
            this.EnabledMark = true;
            this.PV = 0;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Id = keyValue;
            this.ModifyDate = DateTimeHelper.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}
