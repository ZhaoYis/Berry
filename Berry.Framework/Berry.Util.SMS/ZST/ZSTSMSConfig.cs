namespace Berry.Util.SMS.ZST
{
    /// <summary>
    /// 掌上通短信平台配置
    /// </summary>
    public static class ZSTSMSConfig
    {
        /// <summary>
        /// 接入账户。必需
        /// </summary>
        public const long ZST_ECECCID = 0;
        /// <summary>
        /// 接入密码。必需
        /// </summary>
        public const string ZST_PASSWORD = "";

        /// <summary>
        /// WebService地址
        /// </summary>
        public const string ZST_API_WEBSERVICE_URL = "http://pi.f3.cn/F3WebService.asmx";

        /// <summary>
        /// 短信接口地址，UTF-8编码
        /// </summary>
        public const string API_SEND_SMS_URL_UTF8 = "http://pi.noc.cn/SendSMS.aspx";
        /// <summary>
        /// 短信接口地址，GB2312编码
        /// </summary>
        public const string API_SEND_SMS_URL_GB2312 = "http://pi.noc.cn/SendSMSGB2312.aspx";

        /// <summary>
        /// 彩信接口地址，UTF-8编码
        /// </summary>
        public const string API_SEND_MMS_URL_UTF8 = "http://pi.noc.cn/SendMMS.aspx";
        /// <summary>
        /// 彩信接口地址，GB2312编码
        /// </summary>
        public const string API_SEND_MMS_URL_GB2312 = "http://pi.noc.cn/SendMMSGB2312.aspx";

        /// <summary>
        /// 查询余量
        /// <para>每次查询时间间隔需要大于30秒，否则返回失败状态。</para>
        /// </summary>
        public const string API_QUERY_AMOUNT_URL = "http://pi.noc.cn/QueryAmount.aspx";

    }
}