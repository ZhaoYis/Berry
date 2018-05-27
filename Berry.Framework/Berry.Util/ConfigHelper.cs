using System.Configuration;

namespace Berry.Util
{
    /// <summary>
    /// 配置文件操作帮助类
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            //Data Source=101.200.33.46;database=LottomatBaseDB;uid=sa;pwd=zhaoyi18284594619;
            string reg = @"Data Source=(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)";
            if (StringHelper.QuickValidate(reg, name))
                return name;

            string res = ConfigurationManager.ConnectionStrings[name].ConnectionString.ToString();

            return res;
        }

        /// <summary>
        /// 根据Key获取配置值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            string res = ConfigurationManager.AppSettings[key].ToString();

            return res;
        }

        /// <summary>
        /// 获取配置文件节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static T GetSection<T>(string sectionName) where T : class, new()
        {
            T res = ConfigurationManager.GetSection(sectionName) as T;

            return res;
        }
    }
}