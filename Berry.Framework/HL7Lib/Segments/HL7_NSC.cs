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
/// NSC Class: Constructs an HL7 NSC Segment Object
/// </summary>
public class NSC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public NSC()
		{
			Name = "NSC";
			Description = "Application Status Change";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(NSC1());
			fs.Add(NSC2());
			fs.Add(NSC3());
			fs.Add(NSC4());
			fs.Add(NSC5());
			fs.Add(NSC6());
			fs.Add(NSC7());
			fs.Add(NSC8());
			fs.Add(NSC9());
			Fields = fs;
		}
		private Field NSC1()
		{
			Field f = new Field("Application Change Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NSC-1.1"));
			f.Components = c;
			return f;
		}
		private Field NSC2()
		{
			Field f = new Field("Current CPU");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NSC-2.1"));
			f.Components = c;
			return f;
		}
		private Field NSC3()
		{
			Field f = new Field("Current Fileserver");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NSC-3.1"));
			f.Components = c;
			return f;
		}
		private Field NSC4()
		{
			Field f = new Field("Current Application");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "NSC-4.1"));
			c.Add(new Component("Universal ID", "NSC-4.2"));
			c.Add(new Component("Universal ID Type", "NSC-4.3"));
			f.Components = c;
			return f;
		}
		private Field NSC5()
		{
			Field f = new Field("Current Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "NSC-5.1"));
			c.Add(new Component("Universal ID", "NSC-5.2"));
			c.Add(new Component("Universal ID Type", "NSC-5.3"));
			f.Components = c;
			return f;
		}
		private Field NSC6()
		{
			Field f = new Field("New CPU");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NSC-6.1"));
			f.Components = c;
			return f;
		}
		private Field NSC7()
		{
			Field f = new Field("New Fileserver");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NSC-7.1"));
			f.Components = c;
			return f;
		}
		private Field NSC8()
		{
			Field f = new Field("New Application");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "NSC-8.1"));
			c.Add(new Component("Universal ID", "NSC-8.2"));
			c.Add(new Component("Universal ID Type", "NSC-8.3"));
			f.Components = c;
			return f;
		}
		private Field NSC9()
		{
			Field f = new Field("New Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "NSC-9.1"));
			c.Add(new Component("Universal ID", "NSC-9.2"));
			c.Add(new Component("Universal ID Type", "NSC-9.3"));
			f.Components = c;
			return f;
		}
	}
}
