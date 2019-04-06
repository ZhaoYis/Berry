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
    /// BHS Class: Constructs an HL7 BHS Segment Object
    /// </summary>
    public class BHS
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Field> Fields { get; set; }

        public BHS()
        {
            Name = "BHS";
            Description = "Batch Header";
            List<Field> fs = new List<Field>();
            fs.Add(Field.SegName());
            fs.Add(BHS1());
            fs.Add(BHS2());
            fs.Add(BHS3());
            fs.Add(BHS4());
            fs.Add(BHS5());
            fs.Add(BHS6());
            fs.Add(BHS7());
            fs.Add(BHS8());
            fs.Add(BHS9());
            fs.Add(BHS10());
            fs.Add(BHS11());
            fs.Add(BHS12());
            Fields = fs;
        }
        private Field BHS1()
        {
            Field f = new Field("Batch Field Separator");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "BHS-1.1"));
            f.Components = c;
            return f;
        }
        private Field BHS2()
        {
            Field f = new Field("Batch Encoding Characters");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "BHS-2.1"));
            f.Components = c;
            return f;
        }
        private Field BHS3()
        {
            Field f = new Field("Batch Sending Application");
            List<Component> c = new List<Component>();
            c.Add(new Component("Namespace ID", "BHS-3.1"));
            c.Add(new Component("Universal ID", "BHS-3.2"));
            c.Add(new Component("Universal ID Type", "BHS-3.3"));
            f.Components = c;
            return f;
        }
        private Field BHS4()
        {
            Field f = new Field("Batch Sending Facility");
            List<Component> c = new List<Component>();
            c.Add(new Component("Namespace ID", "BHS-4.1"));
            c.Add(new Component("Universal ID", "BHS-4.2"));
            c.Add(new Component("Universal ID Type", "BHS-4.3"));
            f.Components = c;
            return f;
        }
        private Field BHS5()
        {
            Field f = new Field("Batch Receiving Application");
            List<Component> c = new List<Component>();
            c.Add(new Component("Namespace ID", "BHS-5.1"));
            c.Add(new Component("Universal ID", "BHS-5.2"));
            c.Add(new Component("Universal ID Type", "BHS-5.3"));
            f.Components = c;
            return f;
        }
        private Field BHS6()
        {
            Field f = new Field("Batch Receiving Facility");
            List<Component> c = new List<Component>();
            c.Add(new Component("Namespace ID", "BHS-6.1"));
            c.Add(new Component("Universal ID", "BHS-6.2"));
            c.Add(new Component("Universal ID Type", "BHS-6.3"));
            f.Components = c;
            return f;
        }
        private Field BHS7()
        {
            Field f = new Field("Batch Creation Date/Time");
            List<Component> c = new List<Component>();
            c.Add(new Component("Time", "BHS-7.1"));
            c.Add(new Component("Degree of Precision", "BHS-7.2"));
            f.Components = c;
            return f;
        }
        private Field BHS8()
        {
            Field f = new Field("Batch Security");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "BHS-8.1"));
            f.Components = c;
            return f;
        }
        private Field BHS9()
        {
            Field f = new Field("Batch Name/ID/Type");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "BHS-9.1"));
            f.Components = c;
            return f;
        }
        private Field BHS10()
        {
            Field f = new Field("Batch Comment");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "BHS-10.1"));
            f.Components = c;
            return f;
        }
        private Field BHS11()
        {
            Field f = new Field("Batch Control ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "BHS-11.1"));
            f.Components = c;
            return f;
        }
        private Field BHS12()
        {
            Field f = new Field("Reference Batch Control ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "BHS-12.1"));
            f.Components = c;
            return f;
        }
    }
}
