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
/// FHS Class: Constructs an HL7 FHS Segment Object
/// </summary>
public class FHS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public FHS()
		{
			Name = "FHS";
			Description = "File Header";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(FHS1());
			fs.Add(FHS2());
			fs.Add(FHS3());
			fs.Add(FHS4());
			fs.Add(FHS5());
			fs.Add(FHS6());
			fs.Add(FHS7());
			fs.Add(FHS8());
			fs.Add(FHS9());
			fs.Add(FHS10());
			fs.Add(FHS11());
			fs.Add(FHS12());
			Fields = fs;
		}
		private Field FHS1()
		{
			Field f = new Field("File Field Separator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FHS-1.1"));
			f.Components = c;
			return f;
		}
		private Field FHS2()
		{
			Field f = new Field("File Encoding Characters");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FHS-2.1"));
			f.Components = c;
			return f;
		}
		private Field FHS3()
		{
			Field f = new Field("File Sending Application");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "FHS-3.1"));
			c.Add(new Component("Universal ID", "FHS-3.2"));
			c.Add(new Component("Universal ID Type", "FHS-3.3"));
			f.Components = c;
			return f;
		}
		private Field FHS4()
		{
			Field f = new Field("File Sending Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "FHS-4.1"));
			c.Add(new Component("Universal ID", "FHS-4.2"));
			c.Add(new Component("Universal ID Type", "FHS-4.3"));
			f.Components = c;
			return f;
		}
		private Field FHS5()
		{
			Field f = new Field("File Receiving Application");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "FHS-5.1"));
			c.Add(new Component("Universal ID", "FHS-5.2"));
			c.Add(new Component("Universal ID Type", "FHS-5.3"));
			f.Components = c;
			return f;
		}
		private Field FHS6()
		{
			Field f = new Field("File Receiving Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "FHS-6.1"));
			c.Add(new Component("Universal ID", "FHS-6.2"));
			c.Add(new Component("Universal ID Type", "FHS-6.3"));
			f.Components = c;
			return f;
		}
		private Field FHS7()
		{
			Field f = new Field("File Creation Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "FHS-7.1"));
			c.Add(new Component("Degree of Precision", "FHS-7.2"));
			f.Components = c;
			return f;
		}
		private Field FHS8()
		{
			Field f = new Field("File Security");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FHS-8.1"));
			f.Components = c;
			return f;
		}
		private Field FHS9()
		{
			Field f = new Field("File Name/ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FHS-9.1"));
			f.Components = c;
			return f;
		}
		private Field FHS10()
		{
			Field f = new Field("File Header Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FHS-10.1"));
			f.Components = c;
			return f;
		}
		private Field FHS11()
		{
			Field f = new Field("File Control ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FHS-11.1"));
			f.Components = c;
			return f;
		}
		private Field FHS12()
		{
			Field f = new Field("Reference File Control ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FHS-12.1"));
			f.Components = c;
			return f;
		}
	}
}
