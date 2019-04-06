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
/// UB2 Class: Constructs an HL7 UB2 Segment Object
/// </summary>
public class UB2
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public UB2()
		{
			Name = "UB2";
			Description = "UB92 Data";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(UB21());
			fs.Add(UB22());
			fs.Add(UB23());
			fs.Add(UB24());
			fs.Add(UB25());
			fs.Add(UB26());
			fs.Add(UB27());
			fs.Add(UB28());
			fs.Add(UB29());
			fs.Add(UB210());
			fs.Add(UB211());
			fs.Add(UB212());
			fs.Add(UB213());
			fs.Add(UB214());
			fs.Add(UB215());
			fs.Add(UB216());
			fs.Add(UB217());
			Fields = fs;
		}
		private Field UB21()
		{
			Field f = new Field("Set ID - UB2");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "UB2-1.1"));
			f.Components = c;
			return f;
		}
		private Field UB22()
		{
			Field f = new Field("Co-Insurance Days (9)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-2.1"));
			f.Components = c;
			return f;
		}
		private Field UB23()
		{
			Field f = new Field("Condition Code (24-30)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-3.1"));
			f.Components = c;
			return f;
		}
		private Field UB24()
		{
			Field f = new Field("Covered Days (7)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-4.1"));
			f.Components = c;
			return f;
		}
		private Field UB25()
		{
			Field f = new Field("Non-Covered Days (8)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-5.1"));
			f.Components = c;
			return f;
		}
		private Field UB26()
		{
			Field f = new Field("Value Amount & Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Value Code", "UB2-6.1"));
			c.Add(new Component("Value Amount", "UB2-6.2"));
			f.Components = c;
			return f;
		}
		private Field UB27()
		{
			Field f = new Field("Occurrence Code & Date (32-35)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Occurence Code", "UB2-7.1"));
			c.Add(new Component("Occurence Date", "UB2-7.2"));
			f.Components = c;
			return f;
		}
		private Field UB28()
		{
			Field f = new Field("Occurrence Span Code/Dates (36)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Occurence Span Code", "UB2-8.1"));
			c.Add(new Component("Occurrence Span Start Date", "UB2-8.2"));
			c.Add(new Component("Occurrence Span Stop Date", "UB2-8.3"));
			f.Components = c;
			return f;
		}
		private Field UB29()
		{
			Field f = new Field("UB92 Locator 2 (State)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-9.1"));
			f.Components = c;
			return f;
		}
		private Field UB210()
		{
			Field f = new Field("UB92 Locator 11 (State)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-10.1"));
			f.Components = c;
			return f;
		}
		private Field UB211()
		{
			Field f = new Field("UB92 Locator 31 (National)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-11.1"));
			f.Components = c;
			return f;
		}
		private Field UB212()
		{
			Field f = new Field("Document Control Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-12.1"));
			f.Components = c;
			return f;
		}
		private Field UB213()
		{
			Field f = new Field("UB92 Locator 49 (National)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-13.1"));
			f.Components = c;
			return f;
		}
		private Field UB214()
		{
			Field f = new Field("UB92 Locator 56 (State)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-14.1"));
			f.Components = c;
			return f;
		}
		private Field UB215()
		{
			Field f = new Field("UB92 Locator 57 (National)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-15.1"));
			f.Components = c;
			return f;
		}
		private Field UB216()
		{
			Field f = new Field("UB92 Locator 78 (State)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-16.1"));
			f.Components = c;
			return f;
		}
		private Field UB217()
		{
			Field f = new Field("Special Visit Count");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB2-17.1"));
			f.Components = c;
			return f;
		}
	}
}
