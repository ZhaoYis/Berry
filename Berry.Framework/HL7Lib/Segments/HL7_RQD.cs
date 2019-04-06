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
/// RQD Class: Constructs an HL7 RQD Segment Object
/// </summary>
public class RQD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RQD()
		{
			Name = "RQD";
			Description = "Requisition Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RQD1());
			fs.Add(RQD2());
			fs.Add(RQD3());
			fs.Add(RQD4());
			fs.Add(RQD5());
			fs.Add(RQD6());
			fs.Add(RQD7());
			fs.Add(RQD8());
			fs.Add(RQD9());
			fs.Add(RQD10());
			Fields = fs;
		}
		private Field RQD1()
		{
			Field f = new Field("Requisition Line Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "RQD-1.1"));
			f.Components = c;
			return f;
		}
		private Field RQD2()
		{
			Field f = new Field("Item Code - Internal");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RQD-2.1"));
			c.Add(new Component("", "RQD-2.2"));
			c.Add(new Component("Name of Coding System", "RQD-2.3"));
			c.Add(new Component("Alternate Identifier", "RQD-2.4"));
			c.Add(new Component("Alternate Text", "RQD-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "RQD-2.6"));
			f.Components = c;
			return f;
		}
		private Field RQD3()
		{
			Field f = new Field("Item Code - External");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RQD-3.1"));
			c.Add(new Component("", "RQD-3.2"));
			c.Add(new Component("Name of Coding System", "RQD-3.3"));
			c.Add(new Component("Alternate Identifier", "RQD-3.4"));
			c.Add(new Component("Alternate Text", "RQD-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "RQD-3.6"));
			f.Components = c;
			return f;
		}
		private Field RQD4()
		{
			Field f = new Field("Hospital Item Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RQD-4.1"));
			c.Add(new Component("", "RQD-4.2"));
			c.Add(new Component("Name of Coding System", "RQD-4.3"));
			c.Add(new Component("Alternate Identifier", "RQD-4.4"));
			c.Add(new Component("Alternate Text", "RQD-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "RQD-4.6"));
			f.Components = c;
			return f;
		}
		private Field RQD5()
		{
			Field f = new Field("Requisition Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQD-5.1"));
			f.Components = c;
			return f;
		}
		private Field RQD6()
		{
			Field f = new Field("Requisition Unit of Measure");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RQD-6.1"));
			c.Add(new Component("", "RQD-6.2"));
			c.Add(new Component("Name of Coding System", "RQD-6.3"));
			c.Add(new Component("Alternate Identifier", "RQD-6.4"));
			c.Add(new Component("Alternate Text", "RQD-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "RQD-6.6"));
			f.Components = c;
			return f;
		}
		private Field RQD7()
		{
			Field f = new Field("Dept. Cost Center");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQD-7.1"));
			f.Components = c;
			return f;
		}
		private Field RQD8()
		{
			Field f = new Field("Item Natural Account Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQD-8.1"));
			f.Components = c;
			return f;
		}
		private Field RQD9()
		{
			Field f = new Field("Deliver To ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RQD-9.1"));
			c.Add(new Component("", "RQD-9.2"));
			c.Add(new Component("Name of Coding System", "RQD-9.3"));
			c.Add(new Component("Alternate Identifier", "RQD-9.4"));
			c.Add(new Component("Alternate Text", "RQD-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "RQD-9.6"));
			f.Components = c;
			return f;
		}
		private Field RQD10()
		{
			Field f = new Field("Date Needed");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RQD-10.1"));
			f.Components = c;
			return f;
		}
	}
}
