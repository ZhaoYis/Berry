#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SY.HL7.Parser.Base
* 项目描述 ：
* 类 名 称 ：BaseEntity
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：SY.HL7.Parser.Base
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/6 23:33:45
* 更新时间 ：2019/3/6 23:33:45
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
    /// 功能描述    ：BaseEntity  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/6 23:33:45 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/6 23:33:45 
    /// </summary>
    public class BaseEntity : IHL7ArrayItem
    {
        /// <summary>
        /// 根节点名称
        /// </summary>
        public string Root { get; set; }
    }
}
