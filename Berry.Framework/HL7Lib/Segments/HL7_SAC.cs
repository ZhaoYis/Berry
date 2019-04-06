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
/// SAC Class: Constructs an HL7 SAC Segment Object
/// </summary>
public class SAC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public SAC()
		{
			Name = "SAC";
			Description = "Specimen Container detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(SAC1());
			fs.Add(SAC2());
			fs.Add(SAC3());
			fs.Add(SAC4());
			fs.Add(SAC5());
			fs.Add(SAC6());
			fs.Add(SAC7());
			fs.Add(SAC8());
			fs.Add(SAC9());
			fs.Add(SAC10());
			fs.Add(SAC11());
			fs.Add(SAC12());
			fs.Add(SAC13());
			fs.Add(SAC14());
			fs.Add(SAC15());
			fs.Add(SAC16());
			fs.Add(SAC17());
			fs.Add(SAC18());
			fs.Add(SAC19());
			fs.Add(SAC20());
			fs.Add(SAC21());
			fs.Add(SAC22());
			fs.Add(SAC23());
			fs.Add(SAC24());
			fs.Add(SAC25());
			fs.Add(SAC26());
			fs.Add(SAC27());
			fs.Add(SAC28());
			fs.Add(SAC29());
			fs.Add(SAC30());
			fs.Add(SAC31());
			fs.Add(SAC32());
			fs.Add(SAC33());
			fs.Add(SAC34());
			fs.Add(SAC35());
			fs.Add(SAC36());
			fs.Add(SAC37());
			fs.Add(SAC38());
			fs.Add(SAC39());
			fs.Add(SAC40());
			fs.Add(SAC41());
			fs.Add(SAC42());
			fs.Add(SAC43());
			fs.Add(SAC44());
			Fields = fs;
		}
		private Field SAC1()
		{
			Field f = new Field("External Accession Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SAC-1.1"));
			c.Add(new Component("Namespace ID", "SAC-1.2"));
			c.Add(new Component("Universal ID", "SAC-1.3"));
			c.Add(new Component("Universal ID Type", "SAC-1.4"));
			f.Components = c;
			return f;
		}
		private Field SAC2()
		{
			Field f = new Field("Accession Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SAC-2.1"));
			c.Add(new Component("Namespace ID", "SAC-2.2"));
			c.Add(new Component("Universal ID", "SAC-2.3"));
			c.Add(new Component("Universal ID Type", "SAC-2.4"));
			f.Components = c;
			return f;
		}
		private Field SAC3()
		{
			Field f = new Field("Container Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SAC-3.1"));
			c.Add(new Component("Namespace ID", "SAC-3.2"));
			c.Add(new Component("Universal ID", "SAC-3.3"));
			c.Add(new Component("Universal ID Type", "SAC-3.4"));
			f.Components = c;
			return f;
		}
		private Field SAC4()
		{
			Field f = new Field("Primary (parent) Container Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SAC-4.1"));
			c.Add(new Component("Namespace ID", "SAC-4.2"));
			c.Add(new Component("Universal ID", "SAC-4.3"));
			c.Add(new Component("Universal ID Type", "SAC-4.4"));
			f.Components = c;
			return f;
		}
		private Field SAC5()
		{
			Field f = new Field("Equipment Container Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SAC-5.1"));
			c.Add(new Component("Namespace ID", "SAC-5.2"));
			c.Add(new Component("Universal ID", "SAC-5.3"));
			c.Add(new Component("Universal ID Type", "SAC-5.4"));
			f.Components = c;
			return f;
		}
		private Field SAC6()
		{
			Field f = new Field("Specimen Source");
			List<Component> c = new List<Component>();
			c.Add(new Component("Specimen Source Name or Code", "SAC-6.1"));
			c.Add(new Component("Additives", "SAC-6.2"));
			c.Add(new Component("Specimen Collection Method", "SAC-6.3"));
			c.Add(new Component("Body Site", "SAC-6.4"));
			c.Add(new Component("Site Modifier", "SAC-6.5"));
			c.Add(new Component("Collection Method Modifier Code", "SAC-6.6"));
			c.Add(new Component("Specimen Role", "SAC-6.7"));
			f.Components = c;
			return f;
		}
		private Field SAC7()
		{
			Field f = new Field("Registration Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "SAC-7.1"));
			c.Add(new Component("Degree of Precision", "SAC-7.2"));
			f.Components = c;
			return f;
		}
		private Field SAC8()
		{
			Field f = new Field("Container Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-8.1"));
			c.Add(new Component("", "SAC-8.2"));
			c.Add(new Component("Name of Coding System", "SAC-8.3"));
			c.Add(new Component("Alternate Identifier", "SAC-8.4"));
			c.Add(new Component("Alternate Text", "SAC-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-8.6"));
			f.Components = c;
			return f;
		}
		private Field SAC9()
		{
			Field f = new Field("Carrier Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-9.1"));
			c.Add(new Component("", "SAC-9.2"));
			c.Add(new Component("Name of Coding System", "SAC-9.3"));
			c.Add(new Component("Alternate Identifier", "SAC-9.4"));
			c.Add(new Component("Alternate Text", "SAC-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-9.6"));
			f.Components = c;
			return f;
		}
		private Field SAC10()
		{
			Field f = new Field("Carrier Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SAC-10.1"));
			c.Add(new Component("Namespace ID", "SAC-10.2"));
			c.Add(new Component("Universal ID", "SAC-10.3"));
			c.Add(new Component("Universal ID Type", "SAC-10.4"));
			f.Components = c;
			return f;
		}
		private Field SAC11()
		{
			Field f = new Field("Position in Carrier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Value", "SAC-11.1"));
			c.Add(new Component("Value", "SAC-11.2"));
			c.Add(new Component("Value", "SAC-11.3"));
			c.Add(new Component("Value", "SAC-11.4"));
			f.Components = c;
			return f;
		}
		private Field SAC12()
		{
			Field f = new Field("Tray Type - SAC");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-12.1"));
			c.Add(new Component("", "SAC-12.2"));
			c.Add(new Component("Name of Coding System", "SAC-12.3"));
			c.Add(new Component("Alternate Identifier", "SAC-12.4"));
			c.Add(new Component("Alternate Text", "SAC-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-12.6"));
			f.Components = c;
			return f;
		}
		private Field SAC13()
		{
			Field f = new Field("Tray Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "SAC-13.1"));
			c.Add(new Component("Namespace ID", "SAC-13.2"));
			c.Add(new Component("Universal ID", "SAC-13.3"));
			c.Add(new Component("Universal ID Type", "SAC-13.4"));
			f.Components = c;
			return f;
		}
		private Field SAC14()
		{
			Field f = new Field("Position in Tray");
			List<Component> c = new List<Component>();
			c.Add(new Component("Value", "SAC-14.1"));
			c.Add(new Component("Value", "SAC-14.2"));
			c.Add(new Component("Value", "SAC-14.3"));
			c.Add(new Component("Value", "SAC-14.4"));
			f.Components = c;
			return f;
		}
		private Field SAC15()
		{
			Field f = new Field("Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-15.1"));
			c.Add(new Component("", "SAC-15.2"));
			c.Add(new Component("Name of Coding System", "SAC-15.3"));
			c.Add(new Component("Alternate Identifier", "SAC-15.4"));
			c.Add(new Component("Alternate Text", "SAC-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-15.6"));
			f.Components = c;
			return f;
		}
		private Field SAC16()
		{
			Field f = new Field("Container Height");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-16.1"));
			f.Components = c;
			return f;
		}
		private Field SAC17()
		{
			Field f = new Field("Container Diameter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-17.1"));
			f.Components = c;
			return f;
		}
		private Field SAC18()
		{
			Field f = new Field("Barrier Delta");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-18.1"));
			f.Components = c;
			return f;
		}
		private Field SAC19()
		{
			Field f = new Field("Bottom Delta");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-19.1"));
			f.Components = c;
			return f;
		}
		private Field SAC20()
		{
			Field f = new Field("Container Height/Diameter/Delta Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-20.1"));
			c.Add(new Component("", "SAC-20.2"));
			c.Add(new Component("Name of Coding System", "SAC-20.3"));
			c.Add(new Component("Alternate Identifier", "SAC-20.4"));
			c.Add(new Component("Alternate Text", "SAC-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-20.6"));
			f.Components = c;
			return f;
		}
		private Field SAC21()
		{
			Field f = new Field("Container Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-21.1"));
			f.Components = c;
			return f;
		}
		private Field SAC22()
		{
			Field f = new Field("Available Specimen Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-22.1"));
			f.Components = c;
			return f;
		}
		private Field SAC23()
		{
			Field f = new Field("Initial Specimen Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-23.1"));
			f.Components = c;
			return f;
		}
		private Field SAC24()
		{
			Field f = new Field("Volume Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-24.1"));
			c.Add(new Component("", "SAC-24.2"));
			c.Add(new Component("Name of Coding System", "SAC-24.3"));
			c.Add(new Component("Alternate Identifier", "SAC-24.4"));
			c.Add(new Component("Alternate Text", "SAC-24.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-24.6"));
			f.Components = c;
			return f;
		}
		private Field SAC25()
		{
			Field f = new Field("Separator Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-25.1"));
			c.Add(new Component("", "SAC-25.2"));
			c.Add(new Component("Name of Coding System", "SAC-25.3"));
			c.Add(new Component("Alternate Identifier", "SAC-25.4"));
			c.Add(new Component("Alternate Text", "SAC-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-25.6"));
			f.Components = c;
			return f;
		}
		private Field SAC26()
		{
			Field f = new Field("Cap Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-26.1"));
			c.Add(new Component("", "SAC-26.2"));
			c.Add(new Component("Name of Coding System", "SAC-26.3"));
			c.Add(new Component("Alternate Identifier", "SAC-26.4"));
			c.Add(new Component("Alternate Text", "SAC-26.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-26.6"));
			f.Components = c;
			return f;
		}
		private Field SAC27()
		{
			Field f = new Field("Additive");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-27.1"));
			c.Add(new Component("", "SAC-27.2"));
			c.Add(new Component("Name of Coding System", "SAC-27.3"));
			c.Add(new Component("Alternate Identifier", "SAC-27.4"));
			c.Add(new Component("Alternate Text", "SAC-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-27.6"));
			c.Add(new Component("Coding System Version ID", "SAC-27.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SAC-27.8"));
			c.Add(new Component("Original Text", "SAC-27.9"));
			f.Components = c;
			return f;
		}
		private Field SAC28()
		{
			Field f = new Field("Specimen Component");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-28.1"));
			c.Add(new Component("", "SAC-28.2"));
			c.Add(new Component("Name of Coding System", "SAC-28.3"));
			c.Add(new Component("Alternate Identifier", "SAC-28.4"));
			c.Add(new Component("Alternate Text", "SAC-28.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-28.6"));
			f.Components = c;
			return f;
		}
		private Field SAC29()
		{
			Field f = new Field("Dilution Factor");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "SAC-29.1"));
			c.Add(new Component("", "SAC-29.2"));
			c.Add(new Component("Seperator Suffix", "SAC-29.3"));
			c.Add(new Component("", "SAC-29.4"));
			f.Components = c;
			return f;
		}
		private Field SAC30()
		{
			Field f = new Field("Treatment");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-30.1"));
			c.Add(new Component("", "SAC-30.2"));
			c.Add(new Component("Name of Coding System", "SAC-30.3"));
			c.Add(new Component("Alternate Identifier", "SAC-30.4"));
			c.Add(new Component("Alternate Text", "SAC-30.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-30.6"));
			f.Components = c;
			return f;
		}
		private Field SAC31()
		{
			Field f = new Field("Temperature");
			List<Component> c = new List<Component>();
			c.Add(new Component("Comparator", "SAC-31.1"));
			c.Add(new Component("", "SAC-31.2"));
			c.Add(new Component("Seperator Suffix", "SAC-31.3"));
			c.Add(new Component("", "SAC-31.4"));
			f.Components = c;
			return f;
		}
		private Field SAC32()
		{
			Field f = new Field("Hemolysis Index");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-32.1"));
			f.Components = c;
			return f;
		}
		private Field SAC33()
		{
			Field f = new Field("Hemolysis Index Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-33.1"));
			c.Add(new Component("", "SAC-33.2"));
			c.Add(new Component("Name of Coding System", "SAC-33.3"));
			c.Add(new Component("Alternate Identifier", "SAC-33.4"));
			c.Add(new Component("Alternate Text", "SAC-33.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-33.6"));
			f.Components = c;
			return f;
		}
		private Field SAC34()
		{
			Field f = new Field("Lipemia Index");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-34.1"));
			f.Components = c;
			return f;
		}
		private Field SAC35()
		{
			Field f = new Field("Lipemia Index Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-35.1"));
			c.Add(new Component("", "SAC-35.2"));
			c.Add(new Component("Name of Coding System", "SAC-35.3"));
			c.Add(new Component("Alternate Identifier", "SAC-35.4"));
			c.Add(new Component("Alternate Text", "SAC-35.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-35.6"));
			f.Components = c;
			return f;
		}
		private Field SAC36()
		{
			Field f = new Field("Icterus Index");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-36.1"));
			f.Components = c;
			return f;
		}
		private Field SAC37()
		{
			Field f = new Field("Icterus Index Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-37.1"));
			c.Add(new Component("", "SAC-37.2"));
			c.Add(new Component("Name of Coding System", "SAC-37.3"));
			c.Add(new Component("Alternate Identifier", "SAC-37.4"));
			c.Add(new Component("Alternate Text", "SAC-37.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-37.6"));
			f.Components = c;
			return f;
		}
		private Field SAC38()
		{
			Field f = new Field("Fibrin Index");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SAC-38.1"));
			f.Components = c;
			return f;
		}
		private Field SAC39()
		{
			Field f = new Field("Fibrin Index Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-39.1"));
			c.Add(new Component("", "SAC-39.2"));
			c.Add(new Component("Name of Coding System", "SAC-39.3"));
			c.Add(new Component("Alternate Identifier", "SAC-39.4"));
			c.Add(new Component("Alternate Text", "SAC-39.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-39.6"));
			f.Components = c;
			return f;
		}
		private Field SAC40()
		{
			Field f = new Field("System Induced Contaminants");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-40.1"));
			c.Add(new Component("", "SAC-40.2"));
			c.Add(new Component("Name of Coding System", "SAC-40.3"));
			c.Add(new Component("Alternate Identifier", "SAC-40.4"));
			c.Add(new Component("Alternate Text", "SAC-40.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-40.6"));
			f.Components = c;
			return f;
		}
		private Field SAC41()
		{
			Field f = new Field("Drug Interference");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-41.1"));
			c.Add(new Component("", "SAC-41.2"));
			c.Add(new Component("Name of Coding System", "SAC-41.3"));
			c.Add(new Component("Alternate Identifier", "SAC-41.4"));
			c.Add(new Component("Alternate Text", "SAC-41.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-41.6"));
			f.Components = c;
			return f;
		}
		private Field SAC42()
		{
			Field f = new Field("Artificial Blood");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-42.1"));
			c.Add(new Component("", "SAC-42.2"));
			c.Add(new Component("Name of Coding System", "SAC-42.3"));
			c.Add(new Component("Alternate Identifier", "SAC-42.4"));
			c.Add(new Component("Alternate Text", "SAC-42.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-42.6"));
			f.Components = c;
			return f;
		}
		private Field SAC43()
		{
			Field f = new Field("Special Handling Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-43.1"));
			c.Add(new Component("", "SAC-43.2"));
			c.Add(new Component("Name of Coding System", "SAC-43.3"));
			c.Add(new Component("Alternate Identifier", "SAC-43.4"));
			c.Add(new Component("Alternate Text", "SAC-43.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-43.6"));
			c.Add(new Component("Coding System Version ID", "SAC-43.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SAC-43.8"));
			c.Add(new Component("Original Text", "SAC-43.9"));
			f.Components = c;
			return f;
		}
		private Field SAC44()
		{
			Field f = new Field("Other Environmental Factors");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SAC-44.1"));
			c.Add(new Component("", "SAC-44.2"));
			c.Add(new Component("Name of Coding System", "SAC-44.3"));
			c.Add(new Component("Alternate Identifier", "SAC-44.4"));
			c.Add(new Component("Alternate Text", "SAC-44.5"));
			c.Add(new Component("Name of Alternate Coding System", "SAC-44.6"));
			f.Components = c;
			return f;
		}
	}
}
