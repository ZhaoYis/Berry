#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.MsgService.Base
* 项目描述 ：
* 类 名 称 ：IBMWMQConfig
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.MsgService.Base
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/7 11:44:16
* 更新时间 ：2019/3/7 11:44:16
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using Berry.Extension;
using Berry.Util;

namespace Berry.MQ.IBMMQ
{
    /// <summary>
    /// 功能描述    ：IBMWMQConfig  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/7 11:44:16 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/7 11:44:16 
    /// </summary>
    public class IBMWMQConfig
    {
        /// <summary>
        /// CLIENT_ID
        /// </summary>
        private const string CLIENT_ID = "CDJG_APP";

        /// <summary>
        /// 初始化
        /// </summary>
        static IBMWMQConfig()
        {
            string isDebug = ConfigHelper.GetValue("IsDebug").ToLower();
            if (isDebug.Equals("true"))
            {
                CONNECTION_HOST = ConfigHelper.GetValue("IBM_WMQ_CONNECTION_HOST_DEBUG");
                CONNECTION_PORT = ConfigHelper.GetValue("IBM_WMQ_CONNECTION_PORT_DEBUG").TryToInt32();
                CHANNEL = ConfigHelper.GetValue("IBM_WMQ_CHANNEL_NAME_DEBUG");
                QUEUE_MGR_NAME = ConfigHelper.GetValue("IBM_WMQ_QUEUE_MGR_NAME_DEBUG");
            }
            else
            {
                CONNECTION_HOST = ConfigHelper.GetValue("IBM_WMQ_CONNECTION_HOST");
                CONNECTION_PORT = ConfigHelper.GetValue("IBM_WMQ_CONNECTION_PORT").TryToInt32();
                CHANNEL = ConfigHelper.GetValue("IBM_WMQ_CHANNEL_NAME");
                QUEUE_MGR_NAME = ConfigHelper.GetValue("IBM_WMQ_QUEUE_MGR_NAME");
            }

            CONNECTION_INFO = string.Format("{0}({1})", CONNECTION_HOST, CONNECTION_PORT);
            SUBSCRIPTION_TEMPLATE = "JMS:" + QUEUE_MGR_NAME + ":" + CLIENT_ID + "_{0}.REQ:{0}.REQ";
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
        /// 通道名称
        /// </summary>
        public static string CHANNEL { get; private set; }

        /// <summary>
        /// 队列管理器名称
        /// </summary>
        public static string QUEUE_MGR_NAME { get; private set; }

        /// <summary>
        /// 订阅主题持久化标识，{0}标识具体业务
        /// </summary>
        public static string SUBSCRIPTION_TEMPLATE { get; private set; }

        /// <summary>
        /// IBM.WMQ连接字符串
        /// </summary>
        public static string CONNECTION_INFO { get; private set; }

        /// <summary>
        /// 主题名称模板，{0}标识具体业务
        /// </summary>
        public static string TOPIC_TEMPLATE
        {
            get { return "{0}.REQ"; }
        }

        #region 业务代码定义

        /// <summary>
        /// 签约申请。ZSDZ07
        /// </summary>
        public const string BUSINESS_NAME_ZSDZ07 = "ZSDZ07";
        /// <summary>
        /// 签约申请。ZSD_Z07
        /// </summary>
        public const string BUSINESS_NAME_ZSD_Z07 = "ZSD_Z07";

        /// <summary>
        /// 随访。
        /// </summary>
        public const string BUSINESS_NAME_ZDFZ09 = "ZDFZ09";
        /// <summary>
        /// 随访。ZDF_Z09
        /// </summary>
        public const string BUSINESS_NAME_ZDF_Z09 = "ZDF_Z09";

        /// <summary>
        /// 年检。ZAPZ10
        /// </summary>
        public const string BUSINESS_NAME_ZAPZ10 = "ZAPZ10";
        /// <summary>
        /// 年检。ZAP_Z10
        /// </summary>
        public const string BUSINESS_NAME_ZAP_Z10 = "ZAP_Z10";

        /// <summary>
        /// 检验。OULR24
        /// </summary>
        public const string BUSINESS_NAME_OULR24 = "OULR24";
        /// <summary>
        /// 检验。OUL_R24
        /// </summary>
        public const string BUSINESS_NAME_OUL_R24 = "OUL_R24";

        /// <summary>
        /// 体征数据回传。SIIZ12
        /// </summary>
        public const string BUSINESS_NAME_SIIZ12 = "SIIZ12";
        /// <summary>
        /// 体征数据回传。SII_Z12
        /// </summary>
        public const string BUSINESS_NAME_SII_Z12 = "SII_Z12";
        #endregion
    }
}
