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
/// RXC Class: Constructs an HL7 RXC Segment Object
/// </summary>
public class RXC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RXC()
		{
			Name = "RXC";
			Description = "Pharmacy/Treatment Component Order";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RXC1());
			fs.Add(RXC2());
			fs.Add(RXC3());
			fs.Add(RXC4());
			fs.Add(RXC5());
			fs.Add(RXC6());
			fs.Add(RXC7());
			fs.Add(RXC8());
			fs.Add(RXC9());
			Fields = fs;
		}
		private Field RXC1()
		{
			Field f = new Field("RX Component Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXC-1.1"));
			f.Components = c;
			return f;
		}
		private Field RXC2()
		{
			Field f = new Field("Component Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXC-2.1"));
			c.Add(new Component("", "RXC-2.2"));
			c.Add(new Component("Name of Coding System", "RXC-2.3"));
			c.Add(new Component("Alternate Identifier", "RXC-2.4"));
			c.Add(new Component("Alternate Text", "RXC-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXC-2.6"));
			f.Components = c;
			return f;
		}
		private Field RXC3()
		{
			Field f = new Field("Component Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXC-3.1"));
			f.Components = c;
			return f;
		}
		private Field RXC4()
		{
			Field f = new Field("Component Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXC-4.1"));
			c.Add(new Component("", "RXC-4.2"));
			c.Add(new Component("Name of Coding System", "RXC-4.3"));
			c.Add(new Component("Alternate Identifier", "RXC-4.4"));
			c.Add(new Component("Alternate Text", "RXC-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXC-4.6"));
			f.Components = c;
			return f;
		}
		private Field RXC5()
		{
			Field f = new Field("Component Strength");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXC-5.1"));
			f.Components = c;
			return f;
		}
		private Field RXC6()
		{
			Field f = new Field("Component Strength Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXC-6.1"));
			c.Add(new Component("", "RXC-6.2"));
			c.Add(new Component("Name of Coding System", "RXC-6.3"));
			c.Add(new Component("Alternate Identifier", "RXC-6.4"));
			c.Add(new Component("Alternate Text", "RXC-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXC-6.6"));
			f.Components = c;
			return f;
		}
		private Field RXC7()
		{
			Field f = new Field("Supplementary Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXC-7.1"));
			c.Add(new Component("", "RXC-7.2"));
			c.Add(new Component("Name of Coding System", "RXC-7.3"));
			c.Add(new Component("Alternate Identifier", "RXC-7.4"));
			c.Add(new Component("Alternate Text", "RXC-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXC-7.6"));
			f.Components = c;
			return f;
		}
		private Field RXC8()
		{
			Field f = new Field("Component Drug Strength Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXC-8.1"));
			f.Components = c;
			return f;
		}
		private Field RXC9()
		{
			Field f = new Field("Component Drug Strength Volume Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXC-9.1"));
			c.Add(new Component("", "RXC-9.2"));
			c.Add(new Component("Name of Coding System", "RXC-9.3"));
			c.Add(new Component("Alternate Identifier", "RXC-9.4"));
			c.Add(new Component("Alternate Text", "RXC-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXC-9.6"));
			c.Add(new Component("Coding System Version ID", "RXC-9.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXC-9.8"));
			c.Add(new Component("Original Text", "RXC-9.9"));
			f.Components = c;
			return f;
		}
	}
}
