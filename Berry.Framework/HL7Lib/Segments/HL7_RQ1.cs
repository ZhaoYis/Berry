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
/// RQ1 Class: Constructs an HL7 RQ1 Segment Object
/// </summary>
public class RQ1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RQ1()
		{
			Name = "RQ1";
			Description = "Requisition Detail-1";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RQ11());
			fs.Add(RQ12());
			fs.Add(RQ13());
			fs.Add(RQ14());
			fs.Add(RQ15());
			fs.Add(RQ16());
			fs.Add(RQ17());
			Fields = fs;
		}
		private Field RQ11()
		{
			Field f = new Field("Anticipated Price");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQ1-1.1"));
			f.Components = c;
			return f;
		}
		private Field RQ12()
		{
			Field f = new Field("Manufacturer Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RQ1-2.1"));
			c.Add(new Component("", "RQ1-2.2"));
			c.Add(new Component("Name of Coding System", "RQ1-2.3"));
			c.Add(new Component("Alternate Identifier", "RQ1-2.4"));
			c.Add(new Component("Alternate Text", "RQ1-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "RQ1-2.6"));
			f.Components = c;
			return f;
		}
		private Field RQ13()
		{
			Field f = new Field("Manufacturer's Catalog");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQ1-3.1"));
			f.Components = c;
			return f;
		}
		private Field RQ14()
		{
			Field f = new Field("Vendor ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RQ1-4.1"));
			c.Add(new Component("", "RQ1-4.2"));
			c.Add(new Component("Name of Coding System", "RQ1-4.3"));
			c.Add(new Component("Alternate Identifier", "RQ1-4.4"));
			c.Add(new Component("Alternate Text", "RQ1-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "RQ1-4.6"));
			f.Components = c;
			return f;
		}
		private Field RQ15()
		{
			Field f = new Field("Vendor Catalog");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQ1-5.1"));
			f.Components = c;
			return f;
		}
		private Field RQ16()
		{
			Field f = new Field("Taxable");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQ1-6.1"));
			f.Components = c;
			return f;
		}
		private Field RQ17()
		{
			Field f = new Field("Substitute Allowed");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQ1-7.1"));
			f.Components = c;
			return f;
		}
	}
}
