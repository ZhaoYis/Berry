#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.MQ.ActiveMQ
* 项目描述 ：
* 类 名 称 ：ActiveMQConfig
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.MQ.ActiveMQ
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/30 21:59:33
* 更新时间 ：2019/3/30 21:59:33
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using Berry.Extension;
using Berry.Util;

namespace Berry.MQ.ActiveMQ
{
    /// <summary>
    /// 功能描述    ：ActiveMQ配置信息
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/30 21:59:33 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/30 21:59:33 
    /// </summary>
    public class ActiveMQConfig
    {
        /// <summary>
        /// CLIENT_ID
        /// </summary>
        public const string CLIENT_ID = "";
        /// <summary>
        /// 帐号
        /// </summary>
        public const string MQ_ACCOUNT = "";
        /// <summary>
        /// 密码
        /// </summary>
        public const string MQ_PWD = "";

        /// <summary>
        /// 初始化
        /// </summary>
        static ActiveMQConfig()
        {
            string isDebug = ConfigHelper.GetValue("IsDebug").ToLower();
            if (isDebug.Equals("true"))
            {
                CONNECTION_HOST = ConfigHelper.GetValue("ActiveMQ_CONNECTION_HOST_DEBUG");
                CONNECTION_PORT = ConfigHelper.GetValue("ActiveMQ_CONNECTION_PORT_DEBUG").TryToInt32();
            }
            else
            {
                CONNECTION_HOST = ConfigHelper.GetValue("ActiveMQ_CONNECTION_HOST");
                CONNECTION_PORT = ConfigHelper.GetValue("ActiveMQ_CONNECTION_PORT").TryToInt32();
            }

            CONNECTION_INFO = string.Format("tcp://{0}:{1}/", CONNECTION_HOST, CONNECTION_PORT);
        }

        /// <summary>
        /// MQ主机地址
        /// </summary>
        private static string CONNECTION_HOST { get; set; }

        /// <summary>
        /// 通讯端口
        /// </summary>
        private static int CONNECTION_PORT { get; set; }

        /// <summary>
        /// MQ连接字符串
        /// </summary>
        public static string CONNECTION_INFO { get; private set; }

        /// <summary>
        /// 筛选器
        /// </summary>
        public static string ACTIVEMQ_SELECTOR
        {
            get { return "filter='demo'"; }
        }
    }
}
