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
/// OM6 Class: Constructs an HL7 OM6 Segment Object
/// </summary>
public class OM6
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OM6()
		{
			Name = "OM6";
			Description = "Observations that are Calculated from Other Observations";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OM61());
			fs.Add(OM62());
			Fields = fs;
		}
		private Field OM61()
		{
			Field f = new Field("Sequence Number - Test/Observation Master File");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM6-1.1"));
			f.Components = c;
			return f;
		}
		private Field OM62()
		{
			Field f = new Field("Derivation Rule");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM6-2.1"));
			f.Components = c;
			return f;
		}
	}
}
