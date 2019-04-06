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
/// TCD Class: Constructs an HL7 TCD Segment Object
/// </summary>
public class TCD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public TCD()
		{
			Name = "TCD";
			Description = "Test Code Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(TCD1());
			fs.Add(TCD2());
			fs.Add(TCD3());
			fs.Add(TCD4());
			fs.Add(TCD5());
			fs.Add(TCD6());
			fs.Add(TCD7());
			fs.Add(TCD8());
			Fields = fs;
		}
		private Field TCD1()
		{
			Field f = new Field("Universal Service Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "TCD-1.1"));
			c.Add(new Component("", "TCD-1.2"));
			c.Add(new Component("Name of Coding System", "TCD-1.3"));
			c.Add(new Component("Alternate Identifier", "TCD-1.4"));
			c.Add(new Component("Alternate Text", "TCD-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "TCD-1.6"));
			f.Components = c;
			return f;
		}
		private Field TCD2()
		{
			Field f = new Field("Auto-Dilution Factor");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCD-2.1"));
			c.Add(new Component("", "TCD-2.2"));
			c.Add(new Component("Seperator Suffix", "TCD-2.3"));
			c.Add(new Component("", "TCD-2.4"));
			f.Components = c;
			return f;
		}
		private Field TCD3()
		{
			Field f = new Field("Rerun Dilution Factor");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCD-3.1"));
			c.Add(new Component("", "TCD-3.2"));
			c.Add(new Component("Seperator Suffix", "TCD-3.3"));
			c.Add(new Component("", "TCD-3.4"));
			f.Components = c;
			return f;
		}
		private Field TCD4()
		{
			Field f = new Field("Pre-Dilution Factor");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCD-4.1"));
			c.Add(new Component("", "TCD-4.2"));
			c.Add(new Component("Seperator Suffix", "TCD-4.3"));
			c.Add(new Component("", "TCD-4.4"));
			f.Components = c;
			return f;
		}
		private Field TCD5()
		{
			Field f = new Field("Endogenous Content of Pre-Dilution Diluent");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCD-5.1"));
			c.Add(new Component("", "TCD-5.2"));
			c.Add(new Component("Seperator Suffix", "TCD-5.3"));
			c.Add(new Component("", "TCD-5.4"));
			f.Components = c;
			return f;
		}
		private Field TCD6()
		{
			Field f = new Field("Automatic Repeat Allowed");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TCD-6.1"));
			f.Components = c;
			return f;
		}
		private Field TCD7()
		{
			Field f = new Field("Reflex Allowed");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TCD-7.1"));
			f.Components = c;
			return f;
		}
		private Field TCD8()
		{
			Field f = new Field("Analyte Repeat Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "TCD-8.1"));
			c.Add(new Component("", "TCD-8.2"));
			c.Add(new Component("Name of Coding System", "TCD-8.3"));
			c.Add(new Component("Alternate Identifier", "TCD-8.4"));
			c.Add(new Component("Alternate Text", "TCD-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "TCD-8.6"));
			f.Components = c;
			return f;
		}
	}
}
