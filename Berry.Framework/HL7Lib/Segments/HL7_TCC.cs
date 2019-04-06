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
/// TCC Class: Constructs an HL7 TCC Segment Object
/// </summary>
public class TCC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public TCC()
		{
			Name = "TCC";
			Description = "Test Code Configuration";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(TCC1());
			fs.Add(TCC2());
			fs.Add(TCC3());
			fs.Add(TCC4());
			fs.Add(TCC5());
			fs.Add(TCC6());
			fs.Add(TCC7());
			fs.Add(TCC8());
			fs.Add(TCC9());
			fs.Add(TCC10());
			fs.Add(TCC11());
			fs.Add(TCC12());
			fs.Add(TCC13());
			fs.Add(TCC14());
			Fields = fs;
		}
		private Field TCC1()
		{
			Field f = new Field("Universal Service Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "TCC-1.1"));
			c.Add(new Component("", "TCC-1.2"));
			c.Add(new Component("Name of Coding System", "TCC-1.3"));
			c.Add(new Component("Alternate Identifier", "TCC-1.4"));
			c.Add(new Component("Alternate Text", "TCC-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "TCC-1.6"));
			f.Components = c;
			return f;
		}
		private Field TCC2()
		{
			Field f = new Field("Test Application Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "TCC-2.1"));
			c.Add(new Component("Namespace ID", "TCC-2.2"));
			c.Add(new Component("Universal ID", "TCC-2.3"));
			c.Add(new Component("Universal ID Type", "TCC-2.4"));
			f.Components = c;
			return f;
		}
		private Field TCC3()
		{
			Field f = new Field("Specimen Source");
			List<Component> c = new List<Component>();
			c.Add(new Component("Specimen Source Name or Code", "TCC-3.1"));
			c.Add(new Component("Additives", "TCC-3.2"));
			c.Add(new Component("Specimen Collection Method", "TCC-3.3"));
			c.Add(new Component("Body Site", "TCC-3.4"));
			c.Add(new Component("Site Modifier", "TCC-3.5"));
			c.Add(new Component("Collection Method Modifier Code", "TCC-3.6"));
			c.Add(new Component("Specimen Role", "TCC-3.7"));
			f.Components = c;
			return f;
		}
		private Field TCC4()
		{
			Field f = new Field("Auto-Dilution Factor Default");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCC-4.1"));
			c.Add(new Component("", "TCC-4.2"));
			c.Add(new Component("Seperator Suffix", "TCC-4.3"));
			c.Add(new Component("", "TCC-4.4"));
			f.Components = c;
			return f;
		}
		private Field TCC5()
		{
			Field f = new Field("Rerun Dilution Factor Default");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCC-5.1"));
			c.Add(new Component("", "TCC-5.2"));
			c.Add(new Component("Seperator Suffix", "TCC-5.3"));
			c.Add(new Component("", "TCC-5.4"));
			f.Components = c;
			return f;
		}
		private Field TCC6()
		{
			Field f = new Field("Pre-Dilution Factor Default");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCC-6.1"));
			c.Add(new Component("", "TCC-6.2"));
			c.Add(new Component("Seperator Suffix", "TCC-6.3"));
			c.Add(new Component("", "TCC-6.4"));
			f.Components = c;
			return f;
		}
		private Field TCC7()
		{
			Field f = new Field("Endogenous Content of Pre-Dilution Diluent");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCC-7.1"));
			c.Add(new Component("", "TCC-7.2"));
			c.Add(new Component("Seperator Suffix", "TCC-7.3"));
			c.Add(new Component("", "TCC-7.4"));
			f.Components = c;
			return f;
		}
		private Field TCC8()
		{
			Field f = new Field("Inventory Limits Warning Level");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TCC-8.1"));
			f.Components = c;
			return f;
		}
		private Field TCC9()
		{
			Field f = new Field("Automatic Rerun Allowed");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TCC-9.1"));
			f.Components = c;
			return f;
		}
		private Field TCC10()
		{
			Field f = new Field("Automatic Repeat Allowed");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TCC-10.1"));
			f.Components = c;
			return f;
		}
		private Field TCC11()
		{
			Field f = new Field("Automatic Reflex Allowed");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TCC-11.1"));
			f.Components = c;
			return f;
		}
		private Field TCC12()
		{
			Field f = new Field("Equipment Dynamic Range");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "TCC-12.1"));
			c.Add(new Component("", "TCC-12.2"));
			c.Add(new Component("Seperator Suffix", "TCC-12.3"));
			c.Add(new Component("", "TCC-12.4"));
			f.Components = c;
			return f;
		}
		private Field TCC13()
		{
			Field f = new Field("Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "TCC-13.1"));
			c.Add(new Component("", "TCC-13.2"));
			c.Add(new Component("Name of Coding System", "TCC-13.3"));
			c.Add(new Component("Alternate Identifier", "TCC-13.4"));
			c.Add(new Component("Alternate Text", "TCC-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "TCC-13.6"));
			f.Components = c;
			return f;
		}
		private Field TCC14()
		{
			Field f = new Field("Processing Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "TCC-14.1"));
			c.Add(new Component("", "TCC-14.2"));
			c.Add(new Component("Name of Coding System", "TCC-14.3"));
			c.Add(new Component("Alternate Identifier", "TCC-14.4"));
			c.Add(new Component("Alternate Text", "TCC-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "TCC-14.6"));
			f.Components = c;
			return f;
		}
	}
}
