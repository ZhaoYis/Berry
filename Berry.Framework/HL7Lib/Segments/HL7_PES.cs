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
/// PES Class: Constructs an HL7 PES Segment Object
/// </summary>
public class PES
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PES()
		{
			Name = "PES";
			Description = "Product Experience Sender";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PES1());
			fs.Add(PES2());
			fs.Add(PES3());
			fs.Add(PES4());
			fs.Add(PES5());
			fs.Add(PES6());
			fs.Add(PES7());
			fs.Add(PES8());
			fs.Add(PES9());
			fs.Add(PES10());
			fs.Add(PES11());
			fs.Add(PES12());
			fs.Add(PES13());
			Fields = fs;
		}
		private Field PES1()
		{
			Field f = new Field("Sender Organization Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "PES-1.1"));
			c.Add(new Component("Organization Name Type Code", "PES-1.2"));
			c.Add(new Component("ID Number", "PES-1.3"));
			c.Add(new Component("Check Digit", "PES-1.4"));
			c.Add(new Component("Check Digit Scheme", "PES-1.5"));
			c.Add(new Component("Assigning Authority", "PES-1.6"));
			c.Add(new Component("Identifier Type Code", "PES-1.7"));
			c.Add(new Component("Assigning Facility", "PES-1.8"));
			c.Add(new Component("Name Respresentation Code", "PES-1.9"));
			c.Add(new Component("Organization Identifier", "PES-1.10"));
			f.Components = c;
			return f;
		}
		private Field PES2()
		{
			Field f = new Field("Sender Individual Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PES-2.1"));
			c.Add(new Component("Family Name", "PES-2.2"));
			c.Add(new Component("Given Name", "PES-2.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PES-2.4"));
			c.Add(new Component("Suffix", "PES-2.5"));
			c.Add(new Component("Prefix", "PES-2.6"));
			c.Add(new Component("Degree", "PES-2.7"));
			c.Add(new Component("Source Table", "PES-2.8"));
			c.Add(new Component("Assigning Authority", "PES-2.9"));
			c.Add(new Component("Name Type Code", "PES-2.10"));
			c.Add(new Component("Identifier Check Digit", "PES-2.11"));
			c.Add(new Component("Check Digit Scheme", "PES-2.12"));
			c.Add(new Component("Identifier Type Code", "PES-2.13"));
			c.Add(new Component("Assigning Facility", "PES-2.14"));
			c.Add(new Component("Name Respresentation Code", "PES-2.15"));
			c.Add(new Component("Name Context", "PES-2.16"));
			c.Add(new Component("Name Validity Range", "PES-2.17"));
			c.Add(new Component("Name Assembly Order", "PES-2.18"));
			c.Add(new Component("Effective Date", "PES-2.19"));
			c.Add(new Component("Expiration Date", "PES-2.20"));
			c.Add(new Component("Professional Suffix", "PES-2.21"));
			c.Add(new Component("Assigning Jurisdiction", "PES-2.22"));
			c.Add(new Component("Assigning Agency or Department", "PES-2.23"));
			f.Components = c;
			return f;
		}
		private Field PES3()
		{
			Field f = new Field("Sender Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "PES-3.1"));
			c.Add(new Component("Other Designation", "PES-3.2"));
			c.Add(new Component("City", "PES-3.3"));
			c.Add(new Component("State or Province", "PES-3.4"));
			c.Add(new Component("Zip or Postal Code", "PES-3.5"));
			c.Add(new Component("Country", "PES-3.6"));
			c.Add(new Component("Address Type", "PES-3.7"));
			c.Add(new Component("Other Geographic Designation", "PES-3.8"));
			c.Add(new Component("Country Parish Code", "PES-3.9"));
			c.Add(new Component("Census Tract", "PES-3.10"));
			c.Add(new Component("Address Representation Code", "PES-3.11"));
			c.Add(new Component("Address Validity Range", "PES-3.12"));
			c.Add(new Component("Effective Date", "PES-3.13"));
			c.Add(new Component("Expiration Date", "PES-3.14"));
			f.Components = c;
			return f;
		}
		private Field PES4()
		{
			Field f = new Field("Sender Telephone");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "PES-4.1"));
			c.Add(new Component("Tele-Communication Use Code", "PES-4.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "PES-4.3"));
			c.Add(new Component("Email Address", "PES-4.4"));
			c.Add(new Component("Country Code", "PES-4.5"));
			c.Add(new Component("Area City Code", "PES-4.6"));
			c.Add(new Component("Local Number", "PES-4.7"));
			c.Add(new Component("Extension", "PES-4.8"));
			c.Add(new Component("", "PES-4.9"));
			c.Add(new Component("Extension Prefix", "PES-4.10"));
			c.Add(new Component("Speed Dial Code", "PES-4.11"));
			c.Add(new Component("Unformatted Telephone Number", "PES-4.12"));
			f.Components = c;
			return f;
		}
		private Field PES5()
		{
			Field f = new Field("Sender Event Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "PES-5.1"));
			c.Add(new Component("Namespace ID", "PES-5.2"));
			c.Add(new Component("Universal ID", "PES-5.3"));
			c.Add(new Component("Universal ID Type", "PES-5.4"));
			f.Components = c;
			return f;
		}
		private Field PES6()
		{
			Field f = new Field("Sender Sequence Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PES-6.1"));
			f.Components = c;
			return f;
		}
		private Field PES7()
		{
			Field f = new Field("Sender Event Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PES-7.1"));
			f.Components = c;
			return f;
		}
		private Field PES8()
		{
			Field f = new Field("Sender Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PES-8.1"));
			f.Components = c;
			return f;
		}
		private Field PES9()
		{
			Field f = new Field("Sender Aware Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PES-9.1"));
			c.Add(new Component("Degree of Precision", "PES-9.2"));
			f.Components = c;
			return f;
		}
		private Field PES10()
		{
			Field f = new Field("Event Report Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PES-10.1"));
			c.Add(new Component("Degree of Precision", "PES-10.2"));
			f.Components = c;
			return f;
		}
		private Field PES11()
		{
			Field f = new Field("Event Report Timing/Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PES-11.1"));
			f.Components = c;
			return f;
		}
		private Field PES12()
		{
			Field f = new Field("Event Report Source");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PES-12.1"));
			f.Components = c;
			return f;
		}
		private Field PES13()
		{
			Field f = new Field("Event Reported To");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PES-13.1"));
			f.Components = c;
			return f;
		}
	}
}
