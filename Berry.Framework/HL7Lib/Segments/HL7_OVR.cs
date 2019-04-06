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
/// OVR Class: Constructs an HL7 OVR Segment Object
/// </summary>
public class OVR
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OVR()
		{
			Name = "OVR";
			Description = "Override Segment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OVR1());
			fs.Add(OVR2());
			fs.Add(OVR3());
			fs.Add(OVR4());
			fs.Add(OVR5());
			Fields = fs;
		}
		private Field OVR1()
		{
			Field f = new Field("Business Rule Override Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OVR-1.1"));
			c.Add(new Component("", "OVR-1.2"));
			c.Add(new Component("Name of Coding System", "OVR-1.3"));
			c.Add(new Component("Alternate Identifier", "OVR-1.4"));
			c.Add(new Component("Alternate Text", "OVR-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "OVR-1.6"));
			c.Add(new Component("Coding System Version ID", "OVR-1.7"));
			c.Add(new Component("Alternate Coding System Version ID", "OVR-1.8"));
			c.Add(new Component("Original Text", "OVR-1.9"));
			f.Components = c;
			return f;
		}
		private Field OVR2()
		{
			Field f = new Field("Business Rule Override Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OVR-2.1"));
			c.Add(new Component("", "OVR-2.2"));
			c.Add(new Component("Name of Coding System", "OVR-2.3"));
			c.Add(new Component("Alternate Identifier", "OVR-2.4"));
			c.Add(new Component("Alternate Text", "OVR-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "OVR-2.6"));
			c.Add(new Component("Coding System Version ID", "OVR-2.7"));
			c.Add(new Component("Alternate Coding System Version ID", "OVR-2.8"));
			c.Add(new Component("Original Text", "OVR-2.9"));
			f.Components = c;
			return f;
		}
		private Field OVR3()
		{
			Field f = new Field("Override Comments");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OVR-3.1"));
			f.Components = c;
			return f;
		}
		private Field OVR4()
		{
			Field f = new Field("Override Entered By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "OVR-4.1"));
			c.Add(new Component("Family Name", "OVR-4.2"));
			c.Add(new Component("Given Name", "OVR-4.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "OVR-4.4"));
			c.Add(new Component("Suffix", "OVR-4.5"));
			c.Add(new Component("Prefix", "OVR-4.6"));
			c.Add(new Component("Degree", "OVR-4.7"));
			c.Add(new Component("Source Table", "OVR-4.8"));
			c.Add(new Component("Assigning Authority", "OVR-4.9"));
			c.Add(new Component("Name Type Code", "OVR-4.10"));
			c.Add(new Component("Identifier Check Digit", "OVR-4.11"));
			c.Add(new Component("Check Digit Scheme", "OVR-4.12"));
			c.Add(new Component("Identifier Type Code", "OVR-4.13"));
			c.Add(new Component("Assigning Facility", "OVR-4.14"));
			c.Add(new Component("Name Respresentation Code", "OVR-4.15"));
			c.Add(new Component("Name Context", "OVR-4.16"));
			c.Add(new Component("Name Validity Range", "OVR-4.17"));
			c.Add(new Component("Name Assembly Order", "OVR-4.18"));
			c.Add(new Component("Effective Date", "OVR-4.19"));
			c.Add(new Component("Expiration Date", "OVR-4.20"));
			c.Add(new Component("Professional Suffix", "OVR-4.21"));
			c.Add(new Component("Assigning Jurisdiction", "OVR-4.22"));
			c.Add(new Component("Assigning Agency or Department", "OVR-4.23"));
			f.Components = c;
			return f;
		}
		private Field OVR5()
		{
			Field f = new Field("Override Authorized By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "OVR-5.1"));
			c.Add(new Component("Family Name", "OVR-5.2"));
			c.Add(new Component("Given Name", "OVR-5.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "OVR-5.4"));
			c.Add(new Component("Suffix", "OVR-5.5"));
			c.Add(new Component("Prefix", "OVR-5.6"));
			c.Add(new Component("Degree", "OVR-5.7"));
			c.Add(new Component("Source Table", "OVR-5.8"));
			c.Add(new Component("Assigning Authority", "OVR-5.9"));
			c.Add(new Component("Name Type Code", "OVR-5.10"));
			c.Add(new Component("Identifier Check Digit", "OVR-5.11"));
			c.Add(new Component("Check Digit Scheme", "OVR-5.12"));
			c.Add(new Component("Identifier Type Code", "OVR-5.13"));
			c.Add(new Component("Assigning Facility", "OVR-5.14"));
			c.Add(new Component("Name Respresentation Code", "OVR-5.15"));
			c.Add(new Component("Name Context", "OVR-5.16"));
			c.Add(new Component("Name Validity Range", "OVR-5.17"));
			c.Add(new Component("Name Assembly Order", "OVR-5.18"));
			c.Add(new Component("Effective Date", "OVR-5.19"));
			c.Add(new Component("Expiration Date", "OVR-5.20"));
			c.Add(new Component("Professional Suffix", "OVR-5.21"));
			c.Add(new Component("Assigning Jurisdiction", "OVR-5.22"));
			c.Add(new Component("Assigning Agency or Department", "OVR-5.23"));
			f.Components = c;
			return f;
		}
	}
}
