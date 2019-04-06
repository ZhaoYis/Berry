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
/// IAM Class: Constructs an HL7 IAM Segment Object
/// </summary>
public class IAM
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public IAM()
		{
			Name = "IAM";
			Description = "Patient Adverse Reaction Information";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(IAM1());
			fs.Add(IAM2());
			fs.Add(IAM3());
			fs.Add(IAM4());
			fs.Add(IAM5());
			fs.Add(IAM6());
			fs.Add(IAM7());
			fs.Add(IAM8());
			fs.Add(IAM9());
			fs.Add(IAM10());
			fs.Add(IAM11());
			fs.Add(IAM12());
			fs.Add(IAM13());
			fs.Add(IAM14());
			fs.Add(IAM15());
			fs.Add(IAM16());
			fs.Add(IAM17());
			fs.Add(IAM18());
			fs.Add(IAM19());
			fs.Add(IAM20());
			Fields = fs;
		}
		private Field IAM1()
		{
			Field f = new Field("Set ID - IAM");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "IAM-1.1"));
			f.Components = c;
			return f;
		}
		private Field IAM2()
		{
			Field f = new Field("Allergen Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-2.1"));
			c.Add(new Component("", "IAM-2.2"));
			c.Add(new Component("Name of Coding System", "IAM-2.3"));
			c.Add(new Component("Alternate Identifier", "IAM-2.4"));
			c.Add(new Component("Alternate Text", "IAM-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-2.6"));
			f.Components = c;
			return f;
		}
		private Field IAM3()
		{
			Field f = new Field("Allergen Code/Mnemonic/Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-3.1"));
			c.Add(new Component("", "IAM-3.2"));
			c.Add(new Component("Name of Coding System", "IAM-3.3"));
			c.Add(new Component("Alternate Identifier", "IAM-3.4"));
			c.Add(new Component("Alternate Text", "IAM-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-3.6"));
			f.Components = c;
			return f;
		}
		private Field IAM4()
		{
			Field f = new Field("Allergy Severity Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-4.1"));
			c.Add(new Component("", "IAM-4.2"));
			c.Add(new Component("Name of Coding System", "IAM-4.3"));
			c.Add(new Component("Alternate Identifier", "IAM-4.4"));
			c.Add(new Component("Alternate Text", "IAM-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-4.6"));
			f.Components = c;
			return f;
		}
		private Field IAM5()
		{
			Field f = new Field("Allergy Reaction Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IAM-5.1"));
			f.Components = c;
			return f;
		}
		private Field IAM6()
		{
			Field f = new Field("Allergy Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-6.1"));
			c.Add(new Component("", "IAM-6.2"));
			c.Add(new Component("Name of Coding System", "IAM-6.3"));
			c.Add(new Component("Alternate Identifier", "IAM-6.4"));
			c.Add(new Component("Alternate Text", "IAM-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-6.6"));
			c.Add(new Component("Coding System Version ID", "IAM-6.7"));
			c.Add(new Component("Alternate Coding System Version ID", "IAM-6.8"));
			c.Add(new Component("Original Text", "IAM-6.9"));
			f.Components = c;
			return f;
		}
		private Field IAM7()
		{
			Field f = new Field("Allergy Unique Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "IAM-7.1"));
			c.Add(new Component("Namespace ID", "IAM-7.2"));
			c.Add(new Component("Universal ID", "IAM-7.3"));
			c.Add(new Component("Universal ID Type", "IAM-7.4"));
			f.Components = c;
			return f;
		}
		private Field IAM8()
		{
			Field f = new Field("Action Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IAM-8.1"));
			f.Components = c;
			return f;
		}
		private Field IAM9()
		{
			Field f = new Field("Sensitivity to Causative Agent Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-9.1"));
			c.Add(new Component("", "IAM-9.2"));
			c.Add(new Component("Name of Coding System", "IAM-9.3"));
			c.Add(new Component("Alternate Identifier", "IAM-9.4"));
			c.Add(new Component("Alternate Text", "IAM-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-9.6"));
			f.Components = c;
			return f;
		}
		private Field IAM10()
		{
			Field f = new Field("Allergen Group Code/Mnemonic/Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-10.1"));
			c.Add(new Component("", "IAM-10.2"));
			c.Add(new Component("Name of Coding System", "IAM-10.3"));
			c.Add(new Component("Alternate Identifier", "IAM-10.4"));
			c.Add(new Component("Alternate Text", "IAM-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-10.6"));
			f.Components = c;
			return f;
		}
		private Field IAM11()
		{
			Field f = new Field("Onset Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IAM-11.1"));
			f.Components = c;
			return f;
		}
		private Field IAM12()
		{
			Field f = new Field("Onset Date Text");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IAM-12.1"));
			f.Components = c;
			return f;
		}
		private Field IAM13()
		{
			Field f = new Field("Reported Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IAM-13.1"));
			c.Add(new Component("Degree of Precision", "IAM-13.2"));
			f.Components = c;
			return f;
		}
		private Field IAM14()
		{
			Field f = new Field("Reported By");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IAM-14.1"));
			c.Add(new Component("Given Name", "IAM-14.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IAM-14.3"));
			c.Add(new Component("Suffix", "IAM-14.4"));
			c.Add(new Component("Prefix", "IAM-14.5"));
			c.Add(new Component("Degree", "IAM-14.6"));
			c.Add(new Component("Name Type Code", "IAM-14.7"));
			c.Add(new Component("Name Respresentation Code", "IAM-14.8"));
			c.Add(new Component("Name Context", "IAM-14.9"));
			c.Add(new Component("Name Validity Range", "IAM-14.10"));
			c.Add(new Component("Name Assembly Order", "IAM-14.11"));
			c.Add(new Component("Effective Date", "IAM-14.12"));
			c.Add(new Component("Expiration Date", "IAM-14.13"));
			c.Add(new Component("Professional Suffix", "IAM-14.14"));
			f.Components = c;
			return f;
		}
		private Field IAM15()
		{
			Field f = new Field("Relationship to Patient Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-15.1"));
			c.Add(new Component("", "IAM-15.2"));
			c.Add(new Component("Name of Coding System", "IAM-15.3"));
			c.Add(new Component("Alternate Identifier", "IAM-15.4"));
			c.Add(new Component("Alternate Text", "IAM-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-15.6"));
			f.Components = c;
			return f;
		}
		private Field IAM16()
		{
			Field f = new Field("Alert Device Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-16.1"));
			c.Add(new Component("", "IAM-16.2"));
			c.Add(new Component("Name of Coding System", "IAM-16.3"));
			c.Add(new Component("Alternate Identifier", "IAM-16.4"));
			c.Add(new Component("Alternate Text", "IAM-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-16.6"));
			f.Components = c;
			return f;
		}
		private Field IAM17()
		{
			Field f = new Field("Allergy Clinical Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IAM-17.1"));
			c.Add(new Component("", "IAM-17.2"));
			c.Add(new Component("Name of Coding System", "IAM-17.3"));
			c.Add(new Component("Alternate Identifier", "IAM-17.4"));
			c.Add(new Component("Alternate Text", "IAM-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "IAM-17.6"));
			f.Components = c;
			return f;
		}
		private Field IAM18()
		{
			Field f = new Field("Statused by Person");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IAM-18.1"));
			c.Add(new Component("Family Name", "IAM-18.2"));
			c.Add(new Component("Given Name", "IAM-18.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IAM-18.4"));
			c.Add(new Component("Suffix", "IAM-18.5"));
			c.Add(new Component("Prefix", "IAM-18.6"));
			c.Add(new Component("Degree", "IAM-18.7"));
			c.Add(new Component("Source Table", "IAM-18.8"));
			c.Add(new Component("Assigning Authority", "IAM-18.9"));
			c.Add(new Component("Name Type Code", "IAM-18.10"));
			c.Add(new Component("Identifier Check Digit", "IAM-18.11"));
			c.Add(new Component("Check Digit Scheme", "IAM-18.12"));
			c.Add(new Component("Identifier Type Code", "IAM-18.13"));
			c.Add(new Component("Assigning Facility", "IAM-18.14"));
			c.Add(new Component("Name Respresentation Code", "IAM-18.15"));
			c.Add(new Component("Name Context", "IAM-18.16"));
			c.Add(new Component("Name Validity Range", "IAM-18.17"));
			c.Add(new Component("Name Assembly Order", "IAM-18.18"));
			c.Add(new Component("Effective Date", "IAM-18.19"));
			c.Add(new Component("Expiration Date", "IAM-18.20"));
			c.Add(new Component("Professional Suffix", "IAM-18.21"));
			c.Add(new Component("Assigning Jurisdiction", "IAM-18.22"));
			c.Add(new Component("Assigning Agency or Department", "IAM-18.23"));
			f.Components = c;
			return f;
		}
		private Field IAM19()
		{
			Field f = new Field("Statused by Organization");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "IAM-19.1"));
			c.Add(new Component("Organization Name Type Code", "IAM-19.2"));
			c.Add(new Component("ID Number", "IAM-19.3"));
			c.Add(new Component("Check Digit", "IAM-19.4"));
			c.Add(new Component("Check Digit Scheme", "IAM-19.5"));
			c.Add(new Component("Assigning Authority", "IAM-19.6"));
			c.Add(new Component("Identifier Type Code", "IAM-19.7"));
			c.Add(new Component("Assigning Facility", "IAM-19.8"));
			c.Add(new Component("Name Respresentation Code", "IAM-19.9"));
			c.Add(new Component("Organization Identifier", "IAM-19.10"));
			f.Components = c;
			return f;
		}
		private Field IAM20()
		{
			Field f = new Field("Statused at Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IAM-20.1"));
			c.Add(new Component("Degree of Precision", "IAM-20.2"));
			f.Components = c;
			return f;
		}
	}
}
