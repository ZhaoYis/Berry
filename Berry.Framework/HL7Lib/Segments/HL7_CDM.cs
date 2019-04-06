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
/// CDM Class: Constructs an HL7 CDM Segment Object
/// </summary>
public class CDM
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CDM()
		{
			Name = "CDM";
			Description = "Charge Description Master";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CDM1());
			fs.Add(CDM2());
			fs.Add(CDM3());
			fs.Add(CDM4());
			fs.Add(CDM5());
			fs.Add(CDM6());
			fs.Add(CDM7());
			fs.Add(CDM8());
			fs.Add(CDM9());
			fs.Add(CDM10());
			fs.Add(CDM11());
			fs.Add(CDM12());
			fs.Add(CDM13());
			Fields = fs;
		}
		private Field CDM1()
		{
			Field f = new Field("Primary Key Value - CDM");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CDM-1.1"));
			c.Add(new Component("", "CDM-1.2"));
			c.Add(new Component("Name of Coding System", "CDM-1.3"));
			c.Add(new Component("Alternate Identifier", "CDM-1.4"));
			c.Add(new Component("Alternate Text", "CDM-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "CDM-1.6"));
			f.Components = c;
			return f;
		}
		private Field CDM2()
		{
			Field f = new Field("Charge Code Alias");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CDM-2.1"));
			c.Add(new Component("", "CDM-2.2"));
			c.Add(new Component("Name of Coding System", "CDM-2.3"));
			c.Add(new Component("Alternate Identifier", "CDM-2.4"));
			c.Add(new Component("Alternate Text", "CDM-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "CDM-2.6"));
			f.Components = c;
			return f;
		}
		private Field CDM3()
		{
			Field f = new Field("Charge Description Short");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CDM-3.1"));
			f.Components = c;
			return f;
		}
		private Field CDM4()
		{
			Field f = new Field("Charge Description Long");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CDM-4.1"));
			f.Components = c;
			return f;
		}
		private Field CDM5()
		{
			Field f = new Field("Description Override Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CDM-5.1"));
			f.Components = c;
			return f;
		}
		private Field CDM6()
		{
			Field f = new Field("Exploding Charges");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CDM-6.1"));
			c.Add(new Component("", "CDM-6.2"));
			c.Add(new Component("Name of Coding System", "CDM-6.3"));
			c.Add(new Component("Alternate Identifier", "CDM-6.4"));
			c.Add(new Component("Alternate Text", "CDM-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "CDM-6.6"));
			f.Components = c;
			return f;
		}
		private Field CDM7()
		{
			Field f = new Field("Procedure Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CDM-7.1"));
			c.Add(new Component("", "CDM-7.2"));
			c.Add(new Component("Name of Coding System", "CDM-7.3"));
			c.Add(new Component("Alternate Identifier", "CDM-7.4"));
			c.Add(new Component("Alternate Text", "CDM-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "CDM-7.6"));
			f.Components = c;
			return f;
		}
		private Field CDM8()
		{
			Field f = new Field("Active/Inactive Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CDM-8.1"));
			f.Components = c;
			return f;
		}
		private Field CDM9()
		{
			Field f = new Field("Inventory Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CDM-9.1"));
			c.Add(new Component("", "CDM-9.2"));
			c.Add(new Component("Name of Coding System", "CDM-9.3"));
			c.Add(new Component("Alternate Identifier", "CDM-9.4"));
			c.Add(new Component("Alternate Text", "CDM-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "CDM-9.6"));
			f.Components = c;
			return f;
		}
		private Field CDM10()
		{
			Field f = new Field("Resource Load");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CDM-10.1"));
			f.Components = c;
			return f;
		}
		private Field CDM11()
		{
			Field f = new Field("Contract Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CDM-11.1"));
			c.Add(new Component("Check Digit", "CDM-11.2"));
			c.Add(new Component("Check Digit Scheme", "CDM-11.3"));
			c.Add(new Component("Assigning Authority", "CDM-11.4"));
			c.Add(new Component("Identifier Type Code", "CDM-11.5"));
			c.Add(new Component("Assigning Facility", "CDM-11.6"));
			c.Add(new Component("Effective Date", "CDM-11.7"));
			c.Add(new Component("Expiration Date", "CDM-11.8"));
			c.Add(new Component("Assigning Jurisdiction", "CDM-11.9"));
			c.Add(new Component("Assigning Agency or Department", "CDM-11.10"));
			f.Components = c;
			return f;
		}
		private Field CDM12()
		{
			Field f = new Field("Contract Organization");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "CDM-12.1"));
			c.Add(new Component("Organization Name Type Code", "CDM-12.2"));
			c.Add(new Component("ID Number", "CDM-12.3"));
			c.Add(new Component("Check Digit", "CDM-12.4"));
			c.Add(new Component("Check Digit Scheme", "CDM-12.5"));
			c.Add(new Component("Assigning Authority", "CDM-12.6"));
			c.Add(new Component("Identifier Type Code", "CDM-12.7"));
			c.Add(new Component("Assigning Facility", "CDM-12.8"));
			c.Add(new Component("Name Respresentation Code", "CDM-12.9"));
			c.Add(new Component("Organization Identifier", "CDM-12.10"));
			f.Components = c;
			return f;
		}
		private Field CDM13()
		{
			Field f = new Field("Room Fee Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CDM-13.1"));
			f.Components = c;
			return f;
		}
	}
}
