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
/// DB1 Class: Constructs an HL7 DB1 Segment Object
/// </summary>
public class DB1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public DB1()
		{
			Name = "DB1";
			Description = "Disability";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(DB11());
			fs.Add(DB12());
			fs.Add(DB13());
			fs.Add(DB14());
			fs.Add(DB15());
			fs.Add(DB16());
			fs.Add(DB17());
			fs.Add(DB18());
			Fields = fs;
		}
		private Field DB11()
		{
			Field f = new Field("Set ID - DB1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "DB1-1.1"));
			f.Components = c;
			return f;
		}
		private Field DB12()
		{
			Field f = new Field("Disabled Person Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DB1-2.1"));
			f.Components = c;
			return f;
		}
		private Field DB13()
		{
			Field f = new Field("Disabled Person Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "DB1-3.1"));
			c.Add(new Component("Check Digit", "DB1-3.2"));
			c.Add(new Component("Check Digit Scheme", "DB1-3.3"));
			c.Add(new Component("Assigning Authority", "DB1-3.4"));
			c.Add(new Component("Identifier Type Code", "DB1-3.5"));
			c.Add(new Component("Assigning Facility", "DB1-3.6"));
			c.Add(new Component("Effective Date", "DB1-3.7"));
			c.Add(new Component("Expiration Date", "DB1-3.8"));
			c.Add(new Component("Assigning Jurisdiction", "DB1-3.9"));
			c.Add(new Component("Assigning Agency or Department", "DB1-3.10"));
			f.Components = c;
			return f;
		}
		private Field DB14()
		{
			Field f = new Field("Disabled Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DB1-4.1"));
			f.Components = c;
			return f;
		}
		private Field DB15()
		{
			Field f = new Field("Disability Start Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DB1-5.1"));
			f.Components = c;
			return f;
		}
		private Field DB16()
		{
			Field f = new Field("Disability End Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DB1-6.1"));
			f.Components = c;
			return f;
		}
		private Field DB17()
		{
			Field f = new Field("Disability Return to Work Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DB1-7.1"));
			f.Components = c;
			return f;
		}
		private Field DB18()
		{
			Field f = new Field("Disability Unable to Work Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DB1-8.1"));
			f.Components = c;
			return f;
		}
	}
}
