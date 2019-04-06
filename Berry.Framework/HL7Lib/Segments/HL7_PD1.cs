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
/// PD1 Class: Constructs an HL7 PD1 Segment Object
/// </summary>
public class PD1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PD1()
		{
			Name = "PD1";
			Description = "Patient Additional Demographic";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PD11());
			fs.Add(PD12());
			fs.Add(PD13());
			fs.Add(PD14());
			fs.Add(PD15());
			fs.Add(PD16());
			fs.Add(PD17());
			fs.Add(PD18());
			fs.Add(PD19());
			fs.Add(PD110());
			fs.Add(PD111());
			fs.Add(PD112());
			fs.Add(PD113());
			fs.Add(PD114());
			fs.Add(PD115());
			fs.Add(PD116());
			fs.Add(PD117());
			fs.Add(PD118());
			fs.Add(PD119());
			fs.Add(PD120());
			fs.Add(PD121());
			Fields = fs;
		}
		private Field PD11()
		{
			Field f = new Field("Living Dependency");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-1.1"));
			f.Components = c;
			return f;
		}
		private Field PD12()
		{
			Field f = new Field("Living Arrangement");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-2.1"));
			f.Components = c;
			return f;
		}
		private Field PD13()
		{
			Field f = new Field("Patient Primary Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "PD1-3.1"));
			c.Add(new Component("Organization Name Type Code", "PD1-3.2"));
			c.Add(new Component("ID Number", "PD1-3.3"));
			c.Add(new Component("Check Digit", "PD1-3.4"));
			c.Add(new Component("Check Digit Scheme", "PD1-3.5"));
			c.Add(new Component("Assigning Authority", "PD1-3.6"));
			c.Add(new Component("Identifier Type Code", "PD1-3.7"));
			c.Add(new Component("Assigning Facility", "PD1-3.8"));
			c.Add(new Component("Name Respresentation Code", "PD1-3.9"));
			c.Add(new Component("Organization Identifier", "PD1-3.10"));
			f.Components = c;
			return f;
		}
		private Field PD14()
		{
			Field f = new Field("Patient Primary Care Provider Name & ID No.");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PD1-4.1"));
			c.Add(new Component("Family Name", "PD1-4.2"));
			c.Add(new Component("Given Name", "PD1-4.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PD1-4.4"));
			c.Add(new Component("Suffix", "PD1-4.5"));
			c.Add(new Component("Prefix", "PD1-4.6"));
			c.Add(new Component("Degree", "PD1-4.7"));
			c.Add(new Component("Source Table", "PD1-4.8"));
			c.Add(new Component("Assigning Authority", "PD1-4.9"));
			c.Add(new Component("Name Type Code", "PD1-4.10"));
			c.Add(new Component("Identifier Check Digit", "PD1-4.11"));
			c.Add(new Component("Check Digit Scheme", "PD1-4.12"));
			c.Add(new Component("Identifier Type Code", "PD1-4.13"));
			c.Add(new Component("Assigning Facility", "PD1-4.14"));
			c.Add(new Component("Name Respresentation Code", "PD1-4.15"));
			c.Add(new Component("Name Context", "PD1-4.16"));
			c.Add(new Component("Name Validity Range", "PD1-4.17"));
			c.Add(new Component("Name Assembly Order", "PD1-4.18"));
			c.Add(new Component("Effective Date", "PD1-4.19"));
			c.Add(new Component("Expiration Date", "PD1-4.20"));
			c.Add(new Component("Professional Suffix", "PD1-4.21"));
			c.Add(new Component("Assigning Jurisdiction", "PD1-4.22"));
			c.Add(new Component("Assigning Agency or Department", "PD1-4.23"));
			f.Components = c;
			return f;
		}
		private Field PD15()
		{
			Field f = new Field("Student Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-5.1"));
			f.Components = c;
			return f;
		}
		private Field PD16()
		{
			Field f = new Field("Handicap");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-6.1"));
			f.Components = c;
			return f;
		}
		private Field PD17()
		{
			Field f = new Field("Living Will Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-7.1"));
			f.Components = c;
			return f;
		}
		private Field PD18()
		{
			Field f = new Field("Organ Donor Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-8.1"));
			f.Components = c;
			return f;
		}
		private Field PD19()
		{
			Field f = new Field("Separate Bill");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-9.1"));
			f.Components = c;
			return f;
		}
		private Field PD110()
		{
			Field f = new Field("Duplicate Patient");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PD1-10.1"));
			c.Add(new Component("Check Digit", "PD1-10.2"));
			c.Add(new Component("Check Digit Scheme", "PD1-10.3"));
			c.Add(new Component("Assigning Authority", "PD1-10.4"));
			c.Add(new Component("Identifier Type Code", "PD1-10.5"));
			c.Add(new Component("Assigning Facility", "PD1-10.6"));
			c.Add(new Component("Effective Date", "PD1-10.7"));
			c.Add(new Component("Expiration Date", "PD1-10.8"));
			c.Add(new Component("Assigning Jurisdiction", "PD1-10.9"));
			c.Add(new Component("Assigning Agency or Department", "PD1-10.10"));
			f.Components = c;
			return f;
		}
		private Field PD111()
		{
			Field f = new Field("Publicity Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PD1-11.1"));
			c.Add(new Component("", "PD1-11.2"));
			c.Add(new Component("Name of Coding System", "PD1-11.3"));
			c.Add(new Component("Alternate Identifier", "PD1-11.4"));
			c.Add(new Component("Alternate Text", "PD1-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "PD1-11.6"));
			f.Components = c;
			return f;
		}
		private Field PD112()
		{
			Field f = new Field("Protection Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-12.1"));
			f.Components = c;
			return f;
		}
		private Field PD113()
		{
			Field f = new Field("Protection Indicator Effective Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-13.1"));
			f.Components = c;
			return f;
		}
		private Field PD114()
		{
			Field f = new Field("Place of Worship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "PD1-14.1"));
			c.Add(new Component("Organization Name Type Code", "PD1-14.2"));
			c.Add(new Component("ID Number", "PD1-14.3"));
			c.Add(new Component("Check Digit", "PD1-14.4"));
			c.Add(new Component("Check Digit Scheme", "PD1-14.5"));
			c.Add(new Component("Assigning Authority", "PD1-14.6"));
			c.Add(new Component("Identifier Type Code", "PD1-14.7"));
			c.Add(new Component("Assigning Facility", "PD1-14.8"));
			c.Add(new Component("Name Respresentation Code", "PD1-14.9"));
			c.Add(new Component("Organization Identifier", "PD1-14.10"));
			f.Components = c;
			return f;
		}
		private Field PD115()
		{
			Field f = new Field("Advance Directive Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PD1-15.1"));
			c.Add(new Component("", "PD1-15.2"));
			c.Add(new Component("Name of Coding System", "PD1-15.3"));
			c.Add(new Component("Alternate Identifier", "PD1-15.4"));
			c.Add(new Component("Alternate Text", "PD1-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "PD1-15.6"));
			f.Components = c;
			return f;
		}
		private Field PD116()
		{
			Field f = new Field("Immunization Registry Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-16.1"));
			f.Components = c;
			return f;
		}
		private Field PD117()
		{
			Field f = new Field("Immunization Registry Status Effective Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-17.1"));
			f.Components = c;
			return f;
		}
		private Field PD118()
		{
			Field f = new Field("Publicity Code Effective Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-18.1"));
			f.Components = c;
			return f;
		}
		private Field PD119()
		{
			Field f = new Field("Military Branch");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-19.1"));
			f.Components = c;
			return f;
		}
		private Field PD120()
		{
			Field f = new Field("Military Rank/Grade");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-20.1"));
			f.Components = c;
			return f;
		}
		private Field PD121()
		{
			Field f = new Field("Military Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PD1-21.1"));
			f.Components = c;
			return f;
		}
	}
}
