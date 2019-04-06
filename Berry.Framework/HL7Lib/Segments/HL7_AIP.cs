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
    /// AIP Class: Constructs an HL7 AIP Segment Object
    /// </summary>
	public class AIP
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public AIP()
		{
			Name = "AIP";
			Description = "Appointment Information _ Personnel Resource";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(AIP1());
			fs.Add(AIP2());
			fs.Add(AIP3());
			fs.Add(AIP4());
			fs.Add(AIP5());
			fs.Add(AIP6());
			fs.Add(AIP7());
			fs.Add(AIP8());
			fs.Add(AIP9());
			fs.Add(AIP10());
			fs.Add(AIP11());
			fs.Add(AIP12());
			Fields = fs;
		}
		private Field AIP1()
		{
			Field f = new Field("Set ID - AIP");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "AIP-1.1"));
			f.Components = c;
			return f;
		}
		private Field AIP2()
		{
			Field f = new Field("Segment Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIP-2.1"));
			f.Components = c;
			return f;
		}
		private Field AIP3()
		{
			Field f = new Field("Personnel Resource ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "AIP-3.1"));
			c.Add(new Component("Family Name", "AIP-3.2"));
			c.Add(new Component("Given Name", "AIP-3.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "AIP-3.4"));
			c.Add(new Component("Suffix", "AIP-3.5"));
			c.Add(new Component("Prefix", "AIP-3.6"));
			c.Add(new Component("Degree", "AIP-3.7"));
			c.Add(new Component("Source Table", "AIP-3.8"));
			c.Add(new Component("Assigning Authority", "AIP-3.9"));
			c.Add(new Component("Name Type Code", "AIP-3.10"));
			c.Add(new Component("Identifier Check Digit", "AIP-3.11"));
			c.Add(new Component("Check Digit Scheme", "AIP-3.12"));
			c.Add(new Component("Identifier Type Code", "AIP-3.13"));
			c.Add(new Component("Assigning Facility", "AIP-3.14"));
			c.Add(new Component("Name Respresentation Code", "AIP-3.15"));
			c.Add(new Component("Name Context", "AIP-3.16"));
			c.Add(new Component("Name Validity Range", "AIP-3.17"));
			c.Add(new Component("Name Assembly Order", "AIP-3.18"));
			c.Add(new Component("Effective Date", "AIP-3.19"));
			c.Add(new Component("Expiration Date", "AIP-3.20"));
			c.Add(new Component("Professional Suffix", "AIP-3.21"));
			c.Add(new Component("Assigning Jurisdiction", "AIP-3.22"));
			c.Add(new Component("Assigning Agency or Department", "AIP-3.23"));
			f.Components = c;
			return f;
		}
		private Field AIP4()
		{
			Field f = new Field("Resource Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIP-4.1"));
			c.Add(new Component("", "AIP-4.2"));
			c.Add(new Component("Name of Coding System", "AIP-4.3"));
			c.Add(new Component("Alternate Identifier", "AIP-4.4"));
			c.Add(new Component("Alternate Text", "AIP-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIP-4.6"));
			f.Components = c;
			return f;
		}
		private Field AIP5()
		{
			Field f = new Field("Resource Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIP-5.1"));
			c.Add(new Component("", "AIP-5.2"));
			c.Add(new Component("Name of Coding System", "AIP-5.3"));
			c.Add(new Component("Alternate Identifier", "AIP-5.4"));
			c.Add(new Component("Alternate Text", "AIP-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIP-5.6"));
			f.Components = c;
			return f;
		}
		private Field AIP6()
		{
			Field f = new Field("Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "AIP-6.1"));
			c.Add(new Component("Degree of Precision", "AIP-6.2"));
			f.Components = c;
			return f;
		}
		private Field AIP7()
		{
			Field f = new Field("Start Date/Time Offset");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIP-7.1"));
			f.Components = c;
			return f;
		}
		private Field AIP8()
		{
			Field f = new Field("Start Date/Time Offset Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIP-8.1"));
			c.Add(new Component("", "AIP-8.2"));
			c.Add(new Component("Name of Coding System", "AIP-8.3"));
			c.Add(new Component("Alternate Identifier", "AIP-8.4"));
			c.Add(new Component("Alternate Text", "AIP-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIP-8.6"));
			f.Components = c;
			return f;
		}
		private Field AIP9()
		{
			Field f = new Field("Duration");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIP-9.1"));
			f.Components = c;
			return f;
		}
		private Field AIP10()
		{
			Field f = new Field("Duration Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIP-10.1"));
			c.Add(new Component("", "AIP-10.2"));
			c.Add(new Component("Name of Coding System", "AIP-10.3"));
			c.Add(new Component("Alternate Identifier", "AIP-10.4"));
			c.Add(new Component("Alternate Text", "AIP-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIP-10.6"));
			f.Components = c;
			return f;
		}
		private Field AIP11()
		{
			Field f = new Field("Allow Substitution Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AIP-11.1"));
			f.Components = c;
			return f;
		}
		private Field AIP12()
		{
			Field f = new Field("Filler Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "AIP-12.1"));
			c.Add(new Component("", "AIP-12.2"));
			c.Add(new Component("Name of Coding System", "AIP-12.3"));
			c.Add(new Component("Alternate Identifier", "AIP-12.4"));
			c.Add(new Component("Alternate Text", "AIP-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "AIP-12.6"));
			f.Components = c;
			return f;
		}
	}
}
