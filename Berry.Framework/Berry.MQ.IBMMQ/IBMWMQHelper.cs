#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.MsgService.Base
* 项目描述 ：
* 类 名 称 ：SubIBMMQTopicHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.MsgService.Base
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/7 11:43:04
* 更新时间 ：2019/3/7 11:43:04
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using Mmqi;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace Berry.MQ.IBMMQ
{
    /// <summary>
    /// 功能描述    ：IBMMQ帮助类
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/7 11:43:04 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/7 11:43:04 
    /// </summary>
    public class IBMWMQHelper
    {
        private ConcurrentDictionary<string, MQSubscription> mqSubscriptions = new ConcurrentDictionary<string, MQSubscription>();

        private static readonly object _lock = new object();

        private IIBMWMQMsgHandler _msgHandler;

        public IBMWMQHelper()
        {
            _msgHandler = new DefaultIBMWMQMsgHandler();
        }

        public IBMWMQHelper(IIBMWMQMsgHandler msgHandler)
        {
            _msgHandler = msgHandler;
        }

        /// <summary>
        /// 订阅签约申请
        /// </summary>
        /// <returns></returns>
        public string SUB_ZSD_Z07()
        {
            lock (_lock)
            {
                string msg = this.SubTopic(IBMWMQConfig.BUSINESS_NAME_ZSDZ07);
                return this.RemoveMsgHeader(msg, IBMWMQConfig.BUSINESS_NAME_ZSD_Z07);
            }
        }

        /// <summary>
        /// 订阅随访申请
        /// </summary>
        /// <returns></returns>
        public string SUB_ZDF_Z09()
        {
            lock (_lock)
            {
                string msg = this.SubTopic(IBMWMQConfig.BUSINESS_NAME_ZDFZ09);
                return this.RemoveMsgHeader(msg, IBMWMQConfig.BUSINESS_NAME_ZDF_Z09);
            }
        }

        /// <summary>
        /// 订阅年检申请
        /// </summary>
        /// <returns></returns>
        public string SUB_ZAP_Z10()
        {
            lock (_lock)
            {
                string msg = this.SubTopic(IBMWMQConfig.BUSINESS_NAME_ZAPZ10);
                return this.RemoveMsgHeader(msg, IBMWMQConfig.BUSINESS_NAME_ZAP_Z10);
            }
        }

        /// <summary>
        /// 订阅检验申请
        /// </summary>
        /// <returns></returns>
        public string SUB_OUL_R24()
        {
            lock (_lock)
            {
                string msg = this.SubTopic(IBMWMQConfig.BUSINESS_NAME_OULR24);
                return this.RemoveMsgHeader(msg, IBMWMQConfig.BUSINESS_NAME_OUL_R24);
            }
        }

        /// <summary>
        /// 订阅主题。订阅一次并获取消息
        /// </summary>
        /// <returns></returns>
        private string SubTopic(string business)
        {
            string message = string.Empty;
            MQSubscription subs = null;
            try
            {
                using (var mqmgr = MQQueueManager.Connect(IBMWMQConfig.QUEUE_MGR_NAME, MQC.MQCO_NONE, IBMWMQConfig.CHANNEL, IBMWMQConfig.CONNECTION_INFO))
                {
                    subs = new MQSubscription(mqmgr);
                    if (mqmgr.IsConnected)
                    {
                        int option = MQC.MQSO_CREATE + MQC.MQSO_RESUME + MQC.MQSO_NON_DURABLE + MQC.MQSO_MANAGED + MQC.MQSO_FAIL_IF_QUIESCING;
                        string subName = string.Format(IBMWMQConfig.SUBSCRIPTION_TEMPLATE, business);
                        string topicName = string.Format(IBMWMQConfig.TOPIC_TEMPLATE, business);

                        subs.Subscribe(subName, option, topicName);

                        MQMessage incoming = new MQMessage();
                        MQGetMessageOptions gmo = new MQGetMessageOptions();
                        gmo.WaitInterval = 10 * 1000; //MQC.MQWI_UNLIMITED;
                        gmo.Options |= MQC.MQGMO_WAIT;
                        gmo.Options |= MQC.MQGMO_SYNCPOINT;

                        subs.Get(incoming, gmo);
                        message = incoming.ReadAll();

                        this.TryAdd(business, subs);
                    }
                }
            }
            catch (MQException e)
            {
                message = e.Reason.ToString();
            }
            finally
            {
                if (subs != null)
                {
                    subs.Close(MQC.MQCO_REMOVE_SUB, closeSubQueue: true, closeSubQueueOptions: MQC.MQCO_NONE);
                }
            }
            return message;
        }

        /// <summary>
        /// 订阅主题。订阅一次并尝试一直获取消息
        /// </summary>
        public void SubTopic1(string business, bool isGetMsg = true)
        {
            IBMWMQEventSource eventSource = new IBMWMQEventSource();
            IBMWMQMsgEventListener msgEventListener = new IBMWMQMsgEventListener(_msgHandler);
            MQSubscription subs = null;
            try
            {
                //订阅事件
                msgEventListener.Subscribe(eventSource);
                //MQEnvironment.CCSID = 1381;

                using (var mqmgr = MQQueueManager.Connect(IBMWMQConfig.QUEUE_MGR_NAME, MQC.MQCO_NONE, IBMWMQConfig.CHANNEL, IBMWMQConfig.CONNECTION_INFO))
                {
                    subs = new MQSubscription(mqmgr);
                    if (mqmgr.IsConnected)
                    {
                        this.TryAdd(business, subs);

                        int option = MQC.MQSO_CREATE + MQC.MQSO_RESUME + MQC.MQSO_NON_DURABLE + MQC.MQSO_MANAGED + MQC.MQSO_FAIL_IF_QUIESCING;
                        string subName = string.Format(IBMWMQConfig.SUBSCRIPTION_TEMPLATE, business);
                        string topicName = string.Format(IBMWMQConfig.TOPIC_TEMPLATE, business);

                        try
                        {
                            subs.Subscribe(subName, option, topicName);
                        }
                        catch (MQException ex)
                        {
                            string code = ex.Reason.ToString();
                            //引发事件
                            eventSource.RaiseErroeMsgEvent(business, code);
                        }

                        while (isGetMsg)
                        {
                            eventSource.RaiseErroeMsgEvent(business, string.Format("开始尝试获取 {0} 消息...", business));
                            try
                            {
                                MQMessage incoming = new MQMessage()
                                {
                                    CharacterSet = MQC.CODESET_UTF,
                                    Encoding = MQC.MQENC_NORMAL
                                };
                                MQGetMessageOptions gmo = new MQGetMessageOptions();
                                gmo.WaitInterval = 10 * 1000; //MQC.MQWI_UNLIMITED;
                                gmo.Options |= MQC.MQGMO_WAIT;
                                gmo.Options |= MQC.MQGMO_SYNCPOINT;

                                subs.Get(incoming, gmo);
                                string message = incoming.ReadAll();

                                if (!string.IsNullOrEmpty(message))
                                {
                                    //引发事件
                                    eventSource.RaiseNewMsgEvent(business, message);
                                }
                            }
                            catch (MQException ex)
                            {
                                string code = ex.Reason.ToString();
                                //引发事件
                                eventSource.RaiseErroeMsgEvent(business, code);
                            }
                        }
                    }
                }
            }
            catch (MQException e)
            {
                string code = e.Reason.ToString();
                //引发事件
                eventSource.RaiseErroeMsgEvent(business, code);
            }
            finally
            {
                //if (subs != null)
                //{
                //    subs.Close(MQC.MQCO_REMOVE_SUB, closeSubQueue: true, closeSubQueueOptions: MQC.MQCO_NONE);
                //}
            }
        }

        /// <summary>
        /// 获取队列消息
        /// </summary>
        private string GetQueueMsg(string business)
        {
            string message = string.Empty;
            try
            {
                string queueName = string.Format(IBMWMQConfig.TOPIC_TEMPLATE, business);
                using (var mqmgr = MQQueueManager.Connect(IBMWMQConfig.QUEUE_MGR_NAME, MQC.MQCO_NONE, IBMWMQConfig.CHANNEL, IBMWMQConfig.CONNECTION_INFO))
                using (var q = mqmgr.AccessQueue(queueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING))
                {
                    var incoming = new MQMessage();
                    MQGetMessageOptions gmo = new MQGetMessageOptions();
                    gmo.WaitInterval = 10 * 1000; //MQC.MQWI_UNLIMITED;
                    gmo.Options |= MQC.MQGMO_WAIT;
                    gmo.Options |= MQC.MQGMO_SYNCPOINT;
                    q.Get(incoming, gmo);

                    message = incoming.ReadString(incoming.DataLength);
                }
            }
            catch (MQException e)
            {
                message = e.Reason.ToString();
            }
            return message;
        }

        /// <summary>
        /// 向消息队列推送一条消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="queueName">队列名称</param>
        public void PushMsgToQueue(string msg, string queueName)
        {
            try
            {
                using (var mqmgr = MQQueueManager.Connect(IBMWMQConfig.QUEUE_MGR_NAME, MQC.MQCO_NONE, IBMWMQConfig.CHANNEL, IBMWMQConfig.CONNECTION_INFO))
                using (var q = new MQQueue(mqmgr, queueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING))
                {
                    var outgoing = new MQMessage()
                    {
                        CharacterSet = MQC.CODESET_UTF,
                        Encoding = MQC.MQENC_NORMAL
                    };
                    outgoing.WriteString(msg);
                    q.Put(outgoing, new MQPutMessageOptions());
                }
            }
            catch (MQException e)
            {
                Trace.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 向消息队列推送一条消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="queueName">队列名称</param>
        public void PushMsgToQueue1(string msg, string queueName)
        {
            try
            {
                using (var mqmgr = MQQueueManager.Connect(IBMWMQConfig.QUEUE_MGR_NAME, MQC.MQCO_NONE, IBMWMQConfig.CHANNEL, IBMWMQConfig.CONNECTION_INFO))
                {
                    if (mqmgr.IsConnected)
                    {
                        var outgoing = new MQMessage()
                        {
                            CharacterSet = MQC.CODESET_UTF,
                            Encoding = MQC.MQENC_NORMAL
                        };
                        outgoing.WriteString(msg);

                        var od = new MQObjectDescriptor
                        {
                            ObjectType = MQC.MQOT_Q,
                            ObjectName = queueName
                        };
                        mqmgr.Put1(od, outgoing, new MQPutMessageOptions());
                    }
                }
            }
            catch (MQException e)
            {
                Trace.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 去掉消息头
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string RemoveMsgHeader(string msg, string name)
        {
            msg = msg.Trim();

            //去掉消息头
            int index = msg.IndexOf("<" + name, StringComparison.Ordinal);
            if (index > 0)
            {
                string temp = msg.Substring(0, index);
                msg = msg.Substring(index, msg.Length - temp.Length);
                msg = msg.Trim();
            }

            return msg;
        }

        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subscription"></param>
        private void TryAdd(string key, MQSubscription subscription)
        {
            mqSubscriptions.AddOrUpdate(key, subscription, (k, v) => subscription);
        }

        /// <summary>
        /// 停止订阅消息
        /// </summary>
        public void StopAllSub()
        {
            foreach (KeyValuePair<string, MQSubscription> pair in mqSubscriptions)
            {
                pair.Value.Close(MQC.MQCO_REMOVE_SUB, closeSubQueue: true, closeSubQueueOptions: MQC.MQCO_NONE);
            }
        }
    }
}
