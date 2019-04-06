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
/// TQ1 Class: Constructs an HL7 TQ1 Segment Object
/// </summary>
public class TQ1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public TQ1()
		{
			Name = "TQ1";
			Description = "Timing/Quantity";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(TQ11());
			fs.Add(TQ12());
			fs.Add(TQ13());
			fs.Add(TQ14());
			fs.Add(TQ15());
			fs.Add(TQ16());
			fs.Add(TQ17());
			fs.Add(TQ18());
			fs.Add(TQ19());
			fs.Add(TQ110());
			fs.Add(TQ111());
			fs.Add(TQ112());
			fs.Add(TQ113());
			fs.Add(TQ114());
			Fields = fs;
		}
		private Field TQ11()
		{
			Field f = new Field("Set ID - TQ1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "TQ1-1.1"));
			f.Components = c;
			return f;
		}
		private Field TQ12()
		{
			Field f = new Field("Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "TQ1-2.1"));
			c.Add(new Component("Units", "TQ1-2.2"));
			f.Components = c;
			return f;
		}
		private Field TQ13()
		{
			Field f = new Field("Repeat Pattern");
			List<Component> c = new List<Component>();
			c.Add(new Component("Repeat Pattern Code", "TQ1-3.1"));
			c.Add(new Component("Calendar Alignment", "TQ1-3.2"));
			c.Add(new Component("Phase Range Begin Value", "TQ1-3.3"));
			c.Add(new Component("Phase Range End Value", "TQ1-3.4"));
			c.Add(new Component("Period Quantity", "TQ1-3.5"));
			c.Add(new Component("Period Units", "TQ1-3.6"));
			c.Add(new Component("Institution Specified Time", "TQ1-3.7"));
			c.Add(new Component("Event", "TQ1-3.8"));
			c.Add(new Component("Event Offset Quantity", "TQ1-3.9"));
			c.Add(new Component("Event Offset Units", "TQ1-3.10"));
			c.Add(new Component("General Timing Specification", "TQ1-3.11"));
			f.Components = c;
			return f;
		}
		private Field TQ14()
		{
			Field f = new Field("Explicit Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "TQ1-4.1"));
			f.Components = c;
			return f;
		}
		private Field TQ15()
		{
			Field f = new Field("Relative Time and Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "TQ1-5.1"));
			c.Add(new Component("Units", "TQ1-5.2"));
			f.Components = c;
			return f;
		}
		private Field TQ16()
		{
			Field f = new Field("Service Duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "TQ1-6.1"));
			c.Add(new Component("Units", "TQ1-6.2"));
			f.Components = c;
			return f;
		}
		private Field TQ17()
		{
			Field f = new Field("Start date/time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "TQ1-7.1"));
			c.Add(new Component("Degree of Precision", "TQ1-7.2"));
			f.Components = c;
			return f;
		}
		private Field TQ18()
		{
			Field f = new Field("End date/time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "TQ1-8.1"));
			c.Add(new Component("Degree of Precision", "TQ1-8.2"));
			f.Components = c;
			return f;
		}
		private Field TQ19()
		{
			Field f = new Field("Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "TQ1-9.1"));
			c.Add(new Component("", "TQ1-9.2"));
			c.Add(new Component("Name of Coding System", "TQ1-9.3"));
			c.Add(new Component("Alternate Identifier", "TQ1-9.4"));
			c.Add(new Component("Alternate Text", "TQ1-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "TQ1-9.6"));
			c.Add(new Component("Coding System Version ID", "TQ1-9.7"));
			c.Add(new Component("Alternate Coding System Version ID", "TQ1-9.8"));
			c.Add(new Component("Original Text", "TQ1-9.9"));
			f.Components = c;
			return f;
		}
		private Field TQ110()
		{
			Field f = new Field("Condition text");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ1-10.1"));
			f.Components = c;
			return f;
		}
		private Field TQ111()
		{
			Field f = new Field("Text instruction");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ1-11.1"));
			f.Components = c;
			return f;
		}
		private Field TQ112()
		{
			Field f = new Field("Conjunction");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ1-12.1"));
			f.Components = c;
			return f;
		}
		private Field TQ113()
		{
			Field f = new Field("Occurrence duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "TQ1-13.1"));
			c.Add(new Component("Units", "TQ1-13.2"));
			f.Components = c;
			return f;
		}
		private Field TQ114()
		{
			Field f = new Field("Total occurrence's");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ1-14.1"));
			f.Components = c;
			return f;
		}
	}
}
