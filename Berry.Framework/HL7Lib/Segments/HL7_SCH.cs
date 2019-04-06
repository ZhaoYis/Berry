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
/// SCH Class: Constructs an HL7 SCH Segment Object
/// </summary>
public class SCH
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public SCH()
		{
			Name = "SCH";
			Description = "Scheduling Activity Information";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(SCH1());
			fs.Add(SCH2());
			fs.Add(SCH3());
			fs.Add(SCH4());
			fs.Add(SCH5());
			fs.Add(SCH6());
			fs.Add(SCH7());
			fs.Add(SCH8());
			fs.Add(SCH9());
			fs.Add(SCH10());
			fs.Add(SCH11());
			fs.Add(SCH12());
			fs.Add(SCH13());
			fs.Add(SCH14());
			fs.Add(SCH15());
			fs.Add(SCH16());
			fs.Add(SCH17());
			fs.Add(SCH18());
			fs.Add(SCH19());
			fs.Add(SCH20());
			fs.Add(SCH21());
			fs.Add(SCH22());
			fs.Add(SCH23());
			fs.Add(SCH24());
			fs.Add(SCH25());
			fs.Add(SCH26());
			fs.Add(SCH27());
			Fields = fs;
		}
		private Field SCH1()
		{
			Field f = new Field("Placer Appointment ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SCH-1.1"));
			c.Add(new Component("Namespace ID", "SCH-1.2"));
			c.Add(new Component("Universal ID", "SCH-1.3"));
			c.Add(new Component("Universal ID Type", "SCH-1.4"));
			f.Components = c;
			return f;
		}
		private Field SCH2()
		{
			Field f = new Field("Filler Appointment ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SCH-2.1"));
			c.Add(new Component("Namespace ID", "SCH-2.2"));
			c.Add(new Component("Universal ID", "SCH-2.3"));
			c.Add(new Component("Universal ID Type", "SCH-2.4"));
			f.Components = c;
			return f;
		}
		private Field SCH3()
		{
			Field f = new Field("Occurrence Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SCH-3.1"));
			f.Components = c;
			return f;
		}
		private Field SCH4()
		{
			Field f = new Field("Placer Group Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SCH-4.1"));
			c.Add(new Component("Namespace ID", "SCH-4.2"));
			c.Add(new Component("Universal ID", "SCH-4.3"));
			c.Add(new Component("Universal ID Type", "SCH-4.4"));
			f.Components = c;
			return f;
		}
		private Field SCH5()
		{
			Field f = new Field("Schedule ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SCH-5.1"));
			c.Add(new Component("", "SCH-5.2"));
			c.Add(new Component("Name of Coding System", "SCH-5.3"));
			c.Add(new Component("Alternate Identifier", "SCH-5.4"));
			c.Add(new Component("Alternate Text", "SCH-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "SCH-5.6"));
			f.Components = c;
			return f;
		}
		private Field SCH6()
		{
			Field f = new Field("Event Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SCH-6.1"));
			c.Add(new Component("", "SCH-6.2"));
			c.Add(new Component("Name of Coding System", "SCH-6.3"));
			c.Add(new Component("Alternate Identifier", "SCH-6.4"));
			c.Add(new Component("Alternate Text", "SCH-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "SCH-6.6"));
			f.Components = c;
			return f;
		}
		private Field SCH7()
		{
			Field f = new Field("Appointment Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SCH-7.1"));
			c.Add(new Component("", "SCH-7.2"));
			c.Add(new Component("Name of Coding System", "SCH-7.3"));
			c.Add(new Component("Alternate Identifier", "SCH-7.4"));
			c.Add(new Component("Alternate Text", "SCH-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "SCH-7.6"));
			f.Components = c;
			return f;
		}
		private Field SCH8()
		{
			Field f = new Field("Appointment Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SCH-8.1"));
			c.Add(new Component("", "SCH-8.2"));
			c.Add(new Component("Name of Coding System", "SCH-8.3"));
			c.Add(new Component("Alternate Identifier", "SCH-8.4"));
			c.Add(new Component("Alternate Text", "SCH-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "SCH-8.6"));
			f.Components = c;
			return f;
		}
		private Field SCH9()
		{
			Field f = new Field("Appointment Duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SCH-9.1"));
			f.Components = c;
			return f;
		}
		private Field SCH10()
		{
			Field f = new Field("Appointment Duration Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SCH-10.1"));
			c.Add(new Component("", "SCH-10.2"));
			c.Add(new Component("Name of Coding System", "SCH-10.3"));
			c.Add(new Component("Alternate Identifier", "SCH-10.4"));
			c.Add(new Component("Alternate Text", "SCH-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "SCH-10.6"));
			f.Components = c;
			return f;
		}
		private Field SCH11()
		{
			Field f = new Field("Appointment Timing Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "SCH-11.1"));
			c.Add(new Component("Interval", "SCH-11.2"));
			c.Add(new Component("Duration", "SCH-11.3"));
			c.Add(new Component("Start Date/Time", "SCH-11.4"));
			c.Add(new Component("End Date Time", "SCH-11.5"));
			c.Add(new Component("Priority", "SCH-11.6"));
			c.Add(new Component("Condition", "SCH-11.7"));
			c.Add(new Component("", "SCH-11.8"));
			c.Add(new Component("Conjunction", "SCH-11.9"));
			c.Add(new Component("Order Sequencing", "SCH-11.10"));
			c.Add(new Component("Occurrence Duration", "SCH-11.11"));
			c.Add(new Component("Total Occurrences", "SCH-11.12"));
			f.Components = c;
			return f;
		}
		private Field SCH12()
		{
			Field f = new Field("Placer Contact Person");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "SCH-12.1"));
			c.Add(new Component("Family Name", "SCH-12.2"));
			c.Add(new Component("Given Name", "SCH-12.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "SCH-12.4"));
			c.Add(new Component("Suffix", "SCH-12.5"));
			c.Add(new Component("Prefix", "SCH-12.6"));
			c.Add(new Component("Degree", "SCH-12.7"));
			c.Add(new Component("Source Table", "SCH-12.8"));
			c.Add(new Component("Assigning Authority", "SCH-12.9"));
			c.Add(new Component("Name Type Code", "SCH-12.10"));
			c.Add(new Component("Identifier Check Digit", "SCH-12.11"));
			c.Add(new Component("Check Digit Scheme", "SCH-12.12"));
			c.Add(new Component("Identifier Type Code", "SCH-12.13"));
			c.Add(new Component("Assigning Facility", "SCH-12.14"));
			c.Add(new Component("Name Respresentation Code", "SCH-12.15"));
			c.Add(new Component("Name Context", "SCH-12.16"));
			c.Add(new Component("Name Validity Range", "SCH-12.17"));
			c.Add(new Component("Name Assembly Order", "SCH-12.18"));
			c.Add(new Component("Effective Date", "SCH-12.19"));
			c.Add(new Component("Expiration Date", "SCH-12.20"));
			c.Add(new Component("Professional Suffix", "SCH-12.21"));
			c.Add(new Component("Assigning Jurisdiction", "SCH-12.22"));
			c.Add(new Component("Assigning Agency or Department", "SCH-12.23"));
			f.Components = c;
			return f;
		}
		private Field SCH13()
		{
			Field f = new Field("Placer Contact Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "SCH-13.1"));
			c.Add(new Component("Tele-Communication Use Code", "SCH-13.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "SCH-13.3"));
			c.Add(new Component("Email Address", "SCH-13.4"));
			c.Add(new Component("Country Code", "SCH-13.5"));
			c.Add(new Component("Area City Code", "SCH-13.6"));
			c.Add(new Component("Local Number", "SCH-13.7"));
			c.Add(new Component("Extension", "SCH-13.8"));
			c.Add(new Component("", "SCH-13.9"));
			c.Add(new Component("Extension Prefix", "SCH-13.10"));
			c.Add(new Component("Speed Dial Code", "SCH-13.11"));
			c.Add(new Component("Unformatted Telephone Number", "SCH-13.12"));
			f.Components = c;
			return f;
		}
		private Field SCH14()
		{
			Field f = new Field("Placer Contact Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "SCH-14.1"));
			c.Add(new Component("Other Designation", "SCH-14.2"));
			c.Add(new Component("City", "SCH-14.3"));
			c.Add(new Component("State or Province", "SCH-14.4"));
			c.Add(new Component("Zip or Postal Code", "SCH-14.5"));
			c.Add(new Component("Country", "SCH-14.6"));
			c.Add(new Component("Address Type", "SCH-14.7"));
			c.Add(new Component("Other Geographic Designation", "SCH-14.8"));
			c.Add(new Component("Country Parish Code", "SCH-14.9"));
			c.Add(new Component("Census Tract", "SCH-14.10"));
			c.Add(new Component("Address Representation Code", "SCH-14.11"));
			c.Add(new Component("Address Validity Range", "SCH-14.12"));
			c.Add(new Component("Effective Date", "SCH-14.13"));
			c.Add(new Component("Expiration Date", "SCH-14.14"));
			f.Components = c;
			return f;
		}
		private Field SCH15()
		{
			Field f = new Field("Placer Contact Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "SCH-15.1"));
			c.Add(new Component("Room", "SCH-15.2"));
			c.Add(new Component("Bed", "SCH-15.3"));
			c.Add(new Component("Facility", "SCH-15.4"));
			c.Add(new Component("Location Status", "SCH-15.5"));
			c.Add(new Component("Person Location Type", "SCH-15.6"));
			c.Add(new Component("Building", "SCH-15.7"));
			c.Add(new Component("Floor Number", "SCH-15.8"));
			c.Add(new Component("Location Description", "SCH-15.9"));
			c.Add(new Component("Comprehensive Location Identifier", "SCH-15.10"));
			c.Add(new Component("Assigning Authority for Location", "SCH-15.11"));
			f.Components = c;
			return f;
		}
		private Field SCH16()
		{
			Field f = new Field("Filler Contact Person");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "SCH-16.1"));
			c.Add(new Component("Family Name", "SCH-16.2"));
			c.Add(new Component("Given Name", "SCH-16.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "SCH-16.4"));
			c.Add(new Component("Suffix", "SCH-16.5"));
			c.Add(new Component("Prefix", "SCH-16.6"));
			c.Add(new Component("Degree", "SCH-16.7"));
			c.Add(new Component("Source Table", "SCH-16.8"));
			c.Add(new Component("Assigning Authority", "SCH-16.9"));
			c.Add(new Component("Name Type Code", "SCH-16.10"));
			c.Add(new Component("Identifier Check Digit", "SCH-16.11"));
			c.Add(new Component("Check Digit Scheme", "SCH-16.12"));
			c.Add(new Component("Identifier Type Code", "SCH-16.13"));
			c.Add(new Component("Assigning Facility", "SCH-16.14"));
			c.Add(new Component("Name Respresentation Code", "SCH-16.15"));
			c.Add(new Component("Name Context", "SCH-16.16"));
			c.Add(new Component("Name Validity Range", "SCH-16.17"));
			c.Add(new Component("Name Assembly Order", "SCH-16.18"));
			c.Add(new Component("Effective Date", "SCH-16.19"));
			c.Add(new Component("Expiration Date", "SCH-16.20"));
			c.Add(new Component("Professional Suffix", "SCH-16.21"));
			c.Add(new Component("Assigning Jurisdiction", "SCH-16.22"));
			c.Add(new Component("Assigning Agency or Department", "SCH-16.23"));
			f.Components = c;
			return f;
		}
		private Field SCH17()
		{
			Field f = new Field("Filler Contact Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "SCH-17.1"));
			c.Add(new Component("Tele-Communication Use Code", "SCH-17.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "SCH-17.3"));
			c.Add(new Component("Email Address", "SCH-17.4"));
			c.Add(new Component("Country Code", "SCH-17.5"));
			c.Add(new Component("Area City Code", "SCH-17.6"));
			c.Add(new Component("Local Number", "SCH-17.7"));
			c.Add(new Component("Extension", "SCH-17.8"));
			c.Add(new Component("", "SCH-17.9"));
			c.Add(new Component("Extension Prefix", "SCH-17.10"));
			c.Add(new Component("Speed Dial Code", "SCH-17.11"));
			c.Add(new Component("Unformatted Telephone Number", "SCH-17.12"));
			f.Components = c;
			return f;
		}
		private Field SCH18()
		{
			Field f = new Field("Filler Contact Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "SCH-18.1"));
			c.Add(new Component("Other Designation", "SCH-18.2"));
			c.Add(new Component("City", "SCH-18.3"));
			c.Add(new Component("State or Province", "SCH-18.4"));
			c.Add(new Component("Zip or Postal Code", "SCH-18.5"));
			c.Add(new Component("Country", "SCH-18.6"));
			c.Add(new Component("Address Type", "SCH-18.7"));
			c.Add(new Component("Other Geographic Designation", "SCH-18.8"));
			c.Add(new Component("Country Parish Code", "SCH-18.9"));
			c.Add(new Component("Census Tract", "SCH-18.10"));
			c.Add(new Component("Address Representation Code", "SCH-18.11"));
			c.Add(new Component("Address Validity Range", "SCH-18.12"));
			c.Add(new Component("Effective Date", "SCH-18.13"));
			c.Add(new Component("Expiration Date", "SCH-18.14"));
			f.Components = c;
			return f;
		}
		private Field SCH19()
		{
			Field f = new Field("Filler Contact Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "SCH-19.1"));
			c.Add(new Component("Room", "SCH-19.2"));
			c.Add(new Component("Bed", "SCH-19.3"));
			c.Add(new Component("Facility", "SCH-19.4"));
			c.Add(new Component("Location Status", "SCH-19.5"));
			c.Add(new Component("Person Location Type", "SCH-19.6"));
			c.Add(new Component("Building", "SCH-19.7"));
			c.Add(new Component("Floor Number", "SCH-19.8"));
			c.Add(new Component("Location Description", "SCH-19.9"));
			c.Add(new Component("Comprehensive Location Identifier", "SCH-19.10"));
			c.Add(new Component("Assigning Authority for Location", "SCH-19.11"));
			f.Components = c;
			return f;
		}
		private Field SCH20()
		{
			Field f = new Field("Entered By Person");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "SCH-20.1"));
			c.Add(new Component("Family Name", "SCH-20.2"));
			c.Add(new Component("Given Name", "SCH-20.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "SCH-20.4"));
			c.Add(new Component("Suffix", "SCH-20.5"));
			c.Add(new Component("Prefix", "SCH-20.6"));
			c.Add(new Component("Degree", "SCH-20.7"));
			c.Add(new Component("Source Table", "SCH-20.8"));
			c.Add(new Component("Assigning Authority", "SCH-20.9"));
			c.Add(new Component("Name Type Code", "SCH-20.10"));
			c.Add(new Component("Identifier Check Digit", "SCH-20.11"));
			c.Add(new Component("Check Digit Scheme", "SCH-20.12"));
			c.Add(new Component("Identifier Type Code", "SCH-20.13"));
			c.Add(new Component("Assigning Facility", "SCH-20.14"));
			c.Add(new Component("Name Respresentation Code", "SCH-20.15"));
			c.Add(new Component("Name Context", "SCH-20.16"));
			c.Add(new Component("Name Validity Range", "SCH-20.17"));
			c.Add(new Component("Name Assembly Order", "SCH-20.18"));
			c.Add(new Component("Effective Date", "SCH-20.19"));
			c.Add(new Component("Expiration Date", "SCH-20.20"));
			c.Add(new Component("Professional Suffix", "SCH-20.21"));
			c.Add(new Component("Assigning Jurisdiction", "SCH-20.22"));
			c.Add(new Component("Assigning Agency or Department", "SCH-20.23"));
			f.Components = c;
			return f;
		}
		private Field SCH21()
		{
			Field f = new Field("Entered By Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "SCH-21.1"));
			c.Add(new Component("Tele-Communication Use Code", "SCH-21.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "SCH-21.3"));
			c.Add(new Component("Email Address", "SCH-21.4"));
			c.Add(new Component("Country Code", "SCH-21.5"));
			c.Add(new Component("Area City Code", "SCH-21.6"));
			c.Add(new Component("Local Number", "SCH-21.7"));
			c.Add(new Component("Extension", "SCH-21.8"));
			c.Add(new Component("", "SCH-21.9"));
			c.Add(new Component("Extension Prefix", "SCH-21.10"));
			c.Add(new Component("Speed Dial Code", "SCH-21.11"));
			c.Add(new Component("Unformatted Telephone Number", "SCH-21.12"));
			f.Components = c;
			return f;
		}
		private Field SCH22()
		{
			Field f = new Field("Entered By Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "SCH-22.1"));
			c.Add(new Component("Room", "SCH-22.2"));
			c.Add(new Component("Bed", "SCH-22.3"));
			c.Add(new Component("Facility", "SCH-22.4"));
			c.Add(new Component("Location Status", "SCH-22.5"));
			c.Add(new Component("Person Location Type", "SCH-22.6"));
			c.Add(new Component("Building", "SCH-22.7"));
			c.Add(new Component("Floor Number", "SCH-22.8"));
			c.Add(new Component("Location Description", "SCH-22.9"));
			c.Add(new Component("Comprehensive Location Identifier", "SCH-22.10"));
			c.Add(new Component("Assigning Authority for Location", "SCH-22.11"));
			f.Components = c;
			return f;
		}
		private Field SCH23()
		{
			Field f = new Field("Parent Placer Appointment ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SCH-23.1"));
			c.Add(new Component("Namespace ID", "SCH-23.2"));
			c.Add(new Component("Universal ID", "SCH-23.3"));
			c.Add(new Component("Universal ID Type", "SCH-23.4"));
			f.Components = c;
			return f;
		}
		private Field SCH24()
		{
			Field f = new Field("Parent Filler Appointment ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SCH-24.1"));
			c.Add(new Component("Namespace ID", "SCH-24.2"));
			c.Add(new Component("Universal ID", "SCH-24.3"));
			c.Add(new Component("Universal ID Type", "SCH-24.4"));
			f.Components = c;
			return f;
		}
		private Field SCH25()
		{
			Field f = new Field("Filler Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SCH-25.1"));
			c.Add(new Component("", "SCH-25.2"));
			c.Add(new Component("Name of Coding System", "SCH-25.3"));
			c.Add(new Component("Alternate Identifier", "SCH-25.4"));
			c.Add(new Component("Alternate Text", "SCH-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "SCH-25.6"));
			f.Components = c;
			return f;
		}
		private Field SCH26()
		{
			Field f = new Field("Placer Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SCH-26.1"));
			c.Add(new Component("Namespace ID", "SCH-26.2"));
			c.Add(new Component("Universal ID", "SCH-26.3"));
			c.Add(new Component("Universal ID Type", "SCH-26.4"));
			f.Components = c;
			return f;
		}
		private Field SCH27()
		{
			Field f = new Field("Filler Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SCH-27.1"));
			c.Add(new Component("Namespace ID", "SCH-27.2"));
			c.Add(new Component("Universal ID", "SCH-27.3"));
			c.Add(new Component("Universal ID Type", "SCH-27.4"));
			f.Components = c;
			return f;
		}
	}
}
