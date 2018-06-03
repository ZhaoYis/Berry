namespace Berry.CodeGenerator.Model
{
    /// <summary>
    /// 表格字段信息
    /// </summary>
    public class GridColumnModel
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 字段Id
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public string width { get; set; }
        /// <summary>
        /// 显示位置
        /// </summary>
        public string align { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool hidden { get; set; }
        /// <summary>
        /// 是否排序
        /// </summary>
        public bool sortable { get; set; }
        /// <summary>
        /// 格式化
        /// </summary>
        public string formatter { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string datatype { get; set; }
        /// <summary>
        /// 是否允许为空
        /// </summary>
        public string isnullable { get; set; }
    }
}
