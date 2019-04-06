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
/// SPM Class: Constructs an HL7 SPM Segment Object
/// </summary>
public class SPM
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public SPM()
		{
			Name = "SPM";
			Description = "Specimen";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(SPM1());
			fs.Add(SPM2());
			fs.Add(SPM3());
			fs.Add(SPM4());
			fs.Add(SPM5());
			fs.Add(SPM6());
			fs.Add(SPM7());
			fs.Add(SPM8());
			fs.Add(SPM9());
			fs.Add(SPM10());
			fs.Add(SPM11());
			fs.Add(SPM12());
			fs.Add(SPM13());
			fs.Add(SPM14());
			fs.Add(SPM15());
			fs.Add(SPM16());
			fs.Add(SPM17());
			fs.Add(SPM18());
			fs.Add(SPM19());
			fs.Add(SPM20());
			fs.Add(SPM21());
			fs.Add(SPM22());
			fs.Add(SPM23());
			fs.Add(SPM24());
			fs.Add(SPM25());
			fs.Add(SPM26());
			fs.Add(SPM27());
			fs.Add(SPM28());
			fs.Add(SPM29());
			Fields = fs;
		}
		private Field SPM1()
		{
			Field f = new Field("Set ID _ SPM");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "SPM-1.1"));
			f.Components = c;
			return f;
		}
		private Field SPM2()
		{
			Field f = new Field("Specimen ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Placer Assigned Identifier", "SPM-2.1"));
			c.Add(new Component("Filler Assigned Identifier", "SPM-2.2"));
			f.Components = c;
			return f;
		}
		private Field SPM3()
		{
			Field f = new Field("Specimen Parent IDs");
			List<Component> c = new List<Component>();
			c.Add(new Component("Placer Assigned Identifier", "SPM-3.1"));
			c.Add(new Component("Filler Assigned Identifier", "SPM-3.2"));
			f.Components = c;
			return f;
		}
		private Field SPM4()
		{
			Field f = new Field("Specimen Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-4.1"));
			c.Add(new Component("", "SPM-4.2"));
			c.Add(new Component("Name of Coding System", "SPM-4.3"));
			c.Add(new Component("Alternate Identifier", "SPM-4.4"));
			c.Add(new Component("Alternate Text", "SPM-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-4.6"));
			c.Add(new Component("Coding System Version ID", "SPM-4.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-4.8"));
			c.Add(new Component("Original Text", "SPM-4.9"));
			f.Components = c;
			return f;
		}
		private Field SPM5()
		{
			Field f = new Field("Specimen Type Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-5.1"));
			c.Add(new Component("", "SPM-5.2"));
			c.Add(new Component("Name of Coding System", "SPM-5.3"));
			c.Add(new Component("Alternate Identifier", "SPM-5.4"));
			c.Add(new Component("Alternate Text", "SPM-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-5.6"));
			c.Add(new Component("Coding System Version ID", "SPM-5.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-5.8"));
			c.Add(new Component("Original Text", "SPM-5.9"));
			f.Components = c;
			return f;
		}
		private Field SPM6()
		{
			Field f = new Field("Specimen Additives");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-6.1"));
			c.Add(new Component("", "SPM-6.2"));
			c.Add(new Component("Name of Coding System", "SPM-6.3"));
			c.Add(new Component("Alternate Identifier", "SPM-6.4"));
			c.Add(new Component("Alternate Text", "SPM-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-6.6"));
			c.Add(new Component("Coding System Version ID", "SPM-6.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-6.8"));
			c.Add(new Component("Original Text", "SPM-6.9"));
			f.Components = c;
			return f;
		}
		private Field SPM7()
		{
			Field f = new Field("Specimen Collection Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-7.1"));
			c.Add(new Component("", "SPM-7.2"));
			c.Add(new Component("Name of Coding System", "SPM-7.3"));
			c.Add(new Component("Alternate Identifier", "SPM-7.4"));
			c.Add(new Component("Alternate Text", "SPM-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-7.6"));
			c.Add(new Component("Coding System Version ID", "SPM-7.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-7.8"));
			c.Add(new Component("Original Text", "SPM-7.9"));
			f.Components = c;
			return f;
		}
		private Field SPM8()
		{
			Field f = new Field("Specimen Source Site");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-8.1"));
			c.Add(new Component("", "SPM-8.2"));
			c.Add(new Component("Name of Coding System", "SPM-8.3"));
			c.Add(new Component("Alternate Identifier", "SPM-8.4"));
			c.Add(new Component("Alternate Text", "SPM-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-8.6"));
			c.Add(new Component("Coding System Version ID", "SPM-8.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-8.8"));
			c.Add(new Component("Original Text", "SPM-8.9"));
			f.Components = c;
			return f;
		}
		private Field SPM9()
		{
			Field f = new Field("Specimen Source Site Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-9.1"));
			c.Add(new Component("", "SPM-9.2"));
			c.Add(new Component("Name of Coding System", "SPM-9.3"));
			c.Add(new Component("Alternate Identifier", "SPM-9.4"));
			c.Add(new Component("Alternate Text", "SPM-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-9.6"));
			c.Add(new Component("Coding System Version ID", "SPM-9.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-9.8"));
			c.Add(new Component("Original Text", "SPM-9.9"));
			f.Components = c;
			return f;
		}
		private Field SPM10()
		{
			Field f = new Field("Specimen Collection Site");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-10.1"));
			c.Add(new Component("", "SPM-10.2"));
			c.Add(new Component("Name of Coding System", "SPM-10.3"));
			c.Add(new Component("Alternate Identifier", "SPM-10.4"));
			c.Add(new Component("Alternate Text", "SPM-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-10.6"));
			c.Add(new Component("Coding System Version ID", "SPM-10.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-10.8"));
			c.Add(new Component("Original Text", "SPM-10.9"));
			f.Components = c;
			return f;
		}
		private Field SPM11()
		{
			Field f = new Field("Specimen Role");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-11.1"));
			c.Add(new Component("", "SPM-11.2"));
			c.Add(new Component("Name of Coding System", "SPM-11.3"));
			c.Add(new Component("Alternate Identifier", "SPM-11.4"));
			c.Add(new Component("Alternate Text", "SPM-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-11.6"));
			c.Add(new Component("Coding System Version ID", "SPM-11.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-11.8"));
			c.Add(new Component("Original Text", "SPM-11.9"));
			f.Components = c;
			return f;
		}
		private Field SPM12()
		{
			Field f = new Field("Specimen Collection Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "SPM-12.1"));
			c.Add(new Component("Units", "SPM-12.2"));
			f.Components = c;
			return f;
		}
		private Field SPM13()
		{
			Field f = new Field("Grouped Specimen Count");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SPM-13.1"));
			f.Components = c;
			return f;
		}
		private Field SPM14()
		{
			Field f = new Field("Specimen Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SPM-14.1"));
			f.Components = c;
			return f;
		}
		private Field SPM15()
		{
			Field f = new Field("Specimen Handling Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-15.1"));
			c.Add(new Component("", "SPM-15.2"));
			c.Add(new Component("Name of Coding System", "SPM-15.3"));
			c.Add(new Component("Alternate Identifier", "SPM-15.4"));
			c.Add(new Component("Alternate Text", "SPM-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-15.6"));
			c.Add(new Component("Coding System Version ID", "SPM-15.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-15.8"));
			c.Add(new Component("Original Text", "SPM-15.9"));
			f.Components = c;
			return f;
		}
		private Field SPM16()
		{
			Field f = new Field("Specimen Risk Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-16.1"));
			c.Add(new Component("", "SPM-16.2"));
			c.Add(new Component("Name of Coding System", "SPM-16.3"));
			c.Add(new Component("Alternate Identifier", "SPM-16.4"));
			c.Add(new Component("Alternate Text", "SPM-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-16.6"));
			c.Add(new Component("Coding System Version ID", "SPM-16.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-16.8"));
			c.Add(new Component("Original Text", "SPM-16.9"));
			f.Components = c;
			return f;
		}
		private Field SPM17()
		{
			Field f = new Field("Specimen Collection Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Range Start Date/Time", "SPM-17.1"));
			c.Add(new Component("Range End Date/Time", "SPM-17.2"));
			f.Components = c;
			return f;
		}
		private Field SPM18()
		{
			Field f = new Field("Specimen Received Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "SPM-18.1"));
			c.Add(new Component("Degree of Precision", "SPM-18.2"));
			f.Components = c;
			return f;
		}
		private Field SPM19()
		{
			Field f = new Field("Specimen Expiration Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "SPM-19.1"));
			c.Add(new Component("Degree of Precision", "SPM-19.2"));
			f.Components = c;
			return f;
		}
		private Field SPM20()
		{
			Field f = new Field("Specimen Availability");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SPM-20.1"));
			f.Components = c;
			return f;
		}
		private Field SPM21()
		{
			Field f = new Field("Specimen Reject Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-21.1"));
			c.Add(new Component("", "SPM-21.2"));
			c.Add(new Component("Name of Coding System", "SPM-21.3"));
			c.Add(new Component("Alternate Identifier", "SPM-21.4"));
			c.Add(new Component("Alternate Text", "SPM-21.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-21.6"));
			c.Add(new Component("Coding System Version ID", "SPM-21.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-21.8"));
			c.Add(new Component("Original Text", "SPM-21.9"));
			f.Components = c;
			return f;
		}
		private Field SPM22()
		{
			Field f = new Field("Specimen Quality");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-22.1"));
			c.Add(new Component("", "SPM-22.2"));
			c.Add(new Component("Name of Coding System", "SPM-22.3"));
			c.Add(new Component("Alternate Identifier", "SPM-22.4"));
			c.Add(new Component("Alternate Text", "SPM-22.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-22.6"));
			c.Add(new Component("Coding System Version ID", "SPM-22.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-22.8"));
			c.Add(new Component("Original Text", "SPM-22.9"));
			f.Components = c;
			return f;
		}
		private Field SPM23()
		{
			Field f = new Field("Specimen Appropriateness");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-23.1"));
			c.Add(new Component("", "SPM-23.2"));
			c.Add(new Component("Name of Coding System", "SPM-23.3"));
			c.Add(new Component("Alternate Identifier", "SPM-23.4"));
			c.Add(new Component("Alternate Text", "SPM-23.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-23.6"));
			c.Add(new Component("Coding System Version ID", "SPM-23.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-23.8"));
			c.Add(new Component("Original Text", "SPM-23.9"));
			f.Components = c;
			return f;
		}
		private Field SPM24()
		{
			Field f = new Field("Specimen Condition");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-24.1"));
			c.Add(new Component("", "SPM-24.2"));
			c.Add(new Component("Name of Coding System", "SPM-24.3"));
			c.Add(new Component("Alternate Identifier", "SPM-24.4"));
			c.Add(new Component("Alternate Text", "SPM-24.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-24.6"));
			c.Add(new Component("Coding System Version ID", "SPM-24.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-24.8"));
			c.Add(new Component("Original Text", "SPM-24.9"));
			f.Components = c;
			return f;
		}
		private Field SPM25()
		{
			Field f = new Field("Specimen Current Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "SPM-25.1"));
			c.Add(new Component("Units", "SPM-25.2"));
			f.Components = c;
			return f;
		}
		private Field SPM26()
		{
			Field f = new Field("Number of Specimen Containers");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "SPM-26.1"));
			f.Components = c;
			return f;
		}
		private Field SPM27()
		{
			Field f = new Field("Container Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-27.1"));
			c.Add(new Component("", "SPM-27.2"));
			c.Add(new Component("Name of Coding System", "SPM-27.3"));
			c.Add(new Component("Alternate Identifier", "SPM-27.4"));
			c.Add(new Component("Alternate Text", "SPM-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-27.6"));
			c.Add(new Component("Coding System Version ID", "SPM-27.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-27.8"));
			c.Add(new Component("Original Text", "SPM-27.9"));
			f.Components = c;
			return f;
		}
		private Field SPM28()
		{
			Field f = new Field("Container Condition");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-28.1"));
			c.Add(new Component("", "SPM-28.2"));
			c.Add(new Component("Name of Coding System", "SPM-28.3"));
			c.Add(new Component("Alternate Identifier", "SPM-28.4"));
			c.Add(new Component("Alternate Text", "SPM-28.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-28.6"));
			c.Add(new Component("Coding System Version ID", "SPM-28.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-28.8"));
			c.Add(new Component("Original Text", "SPM-28.9"));
			f.Components = c;
			return f;
		}
		private Field SPM29()
		{
			Field f = new Field("Specimen Child Role");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "SPM-29.1"));
			c.Add(new Component("", "SPM-29.2"));
			c.Add(new Component("Name of Coding System", "SPM-29.3"));
			c.Add(new Component("Alternate Identifier", "SPM-29.4"));
			c.Add(new Component("Alternate Text", "SPM-29.5"));
			c.Add(new Component("Name of Alternate Coding System", "SPM-29.6"));
			c.Add(new Component("Coding System Version ID", "SPM-29.7"));
			c.Add(new Component("Alternate Coding System Version ID", "SPM-29.8"));
			c.Add(new Component("Original Text", "SPM-29.9"));
			f.Components = c;
			return f;
		}
	}
}
