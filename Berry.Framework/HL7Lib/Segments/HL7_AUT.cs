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
    /// AUT Class: Constructs an HL7 AUT Segment Object
    /// </summary>
    public class AUT
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Field> Fields { get; set; }

        public AUT()
        {
            Name = "AUT";
            Description = "Authorization Information";
            List<Field> fs = new List<Field>();
            fs.Add(Field.SegName());
            fs.Add(AUT1());
            fs.Add(AUT2());
            fs.Add(AUT3());
            fs.Add(AUT4());
            fs.Add(AUT5());
            fs.Add(AUT6());
            fs.Add(AUT7());
            fs.Add(AUT8());
            fs.Add(AUT9());
            fs.Add(AUT10());
            Fields = fs;
        }
        private Field AUT1()
        {
            Field f = new Field("Authorizing Payor, Plan ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "AUT-1.1"));
            c.Add(new Component("", "AUT-1.2"));
            c.Add(new Component("Name of Coding System", "AUT-1.3"));
            c.Add(new Component("Alternate Identifier", "AUT-1.4"));
            c.Add(new Component("Alternate Text", "AUT-1.5"));
            c.Add(new Component("Name of Alternate Coding System", "AUT-1.6"));
            f.Components = c;
            return f;
        }
        private Field AUT2()
        {
            Field f = new Field("Authorizing Payor, Company ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "AUT-2.1"));
            c.Add(new Component("", "AUT-2.2"));
            c.Add(new Component("Name of Coding System", "AUT-2.3"));
            c.Add(new Component("Alternate Identifier", "AUT-2.4"));
            c.Add(new Component("Alternate Text", "AUT-2.5"));
            c.Add(new Component("Name of Alternate Coding System", "AUT-2.6"));
            f.Components = c;
            return f;
        }
        private Field AUT3()
        {
            Field f = new Field("Authorizing Payor, Company Name");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "AUT-3.1"));
            f.Components = c;
            return f;
        }
        private Field AUT4()
        {
            Field f = new Field("Authorization Effective Date");
            List<Component> c = new List<Component>();
            c.Add(new Component("Time", "AUT-4.1"));
            c.Add(new Component("Degree of Precision", "AUT-4.2"));
            f.Components = c;
            return f;
        }
        private Field AUT5()
        {
            Field f = new Field("Authorization Expiration Date");
            List<Component> c = new List<Component>();
            c.Add(new Component("Time", "AUT-5.1"));
            c.Add(new Component("Degree of Precision", "AUT-5.2"));
            f.Components = c;
            return f;
        }
        private Field AUT6()
        {
            Field f = new Field("Authorization Identifier");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "AUT-6.1"));
            c.Add(new Component("Namespace ID", "AUT-6.2"));
            c.Add(new Component("Universal ID", "AUT-6.3"));
            c.Add(new Component("Universal ID Type", "AUT-6.4"));
            f.Components = c;
            return f;
        }
        private Field AUT7()
        {
            Field f = new Field("Reimbursement Limit");
            List<Component> c = new List<Component>();
            c.Add(new Component("Price", "AUT-7.1"));
            c.Add(new Component("Price Type", "AUT-7.2"));
            c.Add(new Component("From Value", "AUT-7.3"));
            c.Add(new Component("To Value", "AUT-7.4"));
            c.Add(new Component("Range Units", "AUT-7.5"));
            c.Add(new Component("Range Type", "AUT-7.6"));
            f.Components = c;
            return f;
        }
        private Field AUT8()
        {
            Field f = new Field("Requested Number of Treatments");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "AUT-8.1"));
            f.Components = c;
            return f;
        }
        private Field AUT9()
        {
            Field f = new Field("Authorized Number of Treatments");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "AUT-9.1"));
            f.Components = c;
            return f;
        }
        private Field AUT10()
        {
            Field f = new Field("Process Date");
            List<Component> c = new List<Component>();
            c.Add(new Component("Time", "AUT-10.1"));
            c.Add(new Component("Degree of Precision", "AUT-10.2"));
            f.Components = c;
            return f;
        }
    }
}
