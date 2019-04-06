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
/// VTQ Class: Constructs an HL7 VTQ Segment Object
/// </summary>
public class VTQ
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public VTQ()
		{
			Name = "VTQ";
			Description = "Virtual Table Query Request";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(VTQ1());
			fs.Add(VTQ2());
			fs.Add(VTQ3());
			fs.Add(VTQ4());
			fs.Add(VTQ5());
			Fields = fs;
		}
		private Field VTQ1()
		{
			Field f = new Field("Query Tag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "VTQ-1.1"));
			f.Components = c;
			return f;
		}
		private Field VTQ2()
		{
			Field f = new Field("Query/Response Format Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "VTQ-2.1"));
			f.Components = c;
			return f;
		}
		private Field VTQ3()
		{
			Field f = new Field("VT Query Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "VTQ-3.1"));
			c.Add(new Component("", "VTQ-3.2"));
			c.Add(new Component("Name of Coding System", "VTQ-3.3"));
			c.Add(new Component("Alternate Identifier", "VTQ-3.4"));
			c.Add(new Component("Alternate Text", "VTQ-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "VTQ-3.6"));
			f.Components = c;
			return f;
		}
		private Field VTQ4()
		{
			Field f = new Field("Virtual Table Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "VTQ-4.1"));
			c.Add(new Component("", "VTQ-4.2"));
			c.Add(new Component("Name of Coding System", "VTQ-4.3"));
			c.Add(new Component("Alternate Identifier", "VTQ-4.4"));
			c.Add(new Component("Alternate Text", "VTQ-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "VTQ-4.6"));
			f.Components = c;
			return f;
		}
		private Field VTQ5()
		{
			Field f = new Field("Selection Criteria");
			List<Component> c = new List<Component>();
			c.Add(new Component("Segment Field Name", "VTQ-5.1"));
			c.Add(new Component("Relational Operator", "VTQ-5.2"));
			c.Add(new Component("Value", "VTQ-5.3"));
			c.Add(new Component("Relational Conjunction", "VTQ-5.4"));
			f.Components = c;
			return f;
		}
	}
}
