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
/// BPX Class: Constructs an HL7 BPX Segment Object
/// </summary>
public class BPX
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public BPX()
		{
			Name = "BPX";
			Description = "Blood product dispense status";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(BPX1());
			fs.Add(BPX2());
			fs.Add(BPX3());
			fs.Add(BPX4());
			fs.Add(BPX5());
			fs.Add(BPX6());
			fs.Add(BPX7());
			fs.Add(BPX8());
			fs.Add(BPX9());
			fs.Add(BPX10());
			fs.Add(BPX11());
			fs.Add(BPX12());
			fs.Add(BPX13());
			fs.Add(BPX14());
			fs.Add(BPX15());
			fs.Add(BPX16());
			fs.Add(BPX17());
			fs.Add(BPX18());
			fs.Add(BPX19());
			fs.Add(BPX20());
			fs.Add(BPX21());
			Fields = fs;
		}
		private Field BPX1()
		{
			Field f = new Field("Set ID _ BPX");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "BPX-1.1"));
			f.Components = c;
			return f;
		}
		private Field BPX2()
		{
			Field f = new Field("BP Dispense Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPX-2.1"));
			c.Add(new Component("", "BPX-2.2"));
			c.Add(new Component("Name of Coding System", "BPX-2.3"));
			c.Add(new Component("Alternate Identifier", "BPX-2.4"));
			c.Add(new Component("Alternate Text", "BPX-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPX-2.6"));
			c.Add(new Component("Coding System Version ID", "BPX-2.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPX-2.8"));
			c.Add(new Component("Original Text", "BPX-2.9"));
			f.Components = c;
			return f;
		}
		private Field BPX3()
		{
			Field f = new Field("BP Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BPX-3.1"));
			f.Components = c;
			return f;
		}
		private Field BPX4()
		{
			Field f = new Field("BP Date/Time of Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "BPX-4.1"));
			c.Add(new Component("Degree of Precision", "BPX-4.2"));
			f.Components = c;
			return f;
		}
		private Field BPX5()
		{
			Field f = new Field("BC Donation ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "BPX-5.1"));
			c.Add(new Component("Namespace ID", "BPX-5.2"));
			c.Add(new Component("Universal ID", "BPX-5.3"));
			c.Add(new Component("Universal ID Type", "BPX-5.4"));
			f.Components = c;
			return f;
		}
		private Field BPX6()
		{
			Field f = new Field("BC Component");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPX-6.1"));
			c.Add(new Component("", "BPX-6.2"));
			c.Add(new Component("Name of Coding System", "BPX-6.3"));
			c.Add(new Component("Alternate Identifier", "BPX-6.4"));
			c.Add(new Component("Alternate Text", "BPX-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPX-6.6"));
			c.Add(new Component("Coding System Version ID", "BPX-6.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPX-6.8"));
			c.Add(new Component("Original Text", "BPX-6.9"));
			f.Components = c;
			return f;
		}
		private Field BPX7()
		{
			Field f = new Field("BC Donation Type / Intended Use");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPX-7.1"));
			c.Add(new Component("", "BPX-7.2"));
			c.Add(new Component("Name of Coding System", "BPX-7.3"));
			c.Add(new Component("Alternate Identifier", "BPX-7.4"));
			c.Add(new Component("Alternate Text", "BPX-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPX-7.6"));
			c.Add(new Component("Coding System Version ID", "BPX-7.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPX-7.8"));
			c.Add(new Component("Original Text", "BPX-7.9"));
			f.Components = c;
			return f;
		}
		private Field BPX8()
		{
			Field f = new Field("CP Commercial Product");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPX-8.1"));
			c.Add(new Component("", "BPX-8.2"));
			c.Add(new Component("Name of Coding System", "BPX-8.3"));
			c.Add(new Component("Alternate Identifier", "BPX-8.4"));
			c.Add(new Component("Alternate Text", "BPX-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPX-8.6"));
			c.Add(new Component("Coding System Version ID", "BPX-8.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPX-8.8"));
			c.Add(new Component("Original Text", "BPX-8.9"));
			f.Components = c;
			return f;
		}
		private Field BPX9()
		{
			Field f = new Field("CP Manufacturer");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "BPX-9.1"));
			c.Add(new Component("Organization Name Type Code", "BPX-9.2"));
			c.Add(new Component("ID Number", "BPX-9.3"));
			c.Add(new Component("Check Digit", "BPX-9.4"));
			c.Add(new Component("Check Digit Scheme", "BPX-9.5"));
			c.Add(new Component("Assigning Authority", "BPX-9.6"));
			c.Add(new Component("Identifier Type Code", "BPX-9.7"));
			c.Add(new Component("Assigning Facility", "BPX-9.8"));
			c.Add(new Component("Name Respresentation Code", "BPX-9.9"));
			c.Add(new Component("Organization Identifier", "BPX-9.10"));
			f.Components = c;
			return f;
		}
		private Field BPX10()
		{
			Field f = new Field("CP Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "BPX-10.1"));
			c.Add(new Component("Namespace ID", "BPX-10.2"));
			c.Add(new Component("Universal ID", "BPX-10.3"));
			c.Add(new Component("Universal ID Type", "BPX-10.4"));
			f.Components = c;
			return f;
		}
		private Field BPX11()
		{
			Field f = new Field("BP Blood Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPX-11.1"));
			c.Add(new Component("", "BPX-11.2"));
			c.Add(new Component("Name of Coding System", "BPX-11.3"));
			c.Add(new Component("Alternate Identifier", "BPX-11.4"));
			c.Add(new Component("Alternate Text", "BPX-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPX-11.6"));
			c.Add(new Component("Coding System Version ID", "BPX-11.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPX-11.8"));
			c.Add(new Component("Original Text", "BPX-11.9"));
			f.Components = c;
			return f;
		}
		private Field BPX12()
		{
			Field f = new Field("BC Special Testing");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPX-12.1"));
			c.Add(new Component("", "BPX-12.2"));
			c.Add(new Component("Name of Coding System", "BPX-12.3"));
			c.Add(new Component("Alternate Identifier", "BPX-12.4"));
			c.Add(new Component("Alternate Text", "BPX-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPX-12.6"));
			c.Add(new Component("Coding System Version ID", "BPX-12.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPX-12.8"));
			c.Add(new Component("Original Text", "BPX-12.9"));
			f.Components = c;
			return f;
		}
		private Field BPX13()
		{
			Field f = new Field("BP Expiration Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "BPX-13.1"));
			c.Add(new Component("Degree of Precision", "BPX-13.2"));
			f.Components = c;
			return f;
		}
		private Field BPX14()
		{
			Field f = new Field("BP Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BPX-14.1"));
			f.Components = c;
			return f;
		}
		private Field BPX15()
		{
			Field f = new Field("BP Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BPX-15.1"));
			f.Components = c;
			return f;
		}
		private Field BPX16()
		{
			Field f = new Field("BP Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPX-16.1"));
			c.Add(new Component("", "BPX-16.2"));
			c.Add(new Component("Name of Coding System", "BPX-16.3"));
			c.Add(new Component("Alternate Identifier", "BPX-16.4"));
			c.Add(new Component("Alternate Text", "BPX-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPX-16.6"));
			f.Components = c;
			return f;
		}
		private Field BPX17()
		{
			Field f = new Field("BP Unique ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "BPX-17.1"));
			c.Add(new Component("Namespace ID", "BPX-17.2"));
			c.Add(new Component("Universal ID", "BPX-17.3"));
			c.Add(new Component("Universal ID Type", "BPX-17.4"));
			f.Components = c;
			return f;
		}
		private Field BPX18()
		{
			Field f = new Field("BP Actual Dispensed To Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "BPX-18.1"));
			c.Add(new Component("Room", "BPX-18.2"));
			c.Add(new Component("Bed", "BPX-18.3"));
			c.Add(new Component("Facility", "BPX-18.4"));
			c.Add(new Component("Location Status", "BPX-18.5"));
			c.Add(new Component("Person Location Type", "BPX-18.6"));
			c.Add(new Component("Building", "BPX-18.7"));
			c.Add(new Component("Floor Number", "BPX-18.8"));
			c.Add(new Component("Location Description", "BPX-18.9"));
			c.Add(new Component("Comprehensive Location Identifier", "BPX-18.10"));
			c.Add(new Component("Assigning Authority for Location", "BPX-18.11"));
			f.Components = c;
			return f;
		}
		private Field BPX19()
		{
			Field f = new Field("BP Actual Dispensed To Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "BPX-19.1"));
			c.Add(new Component("Other Designation", "BPX-19.2"));
			c.Add(new Component("City", "BPX-19.3"));
			c.Add(new Component("State or Province", "BPX-19.4"));
			c.Add(new Component("Zip or Postal Code", "BPX-19.5"));
			c.Add(new Component("Country", "BPX-19.6"));
			c.Add(new Component("Address Type", "BPX-19.7"));
			c.Add(new Component("Other Geographic Designation", "BPX-19.8"));
			c.Add(new Component("Country Parish Code", "BPX-19.9"));
			c.Add(new Component("Census Tract", "BPX-19.10"));
			c.Add(new Component("Address Representation Code", "BPX-19.11"));
			c.Add(new Component("Address Validity Range", "BPX-19.12"));
			c.Add(new Component("Effective Date", "BPX-19.13"));
			c.Add(new Component("Expiration Date", "BPX-19.14"));
			f.Components = c;
			return f;
		}
		private Field BPX20()
		{
			Field f = new Field("BP Dispensed to Receiver");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "BPX-20.1"));
			c.Add(new Component("Family Name", "BPX-20.2"));
			c.Add(new Component("Given Name", "BPX-20.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "BPX-20.4"));
			c.Add(new Component("Suffix", "BPX-20.5"));
			c.Add(new Component("Prefix", "BPX-20.6"));
			c.Add(new Component("Degree", "BPX-20.7"));
			c.Add(new Component("Source Table", "BPX-20.8"));
			c.Add(new Component("Assigning Authority", "BPX-20.9"));
			c.Add(new Component("Name Type Code", "BPX-20.10"));
			c.Add(new Component("Identifier Check Digit", "BPX-20.11"));
			c.Add(new Component("Check Digit Scheme", "BPX-20.12"));
			c.Add(new Component("Identifier Type Code", "BPX-20.13"));
			c.Add(new Component("Assigning Facility", "BPX-20.14"));
			c.Add(new Component("Name Respresentation Code", "BPX-20.15"));
			c.Add(new Component("Name Context", "BPX-20.16"));
			c.Add(new Component("Name Validity Range", "BPX-20.17"));
			c.Add(new Component("Name Assembly Order", "BPX-20.18"));
			c.Add(new Component("Effective Date", "BPX-20.19"));
			c.Add(new Component("Expiration Date", "BPX-20.20"));
			c.Add(new Component("Professional Suffix", "BPX-20.21"));
			c.Add(new Component("Assigning Jurisdiction", "BPX-20.22"));
			c.Add(new Component("Assigning Agency or Department", "BPX-20.23"));
			f.Components = c;
			return f;
		}
		private Field BPX21()
		{
			Field f = new Field("BP Dispensing Individual");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "BPX-21.1"));
			c.Add(new Component("Family Name", "BPX-21.2"));
			c.Add(new Component("Given Name", "BPX-21.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "BPX-21.4"));
			c.Add(new Component("Suffix", "BPX-21.5"));
			c.Add(new Component("Prefix", "BPX-21.6"));
			c.Add(new Component("Degree", "BPX-21.7"));
			c.Add(new Component("Source Table", "BPX-21.8"));
			c.Add(new Component("Assigning Authority", "BPX-21.9"));
			c.Add(new Component("Name Type Code", "BPX-21.10"));
			c.Add(new Component("Identifier Check Digit", "BPX-21.11"));
			c.Add(new Component("Check Digit Scheme", "BPX-21.12"));
			c.Add(new Component("Identifier Type Code", "BPX-21.13"));
			c.Add(new Component("Assigning Facility", "BPX-21.14"));
			c.Add(new Component("Name Respresentation Code", "BPX-21.15"));
			c.Add(new Component("Name Context", "BPX-21.16"));
			c.Add(new Component("Name Validity Range", "BPX-21.17"));
			c.Add(new Component("Name Assembly Order", "BPX-21.18"));
			c.Add(new Component("Effective Date", "BPX-21.19"));
			c.Add(new Component("Expiration Date", "BPX-21.20"));
			c.Add(new Component("Professional Suffix", "BPX-21.21"));
			c.Add(new Component("Assigning Jurisdiction", "BPX-21.22"));
			c.Add(new Component("Assigning Agency or Department", "BPX-21.23"));
			f.Components = c;
			return f;
		}
	}
}
