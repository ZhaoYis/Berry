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
/// OM5 Class: Constructs an HL7 OM5 Segment Object
/// </summary>
public class OM5
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OM5()
		{
			Name = "OM5";
			Description = "Observation Batteries (Sets)";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OM51());
			fs.Add(OM52());
			fs.Add(OM53());
			Fields = fs;
		}
		private Field OM51()
		{
			Field f = new Field("Sequence Number - Test/Observation Master File");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM5-1.1"));
			f.Components = c;
			return f;
		}
		private Field OM52()
		{
			Field f = new Field("Test/Observations Included within an Ordered Test Battery");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM5-2.1"));
			c.Add(new Component("", "OM5-2.2"));
			c.Add(new Component("Name of Coding System", "OM5-2.3"));
			c.Add(new Component("Alternate Identifier", "OM5-2.4"));
			c.Add(new Component("Alternate Text", "OM5-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM5-2.6"));
			f.Components = c;
			return f;
		}
		private Field OM53()
		{
			Field f = new Field("Observation ID Suffixes");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM5-3.1"));
			f.Components = c;
			return f;
		}
	}
}
