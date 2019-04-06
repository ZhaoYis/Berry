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
using HL7Lib.Base;

namespace HL7Lib.Segments
{
    /// <summary>
    /// BLC Class: Constructs an HL7 BLC Segment Object
    /// </summary>
    public class BLC
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Field> Fields { get; set; }

        public BLC()
        {
            Name = "BLC";
            Description = "Blood Code";
            List<Field> fs = new List<Field>();
            fs.Add(Field.SegName());
            fs.Add(BLC1());
            fs.Add(BLC2());
            Fields = fs;
        }
        private Field BLC1()
        {
            Field f = new Field("Blood Product Code");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "BLC-1.1"));
            c.Add(new Component("", "BLC-1.2"));
            c.Add(new Component("Name of Coding System", "BLC-1.3"));
            c.Add(new Component("Alternate Identifier", "BLC-1.4"));
            c.Add(new Component("Alternate Text", "BLC-1.5"));
            c.Add(new Component("Name of Alternate Coding System", "BLC-1.6"));
            f.Components = c;
            return f;
        }
        private Field BLC2()
        {
            Field f = new Field("Blood Amount");
            List<Component> c = new List<Component>();
            c.Add(new Component("Quantity", "BLC-2.1"));
            c.Add(new Component("Units", "BLC-2.2"));
            f.Components = c;
            return f;
        }
    }
}
