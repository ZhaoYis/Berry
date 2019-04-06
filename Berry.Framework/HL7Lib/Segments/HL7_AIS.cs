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
    /// AIS Class: Constructs an HL7 AIS Segment Object
    /// </summary>
	public class AIS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public AIS()
		{
			Name = "AIS";
			Description = "Appointment Information";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(AIS1());
			fs.Add(AIS2());
			fs.Add(AIS3());
			fs.Add(AIS4());
			fs.Add(AIS5());
			fs.Add(AIS6());
			fs.Add(AIS7());
			fs.Add(AIS8());
			fs.Add(AIS9());
			fs.Add(AIS10());
			fs.Add(AIS11());
			fs.Add(AIS12());
			Fields = fs;
		}
		private Field AIS1()
		{
			Field f = new Field("Set ID - AIS");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "AIS-1.1"));
			f.Components = c;
			return f;
		}
		private Field AIS2()
		{
			Field f = new Field("Segment Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIS-2.1"));
			f.Components = c;
			return f;
		}
		private Field AIS3()
		{
			Field f = new Field("Universal Service Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIS-3.1"));
			c.Add(new Component("", "AIS-3.2"));
			c.Add(new Component("Name of Coding System", "AIS-3.3"));
			c.Add(new Component("Alternate Identifier", "AIS-3.4"));
			c.Add(new Component("Alternate Text", "AIS-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIS-3.6"));
			f.Components = c;
			return f;
		}
		private Field AIS4()
		{
			Field f = new Field("Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "AIS-4.1"));
			c.Add(new Component("Degree of Precision", "AIS-4.2"));
			f.Components = c;
			return f;
		}
		private Field AIS5()
		{
			Field f = new Field("Start Date/Time Offset");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIS-5.1"));
			f.Components = c;
			return f;
		}
		private Field AIS6()
		{
			Field f = new Field("Start Date/Time Offset Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIS-6.1"));
			c.Add(new Component("", "AIS-6.2"));
			c.Add(new Component("Name of Coding System", "AIS-6.3"));
			c.Add(new Component("Alternate Identifier", "AIS-6.4"));
			c.Add(new Component("Alternate Text", "AIS-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIS-6.6"));
			f.Components = c;
			return f;
		}
		private Field AIS7()
		{
			Field f = new Field("Duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIS-7.1"));
			f.Components = c;
			return f;
		}
		private Field AIS8()
		{
			Field f = new Field("Duration Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIS-8.1"));
			c.Add(new Component("", "AIS-8.2"));
			c.Add(new Component("Name of Coding System", "AIS-8.3"));
			c.Add(new Component("Alternate Identifier", "AIS-8.4"));
			c.Add(new Component("Alternate Text", "AIS-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIS-8.6"));
			f.Components = c;
			return f;
		}
		private Field AIS9()
		{
			Field f = new Field("Allow Substitution Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIS-9.1"));
			f.Components = c;
			return f;
		}
		private Field AIS10()
		{
			Field f = new Field("Filler Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIS-10.1"));
			c.Add(new Component("", "AIS-10.2"));
			c.Add(new Component("Name of Coding System", "AIS-10.3"));
			c.Add(new Component("Alternate Identifier", "AIS-10.4"));
			c.Add(new Component("Alternate Text", "AIS-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIS-10.6"));
			f.Components = c;
			return f;
		}
		private Field AIS11()
		{
			Field f = new Field("Placer Supplemental Service Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIS-11.1"));
			c.Add(new Component("", "AIS-11.2"));
			c.Add(new Component("Name of Coding System", "AIS-11.3"));
			c.Add(new Component("Alternate Identifier", "AIS-11.4"));
			c.Add(new Component("Alternate Text", "AIS-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIS-11.6"));
			f.Components = c;
			return f;
		}
		private Field AIS12()
		{
			Field f = new Field("Filler Supplemental Service Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIS-12.1"));
			c.Add(new Component("", "AIS-12.2"));
			c.Add(new Component("Name of Coding System", "AIS-12.3"));
			c.Add(new Component("Alternate Identifier", "AIS-12.4"));
			c.Add(new Component("Alternate Text", "AIS-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIS-12.6"));
			f.Components = c;
			return f;
		}
	}
}
