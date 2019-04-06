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
/// MFA Class: Constructs an HL7 MFA Segment Object
/// </summary>
public class MFA
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public MFA()
		{
			Name = "MFA";
			Description = "Master File Acknowledgment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(MFA1());
			fs.Add(MFA2());
			fs.Add(MFA3());
			fs.Add(MFA4());
            fs.Add(MFA5());
			fs.Add(MFA6());
			Fields = fs;
		}
		private Field MFA1()
		{
			Field f = new Field("Record-Level Event Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MFA-1.1"));
			f.Components = c;
			return f;
		}
		private Field MFA2()
		{
			Field f = new Field("MFN Control ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MFA-2.1"));
			f.Components = c;
			return f;
		}
		private Field MFA3()
		{
			Field f = new Field("Event Completion Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "MFA-3.1"));
			c.Add(new Component("Degree of Precision", "MFA-3.2"));
			f.Components = c;
			return f;
		}
		private Field MFA4()
		{
			Field f = new Field("MFN Record Level Error Return");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "MFA-4.1"));
			c.Add(new Component("", "MFA-4.2"));
			c.Add(new Component("Name of Coding System", "MFA-4.3"));
			c.Add(new Component("Alternate Identifier", "MFA-4.4"));
			c.Add(new Component("Alternate Text", "MFA-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "MFA-4.6"));
			f.Components = c;
			return f;
		}
        private Field MFA5()
        {
            Field f = new Field("");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "MFA-5.1"));
            f.Components = c;
            return f;
        }
		private Field MFA6()
		{
			Field f = new Field("Primary Key Value Type - MFA");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MFA-6.1"));
			f.Components = c;
			return f;
		}
	}
}
