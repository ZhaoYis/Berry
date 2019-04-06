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
/// RDF Class: Constructs an HL7 RDF Segment Object
/// </summary>
public class RDF
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RDF()
		{
			Name = "RDF";
			Description = "Table Row Definition";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RDF1());
			fs.Add(RDF2());
			Fields = fs;
		}
		private Field RDF1()
		{
			Field f = new Field("Number of Columns per Row");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RDF-1.1"));
			f.Components = c;
			return f;
		}
		private Field RDF2()
		{
			Field f = new Field("Column Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("Segment Field Name", "RDF-2.1"));
			c.Add(new Component("HL7 Data Type", "RDF-2.2"));
			c.Add(new Component("Maximum Column Width", "RDF-2.3"));
			f.Components = c;
			return f;
		}
	}
}
