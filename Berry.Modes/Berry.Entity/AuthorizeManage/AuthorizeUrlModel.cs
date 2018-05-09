namespace Berry.Entity.AuthorizeManage
{
    /// <summary>
    /// 授权功能Url、操作Url
    /// </summary>
    public class AuthorizeUrlModel
    {
        /// <summary>
        /// 功能主键
        /// </summary>
        public string ModuleId { set; get; }

        /// <summary>
        /// Url地址
        /// </summary>
        public string UrlAddress { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { set; get; }
    }
}