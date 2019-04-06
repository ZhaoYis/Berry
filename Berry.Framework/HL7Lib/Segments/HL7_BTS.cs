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
/// BTS Class: Constructs an HL7 BTS Segment Object
/// </summary>
public class BTS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public BTS()
		{
			Name = "BTS";
			Description = "Batch Trailer";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(BTS1());
			fs.Add(BTS2());
			fs.Add(BTS3());
			Fields = fs;
		}
		private Field BTS1()
		{
			Field f = new Field("Batch Message Count");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BTS-1.1"));
			f.Components = c;
			return f;
		}
		private Field BTS2()
		{
			Field f = new Field("Batch Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BTS-2.1"));
			f.Components = c;
			return f;
		}
		private Field BTS3()
		{
			Field f = new Field("Batch Totals");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BTS-3.1"));
			f.Components = c;
			return f;
		}
	}
}
