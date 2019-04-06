#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SY.HL7.Parser.Base
* 项目描述 ：
* 类 名 称 ：HL7FiledAttribute
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：SY.HL7.Parser.Base
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/6 23:34:06
* 更新时间 ：2019/3/6 23:34:06
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

namespace SY.HL7.Parser.Base
{
    /// <summary>
    /// 功能描述    ：HL7FiledAttribute  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/6 23:34:06 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/6 23:34:06 
    /// </summary>
    public class HL7FiledAttribute : Attribute
    {
        /// <summary>
        /// 字段原始名称
        /// </summary>
        public string FiledName { get; set; }

        /// <summary>
        /// XPath
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// 字段描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 字段是否数组
        /// </summary>
        public bool IsArray { get; set; }

        /// <summary>
        /// 需要索引第几个对象。如果是一个对象内又多个数组，解析时泛型索引必须和这个索引一致，否则可能导致无法解析。
        /// </summary>
        public int ObjectIndex { get; set; }

        public HL7FiledAttribute(string name, string path, string desc)
        {
            this.FiledName = name;
            this.XPath = path;
            this.Desc = desc;
            this.IsArray = false;
        }
    }
}
