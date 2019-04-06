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
/// NK1 Class: Constructs an HL7 NK1 Segment Object
/// </summary>
public class NK1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public NK1()
		{
			Name = "NK1";
			Description = "Next of Kin / Associated Parties";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(NK11());
			fs.Add(NK12());
			fs.Add(NK13());
			fs.Add(NK14());
			fs.Add(NK15());
			fs.Add(NK16());
			fs.Add(NK17());
			fs.Add(NK18());
			fs.Add(NK19());
			fs.Add(NK110());
			fs.Add(NK111());
			fs.Add(NK112());
			fs.Add(NK113());
			fs.Add(NK114());
			fs.Add(NK115());
			fs.Add(NK116());
			fs.Add(NK117());
			fs.Add(NK118());
			fs.Add(NK119());
			fs.Add(NK120());
			fs.Add(NK121());
			fs.Add(NK122());
			fs.Add(NK123());
			fs.Add(NK124());
			fs.Add(NK125());
			fs.Add(NK126());
			fs.Add(NK127());
			fs.Add(NK128());
			fs.Add(NK129());
			fs.Add(NK130());
			fs.Add(NK131());
			fs.Add(NK132());
			fs.Add(NK133());
			fs.Add(NK134());
			fs.Add(NK135());
			fs.Add(NK136());
			fs.Add(NK137());
			fs.Add(NK138());
			fs.Add(NK139());
			Fields = fs;
		}
		private Field NK11()
		{
			Field f = new Field("Set ID - NK1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "NK1-1.1"));
			f.Components = c;
			return f;
		}
		private Field NK12()
		{
			Field f = new Field("Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "NK1-2.1"));
			c.Add(new Component("Given Name", "NK1-2.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "NK1-2.3"));
			c.Add(new Component("Suffix", "NK1-2.4"));
			c.Add(new Component("Prefix", "NK1-2.5"));
			c.Add(new Component("Degree", "NK1-2.6"));
			c.Add(new Component("Name Type Code", "NK1-2.7"));
			c.Add(new Component("Name Respresentation Code", "NK1-2.8"));
			c.Add(new Component("Name Context", "NK1-2.9"));
			c.Add(new Component("Name Validity Range", "NK1-2.10"));
			c.Add(new Component("Name Assembly Order", "NK1-2.11"));
			c.Add(new Component("Effective Date", "NK1-2.12"));
			c.Add(new Component("Expiration Date", "NK1-2.13"));
			c.Add(new Component("Professional Suffix", "NK1-2.14"));
			f.Components = c;
			return f;
		}
		private Field NK13()
		{
			Field f = new Field("Relationship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-3.1"));
			c.Add(new Component("", "NK1-3.2"));
			c.Add(new Component("Name of Coding System", "NK1-3.3"));
			c.Add(new Component("Alternate Identifier", "NK1-3.4"));
			c.Add(new Component("Alternate Text", "NK1-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-3.6"));
			f.Components = c;
			return f;
		}
		private Field NK14()
		{
			Field f = new Field("Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "NK1-4.1"));
			c.Add(new Component("Other Designation", "NK1-4.2"));
			c.Add(new Component("City", "NK1-4.3"));
			c.Add(new Component("State or Province", "NK1-4.4"));
			c.Add(new Component("Zip or Postal Code", "NK1-4.5"));
			c.Add(new Component("Country", "NK1-4.6"));
			c.Add(new Component("Address Type", "NK1-4.7"));
			c.Add(new Component("Other Geographic Designation", "NK1-4.8"));
			c.Add(new Component("Country Parish Code", "NK1-4.9"));
			c.Add(new Component("Census Tract", "NK1-4.10"));
			c.Add(new Component("Address Representation Code", "NK1-4.11"));
			c.Add(new Component("Address Validity Range", "NK1-4.12"));
			c.Add(new Component("Effective Date", "NK1-4.13"));
			c.Add(new Component("Expiration Date", "NK1-4.14"));
			f.Components = c;
			return f;
		}
		private Field NK15()
		{
			Field f = new Field("Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "NK1-5.1"));
			c.Add(new Component("Tele-Communication Use Code", "NK1-5.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "NK1-5.3"));
			c.Add(new Component("Email Address", "NK1-5.4"));
			c.Add(new Component("Country Code", "NK1-5.5"));
			c.Add(new Component("Area City Code", "NK1-5.6"));
			c.Add(new Component("Local Number", "NK1-5.7"));
			c.Add(new Component("Extension", "NK1-5.8"));
			c.Add(new Component("", "NK1-5.9"));
			c.Add(new Component("Extension Prefix", "NK1-5.10"));
			c.Add(new Component("Speed Dial Code", "NK1-5.11"));
			c.Add(new Component("Unformatted Telephone Number", "NK1-5.12"));
			f.Components = c;
			return f;
		}
		private Field NK16()
		{
			Field f = new Field("Business Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "NK1-6.1"));
			c.Add(new Component("Tele-Communication Use Code", "NK1-6.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "NK1-6.3"));
			c.Add(new Component("Email Address", "NK1-6.4"));
			c.Add(new Component("Country Code", "NK1-6.5"));
			c.Add(new Component("Area City Code", "NK1-6.6"));
			c.Add(new Component("Local Number", "NK1-6.7"));
			c.Add(new Component("Extension", "NK1-6.8"));
			c.Add(new Component("", "NK1-6.9"));
			c.Add(new Component("Extension Prefix", "NK1-6.10"));
			c.Add(new Component("Speed Dial Code", "NK1-6.11"));
			c.Add(new Component("Unformatted Telephone Number", "NK1-6.12"));
			f.Components = c;
			return f;
		}
		private Field NK17()
		{
			Field f = new Field("Contact Role");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-7.1"));
			c.Add(new Component("", "NK1-7.2"));
			c.Add(new Component("Name of Coding System", "NK1-7.3"));
			c.Add(new Component("Alternate Identifier", "NK1-7.4"));
			c.Add(new Component("Alternate Text", "NK1-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-7.6"));
			f.Components = c;
			return f;
		}
		private Field NK18()
		{
			Field f = new Field("Start Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-8.1"));
			f.Components = c;
			return f;
		}
		private Field NK19()
		{
			Field f = new Field("End Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-9.1"));
			f.Components = c;
			return f;
		}
		private Field NK110()
		{
			Field f = new Field("Next of Kin / Associated Parties Job Title");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-10.1"));
			f.Components = c;
			return f;
		}
		private Field NK111()
		{
			Field f = new Field("Next of Kin / Associated Parties Job Code/Class");
			List<Component> c = new List<Component>();
			c.Add(new Component("Job Code", "NK1-11.1"));
			c.Add(new Component("Job Class", "NK1-11.2"));
			c.Add(new Component("Job Description", "NK1-11.3"));
			f.Components = c;
			return f;
		}
		private Field NK112()
		{
			Field f = new Field("Next of Kin / Associated Parties Employee Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "NK1-12.1"));
			c.Add(new Component("Check Digit", "NK1-12.2"));
			c.Add(new Component("Check Digit Scheme", "NK1-12.3"));
			c.Add(new Component("Assigning Authority", "NK1-12.4"));
			c.Add(new Component("Identifier Type Code", "NK1-12.5"));
			c.Add(new Component("Assigning Facility", "NK1-12.6"));
			c.Add(new Component("Effective Date", "NK1-12.7"));
			c.Add(new Component("Expiration Date", "NK1-12.8"));
			c.Add(new Component("Assigning Jurisdiction", "NK1-12.9"));
			c.Add(new Component("Assigning Agency or Department", "NK1-12.10"));
			f.Components = c;
			return f;
		}
		private Field NK113()
		{
			Field f = new Field("Organization Name - NK1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "NK1-13.1"));
			c.Add(new Component("Organization Name Type Code", "NK1-13.2"));
			c.Add(new Component("ID Number", "NK1-13.3"));
			c.Add(new Component("Check Digit", "NK1-13.4"));
			c.Add(new Component("Check Digit Scheme", "NK1-13.5"));
			c.Add(new Component("Assigning Authority", "NK1-13.6"));
			c.Add(new Component("Identifier Type Code", "NK1-13.7"));
			c.Add(new Component("Assigning Facility", "NK1-13.8"));
			c.Add(new Component("Name Respresentation Code", "NK1-13.9"));
			c.Add(new Component("Organization Identifier", "NK1-13.10"));
			f.Components = c;
			return f;
		}
		private Field NK114()
		{
			Field f = new Field("Marital Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-14.1"));
			c.Add(new Component("", "NK1-14.2"));
			c.Add(new Component("Name of Coding System", "NK1-14.3"));
			c.Add(new Component("Alternate Identifier", "NK1-14.4"));
			c.Add(new Component("Alternate Text", "NK1-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-14.6"));
			f.Components = c;
			return f;
		}
		private Field NK115()
		{
			Field f = new Field("Administrative Sex");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-15.1"));
			f.Components = c;
			return f;
		}
		private Field NK116()
		{
			Field f = new Field("Date/Time of Birth");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "NK1-16.1"));
			c.Add(new Component("Degree of Precision", "NK1-16.2"));
			f.Components = c;
			return f;
		}
		private Field NK117()
		{
			Field f = new Field("Living Dependency");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-17.1"));
			f.Components = c;
			return f;
		}
		private Field NK118()
		{
			Field f = new Field("Ambulatory Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-18.1"));
			f.Components = c;
			return f;
		}
		private Field NK119()
		{
			Field f = new Field("Citizenship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-19.1"));
			c.Add(new Component("", "NK1-19.2"));
			c.Add(new Component("Name of Coding System", "NK1-19.3"));
			c.Add(new Component("Alternate Identifier", "NK1-19.4"));
			c.Add(new Component("Alternate Text", "NK1-19.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-19.6"));
			f.Components = c;
			return f;
		}
		private Field NK120()
		{
			Field f = new Field("Primary Language");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-20.1"));
			c.Add(new Component("", "NK1-20.2"));
			c.Add(new Component("Name of Coding System", "NK1-20.3"));
			c.Add(new Component("Alternate Identifier", "NK1-20.4"));
			c.Add(new Component("Alternate Text", "NK1-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-20.6"));
			f.Components = c;
			return f;
		}
		private Field NK121()
		{
			Field f = new Field("Living Arrangement");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-21.1"));
			f.Components = c;
			return f;
		}
		private Field NK122()
		{
			Field f = new Field("Publicity Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-22.1"));
			c.Add(new Component("", "NK1-22.2"));
			c.Add(new Component("Name of Coding System", "NK1-22.3"));
			c.Add(new Component("Alternate Identifier", "NK1-22.4"));
			c.Add(new Component("Alternate Text", "NK1-22.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-22.6"));
			f.Components = c;
			return f;
		}
		private Field NK123()
		{
			Field f = new Field("Protection Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-23.1"));
			f.Components = c;
			return f;
		}
		private Field NK124()
		{
			Field f = new Field("Student Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-24.1"));
			f.Components = c;
			return f;
		}
		private Field NK125()
		{
			Field f = new Field("Religion");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-25.1"));
			c.Add(new Component("", "NK1-25.2"));
			c.Add(new Component("Name of Coding System", "NK1-25.3"));
			c.Add(new Component("Alternate Identifier", "NK1-25.4"));
			c.Add(new Component("Alternate Text", "NK1-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-25.6"));
			f.Components = c;
			return f;
		}
		private Field NK126()
		{
			Field f = new Field("Mother's Maiden Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "NK1-26.1"));
			c.Add(new Component("Given Name", "NK1-26.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "NK1-26.3"));
			c.Add(new Component("Suffix", "NK1-26.4"));
			c.Add(new Component("Prefix", "NK1-26.5"));
			c.Add(new Component("Degree", "NK1-26.6"));
			c.Add(new Component("Name Type Code", "NK1-26.7"));
			c.Add(new Component("Name Respresentation Code", "NK1-26.8"));
			c.Add(new Component("Name Context", "NK1-26.9"));
			c.Add(new Component("Name Validity Range", "NK1-26.10"));
			c.Add(new Component("Name Assembly Order", "NK1-26.11"));
			c.Add(new Component("Effective Date", "NK1-26.12"));
			c.Add(new Component("Expiration Date", "NK1-26.13"));
			c.Add(new Component("Professional Suffix", "NK1-26.14"));
			f.Components = c;
			return f;
		}
		private Field NK127()
		{
			Field f = new Field("Nationality");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-27.1"));
			c.Add(new Component("", "NK1-27.2"));
			c.Add(new Component("Name of Coding System", "NK1-27.3"));
			c.Add(new Component("Alternate Identifier", "NK1-27.4"));
			c.Add(new Component("Alternate Text", "NK1-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-27.6"));
			f.Components = c;
			return f;
		}
		private Field NK128()
		{
			Field f = new Field("Ethnic Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-28.1"));
			c.Add(new Component("", "NK1-28.2"));
			c.Add(new Component("Name of Coding System", "NK1-28.3"));
			c.Add(new Component("Alternate Identifier", "NK1-28.4"));
			c.Add(new Component("Alternate Text", "NK1-28.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-28.6"));
			f.Components = c;
			return f;
		}
		private Field NK129()
		{
			Field f = new Field("Contact Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-29.1"));
			c.Add(new Component("", "NK1-29.2"));
			c.Add(new Component("Name of Coding System", "NK1-29.3"));
			c.Add(new Component("Alternate Identifier", "NK1-29.4"));
			c.Add(new Component("Alternate Text", "NK1-29.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-29.6"));
			f.Components = c;
			return f;
		}
		private Field NK130()
		{
			Field f = new Field("Contact Person's Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "NK1-30.1"));
			c.Add(new Component("Given Name", "NK1-30.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "NK1-30.3"));
			c.Add(new Component("Suffix", "NK1-30.4"));
			c.Add(new Component("Prefix", "NK1-30.5"));
			c.Add(new Component("Degree", "NK1-30.6"));
			c.Add(new Component("Name Type Code", "NK1-30.7"));
			c.Add(new Component("Name Respresentation Code", "NK1-30.8"));
			c.Add(new Component("Name Context", "NK1-30.9"));
			c.Add(new Component("Name Validity Range", "NK1-30.10"));
			c.Add(new Component("Name Assembly Order", "NK1-30.11"));
			c.Add(new Component("Effective Date", "NK1-30.12"));
			c.Add(new Component("Expiration Date", "NK1-30.13"));
			c.Add(new Component("Professional Suffix", "NK1-30.14"));
			f.Components = c;
			return f;
		}
		private Field NK131()
		{
			Field f = new Field("Contact Person's Telephone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "NK1-31.1"));
			c.Add(new Component("Tele-Communication Use Code", "NK1-31.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "NK1-31.3"));
			c.Add(new Component("Email Address", "NK1-31.4"));
			c.Add(new Component("Country Code", "NK1-31.5"));
			c.Add(new Component("Area City Code", "NK1-31.6"));
			c.Add(new Component("Local Number", "NK1-31.7"));
			c.Add(new Component("Extension", "NK1-31.8"));
			c.Add(new Component("", "NK1-31.9"));
			c.Add(new Component("Extension Prefix", "NK1-31.10"));
			c.Add(new Component("Speed Dial Code", "NK1-31.11"));
			c.Add(new Component("Unformatted Telephone Number", "NK1-31.12"));
			f.Components = c;
			return f;
		}
		private Field NK132()
		{
			Field f = new Field("Contact Person's Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "NK1-32.1"));
			c.Add(new Component("Other Designation", "NK1-32.2"));
			c.Add(new Component("City", "NK1-32.3"));
			c.Add(new Component("State or Province", "NK1-32.4"));
			c.Add(new Component("Zip or Postal Code", "NK1-32.5"));
			c.Add(new Component("Country", "NK1-32.6"));
			c.Add(new Component("Address Type", "NK1-32.7"));
			c.Add(new Component("Other Geographic Designation", "NK1-32.8"));
			c.Add(new Component("Country Parish Code", "NK1-32.9"));
			c.Add(new Component("Census Tract", "NK1-32.10"));
			c.Add(new Component("Address Representation Code", "NK1-32.11"));
			c.Add(new Component("Address Validity Range", "NK1-32.12"));
			c.Add(new Component("Effective Date", "NK1-32.13"));
			c.Add(new Component("Expiration Date", "NK1-32.14"));
			f.Components = c;
			return f;
		}
		private Field NK133()
		{
			Field f = new Field("Next of Kin/Associated Party's Identifiers");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "NK1-33.1"));
			c.Add(new Component("Check Digit", "NK1-33.2"));
			c.Add(new Component("Check Digit Scheme", "NK1-33.3"));
			c.Add(new Component("Assigning Authority", "NK1-33.4"));
			c.Add(new Component("Identifier Type Code", "NK1-33.5"));
			c.Add(new Component("Assigning Facility", "NK1-33.6"));
			c.Add(new Component("Effective Date", "NK1-33.7"));
			c.Add(new Component("Expiration Date", "NK1-33.8"));
			c.Add(new Component("Assigning Jurisdiction", "NK1-33.9"));
			c.Add(new Component("Assigning Agency or Department", "NK1-33.10"));
			f.Components = c;
			return f;
		}
		private Field NK134()
		{
			Field f = new Field("Job Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-34.1"));
			f.Components = c;
			return f;
		}
		private Field NK135()
		{
			Field f = new Field("Race");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NK1-35.1"));
			c.Add(new Component("", "NK1-35.2"));
			c.Add(new Component("Name of Coding System", "NK1-35.3"));
			c.Add(new Component("Alternate Identifier", "NK1-35.4"));
			c.Add(new Component("Alternate Text", "NK1-35.5"));
			c.Add(new Component("Name of Alternate Coding System", "NK1-35.6"));
			f.Components = c;
			return f;
		}
		private Field NK136()
		{
			Field f = new Field("Handicap");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-36.1"));
			f.Components = c;
			return f;
		}
		private Field NK137()
		{
			Field f = new Field("Contact Person Social Security Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-37.1"));
			f.Components = c;
			return f;
		}
		private Field NK138()
		{
			Field f = new Field("Next of Kin Birth Place");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-38.1"));
			f.Components = c;
			return f;
		}
		private Field NK139()
		{
			Field f = new Field("VIP Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NK1-39.1"));
			f.Components = c;
			return f;
		}
	}
}
