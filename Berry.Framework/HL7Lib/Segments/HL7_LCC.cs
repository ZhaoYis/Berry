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
/// LCC Class: Constructs an HL7 LCC Segment Object
/// </summary>
public class LCC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public LCC()
		{
			Name = "LCC";
			Description = "Location Charge Code";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(LCC1());
			fs.Add(LCC2());
			fs.Add(LCC3());
			fs.Add(LCC4());
			Fields = fs;
		}
		private Field LCC1()
		{
			Field f = new Field("Primary Key Value - LCC");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "LCC-1.1"));
			c.Add(new Component("Room", "LCC-1.2"));
			c.Add(new Component("Bed", "LCC-1.3"));
			c.Add(new Component("Facility", "LCC-1.4"));
			c.Add(new Component("Location Status", "LCC-1.5"));
			c.Add(new Component("Person Location Type", "LCC-1.6"));
			c.Add(new Component("Building", "LCC-1.7"));
			c.Add(new Component("Floor Number", "LCC-1.8"));
			c.Add(new Component("Location Description", "LCC-1.9"));
			c.Add(new Component("Comprehensive Location Identifier", "LCC-1.10"));
			c.Add(new Component("Assigning Authority for Location", "LCC-1.11"));
			f.Components = c;
			return f;
		}
		private Field LCC2()
		{
			Field f = new Field("Location Department");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LCC-2.1"));
			c.Add(new Component("", "LCC-2.2"));
			c.Add(new Component("Name of Coding System", "LCC-2.3"));
			c.Add(new Component("Alternate Identifier", "LCC-2.4"));
			c.Add(new Component("Alternate Text", "LCC-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "LCC-2.6"));
			f.Components = c;
			return f;
		}
		private Field LCC3()
		{
			Field f = new Field("Accommodation Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LCC-3.1"));
			c.Add(new Component("", "LCC-3.2"));
			c.Add(new Component("Name of Coding System", "LCC-3.3"));
			c.Add(new Component("Alternate Identifier", "LCC-3.4"));
			c.Add(new Component("Alternate Text", "LCC-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "LCC-3.6"));
			f.Components = c;
			return f;
		}
		private Field LCC4()
		{
			Field f = new Field("Charge Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LCC-4.1"));
			c.Add(new Component("", "LCC-4.2"));
			c.Add(new Component("Name of Coding System", "LCC-4.3"));
			c.Add(new Component("Alternate Identifier", "LCC-4.4"));
			c.Add(new Component("Alternate Text", "LCC-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "LCC-4.6"));
			f.Components = c;
			return f;
		}
	}
}
