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
/// EQU Class: Constructs an HL7 EQU Segment Object
/// </summary>
public class EQU
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public EQU()
		{
			Name = "EQU";
			Description = "Equipment Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(EQU1());
			fs.Add(EQU2());
			fs.Add(EQU3());
			fs.Add(EQU4());
			fs.Add(EQU5());
			Fields = fs;
		}
		private Field EQU1()
		{
			Field f = new Field("Equipment Instance Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "EQU-1.1"));
			c.Add(new Component("Namespace ID", "EQU-1.2"));
			c.Add(new Component("Universal ID", "EQU-1.3"));
			c.Add(new Component("Universal ID Type", "EQU-1.4"));
			f.Components = c;
			return f;
		}
		private Field EQU2()
		{
			Field f = new Field("Event Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "EQU-2.1"));
			c.Add(new Component("Degree of Precision", "EQU-2.2"));
			f.Components = c;
			return f;
		}
		private Field EQU3()
		{
			Field f = new Field("Equipment State");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "EQU-3.1"));
			c.Add(new Component("", "EQU-3.2"));
			c.Add(new Component("Name of Coding System", "EQU-3.3"));
			c.Add(new Component("Alternate Identifier", "EQU-3.4"));
			c.Add(new Component("Alternate Text", "EQU-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "EQU-3.6"));
			f.Components = c;
			return f;
		}
		private Field EQU4()
		{
			Field f = new Field("Local/Remote Control State");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "EQU-4.1"));
			c.Add(new Component("", "EQU-4.2"));
			c.Add(new Component("Name of Coding System", "EQU-4.3"));
			c.Add(new Component("Alternate Identifier", "EQU-4.4"));
			c.Add(new Component("Alternate Text", "EQU-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "EQU-4.6"));
			f.Components = c;
			return f;
		}
		private Field EQU5()
		{
			Field f = new Field("Alert Level");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "EQU-5.1"));
			c.Add(new Component("", "EQU-5.2"));
			c.Add(new Component("Name of Coding System", "EQU-5.3"));
			c.Add(new Component("Alternate Identifier", "EQU-5.4"));
			c.Add(new Component("Alternate Text", "EQU-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "EQU-5.6"));
			f.Components = c;
			return f;
		}
	}
}
