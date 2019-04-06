#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SY.HL7.Parser
* 项目描述 ：
* 类 名 称 ：ASD_Z07
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：SY.HL7.Parser
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/6 23:35:07
* 更新时间 ：2019/3/6 23:35:07
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
    /// 功能描述    ：签约  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/6 23:35:07 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/6 23:35:07 
    /// </summary>
    public class ASD_Z07 : MSH
    {
        public ASD_Z07()
        {
            this.Root = "/ASD_Z07/";
        }

        #region PID

        /// <summary>
        /// 个人档案标识符
        /// </summary>
        [HL7Filed("CX.1", "PID/PID.2/CX.1", "个人档案标识符")]
        public string PID_2_CX_1 { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [HL7Filed("CX.1", "PID/PID.3/CX.1", "身份证号")]
        public string PID_3_CX_1 { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        [HL7Filed("XPN.2", "PID/PID.5/XPN.2", "患者姓名")]
        public string PID_5_XPN_2 { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [HL7Filed("PID.7", "PID/PID.7", "出生日期")]
        public string PID_7 { get; set; }
        /// <summary>
        /// 性别。A-未知的性别 M-男 F-女 U-未说明的性别
        /// </summary>
        [HL7Filed("PID.8", "PID/PID.8", "性别")]
        public string PID_8 { get; set; }
        /// <summary>
        /// 街道地址
        /// </summary>
        [HL7Filed("ST.1", "PID/PID.11/SAD.1/ST.1", "街道地址")]
        public string PID_11_SAD_1_ST_1 { get; set; }
        /// <summary>
        /// 居委会名称
        /// </summary>
        [HL7Filed("XAD.8", "PID/PID.11/XAD.8", "居委会名称")]
        public string PID_11_XAD_8 { get; set; }
        /// <summary>
        /// 居委会ID
        /// </summary>
        [HL7Filed("XAD.9", "PID/PID.11/XAD.9", "居委会ID")]
        public string PID_11_XAD_9 { get; set; }
        /// <summary>
        /// 本人电话
        /// </summary>
        [HL7Filed("XTN.1", "PID/PID.13/XTN.1", "本人电话")]
        public string PID_13_XTN_1 { get; set; }
        /// <summary>
        /// 婚姻状况编码。1-未婚 2-已婚 3-丧偶 4-离婚 5-未说明的婚姻状况
        /// </summary>
        [HL7Filed("CWE.1", "PID/PID.16/CWE.1", "婚姻状况编码")]
        public string PID_16_CWE_1 { get; set; }
        /// <summary>
        /// 民族编码
        /// </summary>
        [HL7Filed("CWE.1", "PID/PID.28/CWE.1", "民族编码")]
        public string PID_28_CWE_1 { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        [HL7Filed("CWE.2", "PID/PID.28/CWE.2", "民族")]
        public string PID_28_CWE_2 { get; set; }

        #endregion

        #region Z07.1

        /// <summary>
        /// 协议编号
        /// </summary>
        [HL7Filed("XX.1", "Z07/Z07.1/XX.1", "协议编号")]
        public string Z07_Z07_1_XX_1 { get; set; }
        /// <summary>
        /// 签约时间
        /// </summary>
        [HL7Filed("XX.2", "Z07/Z07.1/XX.2", "签约时间")]
        public string Z07_Z07_1_XX_2 { get; set; }
        /// <summary>
        /// 服务开始时间
        /// </summary>
        [HL7Filed("XX.3", "Z07/Z07.1/XX.3", "服务开始时间")]
        public string Z07_Z07_1_XX_3 { get; set; }
        /// <summary>
        /// 服务结束时间
        /// </summary>
        [HL7Filed("XX.4", "Z07/Z07.1/XX.4", "服务结束时间")]
        public string Z07_Z07_1_XX_4 { get; set; }
        /// <summary>
        /// 签约医生名称
        /// </summary>
        [HL7Filed("XX.5", "Z07/Z07.1/XX.5", "签约医生名称")]
        public string Z07_Z07_1_XX_5 { get; set; }
        /// <summary>
        /// 签约医生身份证号
        /// </summary>
        [HL7Filed("XX.6", "Z07/Z07.1/XX.6", "签约医生身份证号")]
        public string Z07_Z07_1_XX_6 { get; set; }
        /// <summary>
        /// 签约团队名称
        /// </summary>
        [HL7Filed("XX.7", "Z07/Z07.1/XX.7", "签约团队名称")]
        public string Z07_Z07_1_XX_7 { get; set; }
        /// <summary>
        /// 签约团队编号
        /// </summary>
        [HL7Filed("XX.8", "Z07/Z07.1/XX.8", "签约团队编号")]
        public string Z07_Z07_1_XX_8 { get; set; }

        #endregion

        #region Z07.2

        /// <summary>
        /// 签约档案服务包信息
        /// </summary>
        [HL7Filed("", "Z07/Z07.2", "签约档案服务包信息", IsArray = true)]
        public List<ASD_Z07_Z07_2> Z07_2_List { get; set; }

        #endregion
    }

    /// <summary>
    /// 签约档案服务包信息明细
    /// </summary>
    public class ASD_Z07_Z07_2 : IHL7ArrayItem
    {
        /// <summary>
        /// 协议编号
        /// </summary>
        [HL7Filed("XX.1", "Z07/Z07.2/XX.1", "协议编号")]
        public string Z07_Z07_2_XX_1 { get; set; }
        /// <summary>
        /// 签约时间
        /// </summary>
        [HL7Filed("XX.2", "Z07/Z07.2/XX.2", "签约时间")]
        public string Z07_Z07_2_XX_2 { get; set; }
        /// <summary>
        /// 服务开始时间
        /// </summary>
        [HL7Filed("XX.3", "Z07/Z07.2/XX.3", "服务开始时间")]
        public string Z07_Z07_2_XX_3 { get; set; }
        /// <summary>
        /// 服务结束时间
        /// </summary>
        [HL7Filed("XX.4", "Z07/Z07.2/XX.4", "服务结束时间")]
        public string Z07_Z07_2_XX_4 { get; set; }
        /// <summary>
        /// 签约医生名称
        /// </summary>
        [HL7Filed("XX.5", "Z07/Z07.2/XX.5", "签约医生名称")]
        public string Z07_Z07_2_XX_5 { get; set; }
        /// <summary>
        /// 签约医生身份证号
        /// </summary>
        [HL7Filed("XX.6", "Z07/Z07.2/XX.6", "签约医生身份证号")]
        public string Z07_Z07_2_XX_6 { get; set; }
        /// <summary>
        /// 签约团队名称
        /// </summary>
        [HL7Filed("XX.7", "Z07/Z07.2/XX.7", "签约团队名称")]
        public string Z07_Z07_2_XX_7 { get; set; }
        /// <summary>
        /// 签约团队编号
        /// </summary>
        [HL7Filed("XX.8", "Z07/Z07.2/XX.8", "签约团队编号")]
        public string Z07_Z07_2_XX_8 { get; set; }
    }
}
