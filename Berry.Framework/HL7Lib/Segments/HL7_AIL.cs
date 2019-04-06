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
    /// AIL Class: Constructs an HL7 AIL Segment Object
    /// </summary>
	public class AIL
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public AIL()
		{
			Name = "AIL";
			Description = "Appointment Information _ Location Resource";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(AIL1());
			fs.Add(AIL2());
			fs.Add(AIL3());
			fs.Add(AIL4());
			fs.Add(AIL5());
			fs.Add(AIL6());
			fs.Add(AIL7());
			fs.Add(AIL8());
			fs.Add(AIL9());
			fs.Add(AIL10());
			fs.Add(AIL11());
			fs.Add(AIL12());
			Fields = fs;
		}
		private Field AIL1()
		{
			Field f = new Field("Set ID - AIL");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "AIL-1.1"));
			f.Components = c;
			return f;
		}
		private Field AIL2()
		{
			Field f = new Field("Segment Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIL-2.1"));
			f.Components = c;
			return f;
		}
		private Field AIL3()
		{
			Field f = new Field("Location Resource ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "AIL-3.1"));
			c.Add(new Component("Room", "AIL-3.2"));
			c.Add(new Component("Bed", "AIL-3.3"));
			c.Add(new Component("Facility", "AIL-3.4"));
			c.Add(new Component("Location Status", "AIL-3.5"));
			c.Add(new Component("Person Location Type", "AIL-3.6"));
			c.Add(new Component("Building", "AIL-3.7"));
			c.Add(new Component("Floor Number", "AIL-3.8"));
			c.Add(new Component("Location Description", "AIL-3.9"));
			c.Add(new Component("Comprehensive Location Identifier", "AIL-3.10"));
			c.Add(new Component("Assigning Authority for Location", "AIL-3.11"));
			f.Components = c;
			return f;
		}
		private Field AIL4()
		{
			Field f = new Field("Location Type-AIL");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIL-4.1"));
			c.Add(new Component("", "AIL-4.2"));
			c.Add(new Component("Name of Coding System", "AIL-4.3"));
			c.Add(new Component("Alternate Identifier", "AIL-4.4"));
			c.Add(new Component("Alternate Text", "AIL-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIL-4.6"));
			f.Components = c;
			return f;
		}
		private Field AIL5()
		{
			Field f = new Field("Location Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIL-5.1"));
			c.Add(new Component("", "AIL-5.2"));
			c.Add(new Component("Name of Coding System", "AIL-5.3"));
			c.Add(new Component("Alternate Identifier", "AIL-5.4"));
			c.Add(new Component("Alternate Text", "AIL-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIL-5.6"));
			f.Components = c;
			return f;
		}
		private Field AIL6()
		{
			Field f = new Field("Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "AIL-6.1"));
			c.Add(new Component("Degree of Precision", "AIL-6.2"));
			f.Components = c;
			return f;
		}
		private Field AIL7()
		{
			Field f = new Field("Start Date/Time Offset");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIL-7.1"));
			f.Components = c;
			return f;
		}
		private Field AIL8()
		{
			Field f = new Field("Start Date/Time Offset Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIL-8.1"));
			c.Add(new Component("", "AIL-8.2"));
			c.Add(new Component("Name of Coding System", "AIL-8.3"));
			c.Add(new Component("Alternate Identifier", "AIL-8.4"));
			c.Add(new Component("Alternate Text", "AIL-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIL-8.6"));
			f.Components = c;
			return f;
		}
		private Field AIL9()
		{
			Field f = new Field("Duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIL-9.1"));
			f.Components = c;
			return f;
		}
		private Field AIL10()
		{
			Field f = new Field("Duration Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIL-10.1"));
			c.Add(new Component("", "AIL-10.2"));
			c.Add(new Component("Name of Coding System", "AIL-10.3"));
			c.Add(new Component("Alternate Identifier", "AIL-10.4"));
			c.Add(new Component("Alternate Text", "AIL-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIL-10.6"));
			f.Components = c;
			return f;
		}
		private Field AIL11()
		{
			Field f = new Field("Allow Substitution Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIL-11.1"));
			f.Components = c;
			return f;
		}
		private Field AIL12()
		{
			Field f = new Field("Filler Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIL-12.1"));
			c.Add(new Component("", "AIL-12.2"));
			c.Add(new Component("Name of Coding System", "AIL-12.3"));
			c.Add(new Component("Alternate Identifier", "AIL-12.4"));
			c.Add(new Component("Alternate Text", "AIL-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIL-12.6"));
			f.Components = c;
			return f;
		}
	}
}
