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
/// INV Class: Constructs an HL7 INV Segment Object
/// </summary>
public class INV
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public INV()
		{
			Name = "INV";
			Description = "Inventory Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(INV1());
			fs.Add(INV2());
			fs.Add(INV3());
			fs.Add(INV4());
			fs.Add(INV5());
			fs.Add(INV6());
			fs.Add(INV7());
			fs.Add(INV8());
			fs.Add(INV9());
			fs.Add(INV10());
			fs.Add(INV11());
			fs.Add(INV12());
			fs.Add(INV13());
			fs.Add(INV14());
			fs.Add(INV15());
			fs.Add(INV16());
			fs.Add(INV17());
			fs.Add(INV18());
			fs.Add(INV19());
			fs.Add(INV20());
			Fields = fs;
		}
		private Field INV1()
		{
			Field f = new Field("Substance Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-1.1"));
			c.Add(new Component("", "INV-1.2"));
			c.Add(new Component("Name of Coding System", "INV-1.3"));
			c.Add(new Component("Alternate Identifier", "INV-1.4"));
			c.Add(new Component("Alternate Text", "INV-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-1.6"));
			f.Components = c;
			return f;
		}
		private Field INV2()
		{
			Field f = new Field("Substance Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-2.1"));
			c.Add(new Component("", "INV-2.2"));
			c.Add(new Component("Name of Coding System", "INV-2.3"));
			c.Add(new Component("Alternate Identifier", "INV-2.4"));
			c.Add(new Component("Alternate Text", "INV-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-2.6"));
			f.Components = c;
			return f;
		}
		private Field INV3()
		{
			Field f = new Field("Substance Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-3.1"));
			c.Add(new Component("", "INV-3.2"));
			c.Add(new Component("Name of Coding System", "INV-3.3"));
			c.Add(new Component("Alternate Identifier", "INV-3.4"));
			c.Add(new Component("Alternate Text", "INV-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-3.6"));
			f.Components = c;
			return f;
		}
		private Field INV4()
		{
			Field f = new Field("Inventory Container Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-4.1"));
			c.Add(new Component("", "INV-4.2"));
			c.Add(new Component("Name of Coding System", "INV-4.3"));
			c.Add(new Component("Alternate Identifier", "INV-4.4"));
			c.Add(new Component("Alternate Text", "INV-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-4.6"));
			f.Components = c;
			return f;
		}
		private Field INV5()
		{
			Field f = new Field("Container Carrier Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-5.1"));
			c.Add(new Component("", "INV-5.2"));
			c.Add(new Component("Name of Coding System", "INV-5.3"));
			c.Add(new Component("Alternate Identifier", "INV-5.4"));
			c.Add(new Component("Alternate Text", "INV-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-5.6"));
			f.Components = c;
			return f;
		}
		private Field INV6()
		{
			Field f = new Field("Position on Carrier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-6.1"));
			c.Add(new Component("", "INV-6.2"));
			c.Add(new Component("Name of Coding System", "INV-6.3"));
			c.Add(new Component("Alternate Identifier", "INV-6.4"));
			c.Add(new Component("Alternate Text", "INV-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-6.6"));
			f.Components = c;
			return f;
		}
		private Field INV7()
		{
			Field f = new Field("Initial Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "INV-7.1"));
			f.Components = c;
			return f;
		}
		private Field INV8()
		{
			Field f = new Field("Current Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "INV-8.1"));
			f.Components = c;
			return f;
		}
		private Field INV9()
		{
			Field f = new Field("Available Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "INV-9.1"));
			f.Components = c;
			return f;
		}
		private Field INV10()
		{
			Field f = new Field("Consumption Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "INV-10.1"));
			f.Components = c;
			return f;
		}
		private Field INV11()
		{
			Field f = new Field("Quantity Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-11.1"));
			c.Add(new Component("", "INV-11.2"));
			c.Add(new Component("Name of Coding System", "INV-11.3"));
			c.Add(new Component("Alternate Identifier", "INV-11.4"));
			c.Add(new Component("Alternate Text", "INV-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-11.6"));
			f.Components = c;
			return f;
		}
		private Field INV12()
		{
			Field f = new Field("Expiration Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "INV-12.1"));
			c.Add(new Component("Degree of Precision", "INV-12.2"));
			f.Components = c;
			return f;
		}
		private Field INV13()
		{
			Field f = new Field("First Used Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "INV-13.1"));
			c.Add(new Component("Degree of Precision", "INV-13.2"));
			f.Components = c;
			return f;
		}
		private Field INV14()
		{
			Field f = new Field("On Board Stability Duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "INV-14.1"));
			c.Add(new Component("Interval", "INV-14.2"));
			c.Add(new Component("Duration", "INV-14.3"));
			c.Add(new Component("Start Date/Time", "INV-14.4"));
			c.Add(new Component("End Date Time", "INV-14.5"));
			c.Add(new Component("Priority", "INV-14.6"));
			c.Add(new Component("Condition", "INV-14.7"));
			c.Add(new Component("", "INV-14.8"));
			c.Add(new Component("Conjunction", "INV-14.9"));
			c.Add(new Component("Order Sequencing", "INV-14.10"));
			c.Add(new Component("Occurrence Duration", "INV-14.11"));
			c.Add(new Component("Total Occurrences", "INV-14.12"));
			f.Components = c;
			return f;
		}
		private Field INV15()
		{
			Field f = new Field("Test/Fluid Identifier(s)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-15.1"));
			c.Add(new Component("", "INV-15.2"));
			c.Add(new Component("Name of Coding System", "INV-15.3"));
			c.Add(new Component("Alternate Identifier", "INV-15.4"));
			c.Add(new Component("Alternate Text", "INV-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-15.6"));
			f.Components = c;
			return f;
		}
		private Field INV16()
		{
			Field f = new Field("Manufacturer Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "INV-16.1"));
			f.Components = c;
			return f;
		}
		private Field INV17()
		{
			Field f = new Field("Manufacturer Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-17.1"));
			c.Add(new Component("", "INV-17.2"));
			c.Add(new Component("Name of Coding System", "INV-17.3"));
			c.Add(new Component("Alternate Identifier", "INV-17.4"));
			c.Add(new Component("Alternate Text", "INV-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-17.6"));
			f.Components = c;
			return f;
		}
		private Field INV18()
		{
			Field f = new Field("Supplier Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "INV-18.1"));
			c.Add(new Component("", "INV-18.2"));
			c.Add(new Component("Name of Coding System", "INV-18.3"));
			c.Add(new Component("Alternate Identifier", "INV-18.4"));
			c.Add(new Component("Alternate Text", "INV-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "INV-18.6"));
			f.Components = c;
			return f;
		}
		private Field INV19()
		{
			Field f = new Field("On Board Stability Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "INV-19.1"));
			c.Add(new Component("Units", "INV-19.2"));
			f.Components = c;
			return f;
		}
		private Field INV20()
		{
			Field f = new Field("Target Value");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "INV-20.1"));
			c.Add(new Component("Units", "INV-20.2"));
			f.Components = c;
			return f;
		}
	}
}
