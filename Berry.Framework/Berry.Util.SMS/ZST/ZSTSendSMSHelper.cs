using System;
using System.Net;
using System.Text;
using Berry.Extension;

namespace Berry.Util.SMS.ZST
{
    /// <summary>
    /// 掌上通发送短信、彩信帮助类
    /// </summary>
    public sealed class ZSTSendSMSHelper
    {
        private static HttpHelper httpHelper = new HttpHelper();

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="Msisdn">接收号码，多个用逗号隔开，非空。eg：13900000000,13300000000</param>
        /// <param name="SMSContent">短信内容，非空。长度不能超过500字符，超出返回失败信息。</param>
        /// <param name="MSGType">短信类型，默认值为5。</param>
        /// <param name="LongCode">扩展码</param>
        /// <para>MSGType取值范围：</para>
        /// <para>1：ShortSMS，单条短信。对于超过70个字符的(也可能不等于70个字符，试通道而定)，自动截断。</para>
        /// <para>2：LongSMSNoPageNum，分割短信。对于超过70字符的(也可能不等于70个字符，试通道而定)，自动分割成多条短信，但无页码标识。</para>
        /// <para>3：LongSMSWithPageNum，分割短信。对于超过70字符的(也可能不等于70个字符，试通道而定)，自动分割，同时加上页码标识。eg：(1/3)</para>
        /// <para>5：LongSMS，长短信。</para>
        public ZSTSMSResultModel SendSMS(string Msisdn, string SMSContent, int MSGType = 5, string LongCode = "")
        {
            ZSTSMSResultModel data = new ZSTSMSResultModel();

            //对短信内容进行编码
            string content = StringHelper.UrlEncode(SMSContent, Encoding.GetEncoding("GB2312"));
            //参数校验
            if (string.IsNullOrEmpty(Msisdn)) return null;
            if (string.IsNullOrEmpty(SMSContent)) return null;
            //组装参数
            string para = string.Format("ececcid={0}&password={1}&msisdn={2}&smscontent={3}&msgtype={4}&longcode={5}", ZSTSMSConfig.ZST_ECECCID, ZSTSMSConfig.ZST_PASSWORD, Msisdn, content, MSGType, LongCode);
            HttpItem item = new HttpItem
            {
                Url = ZSTSMSConfig.API_SEND_SMS_URL_UTF8,
                Method = "POST",
                Postdata = para,
                PostDataType = PostDataType.String,
                ContentType = "application/x-www-form-urlencoded",
                PostEncoding = Encoding.UTF8,
                Encoding = Encoding.UTF8
            };
            HttpResult result = httpHelper.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                //请求返回结果
                string res = result.Html;
                //格式化返回结果
                data = FormatData(res);
            }

            return data;
        }

        #region 私有方法
        /// <summary>
        /// 格式化返回结果
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private ZSTSMSResultModel FormatData(string source)
        {
            if (string.IsNullOrEmpty(source)) return null;

            ZSTSMSResultModel result = new ZSTSMSResultModel();
            string[] arr = source.Split("|".ToCharArray());
            if (arr.Length == 3)
            {
                bool isSucc = Enum.TryParse(arr[0], false, out ZSTSMSErrorCode code);
                if (isSucc)
                {
                    result.Status = code;
                    result.MsgId = arr[1];
                    result.Description = arr[2];
                }
            }
            return result;
        }

        #endregion
    }
}