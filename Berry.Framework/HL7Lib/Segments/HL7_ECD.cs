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
/// ECD Class: Constructs an HL7 ECD Segment Object
/// </summary>
public class ECD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ECD()
		{
			Name = "ECD";
			Description = "Equipment Command";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ECD1());
			fs.Add(ECD2());
			fs.Add(ECD3());
			fs.Add(ECD4());
			fs.Add(ECD5());
			Fields = fs;
		}
		private Field ECD1()
		{
			Field f = new Field("Reference Command Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ECD-1.1"));
			f.Components = c;
			return f;
		}
		private Field ECD2()
		{
			Field f = new Field("Remote Control Command");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ECD-2.1"));
			c.Add(new Component("", "ECD-2.2"));
			c.Add(new Component("Name of Coding System", "ECD-2.3"));
			c.Add(new Component("Alternate Identifier", "ECD-2.4"));
			c.Add(new Component("Alternate Text", "ECD-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "ECD-2.6"));
			f.Components = c;
			return f;
		}
		private Field ECD3()
		{
			Field f = new Field("Response Required");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ECD-3.1"));
			f.Components = c;
			return f;
		}
		private Field ECD4()
		{
			Field f = new Field("Requested Completion Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "ECD-4.1"));
			c.Add(new Component("Interval", "ECD-4.2"));
			c.Add(new Component("Duration", "ECD-4.3"));
			c.Add(new Component("Start Date/Time", "ECD-4.4"));
			c.Add(new Component("End Date Time", "ECD-4.5"));
			c.Add(new Component("Priority", "ECD-4.6"));
			c.Add(new Component("Condition", "ECD-4.7"));
			c.Add(new Component("", "ECD-4.8"));
			c.Add(new Component("Conjunction", "ECD-4.9"));
			c.Add(new Component("Order Sequencing", "ECD-4.10"));
			c.Add(new Component("Occurrence Duration", "ECD-4.11"));
			c.Add(new Component("Total Occurrences", "ECD-4.12"));
			f.Components = c;
			return f;
		}
		private Field ECD5()
		{
			Field f = new Field("Parameters");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ECD-5.1"));
			f.Components = c;
			return f;
		}
	}
}
