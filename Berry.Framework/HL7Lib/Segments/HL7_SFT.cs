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
/// SFT Class: Constructs an HL7 SFT Segment Object
/// </summary>
public class SFT
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public SFT()
		{
			Name = "SFT";
			Description = "Software Segment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(SFT1());
			fs.Add(SFT2());
			fs.Add(SFT3());
			fs.Add(SFT4());
			fs.Add(SFT5());
			fs.Add(SFT6());
			Fields = fs;
		}
		private Field SFT1()
		{
			Field f = new Field("Software Vendor Organization");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "SFT-1.1"));
			c.Add(new Component("Organization Name Type Code", "SFT-1.2"));
			c.Add(new Component("ID Number", "SFT-1.3"));
			c.Add(new Component("Check Digit", "SFT-1.4"));
			c.Add(new Component("Check Digit Scheme", "SFT-1.5"));
			c.Add(new Component("Assigning Authority", "SFT-1.6"));
			c.Add(new Component("Identifier Type Code", "SFT-1.7"));
			c.Add(new Component("Assigning Facility", "SFT-1.8"));
			c.Add(new Component("Name Respresentation Code", "SFT-1.9"));
			c.Add(new Component("Organization Identifier", "SFT-1.10"));
			f.Components = c;
			return f;
		}
		private Field SFT2()
		{
			Field f = new Field("Software Certified Version or Release Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SFT-2.1"));
			f.Components = c;
			return f;
		}
		private Field SFT3()
		{
			Field f = new Field("Software Product Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SFT-3.1"));
			f.Components = c;
			return f;
		}
		private Field SFT4()
		{
			Field f = new Field("Software Binary ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SFT-4.1"));
			f.Components = c;
			return f;
		}
		private Field SFT5()
		{
			Field f = new Field("Software Product Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SFT-5.1"));
			f.Components = c;
			return f;
		}
		private Field SFT6()
		{
			Field f = new Field("Software Install Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "SFT-6.1"));
			c.Add(new Component("Degree of Precision", "SFT-6.2"));
			f.Components = c;
			return f;
		}
	}
}
