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
/// NCK Class: Constructs an HL7 NCK Segment Object
/// </summary>
public class NCK
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public NCK()
		{
			Name = "NCK";
			Description = "System Clock";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(NCK1());
			Fields = fs;
		}
		private Field NCK1()
		{
			Field f = new Field("System Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "NCK-1.1"));
			c.Add(new Component("Degree of Precision", "NCK-1.2"));
			f.Components = c;
			return f;
		}
	}
}
