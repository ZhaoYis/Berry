#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SY.HL7.Parser
* 项目描述 ：
* 类 名 称 ：OUL_R24
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：SY.HL7.Parser
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/7 21:25:30
* 更新时间 ：2019/3/7 21:25:30
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
    /// 功能描述    ：检验
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/7 21:25:30 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/7 21:25:30 
    /// </summary>
    public class OUL_R24 : MSH
    {
        public OUL_R24()
        {
            this.Root = "/OUL_R24/";
        }

        #region PID

        /// <summary>
        /// 个人档案标识符
        /// </summary>
        [HL7Filed("CX.1", "OUL_R24.PATIENT/PID/PID.2/CX.1", "个人档案标识符")]
        public string PID_2_CX_1 { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [HL7Filed("CX.1", "OUL_R24.PATIENT/PID/PID.3/CX.1", "身份证号")]
        public string PID_3_CX_1 { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        [HL7Filed("XPN.2", "OUL_R24.PATIENT/PID/PID.5/XPN.2", "患者姓名")]
        public string PID_5_XPN_2 { get; set; }
        /// <summary>
        /// 性别。A-未知的性别 M-男 F-女 U-未说明的性别
        /// </summary>
        [HL7Filed("PID.8", "OUL_R24.PATIENT/PID/PID.8", "性别")]
        public string PID_8 { get; set; }

        /// <summary>
        /// 入院类型
        /// </summary>
        [HL7Filed("PV1.4", "OUL_R24.PATIENT/OUL_R24.VISIT/PV1/PV1.4", "入院类型")]
        public string PV1_PV1_4 { get; set; }

        #endregion

        #region OBR

        /// <summary>
        /// 申请单号
        /// </summary>
        [HL7Filed("EI.1", "OUL_R24.ORDER/OBR/OBR.2/EI.1", "申请单号")]
        public string OBR_OBR_2_EI_1 { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        [HL7Filed("OBR.6", "OUL_R24.ORDER/OBR/OBR.6", "申请时间")]
        public string OBR_OBR_6 { get; set; }

        #endregion

        #region ORC

        /// <summary>
        /// 填上申请状态。0=预约 1=申请 2=登记 3=检查 4=报告5=审核 6=退费许可
        /// </summary>
        [HL7Filed("ORC.5", "OUL_R24.ORDER/ORC/ORC.5", "填上申请状态")]
        public string ORC_ORC_5 { get; set; }
        /// <summary>
        /// 检验类型。
        /// </summary>
        [HL7Filed("CWE.1", "OUL_R24.ORDER/ORC/ORC.29/CWE.1", "检验类型")]
        public string ORC_ORC_29_CWE_1 { get; set; }

        #endregion

        #region NTE

        /// <summary>
        /// 图片URL
        /// </summary>
        [HL7Filed("NTE.3", "OUL_R24.ORDER/NTE/NTE.3", "图片URL")]
        public string NTE_NTE_3 { get; set; }

        #endregion

        #region OUL_R24.SPECIMEN

        /// <summary>
        /// 样品
        /// </summary>
        [HL7Filed("", "OUL_R24.ORDER/OUL_R24.SPECIMEN", "样品", IsArray = true)]
        public List<OUL_R24_OUL_R24_SPECIMEN> OUL_R24_SPECIMEN_List { get; set; }

        #endregion

    }

    /// <summary>
    /// 样品
    /// </summary>
    public class OUL_R24_OUL_R24_SPECIMEN : IHL7ArrayItem
    {
        #region SPM

        /// <summary>
        /// 样本类型
        /// </summary>
        [HL7Filed("CWE.1", "OUL_R24.ORDER/OUL_R24.SPECIMEN/SPM/SPM.4/CWE.1", "样本类型")]
        public string SPM_SPM_4_CWE_1 { get; set; }
        /// <summary>
        /// 采集时间
        /// </summary>
        [HL7Filed("DR.1", "OUL_R24.ORDER/OUL_R24.SPECIMEN/SPM/SPM.17/DR.1", "采集时间")]
        public string SPM_SPM_17_DR_1 { get; set; }
        /// <summary>
        /// 核收时间
        /// </summary>
        [HL7Filed("SPM.18", "OUL_R24.ORDER/OUL_R24.SPECIMEN/SPM/SPM.18", "核收时间")]
        public string SPM_SPM_18 { get; set; }

        #endregion

        #region OBX

        /// <summary>
        /// 观察值类型
        /// </summary>
        [HL7Filed("OBX.2", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.2", "观察值类型")]
        public string OBX_OBX_2 { get; set; }
        /// <summary>
        /// 结果编码
        /// </summary>
        [HL7Filed("CWE.1", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.3/CWE.1", "结果编码")]
        public string OBX_OBX_3_CWE_1 { get; set; }
        /// <summary>
        /// 结果英文名称
        /// </summary>
        [HL7Filed("CWE.2", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.3/CWE.2", "结果英文名称")]
        public string OBX_OBX_3_CWE_2 { get; set; }
        /// <summary>
        /// 检验项目代码
        /// </summary>
        [HL7Filed("CWE.4", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.3/CWE.4", "检验项目代码")]
        public string OBX_OBX_3_CWE_4 { get; set; }
        /// <summary>
        /// 检验项目名称
        /// </summary>
        [HL7Filed("CWE.5", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.3/CWE.5", "检验项目名称")]
        public string OBX_OBX_3_CWE_5 { get; set; }
        /// <summary>
        /// 结果中文名称
        /// </summary>
        [HL7Filed("CWE.9", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.3/CWE.9", "结果中文名称")]
        public string OBX_OBX_3_CWE_9 { get; set; }
        /// <summary>
        /// 报告序号
        /// </summary>
        [HL7Filed("OBX.4", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.4", "报告序号")]
        public string OBX_OBX_4 { get; set; }
        /// <summary>
        /// 观察值
        /// </summary>
        [HL7Filed("OBX.5", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.5", "观察值")]
        public string OBX_OBX_5 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [HL7Filed("CWE.2", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.6/CWE.2", "单位")]
        public string OBX_OBX_6_CWE_2 { get; set; }
        /// <summary>
        /// 参考值范围
        /// </summary>
        [HL7Filed("OBX.7", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.7", "参考值范围")]
        public string OBX_OBX_7 { get; set; }
        /// <summary>
        /// 异常标志
        /// </summary>
        [HL7Filed("OBX.8", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.8", "异常标志")]
        public string OBX_OBX_8 { get; set; }
        /// <summary>
        /// 结果检出时间
        /// </summary>
        [HL7Filed("OBX.14", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.14", "结果检出时间")]
        public string OBX_OBX_14 { get; set; }
        /// <summary>
        /// 检验方法
        /// </summary>
        [HL7Filed("CWE.2", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.17/CWE.2", "检验方法")]
        public string OBX_OBX_17_CWE_2 { get; set; }
        /// <summary>
        /// 值类型
        /// </summary>
        [HL7Filed("CWE.5", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.17/CWE.5", "值类型")]
        public string OBX_OBX_17_CWE_5 { get; set; }
        /// <summary>
        /// 操作(上机)时间
        /// </summary>
        [HL7Filed("OBX.19", "OUL_R24.ORDER/OUL_R24.SPECIMEN/OBX/OBX.19", "操作(上机)时间")]
        public string OBX_OBX_19 { get; set; }
        #endregion
    }
}
