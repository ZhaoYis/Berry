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
/// OM3 Class: Constructs an HL7 OM3 Segment Object
/// </summary>
public class OM3
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OM3()
		{
			Name = "OM3";
			Description = "Categorical Service/Test/Observation";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OM31());
			fs.Add(OM32());
			fs.Add(OM33());
			fs.Add(OM34());
			fs.Add(OM35());
			fs.Add(OM36());
			fs.Add(OM37());
			Fields = fs;
		}
		private Field OM31()
		{
			Field f = new Field("Sequence Number - Test/Observation Master File");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM3-1.1"));
			f.Components = c;
			return f;
		}
		private Field OM32()
		{
			Field f = new Field("Preferred Coding System");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM3-2.1"));
			c.Add(new Component("", "OM3-2.2"));
			c.Add(new Component("Name of Coding System", "OM3-2.3"));
			c.Add(new Component("Alternate Identifier", "OM3-2.4"));
			c.Add(new Component("Alternate Text", "OM3-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM3-2.6"));
			f.Components = c;
			return f;
		}
		private Field OM33()
		{
			Field f = new Field("Valid Coded Answers");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM3-3.1"));
			c.Add(new Component("", "OM3-3.2"));
			c.Add(new Component("Name of Coding System", "OM3-3.3"));
			c.Add(new Component("Alternate Identifier", "OM3-3.4"));
			c.Add(new Component("Alternate Text", "OM3-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM3-3.6"));
			f.Components = c;
			return f;
		}
		private Field OM34()
		{
			Field f = new Field("Normal Text/Codes for Categorical Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM3-4.1"));
			c.Add(new Component("", "OM3-4.2"));
			c.Add(new Component("Name of Coding System", "OM3-4.3"));
			c.Add(new Component("Alternate Identifier", "OM3-4.4"));
			c.Add(new Component("Alternate Text", "OM3-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM3-4.6"));
			f.Components = c;
			return f;
		}
		private Field OM35()
		{
			Field f = new Field("Abnormal Text/Codes for Categorical Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM3-5.1"));
			c.Add(new Component("", "OM3-5.2"));
			c.Add(new Component("Name of Coding System", "OM3-5.3"));
			c.Add(new Component("Alternate Identifier", "OM3-5.4"));
			c.Add(new Component("Alternate Text", "OM3-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM3-5.6"));
			f.Components = c;
			return f;
		}
		private Field OM36()
		{
			Field f = new Field("Critical Text/Codes for Categorical Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM3-6.1"));
			c.Add(new Component("", "OM3-6.2"));
			c.Add(new Component("Name of Coding System", "OM3-6.3"));
			c.Add(new Component("Alternate Identifier", "OM3-6.4"));
			c.Add(new Component("Alternate Text", "OM3-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM3-6.6"));
			f.Components = c;
			return f;
		}
		private Field OM37()
		{
			Field f = new Field("Value Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM3-7.1"));
			f.Components = c;
			return f;
		}
	}
}
