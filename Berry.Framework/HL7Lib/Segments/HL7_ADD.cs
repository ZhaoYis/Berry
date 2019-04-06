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
    /// ADD Class: Constructs an HL7 ADD Segment Object
    /// </summary>
	public class ADD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ADD()
		{
			Name = "ADD";
			Description = "Addendum";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ADD1());
			Fields = fs;
		}
		private Field ADD1()
		{
			Field f = new Field("Addendum Continuation Pointer");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ADD-1.1"));
			f.Components = c;
			return f;
		}
	}
}
