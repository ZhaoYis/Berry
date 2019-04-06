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
    /// ABS Class: Constructs an HL7 ABS Segment Object
    /// </summary>
	public class ABS
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ABS()
		{
			Name = "ABS";
			Description = "Abstract";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ABS1());
			fs.Add(ABS2());
			fs.Add(ABS3());
			fs.Add(ABS4());
			fs.Add(ABS5());
			fs.Add(ABS6());
			fs.Add(ABS7());
			fs.Add(ABS8());
			fs.Add(ABS9());
			fs.Add(ABS10());
			fs.Add(ABS11());
			fs.Add(ABS12());
			fs.Add(ABS13());
			fs.Add(ABS14());
			Fields = fs;
		}
		private Field ABS1()
		{
			Field f = new Field("Discharge Care Provider");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ABS-1.1"));
			c.Add(new Component("Family Name", "ABS-1.2"));
			c.Add(new Component("Given Name", "ABS-1.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ABS-1.4"));
			c.Add(new Component("Suffix", "ABS-1.5"));
			c.Add(new Component("Prefix", "ABS-1.6"));
			c.Add(new Component("Degree", "ABS-1.7"));
			c.Add(new Component("Source Table", "ABS-1.8"));
			c.Add(new Component("Assigning Authority", "ABS-1.9"));
			c.Add(new Component("Name Type Code", "ABS-1.10"));
			c.Add(new Component("Identifier Check Digit", "ABS-1.11"));
			c.Add(new Component("Check Digit Scheme", "ABS-1.12"));
			c.Add(new Component("Identifier Type Code", "ABS-1.13"));
			c.Add(new Component("Assigning Facility", "ABS-1.14"));
			c.Add(new Component("Name Respresentation Code", "ABS-1.15"));
			c.Add(new Component("Name Context", "ABS-1.16"));
			c.Add(new Component("Name Validity Range", "ABS-1.17"));
			c.Add(new Component("Name Assembly Order", "ABS-1.18"));
			c.Add(new Component("Effective Date", "ABS-1.19"));
			c.Add(new Component("Expiration Date", "ABS-1.20"));
			c.Add(new Component("Professional Suffix", "ABS-1.21"));
			c.Add(new Component("Assigning Jurisdiction", "ABS-1.22"));
			c.Add(new Component("Assigning Agency or Department", "ABS-1.23"));
			f.Components = c;
			return f;
		}
		private Field ABS2()
		{
			Field f = new Field("Transfer Medical Service Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ABS-2.1"));
			c.Add(new Component("", "ABS-2.2"));
			c.Add(new Component("Name of Coding System", "ABS-2.3"));
			c.Add(new Component("Alternate Identifier", "ABS-2.4"));
			c.Add(new Component("Alternate Text", "ABS-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "ABS-2.6"));
			f.Components = c;
			return f;
		}
		private Field ABS3()
		{
			Field f = new Field("Severity of Illness Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ABS-3.1"));
			c.Add(new Component("", "ABS-3.2"));
			c.Add(new Component("Name of Coding System", "ABS-3.3"));
			c.Add(new Component("Alternate Identifier", "ABS-3.4"));
			c.Add(new Component("Alternate Text", "ABS-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "ABS-3.6"));
			f.Components = c;
			return f;
		}
		private Field ABS4()
		{
			Field f = new Field("Date/Time of Attestation");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ABS-4.1"));
			c.Add(new Component("Degree of Precision", "ABS-4.2"));
			f.Components = c;
			return f;
		}
		private Field ABS5()
		{
			Field f = new Field("Attested By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ABS-5.1"));
			c.Add(new Component("Family Name", "ABS-5.2"));
			c.Add(new Component("Given Name", "ABS-5.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ABS-5.4"));
			c.Add(new Component("Suffix", "ABS-5.5"));
			c.Add(new Component("Prefix", "ABS-5.6"));
			c.Add(new Component("Degree", "ABS-5.7"));
			c.Add(new Component("Source Table", "ABS-5.8"));
			c.Add(new Component("Assigning Authority", "ABS-5.9"));
			c.Add(new Component("Name Type Code", "ABS-5.10"));
			c.Add(new Component("Identifier Check Digit", "ABS-5.11"));
			c.Add(new Component("Check Digit Scheme", "ABS-5.12"));
			c.Add(new Component("Identifier Type Code", "ABS-5.13"));
			c.Add(new Component("Assigning Facility", "ABS-5.14"));
			c.Add(new Component("Name Respresentation Code", "ABS-5.15"));
			c.Add(new Component("Name Context", "ABS-5.16"));
			c.Add(new Component("Name Validity Range", "ABS-5.17"));
			c.Add(new Component("Name Assembly Order", "ABS-5.18"));
			c.Add(new Component("Effective Date", "ABS-5.19"));
			c.Add(new Component("Expiration Date", "ABS-5.20"));
			c.Add(new Component("Professional Suffix", "ABS-5.21"));
			c.Add(new Component("Assigning Jurisdiction", "ABS-5.22"));
			c.Add(new Component("Assigning Agency or Department", "ABS-5.23"));
			f.Components = c;
			return f;
		}
		private Field ABS6()
		{
			Field f = new Field("Triage Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ABS-6.1"));
			c.Add(new Component("", "ABS-6.2"));
			c.Add(new Component("Name of Coding System", "ABS-6.3"));
			c.Add(new Component("Alternate Identifier", "ABS-6.4"));
			c.Add(new Component("Alternate Text", "ABS-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "ABS-6.6"));
			f.Components = c;
			return f;
		}
		private Field ABS7()
		{
			Field f = new Field("Abstract Completion Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ABS-7.1"));
			c.Add(new Component("Degree of Precision", "ABS-7.2"));
			f.Components = c;
			return f;
		}
		private Field ABS8()
		{
			Field f = new Field("Abstracted By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ABS-8.1"));
			c.Add(new Component("Family Name", "ABS-8.2"));
			c.Add(new Component("Given Name", "ABS-8.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ABS-8.4"));
			c.Add(new Component("Suffix", "ABS-8.5"));
			c.Add(new Component("Prefix", "ABS-8.6"));
			c.Add(new Component("Degree", "ABS-8.7"));
			c.Add(new Component("Source Table", "ABS-8.8"));
			c.Add(new Component("Assigning Authority", "ABS-8.9"));
			c.Add(new Component("Name Type Code", "ABS-8.10"));
			c.Add(new Component("Identifier Check Digit", "ABS-8.11"));
			c.Add(new Component("Check Digit Scheme", "ABS-8.12"));
			c.Add(new Component("Identifier Type Code", "ABS-8.13"));
			c.Add(new Component("Assigning Facility", "ABS-8.14"));
			c.Add(new Component("Name Respresentation Code", "ABS-8.15"));
			c.Add(new Component("Name Context", "ABS-8.16"));
			c.Add(new Component("Name Validity Range", "ABS-8.17"));
			c.Add(new Component("Name Assembly Order", "ABS-8.18"));
			c.Add(new Component("Effective Date", "ABS-8.19"));
			c.Add(new Component("Expiration Date", "ABS-8.20"));
			c.Add(new Component("Professional Suffix", "ABS-8.21"));
			c.Add(new Component("Assigning Jurisdiction", "ABS-8.22"));
			c.Add(new Component("Assigning Agency or Department", "ABS-8.23"));
			f.Components = c;
			return f;
		}
		private Field ABS9()
		{
			Field f = new Field("Case Category Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ABS-9.1"));
			c.Add(new Component("", "ABS-9.2"));
			c.Add(new Component("Name of Coding System", "ABS-9.3"));
			c.Add(new Component("Alternate Identifier", "ABS-9.4"));
			c.Add(new Component("Alternate Text", "ABS-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "ABS-9.6"));
			f.Components = c;
			return f;
		}
		private Field ABS10()
		{
			Field f = new Field("Caesarian Section Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ABS-10.1"));
			f.Components = c;
			return f;
		}
		private Field ABS11()
		{
			Field f = new Field("Gestation Category Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ABS-11.1"));
			c.Add(new Component("", "ABS-11.2"));
			c.Add(new Component("Name of Coding System", "ABS-11.3"));
			c.Add(new Component("Alternate Identifier", "ABS-11.4"));
			c.Add(new Component("Alternate Text", "ABS-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "ABS-11.6"));
			f.Components = c;
			return f;
		}
		private Field ABS12()
		{
			Field f = new Field("Gestation Period - Weeks");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ABS-12.1"));
			f.Components = c;
			return f;
		}
		private Field ABS13()
		{
			Field f = new Field("Newborn Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ABS-13.1"));
			c.Add(new Component("", "ABS-13.2"));
			c.Add(new Component("Name of Coding System", "ABS-13.3"));
			c.Add(new Component("Alternate Identifier", "ABS-13.4"));
			c.Add(new Component("Alternate Text", "ABS-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "ABS-13.6"));
			f.Components = c;
			return f;
		}
		private Field ABS14()
		{
			Field f = new Field("Stillborn Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ABS-14.1"));
			f.Components = c;
			return f;
		}
	}
}
