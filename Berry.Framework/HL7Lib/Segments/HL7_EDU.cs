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
/// EDU Class: Constructs an HL7 EDU Segment Object
/// </summary>
public class EDU
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public EDU()
		{
			Name = "EDU";
			Description = "Educational Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(EDU1());
			fs.Add(EDU2());
			fs.Add(EDU3());
			fs.Add(EDU4());
			fs.Add(EDU5());
			fs.Add(EDU6());
			fs.Add(EDU7());
			fs.Add(EDU8());
			fs.Add(EDU9());
			Fields = fs;
		}
		private Field EDU1()
		{
			Field f = new Field("Set ID _ EDU");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "EDU-1.1"));
			f.Components = c;
			return f;
		}
		private Field EDU2()
		{
			Field f = new Field("Academic Degree");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EDU-2.1"));
			f.Components = c;
			return f;
		}
		private Field EDU3()
		{
			Field f = new Field("Academic Degree Program Date Range");
			List<Component> c = new List<Component>();
			c.Add(new Component("Range Start Date/Time", "EDU-3.1"));
			c.Add(new Component("Range End Date/Time", "EDU-3.2"));
			f.Components = c;
			return f;
		}
		private Field EDU4()
		{
			Field f = new Field("Academic Degree Program Participation Date Range");
			List<Component> c = new List<Component>();
			c.Add(new Component("Range Start Date/Time", "EDU-4.1"));
			c.Add(new Component("Range End Date/Time", "EDU-4.2"));
			f.Components = c;
			return f;
		}
		private Field EDU5()
		{
			Field f = new Field("Academic Degree Granted Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EDU-5.1"));
			f.Components = c;
			return f;
		}
		private Field EDU6()
		{
			Field f = new Field("School");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "EDU-6.1"));
			c.Add(new Component("Organization Name Type Code", "EDU-6.2"));
			c.Add(new Component("ID Number", "EDU-6.3"));
			c.Add(new Component("Check Digit", "EDU-6.4"));
			c.Add(new Component("Check Digit Scheme", "EDU-6.5"));
			c.Add(new Component("Assigning Authority", "EDU-6.6"));
			c.Add(new Component("Identifier Type Code", "EDU-6.7"));
			c.Add(new Component("Assigning Facility", "EDU-6.8"));
			c.Add(new Component("Name Respresentation Code", "EDU-6.9"));
			c.Add(new Component("Organization Identifier", "EDU-6.10"));
			f.Components = c;
			return f;
		}
		private Field EDU7()
		{
			Field f = new Field("School Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "EDU-7.1"));
			c.Add(new Component("", "EDU-7.2"));
			c.Add(new Component("Name of Coding System", "EDU-7.3"));
			c.Add(new Component("Alternate Identifier", "EDU-7.4"));
			c.Add(new Component("Alternate Text", "EDU-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "EDU-7.6"));
			f.Components = c;
			return f;
		}
		private Field EDU8()
		{
			Field f = new Field("School Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "EDU-8.1"));
			c.Add(new Component("Other Designation", "EDU-8.2"));
			c.Add(new Component("City", "EDU-8.3"));
			c.Add(new Component("State or Province", "EDU-8.4"));
			c.Add(new Component("Zip or Postal Code", "EDU-8.5"));
			c.Add(new Component("Country", "EDU-8.6"));
			c.Add(new Component("Address Type", "EDU-8.7"));
			c.Add(new Component("Other Geographic Designation", "EDU-8.8"));
			c.Add(new Component("Country Parish Code", "EDU-8.9"));
			c.Add(new Component("Census Tract", "EDU-8.10"));
			c.Add(new Component("Address Representation Code", "EDU-8.11"));
			c.Add(new Component("Address Validity Range", "EDU-8.12"));
			c.Add(new Component("Effective Date", "EDU-8.13"));
			c.Add(new Component("Expiration Date", "EDU-8.14"));
			f.Components = c;
			return f;
		}
		private Field EDU9()
		{
			Field f = new Field("Major Field of Study");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "EDU-9.1"));
			c.Add(new Component("", "EDU-9.2"));
			c.Add(new Component("Name of Coding System", "EDU-9.3"));
			c.Add(new Component("Alternate Identifier", "EDU-9.4"));
			c.Add(new Component("Alternate Text", "EDU-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "EDU-9.6"));
			c.Add(new Component("Coding System Version ID", "EDU-9.7"));
			c.Add(new Component("Alternate Coding System Version ID", "EDU-9.8"));
			c.Add(new Component("Original Text", "EDU-9.9"));
			f.Components = c;
			return f;
		}
	}
}
