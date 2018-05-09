namespace Berry.Entity.ViewModel
{
    /// <summary>
    /// 数据字典分类明细
    /// </summary>
    public class DataItemViewModel
    {
        /// <summary>
        /// 分类主键
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 明细主键
        /// </summary>
        public string ItemDetailId { get; set; }

        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 项目名
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 项目值
        /// </summary>
        public string ItemValue { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        public string SimpleSpelling { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public bool EnabledMark { get; set; }
    }
}