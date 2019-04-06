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
    /// ParseComponent Class: Creates a Component value object
    /// </summary>
    public class ParseComponent
    {
        /// <summary>
        /// The ComponentIndex of this component value object
        /// </summary>
        public int ComponentIndex { get; set; }
        /// <summary>
        /// The ComponentValue of this component value object
        /// </summary>
        public string ComponentValue { get; set; }
        /// <summary>
        /// ParseComponent Constructor: Constructs a ParseComponent object
        /// </summary>
        /// <param name="Index">The Index of this instance of the ParseComponent</param>
        /// <param name="Value">The Value of this instance of the ParseComponent</param>
        public ParseComponent(int Index, string Value)
        {
            ComponentIndex = Index;
            ComponentValue = Value;
        }
    }
}
