#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.MQ.IBMMQ
* 项目描述 ：
* 类 名 称 ：IBMWMQMsgHandler
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.MQ.IBMMQ
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/23 11:10:07
* 更新时间 ：2019/3/23 11:10:07
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion


namespace Berry.MQ.IBMMQ
{
    /// <summary>
    /// 功能描述    ：事件中心  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/23 11:10:07 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/23 11:10:07 
    /// </summary>
    public class IBMWMQEventSource
    {
        /// <summary>
        /// 新消息处理委托
        /// </summary>
        /// <param name="business"></param>
        /// <param name="msg"></param>
        public delegate void NewMsgHandler(string business, string msg);
        /// <summary>
        /// 新消息处理事件
        /// </summary>
        public event NewMsgHandler NewMsgEventHandler;

        /// <summary>
        /// 错误消息处理委托
        /// </summary>
        /// <param name="errorCode"></param>
        public delegate void ErrorMsgHandler(string business, string errorCode);
        /// <summary>
        /// 错误消息处理事件
        /// </summary>
        public event ErrorMsgHandler ErrorMsgEventHandler;

        /// <summary>
        /// 引发新消息处理事件的方法
        /// </summary>
        /// <param name="business"></param>
        /// <param name="msg"></param>
        public void RaiseNewMsgEvent(string business, string msg)
        {
            if (NewMsgEventHandler != null)
            {
                NewMsgEventHandler.Invoke(business, msg);
            }
        }

        /// <summary>
        /// 引发错误消息处理事件的方法
        /// </summary>
        /// <param name="business"></param>
        /// <param name="errorCode"></param>
        public void RaiseErroeMsgEvent(string business, string errorCode)
        {
            if (ErrorMsgEventHandler != null)
            {
                ErrorMsgEventHandler.Invoke(business, errorCode);
            }
        }
    }
}
