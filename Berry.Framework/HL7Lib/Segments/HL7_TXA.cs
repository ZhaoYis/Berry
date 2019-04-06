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
/// TXA Class: Constructs an HL7 TXA Segment Object
/// </summary>
public class TXA
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public TXA()
		{
			Name = "TXA";
			Description = "Transcription Document Header";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(TXA1());
			fs.Add(TXA2());
			fs.Add(TXA3());
			fs.Add(TXA4());
			fs.Add(TXA5());
			fs.Add(TXA6());
			fs.Add(TXA7());
			fs.Add(TXA8());
			fs.Add(TXA9());
			fs.Add(TXA10());
			fs.Add(TXA11());
			fs.Add(TXA12());
			fs.Add(TXA13());
			fs.Add(TXA14());
			fs.Add(TXA15());
			fs.Add(TXA16());
			fs.Add(TXA17());
			fs.Add(TXA18());
			fs.Add(TXA19());
			fs.Add(TXA20());
			fs.Add(TXA21());
			fs.Add(TXA22());
			fs.Add(TXA23());
			Fields = fs;
		}
		private Field TXA1()
		{
			Field f = new Field("Set ID- TXA");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "TXA-1.1"));
			f.Components = c;
			return f;
		}
		private Field TXA2()
		{
			Field f = new Field("Document Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TXA-2.1"));
			f.Components = c;
			return f;
		}
		private Field TXA3()
		{
			Field f = new Field("Document Content Presentation");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TXA-3.1"));
			f.Components = c;
			return f;
		}
		private Field TXA4()
		{
			Field f = new Field("Activity Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "TXA-4.1"));
			c.Add(new Component("Degree of Precision", "TXA-4.2"));
			f.Components = c;
			return f;
		}
		private Field TXA5()
		{
			Field f = new Field("Primary Activity Provider Code/Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "TXA-5.1"));
			c.Add(new Component("Family Name", "TXA-5.2"));
			c.Add(new Component("Given Name", "TXA-5.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "TXA-5.4"));
			c.Add(new Component("Suffix", "TXA-5.5"));
			c.Add(new Component("Prefix", "TXA-5.6"));
			c.Add(new Component("Degree", "TXA-5.7"));
			c.Add(new Component("Source Table", "TXA-5.8"));
			c.Add(new Component("Assigning Authority", "TXA-5.9"));
			c.Add(new Component("Name Type Code", "TXA-5.10"));
			c.Add(new Component("Identifier Check Digit", "TXA-5.11"));
			c.Add(new Component("Check Digit Scheme", "TXA-5.12"));
			c.Add(new Component("Identifier Type Code", "TXA-5.13"));
			c.Add(new Component("Assigning Facility", "TXA-5.14"));
			c.Add(new Component("Name Respresentation Code", "TXA-5.15"));
			c.Add(new Component("Name Context", "TXA-5.16"));
			c.Add(new Component("Name Validity Range", "TXA-5.17"));
			c.Add(new Component("Name Assembly Order", "TXA-5.18"));
			c.Add(new Component("Effective Date", "TXA-5.19"));
			c.Add(new Component("Expiration Date", "TXA-5.20"));
			c.Add(new Component("Professional Suffix", "TXA-5.21"));
			c.Add(new Component("Assigning Jurisdiction", "TXA-5.22"));
			c.Add(new Component("Assigning Agency or Department", "TXA-5.23"));
			f.Components = c;
			return f;
		}
		private Field TXA6()
		{
			Field f = new Field("Origination Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "TXA-6.1"));
			c.Add(new Component("Degree of Precision", "TXA-6.2"));
			f.Components = c;
			return f;
		}
		private Field TXA7()
		{
			Field f = new Field("Transcription Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "TXA-7.1"));
			c.Add(new Component("Degree of Precision", "TXA-7.2"));
			f.Components = c;
			return f;
		}
		private Field TXA8()
		{
			Field f = new Field("Edit Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "TXA-8.1"));
			c.Add(new Component("Degree of Precision", "TXA-8.2"));
			f.Components = c;
			return f;
		}
		private Field TXA9()
		{
			Field f = new Field("Originator Code/Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "TXA-9.1"));
			c.Add(new Component("Family Name", "TXA-9.2"));
			c.Add(new Component("Given Name", "TXA-9.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "TXA-9.4"));
			c.Add(new Component("Suffix", "TXA-9.5"));
			c.Add(new Component("Prefix", "TXA-9.6"));
			c.Add(new Component("Degree", "TXA-9.7"));
			c.Add(new Component("Source Table", "TXA-9.8"));
			c.Add(new Component("Assigning Authority", "TXA-9.9"));
			c.Add(new Component("Name Type Code", "TXA-9.10"));
			c.Add(new Component("Identifier Check Digit", "TXA-9.11"));
			c.Add(new Component("Check Digit Scheme", "TXA-9.12"));
			c.Add(new Component("Identifier Type Code", "TXA-9.13"));
			c.Add(new Component("Assigning Facility", "TXA-9.14"));
			c.Add(new Component("Name Respresentation Code", "TXA-9.15"));
			c.Add(new Component("Name Context", "TXA-9.16"));
			c.Add(new Component("Name Validity Range", "TXA-9.17"));
			c.Add(new Component("Name Assembly Order", "TXA-9.18"));
			c.Add(new Component("Effective Date", "TXA-9.19"));
			c.Add(new Component("Expiration Date", "TXA-9.20"));
			c.Add(new Component("Professional Suffix", "TXA-9.21"));
			c.Add(new Component("Assigning Jurisdiction", "TXA-9.22"));
			c.Add(new Component("Assigning Agency or Department", "TXA-9.23"));
			f.Components = c;
			return f;
		}
		private Field TXA10()
		{
			Field f = new Field("Assigned Document Authenticator");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "TXA-10.1"));
			c.Add(new Component("Family Name", "TXA-10.2"));
			c.Add(new Component("Given Name", "TXA-10.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "TXA-10.4"));
			c.Add(new Component("Suffix", "TXA-10.5"));
			c.Add(new Component("Prefix", "TXA-10.6"));
			c.Add(new Component("Degree", "TXA-10.7"));
			c.Add(new Component("Source Table", "TXA-10.8"));
			c.Add(new Component("Assigning Authority", "TXA-10.9"));
			c.Add(new Component("Name Type Code", "TXA-10.10"));
			c.Add(new Component("Identifier Check Digit", "TXA-10.11"));
			c.Add(new Component("Check Digit Scheme", "TXA-10.12"));
			c.Add(new Component("Identifier Type Code", "TXA-10.13"));
			c.Add(new Component("Assigning Facility", "TXA-10.14"));
			c.Add(new Component("Name Respresentation Code", "TXA-10.15"));
			c.Add(new Component("Name Context", "TXA-10.16"));
			c.Add(new Component("Name Validity Range", "TXA-10.17"));
			c.Add(new Component("Name Assembly Order", "TXA-10.18"));
			c.Add(new Component("Effective Date", "TXA-10.19"));
			c.Add(new Component("Expiration Date", "TXA-10.20"));
			c.Add(new Component("Professional Suffix", "TXA-10.21"));
			c.Add(new Component("Assigning Jurisdiction", "TXA-10.22"));
			c.Add(new Component("Assigning Agency or Department", "TXA-10.23"));
			f.Components = c;
			return f;
		}
		private Field TXA11()
		{
			Field f = new Field("Transcriptionist Code/Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "TXA-11.1"));
			c.Add(new Component("Family Name", "TXA-11.2"));
			c.Add(new Component("Given Name", "TXA-11.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "TXA-11.4"));
			c.Add(new Component("Suffix", "TXA-11.5"));
			c.Add(new Component("Prefix", "TXA-11.6"));
			c.Add(new Component("Degree", "TXA-11.7"));
			c.Add(new Component("Source Table", "TXA-11.8"));
			c.Add(new Component("Assigning Authority", "TXA-11.9"));
			c.Add(new Component("Name Type Code", "TXA-11.10"));
			c.Add(new Component("Identifier Check Digit", "TXA-11.11"));
			c.Add(new Component("Check Digit Scheme", "TXA-11.12"));
			c.Add(new Component("Identifier Type Code", "TXA-11.13"));
			c.Add(new Component("Assigning Facility", "TXA-11.14"));
			c.Add(new Component("Name Respresentation Code", "TXA-11.15"));
			c.Add(new Component("Name Context", "TXA-11.16"));
			c.Add(new Component("Name Validity Range", "TXA-11.17"));
			c.Add(new Component("Name Assembly Order", "TXA-11.18"));
			c.Add(new Component("Effective Date", "TXA-11.19"));
			c.Add(new Component("Expiration Date", "TXA-11.20"));
			c.Add(new Component("Professional Suffix", "TXA-11.21"));
			c.Add(new Component("Assigning Jurisdiction", "TXA-11.22"));
			c.Add(new Component("Assigning Agency or Department", "TXA-11.23"));
			f.Components = c;
			return f;
		}
		private Field TXA12()
		{
			Field f = new Field("Unique Document Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "TXA-12.1"));
			c.Add(new Component("Namespace ID", "TXA-12.2"));
			c.Add(new Component("Universal ID", "TXA-12.3"));
			c.Add(new Component("Universal ID Type", "TXA-12.4"));
			f.Components = c;
			return f;
		}
		private Field TXA13()
		{
			Field f = new Field("Parent Document Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "TXA-13.1"));
			c.Add(new Component("Namespace ID", "TXA-13.2"));
			c.Add(new Component("Universal ID", "TXA-13.3"));
			c.Add(new Component("Universal ID Type", "TXA-13.4"));
			f.Components = c;
			return f;
		}
		private Field TXA14()
		{
			Field f = new Field("Placer Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "TXA-14.1"));
			c.Add(new Component("Namespace ID", "TXA-14.2"));
			c.Add(new Component("Universal ID", "TXA-14.3"));
			c.Add(new Component("Universal ID Type", "TXA-14.4"));
			f.Components = c;
			return f;
		}
		private Field TXA15()
		{
			Field f = new Field("Filler Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "TXA-15.1"));
			c.Add(new Component("Namespace ID", "TXA-15.2"));
			c.Add(new Component("Universal ID", "TXA-15.3"));
			c.Add(new Component("Universal ID Type", "TXA-15.4"));
			f.Components = c;
			return f;
		}
		private Field TXA16()
		{
			Field f = new Field("Unique Document File Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TXA-16.1"));
			f.Components = c;
			return f;
		}
		private Field TXA17()
		{
			Field f = new Field("Document Completion Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TXA-17.1"));
			f.Components = c;
			return f;
		}
		private Field TXA18()
		{
			Field f = new Field("Document Confidentiality Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TXA-18.1"));
			f.Components = c;
			return f;
		}
		private Field TXA19()
		{
			Field f = new Field("Document Availability Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TXA-19.1"));
			f.Components = c;
			return f;
		}
		private Field TXA20()
		{
			Field f = new Field("Document Storage Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TXA-20.1"));
			f.Components = c;
			return f;
		}
		private Field TXA21()
		{
			Field f = new Field("Document Change Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TXA-21.1"));
			f.Components = c;
			return f;
		}
		private Field TXA22()
		{
			Field f = new Field("Authentication Person, Time Stamp");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "TXA-22.1"));
			c.Add(new Component("Family Name", "TXA-22.2"));
			c.Add(new Component("Given Name", "TXA-22.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "TXA-22.4"));
			c.Add(new Component("Suffix", "TXA-22.5"));
			c.Add(new Component("Prefix", "TXA-22.6"));
			c.Add(new Component("Degree", "TXA-22.7"));
			c.Add(new Component("Source Table", "TXA-22.8"));
			c.Add(new Component("Assigning Authority", "TXA-22.9"));
			c.Add(new Component("Name Type Code", "TXA-22.10"));
			c.Add(new Component("Identifier Check Digit", "TXA-22.11"));
			c.Add(new Component("Check Digit Scheme", "TXA-22.12"));
			c.Add(new Component("Identifier Type Code", "TXA-22.13"));
			c.Add(new Component("Assigning Facility", "TXA-22.14"));
			c.Add(new Component("Date/Time Action Performed", "TXA-22.15"));
			c.Add(new Component("Name Respresentation Code", "TXA-22.16"));
			c.Add(new Component("Name Context", "TXA-22.17"));
			c.Add(new Component("Name Validity Range", "TXA-22.18"));
			c.Add(new Component("Name Assembly Order", "TXA-22.19"));
			c.Add(new Component("Effective Date", "TXA-22.20"));
			c.Add(new Component("Expiration Date", "TXA-22.21"));
			c.Add(new Component("Professional Suffix", "TXA-22.22"));
			c.Add(new Component("Assigning Jurisdiction", "TXA-22.23"));
			c.Add(new Component("Assigning Agency or Department", "TXA-22.24"));
			f.Components = c;
			return f;
		}
		private Field TXA23()
		{
			Field f = new Field("Distributed Copies (Code and Name of Recipients)");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "TXA-23.1"));
			c.Add(new Component("Family Name", "TXA-23.2"));
			c.Add(new Component("Given Name", "TXA-23.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "TXA-23.4"));
			c.Add(new Component("Suffix", "TXA-23.5"));
			c.Add(new Component("Prefix", "TXA-23.6"));
			c.Add(new Component("Degree", "TXA-23.7"));
			c.Add(new Component("Source Table", "TXA-23.8"));
			c.Add(new Component("Assigning Authority", "TXA-23.9"));
			c.Add(new Component("Name Type Code", "TXA-23.10"));
			c.Add(new Component("Identifier Check Digit", "TXA-23.11"));
			c.Add(new Component("Check Digit Scheme", "TXA-23.12"));
			c.Add(new Component("Identifier Type Code", "TXA-23.13"));
			c.Add(new Component("Assigning Facility", "TXA-23.14"));
			c.Add(new Component("Name Respresentation Code", "TXA-23.15"));
			c.Add(new Component("Name Context", "TXA-23.16"));
			c.Add(new Component("Name Validity Range", "TXA-23.17"));
			c.Add(new Component("Name Assembly Order", "TXA-23.18"));
			c.Add(new Component("Effective Date", "TXA-23.19"));
			c.Add(new Component("Expiration Date", "TXA-23.20"));
			c.Add(new Component("Professional Suffix", "TXA-23.21"));
			c.Add(new Component("Assigning Jurisdiction", "TXA-23.22"));
			c.Add(new Component("Assigning Agency or Department", "TXA-23.23"));
			f.Components = c;
			return f;
		}
	}
}
