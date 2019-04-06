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
    /// VAR Class: Constructs an HL7 VAR Segment Object
    /// </summary>
    public class VAR
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Field> Fields { get; set; }

        public VAR()
        {
            Name = "VAR";
            Description = "Variance";
            List<Field> fs = new List<Field>();
            fs.Add(Field.SegName());
            fs.Add(VAR1());
            fs.Add(VAR2());
            fs.Add(VAR3());
            fs.Add(VAR4());
            fs.Add(VAR5());
            fs.Add(VAR6());
            Fields = fs;
        }
        private Field VAR1()
        {
            Field f = new Field("Variance Instance ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "VAR-1.1"));
            c.Add(new Component("Namespace ID", "VAR-1.2"));
            c.Add(new Component("Universal ID", "VAR-1.3"));
            c.Add(new Component("Universal ID Type", "VAR-1.4"));
            f.Components = c;
            return f;
        }
        private Field VAR2()
        {
            Field f = new Field("Documented Date/Time");
            List<Component> c = new List<Component>();
            c.Add(new Component("Time", "VAR-2.1"));
            c.Add(new Component("Degree of Precision", "VAR-2.2"));
            f.Components = c;
            return f;
        }
        private Field VAR3()
        {
            Field f = new Field("Stated Variance Date/Time");
            List<Component> c = new List<Component>();
            c.Add(new Component("Time", "VAR-3.1"));
            c.Add(new Component("Degree of Precision", "VAR-3.2"));
            f.Components = c;
            return f;
        }
        private Field VAR4()
        {
            Field f = new Field("Variance Originator");
            List<Component> c = new List<Component>();
            c.Add(new Component("ID Number", "VAR-4.1"));
            c.Add(new Component("Family Name", "VAR-4.2"));
            c.Add(new Component("Given Name", "VAR-4.3"));
            c.Add(new Component("Second and Further Given Names or Initials Thereof", "VAR-4.4"));
            c.Add(new Component("Suffix", "VAR-4.5"));
            c.Add(new Component("Prefix", "VAR-4.6"));
            c.Add(new Component("Degree", "VAR-4.7"));
            c.Add(new Component("Source Table", "VAR-4.8"));
            c.Add(new Component("Assigning Authority", "VAR-4.9"));
            c.Add(new Component("Name Type Code", "VAR-4.10"));
            c.Add(new Component("Identifier Check Digit", "VAR-4.11"));
            c.Add(new Component("Check Digit Scheme", "VAR-4.12"));
            c.Add(new Component("Identifier Type Code", "VAR-4.13"));
            c.Add(new Component("Assigning Facility", "VAR-4.14"));
            c.Add(new Component("Name Respresentation Code", "VAR-4.15"));
            c.Add(new Component("Name Context", "VAR-4.16"));
            c.Add(new Component("Name Validity Range", "VAR-4.17"));
            c.Add(new Component("Name Assembly Order", "VAR-4.18"));
            c.Add(new Component("Effective Date", "VAR-4.19"));
            c.Add(new Component("Expiration Date", "VAR-4.20"));
            c.Add(new Component("Professional Suffix", "VAR-4.21"));
            c.Add(new Component("Assigning Jurisdiction", "VAR-4.22"));
            c.Add(new Component("Assigning Agency or Department", "VAR-4.23"));
            f.Components = c;
            return f;
        }
        private Field VAR5()
        {
            Field f = new Field("Variance Classification");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "VAR-5.1"));
            c.Add(new Component("", "VAR-5.2"));
            c.Add(new Component("Name of Coding System", "VAR-5.3"));
            c.Add(new Component("Alternate Identifier", "VAR-5.4"));
            c.Add(new Component("Alternate Text", "VAR-5.5"));
            c.Add(new Component("Name of Alternate Coding System", "VAR-5.6"));
            f.Components = c;
            return f;
        }
        private Field VAR6()
        {
            Field f = new Field("Variance Description");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "VAR-6.1"));
            f.Components = c;
            return f;
        }
    }
}
