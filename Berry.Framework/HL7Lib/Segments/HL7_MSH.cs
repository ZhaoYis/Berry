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
    /// MSH Class: Constructs an HL7 MSH Segment Object
    /// </summary>
    public class MSH
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Field> Fields { get; set; }

        public MSH()
        {
            Name = "MSH";
            Description = "Message Header";
            List<Field> fs = new List<Field>();
            fs.Add(Field.SegName());
            fs.Add(MSH1());
            fs.Add(MSH2());
            fs.Add(MSH3());
            fs.Add(MSH4());
            fs.Add(MSH5());
            fs.Add(MSH6());
            fs.Add(MSH7());
            fs.Add(MSH8());
            fs.Add(MSH9());
            fs.Add(MSH10());
            fs.Add(MSH11());
            fs.Add(MSH12());
            fs.Add(MSH13());
            fs.Add(MSH14());
            fs.Add(MSH15());
            fs.Add(MSH16());
            fs.Add(MSH17());
            fs.Add(MSH18());
            fs.Add(MSH19());
            fs.Add(MSH20());
            fs.Add(MSH21());
            Fields = fs;
        }
        private Field MSH1()
        {
            Field f = new Field("Field Separator");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-1.1"));
            f.Components = c;
            return f;
        }
        private Field MSH2()
        {
            Field f = new Field("Encoding Characters");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-2.1"));
            f.Components = c;
            return f;
        }
        private Field MSH3()
        {
            Field f = new Field("Sending Application");
            List<Component> c = new List<Component>();
            c.Add(new Component("Namespace ID", "MSH-3.1"));
            c.Add(new Component("Universal ID", "MSH-3.2"));
            c.Add(new Component("Universal ID Type", "MSH-3.3"));
            f.Components = c;
            return f;
        }
        private Field MSH4()
        {
            Field f = new Field("Sending Facility");
            List<Component> c = new List<Component>();
            c.Add(new Component("Namespace ID", "MSH-4.1"));
            c.Add(new Component("Universal ID", "MSH-4.2"));
            c.Add(new Component("Universal ID Type", "MSH-4.3"));
            f.Components = c;
            return f;
        }
        private Field MSH5()
        {
            Field f = new Field("Receiving Application");
            List<Component> c = new List<Component>();
            c.Add(new Component("Namespace ID", "MSH-5.1"));
            c.Add(new Component("Universal ID", "MSH-5.2"));
            c.Add(new Component("Universal ID Type", "MSH-5.3"));
            f.Components = c;
            return f;
        }
        private Field MSH6()
        {
            Field f = new Field("Receiving Facility");
            List<Component> c = new List<Component>();
            c.Add(new Component("Namespace ID", "MSH-6.1"));
            c.Add(new Component("Universal ID", "MSH-6.2"));
            c.Add(new Component("Universal ID Type", "MSH-6.3"));
            f.Components = c;
            return f;
        }
        private Field MSH7()
        {
            Field f = new Field("Date/Time Of Message");
            List<Component> c = new List<Component>();
            c.Add(new Component("Time", "MSH-7.1"));
            c.Add(new Component("Degree of Precision", "MSH-7.2"));
            f.Components = c;
            return f;
        }
        private Field MSH8()
        {
            Field f = new Field("Security");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-8.1"));
            f.Components = c;
            return f;
        }
        private Field MSH9()
        {
            Field f = new Field("Message Type");
            List<Component> c = new List<Component>();
            c.Add(new Component("Message Code", "MSH-9.1"));
            c.Add(new Component("Trigger Event", "MSH-9.2"));
            c.Add(new Component("Message Structure", "MSH-9.3"));
            f.Components = c;
            return f;
        }
        private Field MSH10()
        {
            Field f = new Field("Message Control ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-10.1"));
            f.Components = c;
            return f;
        }
        private Field MSH11()
        {
            Field f = new Field("Processing ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Processing ID", "MSH-11.1"));
            c.Add(new Component("Processing Mode", "MSH-11.2"));
            f.Components = c;
            return f;
        }
        private Field MSH12()
        {
            Field f = new Field("Version ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Version ID", "MSH-12.1"));
            c.Add(new Component("Internationlization Code", "MSH-12.2"));
            c.Add(new Component("International Version ID", "MSH-12.3"));
            f.Components = c;
            return f;
        }
        private Field MSH13()
        {
            Field f = new Field("Sequence Number");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-13.1"));
            f.Components = c;
            return f;
        }
        private Field MSH14()
        {
            Field f = new Field("Continuation Pointer");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-14.1"));
            f.Components = c;
            return f;
        }
        private Field MSH15()
        {
            Field f = new Field("Accept Acknowledgment Type");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-15.1"));
            f.Components = c;
            return f;
        }
        private Field MSH16()
        {
            Field f = new Field("Application Acknowledgment Type");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-16.1"));
            f.Components = c;
            return f;
        }
        private Field MSH17()
        {
            Field f = new Field("Country Code");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-17.1"));
            f.Components = c;
            return f;
        }
        private Field MSH18()
        {
            Field f = new Field("Character Set");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-18.1"));
            f.Components = c;
            return f;
        }
        private Field MSH19()
        {
            Field f = new Field("Principal Language Of Message");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "MSH-19.1"));
            c.Add(new Component("", "MSH-19.2"));
            c.Add(new Component("Name of Coding System", "MSH-19.3"));
            c.Add(new Component("Alternate Identifier", "MSH-19.4"));
            c.Add(new Component("Alternate Text", "MSH-19.5"));
            c.Add(new Component("Name of Alternate Coding System", "MSH-19.6"));
            f.Components = c;
            return f;
        }
        private Field MSH20()
        {
            Field f = new Field("Alternate Character Set Handling Scheme");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MSH-20.1"));
            f.Components = c;
            return f;
        }
        private Field MSH21()
        {
            Field f = new Field("Message Profile Identifier");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "MSH-21.1"));
            c.Add(new Component("Namespace ID", "MSH-21.2"));
            c.Add(new Component("Universal ID", "MSH-21.3"));
            c.Add(new Component("Universal ID Type", "MSH-21.4"));
            f.Components = c;
            return f;
        }
    }
}
