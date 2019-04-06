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
/// QID Class: Constructs an HL7 QID Segment Object
/// </summary>
public class QID
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public QID()
		{
			Name = "QID";
			Description = "Query Identification";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(QID1());
			fs.Add(QID2());
			Fields = fs;
		}
		private Field QID1()
		{
			Field f = new Field("Query Tag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QID-1.1"));
			f.Components = c;
			return f;
		}
		private Field QID2()
		{
			Field f = new Field("Message Query Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "QID-2.1"));
			c.Add(new Component("", "QID-2.2"));
			c.Add(new Component("Name of Coding System", "QID-2.3"));
			c.Add(new Component("Alternate Identifier", "QID-2.4"));
			c.Add(new Component("Alternate Text", "QID-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "QID-2.6"));
			f.Components = c;
			return f;
		}
	}
}
