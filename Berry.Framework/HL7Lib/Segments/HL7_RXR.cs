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
/// RXR Class: Constructs an HL7 RXR Segment Object
/// </summary>
public class RXR
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RXR()
		{
			Name = "RXR";
			Description = "Pharmacy/Treatment Route";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RXR1());
			fs.Add(RXR2());
			fs.Add(RXR3());
			fs.Add(RXR4());
			fs.Add(RXR5());
			fs.Add(RXR6());
			Fields = fs;
		}
		private Field RXR1()
		{
			Field f = new Field("Route");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXR-1.1"));
			c.Add(new Component("", "RXR-1.2"));
			c.Add(new Component("Name of Coding System", "RXR-1.3"));
			c.Add(new Component("Alternate Identifier", "RXR-1.4"));
			c.Add(new Component("Alternate Text", "RXR-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXR-1.6"));
			f.Components = c;
			return f;
		}
		private Field RXR2()
		{
			Field f = new Field("Administration Site");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXR-2.1"));
			c.Add(new Component("", "RXR-2.2"));
			c.Add(new Component("Name of Coding System", "RXR-2.3"));
			c.Add(new Component("Alternate Identifier", "RXR-2.4"));
			c.Add(new Component("Alternate Text", "RXR-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXR-2.6"));
			c.Add(new Component("Coding System Version ID", "RXR-2.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXR-2.8"));
			c.Add(new Component("Original Text", "RXR-2.9"));
			f.Components = c;
			return f;
		}
		private Field RXR3()
		{
			Field f = new Field("Administration Device");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXR-3.1"));
			c.Add(new Component("", "RXR-3.2"));
			c.Add(new Component("Name of Coding System", "RXR-3.3"));
			c.Add(new Component("Alternate Identifier", "RXR-3.4"));
			c.Add(new Component("Alternate Text", "RXR-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXR-3.6"));
			f.Components = c;
			return f;
		}
		private Field RXR4()
		{
			Field f = new Field("Administration Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXR-4.1"));
			c.Add(new Component("", "RXR-4.2"));
			c.Add(new Component("Name of Coding System", "RXR-4.3"));
			c.Add(new Component("Alternate Identifier", "RXR-4.4"));
			c.Add(new Component("Alternate Text", "RXR-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXR-4.6"));
			c.Add(new Component("Coding System Version ID", "RXR-4.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXR-4.8"));
			c.Add(new Component("Original Text", "RXR-4.9"));
			f.Components = c;
			return f;
		}
		private Field RXR5()
		{
			Field f = new Field("Routing Instruction");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXR-5.1"));
			c.Add(new Component("", "RXR-5.2"));
			c.Add(new Component("Name of Coding System", "RXR-5.3"));
			c.Add(new Component("Alternate Identifier", "RXR-5.4"));
			c.Add(new Component("Alternate Text", "RXR-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXR-5.6"));
			f.Components = c;
			return f;
		}
		private Field RXR6()
		{
			Field f = new Field("Administration Site Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXR-6.1"));
			c.Add(new Component("", "RXR-6.2"));
			c.Add(new Component("Name of Coding System", "RXR-6.3"));
			c.Add(new Component("Alternate Identifier", "RXR-6.4"));
			c.Add(new Component("Alternate Text", "RXR-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXR-6.6"));
			c.Add(new Component("Coding System Version ID", "RXR-6.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXR-6.8"));
			c.Add(new Component("Original Text", "RXR-6.9"));
			f.Components = c;
			return f;
		}
	}
}
