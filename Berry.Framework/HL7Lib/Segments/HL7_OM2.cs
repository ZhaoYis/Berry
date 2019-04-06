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
/// OM2 Class: Constructs an HL7 OM2 Segment Object
/// </summary>
public class OM2
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OM2()
		{
			Name = "OM2";
			Description = "Numeric Observation";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OM21());
			fs.Add(OM22());
			fs.Add(OM23());
			fs.Add(OM24());
			fs.Add(OM25());
			fs.Add(OM26());
			fs.Add(OM27());
			fs.Add(OM28());
			fs.Add(OM29());
			fs.Add(OM210());
			Fields = fs;
		}
		private Field OM21()
		{
			Field f = new Field("Sequence Number - Test/Observation Master File");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM2-1.1"));
			f.Components = c;
			return f;
		}
		private Field OM22()
		{
			Field f = new Field("Units of Measure");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM2-2.1"));
			c.Add(new Component("", "OM2-2.2"));
			c.Add(new Component("Name of Coding System", "OM2-2.3"));
			c.Add(new Component("Alternate Identifier", "OM2-2.4"));
			c.Add(new Component("Alternate Text", "OM2-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM2-2.6"));
			f.Components = c;
			return f;
		}
		private Field OM23()
		{
			Field f = new Field("Range of Decimal Precision");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM2-3.1"));
			f.Components = c;
			return f;
		}
		private Field OM24()
		{
			Field f = new Field("Corresponding SI Units of Measure");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM2-4.1"));
			c.Add(new Component("", "OM2-4.2"));
			c.Add(new Component("Name of Coding System", "OM2-4.3"));
			c.Add(new Component("Alternate Identifier", "OM2-4.4"));
			c.Add(new Component("Alternate Text", "OM2-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM2-4.6"));
			f.Components = c;
			return f;
		}
		private Field OM25()
		{
			Field f = new Field("SI Conversion Factor");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM2-5.1"));
			f.Components = c;
			return f;
		}
		private Field OM26()
		{
			Field f = new Field("Reference (Normal) Range - Ordinal and Continuous Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("Numeric Range", "OM2-6.1"));
			c.Add(new Component("Administrative Sex", "OM2-6.2"));
			c.Add(new Component("Age Range", "OM2-6.3"));
			c.Add(new Component("Gestational Age Range", "OM2-6.4"));
			c.Add(new Component("Species", "OM2-6.5"));
			c.Add(new Component("Race Sub-Species", "OM2-6.6"));
			c.Add(new Component("Conditions", "OM2-6.7"));
			f.Components = c;
			return f;
		}
		private Field OM27()
		{
			Field f = new Field("Critical Range for Ordinal and Continuous Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("Numeric Range", "OM2-7.1"));
			c.Add(new Component("Administrative Sex", "OM2-7.2"));
			c.Add(new Component("Age Range", "OM2-7.3"));
			c.Add(new Component("Gestational Age Range", "OM2-7.4"));
			c.Add(new Component("Species", "OM2-7.5"));
			c.Add(new Component("Race Sub-Species", "OM2-7.6"));
			c.Add(new Component("Conditions", "OM2-7.7"));
			f.Components = c;
			return f;
		}
		private Field OM28()
		{
			Field f = new Field("Absolute Range for Ordinal and Continuous Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("Numeric Range", "OM2-8.1"));
			c.Add(new Component("Administrative Sex", "OM2-8.2"));
			c.Add(new Component("Age Range", "OM2-8.3"));
			c.Add(new Component("Gestational Age Range", "OM2-8.4"));
			c.Add(new Component("Species", "OM2-8.5"));
			c.Add(new Component("Race Sub-Species", "OM2-8.6"));
			c.Add(new Component("Conditions", "OM2-8.7"));
			f.Components = c;
			return f;
		}
		private Field OM29()
		{
			Field f = new Field("Delta Check Criteria");
			List<Component> c = new List<Component>();
			c.Add(new Component("Normal Range", "OM2-9.1"));
			c.Add(new Component("Numeric Threshold", "OM2-9.2"));
			c.Add(new Component("Change Computation", "OM2-9.3"));
			c.Add(new Component("Days Retained", "OM2-9.4"));
			f.Components = c;
			return f;
		}
		private Field OM210()
		{
			Field f = new Field("Minimum Meaningful Increments");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM2-10.1"));
			f.Components = c;
			return f;
		}
	}
}
