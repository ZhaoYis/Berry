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
/// RMI Class: Constructs an HL7 RMI Segment Object
/// </summary>
public class RMI
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RMI()
		{
			Name = "RMI";
			Description = "Risk Management Incident";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RMI1());
			fs.Add(RMI2());
			fs.Add(RMI3());
			Fields = fs;
		}
		private Field RMI1()
		{
			Field f = new Field("Risk Management Incident Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RMI-1.1"));
			c.Add(new Component("", "RMI-1.2"));
			c.Add(new Component("Name of Coding System", "RMI-1.3"));
			c.Add(new Component("Alternate Identifier", "RMI-1.4"));
			c.Add(new Component("Alternate Text", "RMI-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "RMI-1.6"));
			f.Components = c;
			return f;
		}
		private Field RMI2()
		{
			Field f = new Field("Date/Time Incident");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RMI-2.1"));
			c.Add(new Component("Degree of Precision", "RMI-2.2"));
			f.Components = c;
			return f;
		}
		private Field RMI3()
		{
			Field f = new Field("Incident Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RMI-3.1"));
			c.Add(new Component("", "RMI-3.2"));
			c.Add(new Component("Name of Coding System", "RMI-3.3"));
			c.Add(new Component("Alternate Identifier", "RMI-3.4"));
			c.Add(new Component("Alternate Text", "RMI-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "RMI-3.6"));
			f.Components = c;
			return f;
		}
	}
}
