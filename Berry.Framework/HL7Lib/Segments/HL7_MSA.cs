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
/// MSA Class: Constructs an HL7 MSA Segment Object
/// </summary>
public class MSA
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public MSA()
		{
			Name = "MSA";
			Description = "Message Acknowledgment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(MSA1());
			fs.Add(MSA2());
			fs.Add(MSA3());
			fs.Add(MSA4());
			fs.Add(MSA5());
			fs.Add(MSA6());
			Fields = fs;
		}
		private Field MSA1()
		{
			Field f = new Field("Acknowledgment Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MSA-1.1"));
			f.Components = c;
			return f;
		}
		private Field MSA2()
		{
			Field f = new Field("Message Control ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MSA-2.1"));
			f.Components = c;
			return f;
		}
		private Field MSA3()
		{
			Field f = new Field("Text Message");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MSA-3.1"));
			f.Components = c;
			return f;
		}
		private Field MSA4()
		{
			Field f = new Field("Expected Sequence Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MSA-4.1"));
			f.Components = c;
			return f;
		}
		private Field MSA5()
		{
			Field f = new Field("Delayed Acknowledgment Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "MSA-5.1"));
			f.Components = c;
			return f;
		}
		private Field MSA6()
		{
			Field f = new Field("Error Condition");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "MSA-6.1"));
			c.Add(new Component("", "MSA-6.2"));
			c.Add(new Component("Name of Coding System", "MSA-6.3"));
			c.Add(new Component("Alternate Identifier", "MSA-6.4"));
			c.Add(new Component("Alternate Text", "MSA-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "MSA-6.6"));
			f.Components = c;
			return f;
		}
	}
}
