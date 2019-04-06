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
/// FAC Class: Constructs an HL7 FAC Segment Object
/// </summary>
public class FAC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public FAC()
		{
			Name = "FAC";
			Description = "Facility";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(FAC1());
			fs.Add(FAC2());
			fs.Add(FAC3());
			fs.Add(FAC4());
			fs.Add(FAC5());
			fs.Add(FAC6());
			fs.Add(FAC7());
			fs.Add(FAC8());
			fs.Add(FAC9());
			fs.Add(FAC10());
			fs.Add(FAC11());
			fs.Add(FAC12());
			Fields = fs;
		}
		private Field FAC1()
		{
			Field f = new Field("Facility ID-FAC");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "FAC-1.1"));
			c.Add(new Component("Namespace ID", "FAC-1.2"));
			c.Add(new Component("Universal ID", "FAC-1.3"));
			c.Add(new Component("Universal ID Type", "FAC-1.4"));
			f.Components = c;
			return f;
		}
		private Field FAC2()
		{
			Field f = new Field("Facility Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FAC-2.1"));
			f.Components = c;
			return f;
		}
		private Field FAC3()
		{
			Field f = new Field("Facility Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "FAC-3.1"));
			c.Add(new Component("Other Designation", "FAC-3.2"));
			c.Add(new Component("City", "FAC-3.3"));
			c.Add(new Component("State or Province", "FAC-3.4"));
			c.Add(new Component("Zip or Postal Code", "FAC-3.5"));
			c.Add(new Component("Country", "FAC-3.6"));
			c.Add(new Component("Address Type", "FAC-3.7"));
			c.Add(new Component("Other Geographic Designation", "FAC-3.8"));
			c.Add(new Component("Country Parish Code", "FAC-3.9"));
			c.Add(new Component("Census Tract", "FAC-3.10"));
			c.Add(new Component("Address Representation Code", "FAC-3.11"));
			c.Add(new Component("Address Validity Range", "FAC-3.12"));
			c.Add(new Component("Effective Date", "FAC-3.13"));
			c.Add(new Component("Expiration Date", "FAC-3.14"));
			f.Components = c;
			return f;
		}
		private Field FAC4()
		{
			Field f = new Field("Facility Telecommunication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "FAC-4.1"));
			c.Add(new Component("Tele-Communication Use Code", "FAC-4.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "FAC-4.3"));
			c.Add(new Component("Email Address", "FAC-4.4"));
			c.Add(new Component("Country Code", "FAC-4.5"));
			c.Add(new Component("Area City Code", "FAC-4.6"));
			c.Add(new Component("Local Number", "FAC-4.7"));
			c.Add(new Component("Extension", "FAC-4.8"));
			c.Add(new Component("", "FAC-4.9"));
			c.Add(new Component("Extension Prefix", "FAC-4.10"));
			c.Add(new Component("Speed Dial Code", "FAC-4.11"));
			c.Add(new Component("Unformatted Telephone Number", "FAC-4.12"));
			f.Components = c;
			return f;
		}
		private Field FAC5()
		{
			Field f = new Field("Contact Person");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "FAC-5.1"));
			c.Add(new Component("Family Name", "FAC-5.2"));
			c.Add(new Component("Given Name", "FAC-5.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "FAC-5.4"));
			c.Add(new Component("Suffix", "FAC-5.5"));
			c.Add(new Component("Prefix", "FAC-5.6"));
			c.Add(new Component("Degree", "FAC-5.7"));
			c.Add(new Component("Source Table", "FAC-5.8"));
			c.Add(new Component("Assigning Authority", "FAC-5.9"));
			c.Add(new Component("Name Type Code", "FAC-5.10"));
			c.Add(new Component("Identifier Check Digit", "FAC-5.11"));
			c.Add(new Component("Check Digit Scheme", "FAC-5.12"));
			c.Add(new Component("Identifier Type Code", "FAC-5.13"));
			c.Add(new Component("Assigning Facility", "FAC-5.14"));
			c.Add(new Component("Name Respresentation Code", "FAC-5.15"));
			c.Add(new Component("Name Context", "FAC-5.16"));
			c.Add(new Component("Name Validity Range", "FAC-5.17"));
			c.Add(new Component("Name Assembly Order", "FAC-5.18"));
			c.Add(new Component("Effective Date", "FAC-5.19"));
			c.Add(new Component("Expiration Date", "FAC-5.20"));
			c.Add(new Component("Professional Suffix", "FAC-5.21"));
			c.Add(new Component("Assigning Jurisdiction", "FAC-5.22"));
			c.Add(new Component("Assigning Agency or Department", "FAC-5.23"));
			f.Components = c;
			return f;
		}
		private Field FAC6()
		{
			Field f = new Field("Contact Title");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FAC-6.1"));
			f.Components = c;
			return f;
		}
		private Field FAC7()
		{
			Field f = new Field("Contact Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "FAC-7.1"));
			c.Add(new Component("Other Designation", "FAC-7.2"));
			c.Add(new Component("City", "FAC-7.3"));
			c.Add(new Component("State or Province", "FAC-7.4"));
			c.Add(new Component("Zip or Postal Code", "FAC-7.5"));
			c.Add(new Component("Country", "FAC-7.6"));
			c.Add(new Component("Address Type", "FAC-7.7"));
			c.Add(new Component("Other Geographic Designation", "FAC-7.8"));
			c.Add(new Component("Country Parish Code", "FAC-7.9"));
			c.Add(new Component("Census Tract", "FAC-7.10"));
			c.Add(new Component("Address Representation Code", "FAC-7.11"));
			c.Add(new Component("Address Validity Range", "FAC-7.12"));
			c.Add(new Component("Effective Date", "FAC-7.13"));
			c.Add(new Component("Expiration Date", "FAC-7.14"));
			f.Components = c;
			return f;
		}
		private Field FAC8()
		{
			Field f = new Field("Contact Telecommunication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "FAC-8.1"));
			c.Add(new Component("Tele-Communication Use Code", "FAC-8.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "FAC-8.3"));
			c.Add(new Component("Email Address", "FAC-8.4"));
			c.Add(new Component("Country Code", "FAC-8.5"));
			c.Add(new Component("Area City Code", "FAC-8.6"));
			c.Add(new Component("Local Number", "FAC-8.7"));
			c.Add(new Component("Extension", "FAC-8.8"));
			c.Add(new Component("", "FAC-8.9"));
			c.Add(new Component("Extension Prefix", "FAC-8.10"));
			c.Add(new Component("Speed Dial Code", "FAC-8.11"));
			c.Add(new Component("Unformatted Telephone Number", "FAC-8.12"));
			f.Components = c;
			return f;
		}
		private Field FAC9()
		{
			Field f = new Field("Signature Authority");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "FAC-9.1"));
			c.Add(new Component("Family Name", "FAC-9.2"));
			c.Add(new Component("Given Name", "FAC-9.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "FAC-9.4"));
			c.Add(new Component("Suffix", "FAC-9.5"));
			c.Add(new Component("Prefix", "FAC-9.6"));
			c.Add(new Component("Degree", "FAC-9.7"));
			c.Add(new Component("Source Table", "FAC-9.8"));
			c.Add(new Component("Assigning Authority", "FAC-9.9"));
			c.Add(new Component("Name Type Code", "FAC-9.10"));
			c.Add(new Component("Identifier Check Digit", "FAC-9.11"));
			c.Add(new Component("Check Digit Scheme", "FAC-9.12"));
			c.Add(new Component("Identifier Type Code", "FAC-9.13"));
			c.Add(new Component("Assigning Facility", "FAC-9.14"));
			c.Add(new Component("Name Respresentation Code", "FAC-9.15"));
			c.Add(new Component("Name Context", "FAC-9.16"));
			c.Add(new Component("Name Validity Range", "FAC-9.17"));
			c.Add(new Component("Name Assembly Order", "FAC-9.18"));
			c.Add(new Component("Effective Date", "FAC-9.19"));
			c.Add(new Component("Expiration Date", "FAC-9.20"));
			c.Add(new Component("Professional Suffix", "FAC-9.21"));
			c.Add(new Component("Assigning Jurisdiction", "FAC-9.22"));
			c.Add(new Component("Assigning Agency or Department", "FAC-9.23"));
			f.Components = c;
			return f;
		}
		private Field FAC10()
		{
			Field f = new Field("Signature Authority Title");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FAC-10.1"));
			f.Components = c;
			return f;
		}
		private Field FAC11()
		{
			Field f = new Field("Signature Authority Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "FAC-11.1"));
			c.Add(new Component("Other Designation", "FAC-11.2"));
			c.Add(new Component("City", "FAC-11.3"));
			c.Add(new Component("State or Province", "FAC-11.4"));
			c.Add(new Component("Zip or Postal Code", "FAC-11.5"));
			c.Add(new Component("Country", "FAC-11.6"));
			c.Add(new Component("Address Type", "FAC-11.7"));
			c.Add(new Component("Other Geographic Designation", "FAC-11.8"));
			c.Add(new Component("Country Parish Code", "FAC-11.9"));
			c.Add(new Component("Census Tract", "FAC-11.10"));
			c.Add(new Component("Address Representation Code", "FAC-11.11"));
			c.Add(new Component("Address Validity Range", "FAC-11.12"));
			c.Add(new Component("Effective Date", "FAC-11.13"));
			c.Add(new Component("Expiration Date", "FAC-11.14"));
			f.Components = c;
			return f;
		}
		private Field FAC12()
		{
			Field f = new Field("Signature Authority Telecommunication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "FAC-12.1"));
			c.Add(new Component("Tele-Communication Use Code", "FAC-12.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "FAC-12.3"));
			c.Add(new Component("Email Address", "FAC-12.4"));
			c.Add(new Component("Country Code", "FAC-12.5"));
			c.Add(new Component("Area City Code", "FAC-12.6"));
			c.Add(new Component("Local Number", "FAC-12.7"));
			c.Add(new Component("Extension", "FAC-12.8"));
			c.Add(new Component("", "FAC-12.9"));
			c.Add(new Component("Extension Prefix", "FAC-12.10"));
			c.Add(new Component("Speed Dial Code", "FAC-12.11"));
			c.Add(new Component("Unformatted Telephone Number", "FAC-12.12"));
			f.Components = c;
			return f;
		}
	}
}
