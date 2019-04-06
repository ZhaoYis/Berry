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
/// PDA Class: Constructs an HL7 PDA Segment Object
/// </summary>
public class PDA
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PDA()
		{
			Name = "PDA";
			Description = "Patient Death and Autopsy";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PDA1());
			fs.Add(PDA2());
			fs.Add(PDA3());
			fs.Add(PDA4());
			fs.Add(PDA5());
			fs.Add(PDA6());
			fs.Add(PDA7());
			fs.Add(PDA8());
			fs.Add(PDA9());
			Fields = fs;
		}
		private Field PDA1()
		{
			Field f = new Field("Death Cause Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PDA-1.1"));
			c.Add(new Component("", "PDA-1.2"));
			c.Add(new Component("Name of Coding System", "PDA-1.3"));
			c.Add(new Component("Alternate Identifier", "PDA-1.4"));
			c.Add(new Component("Alternate Text", "PDA-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "PDA-1.6"));
			f.Components = c;
			return f;
		}
		private Field PDA2()
		{
			Field f = new Field("Death Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "PDA-2.1"));
			c.Add(new Component("Room", "PDA-2.2"));
			c.Add(new Component("Bed", "PDA-2.3"));
			c.Add(new Component("Facility", "PDA-2.4"));
			c.Add(new Component("Location Status", "PDA-2.5"));
			c.Add(new Component("Person Location Type", "PDA-2.6"));
			c.Add(new Component("Building", "PDA-2.7"));
			c.Add(new Component("Floor Number", "PDA-2.8"));
			c.Add(new Component("Location Description", "PDA-2.9"));
			c.Add(new Component("Comprehensive Location Identifier", "PDA-2.10"));
			c.Add(new Component("Assigning Authority for Location", "PDA-2.11"));
			f.Components = c;
			return f;
		}
		private Field PDA3()
		{
			Field f = new Field("Death Certified Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDA-3.1"));
			f.Components = c;
			return f;
		}
		private Field PDA4()
		{
			Field f = new Field("Death Certificate Signed Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PDA-4.1"));
			c.Add(new Component("Degree of Precision", "PDA-4.2"));
			f.Components = c;
			return f;
		}
		private Field PDA5()
		{
			Field f = new Field("Death Certified By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PDA-5.1"));
			c.Add(new Component("Family Name", "PDA-5.2"));
			c.Add(new Component("Given Name", "PDA-5.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PDA-5.4"));
			c.Add(new Component("Suffix", "PDA-5.5"));
			c.Add(new Component("Prefix", "PDA-5.6"));
			c.Add(new Component("Degree", "PDA-5.7"));
			c.Add(new Component("Source Table", "PDA-5.8"));
			c.Add(new Component("Assigning Authority", "PDA-5.9"));
			c.Add(new Component("Name Type Code", "PDA-5.10"));
			c.Add(new Component("Identifier Check Digit", "PDA-5.11"));
			c.Add(new Component("Check Digit Scheme", "PDA-5.12"));
			c.Add(new Component("Identifier Type Code", "PDA-5.13"));
			c.Add(new Component("Assigning Facility", "PDA-5.14"));
			c.Add(new Component("Name Respresentation Code", "PDA-5.15"));
			c.Add(new Component("Name Context", "PDA-5.16"));
			c.Add(new Component("Name Validity Range", "PDA-5.17"));
			c.Add(new Component("Name Assembly Order", "PDA-5.18"));
			c.Add(new Component("Effective Date", "PDA-5.19"));
			c.Add(new Component("Expiration Date", "PDA-5.20"));
			c.Add(new Component("Professional Suffix", "PDA-5.21"));
			c.Add(new Component("Assigning Jurisdiction", "PDA-5.22"));
			c.Add(new Component("Assigning Agency or Department", "PDA-5.23"));
			f.Components = c;
			return f;
		}
		private Field PDA6()
		{
			Field f = new Field("Autopsy Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDA-6.1"));
			f.Components = c;
			return f;
		}
		private Field PDA7()
		{
			Field f = new Field("Autopsy Start and End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Range Start Date/Time", "PDA-7.1"));
			c.Add(new Component("Range End Date/Time", "PDA-7.2"));
			f.Components = c;
			return f;
		}
		private Field PDA8()
		{
			Field f = new Field("Autopsy Performed By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PDA-8.1"));
			c.Add(new Component("Family Name", "PDA-8.2"));
			c.Add(new Component("Given Name", "PDA-8.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PDA-8.4"));
			c.Add(new Component("Suffix", "PDA-8.5"));
			c.Add(new Component("Prefix", "PDA-8.6"));
			c.Add(new Component("Degree", "PDA-8.7"));
			c.Add(new Component("Source Table", "PDA-8.8"));
			c.Add(new Component("Assigning Authority", "PDA-8.9"));
			c.Add(new Component("Name Type Code", "PDA-8.10"));
			c.Add(new Component("Identifier Check Digit", "PDA-8.11"));
			c.Add(new Component("Check Digit Scheme", "PDA-8.12"));
			c.Add(new Component("Identifier Type Code", "PDA-8.13"));
			c.Add(new Component("Assigning Facility", "PDA-8.14"));
			c.Add(new Component("Name Respresentation Code", "PDA-8.15"));
			c.Add(new Component("Name Context", "PDA-8.16"));
			c.Add(new Component("Name Validity Range", "PDA-8.17"));
			c.Add(new Component("Name Assembly Order", "PDA-8.18"));
			c.Add(new Component("Effective Date", "PDA-8.19"));
			c.Add(new Component("Expiration Date", "PDA-8.20"));
			c.Add(new Component("Professional Suffix", "PDA-8.21"));
			c.Add(new Component("Assigning Jurisdiction", "PDA-8.22"));
			c.Add(new Component("Assigning Agency or Department", "PDA-8.23"));
			f.Components = c;
			return f;
		}
		private Field PDA9()
		{
			Field f = new Field("Coroner Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PDA-9.1"));
			f.Components = c;
			return f;
		}
	}
}
