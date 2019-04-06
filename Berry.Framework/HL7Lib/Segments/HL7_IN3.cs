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
/// IN3 Class: Constructs an HL7 IN3 Segment Object
/// </summary>
public class IN3
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public IN3()
		{
			Name = "IN3";
			Description = "Insurance Additional Information, Certification";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(IN31());
			fs.Add(IN32());
			fs.Add(IN33());
			fs.Add(IN34());
			fs.Add(IN35());
			fs.Add(IN36());
			fs.Add(IN37());
			fs.Add(IN38());
			fs.Add(IN39());
			fs.Add(IN310());
			fs.Add(IN311());
			fs.Add(IN312());
			fs.Add(IN313());
			fs.Add(IN314());
			fs.Add(IN315());
			fs.Add(IN316());
			fs.Add(IN317());
			fs.Add(IN318());
			fs.Add(IN319());
			fs.Add(IN320());
			fs.Add(IN321());
			fs.Add(IN322());
			fs.Add(IN323());
			fs.Add(IN324());
			fs.Add(IN325());
			Fields = fs;
		}
		private Field IN31()
		{
			Field f = new Field("Set ID - IN3");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "IN3-1.1"));
			f.Components = c;
			return f;
		}
		private Field IN32()
		{
			Field f = new Field("Certification Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN3-2.1"));
			c.Add(new Component("Check Digit", "IN3-2.2"));
			c.Add(new Component("Check Digit Scheme", "IN3-2.3"));
			c.Add(new Component("Assigning Authority", "IN3-2.4"));
			c.Add(new Component("Identifier Type Code", "IN3-2.5"));
			c.Add(new Component("Assigning Facility", "IN3-2.6"));
			c.Add(new Component("Effective Date", "IN3-2.7"));
			c.Add(new Component("Expiration Date", "IN3-2.8"));
			c.Add(new Component("Assigning Jurisdiction", "IN3-2.9"));
			c.Add(new Component("Assigning Agency or Department", "IN3-2.10"));
			f.Components = c;
			return f;
		}
		private Field IN33()
		{
			Field f = new Field("Certified By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN3-3.1"));
			c.Add(new Component("Family Name", "IN3-3.2"));
			c.Add(new Component("Given Name", "IN3-3.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN3-3.4"));
			c.Add(new Component("Suffix", "IN3-3.5"));
			c.Add(new Component("Prefix", "IN3-3.6"));
			c.Add(new Component("Degree", "IN3-3.7"));
			c.Add(new Component("Source Table", "IN3-3.8"));
			c.Add(new Component("Assigning Authority", "IN3-3.9"));
			c.Add(new Component("Name Type Code", "IN3-3.10"));
			c.Add(new Component("Identifier Check Digit", "IN3-3.11"));
			c.Add(new Component("Check Digit Scheme", "IN3-3.12"));
			c.Add(new Component("Identifier Type Code", "IN3-3.13"));
			c.Add(new Component("Assigning Facility", "IN3-3.14"));
			c.Add(new Component("Name Respresentation Code", "IN3-3.15"));
			c.Add(new Component("Name Context", "IN3-3.16"));
			c.Add(new Component("Name Validity Range", "IN3-3.17"));
			c.Add(new Component("Name Assembly Order", "IN3-3.18"));
			c.Add(new Component("Effective Date", "IN3-3.19"));
			c.Add(new Component("Expiration Date", "IN3-3.20"));
			c.Add(new Component("Professional Suffix", "IN3-3.21"));
			c.Add(new Component("Assigning Jurisdiction", "IN3-3.22"));
			c.Add(new Component("Assigning Agency or Department", "IN3-3.23"));
			f.Components = c;
			return f;
		}
		private Field IN34()
		{
			Field f = new Field("Certification Required");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN3-4.1"));
			f.Components = c;
			return f;
		}
		private Field IN35()
		{
			Field f = new Field("Penalty");
			List<Component> c = new List<Component>();
			c.Add(new Component("Money or Percentage Indicator", "IN3-5.1"));
			c.Add(new Component("MoneyorPercentageQuantity", "IN3-5.2"));
			c.Add(new Component("Currency Denomination", "IN3-5.3"));
			f.Components = c;
			return f;
		}
		private Field IN36()
		{
			Field f = new Field("Certification Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IN3-6.1"));
			c.Add(new Component("Degree of Precision", "IN3-6.2"));
			f.Components = c;
			return f;
		}
		private Field IN37()
		{
			Field f = new Field("Certification Modify Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IN3-7.1"));
			c.Add(new Component("Degree of Precision", "IN3-7.2"));
			f.Components = c;
			return f;
		}
		private Field IN38()
		{
			Field f = new Field("Operator");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN3-8.1"));
			c.Add(new Component("Family Name", "IN3-8.2"));
			c.Add(new Component("Given Name", "IN3-8.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN3-8.4"));
			c.Add(new Component("Suffix", "IN3-8.5"));
			c.Add(new Component("Prefix", "IN3-8.6"));
			c.Add(new Component("Degree", "IN3-8.7"));
			c.Add(new Component("Source Table", "IN3-8.8"));
			c.Add(new Component("Assigning Authority", "IN3-8.9"));
			c.Add(new Component("Name Type Code", "IN3-8.10"));
			c.Add(new Component("Identifier Check Digit", "IN3-8.11"));
			c.Add(new Component("Check Digit Scheme", "IN3-8.12"));
			c.Add(new Component("Identifier Type Code", "IN3-8.13"));
			c.Add(new Component("Assigning Facility", "IN3-8.14"));
			c.Add(new Component("Name Respresentation Code", "IN3-8.15"));
			c.Add(new Component("Name Context", "IN3-8.16"));
			c.Add(new Component("Name Validity Range", "IN3-8.17"));
			c.Add(new Component("Name Assembly Order", "IN3-8.18"));
			c.Add(new Component("Effective Date", "IN3-8.19"));
			c.Add(new Component("Expiration Date", "IN3-8.20"));
			c.Add(new Component("Professional Suffix", "IN3-8.21"));
			c.Add(new Component("Assigning Jurisdiction", "IN3-8.22"));
			c.Add(new Component("Assigning Agency or Department", "IN3-8.23"));
			f.Components = c;
			return f;
		}
		private Field IN39()
		{
			Field f = new Field("Certification Begin Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN3-9.1"));
			f.Components = c;
			return f;
		}
		private Field IN310()
		{
			Field f = new Field("Certification End Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN3-10.1"));
			f.Components = c;
			return f;
		}
		private Field IN311()
		{
			Field f = new Field("Days");
			List<Component> c = new List<Component>();
			c.Add(new Component("Day Type", "IN3-11.1"));
			c.Add(new Component("Number of Days", "IN3-11.2"));
			f.Components = c;
			return f;
		}
		private Field IN312()
		{
			Field f = new Field("Non-Concur Code/Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN3-12.1"));
			c.Add(new Component("", "IN3-12.2"));
			c.Add(new Component("Name of Coding System", "IN3-12.3"));
			c.Add(new Component("Alternate Identifier", "IN3-12.4"));
			c.Add(new Component("Alternate Text", "IN3-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN3-12.6"));
			f.Components = c;
			return f;
		}
		private Field IN313()
		{
			Field f = new Field("Non-Concur Effective Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IN3-13.1"));
			c.Add(new Component("Degree of Precision", "IN3-13.2"));
			f.Components = c;
			return f;
		}
		private Field IN314()
		{
			Field f = new Field("Physician Reviewer");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN3-14.1"));
			c.Add(new Component("Family Name", "IN3-14.2"));
			c.Add(new Component("Given Name", "IN3-14.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN3-14.4"));
			c.Add(new Component("Suffix", "IN3-14.5"));
			c.Add(new Component("Prefix", "IN3-14.6"));
			c.Add(new Component("Degree", "IN3-14.7"));
			c.Add(new Component("Source Table", "IN3-14.8"));
			c.Add(new Component("Assigning Authority", "IN3-14.9"));
			c.Add(new Component("Name Type Code", "IN3-14.10"));
			c.Add(new Component("Identifier Check Digit", "IN3-14.11"));
			c.Add(new Component("Check Digit Scheme", "IN3-14.12"));
			c.Add(new Component("Identifier Type Code", "IN3-14.13"));
			c.Add(new Component("Assigning Facility", "IN3-14.14"));
			c.Add(new Component("Name Respresentation Code", "IN3-14.15"));
			c.Add(new Component("Name Context", "IN3-14.16"));
			c.Add(new Component("Name Validity Range", "IN3-14.17"));
			c.Add(new Component("Name Assembly Order", "IN3-14.18"));
			c.Add(new Component("Effective Date", "IN3-14.19"));
			c.Add(new Component("Expiration Date", "IN3-14.20"));
			c.Add(new Component("Professional Suffix", "IN3-14.21"));
			c.Add(new Component("Assigning Jurisdiction", "IN3-14.22"));
			c.Add(new Component("Assigning Agency or Department", "IN3-14.23"));
			f.Components = c;
			return f;
		}
		private Field IN315()
		{
			Field f = new Field("Certification Contact");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN3-15.1"));
			f.Components = c;
			return f;
		}
		private Field IN316()
		{
			Field f = new Field("Certification Contact Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "IN3-16.1"));
			c.Add(new Component("Tele-Communication Use Code", "IN3-16.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "IN3-16.3"));
			c.Add(new Component("Email Address", "IN3-16.4"));
			c.Add(new Component("Country Code", "IN3-16.5"));
			c.Add(new Component("Area City Code", "IN3-16.6"));
			c.Add(new Component("Local Number", "IN3-16.7"));
			c.Add(new Component("Extension", "IN3-16.8"));
			c.Add(new Component("", "IN3-16.9"));
			c.Add(new Component("Extension Prefix", "IN3-16.10"));
			c.Add(new Component("Speed Dial Code", "IN3-16.11"));
			c.Add(new Component("Unformatted Telephone Number", "IN3-16.12"));
			f.Components = c;
			return f;
		}
		private Field IN317()
		{
			Field f = new Field("Appeal Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN3-17.1"));
			c.Add(new Component("", "IN3-17.2"));
			c.Add(new Component("Name of Coding System", "IN3-17.3"));
			c.Add(new Component("Alternate Identifier", "IN3-17.4"));
			c.Add(new Component("Alternate Text", "IN3-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN3-17.6"));
			f.Components = c;
			return f;
		}
		private Field IN318()
		{
			Field f = new Field("Certification Agency");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN3-18.1"));
			c.Add(new Component("", "IN3-18.2"));
			c.Add(new Component("Name of Coding System", "IN3-18.3"));
			c.Add(new Component("Alternate Identifier", "IN3-18.4"));
			c.Add(new Component("Alternate Text", "IN3-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN3-18.6"));
			f.Components = c;
			return f;
		}
		private Field IN319()
		{
			Field f = new Field("Certification Agency Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "IN3-19.1"));
			c.Add(new Component("Tele-Communication Use Code", "IN3-19.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "IN3-19.3"));
			c.Add(new Component("Email Address", "IN3-19.4"));
			c.Add(new Component("Country Code", "IN3-19.5"));
			c.Add(new Component("Area City Code", "IN3-19.6"));
			c.Add(new Component("Local Number", "IN3-19.7"));
			c.Add(new Component("Extension", "IN3-19.8"));
			c.Add(new Component("", "IN3-19.9"));
			c.Add(new Component("Extension Prefix", "IN3-19.10"));
			c.Add(new Component("Speed Dial Code", "IN3-19.11"));
			c.Add(new Component("Unformatted Telephone Number", "IN3-19.12"));
			f.Components = c;
			return f;
		}
		private Field IN320()
		{
			Field f = new Field("Pre-Certification Requirement");
			List<Component> c = new List<Component>();
			c.Add(new Component("Certification Patient Type", "IN3-20.1"));
			c.Add(new Component("Certification Required", "IN3-20.2"));
			c.Add(new Component("Date Time Certification Required", "IN3-20.3"));
			f.Components = c;
			return f;
		}
		private Field IN321()
		{
			Field f = new Field("Case Manager");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN3-21.1"));
			f.Components = c;
			return f;
		}
		private Field IN322()
		{
			Field f = new Field("Second Opinion Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN3-22.1"));
			f.Components = c;
			return f;
		}
		private Field IN323()
		{
			Field f = new Field("Second Opinion Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN3-23.1"));
			f.Components = c;
			return f;
		}
		private Field IN324()
		{
			Field f = new Field("Second Opinion Documentation Received");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN3-24.1"));
			f.Components = c;
			return f;
		}
		private Field IN325()
		{
			Field f = new Field("Second Opinion Physician");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN3-25.1"));
			c.Add(new Component("Family Name", "IN3-25.2"));
			c.Add(new Component("Given Name", "IN3-25.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN3-25.4"));
			c.Add(new Component("Suffix", "IN3-25.5"));
			c.Add(new Component("Prefix", "IN3-25.6"));
			c.Add(new Component("Degree", "IN3-25.7"));
			c.Add(new Component("Source Table", "IN3-25.8"));
			c.Add(new Component("Assigning Authority", "IN3-25.9"));
			c.Add(new Component("Name Type Code", "IN3-25.10"));
			c.Add(new Component("Identifier Check Digit", "IN3-25.11"));
			c.Add(new Component("Check Digit Scheme", "IN3-25.12"));
			c.Add(new Component("Identifier Type Code", "IN3-25.13"));
			c.Add(new Component("Assigning Facility", "IN3-25.14"));
			c.Add(new Component("Name Respresentation Code", "IN3-25.15"));
			c.Add(new Component("Name Context", "IN3-25.16"));
			c.Add(new Component("Name Validity Range", "IN3-25.17"));
			c.Add(new Component("Name Assembly Order", "IN3-25.18"));
			c.Add(new Component("Effective Date", "IN3-25.19"));
			c.Add(new Component("Expiration Date", "IN3-25.20"));
			c.Add(new Component("Professional Suffix", "IN3-25.21"));
			c.Add(new Component("Assigning Jurisdiction", "IN3-25.22"));
			c.Add(new Component("Assigning Agency or Department", "IN3-25.23"));
			f.Components = c;
			return f;
		}
	}
}
