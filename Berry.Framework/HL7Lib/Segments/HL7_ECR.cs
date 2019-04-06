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
/// ECR Class: Constructs an HL7 ECR Segment Object
/// </summary>
public class ECR
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ECR()
		{
			Name = "ECR";
			Description = "Equipment Command Response";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ECR1());
			fs.Add(ECR2());
			fs.Add(ECR3());
			Fields = fs;
		}
		private Field ECR1()
		{
			Field f = new Field("Command Response");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ECR-1.1"));
			c.Add(new Component("", "ECR-1.2"));
			c.Add(new Component("Name of Coding System", "ECR-1.3"));
			c.Add(new Component("Alternate Identifier", "ECR-1.4"));
			c.Add(new Component("Alternate Text", "ECR-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "ECR-1.6"));
			f.Components = c;
			return f;
		}
		private Field ECR2()
		{
			Field f = new Field("Date/Time Completed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ECR-2.1"));
			c.Add(new Component("Degree of Precision", "ECR-2.2"));
			f.Components = c;
			return f;
		}
		private Field ECR3()
		{
			Field f = new Field("Command Response Parameters");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ECR-3.1"));
			f.Components = c;
			return f;
		}
	}
}
