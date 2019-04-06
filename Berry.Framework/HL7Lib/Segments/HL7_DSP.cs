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
/// DSP Class: Constructs an HL7 DSP Segment Object
/// </summary>
public class DSP
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public DSP()
		{
			Name = "DSP";
			Description = "Display Data";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(DSP1());
			fs.Add(DSP2());
			fs.Add(DSP3());
			fs.Add(DSP4());
			fs.Add(DSP5());
			Fields = fs;
		}
		private Field DSP1()
		{
			Field f = new Field("Set ID - DSP");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "DSP-1.1"));
			f.Components = c;
			return f;
		}
		private Field DSP2()
		{
			Field f = new Field("Display Level");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "DSP-2.1"));
			f.Components = c;
			return f;
		}
		private Field DSP3()
		{
			Field f = new Field("Data Line");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DSP-3.1"));
			f.Components = c;
			return f;
		}
		private Field DSP4()
		{
			Field f = new Field("Logical Break Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DSP-4.1"));
			f.Components = c;
			return f;
		}
		private Field DSP5()
		{
			Field f = new Field("Result ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DSP-5.1"));
			f.Components = c;
			return f;
		}
	}
}
