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
/// URS Class: Constructs an HL7 URS Segment Object
/// </summary>
public class URS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public URS()
		{
			Name = "URS";
			Description = "Unsolicited Selection";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(URS1());
			fs.Add(URS2());
			fs.Add(URS3());
			fs.Add(URS4());
			fs.Add(URS5());
			fs.Add(URS6());
			fs.Add(URS7());
			fs.Add(URS8());
			fs.Add(URS9());
			Fields = fs;
		}
		private Field URS1()
		{
			Field f = new Field("R/U Where Subject Definition");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URS-1.1"));
			f.Components = c;
			return f;
		}
		private Field URS2()
		{
			Field f = new Field("R/U When Data Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "URS-2.1"));
			c.Add(new Component("Degree of Precision", "URS-2.2"));
			f.Components = c;
			return f;
		}
		private Field URS3()
		{
			Field f = new Field("R/U When Data End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "URS-3.1"));
			c.Add(new Component("Degree of Precision", "URS-3.2"));
			f.Components = c;
			return f;
		}
		private Field URS4()
		{
			Field f = new Field("R/U What User Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URS-4.1"));
			f.Components = c;
			return f;
		}
		private Field URS5()
		{
			Field f = new Field("R/U Other Results Subject Definition");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URS-5.1"));
			f.Components = c;
			return f;
		}
		private Field URS6()
		{
			Field f = new Field("R/U Which Date/Time Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URS-6.1"));
			f.Components = c;
			return f;
		}
		private Field URS7()
		{
			Field f = new Field("R/U Which Date/Time Status Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URS-7.1"));
			f.Components = c;
			return f;
		}
		private Field URS8()
		{
			Field f = new Field("R/U Date/Time Selection Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URS-8.1"));
			f.Components = c;
			return f;
		}
		private Field URS9()
		{
			Field f = new Field("R/U Quantity/Timing Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "URS-9.1"));
			c.Add(new Component("Interval", "URS-9.2"));
			c.Add(new Component("Duration", "URS-9.3"));
			c.Add(new Component("Start Date/Time", "URS-9.4"));
			c.Add(new Component("End Date Time", "URS-9.5"));
			c.Add(new Component("Priority", "URS-9.6"));
			c.Add(new Component("Condition", "URS-9.7"));
			c.Add(new Component("", "URS-9.8"));
			c.Add(new Component("Conjunction", "URS-9.9"));
			c.Add(new Component("Order Sequencing", "URS-9.10"));
			c.Add(new Component("Occurrence Duration", "URS-9.11"));
			c.Add(new Component("Total Occurrences", "URS-9.12"));
			f.Components = c;
			return f;
		}
	}
}
