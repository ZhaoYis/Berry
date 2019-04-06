#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SY.HL7.Parser
* 项目描述 ：
* 类 名 称 ：ZAP_Z10
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：SY.HL7.Parser
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/7 22:14:50
* 更新时间 ：2019/3/7 22:14:50
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
    /// 功能描述    ：年检  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/7 22:14:50 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/7 22:14:50 
    /// </summary>
    public class ZAP_Z10 : MSH
    {
        public ZAP_Z10()
        {
            this.Root = "/ZAP_Z10/";
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

        #endregion

        #region Z10

        #region Z10.1

        /// <summary>
        /// 体检机构代码
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.1/XX.1", "体检机构代码")]
        public string Z10_Z10_1_XX_1 { get; set; }
        /// <summary>
        /// 体检编号
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.1/XX.2", "体检编号")]
        public string Z10_Z10_1_XX_2 { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.1/XX.3", "证件号码")]
        public string Z10_Z10_1_XX_3 { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        [HL7Filed("XX.4", "Z10/Z10.1/XX.4", "证件类型")]
        public string Z10_Z10_1_XX_4 { get; set; }
        /// <summary>
        /// 体检开始时间
        /// </summary>
        [HL7Filed("XX.5", "Z10/Z10.1/XX.5", "体检开始时间")]
        public string Z10_Z10_1_XX_5 { get; set; }
        /// <summary>
        /// 主检医生身份证号码
        /// </summary>
        [HL7Filed("XX.6", "Z10/Z10.1/XX.6", "主检医生身份证号码")]
        public string Z10_Z10_1_XX_6 { get; set; }
        /// <summary>
        /// 主检医生姓名
        /// </summary>
        [HL7Filed("XX.7", "Z10/Z10.1/XX.7", "主检医生姓名")]
        public string Z10_Z10_1_XX_7 { get; set; }
        /// <summary>
        /// 体检结束时间
        /// </summary>
        [HL7Filed("XX.8", "Z10/Z10.1/XX.8", "体检结束时间")]
        public string Z10_Z10_1_XX_8 { get; set; }
        #endregion

        #region Z10.2

        /// <summary>
        /// 症状代码。1无症状 2头痛 3头晕 4心悸 5胸闷 6胸痛 7慢性咳嗽 8咳痰 9呼吸困难 10多饮 11多尿 12体重下降 13乏力 14关节肿痛 15视力模糊 16手脚麻木 17尿急 18尿痛 19便秘 20腹泻 21恶心呕吐 22眼花 23耳鸣 24乳房胀痛 25其他，多个以“;”间隔
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.2/XX.1", "症状代码")]
        public string Z10_Z10_2_XX_1 { get; set; }
        /// <summary>
        /// 症状名称
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.2/XX.2", "症状名称")]
        public string Z10_Z10_2_XX_2 { get; set; }

        #endregion

        #region Z10.3

        /// <summary>
        /// 体温(℃)
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.3/XX.1", "体温")]
        public string Z10_Z10_3_XX_1 { get; set; }
        /// <summary>
        /// 脉率(次/min)
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.3/XX.2", "脉率")]
        public string Z10_Z10_3_XX_2 { get; set; }
        /// <summary>
        /// 呼吸频率(次/min)
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.3/XX.3", "呼吸频率")]
        public string Z10_Z10_3_XX_3 { get; set; }
        /// <summary>
        /// 血压左舒张压(mmHg)
        /// </summary>
        [HL7Filed("XX.4", "Z10/Z10.3/XX.4", "血压左舒张压")]
        public string Z10_Z10_3_XX_4 { get; set; }
        /// <summary>
        /// 血压左收缩压(mmHg)
        /// </summary>
        [HL7Filed("XX.5", "Z10/Z10.3/XX.5", "血压左收缩压")]
        public string Z10_Z10_3_XX_5 { get; set; }
        /// <summary>
        /// 血压右舒张压(mmHg)
        /// </summary>
        [HL7Filed("XX.6", "Z10/Z10.3/XX.6", "血压右舒张压")]
        public string Z10_Z10_3_XX_6 { get; set; }
        /// <summary>
        /// 血压右收缩压(mmHg)
        /// </summary>
        [HL7Filed("XX.7", "Z10/Z10.3/XX.7", "血压右收缩压")]
        public string Z10_Z10_3_XX_7 { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        [HL7Filed("XX.8", "Z10/Z10.3/XX.8", "身高")]
        public string Z10_Z10_3_XX_8 { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        [HL7Filed("XX.9", "Z10/Z10.3/XX.9", "体重")]
        public string Z10_Z10_3_XX_9 { get; set; }
        /// <summary>
        /// 体质指数
        /// </summary>
        [HL7Filed("XX.10", "Z10/Z10.3/XX.10", "体质指数")]
        public string Z10_Z10_3_XX_10 { get; set; }
        /// <summary>
        /// 腰围
        /// </summary>
        [HL7Filed("XX.11", "Z10/Z10.3/XX.11", "腰围")]
        public string Z10_Z10_3_XX_11 { get; set; }
        /// <summary>
        /// 老年人健康状态自我评估代码。1满意 2基本满意 3说不清楚 4不太满意 5不满意
        /// </summary>
        [HL7Filed("XX.12", "Z10/Z10.3/XX.12", "老年人健康状态自我评估代码")]
        public string Z10_Z10_3_XX_12 { get; set; }
        /// <summary>
        /// 老年人自理能力自我评估代码。1 可自理（ 0～3分）2 轻度依赖（ 4～8分） 3 中度依赖（ 9～18分） 4 不能自理（≥19分）
        /// </summary>
        [HL7Filed("XX.13", "Z10/Z10.3/XX.13", "老年人自理能力自我评估代码")]
        public string Z10_Z10_3_XX_13 { get; set; }
        /// <summary>
        /// 老年人认识功能代码。1-粗筛阴性 2-粗筛阳性
        /// </summary>
        [HL7Filed("XX.14", "Z10/Z10.3/XX.14", "老年人认识功能代码")]
        public string Z10_Z10_3_XX_14 { get; set; }
        /// <summary>
        /// 智力状态检查总分
        /// </summary>
        [HL7Filed("XX.15", "Z10/Z10.3/XX.15", "智力状态检查总分")]
        public string Z10_Z10_3_XX_15 { get; set; }
        /// <summary>
        /// 老年人情感状态代码。1-粗筛阴性 2-粗筛阳性
        /// </summary>
        [HL7Filed("XX.16", "Z10/Z10.3/XX.16", "老年人情感状态代码")]
        public string Z10_Z10_3_XX_16 { get; set; }
        /// <summary>
        /// 老年人抑郁评分检查总分
        /// </summary>
        [HL7Filed("XX.17", "Z10/Z10.3/XX.17", "老年人抑郁评分检查总分")]
        public string Z10_Z10_3_XX_17 { get; set; }
        /// <summary>
        /// 臀围
        /// </summary>
        [HL7Filed("XX.18", "Z10/Z10.3/XX.18", "臀围")]
        public string Z10_Z10_3_XX_18 { get; set; }
        #endregion

        #region Z10.4

        /// <summary>
        /// 锻炼频率代码。1每天 2每周一次以上 3偶尔 4不运动
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.4/XX.1", "锻炼频率代码")]
        public string Z10_Z10_4_XX_1 { get; set; }
        /// <summary>
        /// 每次锻炼时间
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.4/XX.2", "每次锻炼时间")]
        public string Z10_Z10_4_XX_2 { get; set; }
        /// <summary>
        /// 坚持锻炼时间
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.4/XX.3", "坚持锻炼时间")]
        public string Z10_Z10_4_XX_3 { get; set; }
        /// <summary>
        /// 锻炼方式说明
        /// </summary>
        [HL7Filed("XX.4", "Z10/Z10.4/XX.4", "锻炼方式说明")]
        public string Z10_Z10_4_XX_4 { get; set; }
        /// <summary>
        /// 饮食习惯代码。1荤素均衡 2荤食为主 3素食为主 4嗜盐 5嗜油 6嗜糖
        /// </summary>
        [HL7Filed("XX.5", "Z10/Z10.4/XX.5", "饮食习惯代码")]
        public string Z10_Z10_4_XX_5 { get; set; }
        /// <summary>
        /// 吸烟状况代码。1从不吸烟 2已戒烟 3吸烟
        /// </summary>
        [HL7Filed("XX.6", "Z10/Z10.4/XX.6", "吸烟状况代码")]
        public string Z10_Z10_4_XX_6 { get; set; }
        /// <summary>
        /// 日吸烟量
        /// </summary>
        [HL7Filed("XX.7", "Z10/Z10.4/XX.7", "日吸烟量")]
        public string Z10_Z10_4_XX_7 { get; set; }
        /// <summary>
        /// 开始吸烟年龄
        /// </summary>
        [HL7Filed("XX.8", "Z10/Z10.4/XX.8", "开始吸烟年龄")]
        public string Z10_Z10_4_XX_8 { get; set; }
        /// <summary>
        /// 戒烟年龄
        /// </summary>
        [HL7Filed("XX.9", "Z10/Z10.4/XX.9", "戒烟年龄")]
        public string Z10_Z10_4_XX_9 { get; set; }
        /// <summary>
        /// 饮酒频率代码。1从不 2偶尔 3经常 4每天
        /// </summary>
        [HL7Filed("XX.10", "Z10/Z10.4/XX.10", "饮酒频率代码")]
        public string Z10_Z10_4_XX_10 { get; set; }
        /// <summary>
        /// 日饮酒量
        /// </summary>
        [HL7Filed("XX.11", "Z10/Z10.4/XX.11", "日饮酒量")]
        public string Z10_Z10_4_XX_11 { get; set; }
        /// <summary>
        /// 是否戒酒。1未戒酒  2已戒酒
        /// </summary>
        [HL7Filed("XX.12", "Z10/Z10.4/XX.12", "是否戒酒")]
        public string Z10_Z10_4_XX_12 { get; set; }
        /// <summary>
        /// 戒酒年龄
        /// </summary>
        [HL7Filed("XX.13", "Z10/Z10.4/XX.13", "戒酒年龄")]
        public string Z10_Z10_4_XX_13 { get; set; }
        /// <summary>
        /// 开始饮酒年龄。
        /// </summary>
        [HL7Filed("XX.14", "Z10/Z10.4/XX.14", "开始饮酒年龄")]
        public string Z10_Z10_4_XX_14 { get; set; }
        /// <summary>
        /// 近一年是否有醉酒。1是 2否
        /// </summary>
        [HL7Filed("XX.15", "Z10/Z10.4/XX.15", "近一年是否有醉酒")]
        public string Z10_Z10_4_XX_15 { get; set; }
        /// <summary>
        /// 饮酒种类代码。1白酒 2啤酒 3红酒 4黄酒 5其他
        /// </summary>
        [HL7Filed("XX.16", "Z10/Z10.4/XX.16", "饮酒种类代码")]
        public string Z10_Z10_4_XX_16 { get; set; }
        /// <summary>
        /// 饮酒种类名称
        /// </summary>
        [HL7Filed("XX.17", "Z10/Z10.4/XX.17", "饮酒种类名称")]
        public string Z10_Z10_4_XX_17 { get; set; }
        /// <summary>
        /// 进餐方式
        /// </summary>
        [HL7Filed("XX.18", "Z10/Z10.4/XX.18", "进餐方式")]
        public string Z10_Z10_4_XX_18 { get; set; }
        /// <summary>
        /// 梳洗
        /// </summary>
        [HL7Filed("XX.19", "Z10/Z10.4/XX.19", "梳洗")]
        public string Z10_Z10_4_XX_19 { get; set; }
        /// <summary>
        /// 穿衣
        /// </summary>
        [HL7Filed("XX.20", "Z10/Z10.4/XX.20", "穿衣")]
        public string Z10_Z10_4_XX_20 { get; set; }
        /// <summary>
        /// 如厕
        /// </summary>
        [HL7Filed("XX.21", "Z10/Z10.4/XX.21", "如厕")]
        public string Z10_Z10_4_XX_21 { get; set; }
        /// <summary>
        /// 活动
        /// </summary>
        [HL7Filed("XX.22", "Z10/Z10.4/XX.22", "活动")]
        public string Z10_Z10_4_XX_22 { get; set; }
        /// <summary>
        /// 老年人自理能力评估事项总得分
        /// </summary>
        [HL7Filed("XX.23", "Z10/Z10.4/XX.23", "老年人自理能力评估事项总得分")]
        public string Z10_Z10_4_XX_23 { get; set; }
        /// <summary>
        /// 老年人自理能力自我评估代码
        /// </summary>
        [HL7Filed("XX.24", "Z10/Z10.4/XX.24", "老年人自理能力自我评估代码")]
        public string Z10_Z10_4_XX_24 { get; set; }

        #endregion

        #region Z10.5

        /// <summary>
        /// 口腔口唇外观代码。1-红润 2-苍白 3-发绀 4-皲裂 5-疱疹
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.5/XX.1", "口腔口唇外观代码")]
        public string Z10_Z10_5_XX_1 { get; set; }
        /// <summary>
        /// 口腔齿列类别代码。1-正常 2-缺齿 3-龋齿 4-义齿
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.5/XX.2", "口腔齿列类别代码")]
        public string Z10_Z10_5_XX_2 { get; set; }
        /// <summary>
        /// 口腔咽部检查结果代码。1-无充血 2-充血 3-淋巴滤泡增生
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.5/XX.3", "口腔咽部检查结果代码")]
        public string Z10_Z10_5_XX_3 { get; set; }
        /// <summary>
        /// 裸眼视力左眼
        /// </summary>
        [HL7Filed("XX.4", "Z10/Z10.5/XX.4", "裸眼视力左眼")]
        public string Z10_Z10_5_XX_4 { get; set; }
        /// <summary>
        /// 裸眼视力右眼
        /// </summary>
        [HL7Filed("XX.5", "Z10/Z10.5/XX.5", "裸眼视力右眼")]
        public string Z10_Z10_5_XX_5 { get; set; }
        /// <summary>
        /// 矫正视力左眼
        /// </summary>
        [HL7Filed("XX.6", "Z10/Z10.5/XX.6", "矫正视力左眼")]
        public string Z10_Z10_5_XX_6 { get; set; }
        /// <summary>
        /// 矫正视力右眼
        /// </summary>
        [HL7Filed("XX.7", "Z10/Z10.5/XX.7", "矫正视力右眼")]
        public string Z10_Z10_5_XX_7 { get; set; }
        /// <summary>
        /// 听力检测结果代码。1-听见 2-听不清或无法听见
        /// </summary>
        [HL7Filed("XX.8", "Z10/Z10.5/XX.8", "听力检测结果代码")]
        public string Z10_Z10_5_XX_8 { get; set; }
        /// <summary>
        /// 运动功能状态代码。1-可顺利完成  2-无法独立完成其中任何一个动作
        /// </summary>
        [HL7Filed("XX.9", "Z10/Z10.5/XX.9", "运动功能状态代码")]
        public string Z10_Z10_5_XX_9 { get; set; }

        #endregion

        #region Z10.6

        /// <summary>
        /// 眼底异常标志。1正常 2异常
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.6/XX.1", "眼底异常标志")]
        public string Z10_Z10_6_XX_1 { get; set; }
        /// <summary>
        /// 皮肤检查结果代码。1正常 2潮红 3苍白 4发绀 5黄染 6色素沉着 7其他
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.6/XX.3", "皮肤检查结果代码")]
        public string Z10_Z10_6_XX_3 { get; set; }
        /// <summary>
        /// 巩膜检查结果代码。1正常 2黄染 3充血 4其他
        /// </summary>
        [HL7Filed("XX.5", "Z10/Z10.6/XX.5", "巩膜检查结果代码")]
        public string Z10_Z10_6_XX_5 { get; set; }
        /// <summary>
        /// 淋巴结检查结果代码。1未触及 2锁骨上 4腋窝 8其他
        /// </summary>
        [HL7Filed("XX.7", "Z10/Z10.6/XX.7", "淋巴结检查结果代码")]
        public string Z10_Z10_6_XX_7 { get; set; }
        /// <summary>
        /// 肺桶状胸标志。1否　2是
        /// </summary>
        [HL7Filed("XX.9", "Z10/Z10.6/XX.9", "肺桶状胸标志")]
        public string Z10_Z10_6_XX_9 { get; set; }
        /// <summary>
        /// 肺呼吸音标志。1正常 2异常
        /// </summary>
        [HL7Filed("XX.10", "Z10/Z10.6/XX.10", "肺呼吸音标志")]
        public string Z10_Z10_6_XX_10 { get; set; }
        /// <summary>
        /// 肺罗音代码。1无 2干罗音  3湿罗音 4其他
        /// </summary>
        [HL7Filed("XX.12", "Z10/Z10.6/XX.12", "肺罗音代码")]
        public string Z10_Z10_6_XX_12 { get; set; }
        /// <summary>
        /// 心脏心率
        /// </summary>
        [HL7Filed("XX.14", "Z10/Z10.6/XX.14", "心脏心率")]
        public string Z10_Z10_6_XX_14 { get; set; }
        /// <summary>
        /// 心脏心律类别代码。l齐 2不齐 3绝对不齐
        /// </summary>
        [HL7Filed("XX.15", "Z10/Z10.6/XX.15", "心脏心律类别代码")]
        public string Z10_Z10_6_XX_15 { get; set; }
        /// <summary>
        /// 心脏杂音标志。1无 2有
        /// </summary>
        [HL7Filed("XX.16", "Z10/Z10.6/XX.16", "心脏杂音标志")]
        public string Z10_Z10_6_XX_16 { get; set; }
        /// <summary>
        /// 腹部压痛标志。1无 2有
        /// </summary>
        [HL7Filed("XX.18", "Z10/Z10.6/XX.18", "腹部压痛标志")]
        public string Z10_Z10_6_XX_18 { get; set; }
        /// <summary>
        /// 腹部包块标志。1无 2有
        /// </summary>
        [HL7Filed("XX.20", "Z10/Z10.6/XX.20", "腹部包块标志")]
        public string Z10_Z10_6_XX_20 { get; set; }
        /// <summary>
        /// 腹部肝大标志。1无 2有
        /// </summary>
        [HL7Filed("XX.22", "Z10/Z10.6/XX.22", "腹部肝大标志")]
        public string Z10_Z10_6_XX_22 { get; set; }
        /// <summary>
        /// 腹部脾大标志。1无 2有
        /// </summary>
        [HL7Filed("XX.24", "Z10/Z10.6/XX.24", "腹部脾大标志")]
        public string Z10_Z10_6_XX_24 { get; set; }
        /// <summary>
        /// 腹部移动性浊音标志。1无 2有
        /// </summary>
        [HL7Filed("XX.26", "Z10/Z10.6/XX.26", "腹部移动性浊音标志")]
        public string Z10_Z10_6_XX_26 { get; set; }
        /// <summary>
        /// 下肢水肿代码。1.无下肢水肿 2.单侧下肢水肿 3.双侧不对称下肢水肿 4.双侧对称下肢水肿
        /// </summary>
        [HL7Filed("XX.28", "Z10/Z10.6/XX.28", "下肢水肿代码")]
        public string Z10_Z10_6_XX_28 { get; set; }
        /// <summary>
        /// 足背动脉博动代码。1未触及 2 触及双侧对称 3 触及左侧弱或消失 4 触及右侧弱或消失
        /// </summary>
        [HL7Filed("XX.29", "Z10/Z10.6/XX.29", "足背动脉博动代码")]
        public string Z10_Z10_6_XX_29 { get; set; }
        /// <summary>
        /// 肛门指诊代码。1未及异常 2触痛 3包块 4前列腺异常 5其他
        /// </summary>
        [HL7Filed("XX.30", "Z10/Z10.6/XX.30", "肛门指诊代码")]
        public string Z10_Z10_6_XX_30 { get; set; }
        /// <summary>
        /// 乳腺检查结果代码。1未见异常 2乳房切除 3异常泌乳 4乳腺包块 5其他
        /// </summary>
        [HL7Filed("XX.32", "Z10/Z10.6/XX.32", "乳腺检查结果代码")]
        public string Z10_Z10_6_XX_32 { get; set; }

        #endregion

        #region Z10.7

        /// <summary>
        /// 心电图异常标志。1正常 2异常
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.7/XX.1", "心电图异常标志")]
        public string Z10_Z10_7_XX_1 { get; set; }
        /// <summary>
        /// 心电图异常描述
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.7/XX.2", "心电图异常描述")]
        public string Z10_Z10_7_XX_2 { get; set; }
        /// <summary>
        /// 腹部B超异常标志。1正常 2异常
        /// </summary>
        [HL7Filed("XX.5", "Z10/Z10.7/XX.5", "腹部B超异常标志 ")]
        public string Z10_Z10_7_XX_5 { get; set; }
        /// <summary>
        /// 宫颈涂片异常标志。1正常 2异常
        /// </summary>
        [HL7Filed("XX.6", "Z10/Z10.7/XX.6", "宫颈涂片异常标志")]
        public string Z10_Z10_7_XX_6 { get; set; }

        #endregion

        #region Z10.8

        /// <summary>
        /// 脑血管疾病代码。1未发现  2缺血性卒中 3脑出血 4蛛网膜下腔出血 5短暂性脑缺血发作 6其他
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.8/XX.1", "脑血管疾病代码")]
        public string Z10_Z10_8_XX_1 { get; set; }
        /// <summary>
        /// 肾脏疾病代码。1未发现  2糖尿病肾病  3肾功能衰竭  4急性肾炎  5慢性肾炎   6其他
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.8/XX.3", "肾脏疾病代码")]
        public string Z10_Z10_8_XX_3 { get; set; }
        /// <summary>
        /// 心脏疾病代码。1未发现  2心肌梗死  3心绞痛  4冠状动脉血运重建 5充血性心力衰竭 6 心前区疼痛  7其他
        /// </summary>
        [HL7Filed("XX.5", "Z10/Z10.8/XX.5", "心脏疾病代码")]
        public string Z10_Z10_8_XX_5 { get; set; }
        /// <summary>
        /// 血管疾病代码。1未发现 2夹层动脉瘤  3动脉闭塞性疾病 4其他
        /// </summary>
        [HL7Filed("XX.7", "Z10/Z10.8/XX.7", "血管疾病代码")]
        public string Z10_Z10_8_XX_7 { get; set; }
        /// <summary>
        /// 眼部疾病代码。1未发现 2视网膜出血或渗出 3视乳头水肿 4白内障 5其他
        /// </summary>
        [HL7Filed("XX.9", "Z10/Z10.8/XX.9", "眼部疾病代码")]
        public string Z10_Z10_8_XX_9 { get; set; }
        /// <summary>
        /// 神经系统疾病标志。1未发现 2有
        /// </summary>
        [HL7Filed("XX.11", "Z10/Z10.8/XX.11", "神经系统疾病标志")]
        public string Z10_Z10_8_XX_11 { get; set; }
        /// <summary>
        /// 其他系统疾病。1未发现 2有
        /// </summary>
        [HL7Filed("XX.13", "Z10/Z10.8/XX.13", "其他系统疾病")]
        public string Z10_Z10_8_XX_13 { get; set; }
        /// <summary>
        /// 其他系统疾病描述
        /// </summary>
        [HL7Filed("XX.14", "Z10/Z10.8/XX.14", "其他系统疾病描述")]
        public string Z10_Z10_8_XX_14 { get; set; }


        #endregion

        #region Z10.9

        /// <summary>
        /// 健康评价异常标志。1无异常 2有异常
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.9/XX.1", "健康评价异常标志")]
        public string Z10_Z10_9_XX_1 { get; set; }
        /// <summary>
        /// 健康评价异常描述1
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.9/XX.2", "健康评价异常描述1")]
        public string Z10_Z10_9_XX_2 { get; set; }
        /// <summary>
        /// 健康评价异常描述3
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.9/XX.3", "健康评价异常描述3")]
        public string Z10_Z10_9_XX_3 { get; set; }
        /// <summary>
        /// 健康评价异常描述4
        /// </summary>
        [HL7Filed("XX.4", "Z10/Z10.9/XX.4", "健康评价异常描述4")]
        public string Z10_Z10_9_XX_4 { get; set; }
        /// <summary>
        /// 健康评价异常描述5
        /// </summary>
        [HL7Filed("XX.5", "Z10/Z10.9/XX.5", "健康评价异常描述5")]
        public string Z10_Z10_9_XX_5 { get; set; }
        /// <summary>
        /// 健康评价异常描述6
        /// </summary>
        [HL7Filed("XX.6", "Z10/Z10.9/XX.6", "健康评价异常描述6")]
        public string Z10_Z10_9_XX_6 { get; set; }
        /// <summary>
        /// 健康评价异常描述7
        /// </summary>
        [HL7Filed("XX.7", "Z10/Z10.9/XX.7", "健康评价异常描述7")]
        public string Z10_Z10_9_XX_7 { get; set; }
        /// <summary>
        /// 健康评价异常描述8
        /// </summary>
        [HL7Filed("XX.8", "Z10/Z10.9/XX.8", "健康评价异常描述8")]
        public string Z10_Z10_9_XX_8 { get; set; }
        /// <summary>
        /// 健康评价异常描述9
        /// </summary>
        [HL7Filed("XX.9", "Z10/Z10.9/XX.9", "健康评价异常描述9")]
        public string Z10_Z10_9_XX_9 { get; set; }
        /// <summary>
        /// 健康评价异常描述10
        /// </summary>
        [HL7Filed("XX.10", "Z10/Z10.9/XX.10", "健康评价异常描述10")]
        public string Z10_Z10_9_XX_10 { get; set; }
        /// <summary>
        /// 健康评价异常描述11
        /// </summary>
        [HL7Filed("XX.11", "Z10/Z10.9/XX.11", "健康评价异常描述11")]
        public string Z10_Z10_9_XX_11 { get; set; }

        #endregion

        #region Z10.10

        /// <summary>
        /// 健康指导代码。1纳人慢性病患者健康管理 2建议复查 3建议转诊
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.9/XX.1", "健康指导代码")]
        public string Z10_Z10_10_XX_1 { get; set; }
        /// <summary>
        /// 危险因素控制建议代码。1.戒烟 2.健康饮酒 3.饮食 4.锻炼 5.减体重 6.建议接种疫苗 7.其他
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.9/XX.2", "危险因素控制建议代码")]
        public string Z10_Z10_10_XX_2 { get; set; }
        /// <summary>
        /// 减体重目标
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.9/XX.3", "减体重目标")]
        public string Z10_Z10_10_XX_3 { get; set; }
        /// <summary>
        /// 建议接种疫苗名称
        /// </summary>
        [HL7Filed("XX.4", "Z10/Z10.9/XX.4", "建议接种疫苗名称")]
        public string Z10_Z10_10_XX_4 { get; set; }

        #endregion

        #region Z10.14

        /// <summary>
        /// 非免疫规划预防接种史相关信息
        /// </summary>
        [HL7Filed("", "Z10/Z10.14", "非免疫规划预防接种史相关信息", IsArray = true, ObjectIndex = 1)]
        public List<ZAP_Z10_Z10_14> Z10_14_List { get; set; }

        #endregion

        #region Z10.15

        /// <summary>
        /// 实验室检查相关信息
        /// </summary>
        [HL7Filed("", "Z10/Z10.15", "实验室检查相关信息", IsArray = true, ObjectIndex = 2)]
        public List<ZAP_Z10_Z10_15> Z10_15_List { get; set; }

        #endregion

        #region Z10.16

        /// <summary>
        /// 接触史相关信息的信息段
        /// </summary>
        [HL7Filed("", "Z10/Z10.16", "接触史相关信息的信息段", IsArray = true, ObjectIndex = 3)]
        public List<ZAP_Z10_Z10_16> Z10_16_List { get; set; }

        #endregion

        #region Z10.19

        /// <summary>
        /// 胰岛素用药情况相关信息
        /// </summary>
        [HL7Filed("", "Z10/Z10.19", "胰岛素用药情况相关信息", IsArray = true, ObjectIndex = 4)]
        public List<ZAP_Z10_Z10_19> Z10_19_List { get; set; }

        #endregion

        #endregion
    }

    /// <summary>
    /// 非免疫规划预防接种史相关信息
    /// </summary>
    public class ZAP_Z10_Z10_14 : IHL7ArrayItem
    {
        /// <summary>
        /// 疫苗代码
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.14/XX.1", "疫苗代码")]
        public string Z10_Z10_14_XX_1 { get; set; }
        /// <summary>
        /// 疫苗名称
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.14/XX.2", "疫苗名称")]
        public string Z10_Z10_14_XX_2 { get; set; }
        /// <summary>
        /// 接种日期
        /// </summary>
        [HL7Filed("XX.3", "Z10/Z10.14/XX.3", "接种日期")]
        public string Z10_Z10_14_XX_3 { get; set; }
        /// <summary>
        /// 接种机构名称
        /// </summary>
        [HL7Filed("XX.4", "Z10/Z10.14/XX.4", "接种机构名称")]
        public string Z10_Z10_14_XX_4 { get; set; }
    }

    /// <summary>
    /// 实验室检查相关信息
    /// </summary>
    public class ZAP_Z10_Z10_15 : IHL7ArrayItem
    {
        /// <summary>
        /// 检测项目大类名称
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.15/XX.2", "检测项目大类名称")]
        public string Z10_Z10_15_XX_2 { get; set; }
        /// <summary>
        /// 检测指标名称
        /// </summary>
        [HL7Filed("XX.6", "Z10/Z10.15/XX.6", "检测指标名称")]
        public string Z10_Z10_15_XX_6 { get; set; }
        /// <summary>
        /// 检测指标结果
        /// </summary>
        [HL7Filed("XX.9", "Z10/Z10.15/XX.9", "检测指标结果")]
        public string Z10_Z10_15_XX_9 { get; set; }
        /// <summary>
        /// 拒检标志
        /// </summary>
        [HL7Filed("XX.20", "Z10/Z10.15/XX.20", "拒检标志")]
        public string Z10_Z10_15_XX_20 { get; set; }
    }

    /// <summary>
    /// 接触史相关信息的信息段
    /// </summary>
    public class ZAP_Z10_Z10_16 : IHL7ArrayItem
    {
        /// <summary>
        /// 有无接触史。1无 2有
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.16/XX.1", "有无接触史")]
        public string Z10_Z10_16_XX_1 { get; set; }
        /// <summary>
        /// 粉尘防护措施有无。1无 2有
        /// </summary>
        [HL7Filed("XX.6", "Z10/Z10.16/XX.6", "粉尘防护措施有无")]
        public string Z10_Z10_16_XX_6 { get; set; }
        /// <summary>
        /// 放射物质防护措施有无。1无 2有
        /// </summary>
        [HL7Filed("XX.9", "Z10/Z10.16/XX.9", "放射物质防护措施有无")]
        public string Z10_Z10_16_XX_9 { get; set; }
        /// <summary>
        /// 物理因素防护措施有无。1无 2有
        /// </summary>
        [HL7Filed("XX.12", "Z10/Z10.16/XX.12", "物理因素防护措施有无")]
        public string Z10_Z10_16_XX_12 { get; set; }
        /// <summary>
        /// 化学物质防护措施有无。1无 2有
        /// </summary>
        [HL7Filed("XX.15", "Z10/Z10.16/XX.15", "化学物质防护措施有无")]
        public string Z10_Z10_16_XX_15 { get; set; }
    }

    /// <summary>
    /// 胰岛素用药情况相关信息
    /// </summary>
    public class ZAP_Z10_Z10_19 : IHL7ArrayItem
    {
        /// <summary>
        /// 胰岛素-种类
        /// </summary>
        [HL7Filed("XX.1", "Z10/Z10.19/XX.1", "胰岛素-种类")]
        public string Z10_Z10_19_XX_1 { get; set; }
        /// <summary>
        /// 粉胰岛素用量-早餐
        /// </summary>
        [HL7Filed("XX.2", "Z10/Z10.19/XX.2", "胰岛素用量-早餐")]
        public string Z10_Z10_19_XX_2 { get; set; }
    }
}
