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
/// PTH Class: Constructs an HL7 PTH Segment Object
/// </summary>
public class PTH
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PTH()
		{
			Name = "PTH";
			Description = "Pathway";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PTH1());
			fs.Add(PTH2());
			fs.Add(PTH3());
			fs.Add(PTH4());
			fs.Add(PTH5());
			fs.Add(PTH6());
			Fields = fs;
		}
		private Field PTH1()
		{
			Field f = new Field("Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PTH-1.1"));
			f.Components = c;
			return f;
		}
		private Field PTH2()
		{
			Field f = new Field("Pathway ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PTH-2.1"));
			c.Add(new Component("", "PTH-2.2"));
			c.Add(new Component("Name of Coding System", "PTH-2.3"));
			c.Add(new Component("Alternate Identifier", "PTH-2.4"));
			c.Add(new Component("Alternate Text", "PTH-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "PTH-2.6"));
			f.Components = c;
			return f;
		}
		private Field PTH3()
		{
			Field f = new Field("Pathway Instance ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "PTH-3.1"));
			c.Add(new Component("Namespace ID", "PTH-3.2"));
			c.Add(new Component("Universal ID", "PTH-3.3"));
			c.Add(new Component("Universal ID Type", "PTH-3.4"));
			f.Components = c;
			return f;
		}
		private Field PTH4()
		{
			Field f = new Field("Pathway Established Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PTH-4.1"));
			c.Add(new Component("Degree of Precision", "PTH-4.2"));
			f.Components = c;
			return f;
		}
		private Field PTH5()
		{
			Field f = new Field("Pathway Life Cycle Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PTH-5.1"));
			c.Add(new Component("", "PTH-5.2"));
			c.Add(new Component("Name of Coding System", "PTH-5.3"));
			c.Add(new Component("Alternate Identifier", "PTH-5.4"));
			c.Add(new Component("Alternate Text", "PTH-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "PTH-5.6"));
			f.Components = c;
			return f;
		}
		private Field PTH6()
		{
			Field f = new Field("Change Pathway Life Cycle Status Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PTH-6.1"));
			c.Add(new Component("Degree of Precision", "PTH-6.2"));
			f.Components = c;
			return f;
		}
	}
}
