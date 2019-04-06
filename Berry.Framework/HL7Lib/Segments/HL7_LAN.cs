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
/// LAN Class: Constructs an HL7 LAN Segment Object
/// </summary>
public class LAN
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public LAN()
		{
			Name = "LAN";
			Description = "Language Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(LAN1());
			fs.Add(LAN2());
			fs.Add(LAN3());
			fs.Add(LAN4());
			Fields = fs;
		}
		private Field LAN1()
		{
			Field f = new Field("Set ID _ LAN");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "LAN-1.1"));
			f.Components = c;
			return f;
		}
		private Field LAN2()
		{
			Field f = new Field("Language Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LAN-2.1"));
			c.Add(new Component("", "LAN-2.2"));
			c.Add(new Component("Name of Coding System", "LAN-2.3"));
			c.Add(new Component("Alternate Identifier", "LAN-2.4"));
			c.Add(new Component("Alternate Text", "LAN-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "LAN-2.6"));
			f.Components = c;
			return f;
		}
		private Field LAN3()
		{
			Field f = new Field("Language Ability Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LAN-3.1"));
			c.Add(new Component("", "LAN-3.2"));
			c.Add(new Component("Name of Coding System", "LAN-3.3"));
			c.Add(new Component("Alternate Identifier", "LAN-3.4"));
			c.Add(new Component("Alternate Text", "LAN-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "LAN-3.6"));
			f.Components = c;
			return f;
		}
		private Field LAN4()
		{
			Field f = new Field("Language Proficiency Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "LAN-4.1"));
			c.Add(new Component("", "LAN-4.2"));
			c.Add(new Component("Name of Coding System", "LAN-4.3"));
			c.Add(new Component("Alternate Identifier", "LAN-4.4"));
			c.Add(new Component("Alternate Text", "LAN-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "LAN-4.6"));
			f.Components = c;
			return f;
		}
	}
}
