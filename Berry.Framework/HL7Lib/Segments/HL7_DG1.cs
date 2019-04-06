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
/// DG1 Class: Constructs an HL7 DG1 Segment Object
/// </summary>
public class DG1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public DG1()
		{
			Name = "DG1";
			Description = "Diagnosis";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(DG11());
			fs.Add(DG12());
			fs.Add(DG13());
			fs.Add(DG14());
			fs.Add(DG15());
			fs.Add(DG16());
			fs.Add(DG17());
			fs.Add(DG18());
			fs.Add(DG19());
			fs.Add(DG110());
			fs.Add(DG111());
			fs.Add(DG112());
			fs.Add(DG113());
			fs.Add(DG114());
			fs.Add(DG115());
			fs.Add(DG116());
			fs.Add(DG117());
			fs.Add(DG118());
			fs.Add(DG119());
			fs.Add(DG120());
			fs.Add(DG121());
			Fields = fs;
		}
		private Field DG11()
		{
			Field f = new Field("Set ID - DG1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "DG1-1.1"));
			f.Components = c;
			return f;
		}
		private Field DG12()
		{
			Field f = new Field("Diagnosis Coding Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-2.1"));
			f.Components = c;
			return f;
		}
		private Field DG13()
		{
			Field f = new Field("Diagnosis Code - DG1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "DG1-3.1"));
			c.Add(new Component("", "DG1-3.2"));
			c.Add(new Component("Name of Coding System", "DG1-3.3"));
			c.Add(new Component("Alternate Identifier", "DG1-3.4"));
			c.Add(new Component("Alternate Text", "DG1-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "DG1-3.6"));
			f.Components = c;
			return f;
		}
		private Field DG14()
		{
			Field f = new Field("Diagnosis Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-4.1"));
			f.Components = c;
			return f;
		}
		private Field DG15()
		{
			Field f = new Field("Diagnosis Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "DG1-5.1"));
			c.Add(new Component("Degree of Precision", "DG1-5.2"));
			f.Components = c;
			return f;
		}
		private Field DG16()
		{
			Field f = new Field("Diagnosis Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-6.1"));
			f.Components = c;
			return f;
		}
		private Field DG17()
		{
			Field f = new Field("Major Diagnostic Category");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "DG1-7.1"));
			c.Add(new Component("", "DG1-7.2"));
			c.Add(new Component("Name of Coding System", "DG1-7.3"));
			c.Add(new Component("Alternate Identifier", "DG1-7.4"));
			c.Add(new Component("Alternate Text", "DG1-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "DG1-7.6"));
			f.Components = c;
			return f;
		}
		private Field DG18()
		{
			Field f = new Field("Diagnostic Related Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "DG1-8.1"));
			c.Add(new Component("", "DG1-8.2"));
			c.Add(new Component("Name of Coding System", "DG1-8.3"));
			c.Add(new Component("Alternate Identifier", "DG1-8.4"));
			c.Add(new Component("Alternate Text", "DG1-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "DG1-8.6"));
			f.Components = c;
			return f;
		}
		private Field DG19()
		{
			Field f = new Field("DRG Approval Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-9.1"));
			f.Components = c;
			return f;
		}
		private Field DG110()
		{
			Field f = new Field("DRG Grouper Review Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-10.1"));
			f.Components = c;
			return f;
		}
		private Field DG111()
		{
			Field f = new Field("Outlier Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "DG1-11.1"));
			c.Add(new Component("", "DG1-11.2"));
			c.Add(new Component("Name of Coding System", "DG1-11.3"));
			c.Add(new Component("Alternate Identifier", "DG1-11.4"));
			c.Add(new Component("Alternate Text", "DG1-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "DG1-11.6"));
			f.Components = c;
			return f;
		}
		private Field DG112()
		{
			Field f = new Field("Outlier Days");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-12.1"));
			f.Components = c;
			return f;
		}
		private Field DG113()
		{
			Field f = new Field("Outlier Cost");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "DG1-13.1"));
			c.Add(new Component("Price Type", "DG1-13.2"));
			c.Add(new Component("From Value", "DG1-13.3"));
			c.Add(new Component("To Value", "DG1-13.4"));
			c.Add(new Component("Range Units", "DG1-13.5"));
			c.Add(new Component("Range Type", "DG1-13.6"));
			f.Components = c;
			return f;
		}
		private Field DG114()
		{
			Field f = new Field("Grouper Version And Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-14.1"));
			f.Components = c;
			return f;
		}
		private Field DG115()
		{
			Field f = new Field("Diagnosis Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-15.1"));
			f.Components = c;
			return f;
		}
		private Field DG116()
		{
			Field f = new Field("Diagnosing Clinician");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "DG1-16.1"));
			c.Add(new Component("Family Name", "DG1-16.2"));
			c.Add(new Component("Given Name", "DG1-16.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "DG1-16.4"));
			c.Add(new Component("Suffix", "DG1-16.5"));
			c.Add(new Component("Prefix", "DG1-16.6"));
			c.Add(new Component("Degree", "DG1-16.7"));
			c.Add(new Component("Source Table", "DG1-16.8"));
			c.Add(new Component("Assigning Authority", "DG1-16.9"));
			c.Add(new Component("Name Type Code", "DG1-16.10"));
			c.Add(new Component("Identifier Check Digit", "DG1-16.11"));
			c.Add(new Component("Check Digit Scheme", "DG1-16.12"));
			c.Add(new Component("Identifier Type Code", "DG1-16.13"));
			c.Add(new Component("Assigning Facility", "DG1-16.14"));
			c.Add(new Component("Name Respresentation Code", "DG1-16.15"));
			c.Add(new Component("Name Context", "DG1-16.16"));
			c.Add(new Component("Name Validity Range", "DG1-16.17"));
			c.Add(new Component("Name Assembly Order", "DG1-16.18"));
			c.Add(new Component("Effective Date", "DG1-16.19"));
			c.Add(new Component("Expiration Date", "DG1-16.20"));
			c.Add(new Component("Professional Suffix", "DG1-16.21"));
			c.Add(new Component("Assigning Jurisdiction", "DG1-16.22"));
			c.Add(new Component("Assigning Agency or Department", "DG1-16.23"));
			f.Components = c;
			return f;
		}
		private Field DG117()
		{
			Field f = new Field("Diagnosis Classification");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-17.1"));
			f.Components = c;
			return f;
		}
		private Field DG118()
		{
			Field f = new Field("Confidential Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-18.1"));
			f.Components = c;
			return f;
		}
		private Field DG119()
		{
			Field f = new Field("Attestation Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "DG1-19.1"));
			c.Add(new Component("Degree of Precision", "DG1-19.2"));
			f.Components = c;
			return f;
		}
		private Field DG120()
		{
			Field f = new Field("Diagnosis Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "DG1-20.1"));
			c.Add(new Component("Namespace ID", "DG1-20.2"));
			c.Add(new Component("Universal ID", "DG1-20.3"));
			c.Add(new Component("Universal ID Type", "DG1-20.4"));
			f.Components = c;
			return f;
		}
		private Field DG121()
		{
			Field f = new Field("Diagnosis Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "DG1-21.1"));
			f.Components = c;
			return f;
		}
	}
}
