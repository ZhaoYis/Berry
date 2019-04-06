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
/// EQP Class: Constructs an HL7 EQP Segment Object
/// </summary>
public class EQP
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public EQP()
		{
			Name = "EQP";
			Description = "Equipment/log Service";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(EQP1());
			fs.Add(EQP2());
			fs.Add(EQP3());
			fs.Add(EQP4());
			fs.Add(EQP5());
			Fields = fs;
		}
		private Field EQP1()
		{
			Field f = new Field("Event type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "EQP-1.1"));
			c.Add(new Component("", "EQP-1.2"));
			c.Add(new Component("Name of Coding System", "EQP-1.3"));
			c.Add(new Component("Alternate Identifier", "EQP-1.4"));
			c.Add(new Component("Alternate Text", "EQP-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "EQP-1.6"));
			f.Components = c;
			return f;
		}
		private Field EQP2()
		{
			Field f = new Field("File Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EQP-2.1"));
			f.Components = c;
			return f;
		}
		private Field EQP3()
		{
			Field f = new Field("Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "EQP-3.1"));
			c.Add(new Component("Degree of Precision", "EQP-3.2"));
			f.Components = c;
			return f;
		}
		private Field EQP4()
		{
			Field f = new Field("End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "EQP-4.1"));
			c.Add(new Component("Degree of Precision", "EQP-4.2"));
			f.Components = c;
			return f;
		}
		private Field EQP5()
		{
			Field f = new Field("Transaction Data");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "EQP-5.1"));
			f.Components = c;
			return f;
		}
	}
}
