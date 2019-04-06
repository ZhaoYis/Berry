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
/// CTD Class: Constructs an HL7 CTD Segment Object
/// </summary>
public class CTD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CTD()
		{
			Name = "CTD";
			Description = "Contact Data";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CTD1());
			fs.Add(CTD2());
			fs.Add(CTD3());
			fs.Add(CTD4());
			fs.Add(CTD5());
			fs.Add(CTD6());
			fs.Add(CTD7());
			Fields = fs;
		}
		private Field CTD1()
		{
			Field f = new Field("Contact Role");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CTD-1.1"));
			c.Add(new Component("", "CTD-1.2"));
			c.Add(new Component("Name of Coding System", "CTD-1.3"));
			c.Add(new Component("Alternate Identifier", "CTD-1.4"));
			c.Add(new Component("Alternate Text", "CTD-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "CTD-1.6"));
			f.Components = c;
			return f;
		}
		private Field CTD2()
		{
			Field f = new Field("Contact Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "CTD-2.1"));
			c.Add(new Component("Given Name", "CTD-2.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "CTD-2.3"));
			c.Add(new Component("Suffix", "CTD-2.4"));
			c.Add(new Component("Prefix", "CTD-2.5"));
			c.Add(new Component("Degree", "CTD-2.6"));
			c.Add(new Component("Name Type Code", "CTD-2.7"));
			c.Add(new Component("Name Respresentation Code", "CTD-2.8"));
			c.Add(new Component("Name Context", "CTD-2.9"));
			c.Add(new Component("Name Validity Range", "CTD-2.10"));
			c.Add(new Component("Name Assembly Order", "CTD-2.11"));
			c.Add(new Component("Effective Date", "CTD-2.12"));
			c.Add(new Component("Expiration Date", "CTD-2.13"));
			c.Add(new Component("Professional Suffix", "CTD-2.14"));
			f.Components = c;
			return f;
		}
		private Field CTD3()
		{
			Field f = new Field("Contact Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "CTD-3.1"));
			c.Add(new Component("Other Designation", "CTD-3.2"));
			c.Add(new Component("City", "CTD-3.3"));
			c.Add(new Component("State or Province", "CTD-3.4"));
			c.Add(new Component("Zip or Postal Code", "CTD-3.5"));
			c.Add(new Component("Country", "CTD-3.6"));
			c.Add(new Component("Address Type", "CTD-3.7"));
			c.Add(new Component("Other Geographic Designation", "CTD-3.8"));
			c.Add(new Component("Country Parish Code", "CTD-3.9"));
			c.Add(new Component("Census Tract", "CTD-3.10"));
			c.Add(new Component("Address Representation Code", "CTD-3.11"));
			c.Add(new Component("Address Validity Range", "CTD-3.12"));
			c.Add(new Component("Effective Date", "CTD-3.13"));
			c.Add(new Component("Expiration Date", "CTD-3.14"));
			f.Components = c;
			return f;
		}
		private Field CTD4()
		{
			Field f = new Field("Contact Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "CTD-4.1"));
			c.Add(new Component("Room", "CTD-4.2"));
			c.Add(new Component("Bed", "CTD-4.3"));
			c.Add(new Component("Facility", "CTD-4.4"));
			c.Add(new Component("Location Status", "CTD-4.5"));
			c.Add(new Component("Person Location Type", "CTD-4.6"));
			c.Add(new Component("Building", "CTD-4.7"));
			c.Add(new Component("Floor Number", "CTD-4.8"));
			c.Add(new Component("Location Description", "CTD-4.9"));
			c.Add(new Component("Comprehensive Location Identifier", "CTD-4.10"));
			c.Add(new Component("Assigning Authority for Location", "CTD-4.11"));
			f.Components = c;
			return f;
		}
		private Field CTD5()
		{
			Field f = new Field("Contact Communication Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "CTD-5.1"));
			c.Add(new Component("Tele-Communication Use Code", "CTD-5.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "CTD-5.3"));
			c.Add(new Component("Email Address", "CTD-5.4"));
			c.Add(new Component("Country Code", "CTD-5.5"));
			c.Add(new Component("Area City Code", "CTD-5.6"));
			c.Add(new Component("Local Number", "CTD-5.7"));
			c.Add(new Component("Extension", "CTD-5.8"));
			c.Add(new Component("", "CTD-5.9"));
			c.Add(new Component("Extension Prefix", "CTD-5.10"));
			c.Add(new Component("Speed Dial Code", "CTD-5.11"));
			c.Add(new Component("Unformatted Telephone Number", "CTD-5.12"));
			f.Components = c;
			return f;
		}
		private Field CTD6()
		{
			Field f = new Field("Preferred Method of Contact");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CTD-6.1"));
			c.Add(new Component("", "CTD-6.2"));
			c.Add(new Component("Name of Coding System", "CTD-6.3"));
			c.Add(new Component("Alternate Identifier", "CTD-6.4"));
			c.Add(new Component("Alternate Text", "CTD-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "CTD-6.6"));
			f.Components = c;
			return f;
		}
		private Field CTD7()
		{
			Field f = new Field("Contact Identifiers");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CTD-7.1"));
			c.Add(new Component("Type or ID Number", "CTD-7.2"));
			c.Add(new Component("State Other Qualifying Information", "CTD-7.3"));
			c.Add(new Component("Expiration Date", "CTD-7.4"));
			f.Components = c;
			return f;
		}
	}
}
