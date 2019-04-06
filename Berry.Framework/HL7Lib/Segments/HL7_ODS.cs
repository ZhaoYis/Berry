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
/// ODS Class: Constructs an HL7 ODS Segment Object
/// </summary>
public class ODS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ODS()
		{
			Name = "ODS";
			Description = "Dietary Orders, Supplements, and Preferences";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ODS1());
			fs.Add(ODS2());
			fs.Add(ODS3());
			fs.Add(ODS4());
			Fields = fs;
		}
		private Field ODS1()
		{
			Field f = new Field("Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ODS-1.1"));
			f.Components = c;
			return f;
		}
		private Field ODS2()
		{
			Field f = new Field("Service Period");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ODS-2.1"));
			c.Add(new Component("", "ODS-2.2"));
			c.Add(new Component("Name of Coding System", "ODS-2.3"));
			c.Add(new Component("Alternate Identifier", "ODS-2.4"));
			c.Add(new Component("Alternate Text", "ODS-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "ODS-2.6"));
			f.Components = c;
			return f;
		}
		private Field ODS3()
		{
			Field f = new Field("Diet, Supplement, or Preference Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ODS-3.1"));
			c.Add(new Component("", "ODS-3.2"));
			c.Add(new Component("Name of Coding System", "ODS-3.3"));
			c.Add(new Component("Alternate Identifier", "ODS-3.4"));
			c.Add(new Component("Alternate Text", "ODS-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "ODS-3.6"));
			f.Components = c;
			return f;
		}
		private Field ODS4()
		{
			Field f = new Field("Text Instruction");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ODS-4.1"));
			f.Components = c;
			return f;
		}
	}
}
