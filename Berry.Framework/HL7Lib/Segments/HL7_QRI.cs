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
/// QRI Class: Constructs an HL7 QRI Segment Object
/// </summary>
public class QRI
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public QRI()
		{
			Name = "QRI";
			Description = "Query Response Instance";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(QRI1());
			fs.Add(QRI2());
			fs.Add(QRI3());
			Fields = fs;
		}
		private Field QRI1()
		{
			Field f = new Field("Candidate Confidence");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRI-1.1"));
			f.Components = c;
			return f;
		}
		private Field QRI2()
		{
			Field f = new Field("Match Reason Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRI-2.1"));
			f.Components = c;
			return f;
		}
		private Field QRI3()
		{
			Field f = new Field("Algorithm Descriptor");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "QRI-3.1"));
			c.Add(new Component("", "QRI-3.2"));
			c.Add(new Component("Name of Coding System", "QRI-3.3"));
			c.Add(new Component("Alternate Identifier", "QRI-3.4"));
			c.Add(new Component("Alternate Text", "QRI-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "QRI-3.6"));
			f.Components = c;
			return f;
		}
	}
}
