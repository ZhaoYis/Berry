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
/// QPD Class: Constructs an HL7 QPD Segment Object
/// </summary>
public class QPD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public QPD()
		{
			Name = "QPD";
			Description = "Query Parameter Definition";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(QPD1());
			fs.Add(QPD2());
			Fields = fs;
		}
		private Field QPD1()
		{
			Field f = new Field("Message Query Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "QPD-1.1"));
			c.Add(new Component("", "QPD-1.2"));
			c.Add(new Component("Name of Coding System", "QPD-1.3"));
			c.Add(new Component("Alternate Identifier", "QPD-1.4"));
			c.Add(new Component("Alternate Text", "QPD-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "QPD-1.6"));
			f.Components = c;
			return f;
		}
		private Field QPD2()
		{
			Field f = new Field("Query Tag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QPD-2.1"));
			f.Components = c;
			return f;
		}
	}
}
