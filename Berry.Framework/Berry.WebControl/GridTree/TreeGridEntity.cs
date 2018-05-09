namespace Berry.WebControl.GridTree
{
    /// <summary>
    /// 树表格实体
    /// </summary>
    public class TreeGridEntity
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 实体Json字符串
        /// </summary>
        public string EntityJson { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool Expanded { get; set; }

        /// <summary>
        /// 是否含有子节点
        /// </summary>
        public bool HasChildren { get; set; }
    }
}