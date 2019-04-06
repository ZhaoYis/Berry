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
/// NST Class: Constructs an HL7 NST Segment Object
/// </summary>
public class NST
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public NST()
		{
			Name = "NST";
			Description = "Application control level statistics";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(NST1());
			fs.Add(NST2());
			fs.Add(NST3());
			fs.Add(NST4());
			fs.Add(NST5());
			fs.Add(NST6());
			fs.Add(NST7());
			fs.Add(NST8());
			fs.Add(NST9());
			fs.Add(NST10());
			fs.Add(NST11());
			fs.Add(NST12());
			fs.Add(NST13());
			fs.Add(NST14());
			fs.Add(NST15());
			Fields = fs;
		}
		private Field NST1()
		{
			Field f = new Field("Statistics Available");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-1.1"));
			f.Components = c;
			return f;
		}
		private Field NST2()
		{
			Field f = new Field("Source Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-2.1"));
			f.Components = c;
			return f;
		}
		private Field NST3()
		{
			Field f = new Field("Source Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-3.1"));
			f.Components = c;
			return f;
		}
		private Field NST4()
		{
			Field f = new Field("Statistics Start");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "NST-4.1"));
			c.Add(new Component("Degree of Precision", "NST-4.2"));
			f.Components = c;
			return f;
		}
		private Field NST5()
		{
			Field f = new Field("Statistics End");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "NST-5.1"));
			c.Add(new Component("Degree of Precision", "NST-5.2"));
			f.Components = c;
			return f;
		}
		private Field NST6()
		{
			Field f = new Field("Receive Character Count");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-6.1"));
			f.Components = c;
			return f;
		}
		private Field NST7()
		{
			Field f = new Field("Send Character Count");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-7.1"));
			f.Components = c;
			return f;
		}
		private Field NST8()
		{
			Field f = new Field("Messages Received");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-8.1"));
			f.Components = c;
			return f;
		}
		private Field NST9()
		{
			Field f = new Field("Messages Sent");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-9.1"));
			f.Components = c;
			return f;
		}
		private Field NST10()
		{
			Field f = new Field("Checksum Errors Received");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-10.1"));
			f.Components = c;
			return f;
		}
		private Field NST11()
		{
			Field f = new Field("Length Errors Received");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-11.1"));
			f.Components = c;
			return f;
		}
		private Field NST12()
		{
			Field f = new Field("Other Errors Received");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-12.1"));
			f.Components = c;
			return f;
		}
		private Field NST13()
		{
			Field f = new Field("Connect Timeouts");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-13.1"));
			f.Components = c;
			return f;
		}
		private Field NST14()
		{
			Field f = new Field("Receive Timeouts");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-14.1"));
			f.Components = c;
			return f;
		}
		private Field NST15()
		{
			Field f = new Field("Application control-level Errors");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NST-15.1"));
			f.Components = c;
			return f;
		}
	}
}
