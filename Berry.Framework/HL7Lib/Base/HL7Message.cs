/***************************************************************
* Copyright (C) 2011 Jeremy Reagan, All Rights Reserved.
* I may be reached via email at: jeremy.reagan@live.com
* 
* This program is free software; you can redistribute it and/or
* modify it under the terms of the GNU General Public License
* as published by the Free Software Foundation; under version 2
* of the License.
* 
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
****************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace HL7Lib.Base
{
    /// <summary>
    /// Message Class: Constructs an HL7 message object from a string
    /// </summary>
    public class HL7Message
    {
        #region 字段信息

        private string FSeperator = "|";
        private string CSeperator = "^";
        private string FRSeperator = "~";
        private string SCSeperator = "&";
        private string ECharacter = "\\";

        /// <summary>
        /// HL7消息字段分隔符字符串
        /// </summary>
        public string FieldSeperator
        {
            get { return FSeperator; }
            set { FSeperator = value; }
        }
        /// <summary>
        /// HL7消息组件分隔符字符串
        /// </summary>
        public string ComponentSeperator
        {
            get { return CSeperator; }
            set { CSeperator = value; }
        }
        /// <summary>
        /// HL7消息子组件分隔符字符串
        /// </summary>
        public string SubComponentSeperator
        {
            get { return SCSeperator; }
            set { SCSeperator = value; }
        }
        /// <summary>
        /// HL7消息重复域分隔符字符串
        /// </summary>
        public string FieldRepeatSeperator
        {
            get { return FRSeperator; }
            set { FRSeperator = value; }
        }
        /// <summary>
        /// HL7消息转义字符分隔符字符串
        /// </summary>
        public string EscapeCharacter
        {
            get { return ECharacter; }
            set { ECharacter = value; }
        } 
        #endregion

        /// <summary>
        /// HL7消息中的段列表
        /// </summary>
        public List<Segment> Segments { get; set; }

        /// <summary>
        /// HL7报文段名列表
        /// </summary>
        public List<string> SegmentNames { get; set; }

        /// <summary>
        /// 为显示而格式化的HL7消息字符串
        /// </summary>
        public string DisplayString { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public HL7Message() { }

        /// <summary>
        /// 从HL7消息字符串构造HL7消息
        /// </summary>
        /// <param name="HL7Message">HL7消息字符串</param>
        public HL7Message(string HL7Message)
        {
            Segments = new List<Segment>();
            SegmentNames = new List<string>();
            Parse(HL7Message);
        }
        /// <summary>
        /// 解析HL7消息字符串并从中创建段列表
        /// </summary>
        /// <param name="HL7Message">The HL7 message string</param>
        public void Parse(string HL7Message)
        {
            string[] segments = HL7Message.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string segment in segments)
            {
                string seg = segment;
                if (seg.IndexOf(FSeperator) > -1)
                {
                    DisplayString += segment + "\r\n";

                    if (!String.IsNullOrEmpty(seg.Trim()))
                    {
                        string segmentName = SetSegName(seg);
                        if (segmentName == "MSH")
                        {
                            FSeperator = seg.Substring(3, 1);
                            CSeperator = seg.Substring(4, 1);
                            FRSeperator = seg.Substring(5, 1);
                            ECharacter = seg.Substring(6, 1);
                            SCSeperator = seg.Substring(7, 1);
                            seg = seg.Insert(4, FSeperator);
                        }
                        SetFields(seg, segmentName);
                    }
                }
            }
        }
        /// <summary>
        /// 设置单个段的字段
        /// </summary>
        /// <param name="seg">The Segment string</param>
        /// <param name="SegmentName">The Segment name</param>
        private void SetFields(string seg, string SegmentName)
        {
            string[] fields = seg.Split(new string[] { FSeperator }, StringSplitOptions.None);
            List<ParseField> l = new List<ParseField>();
            for (int i = 0; i < fields.Length; i++)
            {
                string[] repeatedFields = fields.GetValue(i).ToString().Split(new string[] { FRSeperator }, StringSplitOptions.None);
                for (int y = 0; y < repeatedFields.Length; y++)
                {
                    string[] components = repeatedFields[y].Split(new string[] { CSeperator }, StringSplitOptions.None);
                    List<ParseComponent> values = new List<ParseComponent>();
                    for (int x = 0; x < components.Length; x++)
                    {
                        string v = components.GetValue(x).ToString();
                        if (v.Trim().Length > 0 && v.Replace("\"\"", "").Trim().Length > 0)
                            values.Add(new ParseComponent(x, v));
                    }
                    l.Add(new ParseField(i, y, (y == 0) ? false : true, values));
                }
            }
            SetSegment(SegmentName, l);
        }
        /// <summary>
        /// 根据段名调用parse hl7段方法之一
        /// </summary>
        /// <param name="SegmentName">The Segment Name to Parse</param>
        /// <param name="l">The List of objects</param>
        private void SetSegment(string SegmentName, List<ParseField> l)//List<List<string>> l)
        {
            switch (SegmentName)
            {
                case "ABS": Segments.Add(ParseStandard(l, Base.Segments.ABS)); break;
                case "ACC": Segments.Add(ParseStandard(l, Base.Segments.ACC)); break;
                case "ADD": Segments.Add(ParseStandard(l, Base.Segments.ADD)); break;
                case "AFF": Segments.Add(ParseStandard(l, Base.Segments.AFF)); break;
                case "AIG": Segments.Add(ParseStandard(l, Base.Segments.AIG)); break;
                case "AIL": Segments.Add(ParseStandard(l, Base.Segments.AIL)); break;
                case "AIP": Segments.Add(ParseStandard(l, Base.Segments.AIP)); break;
                case "AIS": Segments.Add(ParseStandard(l, Base.Segments.AIS)); break;
                case "AL1": Segments.Add(ParseStandard(l, Base.Segments.AL1)); break;
                case "APR": Segments.Add(ParseStandard(l, Base.Segments.APR)); break;
                case "ARQ": Segments.Add(ParseStandard(l, Base.Segments.ARQ)); break;
                case "AUT": Segments.Add(ParseStandard(l, Base.Segments.AUT)); break;
                case "BHS": Segments.Add(ParseStandard(l, Base.Segments.BHS)); break;
                case "BLC": Segments.Add(ParseStandard(l, Base.Segments.BLC)); break;
                case "BLG": Segments.Add(ParseStandard(l, Base.Segments.BLG)); break;
                case "BPO": Segments.Add(ParseStandard(l, Base.Segments.BPO)); break;
                case "BPX": Segments.Add(ParseStandard(l, Base.Segments.BPX)); break;
                case "BTS": Segments.Add(ParseStandard(l, Base.Segments.BTS)); break;
                case "BTX": Segments.Add(ParseStandard(l, Base.Segments.BTX)); break;
                case "CDM": Segments.Add(ParseStandard(l, Base.Segments.CDM)); break;
                case "CER": Segments.Add(ParseStandard(l, Base.Segments.CER)); break;
                case "CM0": Segments.Add(ParseStandard(l, Base.Segments.CM0)); break;
                case "CM1": Segments.Add(ParseStandard(l, Base.Segments.CM1)); break;
                case "CM2": Segments.Add(ParseStandard(l, Base.Segments.CM2)); break;
                case "CNS": Segments.Add(ParseStandard(l, Base.Segments.CNS)); break;
                case "CON": Segments.Add(ParseStandard(l, Base.Segments.CON)); break;
                case "CSP": Segments.Add(ParseStandard(l, Base.Segments.CSP)); break;
                case "CSR": Segments.Add(ParseStandard(l, Base.Segments.CSR)); break;
                case "CSS": Segments.Add(ParseStandard(l, Base.Segments.CSS)); break;
                case "CTD": Segments.Add(ParseStandard(l, Base.Segments.CTD)); break;
                case "CTI": Segments.Add(ParseStandard(l, Base.Segments.CTI)); break;
                case "DB1": Segments.Add(ParseStandard(l, Base.Segments.DB1)); break;
                case "DG1": Segments.Add(ParseStandard(l, Base.Segments.DG1)); break;
                case "DRG": Segments.Add(ParseStandard(l, Base.Segments.DRG)); break;
                case "DSC": Segments.Add(ParseStandard(l, Base.Segments.DSC)); break;
                case "DSP": Segments.Add(ParseStandard(l, Base.Segments.DSP)); break;
                case "ECD": Segments.Add(ParseStandard(l, Base.Segments.ECD)); break;
                case "ECR": Segments.Add(ParseStandard(l, Base.Segments.ECR)); break;
                case "EDU": Segments.Add(ParseStandard(l, Base.Segments.EDU)); break;
                case "EQL": Segments.Add(ParseStandard(l, Base.Segments.EQL)); break;
                case "EQP": Segments.Add(ParseStandard(l, Base.Segments.EQP)); break;
                case "EQU": Segments.Add(ParseStandard(l, Base.Segments.EQU)); break;
                case "ERQ": Segments.Add(ParseStandard(l, Base.Segments.ERQ)); break;
                case "ERR": Segments.Add(ParseStandard(l, Base.Segments.ERR)); break;
                case "EVN": Segments.Add(ParseStandard(l, Base.Segments.EVN)); break;
                case "FAC": Segments.Add(ParseStandard(l, Base.Segments.FAC)); break;
                case "FHS": Segments.Add(ParseStandard(l, Base.Segments.FHS)); break;
                case "FT1": Segments.Add(ParseStandard(l, Base.Segments.FT1)); break;
                case "FTS": Segments.Add(ParseStandard(l, Base.Segments.FTS)); break;
                case "GOL": Segments.Add(ParseStandard(l, Base.Segments.GOL)); break;
                case "GP1": Segments.Add(ParseStandard(l, Base.Segments.GP1)); break;
                case "GP2": Segments.Add(ParseStandard(l, Base.Segments.GP2)); break;
                case "GT1": Segments.Add(ParseStandard(l, Base.Segments.GT1)); break;
                case "IAM": Segments.Add(ParseStandard(l, Base.Segments.IAM)); break;
                case "IIM": Segments.Add(ParseStandard(l, Base.Segments.IIM)); break;
                case "IN1": Segments.Add(ParseStandard(l, Base.Segments.IN1)); break;
                case "IN2": Segments.Add(ParseStandard(l, Base.Segments.IN2)); break;
                case "IN3": Segments.Add(ParseStandard(l, Base.Segments.IN3)); break;
                case "INV": Segments.Add(ParseStandard(l, Base.Segments.INV)); break;
                case "IPC": Segments.Add(ParseStandard(l, Base.Segments.IPC)); break;
                case "ISD": Segments.Add(ParseStandard(l, Base.Segments.ISD)); break;
                case "LAN": Segments.Add(ParseStandard(l, Base.Segments.LAN)); break;
                case "LCC": Segments.Add(ParseStandard(l, Base.Segments.LCC)); break;
                case "LCH": Segments.Add(ParseStandard(l, Base.Segments.LCH)); break;
                case "LDP": Segments.Add(ParseStandard(l, Base.Segments.LDP)); break;
                case "LOC": Segments.Add(ParseStandard(l, Base.Segments.LOC)); break;
                case "LRL": Segments.Add(ParseStandard(l, Base.Segments.LRL)); break;
                case "MFA": Segments.Add(ParseStandard(l, Base.Segments.MFA)); break;
                case "MFE": Segments.Add(ParseStandard(l, Base.Segments.MFE)); break;
                case "MFI": Segments.Add(ParseStandard(l, Base.Segments.MFI)); break;
                case "MRG": Segments.Add(ParseStandard(l, Base.Segments.MRG)); break;
                case "MSA": Segments.Add(ParseStandard(l, Base.Segments.MSA)); break;
                case "MSH": Segments.Add(ParseMSH(l)); break;
                case "NCK": Segments.Add(ParseStandard(l, Base.Segments.NCK)); break;
                case "NDS": Segments.Add(ParseStandard(l, Base.Segments.NDS)); break;
                case "NK1": Segments.Add(ParseStandard(l, Base.Segments.NK1)); break;
                case "NPU": Segments.Add(ParseStandard(l, Base.Segments.NPU)); break;
                case "NSC": Segments.Add(ParseStandard(l, Base.Segments.NSC)); break;
                case "NST": Segments.Add(ParseStandard(l, Base.Segments.NST)); break;
                case "NTE": Segments.Add(ParseStandard(l, Base.Segments.NTE)); break;
                case "OBR": Segments.Add(ParseStandard(l, Base.Segments.OBR)); break;
                case "OBX": Segments.Add(ParseStandard(l, Base.Segments.OBX)); break;
                case "ODS": Segments.Add(ParseStandard(l, Base.Segments.ODS)); break;
                case "ODT": Segments.Add(ParseStandard(l, Base.Segments.ODT)); break;
                case "OM1": Segments.Add(ParseStandard(l, Base.Segments.OM1)); break;
                case "OM2": Segments.Add(ParseStandard(l, Base.Segments.OM2)); break;
                case "OM3": Segments.Add(ParseStandard(l, Base.Segments.OM3)); break;
                case "OM4": Segments.Add(ParseStandard(l, Base.Segments.OM4)); break;
                case "OM5": Segments.Add(ParseStandard(l, Base.Segments.OM5)); break;
                case "OM6": Segments.Add(ParseStandard(l, Base.Segments.OM6)); break;
                case "OM7": Segments.Add(ParseStandard(l, Base.Segments.OM7)); break;
                case "ORC": Segments.Add(ParseStandard(l, Base.Segments.ORC)); break;
                case "ORG": Segments.Add(ParseStandard(l, Base.Segments.ORG)); break;
                case "OVR": Segments.Add(ParseStandard(l, Base.Segments.OVR)); break;
                case "PCR": Segments.Add(ParseStandard(l, Base.Segments.PCR)); break;
                case "PD1": Segments.Add(ParseStandard(l, Base.Segments.PD1)); break;
                case "PDA": Segments.Add(ParseStandard(l, Base.Segments.PDA)); break;
                case "PDC": Segments.Add(ParseStandard(l, Base.Segments.PDC)); break;
                case "PEO": Segments.Add(ParseStandard(l, Base.Segments.PEO)); break;
                case "PES": Segments.Add(ParseStandard(l, Base.Segments.PES)); break;
                case "PID": Segments.Add(ParseStandard(l, Base.Segments.PID)); break;
                case "PR1": Segments.Add(ParseStandard(l, Base.Segments.PR1)); break;
                case "PRA": Segments.Add(ParseStandard(l, Base.Segments.PRA)); break;
                case "PRB": Segments.Add(ParseStandard(l, Base.Segments.PRB)); break;
                case "PRC": Segments.Add(ParseStandard(l, Base.Segments.PRC)); break;
                case "PRD": Segments.Add(ParseStandard(l, Base.Segments.PRD)); break;
                case "PSH": Segments.Add(ParseStandard(l, Base.Segments.PSH)); break;
                case "PTH": Segments.Add(ParseStandard(l, Base.Segments.PTH)); break;
                case "PV1": Segments.Add(ParseStandard(l, Base.Segments.PV1)); break;
                case "PV2": Segments.Add(ParseStandard(l, Base.Segments.PV2)); break;
                case "QAK": Segments.Add(ParseStandard(l, Base.Segments.QAK)); break;
                case "QID": Segments.Add(ParseStandard(l, Base.Segments.QID)); break;
                case "QPD": Segments.Add(ParseStandard(l, Base.Segments.QPD)); break;
                case "QRD": Segments.Add(ParseStandard(l, Base.Segments.QRD)); break;
                case "QRF": Segments.Add(ParseStandard(l, Base.Segments.QRF)); break;
                case "QRI": Segments.Add(ParseStandard(l, Base.Segments.QRI)); break;
                case "RCP": Segments.Add(ParseStandard(l, Base.Segments.RCP)); break;
                case "RDF": Segments.Add(ParseStandard(l, Base.Segments.RDF)); break;
                case "RF1": Segments.Add(ParseStandard(l, Base.Segments.RF1)); break;
                case "RGS": Segments.Add(ParseStandard(l, Base.Segments.RGS)); break;
                case "RMI": Segments.Add(ParseStandard(l, Base.Segments.RMI)); break;
                case "ROL": Segments.Add(ParseStandard(l, Base.Segments.ROL)); break;
                case "RQ1": Segments.Add(ParseStandard(l, Base.Segments.RQ1)); break;
                case "RQD": Segments.Add(ParseStandard(l, Base.Segments.RQD)); break;
                case "RXA": Segments.Add(ParseStandard(l, Base.Segments.RXA)); break;
                case "RXC": Segments.Add(ParseStandard(l, Base.Segments.RXC)); break;
                case "RXD": Segments.Add(ParseStandard(l, Base.Segments.RXD)); break;
                case "RXE": Segments.Add(ParseStandard(l, Base.Segments.RXE)); break;
                case "RXG": Segments.Add(ParseStandard(l, Base.Segments.RXG)); break;
                case "RXO": Segments.Add(ParseStandard(l, Base.Segments.RXO)); break;
                case "RXR": Segments.Add(ParseStandard(l, Base.Segments.RXR)); break;
                case "SAC": Segments.Add(ParseStandard(l, Base.Segments.SAC)); break;
                case "SCH": Segments.Add(ParseStandard(l, Base.Segments.SCH)); break;
                case "SFT": Segments.Add(ParseStandard(l, Base.Segments.SFT)); break;
                case "SID": Segments.Add(ParseStandard(l, Base.Segments.SID)); break;
                case "SPM": Segments.Add(ParseStandard(l, Base.Segments.SPM)); break;
                case "SPR": Segments.Add(ParseStandard(l, Base.Segments.SPR)); break;
                case "STF": Segments.Add(ParseStandard(l, Base.Segments.STF)); break;
                case "TCC": Segments.Add(ParseStandard(l, Base.Segments.TCC)); break;
                case "TCD": Segments.Add(ParseStandard(l, Base.Segments.TCD)); break;
                case "TQ1": Segments.Add(ParseStandard(l, Base.Segments.TQ1)); break;
                case "TQ2": Segments.Add(ParseStandard(l, Base.Segments.TQ2)); break;
                case "TXA": Segments.Add(ParseStandard(l, Base.Segments.TXA)); break;
                case "UB1": Segments.Add(ParseStandard(l, Base.Segments.UB1)); break;
                case "UB2": Segments.Add(ParseStandard(l, Base.Segments.UB2)); break;
                case "URD": Segments.Add(ParseStandard(l, Base.Segments.URD)); break;
                case "URS": Segments.Add(ParseStandard(l, Base.Segments.URS)); break;
                case "VAR": Segments.Add(ParseStandard(l, Base.Segments.VAR)); break;
                case "VTQ": Segments.Add(ParseStandard(l, Base.Segments.VTQ)); break;
                default: Segments.Add(ParseCustom(l, SegmentName)); break;
            }
        }
        /// <summary>
        /// 设置指定段的段名称
        /// </summary>
        /// <param name="seg">The segment to parse</param>
        /// <returns>The segment name</returns>
        private string SetSegName(string seg)
        {
            string segmentName = seg.Substring(0, seg.IndexOf(FSeperator)).ToUpper();
            if (!SegmentNames.Contains(segmentName))
                SegmentNames.Add(segmentName);
            return segmentName;
        }

        #region Parse HL7 Segment Methods
        /// <summary>
        /// Parses a custom (Z) segment from the message string
        /// </summary>
        /// <param name="HL7Segment">The fields and components from the custom segment string</param>
        /// <param name="SegName">The segment name to use</param>
        /// <returns>Returns a custom segment after processing</returns>
        private Segment ParseCustom(List<ParseField> HL7Segment, string SegName)
        {
            List<Field> fields = new List<Field>();
            Segment s = new Segment();
            s.Name = SegName;
            s.Description = "Custom Segment";
            for (int i = 0; i < HL7Segment.Count; i++)
            {
                List<Component> components = new List<Component>();
                Field f = new Field(String.Format("Field {0}", i));

                if (HL7Segment[i].FieldValues.Count > 0)
                {
                    for (int x = 0; x < HL7Segment[i].FieldValues.Count; x++)
                    {
                        try
                        {
                            Component c = new Component(String.Format("Component {0}", (x + 1)));
                            c.ID = String.Format("{0}-{1}.{2}", SegName, i, (x + 1));
                            c.Value = HL7Segment[i].FieldValues[x].ComponentValue.UnEscape(EscapeCharacter);
                            components.Add(c);
                        }
                        catch (ArgumentOutOfRangeException) { }
                        catch (IndexOutOfRangeException) { }
                    }
                }
                else
                {
                    Component c = new Component(String.Format("Component {0}", (1)));
                    c.ID = String.Format("{0}-{1}.{2}", SegName, i, (1));
                    c.Value = "";
                    components.Add(c);
                }
                f.Components = components;
                fields.Add(f);
            }
            s.Fields = fields;
            return s;
        }
        /// <summary>
        /// Parses a standard segment, this is the main processing method for most segments
        /// </summary>
        /// <param name="HL7Segment">The fields and components from the standard segment string</param>
        /// <param name="seg">The Segments enum object to use for this segment</param>
        /// <returns>Returns a standard segment after processing</returns>
        private Segment ParseStandard(List<ParseField> HL7Segment, Base.Segments seg)
        {
            Segment s = new Segment(seg);
            List<ParseField> standardFields = HL7Segment.FindAll(delegate(ParseField f) { return f.RepeatedField == false; });
            List<ParseField> repeatedFields = HL7Segment.FindAll(delegate(ParseField f) { return f.RepeatedField == true; });
            if (standardFields.Count > 0)
                AddStandard(standardFields, s);
            if (repeatedFields.Count > 0)
                AddRepeated(repeatedFields, s);
            return s;
        }
        /// <summary>
        /// Parses an MSH segment from the message string
        /// </summary>
        /// <param name="HL7Segment">The fields and components from the MSH segment string</param>
        /// <returns>Returns an MSH segment after processing</returns>
        private Segment ParseMSH(List<ParseField> HL7Segment)
        {
            Segment s = new Segment(Base.Segments.MSH);
            List<ParseField> standardFields = HL7Segment.FindAll(delegate(ParseField f) { return f.RepeatedField == false; });
            if (standardFields.Count > 0)
                AddStandard(standardFields, s);
            s.Fields[1].Components[0].Value = "|";
            s.Fields[2].Components[0].Value = CSeperator + FRSeperator + ECharacter + SCSeperator;
            return s;
        }
        /// <summary>
        /// Adds a standard field and component to the specified segment
        /// </summary>
        /// <param name="standardFields">The standard field and components for the specified segment</param>
        /// <param name="s">The segment to add to</param>
        private void AddStandard(List<ParseField> standardFields, Segment s)
        {
            foreach (ParseField field in standardFields)
            {
                foreach (ParseComponent component in field.FieldValues)
                {
                    try
                    {
                        s.Fields[field.FieldIndex].Components[component.ComponentIndex].Value = component.ComponentValue.UnEscape(EscapeCharacter);
                        s.Fields[field.FieldIndex].Components[component.ComponentIndex].ID = s.Name + "-" + field.FieldIndex + "." + (component.ComponentIndex + 1);
                    }
                    catch (ArgumentOutOfRangeException) { }
                    catch (IndexOutOfRangeException) { }
                }
            }
        }
        /// <summary>
        /// Adds a repeated field and component to the specified segment
        /// </summary>
        /// <param name="repeatedFields">The repeated field and components for the specified segment</param>
        /// <param name="s">The segment to add to</param>
        private void AddRepeated(List<ParseField> repeatedFields, Segment s)
        {
            try
            {
                repeatedFields.Sort();
                foreach (ParseField field in repeatedFields)
                {
                    Field f = new Field(s.Fields[field.FieldIndex].Name);
                    f.Components = new List<Component>();
                    foreach (Component segCom in s.Fields[field.FieldIndex].Components)
                    {
                        Component c = new Component();
                        c.Name = segCom.Name;
                        c.ID = segCom.ID;
                        f.Components.Add(c);
                    }
                    foreach (ParseComponent component in field.FieldValues)
                        f.Components[component.ComponentIndex].Value = component.ComponentValue;
                    s.Fields.Insert(field.FieldIndex + field.FieldOrder, f);
                }
            }
            catch (ArgumentOutOfRangeException) { }
            catch (IndexOutOfRangeException) { }
        }
        #endregion
    }
}