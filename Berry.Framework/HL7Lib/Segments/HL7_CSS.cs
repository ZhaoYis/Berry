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
/// CSS Class: Constructs an HL7 CSS Segment Object
/// </summary>
public class CSS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CSS()
		{
			Name = "CSS";
			Description = "Clinical Study Data Schedule Segment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CSS1());
			fs.Add(CSS2());
			fs.Add(CSS3());
			Fields = fs;
		}
		private Field CSS1()
		{
			Field f = new Field("Study Scheduled Time Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CSS-1.1"));
			c.Add(new Component("", "CSS-1.2"));
			c.Add(new Component("Name of Coding System", "CSS-1.3"));
			c.Add(new Component("Alternate Identifier", "CSS-1.4"));
			c.Add(new Component("Alternate Text", "CSS-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "CSS-1.6"));
			f.Components = c;
			return f;
		}
		private Field CSS2()
		{
			Field f = new Field("Study Scheduled Patient Time Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CSS-2.1"));
			c.Add(new Component("Degree of Precision", "CSS-2.2"));
			f.Components = c;
			return f;
		}
		private Field CSS3()
		{
			Field f = new Field("Study Quality Control Codes");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CSS-3.1"));
			c.Add(new Component("", "CSS-3.2"));
			c.Add(new Component("Name of Coding System", "CSS-3.3"));
			c.Add(new Component("Alternate Identifier", "CSS-3.4"));
			c.Add(new Component("Alternate Text", "CSS-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "CSS-3.6"));
			f.Components = c;
			return f;
		}
	}
}
