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
/// QAK Class: Constructs an HL7 QAK Segment Object
/// </summary>
public class QAK
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public QAK()
		{
			Name = "QAK";
			Description = "Query Acknowledgment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(QAK1());
			fs.Add(QAK2());
			fs.Add(QAK3());
			fs.Add(QAK4());
			fs.Add(QAK5());
			fs.Add(QAK6());
			Fields = fs;
		}
		private Field QAK1()
		{
			Field f = new Field("Query Tag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QAK-1.1"));
			f.Components = c;
			return f;
		}
		private Field QAK2()
		{
			Field f = new Field("Query Response Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QAK-2.1"));
			f.Components = c;
			return f;
		}
		private Field QAK3()
		{
			Field f = new Field("Message Query Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "QAK-3.1"));
			c.Add(new Component("", "QAK-3.2"));
			c.Add(new Component("Name of Coding System", "QAK-3.3"));
			c.Add(new Component("Alternate Identifier", "QAK-3.4"));
			c.Add(new Component("Alternate Text", "QAK-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "QAK-3.6"));
			f.Components = c;
			return f;
		}
		private Field QAK4()
		{
			Field f = new Field("Hit Count");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QAK-4.1"));
			f.Components = c;
			return f;
		}
		private Field QAK5()
		{
			Field f = new Field("This payload");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QAK-5.1"));
			f.Components = c;
			return f;
		}
		private Field QAK6()
		{
			Field f = new Field("Hits remaining");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QAK-6.1"));
			f.Components = c;
			return f;
		}
	}
}
