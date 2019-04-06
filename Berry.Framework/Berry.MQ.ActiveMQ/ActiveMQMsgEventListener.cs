#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.MQ.IBMMQ
* 项目描述 ：
* 类 名 称 ：IBMWMQMsgEventListener
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.MQ.IBMMQ
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/23 11:25:33
* 更新时间 ：2019/3/23 11:25:33
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

namespace Berry.MQ.ActiveMQ
{
    /// <summary>
    /// 功能描述    ：事件监听器  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/23 11:25:33 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/23 11:25:33 
    /// </summary>
    public class ActiveMQMsgEventListener
    {
        private readonly IActiveMQMsgHandler _msgHandler;

        public ActiveMQMsgEventListener(IActiveMQMsgHandler msgHandler)
        {
            _msgHandler = msgHandler;
        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        public void Subscribe(ActiveMQEventSource eventSource)
        {
            eventSource.NewMsgEventHandler += _msgHandler.OnNewMsgHandler;
            eventSource.ErrorMsgEventHandler += _msgHandler.OnErrorMsgHandler;
        }

        /// <summary>
        /// 取消订阅事件
        /// </summary>
        public void UnSubscribe(ActiveMQEventSource eventSource)
        {
            eventSource.NewMsgEventHandler -= _msgHandler.OnNewMsgHandler;
            eventSource.ErrorMsgEventHandler -= _msgHandler.OnErrorMsgHandler;
        }
    }
}
