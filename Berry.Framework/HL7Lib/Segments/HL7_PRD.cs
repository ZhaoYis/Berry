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
/// PRD Class: Constructs an HL7 PRD Segment Object
/// </summary>
public class PRD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PRD()
		{
			Name = "PRD";
			Description = "Provider Data";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PRD1());
			fs.Add(PRD2());
			fs.Add(PRD3());
			fs.Add(PRD4());
			fs.Add(PRD5());
			fs.Add(PRD6());
			fs.Add(PRD7());
			fs.Add(PRD8());
			fs.Add(PRD9());
			Fields = fs;
		}
		private Field PRD1()
		{
			Field f = new Field("Provider Role");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRD-1.1"));
			c.Add(new Component("", "PRD-1.2"));
			c.Add(new Component("Name of Coding System", "PRD-1.3"));
			c.Add(new Component("Alternate Identifier", "PRD-1.4"));
			c.Add(new Component("Alternate Text", "PRD-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRD-1.6"));
			f.Components = c;
			return f;
		}
		private Field PRD2()
		{
			Field f = new Field("Provider Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "PRD-2.1"));
			c.Add(new Component("Given Name", "PRD-2.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PRD-2.3"));
			c.Add(new Component("Suffix", "PRD-2.4"));
			c.Add(new Component("Prefix", "PRD-2.5"));
			c.Add(new Component("Degree", "PRD-2.6"));
			c.Add(new Component("Name Type Code", "PRD-2.7"));
			c.Add(new Component("Name Respresentation Code", "PRD-2.8"));
			c.Add(new Component("Name Context", "PRD-2.9"));
			c.Add(new Component("Name Validity Range", "PRD-2.10"));
			c.Add(new Component("Name Assembly Order", "PRD-2.11"));
			c.Add(new Component("Effective Date", "PRD-2.12"));
			c.Add(new Component("Expiration Date", "PRD-2.13"));
			c.Add(new Component("Professional Suffix", "PRD-2.14"));
			f.Components = c;
			return f;
		}
		private Field PRD3()
		{
			Field f = new Field("Provider Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "PRD-3.1"));
			c.Add(new Component("Other Designation", "PRD-3.2"));
			c.Add(new Component("City", "PRD-3.3"));
			c.Add(new Component("State or Province", "PRD-3.4"));
			c.Add(new Component("Zip or Postal Code", "PRD-3.5"));
			c.Add(new Component("Country", "PRD-3.6"));
			c.Add(new Component("Address Type", "PRD-3.7"));
			c.Add(new Component("Other Geographic Designation", "PRD-3.8"));
			c.Add(new Component("Country Parish Code", "PRD-3.9"));
			c.Add(new Component("Census Tract", "PRD-3.10"));
			c.Add(new Component("Address Representation Code", "PRD-3.11"));
			c.Add(new Component("Address Validity Range", "PRD-3.12"));
			c.Add(new Component("Effective Date", "PRD-3.13"));
			c.Add(new Component("Expiration Date", "PRD-3.14"));
			f.Components = c;
			return f;
		}
		private Field PRD4()
		{
			Field f = new Field("Provider Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "PRD-4.1"));
			c.Add(new Component("Room", "PRD-4.2"));
			c.Add(new Component("Bed", "PRD-4.3"));
			c.Add(new Component("Facility", "PRD-4.4"));
			c.Add(new Component("Location Status", "PRD-4.5"));
			c.Add(new Component("Person Location Type", "PRD-4.6"));
			c.Add(new Component("Building", "PRD-4.7"));
			c.Add(new Component("Floor Number", "PRD-4.8"));
			c.Add(new Component("Location Description", "PRD-4.9"));
			c.Add(new Component("Comprehensive Location Identifier", "PRD-4.10"));
			c.Add(new Component("Assigning Authority for Location", "PRD-4.11"));
			f.Components = c;
			return f;
		}
		private Field PRD5()
		{
			Field f = new Field("Provider Communication Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "PRD-5.1"));
			c.Add(new Component("Tele-Communication Use Code", "PRD-5.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "PRD-5.3"));
			c.Add(new Component("Email Address", "PRD-5.4"));
			c.Add(new Component("Country Code", "PRD-5.5"));
			c.Add(new Component("Area City Code", "PRD-5.6"));
			c.Add(new Component("Local Number", "PRD-5.7"));
			c.Add(new Component("Extension", "PRD-5.8"));
			c.Add(new Component("", "PRD-5.9"));
			c.Add(new Component("Extension Prefix", "PRD-5.10"));
			c.Add(new Component("Speed Dial Code", "PRD-5.11"));
			c.Add(new Component("Unformatted Telephone Number", "PRD-5.12"));
			f.Components = c;
			return f;
		}
		private Field PRD6()
		{
			Field f = new Field("Preferred Method of Contact");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRD-6.1"));
			c.Add(new Component("", "PRD-6.2"));
			c.Add(new Component("Name of Coding System", "PRD-6.3"));
			c.Add(new Component("Alternate Identifier", "PRD-6.4"));
			c.Add(new Component("Alternate Text", "PRD-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRD-6.6"));
			f.Components = c;
			return f;
		}
		private Field PRD7()
		{
			Field f = new Field("Provider Identifiers");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PRD-7.1"));
			c.Add(new Component("Type or ID Number", "PRD-7.2"));
			c.Add(new Component("State Other Qualifying Information", "PRD-7.3"));
			c.Add(new Component("Expiration Date", "PRD-7.4"));
			f.Components = c;
			return f;
		}
		private Field PRD8()
		{
			Field f = new Field("Effective Start Date of Provider Role");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRD-8.1"));
			c.Add(new Component("Degree of Precision", "PRD-8.2"));
			f.Components = c;
			return f;
		}
		private Field PRD9()
		{
			Field f = new Field("Effective End Date of Provider Role");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRD-9.1"));
			c.Add(new Component("Degree of Precision", "PRD-9.2"));
			f.Components = c;
			return f;
		}
	}
}
