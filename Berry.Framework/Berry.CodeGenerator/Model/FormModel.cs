namespace Berry.CodeGenerator.Model
{
    /// <summary>
    /// 表单信息
    /// </summary>
    public class FormModel
    {
        /// <summary>
        /// 显示类型（一列、二列）
        /// </summary>
        public int? FormType { get; set; }
        /// <summary>
        /// 表单宽度
        /// </summary>
        public int? width { get; set; }
        /// <summary>
        /// 表单高度
        /// </summary>
        public int? height { get; set; }
    }
}
