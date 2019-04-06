#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.MQ.ActiveMQ
* 项目描述 ：
* 类 名 称 ：DefaultActiveMQMsgHandler
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.MQ.ActiveMQ
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/30 23:25:39
* 更新时间 ：2019/3/30 23:25:39
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System.Diagnostics;

namespace Berry.MQ.ActiveMQ
{
    /// <summary>
    /// 功能描述    ：默认消息处理器  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/30 23:25:39 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/30 23:25:39 
    /// </summary>
    public class DefaultActiveMQMsgHandler : IActiveMQMsgHandler
    {
        /// <summary>
        /// 处理新消息
        /// </summary>
        /// <param name="business">业务代码</param>
        /// <param name="msg">消息包</param>
        public void OnNewMsgHandler(string business, string msg)
        {
            Trace.WriteLine(string.Format("新消息到达，数据包：{0}", msg));
        }

        /// <summary>
        /// 处理错误消息
        /// </summary>
        /// <param name="business">业务代码</param>
        /// <param name="errorCode">错误码</param>
        public void OnErrorMsgHandler(string business, string errorCode)
        {
            Trace.WriteLine(string.Format("处理错误消息，错误码：{0}", errorCode));
        }
    }
}
