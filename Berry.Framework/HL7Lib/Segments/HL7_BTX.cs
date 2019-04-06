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
/// BTX Class: Constructs an HL7 BTX Segment Object
/// </summary>
public class BTX
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public BTX()
		{
			Name = "BTX";
			Description = "Blood Product Transfusion/Disposition";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(BTX1());
			fs.Add(BTX2());
			fs.Add(BTX3());
			fs.Add(BTX4());
			fs.Add(BTX5());
			fs.Add(BTX6());
			fs.Add(BTX7());
			fs.Add(BTX8());
			fs.Add(BTX9());
			fs.Add(BTX10());
			fs.Add(BTX11());
			fs.Add(BTX12());
			fs.Add(BTX13());
			fs.Add(BTX14());
			fs.Add(BTX15());
			fs.Add(BTX16());
			fs.Add(BTX17());
			fs.Add(BTX18());
			fs.Add(BTX19());
			Fields = fs;
		}
		private Field BTX1()
		{
			Field f = new Field("Set ID _ BTX");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "BTX-1.1"));
			f.Components = c;
			return f;
		}
		private Field BTX2()
		{
			Field f = new Field("BC Donation ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "BTX-2.1"));
			c.Add(new Component("Namespace ID", "BTX-2.2"));
			c.Add(new Component("Universal ID", "BTX-2.3"));
			c.Add(new Component("Universal ID Type", "BTX-2.4"));
			f.Components = c;
			return f;
		}
		private Field BTX3()
		{
			Field f = new Field("BC Component");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BTX-3.1"));
			c.Add(new Component("", "BTX-3.2"));
			c.Add(new Component("Name of Coding System", "BTX-3.3"));
			c.Add(new Component("Alternate Identifier", "BTX-3.4"));
			c.Add(new Component("Alternate Text", "BTX-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "BTX-3.6"));
			c.Add(new Component("Coding System Version ID", "BTX-3.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BTX-3.8"));
			c.Add(new Component("Original Text", "BTX-3.9"));
			f.Components = c;
			return f;
		}
		private Field BTX4()
		{
			Field f = new Field("BC Blood Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BTX-4.1"));
			c.Add(new Component("", "BTX-4.2"));
			c.Add(new Component("Name of Coding System", "BTX-4.3"));
			c.Add(new Component("Alternate Identifier", "BTX-4.4"));
			c.Add(new Component("Alternate Text", "BTX-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "BTX-4.6"));
			c.Add(new Component("Coding System Version ID", "BTX-4.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BTX-4.8"));
			c.Add(new Component("Original Text", "BTX-4.9"));
			f.Components = c;
			return f;
		}
		private Field BTX5()
		{
			Field f = new Field("CP Commercial Product");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BTX-5.1"));
			c.Add(new Component("", "BTX-5.2"));
			c.Add(new Component("Name of Coding System", "BTX-5.3"));
			c.Add(new Component("Alternate Identifier", "BTX-5.4"));
			c.Add(new Component("Alternate Text", "BTX-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "BTX-5.6"));
			c.Add(new Component("Coding System Version ID", "BTX-5.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BTX-5.8"));
			c.Add(new Component("Original Text", "BTX-5.9"));
			f.Components = c;
			return f;
		}
		private Field BTX6()
		{
			Field f = new Field("CP Manufacturer");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "BTX-6.1"));
			c.Add(new Component("Organization Name Type Code", "BTX-6.2"));
			c.Add(new Component("ID Number", "BTX-6.3"));
			c.Add(new Component("Check Digit", "BTX-6.4"));
			c.Add(new Component("Check Digit Scheme", "BTX-6.5"));
			c.Add(new Component("Assigning Authority", "BTX-6.6"));
			c.Add(new Component("Identifier Type Code", "BTX-6.7"));
			c.Add(new Component("Assigning Facility", "BTX-6.8"));
			c.Add(new Component("Name Respresentation Code", "BTX-6.9"));
			c.Add(new Component("Organization Identifier", "BTX-6.10"));
			f.Components = c;
			return f;
		}
		private Field BTX7()
		{
			Field f = new Field("CP Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "BTX-7.1"));
			c.Add(new Component("Namespace ID", "BTX-7.2"));
			c.Add(new Component("Universal ID", "BTX-7.3"));
			c.Add(new Component("Universal ID Type", "BTX-7.4"));
			f.Components = c;
			return f;
		}
		private Field BTX8()
		{
			Field f = new Field("BP Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BTX-8.1"));
			f.Components = c;
			return f;
		}
		private Field BTX9()
		{
			Field f = new Field("BP Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BTX-9.1"));
			f.Components = c;
			return f;
		}
		private Field BTX10()
		{
			Field f = new Field("BP Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BTX-10.1"));
			c.Add(new Component("", "BTX-10.2"));
			c.Add(new Component("Name of Coding System", "BTX-10.3"));
			c.Add(new Component("Alternate Identifier", "BTX-10.4"));
			c.Add(new Component("Alternate Text", "BTX-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "BTX-10.6"));
			f.Components = c;
			return f;
		}
		private Field BTX11()
		{
			Field f = new Field("BP Transfusion/Disposition Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BTX-11.1"));
			c.Add(new Component("", "BTX-11.2"));
			c.Add(new Component("Name of Coding System", "BTX-11.3"));
			c.Add(new Component("Alternate Identifier", "BTX-11.4"));
			c.Add(new Component("Alternate Text", "BTX-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "BTX-11.6"));
			c.Add(new Component("Coding System Version ID", "BTX-11.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BTX-11.8"));
			c.Add(new Component("Original Text", "BTX-11.9"));
			f.Components = c;
			return f;
		}
		private Field BTX12()
		{
			Field f = new Field("BP Message Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BTX-12.1"));
			f.Components = c;
			return f;
		}
		private Field BTX13()
		{
			Field f = new Field("BP Date/Time of Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "BTX-13.1"));
			c.Add(new Component("Degree of Precision", "BTX-13.2"));
			f.Components = c;
			return f;
		}
		private Field BTX14()
		{
			Field f = new Field("BP Administrator");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "BTX-14.1"));
			c.Add(new Component("Family Name", "BTX-14.2"));
			c.Add(new Component("Given Name", "BTX-14.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "BTX-14.4"));
			c.Add(new Component("Suffix", "BTX-14.5"));
			c.Add(new Component("Prefix", "BTX-14.6"));
			c.Add(new Component("Degree", "BTX-14.7"));
			c.Add(new Component("Source Table", "BTX-14.8"));
			c.Add(new Component("Assigning Authority", "BTX-14.9"));
			c.Add(new Component("Name Type Code", "BTX-14.10"));
			c.Add(new Component("Identifier Check Digit", "BTX-14.11"));
			c.Add(new Component("Check Digit Scheme", "BTX-14.12"));
			c.Add(new Component("Identifier Type Code", "BTX-14.13"));
			c.Add(new Component("Assigning Facility", "BTX-14.14"));
			c.Add(new Component("Name Respresentation Code", "BTX-14.15"));
			c.Add(new Component("Name Context", "BTX-14.16"));
			c.Add(new Component("Name Validity Range", "BTX-14.17"));
			c.Add(new Component("Name Assembly Order", "BTX-14.18"));
			c.Add(new Component("Effective Date", "BTX-14.19"));
			c.Add(new Component("Expiration Date", "BTX-14.20"));
			c.Add(new Component("Professional Suffix", "BTX-14.21"));
			c.Add(new Component("Assigning Jurisdiction", "BTX-14.22"));
			c.Add(new Component("Assigning Agency or Department", "BTX-14.23"));
			f.Components = c;
			return f;
		}
		private Field BTX15()
		{
			Field f = new Field("BP Verifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "BTX-15.1"));
			c.Add(new Component("Family Name", "BTX-15.2"));
			c.Add(new Component("Given Name", "BTX-15.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "BTX-15.4"));
			c.Add(new Component("Suffix", "BTX-15.5"));
			c.Add(new Component("Prefix", "BTX-15.6"));
			c.Add(new Component("Degree", "BTX-15.7"));
			c.Add(new Component("Source Table", "BTX-15.8"));
			c.Add(new Component("Assigning Authority", "BTX-15.9"));
			c.Add(new Component("Name Type Code", "BTX-15.10"));
			c.Add(new Component("Identifier Check Digit", "BTX-15.11"));
			c.Add(new Component("Check Digit Scheme", "BTX-15.12"));
			c.Add(new Component("Identifier Type Code", "BTX-15.13"));
			c.Add(new Component("Assigning Facility", "BTX-15.14"));
			c.Add(new Component("Name Respresentation Code", "BTX-15.15"));
			c.Add(new Component("Name Context", "BTX-15.16"));
			c.Add(new Component("Name Validity Range", "BTX-15.17"));
			c.Add(new Component("Name Assembly Order", "BTX-15.18"));
			c.Add(new Component("Effective Date", "BTX-15.19"));
			c.Add(new Component("Expiration Date", "BTX-15.20"));
			c.Add(new Component("Professional Suffix", "BTX-15.21"));
			c.Add(new Component("Assigning Jurisdiction", "BTX-15.22"));
			c.Add(new Component("Assigning Agency or Department", "BTX-15.23"));
			f.Components = c;
			return f;
		}
		private Field BTX16()
		{
			Field f = new Field("BP Transfusion Start Date/Time of Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "BTX-16.1"));
			c.Add(new Component("Degree of Precision", "BTX-16.2"));
			f.Components = c;
			return f;
		}
		private Field BTX17()
		{
			Field f = new Field("BP Transfusion End Date/Time of Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "BTX-17.1"));
			c.Add(new Component("Degree of Precision", "BTX-17.2"));
			f.Components = c;
			return f;
		}
		private Field BTX18()
		{
			Field f = new Field("BP Adverse Reaction Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BTX-18.1"));
			c.Add(new Component("", "BTX-18.2"));
			c.Add(new Component("Name of Coding System", "BTX-18.3"));
			c.Add(new Component("Alternate Identifier", "BTX-18.4"));
			c.Add(new Component("Alternate Text", "BTX-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "BTX-18.6"));
			c.Add(new Component("Coding System Version ID", "BTX-18.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BTX-18.8"));
			c.Add(new Component("Original Text", "BTX-18.9"));
			f.Components = c;
			return f;
		}
		private Field BTX19()
		{
			Field f = new Field("BP Transfusion Interrupted Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BTX-19.1"));
			c.Add(new Component("", "BTX-19.2"));
			c.Add(new Component("Name of Coding System", "BTX-19.3"));
			c.Add(new Component("Alternate Identifier", "BTX-19.4"));
			c.Add(new Component("Alternate Text", "BTX-19.5"));
			c.Add(new Component("Name of Alternate Coding System", "BTX-19.6"));
			c.Add(new Component("Coding System Version ID", "BTX-19.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BTX-19.8"));
			c.Add(new Component("Original Text", "BTX-19.9"));
			f.Components = c;
			return f;
		}
	}
}
