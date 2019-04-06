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
/// CNS Class: Constructs an HL7 CNS Segment Object
/// </summary>
public class CNS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CNS()
		{
			Name = "CNS";
			Description = "Clear Notification";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CNS1());
			fs.Add(CNS2());
			fs.Add(CNS3());
			fs.Add(CNS4());
			fs.Add(CNS5());
			fs.Add(CNS6());
			Fields = fs;
		}
		private Field CNS1()
		{
			Field f = new Field("Starting Notification Reference Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CNS-1.1"));
			f.Components = c;
			return f;
		}
		private Field CNS2()
		{
			Field f = new Field("Ending Notification Reference Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CNS-2.1"));
			f.Components = c;
			return f;
		}
		private Field CNS3()
		{
			Field f = new Field("Starting Notification Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CNS-3.1"));
			c.Add(new Component("Degree of Precision", "CNS-3.2"));
			f.Components = c;
			return f;
		}
		private Field CNS4()
		{
			Field f = new Field("Ending Notification Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CNS-4.1"));
			c.Add(new Component("Degree of Precision", "CNS-4.2"));
			f.Components = c;
			return f;
		}
		private Field CNS5()
		{
			Field f = new Field("Starting Notification Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CNS-5.1"));
			c.Add(new Component("", "CNS-5.2"));
			c.Add(new Component("Name of Coding System", "CNS-5.3"));
			c.Add(new Component("Alternate Identifier", "CNS-5.4"));
			c.Add(new Component("Alternate Text", "CNS-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "CNS-5.6"));
			f.Components = c;
			return f;
		}
		private Field CNS6()
		{
			Field f = new Field("Ending Notification Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CNS-6.1"));
			c.Add(new Component("", "CNS-6.2"));
			c.Add(new Component("Name of Coding System", "CNS-6.3"));
			c.Add(new Component("Alternate Identifier", "CNS-6.4"));
			c.Add(new Component("Alternate Text", "CNS-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "CNS-6.6"));
			f.Components = c;
			return f;
		}
	}
}
