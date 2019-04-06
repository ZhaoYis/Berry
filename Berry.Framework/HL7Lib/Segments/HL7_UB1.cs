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
/// UB1 Class: Constructs an HL7 UB1 Segment Object
/// </summary>
public class UB1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public UB1()
		{
			Name = "UB1";
			Description = "UB82";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(UB11());
			fs.Add(UB12());
			fs.Add(UB13());
			fs.Add(UB14());
			fs.Add(UB15());
			fs.Add(UB16());
			fs.Add(UB17());
			fs.Add(UB18());
			fs.Add(UB19());
			fs.Add(UB110());
			fs.Add(UB111());
			fs.Add(UB112());
			fs.Add(UB113());
			fs.Add(UB114());
			fs.Add(UB115());
			fs.Add(UB116());
			fs.Add(UB117());
			fs.Add(UB118());
			fs.Add(UB119());
			fs.Add(UB120());
			fs.Add(UB121());
			fs.Add(UB122());
			fs.Add(UB123());
			Fields = fs;
		}
		private Field UB11()
		{
			Field f = new Field("Set ID - UB1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "UB1-1.1"));
			f.Components = c;
			return f;
		}
		private Field UB12()
		{
			Field f = new Field("Blood Deductible (43)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-2.1"));
			f.Components = c;
			return f;
		}
		private Field UB13()
		{
			Field f = new Field("Blood Furnished-Pints Of (40)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-3.1"));
			f.Components = c;
			return f;
		}
		private Field UB14()
		{
			Field f = new Field("Blood Replaced-Pints (41)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-4.1"));
			f.Components = c;
			return f;
		}
		private Field UB15()
		{
			Field f = new Field("Blood Not Replaced-Pints(42)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-5.1"));
			f.Components = c;
			return f;
		}
		private Field UB16()
		{
			Field f = new Field("Co-Insurance Days (25)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-6.1"));
			f.Components = c;
			return f;
		}
		private Field UB17()
		{
			Field f = new Field("Condition Code (35-39)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-7.1"));
			f.Components = c;
			return f;
		}
		private Field UB18()
		{
			Field f = new Field("Covered Days - (23)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-8.1"));
			f.Components = c;
			return f;
		}
		private Field UB19()
		{
			Field f = new Field("Non Covered Days - (24)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-9.1"));
			f.Components = c;
			return f;
		}
		private Field UB110()
		{
			Field f = new Field("Value Amount & Code (46-49)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Value Code", "UB1-10.1"));
			c.Add(new Component("Value Amount", "UB1-10.2"));
			f.Components = c;
			return f;
		}
		private Field UB111()
		{
			Field f = new Field("Number Of Grace Days (90)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-11.1"));
			f.Components = c;
			return f;
		}
		private Field UB112()
		{
			Field f = new Field("Special Program Indicator (44)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "UB1-12.1"));
			c.Add(new Component("", "UB1-12.2"));
			c.Add(new Component("Name of Coding System", "UB1-12.3"));
			c.Add(new Component("Alternate Identifier", "UB1-12.4"));
			c.Add(new Component("Alternate Text", "UB1-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "UB1-12.6"));
			f.Components = c;
			return f;
		}
		private Field UB113()
		{
			Field f = new Field("PSRO/UR Approval Indicator (87)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "UB1-13.1"));
			c.Add(new Component("", "UB1-13.2"));
			c.Add(new Component("Name of Coding System", "UB1-13.3"));
			c.Add(new Component("Alternate Identifier", "UB1-13.4"));
			c.Add(new Component("Alternate Text", "UB1-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "UB1-13.6"));
			f.Components = c;
			return f;
		}
		private Field UB114()
		{
			Field f = new Field("PSRO/UR Approved Stay-Fm (88)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-14.1"));
			f.Components = c;
			return f;
		}
		private Field UB115()
		{
			Field f = new Field("PSRO/UR Approved Stay-To (89)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-15.1"));
			f.Components = c;
			return f;
		}
		private Field UB116()
		{
			Field f = new Field("Occurrence (28-32)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Occurence Code", "UB1-16.1"));
			c.Add(new Component("Occurence Date", "UB1-16.2"));
			f.Components = c;
			return f;
		}
		private Field UB117()
		{
			Field f = new Field("Occurrence Span (33)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "UB1-17.1"));
			c.Add(new Component("", "UB1-17.2"));
			c.Add(new Component("Name of Coding System", "UB1-17.3"));
			c.Add(new Component("Alternate Identifier", "UB1-17.4"));
			c.Add(new Component("Alternate Text", "UB1-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "UB1-17.6"));
			f.Components = c;
			return f;
		}
		private Field UB118()
		{
			Field f = new Field("Occur Span Start Date(33)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-18.1"));
			f.Components = c;
			return f;
		}
		private Field UB119()
		{
			Field f = new Field("Occur Span End Date (33)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-19.1"));
			f.Components = c;
			return f;
		}
		private Field UB120()
		{
			Field f = new Field("UB-82 Locator 2");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-20.1"));
			f.Components = c;
			return f;
		}
		private Field UB121()
		{
			Field f = new Field("UB-82 Locator 9");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-21.1"));
			f.Components = c;
			return f;
		}
		private Field UB122()
		{
			Field f = new Field("UB-82 Locator 27");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-22.1"));
			f.Components = c;
			return f;
		}
		private Field UB123()
		{
			Field f = new Field("UB-82 Locator 45");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "UB1-23.1"));
			f.Components = c;
			return f;
		}
	}
}
