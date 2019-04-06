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
/// ISD Class: Constructs an HL7 ISD Segment Object
/// </summary>
public class ISD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ISD()
		{
			Name = "ISD";
			Description = "Interaction Status Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ISD1());
			fs.Add(ISD2());
			fs.Add(ISD3());
			Fields = fs;
		}
		private Field ISD1()
		{
			Field f = new Field("Reference Interaction Number (unique identifier)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ISD-1.1"));
			f.Components = c;
			return f;
		}
		private Field ISD2()
		{
			Field f = new Field("Interaction Type Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ISD-2.1"));
			c.Add(new Component("", "ISD-2.2"));
			c.Add(new Component("Name of Coding System", "ISD-2.3"));
			c.Add(new Component("Alternate Identifier", "ISD-2.4"));
			c.Add(new Component("Alternate Text", "ISD-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "ISD-2.6"));
			f.Components = c;
			return f;
		}
		private Field ISD3()
		{
			Field f = new Field("Interaction Active State");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ISD-3.1"));
			c.Add(new Component("", "ISD-3.2"));
			c.Add(new Component("Name of Coding System", "ISD-3.3"));
			c.Add(new Component("Alternate Identifier", "ISD-3.4"));
			c.Add(new Component("Alternate Text", "ISD-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "ISD-3.6"));
			f.Components = c;
			return f;
		}
	}
}
