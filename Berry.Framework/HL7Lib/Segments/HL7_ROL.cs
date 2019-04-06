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
/// ROL Class: Constructs an HL7 ROL Segment Object
/// </summary>
public class ROL
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ROL()
		{
			Name = "ROL";
			Description = "Role";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ROL1());
			fs.Add(ROL2());
			fs.Add(ROL3());
			fs.Add(ROL4());
			fs.Add(ROL5());
			fs.Add(ROL6());
			fs.Add(ROL7());
			fs.Add(ROL8());
			fs.Add(ROL9());
			fs.Add(ROL10());
			fs.Add(ROL11());
			fs.Add(ROL12());
			Fields = fs;
		}
		private Field ROL1()
		{
			Field f = new Field("Role Instance ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "ROL-1.1"));
			c.Add(new Component("Namespace ID", "ROL-1.2"));
			c.Add(new Component("Universal ID", "ROL-1.3"));
			c.Add(new Component("Universal ID Type", "ROL-1.4"));
			f.Components = c;
			return f;
		}
		private Field ROL2()
		{
			Field f = new Field("Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ROL-2.1"));
			f.Components = c;
			return f;
		}
		private Field ROL3()
		{
			Field f = new Field("Role-ROL");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ROL-3.1"));
			c.Add(new Component("", "ROL-3.2"));
			c.Add(new Component("Name of Coding System", "ROL-3.3"));
			c.Add(new Component("Alternate Identifier", "ROL-3.4"));
			c.Add(new Component("Alternate Text", "ROL-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "ROL-3.6"));
			f.Components = c;
			return f;
		}
		private Field ROL4()
		{
			Field f = new Field("Role Person");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ROL-4.1"));
			c.Add(new Component("Family Name", "ROL-4.2"));
			c.Add(new Component("Given Name", "ROL-4.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ROL-4.4"));
			c.Add(new Component("Suffix", "ROL-4.5"));
			c.Add(new Component("Prefix", "ROL-4.6"));
			c.Add(new Component("Degree", "ROL-4.7"));
			c.Add(new Component("Source Table", "ROL-4.8"));
			c.Add(new Component("Assigning Authority", "ROL-4.9"));
			c.Add(new Component("Name Type Code", "ROL-4.10"));
			c.Add(new Component("Identifier Check Digit", "ROL-4.11"));
			c.Add(new Component("Check Digit Scheme", "ROL-4.12"));
			c.Add(new Component("Identifier Type Code", "ROL-4.13"));
			c.Add(new Component("Assigning Facility", "ROL-4.14"));
			c.Add(new Component("Name Respresentation Code", "ROL-4.15"));
			c.Add(new Component("Name Context", "ROL-4.16"));
			c.Add(new Component("Name Validity Range", "ROL-4.17"));
			c.Add(new Component("Name Assembly Order", "ROL-4.18"));
			c.Add(new Component("Effective Date", "ROL-4.19"));
			c.Add(new Component("Expiration Date", "ROL-4.20"));
			c.Add(new Component("Professional Suffix", "ROL-4.21"));
			c.Add(new Component("Assigning Jurisdiction", "ROL-4.22"));
			c.Add(new Component("Assigning Agency or Department", "ROL-4.23"));
			f.Components = c;
			return f;
		}
		private Field ROL5()
		{
			Field f = new Field("Role Begin Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ROL-5.1"));
			c.Add(new Component("Degree of Precision", "ROL-5.2"));
			f.Components = c;
			return f;
		}
		private Field ROL6()
		{
			Field f = new Field("Role End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ROL-6.1"));
			c.Add(new Component("Degree of Precision", "ROL-6.2"));
			f.Components = c;
			return f;
		}
		private Field ROL7()
		{
			Field f = new Field("Role Duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ROL-7.1"));
			c.Add(new Component("", "ROL-7.2"));
			c.Add(new Component("Name of Coding System", "ROL-7.3"));
			c.Add(new Component("Alternate Identifier", "ROL-7.4"));
			c.Add(new Component("Alternate Text", "ROL-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "ROL-7.6"));
			f.Components = c;
			return f;
		}
		private Field ROL8()
		{
			Field f = new Field("Role Action Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ROL-8.1"));
			c.Add(new Component("", "ROL-8.2"));
			c.Add(new Component("Name of Coding System", "ROL-8.3"));
			c.Add(new Component("Alternate Identifier", "ROL-8.4"));
			c.Add(new Component("Alternate Text", "ROL-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "ROL-8.6"));
			f.Components = c;
			return f;
		}
		private Field ROL9()
		{
			Field f = new Field("Provider Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ROL-9.1"));
			c.Add(new Component("", "ROL-9.2"));
			c.Add(new Component("Name of Coding System", "ROL-9.3"));
			c.Add(new Component("Alternate Identifier", "ROL-9.4"));
			c.Add(new Component("Alternate Text", "ROL-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "ROL-9.6"));
			f.Components = c;
			return f;
		}
		private Field ROL10()
		{
			Field f = new Field("Organization Unit Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ROL-10.1"));
			c.Add(new Component("", "ROL-10.2"));
			c.Add(new Component("Name of Coding System", "ROL-10.3"));
			c.Add(new Component("Alternate Identifier", "ROL-10.4"));
			c.Add(new Component("Alternate Text", "ROL-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "ROL-10.6"));
			f.Components = c;
			return f;
		}
		private Field ROL11()
		{
			Field f = new Field("Office/Home Address/Birthplace");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "ROL-11.1"));
			c.Add(new Component("Other Designation", "ROL-11.2"));
			c.Add(new Component("City", "ROL-11.3"));
			c.Add(new Component("State or Province", "ROL-11.4"));
			c.Add(new Component("Zip or Postal Code", "ROL-11.5"));
			c.Add(new Component("Country", "ROL-11.6"));
			c.Add(new Component("Address Type", "ROL-11.7"));
			c.Add(new Component("Other Geographic Designation", "ROL-11.8"));
			c.Add(new Component("Country Parish Code", "ROL-11.9"));
			c.Add(new Component("Census Tract", "ROL-11.10"));
			c.Add(new Component("Address Representation Code", "ROL-11.11"));
			c.Add(new Component("Address Validity Range", "ROL-11.12"));
			c.Add(new Component("Effective Date", "ROL-11.13"));
			c.Add(new Component("Expiration Date", "ROL-11.14"));
			f.Components = c;
			return f;
		}
		private Field ROL12()
		{
			Field f = new Field("Phone");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "ROL-12.1"));
			c.Add(new Component("Tele-Communication Use Code", "ROL-12.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "ROL-12.3"));
			c.Add(new Component("Email Address", "ROL-12.4"));
			c.Add(new Component("Country Code", "ROL-12.5"));
			c.Add(new Component("Area City Code", "ROL-12.6"));
			c.Add(new Component("Local Number", "ROL-12.7"));
			c.Add(new Component("Extension", "ROL-12.8"));
			c.Add(new Component("", "ROL-12.9"));
			c.Add(new Component("Extension Prefix", "ROL-12.10"));
			c.Add(new Component("Speed Dial Code", "ROL-12.11"));
			c.Add(new Component("Unformatted Telephone Number", "ROL-12.12"));
			f.Components = c;
			return f;
		}
	}
}
