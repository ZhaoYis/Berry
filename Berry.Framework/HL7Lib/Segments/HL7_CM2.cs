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
/// CM2 Class: Constructs an HL7 CM2 Segment Object
/// </summary>
public class CM2
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CM2()
		{
			Name = "CM2";
			Description = "Clinical Study Schedule Master";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CM21());
			fs.Add(CM22());
			fs.Add(CM23());
			fs.Add(CM24());
			Fields = fs;
		}
		private Field CM21()
		{
			Field f = new Field("Set ID- CM2");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "CM2-1.1"));
			f.Components = c;
			return f;
		}
		private Field CM22()
		{
			Field f = new Field("Scheduled Time Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CM2-2.1"));
			c.Add(new Component("", "CM2-2.2"));
			c.Add(new Component("Name of Coding System", "CM2-2.3"));
			c.Add(new Component("Alternate Identifier", "CM2-2.4"));
			c.Add(new Component("Alternate Text", "CM2-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "CM2-2.6"));
			f.Components = c;
			return f;
		}
		private Field CM23()
		{
			Field f = new Field("Description of Time Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CM2-3.1"));
			f.Components = c;
			return f;
		}
		private Field CM24()
		{
			Field f = new Field("Events Scheduled This Time Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CM2-4.1"));
			c.Add(new Component("", "CM2-4.2"));
			c.Add(new Component("Name of Coding System", "CM2-4.3"));
			c.Add(new Component("Alternate Identifier", "CM2-4.4"));
			c.Add(new Component("Alternate Text", "CM2-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "CM2-4.6"));
			f.Components = c;
			return f;
		}
	}
}
