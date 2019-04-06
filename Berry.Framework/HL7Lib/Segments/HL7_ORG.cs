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
/// ORG Class: Constructs an HL7 ORG Segment Object
/// </summary>
public class ORG
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ORG()
		{
			Name = "ORG";
			Description = "Practitioner Organization Unit";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ORG1());
			fs.Add(ORG2());
			fs.Add(ORG3());
			fs.Add(ORG4());
			fs.Add(ORG5());
			fs.Add(ORG6());
			fs.Add(ORG7());
			fs.Add(ORG8());
			fs.Add(ORG9());
			fs.Add(ORG10());
			fs.Add(ORG11());
			fs.Add(ORG12());
			Fields = fs;
		}
		private Field ORG1()
		{
			Field f = new Field("Set ID _ ORG");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "ORG-1.1"));
			f.Components = c;
			return f;
		}
		private Field ORG2()
		{
			Field f = new Field("Organization Unit Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORG-2.1"));
			c.Add(new Component("", "ORG-2.2"));
			c.Add(new Component("Name of Coding System", "ORG-2.3"));
			c.Add(new Component("Alternate Identifier", "ORG-2.4"));
			c.Add(new Component("Alternate Text", "ORG-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORG-2.6"));
			f.Components = c;
			return f;
		}
		private Field ORG3()
		{
			Field f = new Field("Organization Unit Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORG-3.1"));
			c.Add(new Component("", "ORG-3.2"));
			c.Add(new Component("Name of Coding System", "ORG-3.3"));
			c.Add(new Component("Alternate Identifier", "ORG-3.4"));
			c.Add(new Component("Alternate Text", "ORG-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORG-3.6"));
			f.Components = c;
			return f;
		}
		private Field ORG4()
		{
			Field f = new Field("Primary Org Unit Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ORG-4.1"));
			f.Components = c;
			return f;
		}
		private Field ORG5()
		{
			Field f = new Field("Practitioner Org Unit Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ORG-5.1"));
			c.Add(new Component("Check Digit", "ORG-5.2"));
			c.Add(new Component("Check Digit Scheme", "ORG-5.3"));
			c.Add(new Component("Assigning Authority", "ORG-5.4"));
			c.Add(new Component("Identifier Type Code", "ORG-5.5"));
			c.Add(new Component("Assigning Facility", "ORG-5.6"));
			c.Add(new Component("Effective Date", "ORG-5.7"));
			c.Add(new Component("Expiration Date", "ORG-5.8"));
			c.Add(new Component("Assigning Jurisdiction", "ORG-5.9"));
			c.Add(new Component("Assigning Agency or Department", "ORG-5.10"));
			f.Components = c;
			return f;
		}
		private Field ORG6()
		{
			Field f = new Field("Health Care Provider Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORG-6.1"));
			c.Add(new Component("", "ORG-6.2"));
			c.Add(new Component("Name of Coding System", "ORG-6.3"));
			c.Add(new Component("Alternate Identifier", "ORG-6.4"));
			c.Add(new Component("Alternate Text", "ORG-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORG-6.6"));
			f.Components = c;
			return f;
		}
		private Field ORG7()
		{
			Field f = new Field("Health Care Provider Classification Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORG-7.1"));
			c.Add(new Component("", "ORG-7.2"));
			c.Add(new Component("Name of Coding System", "ORG-7.3"));
			c.Add(new Component("Alternate Identifier", "ORG-7.4"));
			c.Add(new Component("Alternate Text", "ORG-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORG-7.6"));
			f.Components = c;
			return f;
		}
		private Field ORG8()
		{
			Field f = new Field("Health Care Provider Area of Specialization Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORG-8.1"));
			c.Add(new Component("", "ORG-8.2"));
			c.Add(new Component("Name of Coding System", "ORG-8.3"));
			c.Add(new Component("Alternate Identifier", "ORG-8.4"));
			c.Add(new Component("Alternate Text", "ORG-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORG-8.6"));
			f.Components = c;
			return f;
		}
		private Field ORG9()
		{
			Field f = new Field("Effective Date Range");
			List<Component> c = new List<Component>();
			c.Add(new Component("Range Start Date/Time", "ORG-9.1"));
			c.Add(new Component("Range End Date/Time", "ORG-9.2"));
			f.Components = c;
			return f;
		}
		private Field ORG10()
		{
			Field f = new Field("Employment Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORG-10.1"));
			c.Add(new Component("", "ORG-10.2"));
			c.Add(new Component("Name of Coding System", "ORG-10.3"));
			c.Add(new Component("Alternate Identifier", "ORG-10.4"));
			c.Add(new Component("Alternate Text", "ORG-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORG-10.6"));
			f.Components = c;
			return f;
		}
		private Field ORG11()
		{
			Field f = new Field("Board Approval Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ORG-11.1"));
			f.Components = c;
			return f;
		}
		private Field ORG12()
		{
			Field f = new Field("Primary Care Physician Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ORG-12.1"));
			f.Components = c;
			return f;
		}
	}
}
