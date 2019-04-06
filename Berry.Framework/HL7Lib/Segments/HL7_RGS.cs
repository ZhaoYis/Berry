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
/// RGS Class: Constructs an HL7 RGS Segment Object
/// </summary>
public class RGS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RGS()
		{
			Name = "RGS";
			Description = "Resource Group";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RGS1());
			fs.Add(RGS2());
			fs.Add(RGS3());
			Fields = fs;
		}
		private Field RGS1()
		{
			Field f = new Field("Set ID - RGS");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "RGS-1.1"));
			f.Components = c;
			return f;
		}
		private Field RGS2()
		{
			Field f = new Field("Segment Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RGS-2.1"));
			f.Components = c;
			return f;
		}
		private Field RGS3()
		{
			Field f = new Field("Resource Group ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RGS-3.1"));
			c.Add(new Component("", "RGS-3.2"));
			c.Add(new Component("Name of Coding System", "RGS-3.3"));
			c.Add(new Component("Alternate Identifier", "RGS-3.4"));
			c.Add(new Component("Alternate Text", "RGS-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "RGS-3.6"));
			f.Components = c;
			return f;
		}
	}
}
