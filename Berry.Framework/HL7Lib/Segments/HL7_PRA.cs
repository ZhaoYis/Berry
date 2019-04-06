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
/// PRA Class: Constructs an HL7 PRA Segment Object
/// </summary>
public class PRA
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PRA()
		{
			Name = "PRA";
			Description = "Practitioner Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PRA1());
			fs.Add(PRA2());
			fs.Add(PRA3());
			fs.Add(PRA4());
			fs.Add(PRA5());
			fs.Add(PRA6());
			fs.Add(PRA7());
			fs.Add(PRA8());
			fs.Add(PRA9());
			fs.Add(PRA10());
			fs.Add(PRA11());
			fs.Add(PRA12());
			Fields = fs;
		}
		private Field PRA1()
		{
			Field f = new Field("Primary Key Value - PRA");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRA-1.1"));
			c.Add(new Component("", "PRA-1.2"));
			c.Add(new Component("Name of Coding System", "PRA-1.3"));
			c.Add(new Component("Alternate Identifier", "PRA-1.4"));
			c.Add(new Component("Alternate Text", "PRA-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRA-1.6"));
			f.Components = c;
			return f;
		}
		private Field PRA2()
		{
			Field f = new Field("Practitioner Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRA-2.1"));
			c.Add(new Component("", "PRA-2.2"));
			c.Add(new Component("Name of Coding System", "PRA-2.3"));
			c.Add(new Component("Alternate Identifier", "PRA-2.4"));
			c.Add(new Component("Alternate Text", "PRA-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRA-2.6"));
			f.Components = c;
			return f;
		}
		private Field PRA3()
		{
			Field f = new Field("Practitioner Category");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRA-3.1"));
			f.Components = c;
			return f;
		}
		private Field PRA4()
		{
			Field f = new Field("Provider Billing");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRA-4.1"));
			f.Components = c;
			return f;
		}
		private Field PRA5()
		{
			Field f = new Field("Specialty");
			List<Component> c = new List<Component>();
			c.Add(new Component("Specialty Name", "PRA-5.1"));
			c.Add(new Component("Governing Board", "PRA-5.2"));
			c.Add(new Component("Eligible or Certified", "PRA-5.3"));
			c.Add(new Component("Date of Certification", "PRA-5.4"));
			f.Components = c;
			return f;
		}
		private Field PRA6()
		{
			Field f = new Field("Practitioner ID Numbers");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PRA-6.1"));
			c.Add(new Component("Type or ID Number", "PRA-6.2"));
			c.Add(new Component("State Other Qualifying Information", "PRA-6.3"));
			c.Add(new Component("Expiration Date", "PRA-6.4"));
			f.Components = c;
			return f;
		}
		private Field PRA7()
		{
			Field f = new Field("Privileges");
			List<Component> c = new List<Component>();
			c.Add(new Component("Privilege", "PRA-7.1"));
			c.Add(new Component("Privilege Class", "PRA-7.2"));
			c.Add(new Component("Expiration Date", "PRA-7.3"));
			c.Add(new Component("Activation Date", "PRA-7.4"));
			c.Add(new Component("Facility", "PRA-7.5"));
			f.Components = c;
			return f;
		}
		private Field PRA8()
		{
			Field f = new Field("Date Entered Practice");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRA-8.1"));
			f.Components = c;
			return f;
		}
		private Field PRA9()
		{
			Field f = new Field("Institution");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRA-9.1"));
			c.Add(new Component("", "PRA-9.2"));
			c.Add(new Component("Name of Coding System", "PRA-9.3"));
			c.Add(new Component("Alternate Identifier", "PRA-9.4"));
			c.Add(new Component("Alternate Text", "PRA-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRA-9.6"));
			f.Components = c;
			return f;
		}
		private Field PRA10()
		{
			Field f = new Field("Date Left Practice");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRA-10.1"));
			f.Components = c;
			return f;
		}
		private Field PRA11()
		{
			Field f = new Field("Government Reimbursement Billing Eligibility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRA-11.1"));
			c.Add(new Component("", "PRA-11.2"));
			c.Add(new Component("Name of Coding System", "PRA-11.3"));
			c.Add(new Component("Alternate Identifier", "PRA-11.4"));
			c.Add(new Component("Alternate Text", "PRA-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRA-11.6"));
			f.Components = c;
			return f;
		}
		private Field PRA12()
		{
			Field f = new Field("Set ID - PRA");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "PRA-12.1"));
			f.Components = c;
			return f;
		}
	}
}
