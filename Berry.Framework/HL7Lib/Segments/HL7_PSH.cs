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
/// PSH Class: Constructs an HL7 PSH Segment Object
/// </summary>
public class PSH
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PSH()
		{
			Name = "PSH";
			Description = "Product Summary Header";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PSH1());
			fs.Add(PSH2());
			fs.Add(PSH3());
			fs.Add(PSH4());
			fs.Add(PSH5());
			fs.Add(PSH6());
			fs.Add(PSH7());
			fs.Add(PSH8());
			fs.Add(PSH9());
			fs.Add(PSH10());
			fs.Add(PSH11());
			fs.Add(PSH12());
			fs.Add(PSH13());
			fs.Add(PSH14());
			Fields = fs;
		}
		private Field PSH1()
		{
			Field f = new Field("Report Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PSH-1.1"));
			f.Components = c;
			return f;
		}
		private Field PSH2()
		{
			Field f = new Field("Report Form Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PSH-2.1"));
			f.Components = c;
			return f;
		}
		private Field PSH3()
		{
			Field f = new Field("Report Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PSH-3.1"));
			c.Add(new Component("Degree of Precision", "PSH-3.2"));
			f.Components = c;
			return f;
		}
		private Field PSH4()
		{
			Field f = new Field("Report Interval Start Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PSH-4.1"));
			c.Add(new Component("Degree of Precision", "PSH-4.2"));
			f.Components = c;
			return f;
		}
		private Field PSH5()
		{
			Field f = new Field("Report Interval End Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PSH-5.1"));
			c.Add(new Component("Degree of Precision", "PSH-5.2"));
			f.Components = c;
			return f;
		}
		private Field PSH6()
		{
			Field f = new Field("Quantity Manufactured");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PSH-6.1"));
			c.Add(new Component("Units", "PSH-6.2"));
			f.Components = c;
			return f;
		}
		private Field PSH7()
		{
			Field f = new Field("Quantity Distributed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PSH-7.1"));
			c.Add(new Component("Units", "PSH-7.2"));
			f.Components = c;
			return f;
		}
		private Field PSH8()
		{
			Field f = new Field("Quantity Distributed Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PSH-8.1"));
			f.Components = c;
			return f;
		}
		private Field PSH9()
		{
			Field f = new Field("Quantity Distributed Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PSH-9.1"));
			f.Components = c;
			return f;
		}
		private Field PSH10()
		{
			Field f = new Field("Quantity in Use");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PSH-10.1"));
			c.Add(new Component("Units", "PSH-10.2"));
			f.Components = c;
			return f;
		}
		private Field PSH11()
		{
			Field f = new Field("Quantity in Use Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PSH-11.1"));
			f.Components = c;
			return f;
		}
		private Field PSH12()
		{
			Field f = new Field("Quantity in Use Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PSH-12.1"));
			f.Components = c;
			return f;
		}
		private Field PSH13()
		{
			Field f = new Field("Number of Product Experience Reports Filed by Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PSH-13.1"));
			f.Components = c;
			return f;
		}
		private Field PSH14()
		{
			Field f = new Field("Number of Product Experience Reports Filed by Distributor");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PSH-14.1"));
			f.Components = c;
			return f;
		}
	}
}
