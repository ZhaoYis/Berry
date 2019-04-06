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
/// SPR Class: Constructs an HL7 SPR Segment Object
/// </summary>
public class SPR
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public SPR()
		{
			Name = "SPR";
			Description = "Stored Procedure Request Definition";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(SPR1());
			fs.Add(SPR2());
			fs.Add(SPR3());
			fs.Add(SPR4());
			Fields = fs;
		}
		private Field SPR1()
		{
			Field f = new Field("Query Tag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SPR-1.1"));
			f.Components = c;
			return f;
		}
		private Field SPR2()
		{
			Field f = new Field("Query/Response Format Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SPR-2.1"));
			f.Components = c;
			return f;
		}
		private Field SPR3()
		{
			Field f = new Field("Stored Procedure Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPR-3.1"));
			c.Add(new Component("", "SPR-3.2"));
			c.Add(new Component("Name of Coding System", "SPR-3.3"));
			c.Add(new Component("Alternate Identifier", "SPR-3.4"));
			c.Add(new Component("Alternate Text", "SPR-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPR-3.6"));
			f.Components = c;
			return f;
		}
		private Field SPR4()
		{
			Field f = new Field("Input Parameter List");
			List<Component> c = new List<Component>();
			c.Add(new Component("Segment Field Name", "SPR-4.1"));
			c.Add(new Component("Value", "SPR-4.2"));
			f.Components = c;
			return f;
		}
	}
}
