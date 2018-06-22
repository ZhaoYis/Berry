namespace Berry.Code
{
    /// <summary>
    /// 全局公共静态编码
    /// </summary>
    public sealed class GlobalConstCode
    {
        #region 正则表达式

        #region Html标签相关
        /// <summary>
        /// 匹配Body
        /// </summary>
        public const string RegBody = @"<body[^>]*>([\s\S]*)<\/body>";
        /// <summary>
        /// 匹配Script标签
        /// </summary>
        public const string RegScript = @"<script[^>]*?>[\s\S]*?<\/script>";
        /// <summary>
        /// 匹配Style标签
        /// </summary>
        public const string RegStyle = @"<style[^>]*?>[\s\S]*?<\/style>";
        /// <summary>
        /// 匹配NoScript标签
        /// </summary>
        public const string RegNoScript = @"<noscript[^>]*?>[\s\S]*?<\/noscript>";
        /// <summary>
        /// 匹配页面注释
        /// </summary>
        public const string RegNotes = @"<!--[\w\W\r\n]*?-->";
        /// <summary>
        /// 匹配class标签
        /// </summary>
        public const string RegClassTag = @"(class|CLASS)='[\s\S]*?'";
        /// <summary>
        /// 匹配id标签
        /// </summary>
        public const string RegIdTag = @"(id|ID)='[\s\S]*?'";
        /// <summary>
        /// 匹配Style标签
        /// </summary>
        public const string RegStyleTag = @"(style|STYLE)='[\s\S]*?'";
        /// <summary>
        /// 匹配onclick特性
        /// </summary>
        public const string RegOnclickTag = @"(onclick|ONCLICK)='[\s\S]*?'";
        /// <summary>
        /// 匹配标签
        /// </summary>
        public const string RegImgTag = @"<(img|IMG).*src=(.*?)[^>]*?>";
        #endregion

        #region 常用数据验证
        /// <summary>
        /// 手机验证码
        /// </summary>
        public const string RegTelePhone = @"^(\+86|0|86|17951)?(13[0-9]|14[57]|15[012356789]|17[678]|18[0-9]|19[0-9])[0-9]{8}$";
        /// <summary>
        /// 身份证号码
        /// </summary>
        public const string RegIdCardNo = @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
        /// <summary>
        /// 中文或者英文数字组合
        /// </summary>
        public const string RegName = @"^[\u4e00-\u9fa5|A-Za-z0-9_]+$";
        /// <summary>
        /// 数字
        /// </summary>
        public const string RegNumber = @"^[0-9]+$";
        /// <summary>
        /// 英文字母
        /// </summary>
        public const string RegEnLetter = @"^[a-zA-Z]+$";
        /// <summary>
        /// 汉字
        /// </summary>
        public const string RegCnLetter = @"^[\u4e00-\u9fa5]+$";
        /// <summary>
        /// 字母和数字组合
        /// </summary>
        public const string RegEnLetterAndNumber = @"^[a-zA-Z0-9]+$";

        #endregion

        #endregion 正则表达式

        #region 系统Api接口相关

        /// <summary>
        /// 获取Token服务器地址
        /// </summary>
        public const string GET_TOKTN_URL = "/api/v1/OAuth/GetToken?appkey={0}&appsecret={1}";

        /// <summary>
        /// Tkoen过期时间，单位：小时
        /// </summary>
        public const int TOKEN_EXPIRE_TIME = 2;

        /// <summary>
        /// 无需请求签名信息的Action方法
        /// </summary>
        public static readonly string[] NOT_NEED_DIGITAL_SIGNATURE = { "GetToken", "Login" };
        #endregion
    }
}