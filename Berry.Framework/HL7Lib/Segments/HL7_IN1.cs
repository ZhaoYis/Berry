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
/// IN1 Class: Constructs an HL7 IN1 Segment Object
/// </summary>
public class IN1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public IN1()
		{
			Name = "IN1";
			Description = "Insurance";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(IN11());
			fs.Add(IN12());
			fs.Add(IN13());
			fs.Add(IN14());
			fs.Add(IN15());
			fs.Add(IN16());
			fs.Add(IN17());
			fs.Add(IN18());
			fs.Add(IN19());
			fs.Add(IN110());
			fs.Add(IN111());
			fs.Add(IN112());
			fs.Add(IN113());
			fs.Add(IN114());
			fs.Add(IN115());
			fs.Add(IN116());
			fs.Add(IN117());
			fs.Add(IN118());
			fs.Add(IN119());
			fs.Add(IN120());
			fs.Add(IN121());
			fs.Add(IN122());
			fs.Add(IN123());
			fs.Add(IN124());
			fs.Add(IN125());
			fs.Add(IN126());
			fs.Add(IN127());
			fs.Add(IN128());
			fs.Add(IN129());
			fs.Add(IN130());
			fs.Add(IN131());
			fs.Add(IN132());
			fs.Add(IN133());
			fs.Add(IN134());
			fs.Add(IN135());
			fs.Add(IN136());
			fs.Add(IN137());
			fs.Add(IN138());
			fs.Add(IN139());
			fs.Add(IN140());
			fs.Add(IN141());
			fs.Add(IN142());
			fs.Add(IN143());
			fs.Add(IN144());
			fs.Add(IN145());
			fs.Add(IN146());
			fs.Add(IN147());
			fs.Add(IN148());
			fs.Add(IN149());
			fs.Add(IN150());
			fs.Add(IN151());
			fs.Add(IN152());
			fs.Add(IN153());
			Fields = fs;
		}
		private Field IN11()
		{
			Field f = new Field("Set ID - IN1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "IN1-1.1"));
			f.Components = c;
			return f;
		}
		private Field IN12()
		{
			Field f = new Field("Insurance Plan ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN1-2.1"));
			c.Add(new Component("", "IN1-2.2"));
			c.Add(new Component("Name of Coding System", "IN1-2.3"));
			c.Add(new Component("Alternate Identifier", "IN1-2.4"));
			c.Add(new Component("Alternate Text", "IN1-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN1-2.6"));
			f.Components = c;
			return f;
		}
		private Field IN13()
		{
			Field f = new Field("Insurance Company ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN1-3.1"));
			c.Add(new Component("Check Digit", "IN1-3.2"));
			c.Add(new Component("Check Digit Scheme", "IN1-3.3"));
			c.Add(new Component("Assigning Authority", "IN1-3.4"));
			c.Add(new Component("Identifier Type Code", "IN1-3.5"));
			c.Add(new Component("Assigning Facility", "IN1-3.6"));
			c.Add(new Component("Effective Date", "IN1-3.7"));
			c.Add(new Component("Expiration Date", "IN1-3.8"));
			c.Add(new Component("Assigning Jurisdiction", "IN1-3.9"));
			c.Add(new Component("Assigning Agency or Department", "IN1-3.10"));
			f.Components = c;
			return f;
		}
		private Field IN14()
		{
			Field f = new Field("Insurance Company Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "IN1-4.1"));
			c.Add(new Component("Organization Name Type Code", "IN1-4.2"));
			c.Add(new Component("ID Number", "IN1-4.3"));
			c.Add(new Component("Check Digit", "IN1-4.4"));
			c.Add(new Component("Check Digit Scheme", "IN1-4.5"));
			c.Add(new Component("Assigning Authority", "IN1-4.6"));
			c.Add(new Component("Identifier Type Code", "IN1-4.7"));
			c.Add(new Component("Assigning Facility", "IN1-4.8"));
			c.Add(new Component("Name Respresentation Code", "IN1-4.9"));
			c.Add(new Component("Organization Identifier", "IN1-4.10"));
			f.Components = c;
			return f;
		}
		private Field IN15()
		{
			Field f = new Field("Insurance Company Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "IN1-5.1"));
			c.Add(new Component("Other Designation", "IN1-5.2"));
			c.Add(new Component("City", "IN1-5.3"));
			c.Add(new Component("State or Province", "IN1-5.4"));
			c.Add(new Component("Zip or Postal Code", "IN1-5.5"));
			c.Add(new Component("Country", "IN1-5.6"));
			c.Add(new Component("Address Type", "IN1-5.7"));
			c.Add(new Component("Other Geographic Designation", "IN1-5.8"));
			c.Add(new Component("Country Parish Code", "IN1-5.9"));
			c.Add(new Component("Census Tract", "IN1-5.10"));
			c.Add(new Component("Address Representation Code", "IN1-5.11"));
			c.Add(new Component("Address Validity Range", "IN1-5.12"));
			c.Add(new Component("Effective Date", "IN1-5.13"));
			c.Add(new Component("Expiration Date", "IN1-5.14"));
			f.Components = c;
			return f;
		}
		private Field IN16()
		{
			Field f = new Field("Insurance Co Contact Person");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IN1-6.1"));
			c.Add(new Component("Given Name", "IN1-6.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN1-6.3"));
			c.Add(new Component("Suffix", "IN1-6.4"));
			c.Add(new Component("Prefix", "IN1-6.5"));
			c.Add(new Component("Degree", "IN1-6.6"));
			c.Add(new Component("Name Type Code", "IN1-6.7"));
			c.Add(new Component("Name Respresentation Code", "IN1-6.8"));
			c.Add(new Component("Name Context", "IN1-6.9"));
			c.Add(new Component("Name Validity Range", "IN1-6.10"));
			c.Add(new Component("Name Assembly Order", "IN1-6.11"));
			c.Add(new Component("Effective Date", "IN1-6.12"));
			c.Add(new Component("Expiration Date", "IN1-6.13"));
			c.Add(new Component("Professional Suffix", "IN1-6.14"));
			f.Components = c;
			return f;
		}
		private Field IN17()
		{
			Field f = new Field("Insurance Co Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "IN1-7.1"));
			c.Add(new Component("Tele-Communication Use Code", "IN1-7.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "IN1-7.3"));
			c.Add(new Component("Email Address", "IN1-7.4"));
			c.Add(new Component("Country Code", "IN1-7.5"));
			c.Add(new Component("Area City Code", "IN1-7.6"));
			c.Add(new Component("Local Number", "IN1-7.7"));
			c.Add(new Component("Extension", "IN1-7.8"));
			c.Add(new Component("", "IN1-7.9"));
			c.Add(new Component("Extension Prefix", "IN1-7.10"));
			c.Add(new Component("Speed Dial Code", "IN1-7.11"));
			c.Add(new Component("Unformatted Telephone Number", "IN1-7.12"));
			f.Components = c;
			return f;
		}
		private Field IN18()
		{
			Field f = new Field("Group Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-8.1"));
			f.Components = c;
			return f;
		}
		private Field IN19()
		{
			Field f = new Field("Group Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "IN1-9.1"));
			c.Add(new Component("Organization Name Type Code", "IN1-9.2"));
			c.Add(new Component("ID Number", "IN1-9.3"));
			c.Add(new Component("Check Digit", "IN1-9.4"));
			c.Add(new Component("Check Digit Scheme", "IN1-9.5"));
			c.Add(new Component("Assigning Authority", "IN1-9.6"));
			c.Add(new Component("Identifier Type Code", "IN1-9.7"));
			c.Add(new Component("Assigning Facility", "IN1-9.8"));
			c.Add(new Component("Name Respresentation Code", "IN1-9.9"));
			c.Add(new Component("Organization Identifier", "IN1-9.10"));
			f.Components = c;
			return f;
		}
		private Field IN110()
		{
			Field f = new Field("Insured's Group Emp ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN1-10.1"));
			c.Add(new Component("Check Digit", "IN1-10.2"));
			c.Add(new Component("Check Digit Scheme", "IN1-10.3"));
			c.Add(new Component("Assigning Authority", "IN1-10.4"));
			c.Add(new Component("Identifier Type Code", "IN1-10.5"));
			c.Add(new Component("Assigning Facility", "IN1-10.6"));
			c.Add(new Component("Effective Date", "IN1-10.7"));
			c.Add(new Component("Expiration Date", "IN1-10.8"));
			c.Add(new Component("Assigning Jurisdiction", "IN1-10.9"));
			c.Add(new Component("Assigning Agency or Department", "IN1-10.10"));
			f.Components = c;
			return f;
		}
		private Field IN111()
		{
			Field f = new Field("Insured's Group Emp Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "IN1-11.1"));
			c.Add(new Component("Organization Name Type Code", "IN1-11.2"));
			c.Add(new Component("ID Number", "IN1-11.3"));
			c.Add(new Component("Check Digit", "IN1-11.4"));
			c.Add(new Component("Check Digit Scheme", "IN1-11.5"));
			c.Add(new Component("Assigning Authority", "IN1-11.6"));
			c.Add(new Component("Identifier Type Code", "IN1-11.7"));
			c.Add(new Component("Assigning Facility", "IN1-11.8"));
			c.Add(new Component("Name Respresentation Code", "IN1-11.9"));
			c.Add(new Component("Organization Identifier", "IN1-11.10"));
			f.Components = c;
			return f;
		}
		private Field IN112()
		{
			Field f = new Field("Plan Effective Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-12.1"));
			f.Components = c;
			return f;
		}
		private Field IN113()
		{
			Field f = new Field("Plan Expiration Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-13.1"));
			f.Components = c;
			return f;
		}
		private Field IN114()
		{
			Field f = new Field("Authorization Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("Authorization Number", "IN1-14.1"));
			c.Add(new Component("", "IN1-14.2"));
			c.Add(new Component("Source", "IN1-14.3"));
			f.Components = c;
			return f;
		}
		private Field IN115()
		{
			Field f = new Field("Plan Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-15.1"));
			f.Components = c;
			return f;
		}
		private Field IN116()
		{
			Field f = new Field("Name Of Insured");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IN1-16.1"));
			c.Add(new Component("Given Name", "IN1-16.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN1-16.3"));
			c.Add(new Component("Suffix", "IN1-16.4"));
			c.Add(new Component("Prefix", "IN1-16.5"));
			c.Add(new Component("Degree", "IN1-16.6"));
			c.Add(new Component("Name Type Code", "IN1-16.7"));
			c.Add(new Component("Name Respresentation Code", "IN1-16.8"));
			c.Add(new Component("Name Context", "IN1-16.9"));
			c.Add(new Component("Name Validity Range", "IN1-16.10"));
			c.Add(new Component("Name Assembly Order", "IN1-16.11"));
			c.Add(new Component("Effective Date", "IN1-16.12"));
			c.Add(new Component("Expiration Date", "IN1-16.13"));
			c.Add(new Component("Professional Suffix", "IN1-16.14"));
			f.Components = c;
			return f;
		}
		private Field IN117()
		{
			Field f = new Field("Insured's Relationship To Patient");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN1-17.1"));
			c.Add(new Component("", "IN1-17.2"));
			c.Add(new Component("Name of Coding System", "IN1-17.3"));
			c.Add(new Component("Alternate Identifier", "IN1-17.4"));
			c.Add(new Component("Alternate Text", "IN1-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN1-17.6"));
			f.Components = c;
			return f;
		}
		private Field IN118()
		{
			Field f = new Field("Insured's Date Of Birth");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IN1-18.1"));
			c.Add(new Component("Degree of Precision", "IN1-18.2"));
			f.Components = c;
			return f;
		}
		private Field IN119()
		{
			Field f = new Field("Insured's Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "IN1-19.1"));
			c.Add(new Component("Other Designation", "IN1-19.2"));
			c.Add(new Component("City", "IN1-19.3"));
			c.Add(new Component("State or Province", "IN1-19.4"));
			c.Add(new Component("Zip or Postal Code", "IN1-19.5"));
			c.Add(new Component("Country", "IN1-19.6"));
			c.Add(new Component("Address Type", "IN1-19.7"));
			c.Add(new Component("Other Geographic Designation", "IN1-19.8"));
			c.Add(new Component("Country Parish Code", "IN1-19.9"));
			c.Add(new Component("Census Tract", "IN1-19.10"));
			c.Add(new Component("Address Representation Code", "IN1-19.11"));
			c.Add(new Component("Address Validity Range", "IN1-19.12"));
			c.Add(new Component("Effective Date", "IN1-19.13"));
			c.Add(new Component("Expiration Date", "IN1-19.14"));
			f.Components = c;
			return f;
		}
		private Field IN120()
		{
			Field f = new Field("Assignment Of Benefits");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-20.1"));
			f.Components = c;
			return f;
		}
		private Field IN121()
		{
			Field f = new Field("Coordination Of Benefits");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-21.1"));
			f.Components = c;
			return f;
		}
		private Field IN122()
		{
			Field f = new Field("Coord Of Ben. Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-22.1"));
			f.Components = c;
			return f;
		}
		private Field IN123()
		{
			Field f = new Field("Notice Of Admission Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-23.1"));
			f.Components = c;
			return f;
		}
		private Field IN124()
		{
			Field f = new Field("Notice Of Admission Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-24.1"));
			f.Components = c;
			return f;
		}
		private Field IN125()
		{
			Field f = new Field("Report Of Eligibility Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-25.1"));
			f.Components = c;
			return f;
		}
		private Field IN126()
		{
			Field f = new Field("Report Of Eligibility Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-26.1"));
			f.Components = c;
			return f;
		}
		private Field IN127()
		{
			Field f = new Field("Release Information Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-27.1"));
			f.Components = c;
			return f;
		}
		private Field IN128()
		{
			Field f = new Field("Pre-Admit Cert (PAC)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-28.1"));
			f.Components = c;
			return f;
		}
		private Field IN129()
		{
			Field f = new Field("Verification Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "IN1-29.1"));
			c.Add(new Component("Degree of Precision", "IN1-29.2"));
			f.Components = c;
			return f;
		}
		private Field IN130()
		{
			Field f = new Field("Verification By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN1-30.1"));
			c.Add(new Component("Family Name", "IN1-30.2"));
			c.Add(new Component("Given Name", "IN1-30.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN1-30.4"));
			c.Add(new Component("Suffix", "IN1-30.5"));
			c.Add(new Component("Prefix", "IN1-30.6"));
			c.Add(new Component("Degree", "IN1-30.7"));
			c.Add(new Component("Source Table", "IN1-30.8"));
			c.Add(new Component("Assigning Authority", "IN1-30.9"));
			c.Add(new Component("Name Type Code", "IN1-30.10"));
			c.Add(new Component("Identifier Check Digit", "IN1-30.11"));
			c.Add(new Component("Check Digit Scheme", "IN1-30.12"));
			c.Add(new Component("Identifier Type Code", "IN1-30.13"));
			c.Add(new Component("Assigning Facility", "IN1-30.14"));
			c.Add(new Component("Name Respresentation Code", "IN1-30.15"));
			c.Add(new Component("Name Context", "IN1-30.16"));
			c.Add(new Component("Name Validity Range", "IN1-30.17"));
			c.Add(new Component("Name Assembly Order", "IN1-30.18"));
			c.Add(new Component("Effective Date", "IN1-30.19"));
			c.Add(new Component("Expiration Date", "IN1-30.20"));
			c.Add(new Component("Professional Suffix", "IN1-30.21"));
			c.Add(new Component("Assigning Jurisdiction", "IN1-30.22"));
			c.Add(new Component("Assigning Agency or Department", "IN1-30.23"));
			f.Components = c;
			return f;
		}
		private Field IN131()
		{
			Field f = new Field("Type Of Agreement Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-31.1"));
			f.Components = c;
			return f;
		}
		private Field IN132()
		{
			Field f = new Field("Billing Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-32.1"));
			f.Components = c;
			return f;
		}
		private Field IN133()
		{
			Field f = new Field("Lifetime Reserve Days");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-33.1"));
			f.Components = c;
			return f;
		}
		private Field IN134()
		{
			Field f = new Field("Delay Before L.R. Day");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-34.1"));
			f.Components = c;
			return f;
		}
		private Field IN135()
		{
			Field f = new Field("Company Plan Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-35.1"));
			f.Components = c;
			return f;
		}
		private Field IN136()
		{
			Field f = new Field("Policy Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-36.1"));
			f.Components = c;
			return f;
		}
		private Field IN137()
		{
			Field f = new Field("Policy Deductible");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "IN1-37.1"));
			c.Add(new Component("Price Type", "IN1-37.2"));
			c.Add(new Component("From Value", "IN1-37.3"));
			c.Add(new Component("To Value", "IN1-37.4"));
			c.Add(new Component("Range Units", "IN1-37.5"));
			c.Add(new Component("Range Type", "IN1-37.6"));
			f.Components = c;
			return f;
		}
		private Field IN138()
		{
			Field f = new Field("Policy Limit - Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "IN1-38.1"));
			c.Add(new Component("Price Type", "IN1-38.2"));
			c.Add(new Component("From Value", "IN1-38.3"));
			c.Add(new Component("To Value", "IN1-38.4"));
			c.Add(new Component("Range Units", "IN1-38.5"));
			c.Add(new Component("Range Type", "IN1-38.6"));
			f.Components = c;
			return f;
		}
		private Field IN139()
		{
			Field f = new Field("Policy Limit - Days");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-39.1"));
			f.Components = c;
			return f;
		}
		private Field IN140()
		{
			Field f = new Field("Room Rate - Semi-Private");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "IN1-40.1"));
			c.Add(new Component("Price Type", "IN1-40.2"));
			c.Add(new Component("From Value", "IN1-40.3"));
			c.Add(new Component("To Value", "IN1-40.4"));
			c.Add(new Component("Range Units", "IN1-40.5"));
			c.Add(new Component("Range Type", "IN1-40.6"));
			f.Components = c;
			return f;
		}
		private Field IN141()
		{
			Field f = new Field("Room Rate - Private");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "IN1-41.1"));
			c.Add(new Component("Price Type", "IN1-41.2"));
			c.Add(new Component("From Value", "IN1-41.3"));
			c.Add(new Component("To Value", "IN1-41.4"));
			c.Add(new Component("Range Units", "IN1-41.5"));
			c.Add(new Component("Range Type", "IN1-41.6"));
			f.Components = c;
			return f;
		}
		private Field IN142()
		{
			Field f = new Field("Insured's Employment Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN1-42.1"));
			c.Add(new Component("", "IN1-42.2"));
			c.Add(new Component("Name of Coding System", "IN1-42.3"));
			c.Add(new Component("Alternate Identifier", "IN1-42.4"));
			c.Add(new Component("Alternate Text", "IN1-42.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN1-42.6"));
			f.Components = c;
			return f;
		}
		private Field IN143()
		{
			Field f = new Field("Insured's Administrative Sex");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-43.1"));
			f.Components = c;
			return f;
		}
		private Field IN144()
		{
			Field f = new Field("Insured's Employer's Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "IN1-44.1"));
			c.Add(new Component("Other Designation", "IN1-44.2"));
			c.Add(new Component("City", "IN1-44.3"));
			c.Add(new Component("State or Province", "IN1-44.4"));
			c.Add(new Component("Zip or Postal Code", "IN1-44.5"));
			c.Add(new Component("Country", "IN1-44.6"));
			c.Add(new Component("Address Type", "IN1-44.7"));
			c.Add(new Component("Other Geographic Designation", "IN1-44.8"));
			c.Add(new Component("Country Parish Code", "IN1-44.9"));
			c.Add(new Component("Census Tract", "IN1-44.10"));
			c.Add(new Component("Address Representation Code", "IN1-44.11"));
			c.Add(new Component("Address Validity Range", "IN1-44.12"));
			c.Add(new Component("Effective Date", "IN1-44.13"));
			c.Add(new Component("Expiration Date", "IN1-44.14"));
			f.Components = c;
			return f;
		}
		private Field IN145()
		{
			Field f = new Field("Verification Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-45.1"));
			f.Components = c;
			return f;
		}
		private Field IN146()
		{
			Field f = new Field("Prior Insurance Plan ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-46.1"));
			f.Components = c;
			return f;
		}
		private Field IN147()
		{
			Field f = new Field("Coverage Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-47.1"));
			f.Components = c;
			return f;
		}
		private Field IN148()
		{
			Field f = new Field("Handicap");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-48.1"));
			f.Components = c;
			return f;
		}
		private Field IN149()
		{
			Field f = new Field("Insured's ID Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN1-49.1"));
			c.Add(new Component("Check Digit", "IN1-49.2"));
			c.Add(new Component("Check Digit Scheme", "IN1-49.3"));
			c.Add(new Component("Assigning Authority", "IN1-49.4"));
			c.Add(new Component("Identifier Type Code", "IN1-49.5"));
			c.Add(new Component("Assigning Facility", "IN1-49.6"));
			c.Add(new Component("Effective Date", "IN1-49.7"));
			c.Add(new Component("Expiration Date", "IN1-49.8"));
			c.Add(new Component("Assigning Jurisdiction", "IN1-49.9"));
			c.Add(new Component("Assigning Agency or Department", "IN1-49.10"));
			f.Components = c;
			return f;
		}
		private Field IN150()
		{
			Field f = new Field("Signature Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-50.1"));
			f.Components = c;
			return f;
		}
		private Field IN151()
		{
			Field f = new Field("Signature Code Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-51.1"));
			f.Components = c;
			return f;
		}
		private Field IN152()
		{
			Field f = new Field("Insured_s Birth Place");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-52.1"));
			f.Components = c;
			return f;
		}
		private Field IN153()
		{
			Field f = new Field("VIP Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN1-53.1"));
			f.Components = c;
			return f;
		}
	}
}
