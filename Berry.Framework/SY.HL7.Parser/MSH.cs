#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SY.HL7.Parser
* 项目描述 ：
* 类 名 称 ：MSH
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：SY.HL7.Parser
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/6 23:34:34
* 更新时间 ：2019/3/6 23:34:34
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SY.HL7.Parser.Base;

namespace SY.HL7.Parser
{
    /// <summary>
    /// 功能描述    ：MSH  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/6 23:34:34 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/6 23:34:34 
    /// </summary>
    public class MSH : BaseEntity
    {
        /// <summary>
        /// 字段分隔符
        /// </summary>
        [HL7Filed("MSH.1", "MSH/MSH.1", "字段分隔符")]
        public string MSH_1 { get; set; }
        /// <summary>
        /// 字符编码集
        /// </summary>
        [HL7Filed("MSH.2", "MSH/MSH.2", "字符编码集")]
        public string MSH_2 { get; set; }
        /// <summary>
        /// 发送应用程序
        /// </summary>
        [HL7Filed("HD.1", "MSH/MSH.3/HD.1", "发送应用程序")]
        public string MSH_3_HD_1 { get; set; }
        /// <summary>
        /// 发送设备
        /// </summary>
        [HL7Filed("HD.1", "MSH/MSH.4/HD.1", "发送设备")]
        public string MSH_4_HD_1 { get; set; }
        /// <summary>
        /// 接收应用程序
        /// </summary>
        [HL7Filed("HD.1", "MSH/MSH.5/HD.1", "接收应用程序")]
        public string MSH_5_HD_1 { get; set; }
        /// <summary>
        /// 接收设备
        /// </summary>
        [HL7Filed("HD.1", "MSH/MSH.6/HD.1", "接收设备")]
        public string MSH_6_HD_1 { get; set; }
        /// <summary>
        /// 消息的日期时间
        /// </summary>
        [HL7Filed("MSH.7", "MSH/MSH.7", "消息的日期时间")]
        public string MSH_7 { get; set; }
        /// <summary>
        /// 安全码
        /// </summary>
        [HL7Filed("MSH.8", "MSH/MSH.8", "安全码")]
        public string MSH_8 { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        [HL7Filed("MSG.1", "MSH/MSH.9/MSG.1", "交易代码")]
        public string MSH_9_MSG_1 { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        [HL7Filed("MSG.2", "MSH/MSH.9/MSG.2", "交易代码")]
        public string MSH_9_MSG_2 { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        [HL7Filed("MSG.3", "MSH/MSH.9/MSG.3", "交易代码")]
        public string MSH_9_MSG_3 { get; set; }
        /// <summary>
        /// 信息控制ID
        /// </summary>
        [HL7Filed("MSH.10", "MSH/MSH.10", "信息控制ID")]
        public string MSH_10 { get; set; }
        /// <summary>
        /// 处理ID
        /// </summary>
        [HL7Filed("PT.1", "MSH/MSH.11/PT.1", "处理ID")]
        public string MSH_11_PT_1 { get; set; }
        /// <summary>
        /// 版本ID
        /// </summary>
        [HL7Filed("VID.1", "MSH/MSH.12/VID.1", "版本ID")]
        public string MSH_12_VID_1 { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        [HL7Filed("MSH.13", "MSH/MSH.13", "序列号")]
        public string MSH_13 { get; set; }
        /// <summary>
        /// 发送负责组织
        /// </summary>
        [HL7Filed("MSH.22", "MSH/MSH.22", "发送负责组织")]
        public string MSH_22 { get; set; }
    }
}
