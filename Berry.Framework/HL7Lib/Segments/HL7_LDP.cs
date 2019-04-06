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
/// LDP Class: Constructs an HL7 LDP Segment Object
/// </summary>
public class LDP
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public LDP()
		{
			Name = "LDP";
			Description = "Location Department";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(LDP1());
			fs.Add(LDP2());
			fs.Add(LDP3());
			fs.Add(LDP4());
			fs.Add(LDP5());
			fs.Add(LDP6());
			fs.Add(LDP7());
			fs.Add(LDP8());
			fs.Add(LDP9());
			fs.Add(LDP10());
			fs.Add(LDP11());
			fs.Add(LDP12());
			Fields = fs;
		}
		private Field LDP1()
		{
			Field f = new Field("Primary Key Value - LDP");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "LDP-1.1"));
			c.Add(new Component("Room", "LDP-1.2"));
			c.Add(new Component("Bed", "LDP-1.3"));
			c.Add(new Component("Facility", "LDP-1.4"));
			c.Add(new Component("Location Status", "LDP-1.5"));
			c.Add(new Component("Person Location Type", "LDP-1.6"));
			c.Add(new Component("Building", "LDP-1.7"));
			c.Add(new Component("Floor Number", "LDP-1.8"));
			c.Add(new Component("Location Description", "LDP-1.9"));
			c.Add(new Component("Comprehensive Location Identifier", "LDP-1.10"));
			c.Add(new Component("Assigning Authority for Location", "LDP-1.11"));
			f.Components = c;
			return f;
		}
		private Field LDP2()
		{
			Field f = new Field("Location Department");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LDP-2.1"));
			c.Add(new Component("", "LDP-2.2"));
			c.Add(new Component("Name of Coding System", "LDP-2.3"));
			c.Add(new Component("Alternate Identifier", "LDP-2.4"));
			c.Add(new Component("Alternate Text", "LDP-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "LDP-2.6"));
			f.Components = c;
			return f;
		}
		private Field LDP3()
		{
			Field f = new Field("Location Service");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LDP-3.1"));
			f.Components = c;
			return f;
		}
		private Field LDP4()
		{
			Field f = new Field("Specialty Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LDP-4.1"));
			c.Add(new Component("", "LDP-4.2"));
			c.Add(new Component("Name of Coding System", "LDP-4.3"));
			c.Add(new Component("Alternate Identifier", "LDP-4.4"));
			c.Add(new Component("Alternate Text", "LDP-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "LDP-4.6"));
			f.Components = c;
			return f;
		}
		private Field LDP5()
		{
			Field f = new Field("Valid Patient Classes");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LDP-5.1"));
			f.Components = c;
			return f;
		}
		private Field LDP6()
		{
			Field f = new Field("Active/Inactive Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LDP-6.1"));
			f.Components = c;
			return f;
		}
		private Field LDP7()
		{
			Field f = new Field("Activation Date LDP");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "LDP-7.1"));
			c.Add(new Component("Degree of Precision", "LDP-7.2"));
			f.Components = c;
			return f;
		}
		private Field LDP8()
		{
			Field f = new Field("Inactivation Date - LDP");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "LDP-8.1"));
			c.Add(new Component("Degree of Precision", "LDP-8.2"));
			f.Components = c;
			return f;
		}
		private Field LDP9()
		{
			Field f = new Field("Inactivated Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LDP-9.1"));
			f.Components = c;
			return f;
		}
		private Field LDP10()
		{
			Field f = new Field("Visiting Hours");
			List<Component> c = new List<Component>();
			c.Add(new Component("Start Day Range", "LDP-10.1"));
			c.Add(new Component("End Day Range", "LDP-10.2"));
			c.Add(new Component("Start Hour Range", "LDP-10.3"));
			c.Add(new Component("End Hour Range", "LDP-10.4"));
			f.Components = c;
			return f;
		}
		private Field LDP11()
		{
			Field f = new Field("Contact Phone");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "LDP-11.1"));
			c.Add(new Component("Tele-Communication Use Code", "LDP-11.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "LDP-11.3"));
			c.Add(new Component("Email Address", "LDP-11.4"));
			c.Add(new Component("Country Code", "LDP-11.5"));
			c.Add(new Component("Area City Code", "LDP-11.6"));
			c.Add(new Component("Local Number", "LDP-11.7"));
			c.Add(new Component("Extension", "LDP-11.8"));
			c.Add(new Component("", "LDP-11.9"));
			c.Add(new Component("Extension Prefix", "LDP-11.10"));
			c.Add(new Component("Speed Dial Code", "LDP-11.11"));
			c.Add(new Component("Unformatted Telephone Number", "LDP-11.12"));
			f.Components = c;
			return f;
		}
		private Field LDP12()
		{
			Field f = new Field("Location Cost Center");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LDP-12.1"));
			c.Add(new Component("", "LDP-12.2"));
			c.Add(new Component("Name of Coding System", "LDP-12.3"));
			c.Add(new Component("Alternate Identifier", "LDP-12.4"));
			c.Add(new Component("Alternate Text", "LDP-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "LDP-12.6"));
			f.Components = c;
			return f;
		}
	}
}
