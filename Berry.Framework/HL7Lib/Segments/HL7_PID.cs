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
/// PID Class: Constructs an HL7 PID Segment Object
/// </summary>
public class PID
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PID()
		{
			Name = "PID";
			Description = "Patient Identification";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PID1());
			fs.Add(PID2());
			fs.Add(PID3());
			fs.Add(PID4());
			fs.Add(PID5());
			fs.Add(PID6());
			fs.Add(PID7());
			fs.Add(PID8());
			fs.Add(PID9());
			fs.Add(PID10());
			fs.Add(PID11());
			fs.Add(PID12());
			fs.Add(PID13());
			fs.Add(PID14());
			fs.Add(PID15());
			fs.Add(PID16());
			fs.Add(PID17());
			fs.Add(PID18());
			fs.Add(PID19());
			fs.Add(PID20());
			fs.Add(PID21());
			fs.Add(PID22());
			fs.Add(PID23());
			fs.Add(PID24());
			fs.Add(PID25());
			fs.Add(PID26());
			fs.Add(PID27());
			fs.Add(PID28());
			fs.Add(PID29());
			fs.Add(PID30());
			fs.Add(PID31());
			fs.Add(PID32());
			fs.Add(PID33());
			fs.Add(PID34());
			fs.Add(PID35());
			fs.Add(PID36());
			fs.Add(PID37());
			fs.Add(PID38());
			fs.Add(PID39());
			Fields = fs;
		}
		private Field PID1()
		{
			Field f = new Field("Set ID - PID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "PID-1.1"));
			f.Components = c;
			return f;
		}
		private Field PID2()
		{
			Field f = new Field("Patient ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PID-2.1"));
			c.Add(new Component("Check Digit", "PID-2.2"));
			c.Add(new Component("Check Digit Scheme", "PID-2.3"));
			c.Add(new Component("Assigning Authority", "PID-2.4"));
			c.Add(new Component("Identifier Type Code", "PID-2.5"));
			c.Add(new Component("Assigning Facility", "PID-2.6"));
			c.Add(new Component("Effective Date", "PID-2.7"));
			c.Add(new Component("Expiration Date", "PID-2.8"));
			c.Add(new Component("Assigning Jurisdiction", "PID-2.9"));
			c.Add(new Component("Assigning Agency or Department", "PID-2.10"));
			f.Components = c;
			return f;
		}
		private Field PID3()
		{
			Field f = new Field("Patient Identifier List");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PID-3.1"));
			c.Add(new Component("Check Digit", "PID-3.2"));
			c.Add(new Component("Check Digit Scheme", "PID-3.3"));
			c.Add(new Component("Assigning Authority", "PID-3.4"));
			c.Add(new Component("Identifier Type Code", "PID-3.5"));
			c.Add(new Component("Assigning Facility", "PID-3.6"));
			c.Add(new Component("Effective Date", "PID-3.7"));
			c.Add(new Component("Expiration Date", "PID-3.8"));
			c.Add(new Component("Assigning Jurisdiction", "PID-3.9"));
			c.Add(new Component("Assigning Agency or Department", "PID-3.10"));
			f.Components = c;
			return f;
		}
		private Field PID4()
		{
			Field f = new Field("Alternate Patient ID - PID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PID-4.1"));
			c.Add(new Component("Check Digit", "PID-4.2"));
			c.Add(new Component("Check Digit Scheme", "PID-4.3"));
			c.Add(new Component("Assigning Authority", "PID-4.4"));
			c.Add(new Component("Identifier Type Code", "PID-4.5"));
			c.Add(new Component("Assigning Facility", "PID-4.6"));
			c.Add(new Component("Effective Date", "PID-4.7"));
			c.Add(new Component("Expiration Date", "PID-4.8"));
			c.Add(new Component("Assigning Jurisdiction", "PID-4.9"));
			c.Add(new Component("Assigning Agency or Department", "PID-4.10"));
			f.Components = c;
			return f;
		}
		private Field PID5()
		{
			Field f = new Field("Patient Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "PID-5.1"));
			c.Add(new Component("Given Name", "PID-5.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PID-5.3"));
			c.Add(new Component("Suffix", "PID-5.4"));
			c.Add(new Component("Prefix", "PID-5.5"));
			c.Add(new Component("Degree", "PID-5.6"));
			c.Add(new Component("Name Type Code", "PID-5.7"));
			c.Add(new Component("Name Respresentation Code", "PID-5.8"));
			c.Add(new Component("Name Context", "PID-5.9"));
			c.Add(new Component("Name Validity Range", "PID-5.10"));
			c.Add(new Component("Name Assembly Order", "PID-5.11"));
			c.Add(new Component("Effective Date", "PID-5.12"));
			c.Add(new Component("Expiration Date", "PID-5.13"));
			c.Add(new Component("Professional Suffix", "PID-5.14"));
			f.Components = c;
			return f;
		}
		private Field PID6()
		{
			Field f = new Field("Mother's Maiden Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "PID-6.1"));
			c.Add(new Component("Given Name", "PID-6.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PID-6.3"));
			c.Add(new Component("Suffix", "PID-6.4"));
			c.Add(new Component("Prefix", "PID-6.5"));
			c.Add(new Component("Degree", "PID-6.6"));
			c.Add(new Component("Name Type Code", "PID-6.7"));
			c.Add(new Component("Name Respresentation Code", "PID-6.8"));
			c.Add(new Component("Name Context", "PID-6.9"));
			c.Add(new Component("Name Validity Range", "PID-6.10"));
			c.Add(new Component("Name Assembly Order", "PID-6.11"));
			c.Add(new Component("Effective Date", "PID-6.12"));
			c.Add(new Component("Expiration Date", "PID-6.13"));
			c.Add(new Component("Professional Suffix", "PID-6.14"));
			f.Components = c;
			return f;
		}
		private Field PID7()
		{
			Field f = new Field("Date/Time of Birth");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PID-7.1"));
			c.Add(new Component("Degree of Precision", "PID-7.2"));
			f.Components = c;
			return f;
		}
		private Field PID8()
		{
			Field f = new Field("Administrative Sex");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-8.1"));
			f.Components = c;
			return f;
		}
		private Field PID9()
		{
			Field f = new Field("Patient Alias");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "PID-9.1"));
			c.Add(new Component("Given Name", "PID-9.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PID-9.3"));
			c.Add(new Component("Suffix", "PID-9.4"));
			c.Add(new Component("Prefix", "PID-9.5"));
			c.Add(new Component("Degree", "PID-9.6"));
			c.Add(new Component("Name Type Code", "PID-9.7"));
			c.Add(new Component("Name Respresentation Code", "PID-9.8"));
			c.Add(new Component("Name Context", "PID-9.9"));
			c.Add(new Component("Name Validity Range", "PID-9.10"));
			c.Add(new Component("Name Assembly Order", "PID-9.11"));
			c.Add(new Component("Effective Date", "PID-9.12"));
			c.Add(new Component("Expiration Date", "PID-9.13"));
			c.Add(new Component("Professional Suffix", "PID-9.14"));
			f.Components = c;
			return f;
		}
		private Field PID10()
		{
			Field f = new Field("Race");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-10.1"));
			c.Add(new Component("", "PID-10.2"));
			c.Add(new Component("Name of Coding System", "PID-10.3"));
			c.Add(new Component("Alternate Identifier", "PID-10.4"));
			c.Add(new Component("Alternate Text", "PID-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-10.6"));
			f.Components = c;
			return f;
		}
		private Field PID11()
		{
			Field f = new Field("Patient Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "PID-11.1"));
			c.Add(new Component("Other Designation", "PID-11.2"));
			c.Add(new Component("City", "PID-11.3"));
			c.Add(new Component("State or Province", "PID-11.4"));
			c.Add(new Component("Zip or Postal Code", "PID-11.5"));
			c.Add(new Component("Country", "PID-11.6"));
			c.Add(new Component("Address Type", "PID-11.7"));
			c.Add(new Component("Other Geographic Designation", "PID-11.8"));
			c.Add(new Component("Country Parish Code", "PID-11.9"));
			c.Add(new Component("Census Tract", "PID-11.10"));
			c.Add(new Component("Address Representation Code", "PID-11.11"));
			c.Add(new Component("Address Validity Range", "PID-11.12"));
			c.Add(new Component("Effective Date", "PID-11.13"));
			c.Add(new Component("Expiration Date", "PID-11.14"));
			f.Components = c;
			return f;
		}
		private Field PID12()
		{
			Field f = new Field("County Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-12.1"));
			f.Components = c;
			return f;
		}
		private Field PID13()
		{
			Field f = new Field("Phone Number - Home");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "PID-13.1"));
			c.Add(new Component("Tele-Communication Use Code", "PID-13.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "PID-13.3"));
			c.Add(new Component("Email Address", "PID-13.4"));
			c.Add(new Component("Country Code", "PID-13.5"));
			c.Add(new Component("Area City Code", "PID-13.6"));
			c.Add(new Component("Local Number", "PID-13.7"));
			c.Add(new Component("Extension", "PID-13.8"));
			c.Add(new Component("", "PID-13.9"));
			c.Add(new Component("Extension Prefix", "PID-13.10"));
			c.Add(new Component("Speed Dial Code", "PID-13.11"));
			c.Add(new Component("Unformatted Telephone Number", "PID-13.12"));
			f.Components = c;
			return f;
		}
		private Field PID14()
		{
			Field f = new Field("Phone Number - Business");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "PID-14.1"));
			c.Add(new Component("Tele-Communication Use Code", "PID-14.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "PID-14.3"));
			c.Add(new Component("Email Address", "PID-14.4"));
			c.Add(new Component("Country Code", "PID-14.5"));
			c.Add(new Component("Area City Code", "PID-14.6"));
			c.Add(new Component("Local Number", "PID-14.7"));
			c.Add(new Component("Extension", "PID-14.8"));
			c.Add(new Component("", "PID-14.9"));
			c.Add(new Component("Extension Prefix", "PID-14.10"));
			c.Add(new Component("Speed Dial Code", "PID-14.11"));
			c.Add(new Component("Unformatted Telephone Number", "PID-14.12"));
			f.Components = c;
			return f;
		}
		private Field PID15()
		{
			Field f = new Field("Primary Language");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-15.1"));
			c.Add(new Component("", "PID-15.2"));
			c.Add(new Component("Name of Coding System", "PID-15.3"));
			c.Add(new Component("Alternate Identifier", "PID-15.4"));
			c.Add(new Component("Alternate Text", "PID-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-15.6"));
			f.Components = c;
			return f;
		}
		private Field PID16()
		{
			Field f = new Field("Marital Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-16.1"));
			c.Add(new Component("", "PID-16.2"));
			c.Add(new Component("Name of Coding System", "PID-16.3"));
			c.Add(new Component("Alternate Identifier", "PID-16.4"));
			c.Add(new Component("Alternate Text", "PID-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-16.6"));
			f.Components = c;
			return f;
		}
		private Field PID17()
		{
			Field f = new Field("Religion");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-17.1"));
			c.Add(new Component("", "PID-17.2"));
			c.Add(new Component("Name of Coding System", "PID-17.3"));
			c.Add(new Component("Alternate Identifier", "PID-17.4"));
			c.Add(new Component("Alternate Text", "PID-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-17.6"));
			f.Components = c;
			return f;
		}
		private Field PID18()
		{
			Field f = new Field("Patient Account Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PID-18.1"));
			c.Add(new Component("Check Digit", "PID-18.2"));
			c.Add(new Component("Check Digit Scheme", "PID-18.3"));
			c.Add(new Component("Assigning Authority", "PID-18.4"));
			c.Add(new Component("Identifier Type Code", "PID-18.5"));
			c.Add(new Component("Assigning Facility", "PID-18.6"));
			c.Add(new Component("Effective Date", "PID-18.7"));
			c.Add(new Component("Expiration Date", "PID-18.8"));
			c.Add(new Component("Assigning Jurisdiction", "PID-18.9"));
			c.Add(new Component("Assigning Agency or Department", "PID-18.10"));
			f.Components = c;
			return f;
		}
		private Field PID19()
		{
			Field f = new Field("SSN Number - Patient");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-19.1"));
			f.Components = c;
			return f;
		}
		private Field PID20()
		{
			Field f = new Field("Driver's License Number - Patient");
			List<Component> c = new List<Component>();
			c.Add(new Component("License Number", "PID-20.1"));
			c.Add(new Component("Issuing State, Province, or Country", "PID-20.2"));
			c.Add(new Component("Expiration Date", "PID-20.3"));
			f.Components = c;
			return f;
		}
		private Field PID21()
		{
			Field f = new Field("Mother's Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PID-21.1"));
			c.Add(new Component("Check Digit", "PID-21.2"));
			c.Add(new Component("Check Digit Scheme", "PID-21.3"));
			c.Add(new Component("Assigning Authority", "PID-21.4"));
			c.Add(new Component("Identifier Type Code", "PID-21.5"));
			c.Add(new Component("Assigning Facility", "PID-21.6"));
			c.Add(new Component("Effective Date", "PID-21.7"));
			c.Add(new Component("Expiration Date", "PID-21.8"));
			c.Add(new Component("Assigning Jurisdiction", "PID-21.9"));
			c.Add(new Component("Assigning Agency or Department", "PID-21.10"));
			f.Components = c;
			return f;
		}
		private Field PID22()
		{
			Field f = new Field("Ethnic Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-22.1"));
			c.Add(new Component("", "PID-22.2"));
			c.Add(new Component("Name of Coding System", "PID-22.3"));
			c.Add(new Component("Alternate Identifier", "PID-22.4"));
			c.Add(new Component("Alternate Text", "PID-22.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-22.6"));
			f.Components = c;
			return f;
		}
		private Field PID23()
		{
			Field f = new Field("Birth Place");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-23.1"));
			f.Components = c;
			return f;
		}
		private Field PID24()
		{
			Field f = new Field("Multiple Birth Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-24.1"));
			f.Components = c;
			return f;
		}
		private Field PID25()
		{
			Field f = new Field("Birth Order");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-25.1"));
			f.Components = c;
			return f;
		}
		private Field PID26()
		{
			Field f = new Field("Citizenship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-26.1"));
			c.Add(new Component("", "PID-26.2"));
			c.Add(new Component("Name of Coding System", "PID-26.3"));
			c.Add(new Component("Alternate Identifier", "PID-26.4"));
			c.Add(new Component("Alternate Text", "PID-26.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-26.6"));
			f.Components = c;
			return f;
		}
		private Field PID27()
		{
			Field f = new Field("Veterans Military Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-27.1"));
			c.Add(new Component("", "PID-27.2"));
			c.Add(new Component("Name of Coding System", "PID-27.3"));
			c.Add(new Component("Alternate Identifier", "PID-27.4"));
			c.Add(new Component("Alternate Text", "PID-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-27.6"));
			f.Components = c;
			return f;
		}
		private Field PID28()
		{
			Field f = new Field("Nationality");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-28.1"));
			c.Add(new Component("", "PID-28.2"));
			c.Add(new Component("Name of Coding System", "PID-28.3"));
			c.Add(new Component("Alternate Identifier", "PID-28.4"));
			c.Add(new Component("Alternate Text", "PID-28.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-28.6"));
			f.Components = c;
			return f;
		}
		private Field PID29()
		{
			Field f = new Field("Patient Death Date and Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PID-29.1"));
			c.Add(new Component("Degree of Precision", "PID-29.2"));
			f.Components = c;
			return f;
		}
		private Field PID30()
		{
			Field f = new Field("Patient Death Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-30.1"));
			f.Components = c;
			return f;
		}
		private Field PID31()
		{
			Field f = new Field("Identity Unknown Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-31.1"));
			f.Components = c;
			return f;
		}
		private Field PID32()
		{
			Field f = new Field("Identity Reliability Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-32.1"));
			f.Components = c;
			return f;
		}
		private Field PID33()
		{
			Field f = new Field("Last Update Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PID-33.1"));
			c.Add(new Component("Degree of Precision", "PID-33.2"));
			f.Components = c;
			return f;
		}
		private Field PID34()
		{
			Field f = new Field("Last Update Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Namespace ID", "PID-34.1"));
			c.Add(new Component("Universal ID", "PID-34.2"));
			c.Add(new Component("Universal ID Type", "PID-34.3"));
			f.Components = c;
			return f;
		}
		private Field PID35()
		{
			Field f = new Field("Species Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-35.1"));
			c.Add(new Component("", "PID-35.2"));
			c.Add(new Component("Name of Coding System", "PID-35.3"));
			c.Add(new Component("Alternate Identifier", "PID-35.4"));
			c.Add(new Component("Alternate Text", "PID-35.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-35.6"));
			f.Components = c;
			return f;
		}
		private Field PID36()
		{
			Field f = new Field("Breed Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-36.1"));
			c.Add(new Component("", "PID-36.2"));
			c.Add(new Component("Name of Coding System", "PID-36.3"));
			c.Add(new Component("Alternate Identifier", "PID-36.4"));
			c.Add(new Component("Alternate Text", "PID-36.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-36.6"));
			f.Components = c;
			return f;
		}
		private Field PID37()
		{
			Field f = new Field("Strain");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PID-37.1"));
			f.Components = c;
			return f;
		}
		private Field PID38()
		{
			Field f = new Field("Production Class Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-38.1"));
			c.Add(new Component("", "PID-38.2"));
			c.Add(new Component("Name of Coding System", "PID-38.3"));
			c.Add(new Component("Alternate Identifier", "PID-38.4"));
			c.Add(new Component("Alternate Text", "PID-38.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-38.6"));
			f.Components = c;
			return f;
		}
		private Field PID39()
		{
			Field f = new Field("Tribal Citizenship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PID-39.1"));
			c.Add(new Component("", "PID-39.2"));
			c.Add(new Component("Name of Coding System", "PID-39.3"));
			c.Add(new Component("Alternate Identifier", "PID-39.4"));
			c.Add(new Component("Alternate Text", "PID-39.5"));
			c.Add(new Component("Name of Alternate Coding System", "PID-39.6"));
			c.Add(new Component("Coding System Version ID", "PID-39.7"));
			c.Add(new Component("Alternate Coding System Version ID", "PID-39.8"));
			c.Add(new Component("Original Text", "PID-39.9"));
			f.Components = c;
			return f;
		}
	}
}
