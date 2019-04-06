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
using System.Linq;
using System.Text;

namespace HL7Lib.Base
{
    /// <summary>
    /// ComponentID Class: Creates a ComponentID object
    /// </summary>
    public class ComponentID
    {
        /// <summary>
        /// The SegmentName of the Component ID string
        /// </summary>
        public string SegmentName { get; set; }
        /// <summary>
        /// The FieldIndex of the Component ID string
        /// </summary>
        public int FieldIndex {get;set;}
        /// <summary>
        /// The ComponentIndex of the Component ID string
        /// </summary>
        public int ComponentIndex { get; set; }

        /// <summary>返回表示当前 <see cref="T:System.Object" /> 的 <see cref="T:System.String" />。</summary>
        /// <returns>
        /// <see cref="T:System.String" />，表示当前的 <see cref="T:System.Object" />。</returns>
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", this.SegmentName, this.FieldIndex, this.ComponentIndex);
        }
    }
}
