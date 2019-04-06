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
/// NDS Class: Constructs an HL7 NDS Segment Object
/// </summary>
public class NDS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public NDS()
		{
			Name = "NDS";
			Description = "Notification Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(NDS1());
			fs.Add(NDS2());
			fs.Add(NDS3());
			fs.Add(NDS4());
			Fields = fs;
		}
		private Field NDS1()
		{
			Field f = new Field("Notification Reference Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "NDS-1.1"));
			f.Components = c;
			return f;
		}
		private Field NDS2()
		{
			Field f = new Field("Notification Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "NDS-2.1"));
			c.Add(new Component("Degree of Precision", "NDS-2.2"));
			f.Components = c;
			return f;
		}
		private Field NDS3()
		{
			Field f = new Field("Notification Alert Severity");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NDS-3.1"));
			c.Add(new Component("", "NDS-3.2"));
			c.Add(new Component("Name of Coding System", "NDS-3.3"));
			c.Add(new Component("Alternate Identifier", "NDS-3.4"));
			c.Add(new Component("Alternate Text", "NDS-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "NDS-3.6"));
			f.Components = c;
			return f;
		}
		private Field NDS4()
		{
			Field f = new Field("Notification Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "NDS-4.1"));
			c.Add(new Component("", "NDS-4.2"));
			c.Add(new Component("Name of Coding System", "NDS-4.3"));
			c.Add(new Component("Alternate Identifier", "NDS-4.4"));
			c.Add(new Component("Alternate Text", "NDS-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "NDS-4.6"));
			f.Components = c;
			return f;
		}
	}
}
