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
/// EQL Class: Constructs an HL7 EQL Segment Object
/// </summary>
public class EQL
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public EQL()
		{
			Name = "EQL";
			Description = "Embedded Query Language";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(EQL1());
			fs.Add(EQL2());
			fs.Add(EQL3());
			fs.Add(EQL4());
			Fields = fs;
		}
		private Field EQL1()
		{
			Field f = new Field("Query Tag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EQL-1.1"));
			f.Components = c;
			return f;
		}
		private Field EQL2()
		{
			Field f = new Field("Query/Response Format Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EQL-2.1"));
			f.Components = c;
			return f;
		}
		private Field EQL3()
		{
			Field f = new Field("EQL Query Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "EQL-3.1"));
			c.Add(new Component("", "EQL-3.2"));
			c.Add(new Component("Name of Coding System", "EQL-3.3"));
			c.Add(new Component("Alternate Identifier", "EQL-3.4"));
			c.Add(new Component("Alternate Text", "EQL-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "EQL-3.6"));
			f.Components = c;
			return f;
		}
		private Field EQL4()
		{
			Field f = new Field("EQL Query Statement");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EQL-4.1"));
			f.Components = c;
			return f;
		}
	}
}
