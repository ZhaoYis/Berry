using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Berry.Extension
{
    /// <summary>
    /// 签名验证
    /// </summary>
    public class SignExtension
    {
        /// <summary>
        /// 校验签名
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="appkey">appkey</param>
        /// <param name="data">请求参数签名，GET请求即参数不带?、&、=符号，如id1nametest，POST请求将数据序列化成Json字符串</param>
        /// <param name="signtoken">客户端发送的Token信息</param>
        /// <param name="access_token">客户端生成的数字签名字符串，用于和服务器生成得签名进行对比</param>
        /// <returns></returns>
        public static bool ValidateSign(string timeStamp, string nonce, string appkey, string signtoken, string access_token)
        {
            //拼接签名数据
            string signStr = timeStamp + appkey + signtoken + nonce;
            //将字符串中字符按升序排序
            string sortStr = string.Concat(signStr.OrderBy(c => c));
            //加密
            string res = Md5(sortStr).Replace("-", "").ToUpper();

            //操作用户传来的token
            //拼接签名数据
            string signOldStr = timeStamp + appkey + access_token + nonce;
            //将字符串中字符按升序排序
            string sortOldStr = string.Concat(signOldStr.OrderBy(c => c));
            //加密
            string resOld = Md5(sortOldStr).Replace("-", "").ToUpper();

            return res == resOld;
        }

        #region MD5加密
        /// <summary>
        /// MD5加密,32位
        /// </summary>
        /// <param name="encypStr">加密字符</param>
        /// <returns></returns>
        private static string Md5(string encypStr)
        {
            StringBuilder builder = new StringBuilder();
            MD5 md5 = MD5.Create();
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(encypStr));
            foreach (byte b in s)
            {
                //将得到的字符串使用十六进制类型格式
                //X 表示大写，x 表示小写，X2和x2表示不省略首位为0的十六进制数字
                builder.Append(b.ToString("X"));
            }
            return builder.ToString();
        }
        #endregion
    }
}