using Berry.Util;
using System.ComponentModel.DataAnnotations.Schema;

namespace Berry.Entity.AuthorizeManage
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    [Table("Base_ModuleButton")]
    public class ModuleButtonEntity : BaseEntity
    {
        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = CommonHelper.GetGuid().ToString();
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

        /// <summary>
        /// 功能主键
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Action地址
        /// </summary>
        public string ActionAddress { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }
    }
}