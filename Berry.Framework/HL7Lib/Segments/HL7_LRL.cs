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
/// LRL Class: Constructs an HL7 LRL Segment Object
/// </summary>
public class LRL
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public LRL()
		{
			Name = "LRL";
			Description = "Location Relationship";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(LRL1());
			fs.Add(LRL2());
			fs.Add(LRL3());
			fs.Add(LRL4());
			fs.Add(LRL5());
			fs.Add(LRL6());
			Fields = fs;
		}
		private Field LRL1()
		{
			Field f = new Field("Primary Key Value - LRL");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "LRL-1.1"));
			c.Add(new Component("Room", "LRL-1.2"));
			c.Add(new Component("Bed", "LRL-1.3"));
			c.Add(new Component("Facility", "LRL-1.4"));
			c.Add(new Component("Location Status", "LRL-1.5"));
			c.Add(new Component("Person Location Type", "LRL-1.6"));
			c.Add(new Component("Building", "LRL-1.7"));
			c.Add(new Component("Floor Number", "LRL-1.8"));
			c.Add(new Component("Location Description", "LRL-1.9"));
			c.Add(new Component("Comprehensive Location Identifier", "LRL-1.10"));
			c.Add(new Component("Assigning Authority for Location", "LRL-1.11"));
			f.Components = c;
			return f;
		}
		private Field LRL2()
		{
			Field f = new Field("Segment Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LRL-2.1"));
			f.Components = c;
			return f;
		}
		private Field LRL3()
		{
			Field f = new Field("Segment Unique Key");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "LRL-3.1"));
			c.Add(new Component("Namespace ID", "LRL-3.2"));
			c.Add(new Component("Universal ID", "LRL-3.3"));
			c.Add(new Component("Universal ID Type", "LRL-3.4"));
			f.Components = c;
			return f;
		}
		private Field LRL4()
		{
			Field f = new Field("Location Relationship ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LRL-4.1"));
			c.Add(new Component("", "LRL-4.2"));
			c.Add(new Component("Name of Coding System", "LRL-4.3"));
			c.Add(new Component("Alternate Identifier", "LRL-4.4"));
			c.Add(new Component("Alternate Text", "LRL-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "LRL-4.6"));
			f.Components = c;
			return f;
		}
		private Field LRL5()
		{
			Field f = new Field("Organizational Location Relationship Value");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "LRL-5.1"));
			c.Add(new Component("Organization Name Type Code", "LRL-5.2"));
			c.Add(new Component("ID Number", "LRL-5.3"));
			c.Add(new Component("Check Digit", "LRL-5.4"));
			c.Add(new Component("Check Digit Scheme", "LRL-5.5"));
			c.Add(new Component("Assigning Authority", "LRL-5.6"));
			c.Add(new Component("Identifier Type Code", "LRL-5.7"));
			c.Add(new Component("Assigning Facility", "LRL-5.8"));
			c.Add(new Component("Name Respresentation Code", "LRL-5.9"));
			c.Add(new Component("Organization Identifier", "LRL-5.10"));
			f.Components = c;
			return f;
		}
		private Field LRL6()
		{
			Field f = new Field("Patient Location Relationship Value");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "LRL-6.1"));
			c.Add(new Component("Room", "LRL-6.2"));
			c.Add(new Component("Bed", "LRL-6.3"));
			c.Add(new Component("Facility", "LRL-6.4"));
			c.Add(new Component("Location Status", "LRL-6.5"));
			c.Add(new Component("Person Location Type", "LRL-6.6"));
			c.Add(new Component("Building", "LRL-6.7"));
			c.Add(new Component("Floor Number", "LRL-6.8"));
			c.Add(new Component("Location Description", "LRL-6.9"));
			c.Add(new Component("Comprehensive Location Identifier", "LRL-6.10"));
			c.Add(new Component("Assigning Authority for Location", "LRL-6.11"));
			f.Components = c;
			return f;
		}
	}
}
