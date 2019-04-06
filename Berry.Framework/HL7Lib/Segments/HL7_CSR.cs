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
/// CSR Class: Constructs an HL7 CSR Segment Object
/// </summary>
public class CSR
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CSR()
		{
			Name = "CSR";
			Description = "Clinical Study Registration";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CSR1());
			fs.Add(CSR2());
			fs.Add(CSR3());
			fs.Add(CSR4());
			fs.Add(CSR5());
			fs.Add(CSR6());
			fs.Add(CSR7());
			fs.Add(CSR8());
			fs.Add(CSR9());
			fs.Add(CSR10());
			fs.Add(CSR11());
			fs.Add(CSR12());
			fs.Add(CSR13());
			fs.Add(CSR14());
			fs.Add(CSR15());
			fs.Add(CSR16());
			Fields = fs;
		}
		private Field CSR1()
		{
			Field f = new Field("Sponsor Study ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "CSR-1.1"));
			c.Add(new Component("Namespace ID", "CSR-1.2"));
			c.Add(new Component("Universal ID", "CSR-1.3"));
			c.Add(new Component("Universal ID Type", "CSR-1.4"));
			f.Components = c;
			return f;
		}
		private Field CSR2()
		{
			Field f = new Field("Alternate Study ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "CSR-2.1"));
			c.Add(new Component("Namespace ID", "CSR-2.2"));
			c.Add(new Component("Universal ID", "CSR-2.3"));
			c.Add(new Component("Universal ID Type", "CSR-2.4"));
			f.Components = c;
			return f;
		}
		private Field CSR3()
		{
			Field f = new Field("Institution Registering the Patient");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CSR-3.1"));
			c.Add(new Component("", "CSR-3.2"));
			c.Add(new Component("Name of Coding System", "CSR-3.3"));
			c.Add(new Component("Alternate Identifier", "CSR-3.4"));
			c.Add(new Component("Alternate Text", "CSR-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "CSR-3.6"));
			f.Components = c;
			return f;
		}
		private Field CSR4()
		{
			Field f = new Field("Sponsor Patient ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CSR-4.1"));
			c.Add(new Component("Check Digit", "CSR-4.2"));
			c.Add(new Component("Check Digit Scheme", "CSR-4.3"));
			c.Add(new Component("Assigning Authority", "CSR-4.4"));
			c.Add(new Component("Identifier Type Code", "CSR-4.5"));
			c.Add(new Component("Assigning Facility", "CSR-4.6"));
			c.Add(new Component("Effective Date", "CSR-4.7"));
			c.Add(new Component("Expiration Date", "CSR-4.8"));
			c.Add(new Component("Assigning Jurisdiction", "CSR-4.9"));
			c.Add(new Component("Assigning Agency or Department", "CSR-4.10"));
			f.Components = c;
			return f;
		}
		private Field CSR5()
		{
			Field f = new Field("Alternate Patient ID - CSR");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CSR-5.1"));
			c.Add(new Component("Check Digit", "CSR-5.2"));
			c.Add(new Component("Check Digit Scheme", "CSR-5.3"));
			c.Add(new Component("Assigning Authority", "CSR-5.4"));
			c.Add(new Component("Identifier Type Code", "CSR-5.5"));
			c.Add(new Component("Assigning Facility", "CSR-5.6"));
			c.Add(new Component("Effective Date", "CSR-5.7"));
			c.Add(new Component("Expiration Date", "CSR-5.8"));
			c.Add(new Component("Assigning Jurisdiction", "CSR-5.9"));
			c.Add(new Component("Assigning Agency or Department", "CSR-5.10"));
			f.Components = c;
			return f;
		}
		private Field CSR6()
		{
			Field f = new Field("Date/Time Of Patient Study Registration");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CSR-6.1"));
			c.Add(new Component("Degree of Precision", "CSR-6.2"));
			f.Components = c;
			return f;
		}
		private Field CSR7()
		{
			Field f = new Field("Person Performing Study Registration");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CSR-7.1"));
			c.Add(new Component("Family Name", "CSR-7.2"));
			c.Add(new Component("Given Name", "CSR-7.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "CSR-7.4"));
			c.Add(new Component("Suffix", "CSR-7.5"));
			c.Add(new Component("Prefix", "CSR-7.6"));
			c.Add(new Component("Degree", "CSR-7.7"));
			c.Add(new Component("Source Table", "CSR-7.8"));
			c.Add(new Component("Assigning Authority", "CSR-7.9"));
			c.Add(new Component("Name Type Code", "CSR-7.10"));
			c.Add(new Component("Identifier Check Digit", "CSR-7.11"));
			c.Add(new Component("Check Digit Scheme", "CSR-7.12"));
			c.Add(new Component("Identifier Type Code", "CSR-7.13"));
			c.Add(new Component("Assigning Facility", "CSR-7.14"));
			c.Add(new Component("Name Respresentation Code", "CSR-7.15"));
			c.Add(new Component("Name Context", "CSR-7.16"));
			c.Add(new Component("Name Validity Range", "CSR-7.17"));
			c.Add(new Component("Name Assembly Order", "CSR-7.18"));
			c.Add(new Component("Effective Date", "CSR-7.19"));
			c.Add(new Component("Expiration Date", "CSR-7.20"));
			c.Add(new Component("Professional Suffix", "CSR-7.21"));
			c.Add(new Component("Assigning Jurisdiction", "CSR-7.22"));
			c.Add(new Component("Assigning Agency or Department", "CSR-7.23"));
			f.Components = c;
			return f;
		}
		private Field CSR8()
		{
			Field f = new Field("Study Authorizing Provider");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CSR-8.1"));
			c.Add(new Component("Family Name", "CSR-8.2"));
			c.Add(new Component("Given Name", "CSR-8.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "CSR-8.4"));
			c.Add(new Component("Suffix", "CSR-8.5"));
			c.Add(new Component("Prefix", "CSR-8.6"));
			c.Add(new Component("Degree", "CSR-8.7"));
			c.Add(new Component("Source Table", "CSR-8.8"));
			c.Add(new Component("Assigning Authority", "CSR-8.9"));
			c.Add(new Component("Name Type Code", "CSR-8.10"));
			c.Add(new Component("Identifier Check Digit", "CSR-8.11"));
			c.Add(new Component("Check Digit Scheme", "CSR-8.12"));
			c.Add(new Component("Identifier Type Code", "CSR-8.13"));
			c.Add(new Component("Assigning Facility", "CSR-8.14"));
			c.Add(new Component("Name Respresentation Code", "CSR-8.15"));
			c.Add(new Component("Name Context", "CSR-8.16"));
			c.Add(new Component("Name Validity Range", "CSR-8.17"));
			c.Add(new Component("Name Assembly Order", "CSR-8.18"));
			c.Add(new Component("Effective Date", "CSR-8.19"));
			c.Add(new Component("Expiration Date", "CSR-8.20"));
			c.Add(new Component("Professional Suffix", "CSR-8.21"));
			c.Add(new Component("Assigning Jurisdiction", "CSR-8.22"));
			c.Add(new Component("Assigning Agency or Department", "CSR-8.23"));
			f.Components = c;
			return f;
		}
		private Field CSR9()
		{
			Field f = new Field("Date/time Patient Study Consent Signed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CSR-9.1"));
			c.Add(new Component("Degree of Precision", "CSR-9.2"));
			f.Components = c;
			return f;
		}
		private Field CSR10()
		{
			Field f = new Field("Patient Study Eligibility Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CSR-10.1"));
			c.Add(new Component("", "CSR-10.2"));
			c.Add(new Component("Name of Coding System", "CSR-10.3"));
			c.Add(new Component("Alternate Identifier", "CSR-10.4"));
			c.Add(new Component("Alternate Text", "CSR-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "CSR-10.6"));
			f.Components = c;
			return f;
		}
		private Field CSR11()
		{
			Field f = new Field("Study Randomization Date/time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CSR-11.1"));
			c.Add(new Component("Degree of Precision", "CSR-11.2"));
			f.Components = c;
			return f;
		}
		private Field CSR12()
		{
			Field f = new Field("Randomized Study Arm");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CSR-12.1"));
			c.Add(new Component("", "CSR-12.2"));
			c.Add(new Component("Name of Coding System", "CSR-12.3"));
			c.Add(new Component("Alternate Identifier", "CSR-12.4"));
			c.Add(new Component("Alternate Text", "CSR-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "CSR-12.6"));
			f.Components = c;
			return f;
		}
		private Field CSR13()
		{
			Field f = new Field("Stratum for Study Randomization");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CSR-13.1"));
			c.Add(new Component("", "CSR-13.2"));
			c.Add(new Component("Name of Coding System", "CSR-13.3"));
			c.Add(new Component("Alternate Identifier", "CSR-13.4"));
			c.Add(new Component("Alternate Text", "CSR-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "CSR-13.6"));
			f.Components = c;
			return f;
		}
		private Field CSR14()
		{
			Field f = new Field("Patient Evaluability Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CSR-14.1"));
			c.Add(new Component("", "CSR-14.2"));
			c.Add(new Component("Name of Coding System", "CSR-14.3"));
			c.Add(new Component("Alternate Identifier", "CSR-14.4"));
			c.Add(new Component("Alternate Text", "CSR-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "CSR-14.6"));
			f.Components = c;
			return f;
		}
		private Field CSR15()
		{
			Field f = new Field("Date/time Ended Study");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CSR-15.1"));
			c.Add(new Component("Degree of Precision", "CSR-15.2"));
			f.Components = c;
			return f;
		}
		private Field CSR16()
		{
			Field f = new Field("Reason Ended Study");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CSR-16.1"));
			c.Add(new Component("", "CSR-16.2"));
			c.Add(new Component("Name of Coding System", "CSR-16.3"));
			c.Add(new Component("Alternate Identifier", "CSR-16.4"));
			c.Add(new Component("Alternate Text", "CSR-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "CSR-16.6"));
			f.Components = c;
			return f;
		}
	}
}
