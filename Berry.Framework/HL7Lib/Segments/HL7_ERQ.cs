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
/// ERQ Class: Constructs an HL7 ERQ Segment Object
/// </summary>
public class ERQ
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ERQ()
		{
			Name = "ERQ";
			Description = "Event replay query";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ERQ1());
			fs.Add(ERQ2());
			fs.Add(ERQ3());
			Fields = fs;
		}
		private Field ERQ1()
		{
			Field f = new Field("Query Tag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ERQ-1.1"));
			f.Components = c;
			return f;
		}
		private Field ERQ2()
		{
			Field f = new Field("Event Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ERQ-2.1"));
			c.Add(new Component("", "ERQ-2.2"));
			c.Add(new Component("Name of Coding System", "ERQ-2.3"));
			c.Add(new Component("Alternate Identifier", "ERQ-2.4"));
			c.Add(new Component("Alternate Text", "ERQ-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "ERQ-2.6"));
			f.Components = c;
			return f;
		}
		private Field ERQ3()
		{
			Field f = new Field("Input Parameter List");
			List<Component> c = new List<Component>();
			c.Add(new Component("Segment Field Name", "ERQ-3.1"));
			c.Add(new Component("Value", "ERQ-3.2"));
			f.Components = c;
			return f;
		}
	}
}
