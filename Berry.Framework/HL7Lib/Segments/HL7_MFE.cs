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
/// MFE Class: Constructs an HL7 MFE Segment Object
/// </summary>
public class MFE
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public MFE()
		{
			Name = "MFE";
			Description = "Master File Entry";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(MFE1());
			fs.Add(MFE2());
			fs.Add(MFE3());
            fs.Add(MFE4());
			fs.Add(MFE5());
			Fields = fs;
		}
		private Field MFE1()
		{
			Field f = new Field("Record-Level Event Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MFE-1.1"));
			f.Components = c;
			return f;
		}
		private Field MFE2()
		{
			Field f = new Field("MFN Control ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MFE-2.1"));
			f.Components = c;
			return f;
		}
		private Field MFE3()
		{
			Field f = new Field("Effective Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "MFE-3.1"));
			c.Add(new Component("Degree of Precision", "MFE-3.2"));
			f.Components = c;
			return f;
		}
        private Field MFE4()
        {
            Field f = new Field("");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MFE-4.1"));
            f.Components = c;
            return f;
        }
		private Field MFE5()
		{
			Field f = new Field("Primary Key Value Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MFE-5.1"));
			f.Components = c;
			return f;
		}
	}
}
