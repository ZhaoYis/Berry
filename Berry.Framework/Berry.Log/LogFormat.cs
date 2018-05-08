using System.Text;

namespace Berry.Log
{
    /// <summary>
    /// 日志格式器
    /// </summary>
    public class LogFormat
    {
        /// <summary>
        /// 生成错误
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string ErrorFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("1. 错误: >> 操作时间: " + logMessage.OperationTime + "   操作人: " + logMessage.UserName + " \r\n");
            strInfo.Append("2. 地址: " + logMessage.Url + "    \r\n");
            strInfo.Append("3. 类名: " + logMessage.Class + " \r\n");
            strInfo.Append("4. Ip  : " + logMessage.Ip + "   主机: " + logMessage.Host + "   浏览器: " + logMessage.Browser + "    \r\n");
            strInfo.Append("5. 内容: " + logMessage.Content + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }

        /// <summary>
        /// 生成警告
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string WarnFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("1. 警告: >> 操作时间: " + logMessage.OperationTime + "   操作人: " + logMessage.UserName + " \r\n");
            strInfo.Append("2. 地址: " + logMessage.Url + "    \r\n");
            strInfo.Append("3. 类名: " + logMessage.Class + " \r\n");
            strInfo.Append("4. Ip  : " + logMessage.Ip + "   主机: " + logMessage.Host + "   浏览器: " + logMessage.Browser + "    \r\n");
            strInfo.Append("5. 内容: " + logMessage.Content + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }

        /// <summary>
        /// 生成信息
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string InfoFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("1. 信息: >> 操作时间: " + logMessage.OperationTime + "   操作人: " + logMessage.UserName + " \r\n");
            strInfo.Append("2. 地址: " + logMessage.Url + "    \r\n");
            strInfo.Append("3. 类名: " + logMessage.Class + " \r\n");
            strInfo.Append("4. Ip  : " + logMessage.Ip + "   主机: " + logMessage.Host + "   浏览器: " + logMessage.Browser + "    \r\n");
            strInfo.Append("5. 内容: " + logMessage.Content + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }

        /// <summary>
        /// 生成调试
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string DebugFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("1. 调试: >> 操作时间: " + logMessage.OperationTime + "   操作人: " + logMessage.UserName + " \r\n");
            strInfo.Append("2. 地址: " + logMessage.Url + "    \r\n");
            strInfo.Append("3. 类名: " + logMessage.Class + " \r\n");
            strInfo.Append("4. Ip  : " + logMessage.Ip + "   主机: " + logMessage.Host + "   浏览器: " + logMessage.Browser + "    \r\n");
            strInfo.Append("5. 内容: " + logMessage.Content + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }

        /// <summary>
        /// 生成异常信息
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string ExceptionFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("1. 调试: >> 操作时间: " + logMessage.OperationTime + "   描述: " + logMessage.Content + " \r\n");
            strInfo.Append("2. 地址: " + logMessage.Url + "    \r\n");
            strInfo.Append("3. 类名: " + logMessage.Class + " \r\n");
            strInfo.Append("4. 主机: " + logMessage.Host + "   Ip  : " + logMessage.Ip + "   浏览器: " + logMessage.Browser + "    \r\n");
            strInfo.Append("5. 异常: " + logMessage.ExceptionInfo + "\r\n");
            strInfo.Append("6. 来源: " + logMessage.ExceptionSource + "\r\n");
            strInfo.Append("7. 实例: " + logMessage.ExceptionRemark + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }
    }
}