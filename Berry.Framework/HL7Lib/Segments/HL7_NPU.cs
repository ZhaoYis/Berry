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
/// NPU Class: Constructs an HL7 NPU Segment Object
/// </summary>
public class NPU
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public NPU()
		{
			Name = "NPU";
			Description = "Bed Status Update";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(NPU1());
			fs.Add(NPU2());
			Fields = fs;
		}
		private Field NPU1()
		{
			Field f = new Field("Bed Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "NPU-1.1"));
			c.Add(new Component("Room", "NPU-1.2"));
			c.Add(new Component("Bed", "NPU-1.3"));
			c.Add(new Component("Facility", "NPU-1.4"));
			c.Add(new Component("Location Status", "NPU-1.5"));
			c.Add(new Component("Person Location Type", "NPU-1.6"));
			c.Add(new Component("Building", "NPU-1.7"));
			c.Add(new Component("Floor Number", "NPU-1.8"));
			c.Add(new Component("Location Description", "NPU-1.9"));
			c.Add(new Component("Comprehensive Location Identifier", "NPU-1.10"));
			c.Add(new Component("Assigning Authority for Location", "NPU-1.11"));
			f.Components = c;
			return f;
		}
		private Field NPU2()
		{
			Field f = new Field("Bed Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NPU-2.1"));
			f.Components = c;
			return f;
		}
	}
}
