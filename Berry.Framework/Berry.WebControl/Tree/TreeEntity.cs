namespace Berry.WebControl.Tree
{
    /// <summary>
    /// 树实体
    /// </summary>
    public class TreeEntity
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
        /// 节点描述
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 选中状态
        /// </summary>
        public int? checkstate { get; set; }

        /// <summary>
        /// 是否显示选择框
        /// </summary>
        public bool showcheck { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool complete { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool isexpand { get; set; }

        /// <summary>
        /// 是否有子节点
        /// </summary>
        public bool hasChildren { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string img { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int? Level { get; set; }

        /// <summary>
        /// 自定义属性
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// 自定义属性值
        /// </summary>
        public string AttributeValue { get; set; }

        /// <summary>
        /// 自定义属性A
        /// </summary>
        public string AttributeA { get; set; }

        /// <summary>
        /// 自定义属性值A
        /// </summary>
        public string AttributeValueA { get; set; }
    }
}