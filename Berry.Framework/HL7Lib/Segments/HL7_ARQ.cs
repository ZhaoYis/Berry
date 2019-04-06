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
    /// ARQ Class: Constructs an HL7 ARQ Segment Object
    /// </summary>
    public class ARQ
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Field> Fields { get; set; }

        public ARQ()
        {
            Name = "ARQ";
            Description = "Appointment Request";
            List<Field> fs = new List<Field>();
            fs.Add(Field.SegName());
            fs.Add(ARQ1());
            fs.Add(ARQ2());
            fs.Add(ARQ3());
            fs.Add(ARQ4());
            fs.Add(ARQ5());
            fs.Add(ARQ6());
            fs.Add(ARQ7());
            fs.Add(ARQ8());
            fs.Add(ARQ9());
            fs.Add(ARQ10());
            fs.Add(ARQ11());
            fs.Add(ARQ12());
            fs.Add(ARQ13());
            fs.Add(ARQ14());
            fs.Add(ARQ15());
            fs.Add(ARQ16());
            fs.Add(ARQ17());
            fs.Add(ARQ18());
            fs.Add(ARQ19());
            fs.Add(ARQ20());
            fs.Add(ARQ21());
            fs.Add(ARQ22());
            fs.Add(ARQ23());
            fs.Add(ARQ24());
            fs.Add(ARQ25());
            Fields = fs;
        }
        private Field ARQ1()
        {
            Field f = new Field("Placer Appointment ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "ARQ-1.1"));
            c.Add(new Component("Namespace ID", "ARQ-1.2"));
            c.Add(new Component("Universal ID", "ARQ-1.3"));
            c.Add(new Component("Universal ID Type", "ARQ-1.4"));
            f.Components = c;
            return f;
        }
        private Field ARQ2()
        {
            Field f = new Field("Filler Appointment ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "ARQ-2.1"));
            c.Add(new Component("Namespace ID", "ARQ-2.2"));
            c.Add(new Component("Universal ID", "ARQ-2.3"));
            c.Add(new Component("Universal ID Type", "ARQ-2.4"));
            f.Components = c;
            return f;
        }
        private Field ARQ3()
        {
            Field f = new Field("Occurrence Number");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "ARQ-3.1"));
            f.Components = c;
            return f;
        }
        private Field ARQ4()
        {
            Field f = new Field("Placer Group Number");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "ARQ-4.1"));
            c.Add(new Component("Namespace ID", "ARQ-4.2"));
            c.Add(new Component("Universal ID", "ARQ-4.3"));
            c.Add(new Component("Universal ID Type", "ARQ-4.4"));
            f.Components = c;
            return f;
        }
        private Field ARQ5()
        {
            Field f = new Field("Schedule ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "ARQ-5.1"));
            c.Add(new Component("", "ARQ-5.2"));
            c.Add(new Component("Name of Coding System", "ARQ-5.3"));
            c.Add(new Component("Alternate Identifier", "ARQ-5.4"));
            c.Add(new Component("Alternate Text", "ARQ-5.5"));
            c.Add(new Component("Name of Alternate Coding System", "ARQ-5.6"));
            f.Components = c;
            return f;
        }
        private Field ARQ6()
        {
            Field f = new Field("Request Event Reason");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "ARQ-6.1"));
            c.Add(new Component("", "ARQ-6.2"));
            c.Add(new Component("Name of Coding System", "ARQ-6.3"));
            c.Add(new Component("Alternate Identifier", "ARQ-6.4"));
            c.Add(new Component("Alternate Text", "ARQ-6.5"));
            c.Add(new Component("Name of Alternate Coding System", "ARQ-6.6"));
            f.Components = c;
            return f;
        }
        private Field ARQ7()
        {
            Field f = new Field("Appointment Reason");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "ARQ-7.1"));
            c.Add(new Component("", "ARQ-7.2"));
            c.Add(new Component("Name of Coding System", "ARQ-7.3"));
            c.Add(new Component("Alternate Identifier", "ARQ-7.4"));
            c.Add(new Component("Alternate Text", "ARQ-7.5"));
            c.Add(new Component("Name of Alternate Coding System", "ARQ-7.6"));
            f.Components = c;
            return f;
        }
        private Field ARQ8()
        {
            Field f = new Field("Appointment Type");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "ARQ-8.1"));
            c.Add(new Component("", "ARQ-8.2"));
            c.Add(new Component("Name of Coding System", "ARQ-8.3"));
            c.Add(new Component("Alternate Identifier", "ARQ-8.4"));
            c.Add(new Component("Alternate Text", "ARQ-8.5"));
            c.Add(new Component("Name of Alternate Coding System", "ARQ-8.6"));
            f.Components = c;
            return f;
        }
        private Field ARQ9()
        {
            Field f = new Field("Appointment Duration");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "ARQ-9.1"));
            f.Components = c;
            return f;
        }
        private Field ARQ10()
        {
            Field f = new Field("Appointment Duration Units");
            List<Component> c = new List<Component>();
            c.Add(new Component("Identifier", "ARQ-10.1"));
            c.Add(new Component("", "ARQ-10.2"));
            c.Add(new Component("Name of Coding System", "ARQ-10.3"));
            c.Add(new Component("Alternate Identifier", "ARQ-10.4"));
            c.Add(new Component("Alternate Text", "ARQ-10.5"));
            c.Add(new Component("Name of Alternate Coding System", "ARQ-10.6"));
            f.Components = c;
            return f;
        }
        private Field ARQ11()
        {
            Field f = new Field("Requested Start Date/Time Range");
            List<Component> c = new List<Component>();
            c.Add(new Component("Range Start Date/Time", "ARQ-11.1"));
            c.Add(new Component("Range End Date/Time", "ARQ-11.2"));
            f.Components = c;
            return f;
        }
        private Field ARQ12()
        {
            Field f = new Field("Priority-ARQ");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "ARQ-12.1"));
            f.Components = c;
            return f;
        }
        private Field ARQ13()
        {
            Field f = new Field("Repeating Interval");
            List<Component> c = new List<Component>();
            c.Add(new Component("Repeat Pattern", "ARQ-13.1"));
            c.Add(new Component("Explicit Time Interval", "ARQ-13.2"));
            f.Components = c;
            return f;
        }
        private Field ARQ14()
        {
            Field f = new Field("Repeating Interval Duration");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "ARQ-14.1"));
            f.Components = c;
            return f;
        }
        private Field ARQ15()
        {
            Field f = new Field("Placer Contact Person");
            List<Component> c = new List<Component>();
            c.Add(new Component("ID Number", "ARQ-15.1"));
            c.Add(new Component("Family Name", "ARQ-15.2"));
            c.Add(new Component("Given Name", "ARQ-15.3"));
            c.Add(new Component("Second and Further Given Names or Initials Thereof", "ARQ-15.4"));
            c.Add(new Component("Suffix", "ARQ-15.5"));
            c.Add(new Component("Prefix", "ARQ-15.6"));
            c.Add(new Component("Degree", "ARQ-15.7"));
            c.Add(new Component("Source Table", "ARQ-15.8"));
            c.Add(new Component("Assigning Authority", "ARQ-15.9"));
            c.Add(new Component("Name Type Code", "ARQ-15.10"));
            c.Add(new Component("Identifier Check Digit", "ARQ-15.11"));
            c.Add(new Component("Check Digit Scheme", "ARQ-15.12"));
            c.Add(new Component("Identifier Type Code", "ARQ-15.13"));
            c.Add(new Component("Assigning Facility", "ARQ-15.14"));
            c.Add(new Component("Name Respresentation Code", "ARQ-15.15"));
            c.Add(new Component("Name Context", "ARQ-15.16"));
            c.Add(new Component("Name Validity Range", "ARQ-15.17"));
            c.Add(new Component("Name Assembly Order", "ARQ-15.18"));
            c.Add(new Component("Effective Date", "ARQ-15.19"));
            c.Add(new Component("Expiration Date", "ARQ-15.20"));
            c.Add(new Component("Professional Suffix", "ARQ-15.21"));
            c.Add(new Component("Assigning Jurisdiction", "ARQ-15.22"));
            c.Add(new Component("Assigning Agency or Department", "ARQ-15.23"));
            f.Components = c;
            return f;
        }
        private Field ARQ16()
        {
            Field f = new Field("Placer Contact Phone Number");
            List<Component> c = new List<Component>();
            c.Add(new Component("Telephone Number", "ARQ-16.1"));
            c.Add(new Component("Tele-Communication Use Code", "ARQ-16.2"));
            c.Add(new Component("Tele-Communication Equipment Type", "ARQ-16.3"));
            c.Add(new Component("Email Address", "ARQ-16.4"));
            c.Add(new Component("Country Code", "ARQ-16.5"));
            c.Add(new Component("Area City Code", "ARQ-16.6"));
            c.Add(new Component("Local Number", "ARQ-16.7"));
            c.Add(new Component("Extension", "ARQ-16.8"));
            c.Add(new Component("", "ARQ-16.9"));
            c.Add(new Component("Extension Prefix", "ARQ-16.10"));
            c.Add(new Component("Speed Dial Code", "ARQ-16.11"));
            c.Add(new Component("Unformatted Telephone Number", "ARQ-16.12"));
            f.Components = c;
            return f;
        }
        private Field ARQ17()
        {
            Field f = new Field("Placer Contact Address");
            List<Component> c = new List<Component>();
            c.Add(new Component("Street Address", "ARQ-17.1"));
            c.Add(new Component("Other Designation", "ARQ-17.2"));
            c.Add(new Component("City", "ARQ-17.3"));
            c.Add(new Component("State or Province", "ARQ-17.4"));
            c.Add(new Component("Zip or Postal Code", "ARQ-17.5"));
            c.Add(new Component("Country", "ARQ-17.6"));
            c.Add(new Component("Address Type", "ARQ-17.7"));
            c.Add(new Component("Other Geographic Designation", "ARQ-17.8"));
            c.Add(new Component("Country Parish Code", "ARQ-17.9"));
            c.Add(new Component("Census Tract", "ARQ-17.10"));
            c.Add(new Component("Address Representation Code", "ARQ-17.11"));
            c.Add(new Component("Address Validity Range", "ARQ-17.12"));
            c.Add(new Component("Effective Date", "ARQ-17.13"));
            c.Add(new Component("Expiration Date", "ARQ-17.14"));
            f.Components = c;
            return f;
        }
        private Field ARQ18()
        {
            Field f = new Field("Placer Contact Location");
            List<Component> c = new List<Component>();
            c.Add(new Component("Point of Care", "ARQ-18.1"));
            c.Add(new Component("Room", "ARQ-18.2"));
            c.Add(new Component("Bed", "ARQ-18.3"));
            c.Add(new Component("Facility", "ARQ-18.4"));
            c.Add(new Component("Location Status", "ARQ-18.5"));
            c.Add(new Component("Person Location Type", "ARQ-18.6"));
            c.Add(new Component("Building", "ARQ-18.7"));
            c.Add(new Component("Floor Number", "ARQ-18.8"));
            c.Add(new Component("Location Description", "ARQ-18.9"));
            c.Add(new Component("Comprehensive Location Identifier", "ARQ-18.10"));
            c.Add(new Component("Assigning Authority for Location", "ARQ-18.11"));
            f.Components = c;
            return f;
        }
        private Field ARQ19()
        {
            Field f = new Field("Entered By Person");
            List<Component> c = new List<Component>();
            c.Add(new Component("ID Number", "ARQ-19.1"));
            c.Add(new Component("Family Name", "ARQ-19.2"));
            c.Add(new Component("Given Name", "ARQ-19.3"));
            c.Add(new Component("Second and Further Given Names or Initials Thereof", "ARQ-19.4"));
            c.Add(new Component("Suffix", "ARQ-19.5"));
            c.Add(new Component("Prefix", "ARQ-19.6"));
            c.Add(new Component("Degree", "ARQ-19.7"));
            c.Add(new Component("Source Table", "ARQ-19.8"));
            c.Add(new Component("Assigning Authority", "ARQ-19.9"));
            c.Add(new Component("Name Type Code", "ARQ-19.10"));
            c.Add(new Component("Identifier Check Digit", "ARQ-19.11"));
            c.Add(new Component("Check Digit Scheme", "ARQ-19.12"));
            c.Add(new Component("Identifier Type Code", "ARQ-19.13"));
            c.Add(new Component("Assigning Facility", "ARQ-19.14"));
            c.Add(new Component("Name Respresentation Code", "ARQ-19.15"));
            c.Add(new Component("Name Context", "ARQ-19.16"));
            c.Add(new Component("Name Validity Range", "ARQ-19.17"));
            c.Add(new Component("Name Assembly Order", "ARQ-19.18"));
            c.Add(new Component("Effective Date", "ARQ-19.19"));
            c.Add(new Component("Expiration Date", "ARQ-19.20"));
            c.Add(new Component("Professional Suffix", "ARQ-19.21"));
            c.Add(new Component("Assigning Jurisdiction", "ARQ-19.22"));
            c.Add(new Component("Assigning Agency or Department", "ARQ-19.23"));
            f.Components = c;
            return f;
        }
        private Field ARQ20()
        {
            Field f = new Field("Entered By Phone Number");
            List<Component> c = new List<Component>();
            c.Add(new Component("Telephone Number", "ARQ-20.1"));
            c.Add(new Component("Tele-Communication Use Code", "ARQ-20.2"));
            c.Add(new Component("Tele-Communication Equipment Type", "ARQ-20.3"));
            c.Add(new Component("Email Address", "ARQ-20.4"));
            c.Add(new Component("Country Code", "ARQ-20.5"));
            c.Add(new Component("Area City Code", "ARQ-20.6"));
            c.Add(new Component("Local Number", "ARQ-20.7"));
            c.Add(new Component("Extension", "ARQ-20.8"));
            c.Add(new Component("", "ARQ-20.9"));
            c.Add(new Component("Extension Prefix", "ARQ-20.10"));
            c.Add(new Component("Speed Dial Code", "ARQ-20.11"));
            c.Add(new Component("Unformatted Telephone Number", "ARQ-20.12"));
            f.Components = c;
            return f;
        }
        private Field ARQ21()
        {
            Field f = new Field("Entered By Location");
            List<Component> c = new List<Component>();
            c.Add(new Component("Point of Care", "ARQ-21.1"));
            c.Add(new Component("Room", "ARQ-21.2"));
            c.Add(new Component("Bed", "ARQ-21.3"));
            c.Add(new Component("Facility", "ARQ-21.4"));
            c.Add(new Component("Location Status", "ARQ-21.5"));
            c.Add(new Component("Person Location Type", "ARQ-21.6"));
            c.Add(new Component("Building", "ARQ-21.7"));
            c.Add(new Component("Floor Number", "ARQ-21.8"));
            c.Add(new Component("Location Description", "ARQ-21.9"));
            c.Add(new Component("Comprehensive Location Identifier", "ARQ-21.10"));
            c.Add(new Component("Assigning Authority for Location", "ARQ-21.11"));
            f.Components = c;
            return f;
        }
        private Field ARQ22()
        {
            Field f = new Field("Parent Placer Appointment ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "ARQ-22.1"));
            c.Add(new Component("Namespace ID", "ARQ-22.2"));
            c.Add(new Component("Universal ID", "ARQ-22.3"));
            c.Add(new Component("Universal ID Type", "ARQ-22.4"));
            f.Components = c;
            return f;
        }
        private Field ARQ23()
        {
            Field f = new Field("Parent Filler Appointment ID");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "ARQ-23.1"));
            c.Add(new Component("Namespace ID", "ARQ-23.2"));
            c.Add(new Component("Universal ID", "ARQ-23.3"));
            c.Add(new Component("Universal ID Type", "ARQ-23.4"));
            f.Components = c;
            return f;
        }
        private Field ARQ24()
        {
            Field f = new Field("Placer Order Number");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "ARQ-24.1"));
            c.Add(new Component("Namespace ID", "ARQ-24.2"));
            c.Add(new Component("Universal ID", "ARQ-24.3"));
            c.Add(new Component("Universal ID Type", "ARQ-24.4"));
            f.Components = c;
            return f;
        }
        private Field ARQ25()
        {
            Field f = new Field("Filler Order Number");
            List<Component> c = new List<Component>();
            c.Add(new Component("Entity Identifier", "ARQ-25.1"));
            c.Add(new Component("Namespace ID", "ARQ-25.2"));
            c.Add(new Component("Universal ID", "ARQ-25.3"));
            c.Add(new Component("Universal ID Type", "ARQ-25.4"));
            f.Components = c;
            return f;
        }
    }
}
