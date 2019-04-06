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
/// DRG Class: Constructs an HL7 DRG Segment Object
/// </summary>
public class DRG
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public DRG()
		{
			Name = "DRG";
			Description = "Diagnosis Related Group";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(DRG1());
			fs.Add(DRG2());
			fs.Add(DRG3());
			fs.Add(DRG4());
			fs.Add(DRG5());
			fs.Add(DRG6());
			fs.Add(DRG7());
			fs.Add(DRG8());
			fs.Add(DRG9());
			fs.Add(DRG10());
			fs.Add(DRG11());
			Fields = fs;
		}
		private Field DRG1()
		{
			Field f = new Field("Diagnostic Related Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "DRG-1.1"));
			c.Add(new Component("", "DRG-1.2"));
			c.Add(new Component("Name of Coding System", "DRG-1.3"));
			c.Add(new Component("Alternate Identifier", "DRG-1.4"));
			c.Add(new Component("Alternate Text", "DRG-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "DRG-1.6"));
			f.Components = c;
			return f;
		}
		private Field DRG2()
		{
			Field f = new Field("DRG Assigned Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "DRG-2.1"));
			c.Add(new Component("Degree of Precision", "DRG-2.2"));
			f.Components = c;
			return f;
		}
		private Field DRG3()
		{
			Field f = new Field("DRG Approval Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DRG-3.1"));
			f.Components = c;
			return f;
		}
		private Field DRG4()
		{
			Field f = new Field("DRG Grouper Review Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DRG-4.1"));
			f.Components = c;
			return f;
		}
		private Field DRG5()
		{
			Field f = new Field("Outlier Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "DRG-5.1"));
			c.Add(new Component("", "DRG-5.2"));
			c.Add(new Component("Name of Coding System", "DRG-5.3"));
			c.Add(new Component("Alternate Identifier", "DRG-5.4"));
			c.Add(new Component("Alternate Text", "DRG-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "DRG-5.6"));
			f.Components = c;
			return f;
		}
		private Field DRG6()
		{
			Field f = new Field("Outlier Days");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DRG-6.1"));
			f.Components = c;
			return f;
		}
		private Field DRG7()
		{
			Field f = new Field("Outlier Cost");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "DRG-7.1"));
			c.Add(new Component("Price Type", "DRG-7.2"));
			c.Add(new Component("From Value", "DRG-7.3"));
			c.Add(new Component("To Value", "DRG-7.4"));
			c.Add(new Component("Range Units", "DRG-7.5"));
			c.Add(new Component("Range Type", "DRG-7.6"));
			f.Components = c;
			return f;
		}
		private Field DRG8()
		{
			Field f = new Field("DRG Payor");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DRG-8.1"));
			f.Components = c;
			return f;
		}
		private Field DRG9()
		{
			Field f = new Field("Outlier Reimbursement");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "DRG-9.1"));
			c.Add(new Component("Price Type", "DRG-9.2"));
			c.Add(new Component("From Value", "DRG-9.3"));
			c.Add(new Component("To Value", "DRG-9.4"));
			c.Add(new Component("Range Units", "DRG-9.5"));
			c.Add(new Component("Range Type", "DRG-9.6"));
			f.Components = c;
			return f;
		}
		private Field DRG10()
		{
			Field f = new Field("Confidential Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DRG-10.1"));
			f.Components = c;
			return f;
		}
		private Field DRG11()
		{
			Field f = new Field("DRG Transfer Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DRG-11.1"));
			f.Components = c;
			return f;
		}
	}
}
