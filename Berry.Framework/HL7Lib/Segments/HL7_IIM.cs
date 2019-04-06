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
/// IIM Class: Constructs an HL7 IIM Segment Object
/// </summary>
public class IIM
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public IIM()
		{
			Name = "IIM";
			Description = "Inventory Item Master";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(IIM1());
			fs.Add(IIM2());
			fs.Add(IIM3());
			fs.Add(IIM4());
			fs.Add(IIM5());
			fs.Add(IIM6());
			fs.Add(IIM7());
			fs.Add(IIM8());
			fs.Add(IIM9());
			fs.Add(IIM10());
			fs.Add(IIM11());
			fs.Add(IIM12());
			fs.Add(IIM13());
			fs.Add(IIM14());
			fs.Add(IIM15());
			Fields = fs;
		}
		private Field IIM1()
		{
			Field f = new Field("Primary Key Value - IIM");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IIM-1.1"));
			c.Add(new Component("", "IIM-1.2"));
			c.Add(new Component("Name of Coding System", "IIM-1.3"));
			c.Add(new Component("Alternate Identifier", "IIM-1.4"));
			c.Add(new Component("Alternate Text", "IIM-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "IIM-1.6"));
			c.Add(new Component("Coding System Version ID", "IIM-1.7"));
			c.Add(new Component("Alternate Coding System Version ID", "IIM-1.8"));
			c.Add(new Component("Original Text", "IIM-1.9"));
			f.Components = c;
			return f;
		}
		private Field IIM2()
		{
			Field f = new Field("Service Item Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IIM-2.1"));
			c.Add(new Component("", "IIM-2.2"));
			c.Add(new Component("Name of Coding System", "IIM-2.3"));
			c.Add(new Component("Alternate Identifier", "IIM-2.4"));
			c.Add(new Component("Alternate Text", "IIM-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "IIM-2.6"));
			c.Add(new Component("Coding System Version ID", "IIM-2.7"));
			c.Add(new Component("Alternate Coding System Version ID", "IIM-2.8"));
			c.Add(new Component("Original Text", "IIM-2.9"));
			f.Components = c;
			return f;
		}
		private Field IIM3()
		{
			Field f = new Field("Inventory Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IIM-3.1"));
			f.Components = c;
			return f;
		}
		private Field IIM4()
		{
			Field f = new Field("Inventory Expiration Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IIM-4.1"));
			c.Add(new Component("Degree of Precision", "IIM-4.2"));
			f.Components = c;
			return f;
		}
		private Field IIM5()
		{
			Field f = new Field("Inventory Manufacturer Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IIM-5.1"));
			c.Add(new Component("", "IIM-5.2"));
			c.Add(new Component("Name of Coding System", "IIM-5.3"));
			c.Add(new Component("Alternate Identifier", "IIM-5.4"));
			c.Add(new Component("Alternate Text", "IIM-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "IIM-5.6"));
			c.Add(new Component("Coding System Version ID", "IIM-5.7"));
			c.Add(new Component("Alternate Coding System Version ID", "IIM-5.8"));
			c.Add(new Component("Original Text", "IIM-5.9"));
			f.Components = c;
			return f;
		}
		private Field IIM6()
		{
			Field f = new Field("Inventory Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IIM-6.1"));
			c.Add(new Component("", "IIM-6.2"));
			c.Add(new Component("Name of Coding System", "IIM-6.3"));
			c.Add(new Component("Alternate Identifier", "IIM-6.4"));
			c.Add(new Component("Alternate Text", "IIM-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "IIM-6.6"));
			c.Add(new Component("Coding System Version ID", "IIM-6.7"));
			c.Add(new Component("Alternate Coding System Version ID", "IIM-6.8"));
			c.Add(new Component("Original Text", "IIM-6.9"));
			f.Components = c;
			return f;
		}
		private Field IIM7()
		{
			Field f = new Field("Inventory Received Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IIM-7.1"));
			c.Add(new Component("Degree of Precision", "IIM-7.2"));
			f.Components = c;
			return f;
		}
		private Field IIM8()
		{
			Field f = new Field("Inventory Received Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IIM-8.1"));
			f.Components = c;
			return f;
		}
		private Field IIM9()
		{
			Field f = new Field("Inventory Received Quantity Unit");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IIM-9.1"));
			c.Add(new Component("", "IIM-9.2"));
			c.Add(new Component("Name of Coding System", "IIM-9.3"));
			c.Add(new Component("Alternate Identifier", "IIM-9.4"));
			c.Add(new Component("Alternate Text", "IIM-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "IIM-9.6"));
			c.Add(new Component("Coding System Version ID", "IIM-9.7"));
			c.Add(new Component("Alternate Coding System Version ID", "IIM-9.8"));
			c.Add(new Component("Original Text", "IIM-9.9"));
			f.Components = c;
			return f;
		}
		private Field IIM10()
		{
			Field f = new Field("Inventory Received Item Cost");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "IIM-10.1"));
			c.Add(new Component("Denomination", "IIM-10.2"));
			f.Components = c;
			return f;
		}
		private Field IIM11()
		{
			Field f = new Field("Inventory On Hand Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IIM-11.1"));
			c.Add(new Component("Degree of Precision", "IIM-11.2"));
			f.Components = c;
			return f;
		}
		private Field IIM12()
		{
			Field f = new Field("Inventory On Hand Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IIM-12.1"));
			f.Components = c;
			return f;
		}
		private Field IIM13()
		{
			Field f = new Field("Inventory On Hand Quantity Unit");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IIM-13.1"));
			c.Add(new Component("", "IIM-13.2"));
			c.Add(new Component("Name of Coding System", "IIM-13.3"));
			c.Add(new Component("Alternate Identifier", "IIM-13.4"));
			c.Add(new Component("Alternate Text", "IIM-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "IIM-13.6"));
			c.Add(new Component("Coding System Version ID", "IIM-13.7"));
			c.Add(new Component("Alternate Coding System Version ID", "IIM-13.8"));
			c.Add(new Component("Original Text", "IIM-13.9"));
			f.Components = c;
			return f;
		}
		private Field IIM14()
		{
			Field f = new Field("Procedure Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IIM-14.1"));
			c.Add(new Component("", "IIM-14.2"));
			c.Add(new Component("Name of Coding System", "IIM-14.3"));
			c.Add(new Component("Alternate Identifier", "IIM-14.4"));
			c.Add(new Component("Alternate Text", "IIM-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "IIM-14.6"));
			f.Components = c;
			return f;
		}
		private Field IIM15()
		{
			Field f = new Field("Procedure Code Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IIM-15.1"));
			c.Add(new Component("", "IIM-15.2"));
			c.Add(new Component("Name of Coding System", "IIM-15.3"));
			c.Add(new Component("Alternate Identifier", "IIM-15.4"));
			c.Add(new Component("Alternate Text", "IIM-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "IIM-15.6"));
			f.Components = c;
			return f;
		}
	}
}
