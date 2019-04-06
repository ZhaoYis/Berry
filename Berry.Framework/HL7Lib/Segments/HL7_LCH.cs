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
/// LCH Class: Constructs an HL7 LCH Segment Object
/// </summary>
public class LCH
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public LCH()
		{
			Name = "LCH";
			Description = "Location Characteristic";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(LCH1());
			fs.Add(LCH2());
			fs.Add(LCH3());
			fs.Add(LCH4());
			fs.Add(LCH5());
			Fields = fs;
		}
		private Field LCH1()
		{
			Field f = new Field("Primary Key Value - LCH");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "LCH-1.1"));
			c.Add(new Component("Room", "LCH-1.2"));
			c.Add(new Component("Bed", "LCH-1.3"));
			c.Add(new Component("Facility", "LCH-1.4"));
			c.Add(new Component("Location Status", "LCH-1.5"));
			c.Add(new Component("Person Location Type", "LCH-1.6"));
			c.Add(new Component("Building", "LCH-1.7"));
			c.Add(new Component("Floor Number", "LCH-1.8"));
			c.Add(new Component("Location Description", "LCH-1.9"));
			c.Add(new Component("Comprehensive Location Identifier", "LCH-1.10"));
			c.Add(new Component("Assigning Authority for Location", "LCH-1.11"));
			f.Components = c;
			return f;
		}
		private Field LCH2()
		{
			Field f = new Field("Segment Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "LCH-2.1"));
			f.Components = c;
			return f;
		}
		private Field LCH3()
		{
			Field f = new Field("Segment Unique Key");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "LCH-3.1"));
			c.Add(new Component("Namespace ID", "LCH-3.2"));
			c.Add(new Component("Universal ID", "LCH-3.3"));
			c.Add(new Component("Universal ID Type", "LCH-3.4"));
			f.Components = c;
			return f;
		}
		private Field LCH4()
		{
			Field f = new Field("Location Characteristic ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LCH-4.1"));
			c.Add(new Component("", "LCH-4.2"));
			c.Add(new Component("Name of Coding System", "LCH-4.3"));
			c.Add(new Component("Alternate Identifier", "LCH-4.4"));
			c.Add(new Component("Alternate Text", "LCH-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "LCH-4.6"));
			f.Components = c;
			return f;
		}
		private Field LCH5()
		{
			Field f = new Field("Location Characteristic Value-LCH");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LCH-5.1"));
			c.Add(new Component("", "LCH-5.2"));
			c.Add(new Component("Name of Coding System", "LCH-5.3"));
			c.Add(new Component("Alternate Identifier", "LCH-5.4"));
			c.Add(new Component("Alternate Text", "LCH-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "LCH-5.6"));
			f.Components = c;
			return f;
		}
	}
}
