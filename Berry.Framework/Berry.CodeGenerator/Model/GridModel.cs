using System.Collections.Generic;

namespace Berry.CodeGenerator.Model
{
    /// <summary>
    /// 表格信息
    /// </summary>
    public class GridModel
    {
        /// <summary>
        /// 工具栏按钮[刷新、新增、编辑、删除]
        /// </summary>
        public List<string> ButtonList { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUrl { get; set; }
        /// <summary>
        /// 是否分页
        /// </summary>
        public bool IsPage { get; set; }
        /// <summary>
        /// 显示行号
        /// </summary>
        public bool Rownumbers { get; set; }
    }
}
