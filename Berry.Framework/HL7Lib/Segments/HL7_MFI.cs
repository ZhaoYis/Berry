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
/// MFI Class: Constructs an HL7 MFI Segment Object
/// </summary>
public class MFI
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public MFI()
		{
			Name = "MFI";
			Description = "Master File Identification";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(MFI1());
			fs.Add(MFI2());
			fs.Add(MFI3());
			fs.Add(MFI4());
			fs.Add(MFI5());
			fs.Add(MFI6());
			Fields = fs;
		}
		private Field MFI1()
		{
			Field f = new Field("Master File Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "MFI-1.1"));
			c.Add(new Component("", "MFI-1.2"));
			c.Add(new Component("Name of Coding System", "MFI-1.3"));
			c.Add(new Component("Alternate Identifier", "MFI-1.4"));
			c.Add(new Component("Alternate Text", "MFI-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "MFI-1.6"));
			f.Components = c;
			return f;
		}
		private Field MFI2()
		{
			Field f = new Field("Master File Application Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "MFI-2.1"));
			c.Add(new Component("Universal ID", "MFI-2.2"));
			c.Add(new Component("Universal ID Type", "MFI-2.3"));
			f.Components = c;
			return f;
		}
		private Field MFI3()
		{
			Field f = new Field("File-Level Event Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MFI-3.1"));
			f.Components = c;
			return f;
		}
		private Field MFI4()
		{
			Field f = new Field("Entered Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "MFI-4.1"));
			c.Add(new Component("Degree of Precision", "MFI-4.2"));
			f.Components = c;
			return f;
		}
		private Field MFI5()
		{
			Field f = new Field("Effective Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "MFI-5.1"));
			c.Add(new Component("Degree of Precision", "MFI-5.2"));
			f.Components = c;
			return f;
		}
		private Field MFI6()
		{
			Field f = new Field("Response Level Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MFI-6.1"));
			f.Components = c;
			return f;
		}
	}
}
