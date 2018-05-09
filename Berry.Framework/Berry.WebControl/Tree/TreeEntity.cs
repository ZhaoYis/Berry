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
        public string ParentId { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 节点描述
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 选中状态
        /// </summary>
        public int? Checkstate { get; set; }

        /// <summary>
        /// 是否显示选择框
        /// </summary>
        public bool Showcheck { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Complete { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool Isexpand { get; set; }

        /// <summary>
        /// 是否有子节点
        /// </summary>
        public bool HasChildren { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }

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