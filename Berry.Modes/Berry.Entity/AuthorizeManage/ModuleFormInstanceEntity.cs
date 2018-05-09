using Berry.Util;
using System.ComponentModel.DataAnnotations.Schema;

namespace Berry.Entity.AuthorizeManage
{
    /// <summary>
    /// 系统表单实例
    /// </summary>
    [Table("Base_ModuleFormInstance")]
    public class ModuleFormInstanceEntity : BaseEntity
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
        /// 表单主键
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// 表单实例Json
        /// </summary>
        public string FormInstanceJson { get; set; }

        /// <summary>
        /// 对象主键
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}