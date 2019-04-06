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
/// RCP Class: Constructs an HL7 RCP Segment Object
/// </summary>
public class RCP
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RCP()
		{
			Name = "RCP";
			Description = "Response Control Parameter";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RCP1());
			fs.Add(RCP2());
			fs.Add(RCP3());
			fs.Add(RCP4());
			fs.Add(RCP5());
			fs.Add(RCP6());
			fs.Add(RCP7());
			Fields = fs;
		}
		private Field RCP1()
		{
			Field f = new Field("Query Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RCP-1.1"));
			f.Components = c;
			return f;
		}
		private Field RCP2()
		{
			Field f = new Field("Quantity Limited Request");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "RCP-2.1"));
			c.Add(new Component("Units", "RCP-2.2"));
			f.Components = c;
			return f;
		}
		private Field RCP3()
		{
			Field f = new Field("Response Modality");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RCP-3.1"));
			c.Add(new Component("", "RCP-3.2"));
			c.Add(new Component("Name of Coding System", "RCP-3.3"));
			c.Add(new Component("Alternate Identifier", "RCP-3.4"));
			c.Add(new Component("Alternate Text", "RCP-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "RCP-3.6"));
			f.Components = c;
			return f;
		}
		private Field RCP4()
		{
			Field f = new Field("Execution and Delivery Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RCP-4.1"));
			c.Add(new Component("Degree of Precision", "RCP-4.2"));
			f.Components = c;
			return f;
		}
		private Field RCP5()
		{
			Field f = new Field("Modify Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RCP-5.1"));
			f.Components = c;
			return f;
		}
		private Field RCP6()
		{
			Field f = new Field("Sort-by Field");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sort By Field", "RCP-6.1"));
			c.Add(new Component("Sequencing", "RCP-6.2"));
			f.Components = c;
			return f;
		}
		private Field RCP7()
		{
			Field f = new Field("Segment group inclusion");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RCP-7.1"));
			f.Components = c;
			return f;
		}
	}
}
