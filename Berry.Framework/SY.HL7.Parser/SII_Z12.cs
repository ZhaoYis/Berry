#region << 版 本 注 释 >>
/*
* 项目名称 ：SY.HL7.Parser
* 项目描述 ：
* 类 名 称 ：SII_Z12
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：SY.HL7.Parser
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-03-21 16:03:32
* 更新时间 ：2019-03-21 16:03:32
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using SY.HL7.Parser.Base;
using SY.HL7.Parser.Properties;
using SY.HL7.Parser.Tools;
using System;

namespace SY.HL7.Parser
{
    /// <summary>
    /// 功能描述    ：体征数据  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-03-21 16:03:32 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-03-21 16:03:32 
    /// </summary>
    public class SII_Z12 : MSH
    {
        public SII_Z12()
        {
            this.Root = "/SII_Z12/";
            this.MSH_1 = "|";
            this.MSH_2 = @"^~\&amp;";
            this.MSH_3_HD_1 = "";
            this.MSH_4_HD_1 = "";
            this.MSH_7 = DateTime.UtcNow.ToString("yyyyMMddHHmmss.fff") + "+0800";
            this.MSH_10 = "";
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
        /// 性别。A-未知的性别 M-男 F-女 U-未说明的性别
        /// </summary>
        [HL7Filed("PID.8", "PID/PID.8", "性别")]
        public string PID_8 { get; set; }
        /// <summary>
        /// 本人电话
        /// </summary>
        [HL7Filed("XTN.1", "PID/PID.13/XTN.1", "本人电话")]
        public string PID_13_XTN_1 { get; set; }

        #endregion

        #region PV1

        /// <summary>
        /// 挂号号
        /// </summary>
        [HL7Filed("PV1.2", "PV1/PV1.2", "挂号号")]
        public string PV1_PV1_2 { get; set; }
        /// <summary>
        /// 临床科室ID
        /// </summary>
        [HL7Filed("PL.1", "PV1/PV1.3/PL.1", "临床科室ID")]
        public string PV1_PV1_3_PL_1 { get; set; }
        /// <summary>
        /// 临床科室
        /// </summary>
        [HL7Filed("PL.2", "PV1/PV1.3/PL.2", "临床科室")]
        public string PV1_PV1_3_PL_2 { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        [HL7Filed("XCN.1", "PV1/PV1.7/XCN.1", "医生ID")]
        public string PV1_PV1_7_XCN_1 { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        [HL7Filed("FN.1", "PV1/PV1.7/XCN.3/FN.1", "医生姓名")]
        public string PV1_PV1_7_XCN_3_FN_1 { get; set; }
        /// <summary>
        /// 接诊日期
        /// </summary>
        [HL7Filed("PV1.44", "PV1/PV1.44", "接诊日期")]
        public string PV1_PV1_44 { get; set; }

        #endregion

        #region Z12

        /// <summary>
        /// 餐后血糖
        /// </summary>
        [HL7Filed("XX.1", "Z12/Z12.1/XX.1", "餐后血糖")]
        public string Z12_Z12_1_XX_1 { get; set; }
        /// <summary>
        /// 空腹血糖
        /// </summary>
        [HL7Filed("XX.2", "Z12/Z12.1/XX.2", "空腹血糖")]
        public string Z12_Z12_1_XX_2 { get; set; }
        /// <summary>
        /// 随机血糖
        /// </summary>
        [HL7Filed("XX.3", "Z12/Z12.1/XX.3", "随机血糖")]
        public string Z12_Z12_1_XX_3 { get; set; }
        /// <summary>
        /// 监测时间
        /// </summary>
        [HL7Filed("XX.5", "Z12/Z12.1/XX.5", "监测时间")]
        public string Z12_Z12_1_XX_5 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [HL7Filed("XX.6", "Z12/Z12.1/XX.6", "单位")]
        public string Z12_Z12_1_XX_6 { get; set; }
        /// <summary>
        /// 早餐前血糖
        /// </summary>
        [HL7Filed("XX.8", "Z12/Z12.1/XX.8", "早餐前血糖")]
        public string Z12_Z12_1_XX_8 { get; set; }
        /// <summary>
        /// 早餐后血糖
        /// </summary>
        [HL7Filed("XX.9", "Z12/Z12.1/XX.9", "早餐后血糖")]
        public string Z12_Z12_1_XX_9 { get; set; }
        /// <summary>
        /// 午餐前血糖
        /// </summary>
        [HL7Filed("XX.10", "Z12/Z12.1/XX.10", "午餐前血糖")]
        public string Z12_Z12_1_XX_10 { get; set; }
        /// <summary>
        /// 午餐后血糖
        /// </summary>
        [HL7Filed("XX.11", "Z12/Z12.1/XX.11", "午餐后血糖")]
        public string Z12_Z12_1_XX_11 { get; set; }
        /// <summary>
        /// 晚餐前血糖
        /// </summary>
        [HL7Filed("XX.12", "Z12/Z12.1/XX.12", "晚餐前血糖")]
        public string Z12_Z12_1_XX_12 { get; set; }
        /// <summary>
        /// 晚餐后血糖
        /// </summary>
        [HL7Filed("XX.13", "Z12/Z12.1/XX.13", "晚餐后血糖")]
        public string Z12_Z12_1_XX_13 { get; set; }
        /// <summary>
        /// 睡前血糖
        /// </summary>
        [HL7Filed("XX.14", "Z12/Z12.1/XX.14", "睡前血糖")]
        public string Z12_Z12_1_XX_14 { get; set; }
        /// <summary>
        /// 凌晨血糖
        /// </summary>
        [HL7Filed("XX.15", "Z12/Z12.1/XX.15", "凌晨血糖")]
        public string Z12_Z12_1_XX_15 { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        [HL7Filed("XX.1", "Z12/Z12.2/XX.1", "收缩压")]
        public string Z12_Z12_2_XX_1 { get; set; }
        /// <summary>
        /// 舒张压
        /// </summary>
        [HL7Filed("XX.2", "Z12/Z12.2/XX.2", "舒张压")]
        public string Z12_Z12_2_XX_2 { get; set; }
        /// <summary>
        /// 监测时间
        /// </summary>
        [HL7Filed("XX.5", "Z12/Z12.2/XX.5", "监测时间")]
        public string Z12_Z12_2_XX_5 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [HL7Filed("XX.6", "Z12/Z12.2/XX.6", "单位")]
        public string Z12_Z12_2_XX_6 { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [HL7Filed("XX.1", "Z12/Z12.3/XX.1", "体重")]
        public string Z12_Z12_3_XX_1 { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        [HL7Filed("XX.2", "Z12/Z12.3/XX.2", "身高")]
        public string Z12_Z12_3_XX_2 { get; set; }
        /// <summary>
        /// 监测时间
        /// </summary>
        [HL7Filed("XX.6", "Z12/Z12.3/XX.6", "监测时间")]
        public string Z12_Z12_3_XX_6 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [HL7Filed("XX.7", "Z12/Z12.3/XX.7", "单位")]
        public string Z12_Z12_3_XX_7 { get; set; }
        #endregion

        /// <summary>返回表示当前对象的字符串。</summary>
        /// <returns>表示当前对象的字符串。</returns>
        public override string ToString()
        {
            XmlHL7Parser xmlHl7Parser = new XmlHL7Parser();
            string template = Resources.SII_Z12_XML_TEMPLATE;

            string res = xmlHl7Parser.Parser<SII_Z12>(this, template);

            return res;
        }
    }
}
