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
/// PR1 Class: Constructs an HL7 PR1 Segment Object
/// </summary>
public class PR1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PR1()
		{
			Name = "PR1";
			Description = "Procedures";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PR11());
			fs.Add(PR12());
			fs.Add(PR13());
			fs.Add(PR14());
			fs.Add(PR15());
			fs.Add(PR16());
			fs.Add(PR17());
			fs.Add(PR18());
			fs.Add(PR19());
			fs.Add(PR110());
			fs.Add(PR111());
			fs.Add(PR112());
			fs.Add(PR113());
			fs.Add(PR114());
			fs.Add(PR115());
			fs.Add(PR116());
			fs.Add(PR117());
			fs.Add(PR118());
			fs.Add(PR119());
			fs.Add(PR120());
			Fields = fs;
		}
		private Field PR11()
		{
			Field f = new Field("Set ID - PR1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "PR1-1.1"));
			f.Components = c;
			return f;
		}
		private Field PR12()
		{
			Field f = new Field("Procedure Coding Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-2.1"));
			f.Components = c;
			return f;
		}
		private Field PR13()
		{
			Field f = new Field("Procedure Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PR1-3.1"));
			c.Add(new Component("", "PR1-3.2"));
			c.Add(new Component("Name of Coding System", "PR1-3.3"));
			c.Add(new Component("Alternate Identifier", "PR1-3.4"));
			c.Add(new Component("Alternate Text", "PR1-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "PR1-3.6"));
			f.Components = c;
			return f;
		}
		private Field PR14()
		{
			Field f = new Field("Procedure Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-4.1"));
			f.Components = c;
			return f;
		}
		private Field PR15()
		{
			Field f = new Field("Procedure Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PR1-5.1"));
			c.Add(new Component("Degree of Precision", "PR1-5.2"));
			f.Components = c;
			return f;
		}
		private Field PR16()
		{
			Field f = new Field("Procedure Functional Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-6.1"));
			f.Components = c;
			return f;
		}
		private Field PR17()
		{
			Field f = new Field("Procedure Minutes");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-7.1"));
			f.Components = c;
			return f;
		}
		private Field PR18()
		{
			Field f = new Field("Anesthesiologist");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PR1-8.1"));
			c.Add(new Component("Family Name", "PR1-8.2"));
			c.Add(new Component("Given Name", "PR1-8.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PR1-8.4"));
			c.Add(new Component("Suffix", "PR1-8.5"));
			c.Add(new Component("Prefix", "PR1-8.6"));
			c.Add(new Component("Degree", "PR1-8.7"));
			c.Add(new Component("Source Table", "PR1-8.8"));
			c.Add(new Component("Assigning Authority", "PR1-8.9"));
			c.Add(new Component("Name Type Code", "PR1-8.10"));
			c.Add(new Component("Identifier Check Digit", "PR1-8.11"));
			c.Add(new Component("Check Digit Scheme", "PR1-8.12"));
			c.Add(new Component("Identifier Type Code", "PR1-8.13"));
			c.Add(new Component("Assigning Facility", "PR1-8.14"));
			c.Add(new Component("Name Respresentation Code", "PR1-8.15"));
			c.Add(new Component("Name Context", "PR1-8.16"));
			c.Add(new Component("Name Validity Range", "PR1-8.17"));
			c.Add(new Component("Name Assembly Order", "PR1-8.18"));
			c.Add(new Component("Effective Date", "PR1-8.19"));
			c.Add(new Component("Expiration Date", "PR1-8.20"));
			c.Add(new Component("Professional Suffix", "PR1-8.21"));
			c.Add(new Component("Assigning Jurisdiction", "PR1-8.22"));
			c.Add(new Component("Assigning Agency or Department", "PR1-8.23"));
			f.Components = c;
			return f;
		}
		private Field PR19()
		{
			Field f = new Field("Anesthesia Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-9.1"));
			f.Components = c;
			return f;
		}
		private Field PR110()
		{
			Field f = new Field("Anesthesia Minutes");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-10.1"));
			f.Components = c;
			return f;
		}
		private Field PR111()
		{
			Field f = new Field("Surgeon");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PR1-11.1"));
			c.Add(new Component("Family Name", "PR1-11.2"));
			c.Add(new Component("Given Name", "PR1-11.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PR1-11.4"));
			c.Add(new Component("Suffix", "PR1-11.5"));
			c.Add(new Component("Prefix", "PR1-11.6"));
			c.Add(new Component("Degree", "PR1-11.7"));
			c.Add(new Component("Source Table", "PR1-11.8"));
			c.Add(new Component("Assigning Authority", "PR1-11.9"));
			c.Add(new Component("Name Type Code", "PR1-11.10"));
			c.Add(new Component("Identifier Check Digit", "PR1-11.11"));
			c.Add(new Component("Check Digit Scheme", "PR1-11.12"));
			c.Add(new Component("Identifier Type Code", "PR1-11.13"));
			c.Add(new Component("Assigning Facility", "PR1-11.14"));
			c.Add(new Component("Name Respresentation Code", "PR1-11.15"));
			c.Add(new Component("Name Context", "PR1-11.16"));
			c.Add(new Component("Name Validity Range", "PR1-11.17"));
			c.Add(new Component("Name Assembly Order", "PR1-11.18"));
			c.Add(new Component("Effective Date", "PR1-11.19"));
			c.Add(new Component("Expiration Date", "PR1-11.20"));
			c.Add(new Component("Professional Suffix", "PR1-11.21"));
			c.Add(new Component("Assigning Jurisdiction", "PR1-11.22"));
			c.Add(new Component("Assigning Agency or Department", "PR1-11.23"));
			f.Components = c;
			return f;
		}
		private Field PR112()
		{
			Field f = new Field("Procedure Practitioner");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PR1-12.1"));
			c.Add(new Component("Family Name", "PR1-12.2"));
			c.Add(new Component("Given Name", "PR1-12.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PR1-12.4"));
			c.Add(new Component("Suffix", "PR1-12.5"));
			c.Add(new Component("Prefix", "PR1-12.6"));
			c.Add(new Component("Degree", "PR1-12.7"));
			c.Add(new Component("Source Table", "PR1-12.8"));
			c.Add(new Component("Assigning Authority", "PR1-12.9"));
			c.Add(new Component("Name Type Code", "PR1-12.10"));
			c.Add(new Component("Identifier Check Digit", "PR1-12.11"));
			c.Add(new Component("Check Digit Scheme", "PR1-12.12"));
			c.Add(new Component("Identifier Type Code", "PR1-12.13"));
			c.Add(new Component("Assigning Facility", "PR1-12.14"));
			c.Add(new Component("Name Respresentation Code", "PR1-12.15"));
			c.Add(new Component("Name Context", "PR1-12.16"));
			c.Add(new Component("Name Validity Range", "PR1-12.17"));
			c.Add(new Component("Name Assembly Order", "PR1-12.18"));
			c.Add(new Component("Effective Date", "PR1-12.19"));
			c.Add(new Component("Expiration Date", "PR1-12.20"));
			c.Add(new Component("Professional Suffix", "PR1-12.21"));
			c.Add(new Component("Assigning Jurisdiction", "PR1-12.22"));
			c.Add(new Component("Assigning Agency or Department", "PR1-12.23"));
			f.Components = c;
			return f;
		}
		private Field PR113()
		{
			Field f = new Field("Consent Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PR1-13.1"));
			c.Add(new Component("", "PR1-13.2"));
			c.Add(new Component("Name of Coding System", "PR1-13.3"));
			c.Add(new Component("Alternate Identifier", "PR1-13.4"));
			c.Add(new Component("Alternate Text", "PR1-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "PR1-13.6"));
			f.Components = c;
			return f;
		}
		private Field PR114()
		{
			Field f = new Field("Procedure Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-14.1"));
			f.Components = c;
			return f;
		}
		private Field PR115()
		{
			Field f = new Field("Associated Diagnosis Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PR1-15.1"));
			c.Add(new Component("", "PR1-15.2"));
			c.Add(new Component("Name of Coding System", "PR1-15.3"));
			c.Add(new Component("Alternate Identifier", "PR1-15.4"));
			c.Add(new Component("Alternate Text", "PR1-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "PR1-15.6"));
			f.Components = c;
			return f;
		}
		private Field PR116()
		{
			Field f = new Field("Procedure Code Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PR1-16.1"));
			c.Add(new Component("", "PR1-16.2"));
			c.Add(new Component("Name of Coding System", "PR1-16.3"));
			c.Add(new Component("Alternate Identifier", "PR1-16.4"));
			c.Add(new Component("Alternate Text", "PR1-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "PR1-16.6"));
			f.Components = c;
			return f;
		}
		private Field PR117()
		{
			Field f = new Field("Procedure DRG Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-17.1"));
			f.Components = c;
			return f;
		}
		private Field PR118()
		{
			Field f = new Field("Tissue Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PR1-18.1"));
			c.Add(new Component("", "PR1-18.2"));
			c.Add(new Component("Name of Coding System", "PR1-18.3"));
			c.Add(new Component("Alternate Identifier", "PR1-18.4"));
			c.Add(new Component("Alternate Text", "PR1-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "PR1-18.6"));
			f.Components = c;
			return f;
		}
		private Field PR119()
		{
			Field f = new Field("Procedure Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "PR1-19.1"));
			c.Add(new Component("Namespace ID", "PR1-19.2"));
			c.Add(new Component("Universal ID", "PR1-19.3"));
			c.Add(new Component("Universal ID Type", "PR1-19.4"));
			f.Components = c;
			return f;
		}
		private Field PR120()
		{
			Field f = new Field("Procedure Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PR1-20.1"));
			f.Components = c;
			return f;
		}
	}
}
