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
/// CM0 Class: Constructs an HL7 CM0 Segment Object
/// </summary>
public class CM0
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CM0()
		{
			Name = "CM0";
			Description = "Clinical Study Master";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CM01());
			fs.Add(CM02());
			fs.Add(CM03());
			fs.Add(CM04());
			fs.Add(CM05());
			fs.Add(CM06());
			fs.Add(CM07());
			fs.Add(CM08());
			fs.Add(CM09());
			fs.Add(CM010());
			fs.Add(CM011());
			Fields = fs;
		}
		private Field CM01()
		{
			Field f = new Field("Set ID - CM0");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "CM0-1.1"));
			f.Components = c;
			return f;
		}
		private Field CM02()
		{
			Field f = new Field("Sponsor Study ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "CM0-2.1"));
			c.Add(new Component("Namespace ID", "CM0-2.2"));
			c.Add(new Component("Universal ID", "CM0-2.3"));
			c.Add(new Component("Universal ID Type", "CM0-2.4"));
			f.Components = c;
			return f;
		}
		private Field CM03()
		{
			Field f = new Field("Alternate Study ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "CM0-3.1"));
			c.Add(new Component("Namespace ID", "CM0-3.2"));
			c.Add(new Component("Universal ID", "CM0-3.3"));
			c.Add(new Component("Universal ID Type", "CM0-3.4"));
			f.Components = c;
			return f;
		}
		private Field CM04()
		{
			Field f = new Field("Title of Study");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CM0-4.1"));
			f.Components = c;
			return f;
		}
		private Field CM05()
		{
			Field f = new Field("Chairman of Study");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CM0-5.1"));
			c.Add(new Component("Family Name", "CM0-5.2"));
			c.Add(new Component("Given Name", "CM0-5.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "CM0-5.4"));
			c.Add(new Component("Suffix", "CM0-5.5"));
			c.Add(new Component("Prefix", "CM0-5.6"));
			c.Add(new Component("Degree", "CM0-5.7"));
			c.Add(new Component("Source Table", "CM0-5.8"));
			c.Add(new Component("Assigning Authority", "CM0-5.9"));
			c.Add(new Component("Name Type Code", "CM0-5.10"));
			c.Add(new Component("Identifier Check Digit", "CM0-5.11"));
			c.Add(new Component("Check Digit Scheme", "CM0-5.12"));
			c.Add(new Component("Identifier Type Code", "CM0-5.13"));
			c.Add(new Component("Assigning Facility", "CM0-5.14"));
			c.Add(new Component("Name Respresentation Code", "CM0-5.15"));
			c.Add(new Component("Name Context", "CM0-5.16"));
			c.Add(new Component("Name Validity Range", "CM0-5.17"));
			c.Add(new Component("Name Assembly Order", "CM0-5.18"));
			c.Add(new Component("Effective Date", "CM0-5.19"));
			c.Add(new Component("Expiration Date", "CM0-5.20"));
			c.Add(new Component("Professional Suffix", "CM0-5.21"));
			c.Add(new Component("Assigning Jurisdiction", "CM0-5.22"));
			c.Add(new Component("Assigning Agency or Department", "CM0-5.23"));
			f.Components = c;
			return f;
		}
		private Field CM06()
		{
			Field f = new Field("Last IRB Approval Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CM0-6.1"));
			f.Components = c;
			return f;
		}
		private Field CM07()
		{
			Field f = new Field("Total Accrual to Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CM0-7.1"));
			f.Components = c;
			return f;
		}
		private Field CM08()
		{
			Field f = new Field("Last Accrual Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CM0-8.1"));
			f.Components = c;
			return f;
		}
		private Field CM09()
		{
			Field f = new Field("Contact for Study");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CM0-9.1"));
			c.Add(new Component("Family Name", "CM0-9.2"));
			c.Add(new Component("Given Name", "CM0-9.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "CM0-9.4"));
			c.Add(new Component("Suffix", "CM0-9.5"));
			c.Add(new Component("Prefix", "CM0-9.6"));
			c.Add(new Component("Degree", "CM0-9.7"));
			c.Add(new Component("Source Table", "CM0-9.8"));
			c.Add(new Component("Assigning Authority", "CM0-9.9"));
			c.Add(new Component("Name Type Code", "CM0-9.10"));
			c.Add(new Component("Identifier Check Digit", "CM0-9.11"));
			c.Add(new Component("Check Digit Scheme", "CM0-9.12"));
			c.Add(new Component("Identifier Type Code", "CM0-9.13"));
			c.Add(new Component("Assigning Facility", "CM0-9.14"));
			c.Add(new Component("Name Respresentation Code", "CM0-9.15"));
			c.Add(new Component("Name Context", "CM0-9.16"));
			c.Add(new Component("Name Validity Range", "CM0-9.17"));
			c.Add(new Component("Name Assembly Order", "CM0-9.18"));
			c.Add(new Component("Effective Date", "CM0-9.19"));
			c.Add(new Component("Expiration Date", "CM0-9.20"));
			c.Add(new Component("Professional Suffix", "CM0-9.21"));
			c.Add(new Component("Assigning Jurisdiction", "CM0-9.22"));
			c.Add(new Component("Assigning Agency or Department", "CM0-9.23"));
			f.Components = c;
			return f;
		}
		private Field CM010()
		{
			Field f = new Field("Contact's Telephone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "CM0-10.1"));
			c.Add(new Component("Tele-Communication Use Code", "CM0-10.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "CM0-10.3"));
			c.Add(new Component("Email Address", "CM0-10.4"));
			c.Add(new Component("Country Code", "CM0-10.5"));
			c.Add(new Component("Area City Code", "CM0-10.6"));
			c.Add(new Component("Local Number", "CM0-10.7"));
			c.Add(new Component("Extension", "CM0-10.8"));
			c.Add(new Component("", "CM0-10.9"));
			c.Add(new Component("Extension Prefix", "CM0-10.10"));
			c.Add(new Component("Speed Dial Code", "CM0-10.11"));
			c.Add(new Component("Unformatted Telephone Number", "CM0-10.12"));
			f.Components = c;
			return f;
		}
		private Field CM011()
		{
			Field f = new Field("Contact's Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "CM0-11.1"));
			c.Add(new Component("Other Designation", "CM0-11.2"));
			c.Add(new Component("City", "CM0-11.3"));
			c.Add(new Component("State or Province", "CM0-11.4"));
			c.Add(new Component("Zip or Postal Code", "CM0-11.5"));
			c.Add(new Component("Country", "CM0-11.6"));
			c.Add(new Component("Address Type", "CM0-11.7"));
			c.Add(new Component("Other Geographic Designation", "CM0-11.8"));
			c.Add(new Component("Country Parish Code", "CM0-11.9"));
			c.Add(new Component("Census Tract", "CM0-11.10"));
			c.Add(new Component("Address Representation Code", "CM0-11.11"));
			c.Add(new Component("Address Validity Range", "CM0-11.12"));
			c.Add(new Component("Effective Date", "CM0-11.13"));
			c.Add(new Component("Expiration Date", "CM0-11.14"));
			f.Components = c;
			return f;
		}
	}
}
