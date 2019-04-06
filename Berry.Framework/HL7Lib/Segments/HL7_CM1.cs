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
/// CM1 Class: Constructs an HL7 CM1 Segment Object
/// </summary>
public class CM1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CM1()
		{
			Name = "CM1";
			Description = "Clinical Study Phase Master";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CM11());
			fs.Add(CM12());
			fs.Add(CM13());
			Fields = fs;
		}
		private Field CM11()
		{
			Field f = new Field("Set ID - CM1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "CM1-1.1"));
			f.Components = c;
			return f;
		}
		private Field CM12()
		{
			Field f = new Field("Study Phase Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CM1-2.1"));
			c.Add(new Component("", "CM1-2.2"));
			c.Add(new Component("Name of Coding System", "CM1-2.3"));
			c.Add(new Component("Alternate Identifier", "CM1-2.4"));
			c.Add(new Component("Alternate Text", "CM1-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "CM1-2.6"));
			f.Components = c;
			return f;
		}
		private Field CM13()
		{
			Field f = new Field("Description of Study Phase");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CM1-3.1"));
			f.Components = c;
			return f;
		}
	}
}
