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
/// STF Class: Constructs an HL7 STF Segment Object
/// </summary>
public class STF
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public STF()
		{
			Name = "STF";
			Description = "Staff Identification";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(STF1());
			fs.Add(STF2());
			fs.Add(STF3());
			fs.Add(STF4());
			fs.Add(STF5());
			fs.Add(STF6());
			fs.Add(STF7());
			fs.Add(STF8());
			fs.Add(STF9());
			fs.Add(STF10());
			fs.Add(STF11());
			fs.Add(STF12());
			fs.Add(STF13());
			fs.Add(STF14());
			fs.Add(STF15());
			fs.Add(STF16());
			fs.Add(STF17());
			fs.Add(STF18());
			fs.Add(STF19());
			fs.Add(STF20());
			fs.Add(STF21());
			fs.Add(STF22());
			fs.Add(STF23());
			fs.Add(STF24());
			fs.Add(STF25());
			fs.Add(STF26());
			fs.Add(STF27());
			fs.Add(STF28());
			fs.Add(STF29());
			fs.Add(STF30());
			fs.Add(STF31());
			fs.Add(STF32());
			fs.Add(STF33());
			fs.Add(STF34());
			fs.Add(STF35());
			fs.Add(STF36());
			fs.Add(STF37());
			fs.Add(STF38());
			Fields = fs;
		}
		private Field STF1()
		{
			Field f = new Field("Primary Key Value - STF");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-1.1"));
			c.Add(new Component("", "STF-1.2"));
			c.Add(new Component("Name of Coding System", "STF-1.3"));
			c.Add(new Component("Alternate Identifier", "STF-1.4"));
			c.Add(new Component("Alternate Text", "STF-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-1.6"));
			f.Components = c;
			return f;
		}
		private Field STF2()
		{
			Field f = new Field("Staff Identifier List");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "STF-2.1"));
			c.Add(new Component("Check Digit", "STF-2.2"));
			c.Add(new Component("Check Digit Scheme", "STF-2.3"));
			c.Add(new Component("Assigning Authority", "STF-2.4"));
			c.Add(new Component("Identifier Type Code", "STF-2.5"));
			c.Add(new Component("Assigning Facility", "STF-2.6"));
			c.Add(new Component("Effective Date", "STF-2.7"));
			c.Add(new Component("Expiration Date", "STF-2.8"));
			c.Add(new Component("Assigning Jurisdiction", "STF-2.9"));
			c.Add(new Component("Assigning Agency or Department", "STF-2.10"));
			f.Components = c;
			return f;
		}
		private Field STF3()
		{
			Field f = new Field("Staff Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "STF-3.1"));
			c.Add(new Component("Given Name", "STF-3.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "STF-3.3"));
			c.Add(new Component("Suffix", "STF-3.4"));
			c.Add(new Component("Prefix", "STF-3.5"));
			c.Add(new Component("Degree", "STF-3.6"));
			c.Add(new Component("Name Type Code", "STF-3.7"));
			c.Add(new Component("Name Respresentation Code", "STF-3.8"));
			c.Add(new Component("Name Context", "STF-3.9"));
			c.Add(new Component("Name Validity Range", "STF-3.10"));
			c.Add(new Component("Name Assembly Order", "STF-3.11"));
			c.Add(new Component("Effective Date", "STF-3.12"));
			c.Add(new Component("Expiration Date", "STF-3.13"));
			c.Add(new Component("Professional Suffix", "STF-3.14"));
			f.Components = c;
			return f;
		}
		private Field STF4()
		{
			Field f = new Field("Staff Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-4.1"));
			f.Components = c;
			return f;
		}
		private Field STF5()
		{
			Field f = new Field("Administrative Sex");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-5.1"));
			f.Components = c;
			return f;
		}
		private Field STF6()
		{
			Field f = new Field("Date/Time of Birth");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "STF-6.1"));
			c.Add(new Component("Degree of Precision", "STF-6.2"));
			f.Components = c;
			return f;
		}
		private Field STF7()
		{
			Field f = new Field("Active/Inactive Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-7.1"));
			f.Components = c;
			return f;
		}
		private Field STF8()
		{
			Field f = new Field("Department");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-8.1"));
			c.Add(new Component("", "STF-8.2"));
			c.Add(new Component("Name of Coding System", "STF-8.3"));
			c.Add(new Component("Alternate Identifier", "STF-8.4"));
			c.Add(new Component("Alternate Text", "STF-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-8.6"));
			f.Components = c;
			return f;
		}
		private Field STF9()
		{
			Field f = new Field("Hospital Service - STF");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-9.1"));
			c.Add(new Component("", "STF-9.2"));
			c.Add(new Component("Name of Coding System", "STF-9.3"));
			c.Add(new Component("Alternate Identifier", "STF-9.4"));
			c.Add(new Component("Alternate Text", "STF-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-9.6"));
			f.Components = c;
			return f;
		}
		private Field STF10()
		{
			Field f = new Field("Phone");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "STF-10.1"));
			c.Add(new Component("Tele-Communication Use Code", "STF-10.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "STF-10.3"));
			c.Add(new Component("Email Address", "STF-10.4"));
			c.Add(new Component("Country Code", "STF-10.5"));
			c.Add(new Component("Area City Code", "STF-10.6"));
			c.Add(new Component("Local Number", "STF-10.7"));
			c.Add(new Component("Extension", "STF-10.8"));
			c.Add(new Component("", "STF-10.9"));
			c.Add(new Component("Extension Prefix", "STF-10.10"));
			c.Add(new Component("Speed Dial Code", "STF-10.11"));
			c.Add(new Component("Unformatted Telephone Number", "STF-10.12"));
			f.Components = c;
			return f;
		}
		private Field STF11()
		{
			Field f = new Field("Office/Home Address/Birthplace");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "STF-11.1"));
			c.Add(new Component("Other Designation", "STF-11.2"));
			c.Add(new Component("City", "STF-11.3"));
			c.Add(new Component("State or Province", "STF-11.4"));
			c.Add(new Component("Zip or Postal Code", "STF-11.5"));
			c.Add(new Component("Country", "STF-11.6"));
			c.Add(new Component("Address Type", "STF-11.7"));
			c.Add(new Component("Other Geographic Designation", "STF-11.8"));
			c.Add(new Component("Country Parish Code", "STF-11.9"));
			c.Add(new Component("Census Tract", "STF-11.10"));
			c.Add(new Component("Address Representation Code", "STF-11.11"));
			c.Add(new Component("Address Validity Range", "STF-11.12"));
			c.Add(new Component("Effective Date", "STF-11.13"));
			c.Add(new Component("Expiration Date", "STF-11.14"));
			f.Components = c;
			return f;
		}
		private Field STF12()
		{
			Field f = new Field("Institution Activation Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-12.1"));
			c.Add(new Component("Institution Name", "STF-12.2"));
			f.Components = c;
			return f;
		}
		private Field STF13()
		{
			Field f = new Field("Institution Inactivation Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-13.1"));
			c.Add(new Component("Institution Name", "STF-13.2"));
			f.Components = c;
			return f;
		}
		private Field STF14()
		{
			Field f = new Field("Backup Person ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-14.1"));
			c.Add(new Component("", "STF-14.2"));
			c.Add(new Component("Name of Coding System", "STF-14.3"));
			c.Add(new Component("Alternate Identifier", "STF-14.4"));
			c.Add(new Component("Alternate Text", "STF-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-14.6"));
			f.Components = c;
			return f;
		}
		private Field STF15()
		{
			Field f = new Field("E-Mail Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-15.1"));
			f.Components = c;
			return f;
		}
		private Field STF16()
		{
			Field f = new Field("Preferred Method of Contact");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-16.1"));
			c.Add(new Component("", "STF-16.2"));
			c.Add(new Component("Name of Coding System", "STF-16.3"));
			c.Add(new Component("Alternate Identifier", "STF-16.4"));
			c.Add(new Component("Alternate Text", "STF-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-16.6"));
			f.Components = c;
			return f;
		}
		private Field STF17()
		{
			Field f = new Field("Marital Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-17.1"));
			c.Add(new Component("", "STF-17.2"));
			c.Add(new Component("Name of Coding System", "STF-17.3"));
			c.Add(new Component("Alternate Identifier", "STF-17.4"));
			c.Add(new Component("Alternate Text", "STF-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-17.6"));
			f.Components = c;
			return f;
		}
		private Field STF18()
		{
			Field f = new Field("Job Title");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-18.1"));
			f.Components = c;
			return f;
		}
		private Field STF19()
		{
			Field f = new Field("Job Code/Class");
			List<Component> c = new List<Component>();
			c.Add(new Component("Job Code", "STF-19.1"));
			c.Add(new Component("Job Class", "STF-19.2"));
			c.Add(new Component("Job Description", "STF-19.3"));
			f.Components = c;
			return f;
		}
		private Field STF20()
		{
			Field f = new Field("Employment Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-20.1"));
			c.Add(new Component("", "STF-20.2"));
			c.Add(new Component("Name of Coding System", "STF-20.3"));
			c.Add(new Component("Alternate Identifier", "STF-20.4"));
			c.Add(new Component("Alternate Text", "STF-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-20.6"));
			f.Components = c;
			return f;
		}
		private Field STF21()
		{
			Field f = new Field("Additional Insured on Auto");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-21.1"));
			f.Components = c;
			return f;
		}
		private Field STF22()
		{
			Field f = new Field("Driver's License Number - Staff");
			List<Component> c = new List<Component>();
			c.Add(new Component("License Number", "STF-22.1"));
			c.Add(new Component("Issuing State, Province, or Country", "STF-22.2"));
			c.Add(new Component("Expiration Date", "STF-22.3"));
			f.Components = c;
			return f;
		}
		private Field STF23()
		{
			Field f = new Field("Copy Auto Ins");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-23.1"));
			f.Components = c;
			return f;
		}
		private Field STF24()
		{
			Field f = new Field("Auto Ins. Expires");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-24.1"));
			f.Components = c;
			return f;
		}
		private Field STF25()
		{
			Field f = new Field("Date Last DMV Review");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-25.1"));
			f.Components = c;
			return f;
		}
		private Field STF26()
		{
			Field f = new Field("Date Next DMV Review");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-26.1"));
			f.Components = c;
			return f;
		}
		private Field STF27()
		{
			Field f = new Field("Race");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-27.1"));
			c.Add(new Component("", "STF-27.2"));
			c.Add(new Component("Name of Coding System", "STF-27.3"));
			c.Add(new Component("Alternate Identifier", "STF-27.4"));
			c.Add(new Component("Alternate Text", "STF-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-27.6"));
			f.Components = c;
			return f;
		}
		private Field STF28()
		{
			Field f = new Field("Ethnic Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-28.1"));
			c.Add(new Component("", "STF-28.2"));
			c.Add(new Component("Name of Coding System", "STF-28.3"));
			c.Add(new Component("Alternate Identifier", "STF-28.4"));
			c.Add(new Component("Alternate Text", "STF-28.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-28.6"));
			f.Components = c;
			return f;
		}
		private Field STF29()
		{
			Field f = new Field("Re-activation Approval Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-29.1"));
			f.Components = c;
			return f;
		}
		private Field STF30()
		{
			Field f = new Field("Citizenship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-30.1"));
			c.Add(new Component("", "STF-30.2"));
			c.Add(new Component("Name of Coding System", "STF-30.3"));
			c.Add(new Component("Alternate Identifier", "STF-30.4"));
			c.Add(new Component("Alternate Text", "STF-30.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-30.6"));
			f.Components = c;
			return f;
		}
		private Field STF31()
		{
			Field f = new Field("Death Date and Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "STF-31.1"));
			c.Add(new Component("Degree of Precision", "STF-31.2"));
			f.Components = c;
			return f;
		}
		private Field STF32()
		{
			Field f = new Field("Death Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-32.1"));
			f.Components = c;
			return f;
		}
		private Field STF33()
		{
			Field f = new Field("Institution Relationship Type Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-33.1"));
			c.Add(new Component("", "STF-33.2"));
			c.Add(new Component("Name of Coding System", "STF-33.3"));
			c.Add(new Component("Alternate Identifier", "STF-33.4"));
			c.Add(new Component("Alternate Text", "STF-33.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-33.6"));
			c.Add(new Component("Coding System Version ID", "STF-33.7"));
			c.Add(new Component("Alternate Coding System Version ID", "STF-33.8"));
			c.Add(new Component("Original Text", "STF-33.9"));
			f.Components = c;
			return f;
		}
		private Field STF34()
		{
			Field f = new Field("Institution Relationship Period");
			List<Component> c = new List<Component>();
			c.Add(new Component("Range Start Date/Time", "STF-34.1"));
			c.Add(new Component("Range End Date/Time", "STF-34.2"));
			f.Components = c;
			return f;
		}
		private Field STF35()
		{
			Field f = new Field("Expected Return Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-35.1"));
			f.Components = c;
			return f;
		}
		private Field STF36()
		{
			Field f = new Field("Cost Center Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-36.1"));
			c.Add(new Component("", "STF-36.2"));
			c.Add(new Component("Name of Coding System", "STF-36.3"));
			c.Add(new Component("Alternate Identifier", "STF-36.4"));
			c.Add(new Component("Alternate Text", "STF-36.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-36.6"));
			c.Add(new Component("Coding System Version ID", "STF-36.7"));
			c.Add(new Component("Alternate Coding System Version ID", "STF-36.8"));
			c.Add(new Component("Original Text", "STF-36.9"));
			f.Components = c;
			return f;
		}
		private Field STF37()
		{
			Field f = new Field("Generic Classification Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "STF-37.1"));
			f.Components = c;
			return f;
		}
		private Field STF38()
		{
			Field f = new Field("Inactive Reason Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "STF-38.1"));
			c.Add(new Component("", "STF-38.2"));
			c.Add(new Component("Name of Coding System", "STF-38.3"));
			c.Add(new Component("Alternate Identifier", "STF-38.4"));
			c.Add(new Component("Alternate Text", "STF-38.5"));
			c.Add(new Component("Name of Alternate Coding System", "STF-38.6"));
			c.Add(new Component("Coding System Version ID", "STF-38.7"));
			c.Add(new Component("Alternate Coding System Version ID", "STF-38.8"));
			c.Add(new Component("Original Text", "STF-38.9"));
			f.Components = c;
			return f;
		}
	}
}
