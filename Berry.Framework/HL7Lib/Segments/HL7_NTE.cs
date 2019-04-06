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
/// NTE Class: Constructs an HL7 NTE Segment Object
/// </summary>
public class NTE
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public NTE()
		{
			Name = "NTE";
			Description = "Notes and Comments";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(NTE1());
			fs.Add(NTE2());
			fs.Add(NTE3());
			fs.Add(NTE4());
			Fields = fs;
		}
		private Field NTE1()
		{
			Field f = new Field("Set ID - NTE");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "NTE-1.1"));
			f.Components = c;
			return f;
		}
		private Field NTE2()
		{
			Field f = new Field("Source of Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NTE-2.1"));
			f.Components = c;
			return f;
		}
		private Field NTE3()
		{
			Field f = new Field("Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NTE-3.1"));
			f.Components = c;
			return f;
		}
		private Field NTE4()
		{
			Field f = new Field("Comment Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NTE-4.1"));
			c.Add(new Component("", "NTE-4.2"));
			c.Add(new Component("Name of Coding System", "NTE-4.3"));
			c.Add(new Component("Alternate Identifier", "NTE-4.4"));
			c.Add(new Component("Alternate Text", "NTE-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "NTE-4.6"));
			f.Components = c;
			return f;
		}
	}
}
