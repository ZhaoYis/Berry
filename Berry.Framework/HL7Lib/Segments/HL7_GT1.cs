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
/// GT1 Class: Constructs an HL7 GT1 Segment Object
/// </summary>
public class GT1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public GT1()
		{
			Name = "GT1";
			Description = "Guarantor";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(GT11());
			fs.Add(GT12());
			fs.Add(GT13());
			fs.Add(GT14());
			fs.Add(GT15());
			fs.Add(GT16());
			fs.Add(GT17());
			fs.Add(GT18());
			fs.Add(GT19());
			fs.Add(GT110());
			fs.Add(GT111());
			fs.Add(GT112());
			fs.Add(GT113());
			fs.Add(GT114());
			fs.Add(GT115());
			fs.Add(GT116());
			fs.Add(GT117());
			fs.Add(GT118());
			fs.Add(GT119());
			fs.Add(GT120());
			fs.Add(GT121());
			fs.Add(GT122());
			fs.Add(GT123());
			fs.Add(GT124());
			fs.Add(GT125());
			fs.Add(GT126());
			fs.Add(GT127());
			fs.Add(GT128());
			fs.Add(GT129());
			fs.Add(GT130());
			fs.Add(GT131());
			fs.Add(GT132());
			fs.Add(GT133());
			fs.Add(GT134());
			fs.Add(GT135());
			fs.Add(GT136());
			fs.Add(GT137());
			fs.Add(GT138());
			fs.Add(GT139());
			fs.Add(GT140());
			fs.Add(GT141());
			fs.Add(GT142());
			fs.Add(GT143());
			fs.Add(GT144());
			fs.Add(GT145());
			fs.Add(GT146());
			fs.Add(GT147());
			fs.Add(GT148());
			fs.Add(GT149());
			fs.Add(GT150());
			fs.Add(GT151());
			fs.Add(GT152());
			fs.Add(GT153());
			fs.Add(GT154());
			fs.Add(GT155());
			fs.Add(GT156());
			fs.Add(GT157());
			Fields = fs;
		}
		private Field GT11()
		{
			Field f = new Field("Set ID - GT1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "GT1-1.1"));
			f.Components = c;
			return f;
		}
		private Field GT12()
		{
			Field f = new Field("Guarantor Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "GT1-2.1"));
			c.Add(new Component("Check Digit", "GT1-2.2"));
			c.Add(new Component("Check Digit Scheme", "GT1-2.3"));
			c.Add(new Component("Assigning Authority", "GT1-2.4"));
			c.Add(new Component("Identifier Type Code", "GT1-2.5"));
			c.Add(new Component("Assigning Facility", "GT1-2.6"));
			c.Add(new Component("Effective Date", "GT1-2.7"));
			c.Add(new Component("Expiration Date", "GT1-2.8"));
			c.Add(new Component("Assigning Jurisdiction", "GT1-2.9"));
			c.Add(new Component("Assigning Agency or Department", "GT1-2.10"));
			f.Components = c;
			return f;
		}
		private Field GT13()
		{
			Field f = new Field("Guarantor Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "GT1-3.1"));
			c.Add(new Component("Given Name", "GT1-3.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "GT1-3.3"));
			c.Add(new Component("Suffix", "GT1-3.4"));
			c.Add(new Component("Prefix", "GT1-3.5"));
			c.Add(new Component("Degree", "GT1-3.6"));
			c.Add(new Component("Name Type Code", "GT1-3.7"));
			c.Add(new Component("Name Respresentation Code", "GT1-3.8"));
			c.Add(new Component("Name Context", "GT1-3.9"));
			c.Add(new Component("Name Validity Range", "GT1-3.10"));
			c.Add(new Component("Name Assembly Order", "GT1-3.11"));
			c.Add(new Component("Effective Date", "GT1-3.12"));
			c.Add(new Component("Expiration Date", "GT1-3.13"));
			c.Add(new Component("Professional Suffix", "GT1-3.14"));
			f.Components = c;
			return f;
		}
		private Field GT14()
		{
			Field f = new Field("Guarantor Spouse Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "GT1-4.1"));
			c.Add(new Component("Given Name", "GT1-4.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "GT1-4.3"));
			c.Add(new Component("Suffix", "GT1-4.4"));
			c.Add(new Component("Prefix", "GT1-4.5"));
			c.Add(new Component("Degree", "GT1-4.6"));
			c.Add(new Component("Name Type Code", "GT1-4.7"));
			c.Add(new Component("Name Respresentation Code", "GT1-4.8"));
			c.Add(new Component("Name Context", "GT1-4.9"));
			c.Add(new Component("Name Validity Range", "GT1-4.10"));
			c.Add(new Component("Name Assembly Order", "GT1-4.11"));
			c.Add(new Component("Effective Date", "GT1-4.12"));
			c.Add(new Component("Expiration Date", "GT1-4.13"));
			c.Add(new Component("Professional Suffix", "GT1-4.14"));
			f.Components = c;
			return f;
		}
		private Field GT15()
		{
			Field f = new Field("Guarantor Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "GT1-5.1"));
			c.Add(new Component("Other Designation", "GT1-5.2"));
			c.Add(new Component("City", "GT1-5.3"));
			c.Add(new Component("State or Province", "GT1-5.4"));
			c.Add(new Component("Zip or Postal Code", "GT1-5.5"));
			c.Add(new Component("Country", "GT1-5.6"));
			c.Add(new Component("Address Type", "GT1-5.7"));
			c.Add(new Component("Other Geographic Designation", "GT1-5.8"));
			c.Add(new Component("Country Parish Code", "GT1-5.9"));
			c.Add(new Component("Census Tract", "GT1-5.10"));
			c.Add(new Component("Address Representation Code", "GT1-5.11"));
			c.Add(new Component("Address Validity Range", "GT1-5.12"));
			c.Add(new Component("Effective Date", "GT1-5.13"));
			c.Add(new Component("Expiration Date", "GT1-5.14"));
			f.Components = c;
			return f;
		}
		private Field GT16()
		{
			Field f = new Field("Guarantor Ph Num - Home");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "GT1-6.1"));
			c.Add(new Component("Tele-Communication Use Code", "GT1-6.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "GT1-6.3"));
			c.Add(new Component("Email Address", "GT1-6.4"));
			c.Add(new Component("Country Code", "GT1-6.5"));
			c.Add(new Component("Area City Code", "GT1-6.6"));
			c.Add(new Component("Local Number", "GT1-6.7"));
			c.Add(new Component("Extension", "GT1-6.8"));
			c.Add(new Component("", "GT1-6.9"));
			c.Add(new Component("Extension Prefix", "GT1-6.10"));
			c.Add(new Component("Speed Dial Code", "GT1-6.11"));
			c.Add(new Component("Unformatted Telephone Number", "GT1-6.12"));
			f.Components = c;
			return f;
		}
		private Field GT17()
		{
			Field f = new Field("Guarantor Ph Num - Business");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "GT1-7.1"));
			c.Add(new Component("Tele-Communication Use Code", "GT1-7.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "GT1-7.3"));
			c.Add(new Component("Email Address", "GT1-7.4"));
			c.Add(new Component("Country Code", "GT1-7.5"));
			c.Add(new Component("Area City Code", "GT1-7.6"));
			c.Add(new Component("Local Number", "GT1-7.7"));
			c.Add(new Component("Extension", "GT1-7.8"));
			c.Add(new Component("", "GT1-7.9"));
			c.Add(new Component("Extension Prefix", "GT1-7.10"));
			c.Add(new Component("Speed Dial Code", "GT1-7.11"));
			c.Add(new Component("Unformatted Telephone Number", "GT1-7.12"));
			f.Components = c;
			return f;
		}
		private Field GT18()
		{
			Field f = new Field("Guarantor Date/Time Of Birth");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GT1-8.1"));
			c.Add(new Component("Degree of Precision", "GT1-8.2"));
			f.Components = c;
			return f;
		}
		private Field GT19()
		{
			Field f = new Field("Guarantor Administrative Sex");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-9.1"));
			f.Components = c;
			return f;
		}
		private Field GT110()
		{
			Field f = new Field("Guarantor Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-10.1"));
			f.Components = c;
			return f;
		}
		private Field GT111()
		{
			Field f = new Field("Guarantor Relationship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-11.1"));
			c.Add(new Component("", "GT1-11.2"));
			c.Add(new Component("Name of Coding System", "GT1-11.3"));
			c.Add(new Component("Alternate Identifier", "GT1-11.4"));
			c.Add(new Component("Alternate Text", "GT1-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-11.6"));
			f.Components = c;
			return f;
		}
		private Field GT112()
		{
			Field f = new Field("Guarantor SSN");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-12.1"));
			f.Components = c;
			return f;
		}
		private Field GT113()
		{
			Field f = new Field("Guarantor Date - Begin");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-13.1"));
			f.Components = c;
			return f;
		}
		private Field GT114()
		{
			Field f = new Field("Guarantor Date - End");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-14.1"));
			f.Components = c;
			return f;
		}
		private Field GT115()
		{
			Field f = new Field("Guarantor Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-15.1"));
			f.Components = c;
			return f;
		}
		private Field GT116()
		{
			Field f = new Field("Guarantor Employer Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "GT1-16.1"));
			c.Add(new Component("Given Name", "GT1-16.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "GT1-16.3"));
			c.Add(new Component("Suffix", "GT1-16.4"));
			c.Add(new Component("Prefix", "GT1-16.5"));
			c.Add(new Component("Degree", "GT1-16.6"));
			c.Add(new Component("Name Type Code", "GT1-16.7"));
			c.Add(new Component("Name Respresentation Code", "GT1-16.8"));
			c.Add(new Component("Name Context", "GT1-16.9"));
			c.Add(new Component("Name Validity Range", "GT1-16.10"));
			c.Add(new Component("Name Assembly Order", "GT1-16.11"));
			c.Add(new Component("Effective Date", "GT1-16.12"));
			c.Add(new Component("Expiration Date", "GT1-16.13"));
			c.Add(new Component("Professional Suffix", "GT1-16.14"));
			f.Components = c;
			return f;
		}
		private Field GT117()
		{
			Field f = new Field("Guarantor Employer Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "GT1-17.1"));
			c.Add(new Component("Other Designation", "GT1-17.2"));
			c.Add(new Component("City", "GT1-17.3"));
			c.Add(new Component("State or Province", "GT1-17.4"));
			c.Add(new Component("Zip or Postal Code", "GT1-17.5"));
			c.Add(new Component("Country", "GT1-17.6"));
			c.Add(new Component("Address Type", "GT1-17.7"));
			c.Add(new Component("Other Geographic Designation", "GT1-17.8"));
			c.Add(new Component("Country Parish Code", "GT1-17.9"));
			c.Add(new Component("Census Tract", "GT1-17.10"));
			c.Add(new Component("Address Representation Code", "GT1-17.11"));
			c.Add(new Component("Address Validity Range", "GT1-17.12"));
			c.Add(new Component("Effective Date", "GT1-17.13"));
			c.Add(new Component("Expiration Date", "GT1-17.14"));
			f.Components = c;
			return f;
		}
		private Field GT118()
		{
			Field f = new Field("Guarantor Employer Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "GT1-18.1"));
			c.Add(new Component("Tele-Communication Use Code", "GT1-18.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "GT1-18.3"));
			c.Add(new Component("Email Address", "GT1-18.4"));
			c.Add(new Component("Country Code", "GT1-18.5"));
			c.Add(new Component("Area City Code", "GT1-18.6"));
			c.Add(new Component("Local Number", "GT1-18.7"));
			c.Add(new Component("Extension", "GT1-18.8"));
			c.Add(new Component("", "GT1-18.9"));
			c.Add(new Component("Extension Prefix", "GT1-18.10"));
			c.Add(new Component("Speed Dial Code", "GT1-18.11"));
			c.Add(new Component("Unformatted Telephone Number", "GT1-18.12"));
			f.Components = c;
			return f;
		}
		private Field GT119()
		{
			Field f = new Field("Guarantor Employee ID Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "GT1-19.1"));
			c.Add(new Component("Check Digit", "GT1-19.2"));
			c.Add(new Component("Check Digit Scheme", "GT1-19.3"));
			c.Add(new Component("Assigning Authority", "GT1-19.4"));
			c.Add(new Component("Identifier Type Code", "GT1-19.5"));
			c.Add(new Component("Assigning Facility", "GT1-19.6"));
			c.Add(new Component("Effective Date", "GT1-19.7"));
			c.Add(new Component("Expiration Date", "GT1-19.8"));
			c.Add(new Component("Assigning Jurisdiction", "GT1-19.9"));
			c.Add(new Component("Assigning Agency or Department", "GT1-19.10"));
			f.Components = c;
			return f;
		}
		private Field GT120()
		{
			Field f = new Field("Guarantor Employment Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-20.1"));
			f.Components = c;
			return f;
		}
		private Field GT121()
		{
			Field f = new Field("Guarantor Organization Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "GT1-21.1"));
			c.Add(new Component("Organization Name Type Code", "GT1-21.2"));
			c.Add(new Component("ID Number", "GT1-21.3"));
			c.Add(new Component("Check Digit", "GT1-21.4"));
			c.Add(new Component("Check Digit Scheme", "GT1-21.5"));
			c.Add(new Component("Assigning Authority", "GT1-21.6"));
			c.Add(new Component("Identifier Type Code", "GT1-21.7"));
			c.Add(new Component("Assigning Facility", "GT1-21.8"));
			c.Add(new Component("Name Respresentation Code", "GT1-21.9"));
			c.Add(new Component("Organization Identifier", "GT1-21.10"));
			f.Components = c;
			return f;
		}
		private Field GT122()
		{
			Field f = new Field("Guarantor Billing Hold Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-22.1"));
			f.Components = c;
			return f;
		}
		private Field GT123()
		{
			Field f = new Field("Guarantor Credit Rating Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-23.1"));
			c.Add(new Component("", "GT1-23.2"));
			c.Add(new Component("Name of Coding System", "GT1-23.3"));
			c.Add(new Component("Alternate Identifier", "GT1-23.4"));
			c.Add(new Component("Alternate Text", "GT1-23.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-23.6"));
			f.Components = c;
			return f;
		}
		private Field GT124()
		{
			Field f = new Field("Guarantor Death Date And Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GT1-24.1"));
			c.Add(new Component("Degree of Precision", "GT1-24.2"));
			f.Components = c;
			return f;
		}
		private Field GT125()
		{
			Field f = new Field("Guarantor Death Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-25.1"));
			f.Components = c;
			return f;
		}
		private Field GT126()
		{
			Field f = new Field("Guarantor Charge Adjustment Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-26.1"));
			c.Add(new Component("", "GT1-26.2"));
			c.Add(new Component("Name of Coding System", "GT1-26.3"));
			c.Add(new Component("Alternate Identifier", "GT1-26.4"));
			c.Add(new Component("Alternate Text", "GT1-26.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-26.6"));
			f.Components = c;
			return f;
		}
		private Field GT127()
		{
			Field f = new Field("Guarantor Household Annual Income");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "GT1-27.1"));
			c.Add(new Component("Price Type", "GT1-27.2"));
			c.Add(new Component("From Value", "GT1-27.3"));
			c.Add(new Component("To Value", "GT1-27.4"));
			c.Add(new Component("Range Units", "GT1-27.5"));
			c.Add(new Component("Range Type", "GT1-27.6"));
			f.Components = c;
			return f;
		}
		private Field GT128()
		{
			Field f = new Field("Guarantor Household Size");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-28.1"));
			f.Components = c;
			return f;
		}
		private Field GT129()
		{
			Field f = new Field("Guarantor Employer ID Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "GT1-29.1"));
			c.Add(new Component("Check Digit", "GT1-29.2"));
			c.Add(new Component("Check Digit Scheme", "GT1-29.3"));
			c.Add(new Component("Assigning Authority", "GT1-29.4"));
			c.Add(new Component("Identifier Type Code", "GT1-29.5"));
			c.Add(new Component("Assigning Facility", "GT1-29.6"));
			c.Add(new Component("Effective Date", "GT1-29.7"));
			c.Add(new Component("Expiration Date", "GT1-29.8"));
			c.Add(new Component("Assigning Jurisdiction", "GT1-29.9"));
			c.Add(new Component("Assigning Agency or Department", "GT1-29.10"));
			f.Components = c;
			return f;
		}
		private Field GT130()
		{
			Field f = new Field("Guarantor Marital Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-30.1"));
			c.Add(new Component("", "GT1-30.2"));
			c.Add(new Component("Name of Coding System", "GT1-30.3"));
			c.Add(new Component("Alternate Identifier", "GT1-30.4"));
			c.Add(new Component("Alternate Text", "GT1-30.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-30.6"));
			f.Components = c;
			return f;
		}
		private Field GT131()
		{
			Field f = new Field("Guarantor Hire Effective Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-31.1"));
			f.Components = c;
			return f;
		}
		private Field GT132()
		{
			Field f = new Field("Employment Stop Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-32.1"));
			f.Components = c;
			return f;
		}
		private Field GT133()
		{
			Field f = new Field("Living Dependency");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-33.1"));
			f.Components = c;
			return f;
		}
		private Field GT134()
		{
			Field f = new Field("Ambulatory Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-34.1"));
			f.Components = c;
			return f;
		}
		private Field GT135()
		{
			Field f = new Field("Citizenship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-35.1"));
			c.Add(new Component("", "GT1-35.2"));
			c.Add(new Component("Name of Coding System", "GT1-35.3"));
			c.Add(new Component("Alternate Identifier", "GT1-35.4"));
			c.Add(new Component("Alternate Text", "GT1-35.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-35.6"));
			f.Components = c;
			return f;
		}
		private Field GT136()
		{
			Field f = new Field("Primary Language");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-36.1"));
			c.Add(new Component("", "GT1-36.2"));
			c.Add(new Component("Name of Coding System", "GT1-36.3"));
			c.Add(new Component("Alternate Identifier", "GT1-36.4"));
			c.Add(new Component("Alternate Text", "GT1-36.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-36.6"));
			f.Components = c;
			return f;
		}
		private Field GT137()
		{
			Field f = new Field("Living Arrangement");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-37.1"));
			f.Components = c;
			return f;
		}
		private Field GT138()
		{
			Field f = new Field("Publicity Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-38.1"));
			c.Add(new Component("", "GT1-38.2"));
			c.Add(new Component("Name of Coding System", "GT1-38.3"));
			c.Add(new Component("Alternate Identifier", "GT1-38.4"));
			c.Add(new Component("Alternate Text", "GT1-38.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-38.6"));
			f.Components = c;
			return f;
		}
		private Field GT139()
		{
			Field f = new Field("Protection Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-39.1"));
			f.Components = c;
			return f;
		}
		private Field GT140()
		{
			Field f = new Field("Student Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-40.1"));
			f.Components = c;
			return f;
		}
		private Field GT141()
		{
			Field f = new Field("Religion");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-41.1"));
			c.Add(new Component("", "GT1-41.2"));
			c.Add(new Component("Name of Coding System", "GT1-41.3"));
			c.Add(new Component("Alternate Identifier", "GT1-41.4"));
			c.Add(new Component("Alternate Text", "GT1-41.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-41.6"));
			f.Components = c;
			return f;
		}
		private Field GT142()
		{
			Field f = new Field("Mother's Maiden Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "GT1-42.1"));
			c.Add(new Component("Given Name", "GT1-42.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "GT1-42.3"));
			c.Add(new Component("Suffix", "GT1-42.4"));
			c.Add(new Component("Prefix", "GT1-42.5"));
			c.Add(new Component("Degree", "GT1-42.6"));
			c.Add(new Component("Name Type Code", "GT1-42.7"));
			c.Add(new Component("Name Respresentation Code", "GT1-42.8"));
			c.Add(new Component("Name Context", "GT1-42.9"));
			c.Add(new Component("Name Validity Range", "GT1-42.10"));
			c.Add(new Component("Name Assembly Order", "GT1-42.11"));
			c.Add(new Component("Effective Date", "GT1-42.12"));
			c.Add(new Component("Expiration Date", "GT1-42.13"));
			c.Add(new Component("Professional Suffix", "GT1-42.14"));
			f.Components = c;
			return f;
		}
		private Field GT143()
		{
			Field f = new Field("Nationality");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-43.1"));
			c.Add(new Component("", "GT1-43.2"));
			c.Add(new Component("Name of Coding System", "GT1-43.3"));
			c.Add(new Component("Alternate Identifier", "GT1-43.4"));
			c.Add(new Component("Alternate Text", "GT1-43.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-43.6"));
			f.Components = c;
			return f;
		}
		private Field GT144()
		{
			Field f = new Field("Ethnic Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-44.1"));
			c.Add(new Component("", "GT1-44.2"));
			c.Add(new Component("Name of Coding System", "GT1-44.3"));
			c.Add(new Component("Alternate Identifier", "GT1-44.4"));
			c.Add(new Component("Alternate Text", "GT1-44.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-44.6"));
			f.Components = c;
			return f;
		}
		private Field GT145()
		{
			Field f = new Field("Contact Person's Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "GT1-45.1"));
			c.Add(new Component("Given Name", "GT1-45.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "GT1-45.3"));
			c.Add(new Component("Suffix", "GT1-45.4"));
			c.Add(new Component("Prefix", "GT1-45.5"));
			c.Add(new Component("Degree", "GT1-45.6"));
			c.Add(new Component("Name Type Code", "GT1-45.7"));
			c.Add(new Component("Name Respresentation Code", "GT1-45.8"));
			c.Add(new Component("Name Context", "GT1-45.9"));
			c.Add(new Component("Name Validity Range", "GT1-45.10"));
			c.Add(new Component("Name Assembly Order", "GT1-45.11"));
			c.Add(new Component("Effective Date", "GT1-45.12"));
			c.Add(new Component("Expiration Date", "GT1-45.13"));
			c.Add(new Component("Professional Suffix", "GT1-45.14"));
			f.Components = c;
			return f;
		}
		private Field GT146()
		{
			Field f = new Field("Contact Person's Telephone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "GT1-46.1"));
			c.Add(new Component("Tele-Communication Use Code", "GT1-46.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "GT1-46.3"));
			c.Add(new Component("Email Address", "GT1-46.4"));
			c.Add(new Component("Country Code", "GT1-46.5"));
			c.Add(new Component("Area City Code", "GT1-46.6"));
			c.Add(new Component("Local Number", "GT1-46.7"));
			c.Add(new Component("Extension", "GT1-46.8"));
			c.Add(new Component("", "GT1-46.9"));
			c.Add(new Component("Extension Prefix", "GT1-46.10"));
			c.Add(new Component("Speed Dial Code", "GT1-46.11"));
			c.Add(new Component("Unformatted Telephone Number", "GT1-46.12"));
			f.Components = c;
			return f;
		}
		private Field GT147()
		{
			Field f = new Field("Contact Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-47.1"));
			c.Add(new Component("", "GT1-47.2"));
			c.Add(new Component("Name of Coding System", "GT1-47.3"));
			c.Add(new Component("Alternate Identifier", "GT1-47.4"));
			c.Add(new Component("Alternate Text", "GT1-47.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-47.6"));
			f.Components = c;
			return f;
		}
		private Field GT148()
		{
			Field f = new Field("Contact Relationship");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-48.1"));
			f.Components = c;
			return f;
		}
		private Field GT149()
		{
			Field f = new Field("Job Title");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-49.1"));
			f.Components = c;
			return f;
		}
		private Field GT150()
		{
			Field f = new Field("Job Code/Class");
			List<Component> c = new List<Component>();
			c.Add(new Component("Job Code", "GT1-50.1"));
			c.Add(new Component("Job Class", "GT1-50.2"));
			c.Add(new Component("Job Description", "GT1-50.3"));
			f.Components = c;
			return f;
		}
		private Field GT151()
		{
			Field f = new Field("Guarantor Employer's Organization Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "GT1-51.1"));
			c.Add(new Component("Organization Name Type Code", "GT1-51.2"));
			c.Add(new Component("ID Number", "GT1-51.3"));
			c.Add(new Component("Check Digit", "GT1-51.4"));
			c.Add(new Component("Check Digit Scheme", "GT1-51.5"));
			c.Add(new Component("Assigning Authority", "GT1-51.6"));
			c.Add(new Component("Identifier Type Code", "GT1-51.7"));
			c.Add(new Component("Assigning Facility", "GT1-51.8"));
			c.Add(new Component("Name Respresentation Code", "GT1-51.9"));
			c.Add(new Component("Organization Identifier", "GT1-51.10"));
			f.Components = c;
			return f;
		}
		private Field GT152()
		{
			Field f = new Field("Handicap");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-52.1"));
			f.Components = c;
			return f;
		}
		private Field GT153()
		{
			Field f = new Field("Job Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-53.1"));
			f.Components = c;
			return f;
		}
		private Field GT154()
		{
			Field f = new Field("Guarantor Financial Class");
			List<Component> c = new List<Component>();
			c.Add(new Component("Financial Class Code", "GT1-54.1"));
			c.Add(new Component("Effective Date", "GT1-54.2"));
			f.Components = c;
			return f;
		}
		private Field GT155()
		{
			Field f = new Field("Guarantor Race");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GT1-55.1"));
			c.Add(new Component("", "GT1-55.2"));
			c.Add(new Component("Name of Coding System", "GT1-55.3"));
			c.Add(new Component("Alternate Identifier", "GT1-55.4"));
			c.Add(new Component("Alternate Text", "GT1-55.5"));
			c.Add(new Component("Name of Alternate Coding System", "GT1-55.6"));
			f.Components = c;
			return f;
		}
		private Field GT156()
		{
			Field f = new Field("Guarantor Birth Place");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-56.1"));
			f.Components = c;
			return f;
		}
		private Field GT157()
		{
			Field f = new Field("VIP Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GT1-57.1"));
			f.Components = c;
			return f;
		}
	}
}
