using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Berry.Util
{
    /// <summary>
    /// 验证工具
    /// </summary>
    public class ValidateHelper
    {
        #region 正则表达式通用验证方法

        /// <summary>
        /// 正则表达式通用验证方法
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <param name="parrtern">正则表达式</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool Validate(string input, string parrtern)
        {
            return Regex.IsMatch(input, parrtern);
        }

        #endregion 正则表达式通用验证方法

        #region 检查该字符串是否由数字和字母组成

        /// <summary>
        /// 检查该字符串是否由字母和数字组成
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsEnglishAndNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^[A-Za-z0-9]+$");
        }

        #endregion 检查该字符串是否由数字和字母组成

        #region 检查该字符串是否全部由小写字母组成

        /// <summary>
        /// 检查该字符串是否全部由小写字母组成
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsEnglishLower(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^[a-z]+$");
        }

        #endregion 检查该字符串是否全部由小写字母组成

        #region 检查该字符串是否全部由大写字母组成

        /// <summary>
        /// 检查该字符串是否全部由大写字母组成
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsEnglishUpper(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^[A-Z]+$");
        }

        #endregion 检查该字符串是否全部由大写字母组成

        #region 检查该字符串是否全部由字母组成（不区分大小写）

        /// <summary>
        /// 检查该字符串是否全部由字母组成（不区分大小写）
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsEnglish(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        #endregion 检查该字符串是否全部由字母组成（不区分大小写）

        #region 检查该字符串是否全部由汉字，英数，以及下划线组成

        /// <summary>
        /// 检查该字符串是否全部由中文组成
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsUserID(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return (Regex.IsMatch(input, @"^[a-zA-Z0-9_\u4e00-\u9fa5]+$"));
        }

        #endregion 检查该字符串是否全部由汉字，英数，以及下划线组成

        #region 检查该字符串是否全部由中文组成

        /// <summary>
        /// 检查该字符串是否全部由中文组成
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsChinese(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return (Regex.IsMatch(input, "^([\u4e00-\u9fa5]|[\ufe30-\uffa0])+$"));
        }

        #endregion 检查该字符串是否全部由中文组成

        #region 检查该字符串是否符合电子邮件地址格式

        /// <summary>
        /// 检查该字符串是否符合电子邮件地址格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsEmail(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return (Regex.IsMatch(input, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"));
        }

        #endregion 检查该字符串是否符合电子邮件地址格式

        #region 检查该字符串是否符合URL地址格式

        /// <summary>
        /// 检查该字符串是否符合URL地址格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsUrl(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^(http[s]{0,1}|ftp):\/\/[A-Za-z0-9\./=\?%\-&_~`@[\]\':+!]+([^<>""])+$");
        }

        #endregion 检查该字符串是否符合URL地址格式

        #region 检查该字符串是否符合电话号码格式

        /// <summary>
        /// 检查该字符串是否符合电话号码格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsTelNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$");
        }

        #endregion 检查该字符串是否符合电话号码格式

        #region 检查该字符串是否符合手机号码格式（移动、联通、电信）

        /// <summary>
        /// 检查该字符串是否符合手机号码格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsMobileNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^(13)\d{9}$|^(15[^4])\d{8}$|^(18[^1234])\d{8}$");
        }

        #region 检查该字符串是否符合中国移动的手机号码格式

        /// <summary>
        /// 检查该字符串是否符合中国移动的手机号码格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsChinaMobile(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^(13[^0123])\d{8}$|^(15[01789])\d{8}$|^(18[78])\d{8}$");
        }

        #endregion 检查该字符串是否符合中国移动的手机号码格式

        #region 检查该字符串是否符合中国联通的手机号码格式

        /// <summary>
        /// 检查该字符串是否符合中国联通的手机号码格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsChinaUnicom(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^(13[0123])\d{8}$|^(15[2356])\d{8}$|^(18[56])\d{8}$");
        }

        #endregion 检查该字符串是否符合中国联通的手机号码格式

        #region 检查该字符串是否符合中国电信的手机号码格式

        /// <summary>
        /// 检查该字符串是否符合中国电信的手机号码格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsChinaTelecom(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^18[09]\d{8}$");
        }

        #endregion 检查该字符串是否符合中国电信的手机号码格式

        #endregion 检查该字符串是否符合手机号码格式（移动、联通、电信）

        #region 检查该字符串是否符合有效的身份证号码格式

        /// <summary>
        /// 检查该字符串是否符合有效的身份证号码格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsIDCard(string input)
        {
            DateTime birthday;
            return IsIDCard(input, out birthday);
        }

        /// <summary>
        /// 检查该字符串是否符合有效的身份证号码格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <param name="birthday">身份证标识的生日</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsIDCard(string input, out DateTime birthday)
        {
            birthday = DateTime.MinValue;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            string date, ai;
            var verify = "10x98765432";
            var wi = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            var area = new string[] { "", "", "", "", "", "", "", "", "", "", "", "北京", "天津", "河北", "山西", "内蒙古",
                                      "", "", "", "", "", "辽宁", "吉林", "黑龙江", "", "", "", "", "", "", "", "上海", "江苏",
                                      "浙江", "安微", "福建", "江西", "山东", "", "", "", "河南", "湖北", "湖南", "广东", "广西",
                                      "海南", "", "", "", "重庆", "四川", "贵州", "云南", "西藏", "", "", "", "", "", "", "陕西",
                                      "甘肃", "青海", "宁夏", "新疆", "", "", "", "", "", "台湾", "", "", "", "", "", "", "", "",
                                      "", "香港", "澳门", "", "", "", "", "", "", "", "", "国外" };
            var re = Regex.Match(input, @"^(\d{2})\d{4}(((\d{2})(\d{2})(\d{2})(\d{3}))|((\d{4})(\d{2})(\d{2})(\d{3}[xX\d])))$");

            if (re.Length == 0)
            {
                return false;
            }

            if (int.Parse(re.Result("$1")) >= area.Length || string.IsNullOrWhiteSpace(area[int.Parse(re.Result("$1"))]))
            {
                return false;
            }

            if (re.Result("$2").Length == 12)
            {
                ai = input.Substring(0, 17);
                date = string.Format("{0}-{1}-{2}", re.Result("$9"), re.Result("$10"), re.Result("$11"));
            }
            else
            {
                ai = input.Substring(0, 6) + "19" + input.Substring(6);
                date = string.Format("19{0}-{1}-{2}", re.Result("$4"), re.Result("$5"), re.Result("$6"));
            }

            if (!IsDateTime(date))
            {
                return false;
            }

            var sum = 0;

            for (int i = 0; i <= 16; i++)
            {
                sum += int.Parse(ai.Substring(i, 1)) * wi[i];
            }

            ai += verify.Substring(sum % 11, 1);
            var result = (input.Length == 15 || input.Length == 18 && input == ai);

            if (result)
            {
                birthday = DateTime.Parse(date);
                return true;
            }

            return false;
        }

        #endregion 检查该字符串是否符合有效的身份证号码格式

        #region 检查该字符串是否符合IP地址格式

        /// <summary>
        /// 检查该字符串是否符合IP地址格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsIP4(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$");
        }

        #endregion 检查该字符串是否符合IP地址格式

        #region 检查该字符串是否是数字

        /// <summary>
        /// 检查该字符串是否是数字
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^-?[0-9]+$");
        }

        #endregion 检查该字符串是否是数字

        #region 检查该字符串是否是 byte 类型

        /// <summary>
        /// 检查该字符串是否是 byte 类型
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsByte(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            byte result;
            return byte.TryParse(input, out result);
        }

        #endregion 检查该字符串是否是 byte 类型

        #region 检查该字符串是否是 int 类型

        /// <summary>
        /// 检查该字符串是否是 int 类型
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsInteger(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            int result;
            return int.TryParse(input, out result);
        }

        #endregion 检查该字符串是否是 int 类型

        #region 检查该字符串是否是 decimal 类型

        /// <summary>
        /// 检查该字符串是否是 decimal 类型
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsDecimal(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            decimal result;
            return decimal.TryParse(input, out result);
        }

        #endregion 检查该字符串是否是 decimal 类型

        #region 检查该字符串是否是 double 类型

        /// <summary>
        /// 检查该字符串是否是 double 类型
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsDouble(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            double result;
            return double.TryParse(input, out result);
        }

        #endregion 检查该字符串是否是 double 类型

        #region 检查该字符串是否是有效的时间格式

        /// <summary>
        /// 检查该字符串是否是有效的时间格式
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsDateTime(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            DateTime dateTime;
            return DateTime.TryParse(input, out dateTime);
        }

        #endregion 检查该字符串是否是有效的时间格式

        #region 检查该字符串是否以指定的格式来表示年月日

        /// <summary>
        /// 检查该字符串是否以指定的格式来表示年月日
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <param name="format">指定的格式</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsDateTime(string input, string format)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            DateTime dateTime;
            return DateTime.TryParseExact(input, format, null, DateTimeStyles.None, out dateTime);
        }

        #endregion 检查该字符串是否以指定的格式来表示年月日

        #region 检查该字符串是否以"20080101"这样的格式来表示年月日

        /// <summary>
        /// 检查该字符串是否以"20080101"这样的格式来表示年月日
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsDateTime8Bit(string input)
        {
            return IsDateTime(input, "yyyyMMdd");
        }

        #endregion 检查该字符串是否以"20080101"这样的格式来表示年月日

        #region 检查该字符串是否是 Guid 类型

        /// <summary>
        /// 检查该字符串是否是 Guid 类型
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsGuid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            Guid result;
            return Guid.TryParse(input, out result);
        }

        #endregion 检查该字符串是否是 Guid 类型

        #region 检查该字符串是否是HTML标志对

        /// <summary>
        /// 检查该字符串是否是HTML标志对
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <returns>验证结果（true：验证成功，false：验证失败）</returns>
        public static bool IsHTMLTag(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"<(.*)>.*<\/\1>|<(.*) \/>|<(.*)\/>");
        }

        #endregion 检查该字符串是否是HTML标志对
    }
}