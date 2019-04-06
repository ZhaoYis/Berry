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
/// SID Class: Constructs an HL7 SID Segment Object
/// </summary>
public class SID
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public SID()
		{
			Name = "SID";
			Description = "Substance Identifier";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(SID1());
			fs.Add(SID2());
			fs.Add(SID3());
			fs.Add(SID4());
			Fields = fs;
		}
		private Field SID1()
		{
			Field f = new Field("Application / Method Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SID-1.1"));
			c.Add(new Component("", "SID-1.2"));
			c.Add(new Component("Name of Coding System", "SID-1.3"));
			c.Add(new Component("Alternate Identifier", "SID-1.4"));
			c.Add(new Component("Alternate Text", "SID-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "SID-1.6"));
			f.Components = c;
			return f;
		}
		private Field SID2()
		{
			Field f = new Field("Substance Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SID-2.1"));
			f.Components = c;
			return f;
		}
		private Field SID3()
		{
			Field f = new Field("Substance Container Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SID-3.1"));
			f.Components = c;
			return f;
		}
		private Field SID4()
		{
			Field f = new Field("Substance Manufacturer Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SID-4.1"));
			c.Add(new Component("", "SID-4.2"));
			c.Add(new Component("Name of Coding System", "SID-4.3"));
			c.Add(new Component("Alternate Identifier", "SID-4.4"));
			c.Add(new Component("Alternate Text", "SID-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "SID-4.6"));
			f.Components = c;
			return f;
		}
	}
}
