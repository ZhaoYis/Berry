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
/// GP2 Class: Constructs an HL7 GP2 Segment Object
/// </summary>
public class GP2
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public GP2()
		{
			Name = "GP2";
			Description = "Grouping/Reimbursement - Procedure Line Item";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(GP21());
			fs.Add(GP22());
			fs.Add(GP23());
			fs.Add(GP24());
			fs.Add(GP25());
			fs.Add(GP26());
			fs.Add(GP27());
			fs.Add(GP28());
			fs.Add(GP29());
			fs.Add(GP210());
			fs.Add(GP211());
			fs.Add(GP212());
			fs.Add(GP213());
			fs.Add(GP214());
			Fields = fs;
		}
		private Field GP21()
		{
			Field f = new Field("Revenue Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-1.1"));
			f.Components = c;
			return f;
		}
		private Field GP22()
		{
			Field f = new Field("Number of Service Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-2.1"));
			f.Components = c;
			return f;
		}
		private Field GP23()
		{
			Field f = new Field("Charge");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "GP2-3.1"));
			c.Add(new Component("Price Type", "GP2-3.2"));
			c.Add(new Component("From Value", "GP2-3.3"));
			c.Add(new Component("To Value", "GP2-3.4"));
			c.Add(new Component("Range Units", "GP2-3.5"));
			c.Add(new Component("Range Type", "GP2-3.6"));
			f.Components = c;
			return f;
		}
		private Field GP24()
		{
			Field f = new Field("Reimbursement Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-4.1"));
			f.Components = c;
			return f;
		}
		private Field GP25()
		{
			Field f = new Field("Denial or Rejection Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-5.1"));
			f.Components = c;
			return f;
		}
		private Field GP26()
		{
			Field f = new Field("OCE Edit Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-6.1"));
			f.Components = c;
			return f;
		}
		private Field GP27()
		{
			Field f = new Field("Ambulatory Payment Classification Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GP2-7.1"));
			c.Add(new Component("", "GP2-7.2"));
			c.Add(new Component("Name of Coding System", "GP2-7.3"));
			c.Add(new Component("Alternate Identifier", "GP2-7.4"));
			c.Add(new Component("Alternate Text", "GP2-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "GP2-7.6"));
			f.Components = c;
			return f;
		}
		private Field GP28()
		{
			Field f = new Field("Modifier Edit Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-8.1"));
			f.Components = c;
			return f;
		}
		private Field GP29()
		{
			Field f = new Field("Payment Adjustment Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-9.1"));
			f.Components = c;
			return f;
		}
		private Field GP210()
		{
			Field f = new Field("Packaging Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-10.1"));
			f.Components = c;
			return f;
		}
		private Field GP211()
		{
			Field f = new Field("Expected CMS Payment Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "GP2-11.1"));
			c.Add(new Component("Price Type", "GP2-11.2"));
			c.Add(new Component("From Value", "GP2-11.3"));
			c.Add(new Component("To Value", "GP2-11.4"));
			c.Add(new Component("Range Units", "GP2-11.5"));
			c.Add(new Component("Range Type", "GP2-11.6"));
			f.Components = c;
			return f;
		}
		private Field GP212()
		{
			Field f = new Field("Reimbursement Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-12.1"));
			f.Components = c;
			return f;
		}
		private Field GP213()
		{
			Field f = new Field("Co-Pay Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "GP2-13.1"));
			c.Add(new Component("Price Type", "GP2-13.2"));
			c.Add(new Component("From Value", "GP2-13.3"));
			c.Add(new Component("To Value", "GP2-13.4"));
			c.Add(new Component("Range Units", "GP2-13.5"));
			c.Add(new Component("Range Type", "GP2-13.6"));
			f.Components = c;
			return f;
		}
		private Field GP214()
		{
			Field f = new Field("Pay Rate per Service Unit");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GP2-14.1"));
			f.Components = c;
			return f;
		}
	}
}
