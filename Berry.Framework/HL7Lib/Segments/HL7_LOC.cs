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
/// LOC Class: Constructs an HL7 LOC Segment Object
/// </summary>
public class LOC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public LOC()
		{
			Name = "LOC";
			Description = "Location Identification";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(LOC1());
			fs.Add(LOC2());
			fs.Add(LOC3());
			fs.Add(LOC4());
			fs.Add(LOC5());
			fs.Add(LOC6());
			fs.Add(LOC7());
			fs.Add(LOC8());
			fs.Add(LOC9());
			Fields = fs;
		}
		private Field LOC1()
		{
			Field f = new Field("Primary Key Value - LOC");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "LOC-1.1"));
			c.Add(new Component("Room", "LOC-1.2"));
			c.Add(new Component("Bed", "LOC-1.3"));
			c.Add(new Component("Facility", "LOC-1.4"));
			c.Add(new Component("Location Status", "LOC-1.5"));
			c.Add(new Component("Person Location Type", "LOC-1.6"));
			c.Add(new Component("Building", "LOC-1.7"));
			c.Add(new Component("Floor Number", "LOC-1.8"));
			c.Add(new Component("Location Description", "LOC-1.9"));
			c.Add(new Component("Comprehensive Location Identifier", "LOC-1.10"));
			c.Add(new Component("Assigning Authority for Location", "LOC-1.11"));
			f.Components = c;
			return f;
		}
		private Field LOC2()
		{
			Field f = new Field("Location Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LOC-2.1"));
			f.Components = c;
			return f;
		}
		private Field LOC3()
		{
			Field f = new Field("Location Type - LOC");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LOC-3.1"));
			f.Components = c;
			return f;
		}
		private Field LOC4()
		{
			Field f = new Field("Organization Name - LOC");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "LOC-4.1"));
			c.Add(new Component("Organization Name Type Code", "LOC-4.2"));
			c.Add(new Component("ID Number", "LOC-4.3"));
			c.Add(new Component("Check Digit", "LOC-4.4"));
			c.Add(new Component("Check Digit Scheme", "LOC-4.5"));
			c.Add(new Component("Assigning Authority", "LOC-4.6"));
			c.Add(new Component("Identifier Type Code", "LOC-4.7"));
			c.Add(new Component("Assigning Facility", "LOC-4.8"));
			c.Add(new Component("Name Respresentation Code", "LOC-4.9"));
			c.Add(new Component("Organization Identifier", "LOC-4.10"));
			f.Components = c;
			return f;
		}
		private Field LOC5()
		{
			Field f = new Field("Location Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "LOC-5.1"));
			c.Add(new Component("Other Designation", "LOC-5.2"));
			c.Add(new Component("City", "LOC-5.3"));
			c.Add(new Component("State or Province", "LOC-5.4"));
			c.Add(new Component("Zip or Postal Code", "LOC-5.5"));
			c.Add(new Component("Country", "LOC-5.6"));
			c.Add(new Component("Address Type", "LOC-5.7"));
			c.Add(new Component("Other Geographic Designation", "LOC-5.8"));
			c.Add(new Component("Country Parish Code", "LOC-5.9"));
			c.Add(new Component("Census Tract", "LOC-5.10"));
			c.Add(new Component("Address Representation Code", "LOC-5.11"));
			c.Add(new Component("Address Validity Range", "LOC-5.12"));
			c.Add(new Component("Effective Date", "LOC-5.13"));
			c.Add(new Component("Expiration Date", "LOC-5.14"));
			f.Components = c;
			return f;
		}
		private Field LOC6()
		{
			Field f = new Field("Location Phone");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "LOC-6.1"));
			c.Add(new Component("Tele-Communication Use Code", "LOC-6.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "LOC-6.3"));
			c.Add(new Component("Email Address", "LOC-6.4"));
			c.Add(new Component("Country Code", "LOC-6.5"));
			c.Add(new Component("Area City Code", "LOC-6.6"));
			c.Add(new Component("Local Number", "LOC-6.7"));
			c.Add(new Component("Extension", "LOC-6.8"));
			c.Add(new Component("", "LOC-6.9"));
			c.Add(new Component("Extension Prefix", "LOC-6.10"));
			c.Add(new Component("Speed Dial Code", "LOC-6.11"));
			c.Add(new Component("Unformatted Telephone Number", "LOC-6.12"));
			f.Components = c;
			return f;
		}
		private Field LOC7()
		{
			Field f = new Field("License Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LOC-7.1"));
			c.Add(new Component("", "LOC-7.2"));
			c.Add(new Component("Name of Coding System", "LOC-7.3"));
			c.Add(new Component("Alternate Identifier", "LOC-7.4"));
			c.Add(new Component("Alternate Text", "LOC-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "LOC-7.6"));
			f.Components = c;
			return f;
		}
		private Field LOC8()
		{
			Field f = new Field("Location Equipment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LOC-8.1"));
			f.Components = c;
			return f;
		}
		private Field LOC9()
		{
			Field f = new Field("Location Service Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LOC-9.1"));
			f.Components = c;
			return f;
		}
	}
}
