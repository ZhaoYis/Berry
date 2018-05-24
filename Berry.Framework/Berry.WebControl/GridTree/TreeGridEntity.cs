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
        public string parentId { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 实体Json字符串
        /// </summary>
        public string entityJson { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool expanded { get; set; }

        /// <summary>
        /// 是否含有子节点
        /// </summary>
        public bool hasChildren { get; set; }
    }
}