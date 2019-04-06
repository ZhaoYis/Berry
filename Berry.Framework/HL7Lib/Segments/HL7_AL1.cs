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
    /// AL1 Class: Constructs an HL7 AL1 Segment Object
    /// </summary>
    public class AL1
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Field> Fields { get; set; }

        public AL1()
        {
            Name = "AL1";
            Description = "Patient Allergy Information";
            List<Field> fs = new List<Field>();
            fs.Add(Field.SegName());
            fs.Add(AL11());
            fs.Add(AL12());
            fs.Add(AL13());
            fs.Add(AL14());
            fs.Add(AL15());
            fs.Add(AL16());
            Fields = fs;
        }
        private Field AL11()
        {
            Field f = new Field("Set ID - AL1");
            List<Component> c = new List<Component>();
            c.Add(new Component("Sequence ID", "AL1-1.1"));
            f.Components = c;
            return f;
        }
        private Field AL12()
        {
            Field f = new Field("Allergen Type Code");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "AL1-2.1"));
            c.Add(new Component("", "AL1-2.2"));
            c.Add(new Component("Name of Coding System", "AL1-2.3"));
            c.Add(new Component("Alternate Identifier", "AL1-2.4"));
            c.Add(new Component("Alternate Text", "AL1-2.5"));
            c.Add(new Component("Name of Alternate Coding System", "AL1-2.6"));
            f.Components = c;
            return f;
        }
        private Field AL13()
        {
            Field f = new Field("Allergen Code/Mnemonic/Description");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "AL1-3.1"));
            c.Add(new Component("", "AL1-3.2"));
            c.Add(new Component("Name of Coding System", "AL1-3.3"));
            c.Add(new Component("Alternate Identifier", "AL1-3.4"));
            c.Add(new Component("Alternate Text", "AL1-3.5"));
            c.Add(new Component("Name of Alternate Coding System", "AL1-3.6"));
            f.Components = c;
            return f;
        }
        private Field AL14()
        {
            Field f = new Field("Allergy Severity Code");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "AL1-4.1"));
            c.Add(new Component("", "AL1-4.2"));
            c.Add(new Component("Name of Coding System", "AL1-4.3"));
            c.Add(new Component("Alternate Identifier", "AL1-4.4"));
            c.Add(new Component("Alternate Text", "AL1-4.5"));
            c.Add(new Component("Name of Alternate Coding System", "AL1-4.6"));
            f.Components = c;
            return f;
        }
        private Field AL15()
        {
            Field f = new Field("Allergy Reaction Code");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "AL1-5.1"));
            f.Components = c;
            return f;
        }
        private Field AL16()
        {
            Field f = new Field("Identification Date");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "AL1-6.1"));
            f.Components = c;
            return f;
        }
    }
}
