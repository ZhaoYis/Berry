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
/// PDC Class: Constructs an HL7 PDC Segment Object
/// </summary>
public class PDC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PDC()
		{
			Name = "PDC";
			Description = "Product Detail Country";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PDC1());
			fs.Add(PDC2());
			fs.Add(PDC3());
			fs.Add(PDC4());
			fs.Add(PDC5());
			fs.Add(PDC6());
			fs.Add(PDC7());
			fs.Add(PDC8());
			fs.Add(PDC9());
			fs.Add(PDC10());
			fs.Add(PDC11());
			fs.Add(PDC12());
			fs.Add(PDC13());
			fs.Add(PDC14());
			fs.Add(PDC15());
			Fields = fs;
		}
		private Field PDC1()
		{
			Field f = new Field("Manufacturer/Distributor");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "PDC-1.1"));
			c.Add(new Component("Organization Name Type Code", "PDC-1.2"));
			c.Add(new Component("ID Number", "PDC-1.3"));
			c.Add(new Component("Check Digit", "PDC-1.4"));
			c.Add(new Component("Check Digit Scheme", "PDC-1.5"));
			c.Add(new Component("Assigning Authority", "PDC-1.6"));
			c.Add(new Component("Identifier Type Code", "PDC-1.7"));
			c.Add(new Component("Assigning Facility", "PDC-1.8"));
			c.Add(new Component("Name Respresentation Code", "PDC-1.9"));
			c.Add(new Component("Organization Identifier", "PDC-1.10"));
			f.Components = c;
			return f;
		}
		private Field PDC2()
		{
			Field f = new Field("Country");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PDC-2.1"));
			c.Add(new Component("", "PDC-2.2"));
			c.Add(new Component("Name of Coding System", "PDC-2.3"));
			c.Add(new Component("Alternate Identifier", "PDC-2.4"));
			c.Add(new Component("Alternate Text", "PDC-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "PDC-2.6"));
			f.Components = c;
			return f;
		}
		private Field PDC3()
		{
			Field f = new Field("Brand Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDC-3.1"));
			f.Components = c;
			return f;
		}
		private Field PDC4()
		{
			Field f = new Field("Device Family Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDC-4.1"));
			f.Components = c;
			return f;
		}
		private Field PDC5()
		{
			Field f = new Field("Generic Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PDC-5.1"));
			c.Add(new Component("", "PDC-5.2"));
			c.Add(new Component("Name of Coding System", "PDC-5.3"));
			c.Add(new Component("Alternate Identifier", "PDC-5.4"));
			c.Add(new Component("Alternate Text", "PDC-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "PDC-5.6"));
			f.Components = c;
			return f;
		}
		private Field PDC6()
		{
			Field f = new Field("Model Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDC-6.1"));
			f.Components = c;
			return f;
		}
		private Field PDC7()
		{
			Field f = new Field("Catalogue Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDC-7.1"));
			f.Components = c;
			return f;
		}
		private Field PDC8()
		{
			Field f = new Field("Other Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDC-8.1"));
			f.Components = c;
			return f;
		}
		private Field PDC9()
		{
			Field f = new Field("Product Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PDC-9.1"));
			c.Add(new Component("", "PDC-9.2"));
			c.Add(new Component("Name of Coding System", "PDC-9.3"));
			c.Add(new Component("Alternate Identifier", "PDC-9.4"));
			c.Add(new Component("Alternate Text", "PDC-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "PDC-9.6"));
			f.Components = c;
			return f;
		}
		private Field PDC10()
		{
			Field f = new Field("Marketing Basis");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDC-10.1"));
			f.Components = c;
			return f;
		}
		private Field PDC11()
		{
			Field f = new Field("Marketing Approval ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDC-11.1"));
			f.Components = c;
			return f;
		}
		private Field PDC12()
		{
			Field f = new Field("Labeled Shelf Life");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PDC-12.1"));
			c.Add(new Component("Units", "PDC-12.2"));
			f.Components = c;
			return f;
		}
		private Field PDC13()
		{
			Field f = new Field("Expected Shelf Life");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PDC-13.1"));
			c.Add(new Component("Units", "PDC-13.2"));
			f.Components = c;
			return f;
		}
		private Field PDC14()
		{
			Field f = new Field("Date First Marketed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PDC-14.1"));
			c.Add(new Component("Degree of Precision", "PDC-14.2"));
			f.Components = c;
			return f;
		}
		private Field PDC15()
		{
			Field f = new Field("Date Last Marketed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PDC-15.1"));
			c.Add(new Component("Degree of Precision", "PDC-15.2"));
			f.Components = c;
			return f;
		}
	}
}
