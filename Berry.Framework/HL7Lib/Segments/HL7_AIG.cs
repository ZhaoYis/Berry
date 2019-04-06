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
    /// AIG Class: Constructs an HL7 AIG Segment Object
    /// </summary>
	public class AIG
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public AIG()
		{
			Name = "AIG";
			Description = "Appointment Information _ General Resource";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(AIG1());
			fs.Add(AIG2());
			fs.Add(AIG3());
			fs.Add(AIG4());
			fs.Add(AIG5());
			fs.Add(AIG6());
			fs.Add(AIG7());
			fs.Add(AIG8());
			fs.Add(AIG9());
			fs.Add(AIG10());
			fs.Add(AIG11());
			fs.Add(AIG12());
			fs.Add(AIG13());
			fs.Add(AIG14());
			Fields = fs;
		}
		private Field AIG1()
		{
			Field f = new Field("Set ID - AIG");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "AIG-1.1"));
			f.Components = c;
			return f;
		}
		private Field AIG2()
		{
			Field f = new Field("Segment Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIG-2.1"));
			f.Components = c;
			return f;
		}
		private Field AIG3()
		{
			Field f = new Field("Resource ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIG-3.1"));
			c.Add(new Component("", "AIG-3.2"));
			c.Add(new Component("Name of Coding System", "AIG-3.3"));
			c.Add(new Component("Alternate Identifier", "AIG-3.4"));
			c.Add(new Component("Alternate Text", "AIG-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIG-3.6"));
			f.Components = c;
			return f;
		}
		private Field AIG4()
		{
			Field f = new Field("Resource Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIG-4.1"));
			c.Add(new Component("", "AIG-4.2"));
			c.Add(new Component("Name of Coding System", "AIG-4.3"));
			c.Add(new Component("Alternate Identifier", "AIG-4.4"));
			c.Add(new Component("Alternate Text", "AIG-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIG-4.6"));
			f.Components = c;
			return f;
		}
		private Field AIG5()
		{
			Field f = new Field("Resource Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIG-5.1"));
			c.Add(new Component("", "AIG-5.2"));
			c.Add(new Component("Name of Coding System", "AIG-5.3"));
			c.Add(new Component("Alternate Identifier", "AIG-5.4"));
			c.Add(new Component("Alternate Text", "AIG-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIG-5.6"));
			f.Components = c;
			return f;
		}
		private Field AIG6()
		{
			Field f = new Field("Resource Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIG-6.1"));
			f.Components = c;
			return f;
		}
		private Field AIG7()
		{
			Field f = new Field("Resource Quantity Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIG-7.1"));
			c.Add(new Component("", "AIG-7.2"));
			c.Add(new Component("Name of Coding System", "AIG-7.3"));
			c.Add(new Component("Alternate Identifier", "AIG-7.4"));
			c.Add(new Component("Alternate Text", "AIG-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIG-7.6"));
			f.Components = c;
			return f;
		}
		private Field AIG8()
		{
			Field f = new Field("Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "AIG-8.1"));
			c.Add(new Component("Degree of Precision", "AIG-8.2"));
			f.Components = c;
			return f;
		}
		private Field AIG9()
		{
			Field f = new Field("Start Date/Time Offset");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIG-9.1"));
			f.Components = c;
			return f;
		}
		private Field AIG10()
		{
			Field f = new Field("Start Date/Time Offset Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIG-10.1"));
			c.Add(new Component("", "AIG-10.2"));
			c.Add(new Component("Name of Coding System", "AIG-10.3"));
			c.Add(new Component("Alternate Identifier", "AIG-10.4"));
			c.Add(new Component("Alternate Text", "AIG-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIG-10.6"));
			f.Components = c;
			return f;
		}
		private Field AIG11()
		{
			Field f = new Field("Duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIG-11.1"));
			f.Components = c;
			return f;
		}
		private Field AIG12()
		{
			Field f = new Field("Duration Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIG-12.1"));
			c.Add(new Component("", "AIG-12.2"));
			c.Add(new Component("Name of Coding System", "AIG-12.3"));
			c.Add(new Component("Alternate Identifier", "AIG-12.4"));
			c.Add(new Component("Alternate Text", "AIG-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIG-12.6"));
			f.Components = c;
			return f;
		}
		private Field AIG13()
		{
			Field f = new Field("Allow Substitution Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIG-13.1"));
			f.Components = c;
			return f;
		}
		private Field AIG14()
		{
			Field f = new Field("Filler Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIG-14.1"));
			c.Add(new Component("", "AIG-14.2"));
			c.Add(new Component("Name of Coding System", "AIG-14.3"));
			c.Add(new Component("Alternate Identifier", "AIG-14.4"));
			c.Add(new Component("Alternate Text", "AIG-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIG-14.6"));
			f.Components = c;
			return f;
		}
	}
}
