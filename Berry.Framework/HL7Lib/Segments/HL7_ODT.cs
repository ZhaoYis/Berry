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
/// ODT Class: Constructs an HL7 ODT Segment Object
/// </summary>
public class ODT
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ODT()
		{
			Name = "ODT";
			Description = "Diet Tray Instructions";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ODT1());
			fs.Add(ODT2());
			fs.Add(ODT3());
			Fields = fs;
		}
		private Field ODT1()
		{
			Field f = new Field("Tray Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ODT-1.1"));
			c.Add(new Component("", "ODT-1.2"));
			c.Add(new Component("Name of Coding System", "ODT-1.3"));
			c.Add(new Component("Alternate Identifier", "ODT-1.4"));
			c.Add(new Component("Alternate Text", "ODT-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "ODT-1.6"));
			f.Components = c;
			return f;
		}
		private Field ODT2()
		{
			Field f = new Field("Service Period");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ODT-2.1"));
			c.Add(new Component("", "ODT-2.2"));
			c.Add(new Component("Name of Coding System", "ODT-2.3"));
			c.Add(new Component("Alternate Identifier", "ODT-2.4"));
			c.Add(new Component("Alternate Text", "ODT-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "ODT-2.6"));
			f.Components = c;
			return f;
		}
		private Field ODT3()
		{
			Field f = new Field("Text Instruction");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ODT-3.1"));
			f.Components = c;
			return f;
		}
	}
}
