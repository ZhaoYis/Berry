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
/// ERR Class: Constructs an HL7 ERR Segment Object
/// </summary>
public class ERR
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ERR()
		{
			Name = "ERR";
			Description = "Error";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ERR1());
			fs.Add(ERR2());
			fs.Add(ERR3());
			fs.Add(ERR4());
			fs.Add(ERR5());
			fs.Add(ERR6());
			fs.Add(ERR7());
			fs.Add(ERR8());
			fs.Add(ERR9());
			fs.Add(ERR10());
			fs.Add(ERR11());
			fs.Add(ERR12());
			Fields = fs;
		}
		private Field ERR1()
		{
			Field f = new Field("Error Code and Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Segment ID", "ERR-1.1"));
			c.Add(new Component("Segment Sequence", "ERR-1.2"));
			c.Add(new Component("Field Position", "ERR-1.3"));
			c.Add(new Component("Code Identifying Error", "ERR-1.4"));
			f.Components = c;
			return f;
		}
		private Field ERR2()
		{
			Field f = new Field("Error Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Segment ID", "ERR-2.1"));
			c.Add(new Component("Segment Sequence", "ERR-2.2"));
			c.Add(new Component("Field Position", "ERR-2.3"));
			c.Add(new Component("Field Repetition", "ERR-2.4"));
			c.Add(new Component("Component Number", "ERR-2.5"));
			c.Add(new Component("Sub-Component Number", "ERR-2.6"));
			f.Components = c;
			return f;
		}
		private Field ERR3()
		{
			Field f = new Field("HL7 Error Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ERR-3.1"));
			c.Add(new Component("", "ERR-3.2"));
			c.Add(new Component("Name of Coding System", "ERR-3.3"));
			c.Add(new Component("Alternate Identifier", "ERR-3.4"));
			c.Add(new Component("Alternate Text", "ERR-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "ERR-3.6"));
			c.Add(new Component("Coding System Version ID", "ERR-3.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ERR-3.8"));
			c.Add(new Component("Original Text", "ERR-3.9"));
			f.Components = c;
			return f;
		}
		private Field ERR4()
		{
			Field f = new Field("Severity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ERR-4.1"));
			f.Components = c;
			return f;
		}
		private Field ERR5()
		{
			Field f = new Field("Application Error Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ERR-5.1"));
			c.Add(new Component("", "ERR-5.2"));
			c.Add(new Component("Name of Coding System", "ERR-5.3"));
			c.Add(new Component("Alternate Identifier", "ERR-5.4"));
			c.Add(new Component("Alternate Text", "ERR-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "ERR-5.6"));
			c.Add(new Component("Coding System Version ID", "ERR-5.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ERR-5.8"));
			c.Add(new Component("Original Text", "ERR-5.9"));
			f.Components = c;
			return f;
		}
		private Field ERR6()
		{
			Field f = new Field("Application Error Parameter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ERR-6.1"));
			f.Components = c;
			return f;
		}
		private Field ERR7()
		{
			Field f = new Field("Diagnostic Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ERR-7.1"));
			f.Components = c;
			return f;
		}
		private Field ERR8()
		{
			Field f = new Field("User Message");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ERR-8.1"));
			f.Components = c;
			return f;
		}
		private Field ERR9()
		{
			Field f = new Field("Inform Person Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ERR-9.1"));
			f.Components = c;
			return f;
		}
		private Field ERR10()
		{
			Field f = new Field("Override Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ERR-10.1"));
			c.Add(new Component("", "ERR-10.2"));
			c.Add(new Component("Name of Coding System", "ERR-10.3"));
			c.Add(new Component("Alternate Identifier", "ERR-10.4"));
			c.Add(new Component("Alternate Text", "ERR-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "ERR-10.6"));
			c.Add(new Component("Coding System Version ID", "ERR-10.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ERR-10.8"));
			c.Add(new Component("Original Text", "ERR-10.9"));
			f.Components = c;
			return f;
		}
		private Field ERR11()
		{
			Field f = new Field("Override Reason Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ERR-11.1"));
			c.Add(new Component("", "ERR-11.2"));
			c.Add(new Component("Name of Coding System", "ERR-11.3"));
			c.Add(new Component("Alternate Identifier", "ERR-11.4"));
			c.Add(new Component("Alternate Text", "ERR-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "ERR-11.6"));
			c.Add(new Component("Coding System Version ID", "ERR-11.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ERR-11.8"));
			c.Add(new Component("Original Text", "ERR-11.9"));
			f.Components = c;
			return f;
		}
		private Field ERR12()
		{
			Field f = new Field("Help Desk Contact Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "ERR-12.1"));
			c.Add(new Component("Tele-Communication Use Code", "ERR-12.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "ERR-12.3"));
			c.Add(new Component("Email Address", "ERR-12.4"));
			c.Add(new Component("Country Code", "ERR-12.5"));
			c.Add(new Component("Area City Code", "ERR-12.6"));
			c.Add(new Component("Local Number", "ERR-12.7"));
			c.Add(new Component("Extension", "ERR-12.8"));
			c.Add(new Component("", "ERR-12.9"));
			c.Add(new Component("Extension Prefix", "ERR-12.10"));
			c.Add(new Component("Speed Dial Code", "ERR-12.11"));
			c.Add(new Component("Unformatted Telephone Number", "ERR-12.12"));
			f.Components = c;
			return f;
		}
	}
}
