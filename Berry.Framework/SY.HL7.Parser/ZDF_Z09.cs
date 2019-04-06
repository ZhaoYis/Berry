#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SY.HL7.Parser
* 项目描述 ：
* 类 名 称 ：ZDF_Z09
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：SY.HL7.Parser
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/7 17:28:03
* 更新时间 ：2019/3/7 17:28:03
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
    /// 功能描述    ：随访  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/7 17:28:03 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/7 17:28:03 
    /// </summary>
    public class ZDF_Z09 : MSH
    {
        public ZDF_Z09()
        {
            this.Root = "/ZDF_Z09/";
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

        #endregion

        #region Z09

        #region Z09.1

        /// <summary>
        /// 随访开始时间
        /// </summary>
        [HL7Filed("XX.1", "Z09/Z09.1/XX.1", "随访开始时间")]
        public string Z09_Z09_1_XX_1 { get; set; }
        /// <summary>
        /// 随访方式代码。1-门诊 2-家庭 3-电话
        /// </summary>
        [HL7Filed("XX.2", "Z09/Z09.1/XX.2", "随访方式代码")]
        public string Z09_Z09_1_XX_2 { get; set; }
        /// <summary>
        /// 服药情况代码。1-规律 2-间断 3-不服药
        /// </summary>
        [HL7Filed("XX.3", "Z09/Z09.1/XX.3", "服药情况代码")]
        public string Z09_Z09_1_XX_3 { get; set; }
        /// <summary>
        /// 药物不良反应标志。1-无 2-有
        /// </summary>
        [HL7Filed("XX.4", "Z09/Z09.1/XX.4", "药物不良反应标志")]
        public string Z09_Z09_1_XX_4 { get; set; }
        /// <summary>
        /// 药物不良反应描述
        /// </summary>
        [HL7Filed("XX.5", "Z09/Z09.1/XX.5", "药物不良反应描述")]
        public string Z09_Z09_1_XX_5 { get; set; }
        /// <summary>
        /// 糖尿病随访分类代码。1-控制满意 2-控制不满意 3-不良反应 4-并发症
        /// </summary>
        [HL7Filed("XX.6", "Z09/Z09.1/XX.6", "糖尿病随访分类代码")]
        public string Z09_Z09_1_XX_6 { get; set; }
        /// <summary>
        /// 下次随访日期
        /// </summary>
        [HL7Filed("XX.7", "Z09/Z09.1/XX.7", "下次随访日期")]
        public string Z09_Z09_1_XX_7 { get; set; }
        /// <summary>
        /// 随访医生姓名
        /// </summary>
        [HL7Filed("XX.8", "Z09/Z09.1/XX.8", "随访医生姓名")]
        public string Z09_Z09_1_XX_8 { get; set; }
        /// <summary>
        /// 随访结束时间
        /// </summary>
        [HL7Filed("XX.9", "Z09/Z09.1/XX.9", "随访结束时间")]
        public string Z09_Z09_1_XX_9 { get; set; }
        /// <summary>
        /// 随访编号
        /// </summary>
        [HL7Filed("XX.10", "Z09/Z09.1/XX.10", "随访编号")]
        public string Z09_Z09_1_XX_10 { get; set; }
        /// <summary>
        /// 低血糖反应。1-无 2-偶尔 3-频繁
        /// </summary>
        [HL7Filed("XX.11", "Z09/Z09.1/XX.11", "低血糖反应")]
        public string Z09_Z09_1_XX_11 { get; set; }
        /// <summary>
        /// 随访医生编号
        /// </summary>
        [HL7Filed("XX.12", "Z09/Z09.1/XX.12", "随访医生编号")]
        public string Z09_Z09_1_XX_12 { get; set; }
        /// <summary>
        /// 是否高血压。1-无 2-有
        /// </summary>
        [HL7Filed("XX.13", "Z09/Z09.1/XX.13", "是否高血压")]
        public string Z09_Z09_1_XX_13 { get; set; }
        /// <summary>
        /// 是否糖尿病。1-无 2-有
        /// </summary>
        [HL7Filed("XX.14", "Z09/Z09.1/XX.14", "是否糖尿病")]
        public string Z09_Z09_1_XX_14 { get; set; }
        /// <summary>
        /// 高血压随访分类代码。1-控制满意 2-控制不满意 3-不良反应 4-并发症
        /// </summary>
        [HL7Filed("XX.15", "Z09/Z09.1/XX.15", "高血压随访分类代码")]
        public string Z09_Z09_1_XX_15 { get; set; }
        #endregion

        #region Z09.2



        #endregion

        #region Z09.3

        /// <summary>
        /// 收缩压
        /// </summary>
        [HL7Filed("XX.1", "Z09/Z09.3/XX.1", "收缩压")]
        public string Z09_Z09_3_XX_1 { get; set; }
        /// <summary>
        /// 舒张压
        /// </summary>
        [HL7Filed("XX.2", "Z09/Z09.3/XX.2", "舒张压")]
        public string Z09_Z09_3_XX_2 { get; set; }
        /// <summary>
        /// 体重(kg)
        /// </summary>
        [HL7Filed("XX.3", "Z09/Z09.3/XX.3", "体重")]
        public string Z09_Z09_3_XX_3 { get; set; }
        /// <summary>
        /// 目标体重（kg）
        /// </summary>
        [HL7Filed("XX.4", "Z09/Z09.3/XX.4", "目标体重")]
        public string Z09_Z09_3_XX_4 { get; set; }
        /// <summary>
        /// 体质指数
        /// </summary>
        [HL7Filed("XX.5", "Z09/Z09.3/XX.5", "体质指数")]
        public string Z09_Z09_3_XX_5 { get; set; }
        /// <summary>
        /// 目标体质指数
        /// </summary>
        [HL7Filed("XX.6", "Z09/Z09.3/XX.6", "目标体质指数")]
        public string Z09_Z09_3_XX_6 { get; set; }
        /// <summary>
        /// 足背动脉搏动代码。1双侧消失 2触及双侧对称 3触及左侧减弱 4触及右侧减弱 5左侧消失 6右侧消失 7触及双侧减弱
        /// </summary>
        [HL7Filed("XX.7", "Z09/Z09.3/XX.7", "足背动脉搏动代码")]
        public string Z09_Z09_3_XX_7 { get; set; }
        /// <summary>
        /// 体征其他描述
        /// </summary>
        [HL7Filed("XX.8", "Z09/Z09.3/XX.8", "体征其他描述")]
        public string Z09_Z09_3_XX_8 { get; set; }
        /// <summary>
        /// 身高(cm)
        /// </summary>
        [HL7Filed("XX.9", "Z09/Z09.3/XX.9", "身高")]
        public string Z09_Z09_3_XX_9 { get; set; }
        /// <summary>
        /// 心率。（次/min）
        /// </summary>
        [HL7Filed("XX.10", "Z09/Z09.3/XX.10", "心率")]
        public string Z09_Z09_3_XX_10 { get; set; }

        #endregion

        #region Z09.4

        /// <summary>
        /// 日吸烟量（支）
        /// </summary>
        [HL7Filed("XX.1", "Z09/Z09.4/XX.1", "日吸烟量")]
        public string Z09_Z09_4_XX_1 { get; set; }
        /// <summary>
        /// 目标日吸烟量
        /// </summary>
        [HL7Filed("XX.2", "Z09/Z09.4/XX.2", "目标日吸烟量")]
        public string Z09_Z09_4_XX_2 { get; set; }
        /// <summary>
        /// 日饮酒量（两）
        /// </summary>
        [HL7Filed("XX.3", "Z09/Z09.4/XX.3", "日饮酒量")]
        public string Z09_Z09_4_XX_3 { get; set; }
        /// <summary>
        /// 目标日饮酒量（两）
        /// </summary>
        [HL7Filed("XX.4", "Z09/Z09.4/XX.4", "目标日饮酒量")]
        public string Z09_Z09_4_XX_4 { get; set; }
        /// <summary>
        /// 运动频率代码
        /// </summary>
        [HL7Filed("XX.5", "Z09/Z09.4/XX.5", "运动频率代码")]
        public string Z09_Z09_4_XX_5 { get; set; }
        /// <summary>
        /// 目标运动频率
        /// </summary>
        [HL7Filed("XX.6", "Z09/Z09.4/XX.6", "目标运动频率")]
        public string Z09_Z09_4_XX_6 { get; set; }
        /// <summary>
        /// 运动时长
        /// </summary>
        [HL7Filed("XX.7", "Z09/Z09.4/XX.7", "运动时长")]
        public string Z09_Z09_4_XX_7 { get; set; }
        /// <summary>
        /// 目标运动时长（min）
        /// </summary>
        [HL7Filed("XX.8", "Z09/Z09.4/XX.8", "目标运动时长")]
        public string Z09_Z09_4_XX_8 { get; set; }
        /// <summary>
        /// 日主食量（g）
        /// </summary>
        [HL7Filed("XX.9", "Z09/Z09.4/XX.9", "日主食量")]
        public string Z09_Z09_4_XX_9 { get; set; }
        /// <summary>
        /// 目标日主食量（g）
        /// </summary>
        [HL7Filed("XX.10", "Z09/Z09.4/XX.10", "目标日主食量")]
        public string Z09_Z09_4_XX_10 { get; set; }
        /// <summary>
        /// 心理调整评价结果代码。1-良好 2-—般 3-差
        /// </summary>
        [HL7Filed("XX.11", "Z09/Z09.4/XX.11", "心理调整评价结果代码")]
        public string Z09_Z09_4_XX_11 { get; set; }
        /// <summary>
        /// 随访遵医行为评价结果代码。1-良好 2-—般 3-差
        /// </summary>
        [HL7Filed("XX.12", "Z09/Z09.4/XX.12", "随访遵医行为评价结果代码")]
        public string Z09_Z09_4_XX_12 { get; set; }
        /// <summary>
        /// 摄盐量分级代码。1-轻 2-中 3-重
        /// </summary>
        [HL7Filed("XX.13", "Z09/Z09.4/XX.13", "摄盐量分级代码")]
        public string Z09_Z09_4_XX_13 { get; set; }
        /// <summary>
        /// 目标摄盐量分级代码。1-轻 2-中 3-重
        /// </summary>
        [HL7Filed("XX.14", "Z09/Z09.4/XX.14", "目标摄盐量分级代码")]
        public string Z09_Z09_4_XX_14 { get; set; }

        #endregion

        #region Z09.7

        /// <summary>
        /// 口服药用药情况相关信息
        /// </summary>
        [HL7Filed("", "Z09/Z09.7", "口服药用药情况相关信息", IsArray = true)]
        public List<ZDF_Z09_Z09_7> Z09_7_List { get; set; }

        #endregion

        #region Z09.8

        /// <summary>
        /// 个人档案标识符
        /// </summary>
        [HL7Filed("XX.4", "Z09/Z09.8/XX.4", "个人档案标识符")]
        public string Z09_Z09_8_XX_4 { get; set; }
        /// <summary>
        /// 第一次随访医生工号
        /// </summary>
        [HL7Filed("XX.5", "Z09/Z09.8/XX.5", "第一次随访医生工号")]
        public string Z09_Z09_8_XX_5 { get; set; }
        /// <summary>
        /// 第一次随访医生姓名
        /// </summary>
        [HL7Filed("XX.6", "Z09/Z09.8/XX.6", "第一次随访医生姓名")]
        public string Z09_Z09_8_XX_6 { get; set; }
        /// <summary>
        /// 第一次随访时间
        /// </summary>
        [HL7Filed("XX.7", "Z09/Z09.8/XX.7", "第一次随访时间")]
        public string Z09_Z09_8_XX_7 { get; set; }
        /// <summary>
        /// 糖尿病临床确诊时间
        /// </summary>
        [HL7Filed("XX.8", "Z09/Z09.8/XX.8", "糖尿病临床确诊时间")]
        public string Z09_Z09_8_XX_8 { get; set; }
        /// <summary>
        /// 糖尿病病例来源
        /// </summary>
        [HL7Filed("XX.9", "Z09/Z09.8/XX.9", "糖尿病病例来源")]
        public string Z09_Z09_8_XX_9 { get; set; }
        /// <summary>
        /// 家族史编码。01无 02高血压 03糖尿病 04冠心病 07脑卒中 99其他
        /// </summary>
        [HL7Filed("XX.10", "Z09/Z09.8/XX.10", "家族史编码")]
        public string Z09_Z09_8_XX_10 { get; set; }
        /// <summary>
        /// 家族史名称
        /// </summary>
        [HL7Filed("XX.11", "Z09/Z09.8/XX.11", "家族史名称")]
        public string Z09_Z09_8_XX_11 { get; set; }
        /// <summary>
        /// 生活自理能力编码。1-可自理 2-轻度依赖 3-中度依赖 4-不能自理
        /// </summary>
        [HL7Filed("XX.12", "Z09/Z09.8/XX.12", "生活自理能力编码")]
        public string Z09_Z09_8_XX_12 { get; set; }
        /// <summary>
        /// 生活自理能力名称
        /// </summary>
        [HL7Filed("XX.13", "Z09/Z09.8/XX.13", "生活自理能力名称")]
        public string Z09_Z09_8_XX_13 { get; set; }
        /// <summary>
        /// 糖尿病并发症情况编码
        /// </summary>
        [HL7Filed("XX.14", "Z09/Z09.8/XX.14", "糖尿病并发症情况编码")]
        public string Z09_Z09_8_XX_14 { get; set; }
        /// <summary>
        /// 糖尿病并发症情况名称
        /// </summary>
        [HL7Filed("XX.15", "Z09/Z09.8/XX.15", "糖尿病并发症情况名称")]
        public string Z09_Z09_8_XX_15 { get; set; }
        /// <summary>
        /// 随机血糖值
        /// </summary>
        [HL7Filed("XX.16", "Z09/Z09.8/XX.16", "随机血糖值")]
        public string Z09_Z09_8_XX_16 { get; set; }
        /// <summary>
        /// 生活习惯锻炼。1-规律 2-偶尔 3-不锻炼
        /// </summary>
        [HL7Filed("XX.17", "Z09/Z09.8/XX.17", "生活习惯锻炼")]
        public string Z09_Z09_8_XX_17 { get; set; }
        /// <summary>
        /// 生活习惯_吸烟。1-从不吸烟 2-戒烟 3-吸烟
        /// </summary>
        [HL7Filed("XX.18", "Z09/Z09.8/XX.18", "生活习惯_吸烟")]
        public string Z09_Z09_8_XX_18 { get; set; }
        /// <summary>
        /// 生活习惯_饮酒。1-从不 2-偶尔 3-经常 4-每天
        /// </summary>
        [HL7Filed("XX.19", "Z09/Z09.8/XX.19", "生活习惯_饮酒")]
        public string Z09_Z09_8_XX_19 { get; set; }

        #endregion

        #endregion
    }

    /// <summary>
    /// 口服药用药情况相关信息
    /// </summary>
    public class ZDF_Z09_Z09_7 : IHL7ArrayItem
    {
        /// <summary>
        /// 药物ID
        /// </summary>
        [HL7Filed("XX.1", "Z09/Z09.7/XX.1", "药物ID")]
        public string Z09_Z09_7_XX_1 { get; set; }
        /// <summary>
        /// 药物名称
        /// </summary>
        [HL7Filed("XX.2", "Z09/Z09.7/XX.2", "药物名称")]
        public string Z09_Z09_7_XX_2 { get; set; }
        /// <summary>
        /// 药物使用频率
        /// </summary>
        [HL7Filed("XX.3", "Z09/Z09.7/XX.3", "药物使用频率")]
        public string Z09_Z09_7_XX_3 { get; set; }
        /// <summary>
        /// 单次使用药物剂量
        /// </summary>
        [HL7Filed("XX.4", "Z09/Z09.7/XX.4", "单次使用药物剂量")]
        public string Z09_Z09_7_XX_4 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [HL7Filed("XX.5", "Z09/Z09.7/XX.5", "单位")]
        public string Z09_Z09_7_XX_5 { get; set; }
    }
}
