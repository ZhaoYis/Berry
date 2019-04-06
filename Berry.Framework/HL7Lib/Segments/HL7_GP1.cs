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
/// GP1 Class: Constructs an HL7 GP1 Segment Object
/// </summary>
public class GP1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public GP1()
		{
			Name = "GP1";
			Description = "Grouping/Reimbursement - Visit";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(GP11());
			fs.Add(GP12());
			fs.Add(GP13());
			fs.Add(GP14());
			fs.Add(GP15());
			Fields = fs;
		}
		private Field GP11()
		{
			Field f = new Field("Type of Bill Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP1-1.1"));
			f.Components = c;
			return f;
		}
		private Field GP12()
		{
			Field f = new Field("Revenue Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP1-2.1"));
			f.Components = c;
			return f;
		}
		private Field GP13()
		{
			Field f = new Field("Overall Claim Disposition Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP1-3.1"));
			f.Components = c;
			return f;
		}
		private Field GP14()
		{
			Field f = new Field("OCE Edits per Visit Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP1-4.1"));
			f.Components = c;
			return f;
		}
		private Field GP15()
		{
			Field f = new Field("Outlier Cost");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "GP1-5.1"));
			c.Add(new Component("Price Type", "GP1-5.2"));
			c.Add(new Component("From Value", "GP1-5.3"));
			c.Add(new Component("To Value", "GP1-5.4"));
			c.Add(new Component("Range Units", "GP1-5.5"));
			c.Add(new Component("Range Type", "GP1-5.6"));
			f.Components = c;
			return f;
		}
	}
}
