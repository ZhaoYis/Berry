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
/// CTI Class: Constructs an HL7 CTI Segment Object
/// </summary>
public class CTI
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CTI()
		{
			Name = "CTI";
			Description = "Clinical Trial Identification";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CTI1());
			fs.Add(CTI2());
			fs.Add(CTI3());
			Fields = fs;
		}
		private Field CTI1()
		{
			Field f = new Field("Sponsor Study ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "CTI-1.1"));
			c.Add(new Component("Namespace ID", "CTI-1.2"));
			c.Add(new Component("Universal ID", "CTI-1.3"));
			c.Add(new Component("Universal ID Type", "CTI-1.4"));
			f.Components = c;
			return f;
		}
		private Field CTI2()
		{
			Field f = new Field("Study Phase Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CTI-2.1"));
			c.Add(new Component("", "CTI-2.2"));
			c.Add(new Component("Name of Coding System", "CTI-2.3"));
			c.Add(new Component("Alternate Identifier", "CTI-2.4"));
			c.Add(new Component("Alternate Text", "CTI-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "CTI-2.6"));
			f.Components = c;
			return f;
		}
		private Field CTI3()
		{
			Field f = new Field("Study Scheduled Time Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CTI-3.1"));
			c.Add(new Component("", "CTI-3.2"));
			c.Add(new Component("Name of Coding System", "CTI-3.3"));
			c.Add(new Component("Alternate Identifier", "CTI-3.4"));
			c.Add(new Component("Alternate Text", "CTI-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "CTI-3.6"));
			f.Components = c;
			return f;
		}
	}
}
