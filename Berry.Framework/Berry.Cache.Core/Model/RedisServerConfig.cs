using System.Collections.Generic;
using Berry.Extension;
using Berry.Util;

namespace Berry.Cache.Core.Model
{
    public class RedisServerConfig
    {
        public static List<RedisServerModel> RedisServers { get; set; }

        public static string ConfigPath = "XmlConfig/RedisServiceConfig.json";

        static RedisServerConfig()
        {
            LoadConfig();
        }

        public static void LoadConfig()
        {
            ConfigPath = DirFileHelper.MapPath(ConfigPath);

            string context = DirFileHelper.ReadAllText(ConfigPath);
            RedisServers = context.JsonToList<RedisServerModel>();
        }
    }
}