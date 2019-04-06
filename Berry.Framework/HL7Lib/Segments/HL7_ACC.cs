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
    /// ACC Class: Constructs an HL7 ACC Segment Object
    /// </summary>
	public class ACC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ACC()
		{
			Name = "ACC";
			Description = "Accident";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ACC1());
			fs.Add(ACC2());
			fs.Add(ACC3());
			fs.Add(ACC4());
			fs.Add(ACC5());
			fs.Add(ACC6());
			fs.Add(ACC7());
			fs.Add(ACC8());
			fs.Add(ACC9());
			fs.Add(ACC10());
			fs.Add(ACC11());
			Fields = fs;
		}
		private Field ACC1()
		{
			Field f = new Field("Accident Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ACC-1.1"));
			c.Add(new Component("Degree of Precision", "ACC-1.2"));
			f.Components = c;
			return f;
		}
		private Field ACC2()
		{
			Field f = new Field("Accident Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ACC-2.1"));
			c.Add(new Component("", "ACC-2.2"));
			c.Add(new Component("Name of Coding System", "ACC-2.3"));
			c.Add(new Component("Alternate Identifier", "ACC-2.4"));
			c.Add(new Component("Alternate Text", "ACC-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "ACC-2.6"));
			f.Components = c;
			return f;
		}
		private Field ACC3()
		{
			Field f = new Field("Accident Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ACC-3.1"));
			f.Components = c;
			return f;
		}
		private Field ACC4()
		{
			Field f = new Field("Auto Accident State");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ACC-4.1"));
			c.Add(new Component("", "ACC-4.2"));
			c.Add(new Component("Name of Coding System", "ACC-4.3"));
			c.Add(new Component("Alternate Identifier", "ACC-4.4"));
			c.Add(new Component("Alternate Text", "ACC-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "ACC-4.6"));
			f.Components = c;
			return f;
		}
		private Field ACC5()
		{
			Field f = new Field("Accident Job Related Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ACC-5.1"));
			f.Components = c;
			return f;
		}
		private Field ACC6()
		{
			Field f = new Field("Accident Death Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ACC-6.1"));
			f.Components = c;
			return f;
		}
		private Field ACC7()
		{
			Field f = new Field("Entered By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ACC-7.1"));
			c.Add(new Component("Family Name", "ACC-7.2"));
			c.Add(new Component("Given Name", "ACC-7.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ACC-7.4"));
			c.Add(new Component("Suffix", "ACC-7.5"));
			c.Add(new Component("Prefix", "ACC-7.6"));
			c.Add(new Component("Degree", "ACC-7.7"));
			c.Add(new Component("Source Table", "ACC-7.8"));
			c.Add(new Component("Assigning Authority", "ACC-7.9"));
			c.Add(new Component("Name Type Code", "ACC-7.10"));
			c.Add(new Component("Identifier Check Digit", "ACC-7.11"));
			c.Add(new Component("Check Digit Scheme", "ACC-7.12"));
			c.Add(new Component("Identifier Type Code", "ACC-7.13"));
			c.Add(new Component("Assigning Facility", "ACC-7.14"));
			c.Add(new Component("Name Respresentation Code", "ACC-7.15"));
			c.Add(new Component("Name Context", "ACC-7.16"));
			c.Add(new Component("Name Validity Range", "ACC-7.17"));
			c.Add(new Component("Name Assembly Order", "ACC-7.18"));
			c.Add(new Component("Effective Date", "ACC-7.19"));
			c.Add(new Component("Expiration Date", "ACC-7.20"));
			c.Add(new Component("Professional Suffix", "ACC-7.21"));
			c.Add(new Component("Assigning Jurisdiction", "ACC-7.22"));
			c.Add(new Component("Assigning Agency or Department", "ACC-7.23"));
			f.Components = c;
			return f;
		}
		private Field ACC8()
		{
			Field f = new Field("Accident Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ACC-8.1"));
			f.Components = c;
			return f;
		}
		private Field ACC9()
		{
			Field f = new Field("Brought In By");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ACC-9.1"));
			f.Components = c;
			return f;
		}
		private Field ACC10()
		{
			Field f = new Field("Police Notified Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ACC-10.1"));
			f.Components = c;
			return f;
		}
		private Field ACC11()
		{
			Field f = new Field("Accident Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "ACC-11.1"));
			c.Add(new Component("Other Designation", "ACC-11.2"));
			c.Add(new Component("City", "ACC-11.3"));
			c.Add(new Component("State or Province", "ACC-11.4"));
			c.Add(new Component("Zip or Postal Code", "ACC-11.5"));
			c.Add(new Component("Country", "ACC-11.6"));
			c.Add(new Component("Address Type", "ACC-11.7"));
			c.Add(new Component("Other Geographic Designation", "ACC-11.8"));
			c.Add(new Component("Country Parish Code", "ACC-11.9"));
			c.Add(new Component("Census Tract", "ACC-11.10"));
			c.Add(new Component("Address Representation Code", "ACC-11.11"));
			c.Add(new Component("Address Validity Range", "ACC-11.12"));
			c.Add(new Component("Effective Date", "ACC-11.13"));
			c.Add(new Component("Expiration Date", "ACC-11.14"));
			f.Components = c;
			return f;
		}
	}
}
