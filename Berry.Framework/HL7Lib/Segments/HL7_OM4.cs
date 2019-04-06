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
/// OM4 Class: Constructs an HL7 OM4 Segment Object
/// </summary>
public class OM4
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OM4()
		{
			Name = "OM4";
			Description = "Observations that Require Specimens";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OM41());
			fs.Add(OM42());
			fs.Add(OM43());
			fs.Add(OM44());
			fs.Add(OM45());
			fs.Add(OM46());
			fs.Add(OM47());
			fs.Add(OM48());
			fs.Add(OM49());
			fs.Add(OM410());
			fs.Add(OM411());
			fs.Add(OM412());
			fs.Add(OM413());
			fs.Add(OM414());
			Fields = fs;
		}
		private Field OM41()
		{
			Field f = new Field("Sequence Number - Test/Observation Master File");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM4-1.1"));
			f.Components = c;
			return f;
		}
		private Field OM42()
		{
			Field f = new Field("Derived Specimen");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM4-2.1"));
			f.Components = c;
			return f;
		}
		private Field OM43()
		{
			Field f = new Field("Container Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM4-3.1"));
			f.Components = c;
			return f;
		}
		private Field OM44()
		{
			Field f = new Field("Container Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM4-4.1"));
			f.Components = c;
			return f;
		}
		private Field OM45()
		{
			Field f = new Field("Container Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM4-5.1"));
			c.Add(new Component("", "OM4-5.2"));
			c.Add(new Component("Name of Coding System", "OM4-5.3"));
			c.Add(new Component("Alternate Identifier", "OM4-5.4"));
			c.Add(new Component("Alternate Text", "OM4-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM4-5.6"));
			f.Components = c;
			return f;
		}
		private Field OM46()
		{
			Field f = new Field("Specimen");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM4-6.1"));
			c.Add(new Component("", "OM4-6.2"));
			c.Add(new Component("Name of Coding System", "OM4-6.3"));
			c.Add(new Component("Alternate Identifier", "OM4-6.4"));
			c.Add(new Component("Alternate Text", "OM4-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM4-6.6"));
			f.Components = c;
			return f;
		}
		private Field OM47()
		{
			Field f = new Field("Additive");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM4-7.1"));
			c.Add(new Component("", "OM4-7.2"));
			c.Add(new Component("Name of Coding System", "OM4-7.3"));
			c.Add(new Component("Alternate Identifier", "OM4-7.4"));
			c.Add(new Component("Alternate Text", "OM4-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM4-7.6"));
			c.Add(new Component("Coding System Version ID", "OM4-7.7"));
			c.Add(new Component("Alternate Coding System Version ID", "OM4-7.8"));
			c.Add(new Component("Original Text", "OM4-7.9"));
			f.Components = c;
			return f;
		}
		private Field OM48()
		{
			Field f = new Field("Preparation");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM4-8.1"));
			f.Components = c;
			return f;
		}
		private Field OM49()
		{
			Field f = new Field("Special Handling Requirements");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM4-9.1"));
			f.Components = c;
			return f;
		}
		private Field OM410()
		{
			Field f = new Field("Normal Collection Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "OM4-10.1"));
			c.Add(new Component("Units", "OM4-10.2"));
			f.Components = c;
			return f;
		}
		private Field OM411()
		{
			Field f = new Field("Minimum Collection Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "OM4-11.1"));
			c.Add(new Component("Units", "OM4-11.2"));
			f.Components = c;
			return f;
		}
		private Field OM412()
		{
			Field f = new Field("Specimen Requirements");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM4-12.1"));
			f.Components = c;
			return f;
		}
		private Field OM413()
		{
			Field f = new Field("Specimen Priorities");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM4-13.1"));
			f.Components = c;
			return f;
		}
		private Field OM414()
		{
			Field f = new Field("Specimen Retention Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "OM4-14.1"));
			c.Add(new Component("Units", "OM4-14.2"));
			f.Components = c;
			return f;
		}
	}
}
