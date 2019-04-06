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
    /// Parse Field Class: Used to store and manage Field information for parsing an HL7 message
    /// </summary>
    public class ParseField : IComparable<ParseField>
    {
        /// <summary>
        /// The FieldIndex of the Field from the HL7 message
        /// </summary>
        public int FieldIndex { get; set; }
        /// <summary>
        /// The FieldOrder used in inserting a repeating field into an HL7 segment
        /// </summary>
        public int FieldOrder { get; set; }
        /// <summary>
        /// The RepeatedField used to determine if a field is a repeating field
        /// </summary>
        public bool RepeatedField { get; set; }
        /// <summary>
        /// The FieldValues used to set the component values of this field
        /// </summary>
        public List<ParseComponent> FieldValues { get; set; }
        /// <summary>
        /// ParseField Constructor: Creates a new ParseField object
        /// </summary>
        /// <param name="Index">The Index to set to this ParseField objects FieldIndex property</param>
        /// <param name="Order">The Order to set to this ParseField objects FieldOrder property</param>
        /// <param name="Repeated">The Repeated to set to this ParseField objects RepeatedField property</param>
        /// <param name="Values">The Values to set to this ParseField objects FieldValues property</param>
        public ParseField(int Index, int Order, bool Repeated, List<ParseComponent> Values)
        {
            FieldIndex = Index;
            RepeatedField = Repeated;
            FieldValues = Values;
            FieldOrder = Order;
        }
        /// <summary>
        /// Sorts a list of objects in reverse FieldIndex order
        /// </summary>
        /// <param name="obj">The ParseField object to compare</param>
        /// <returns>Returns a 1 if the first objects FieldIndex is greater than the second objects else it returns a 0</returns>
        public int CompareTo(ParseField obj)
        {
            if (this.FieldIndex > obj.FieldIndex)
                return 1;
            else
                return 0;                        
        }
    }
}
