namespace Berry.Code
{
    /// <summary>
    /// 全局公共静态编码
    /// </summary>
    public sealed class GlobalConstCode
    {
        #region 正则表达式
        /// <summary>
        /// 匹配Body
        /// </summary>
        private const string RegBody = @"<body[^>]*>([\s\S]*)<\/body>";
        /// <summary>
        /// 匹配Script标签
        /// </summary>
        private const string RegScript = @"<script[^>]*?>[\s\S]*?<\/script>";
        /// <summary>
        /// 匹配Style标签
        /// </summary>
        private const string RegStyle = @"<style[^>]*?>[\s\S]*?<\/style>";
        /// <summary>
        /// 匹配NoScript标签
        /// </summary>
        private const string RegNoScript = @"<noscript[^>]*?>[\s\S]*?<\/noscript>";
        /// <summary>
        /// 匹配页面注释
        /// </summary>
        private const string RegNotes = @"<!--[\w\W\r\n]*?-->";
        /// <summary>
        /// 匹配class标签
        /// </summary>
        private const string RegClassTag = @"(class|CLASS)='[\s\S]*?'";
        /// <summary>
        /// 匹配id标签
        /// </summary>
        private const string RegIdTag = @"(id|ID)='[\s\S]*?'";
        /// <summary>
        /// 匹配Style标签
        /// </summary>
        private const string RegStyleTag = @"(style|STYLE)='[\s\S]*?'";
        /// <summary>
        /// 匹配onclick特性
        /// </summary>
        private const string RegOnclickTag = @"(onclick|ONCLICK)='[\s\S]*?'";
        #endregion 正则表达式
    }
}