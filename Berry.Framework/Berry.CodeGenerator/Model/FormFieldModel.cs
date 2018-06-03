namespace Berry.CodeGenerator.Model
{
    /// <summary>
    /// 表单字段信息
    /// </summary>
    public class FormFieldModel
    {
        /// <summary>
        /// 字段标识
        /// </summary>
        public string ControlId { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string ControlName { get; set; }
        /// <summary>
        /// 字段验证
        /// </summary>
        public string ControlValidator { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string ControlType { get; set; }
        /// <summary>
        /// 合并列
        /// </summary>
        public int? ControlColspan { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string ControlDefault { get; set; }
    }
}
