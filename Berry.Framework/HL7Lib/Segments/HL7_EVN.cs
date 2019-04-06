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
/// EVN Class: Constructs an HL7 EVN Segment Object
/// </summary>
public class EVN
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public EVN()
		{
			Name = "EVN";
			Description = "Event Type";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(EVN1());
			fs.Add(EVN2());
			fs.Add(EVN3());
			fs.Add(EVN4());
			fs.Add(EVN5());
			fs.Add(EVN6());
			fs.Add(EVN7());
			Fields = fs;
		}
		private Field EVN1()
		{
			Field f = new Field("Event Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EVN-1.1"));
			f.Components = c;
			return f;
		}
		private Field EVN2()
		{
			Field f = new Field("Recorded Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "EVN-2.1"));
			c.Add(new Component("Degree of Precision", "EVN-2.2"));
			f.Components = c;
			return f;
		}
		private Field EVN3()
		{
			Field f = new Field("Date/Time Planned Event");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "EVN-3.1"));
			c.Add(new Component("Degree of Precision", "EVN-3.2"));
			f.Components = c;
			return f;
		}
		private Field EVN4()
		{
			Field f = new Field("Event Reason Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EVN-4.1"));
			f.Components = c;
			return f;
		}
		private Field EVN5()
		{
			Field f = new Field("Operator ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "EVN-5.1"));
			c.Add(new Component("Family Name", "EVN-5.2"));
			c.Add(new Component("Given Name", "EVN-5.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "EVN-5.4"));
			c.Add(new Component("Suffix", "EVN-5.5"));
			c.Add(new Component("Prefix", "EVN-5.6"));
			c.Add(new Component("Degree", "EVN-5.7"));
			c.Add(new Component("Source Table", "EVN-5.8"));
			c.Add(new Component("Assigning Authority", "EVN-5.9"));
			c.Add(new Component("Name Type Code", "EVN-5.10"));
			c.Add(new Component("Identifier Check Digit", "EVN-5.11"));
			c.Add(new Component("Check Digit Scheme", "EVN-5.12"));
			c.Add(new Component("Identifier Type Code", "EVN-5.13"));
			c.Add(new Component("Assigning Facility", "EVN-5.14"));
			c.Add(new Component("Name Respresentation Code", "EVN-5.15"));
			c.Add(new Component("Name Context", "EVN-5.16"));
			c.Add(new Component("Name Validity Range", "EVN-5.17"));
			c.Add(new Component("Name Assembly Order", "EVN-5.18"));
			c.Add(new Component("Effective Date", "EVN-5.19"));
			c.Add(new Component("Expiration Date", "EVN-5.20"));
			c.Add(new Component("Professional Suffix", "EVN-5.21"));
			c.Add(new Component("Assigning Jurisdiction", "EVN-5.22"));
			c.Add(new Component("Assigning Agency or Department", "EVN-5.23"));
			f.Components = c;
			return f;
		}
		private Field EVN6()
		{
			Field f = new Field("Event Occurred");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "EVN-6.1"));
			c.Add(new Component("Degree of Precision", "EVN-6.2"));
			f.Components = c;
			return f;
		}
		private Field EVN7()
		{
			Field f = new Field("Event Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "EVN-7.1"));
			c.Add(new Component("Universal ID", "EVN-7.2"));
			c.Add(new Component("Universal ID Type", "EVN-7.3"));
			f.Components = c;
			return f;
		}
	}
}
