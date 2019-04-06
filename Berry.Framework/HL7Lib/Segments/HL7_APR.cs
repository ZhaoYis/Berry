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
    /// APR Class: Constructs an HL7 APR Segment Object
    /// </summary>
    public class APR
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Field> Fields { get; set; }

        public APR()
        {
            Name = "APR";
            Description = "Appointment Preferences";
            List<Field> fs = new List<Field>();
            fs.Add(Field.SegName());
            fs.Add(APR1());
            fs.Add(APR2());
            fs.Add(APR3());
            fs.Add(APR4());
            fs.Add(APR5());
            Fields = fs;
        }
        private Field APR1()
        {
            Field f = new Field("Time Selection Criteria");
            List<Component> c = new List<Component>();
            c.Add(new Component("Paramter Class", "APR-1.1"));
            c.Add(new Component("Parameter Value", "APR-1.2"));
            f.Components = c;
            return f;
        }
        private Field APR2()
        {
            Field f = new Field("Resource Selection Criteria");
            List<Component> c = new List<Component>();
            c.Add(new Component("Paramter Class", "APR-2.1"));
            c.Add(new Component("Parameter Value", "APR-2.2"));
            f.Components = c;
            return f;
        }
        private Field APR3()
        {
            Field f = new Field("Location Selection Criteria");
            List<Component> c = new List<Component>();
            c.Add(new Component("Paramter Class", "APR-3.1"));
            c.Add(new Component("Parameter Value", "APR-3.2"));
            f.Components = c;
            return f;
        }
        private Field APR4()
        {
            Field f = new Field("Slot Spacing Criteria");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "APR-4.1"));
            f.Components = c;
            return f;
        }
        private Field APR5()
        {
            Field f = new Field("Filler Override Criteria");
            List<Component> c = new List<Component>();
            c.Add(new Component("Paramter Class", "APR-5.1"));
            c.Add(new Component("Parameter Value", "APR-5.2"));
            f.Components = c;
            return f;
        }
    }
}
