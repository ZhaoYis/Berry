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
/// CON Class: Constructs an HL7 CON Segment Object
/// </summary>
public class CON
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CON()
		{
			Name = "CON";
			Description = "Consent Segment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CON1());
			fs.Add(CON2());
			fs.Add(CON3());
			fs.Add(CON4());
			fs.Add(CON5());
			fs.Add(CON6());
			fs.Add(CON7());
			fs.Add(CON8());
			fs.Add(CON9());
			fs.Add(CON10());
			fs.Add(CON11());
			fs.Add(CON12());
			fs.Add(CON13());
			fs.Add(CON14());
			fs.Add(CON15());
			fs.Add(CON16());
			fs.Add(CON17());
			fs.Add(CON18());
			fs.Add(CON19());
			fs.Add(CON20());
			fs.Add(CON21());
			fs.Add(CON22());
			fs.Add(CON23());
			fs.Add(CON24());
			fs.Add(CON25());
			Fields = fs;
		}
		private Field CON1()
		{
			Field f = new Field("Set ID - CON");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "CON-1.1"));
			f.Components = c;
			return f;
		}
		private Field CON2()
		{
			Field f = new Field("Consent Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CON-2.1"));
			c.Add(new Component("", "CON-2.2"));
			c.Add(new Component("Name of Coding System", "CON-2.3"));
			c.Add(new Component("Alternate Identifier", "CON-2.4"));
			c.Add(new Component("Alternate Text", "CON-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "CON-2.6"));
			c.Add(new Component("Coding System Version ID", "CON-2.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CON-2.8"));
			c.Add(new Component("Original Text", "CON-2.9"));
			f.Components = c;
			return f;
		}
		private Field CON3()
		{
			Field f = new Field("Consent Form ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-3.1"));
			f.Components = c;
			return f;
		}
		private Field CON4()
		{
			Field f = new Field("Consent Form Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "CON-4.1"));
			c.Add(new Component("Namespace ID", "CON-4.2"));
			c.Add(new Component("Universal ID", "CON-4.3"));
			c.Add(new Component("Universal ID Type", "CON-4.4"));
			f.Components = c;
			return f;
		}
		private Field CON5()
		{
			Field f = new Field("Consent Text");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-5.1"));
			f.Components = c;
			return f;
		}
		private Field CON6()
		{
			Field f = new Field("Subject-specific Consent Text");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-6.1"));
			f.Components = c;
			return f;
		}
		private Field CON7()
		{
			Field f = new Field("Consent Background");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-7.1"));
			f.Components = c;
			return f;
		}
		private Field CON8()
		{
			Field f = new Field("Subject-specific Consent Background");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-8.1"));
			f.Components = c;
			return f;
		}
		private Field CON9()
		{
			Field f = new Field("Consenter-imposed limitations");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-9.1"));
			f.Components = c;
			return f;
		}
		private Field CON10()
		{
			Field f = new Field("Consent Mode");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CON-10.1"));
			c.Add(new Component("", "CON-10.2"));
			c.Add(new Component("Name of Coding System", "CON-10.3"));
			c.Add(new Component("Alternate Identifier", "CON-10.4"));
			c.Add(new Component("Alternate Text", "CON-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "CON-10.6"));
			c.Add(new Component("Coding System Version ID", "CON-10.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CON-10.8"));
			c.Add(new Component("Original Text", "CON-10.9"));
			f.Components = c;
			return f;
		}
		private Field CON11()
		{
			Field f = new Field("Consent Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CON-11.1"));
			c.Add(new Component("", "CON-11.2"));
			c.Add(new Component("Name of Coding System", "CON-11.3"));
			c.Add(new Component("Alternate Identifier", "CON-11.4"));
			c.Add(new Component("Alternate Text", "CON-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "CON-11.6"));
			c.Add(new Component("Coding System Version ID", "CON-11.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CON-11.8"));
			c.Add(new Component("Original Text", "CON-11.9"));
			f.Components = c;
			return f;
		}
		private Field CON12()
		{
			Field f = new Field("Consent Discussion Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CON-12.1"));
			c.Add(new Component("Degree of Precision", "CON-12.2"));
			f.Components = c;
			return f;
		}
		private Field CON13()
		{
			Field f = new Field("Consent Decision Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CON-13.1"));
			c.Add(new Component("Degree of Precision", "CON-13.2"));
			f.Components = c;
			return f;
		}
		private Field CON14()
		{
			Field f = new Field("Consent Effective Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CON-14.1"));
			c.Add(new Component("Degree of Precision", "CON-14.2"));
			f.Components = c;
			return f;
		}
		private Field CON15()
		{
			Field f = new Field("Consent End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CON-15.1"));
			c.Add(new Component("Degree of Precision", "CON-15.2"));
			f.Components = c;
			return f;
		}
		private Field CON16()
		{
			Field f = new Field("Subject Competence Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-16.1"));
			f.Components = c;
			return f;
		}
		private Field CON17()
		{
			Field f = new Field("Translator Assistance Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-17.1"));
			f.Components = c;
			return f;
		}
		private Field CON18()
		{
			Field f = new Field("Language Translated To");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-18.1"));
			f.Components = c;
			return f;
		}
		private Field CON19()
		{
			Field f = new Field("Informational Material Supplied Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-19.1"));
			f.Components = c;
			return f;
		}
		private Field CON20()
		{
			Field f = new Field("Consent Bypass Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CON-20.1"));
			c.Add(new Component("", "CON-20.2"));
			c.Add(new Component("Name of Coding System", "CON-20.3"));
			c.Add(new Component("Alternate Identifier", "CON-20.4"));
			c.Add(new Component("Alternate Text", "CON-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "CON-20.6"));
			c.Add(new Component("Coding System Version ID", "CON-20.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CON-20.8"));
			c.Add(new Component("Original Text", "CON-20.9"));
			f.Components = c;
			return f;
		}
		private Field CON21()
		{
			Field f = new Field("Consent Disclosure Level");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-21.1"));
			f.Components = c;
			return f;
		}
		private Field CON22()
		{
			Field f = new Field("Consent Non-disclosure Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CON-22.1"));
			c.Add(new Component("", "CON-22.2"));
			c.Add(new Component("Name of Coding System", "CON-22.3"));
			c.Add(new Component("Alternate Identifier", "CON-22.4"));
			c.Add(new Component("Alternate Text", "CON-22.5"));
			c.Add(new Component("Name of Alternate Coding System", "CON-22.6"));
			c.Add(new Component("Coding System Version ID", "CON-22.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CON-22.8"));
			c.Add(new Component("Original Text", "CON-22.9"));
			f.Components = c;
			return f;
		}
		private Field CON23()
		{
			Field f = new Field("Non-subject Consenter Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CON-23.1"));
			c.Add(new Component("", "CON-23.2"));
			c.Add(new Component("Name of Coding System", "CON-23.3"));
			c.Add(new Component("Alternate Identifier", "CON-23.4"));
			c.Add(new Component("Alternate Text", "CON-23.5"));
			c.Add(new Component("Name of Alternate Coding System", "CON-23.6"));
			c.Add(new Component("Coding System Version ID", "CON-23.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CON-23.8"));
			c.Add(new Component("Original Text", "CON-23.9"));
			f.Components = c;
			return f;
		}
		private Field CON24()
		{
			Field f = new Field("Consenter ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "CON-24.1"));
			c.Add(new Component("Given Name", "CON-24.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "CON-24.3"));
			c.Add(new Component("Suffix", "CON-24.4"));
			c.Add(new Component("Prefix", "CON-24.5"));
			c.Add(new Component("Degree", "CON-24.6"));
			c.Add(new Component("Name Type Code", "CON-24.7"));
			c.Add(new Component("Name Respresentation Code", "CON-24.8"));
			c.Add(new Component("Name Context", "CON-24.9"));
			c.Add(new Component("Name Validity Range", "CON-24.10"));
			c.Add(new Component("Name Assembly Order", "CON-24.11"));
			c.Add(new Component("Effective Date", "CON-24.12"));
			c.Add(new Component("Expiration Date", "CON-24.13"));
			c.Add(new Component("Professional Suffix", "CON-24.14"));
			f.Components = c;
			return f;
		}
		private Field CON25()
		{
			Field f = new Field("Relationship to Subject Table");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CON-25.1"));
			f.Components = c;
			return f;
		}
	}
}
