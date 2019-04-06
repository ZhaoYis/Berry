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
/// PRC Class: Constructs an HL7 PRC Segment Object
/// </summary>
public class PRC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PRC()
		{
			Name = "PRC";
			Description = "Pricing";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PRC1());
			fs.Add(PRC2());
			fs.Add(PRC3());
			fs.Add(PRC4());
			fs.Add(PRC5());
			fs.Add(PRC6());
			fs.Add(PRC7());
			fs.Add(PRC8());
			fs.Add(PRC9());
			fs.Add(PRC10());
			fs.Add(PRC11());
			fs.Add(PRC12());
			fs.Add(PRC13());
			fs.Add(PRC14());
			fs.Add(PRC15());
			fs.Add(PRC16());
			fs.Add(PRC17());
			fs.Add(PRC18());
			Fields = fs;
		}
		private Field PRC1()
		{
			Field f = new Field("Primary Key Value - PRC");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRC-1.1"));
			c.Add(new Component("", "PRC-1.2"));
			c.Add(new Component("Name of Coding System", "PRC-1.3"));
			c.Add(new Component("Alternate Identifier", "PRC-1.4"));
			c.Add(new Component("Alternate Text", "PRC-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRC-1.6"));
			f.Components = c;
			return f;
		}
		private Field PRC2()
		{
			Field f = new Field("Facility ID - PRC");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRC-2.1"));
			c.Add(new Component("", "PRC-2.2"));
			c.Add(new Component("Name of Coding System", "PRC-2.3"));
			c.Add(new Component("Alternate Identifier", "PRC-2.4"));
			c.Add(new Component("Alternate Text", "PRC-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRC-2.6"));
			f.Components = c;
			return f;
		}
		private Field PRC3()
		{
			Field f = new Field("Department");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRC-3.1"));
			c.Add(new Component("", "PRC-3.2"));
			c.Add(new Component("Name of Coding System", "PRC-3.3"));
			c.Add(new Component("Alternate Identifier", "PRC-3.4"));
			c.Add(new Component("Alternate Text", "PRC-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRC-3.6"));
			f.Components = c;
			return f;
		}
		private Field PRC4()
		{
			Field f = new Field("Valid Patient Classes");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRC-4.1"));
			f.Components = c;
			return f;
		}
		private Field PRC5()
		{
			Field f = new Field("Price");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "PRC-5.1"));
			c.Add(new Component("Price Type", "PRC-5.2"));
			c.Add(new Component("From Value", "PRC-5.3"));
			c.Add(new Component("To Value", "PRC-5.4"));
			c.Add(new Component("Range Units", "PRC-5.5"));
			c.Add(new Component("Range Type", "PRC-5.6"));
			f.Components = c;
			return f;
		}
		private Field PRC6()
		{
			Field f = new Field("Formula");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRC-6.1"));
			f.Components = c;
			return f;
		}
		private Field PRC7()
		{
			Field f = new Field("Minimum Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRC-7.1"));
			f.Components = c;
			return f;
		}
		private Field PRC8()
		{
			Field f = new Field("Maximum Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRC-8.1"));
			f.Components = c;
			return f;
		}
		private Field PRC9()
		{
			Field f = new Field("Minimum Price");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PRC-9.1"));
			c.Add(new Component("Denomination", "PRC-9.2"));
			f.Components = c;
			return f;
		}
		private Field PRC10()
		{
			Field f = new Field("Maximum Price");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PRC-10.1"));
			c.Add(new Component("Denomination", "PRC-10.2"));
			f.Components = c;
			return f;
		}
		private Field PRC11()
		{
			Field f = new Field("Effective Start Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRC-11.1"));
			c.Add(new Component("Degree of Precision", "PRC-11.2"));
			f.Components = c;
			return f;
		}
		private Field PRC12()
		{
			Field f = new Field("Effective End Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRC-12.1"));
			c.Add(new Component("Degree of Precision", "PRC-12.2"));
			f.Components = c;
			return f;
		}
		private Field PRC13()
		{
			Field f = new Field("Price Override Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRC-13.1"));
			f.Components = c;
			return f;
		}
		private Field PRC14()
		{
			Field f = new Field("Billing Category");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRC-14.1"));
			c.Add(new Component("", "PRC-14.2"));
			c.Add(new Component("Name of Coding System", "PRC-14.3"));
			c.Add(new Component("Alternate Identifier", "PRC-14.4"));
			c.Add(new Component("Alternate Text", "PRC-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRC-14.6"));
			f.Components = c;
			return f;
		}
		private Field PRC15()
		{
			Field f = new Field("Chargeable Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRC-15.1"));
			f.Components = c;
			return f;
		}
		private Field PRC16()
		{
			Field f = new Field("Active/Inactive Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRC-16.1"));
			f.Components = c;
			return f;
		}
		private Field PRC17()
		{
			Field f = new Field("Cost");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PRC-17.1"));
			c.Add(new Component("Denomination", "PRC-17.2"));
			f.Components = c;
			return f;
		}
		private Field PRC18()
		{
			Field f = new Field("Charge On Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRC-18.1"));
			f.Components = c;
			return f;
		}
	}
}
