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
/// ORC Class: Constructs an HL7 ORC Segment Object
/// </summary>
public class ORC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public ORC()
		{
			Name = "ORC";
			Description = "Common Order";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(ORC1());
			fs.Add(ORC2());
			fs.Add(ORC3());
			fs.Add(ORC4());
			fs.Add(ORC5());
			fs.Add(ORC6());
			fs.Add(ORC7());
			fs.Add(ORC8());
			fs.Add(ORC9());
			fs.Add(ORC10());
			fs.Add(ORC11());
			fs.Add(ORC12());
			fs.Add(ORC13());
			fs.Add(ORC14());
			fs.Add(ORC15());
			fs.Add(ORC16());
			fs.Add(ORC17());
			fs.Add(ORC18());
			fs.Add(ORC19());
			fs.Add(ORC20());
			fs.Add(ORC21());
			fs.Add(ORC22());
			fs.Add(ORC23());
			fs.Add(ORC24());
			fs.Add(ORC25());
			fs.Add(ORC26());
			fs.Add(ORC27());
			fs.Add(ORC28());
			fs.Add(ORC29());
			fs.Add(ORC30());
			Fields = fs;
		}
		private Field ORC1()
		{
			Field f = new Field("Order Control");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ORC-1.1"));
			f.Components = c;
			return f;
		}
		private Field ORC2()
		{
			Field f = new Field("Placer Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "ORC-2.1"));
			c.Add(new Component("Namespace ID", "ORC-2.2"));
			c.Add(new Component("Universal ID", "ORC-2.3"));
			c.Add(new Component("Universal ID Type", "ORC-2.4"));
			f.Components = c;
			return f;
		}
		private Field ORC3()
		{
			Field f = new Field("Filler Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "ORC-3.1"));
			c.Add(new Component("Namespace ID", "ORC-3.2"));
			c.Add(new Component("Universal ID", "ORC-3.3"));
			c.Add(new Component("Universal ID Type", "ORC-3.4"));
			f.Components = c;
			return f;
		}
		private Field ORC4()
		{
			Field f = new Field("Placer Group Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "ORC-4.1"));
			c.Add(new Component("Namespace ID", "ORC-4.2"));
			c.Add(new Component("Universal ID", "ORC-4.3"));
			c.Add(new Component("Universal ID Type", "ORC-4.4"));
			f.Components = c;
			return f;
		}
		private Field ORC5()
		{
			Field f = new Field("Order Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ORC-5.1"));
			f.Components = c;
			return f;
		}
		private Field ORC6()
		{
			Field f = new Field("Response Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "ORC-6.1"));
			f.Components = c;
			return f;
		}
		private Field ORC7()
		{
			Field f = new Field("Quantity/Timing");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "ORC-7.1"));
			c.Add(new Component("Interval", "ORC-7.2"));
			c.Add(new Component("Duration", "ORC-7.3"));
			c.Add(new Component("Start Date/Time", "ORC-7.4"));
			c.Add(new Component("End Date Time", "ORC-7.5"));
			c.Add(new Component("Priority", "ORC-7.6"));
			c.Add(new Component("Condition", "ORC-7.7"));
			c.Add(new Component("", "ORC-7.8"));
			c.Add(new Component("Conjunction", "ORC-7.9"));
			c.Add(new Component("Order Sequencing", "ORC-7.10"));
			c.Add(new Component("Occurrence Duration", "ORC-7.11"));
			c.Add(new Component("Total Occurrences", "ORC-7.12"));
			f.Components = c;
			return f;
		}
		private Field ORC8()
		{
			Field f = new Field("Parent");
			List<Component> c = new List<Component>();
			c.Add(new Component("Placer Assigned Identifier", "ORC-8.1"));
			c.Add(new Component("Filler Assigned Identifier", "ORC-8.2"));
			f.Components = c;
			return f;
		}
		private Field ORC9()
		{
			Field f = new Field("Date/Time of Transaction");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ORC-9.1"));
			c.Add(new Component("Degree of Precision", "ORC-9.2"));
			f.Components = c;
			return f;
		}
		private Field ORC10()
		{
			Field f = new Field("Entered By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ORC-10.1"));
			c.Add(new Component("Family Name", "ORC-10.2"));
			c.Add(new Component("Given Name", "ORC-10.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ORC-10.4"));
			c.Add(new Component("Suffix", "ORC-10.5"));
			c.Add(new Component("Prefix", "ORC-10.6"));
			c.Add(new Component("Degree", "ORC-10.7"));
			c.Add(new Component("Source Table", "ORC-10.8"));
			c.Add(new Component("Assigning Authority", "ORC-10.9"));
			c.Add(new Component("Name Type Code", "ORC-10.10"));
			c.Add(new Component("Identifier Check Digit", "ORC-10.11"));
			c.Add(new Component("Check Digit Scheme", "ORC-10.12"));
			c.Add(new Component("Identifier Type Code", "ORC-10.13"));
			c.Add(new Component("Assigning Facility", "ORC-10.14"));
			c.Add(new Component("Name Respresentation Code", "ORC-10.15"));
			c.Add(new Component("Name Context", "ORC-10.16"));
			c.Add(new Component("Name Validity Range", "ORC-10.17"));
			c.Add(new Component("Name Assembly Order", "ORC-10.18"));
			c.Add(new Component("Effective Date", "ORC-10.19"));
			c.Add(new Component("Expiration Date", "ORC-10.20"));
			c.Add(new Component("Professional Suffix", "ORC-10.21"));
			c.Add(new Component("Assigning Jurisdiction", "ORC-10.22"));
			c.Add(new Component("Assigning Agency or Department", "ORC-10.23"));
			f.Components = c;
			return f;
		}
		private Field ORC11()
		{
			Field f = new Field("Verified By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ORC-11.1"));
			c.Add(new Component("Family Name", "ORC-11.2"));
			c.Add(new Component("Given Name", "ORC-11.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ORC-11.4"));
			c.Add(new Component("Suffix", "ORC-11.5"));
			c.Add(new Component("Prefix", "ORC-11.6"));
			c.Add(new Component("Degree", "ORC-11.7"));
			c.Add(new Component("Source Table", "ORC-11.8"));
			c.Add(new Component("Assigning Authority", "ORC-11.9"));
			c.Add(new Component("Name Type Code", "ORC-11.10"));
			c.Add(new Component("Identifier Check Digit", "ORC-11.11"));
			c.Add(new Component("Check Digit Scheme", "ORC-11.12"));
			c.Add(new Component("Identifier Type Code", "ORC-11.13"));
			c.Add(new Component("Assigning Facility", "ORC-11.14"));
			c.Add(new Component("Name Respresentation Code", "ORC-11.15"));
			c.Add(new Component("Name Context", "ORC-11.16"));
			c.Add(new Component("Name Validity Range", "ORC-11.17"));
			c.Add(new Component("Name Assembly Order", "ORC-11.18"));
			c.Add(new Component("Effective Date", "ORC-11.19"));
			c.Add(new Component("Expiration Date", "ORC-11.20"));
			c.Add(new Component("Professional Suffix", "ORC-11.21"));
			c.Add(new Component("Assigning Jurisdiction", "ORC-11.22"));
			c.Add(new Component("Assigning Agency or Department", "ORC-11.23"));
			f.Components = c;
			return f;
		}
		private Field ORC12()
		{
			Field f = new Field("Ordering Provider");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ORC-12.1"));
			c.Add(new Component("Family Name", "ORC-12.2"));
			c.Add(new Component("Given Name", "ORC-12.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ORC-12.4"));
			c.Add(new Component("Suffix", "ORC-12.5"));
			c.Add(new Component("Prefix", "ORC-12.6"));
			c.Add(new Component("Degree", "ORC-12.7"));
			c.Add(new Component("Source Table", "ORC-12.8"));
			c.Add(new Component("Assigning Authority", "ORC-12.9"));
			c.Add(new Component("Name Type Code", "ORC-12.10"));
			c.Add(new Component("Identifier Check Digit", "ORC-12.11"));
			c.Add(new Component("Check Digit Scheme", "ORC-12.12"));
			c.Add(new Component("Identifier Type Code", "ORC-12.13"));
			c.Add(new Component("Assigning Facility", "ORC-12.14"));
			c.Add(new Component("Name Respresentation Code", "ORC-12.15"));
			c.Add(new Component("Name Context", "ORC-12.16"));
			c.Add(new Component("Name Validity Range", "ORC-12.17"));
			c.Add(new Component("Name Assembly Order", "ORC-12.18"));
			c.Add(new Component("Effective Date", "ORC-12.19"));
			c.Add(new Component("Expiration Date", "ORC-12.20"));
			c.Add(new Component("Professional Suffix", "ORC-12.21"));
			c.Add(new Component("Assigning Jurisdiction", "ORC-12.22"));
			c.Add(new Component("Assigning Agency or Department", "ORC-12.23"));
			f.Components = c;
			return f;
		}
		private Field ORC13()
		{
			Field f = new Field("Enterer's Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "ORC-13.1"));
			c.Add(new Component("Room", "ORC-13.2"));
			c.Add(new Component("Bed", "ORC-13.3"));
			c.Add(new Component("Facility", "ORC-13.4"));
			c.Add(new Component("Location Status", "ORC-13.5"));
			c.Add(new Component("Person Location Type", "ORC-13.6"));
			c.Add(new Component("Building", "ORC-13.7"));
			c.Add(new Component("Floor Number", "ORC-13.8"));
			c.Add(new Component("Location Description", "ORC-13.9"));
			c.Add(new Component("Comprehensive Location Identifier", "ORC-13.10"));
			c.Add(new Component("Assigning Authority for Location", "ORC-13.11"));
			f.Components = c;
			return f;
		}
		private Field ORC14()
		{
			Field f = new Field("Call Back Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "ORC-14.1"));
			c.Add(new Component("Tele-Communication Use Code", "ORC-14.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "ORC-14.3"));
			c.Add(new Component("Email Address", "ORC-14.4"));
			c.Add(new Component("Country Code", "ORC-14.5"));
			c.Add(new Component("Area City Code", "ORC-14.6"));
			c.Add(new Component("Local Number", "ORC-14.7"));
			c.Add(new Component("Extension", "ORC-14.8"));
			c.Add(new Component("", "ORC-14.9"));
			c.Add(new Component("Extension Prefix", "ORC-14.10"));
			c.Add(new Component("Speed Dial Code", "ORC-14.11"));
			c.Add(new Component("Unformatted Telephone Number", "ORC-14.12"));
			f.Components = c;
			return f;
		}
		private Field ORC15()
		{
			Field f = new Field("Order Effective Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ORC-15.1"));
			c.Add(new Component("Degree of Precision", "ORC-15.2"));
			f.Components = c;
			return f;
		}
		private Field ORC16()
		{
			Field f = new Field("Order Control Code Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-16.1"));
			c.Add(new Component("", "ORC-16.2"));
			c.Add(new Component("Name of Coding System", "ORC-16.3"));
			c.Add(new Component("Alternate Identifier", "ORC-16.4"));
			c.Add(new Component("Alternate Text", "ORC-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-16.6"));
			f.Components = c;
			return f;
		}
		private Field ORC17()
		{
			Field f = new Field("Entering Organization");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-17.1"));
			c.Add(new Component("", "ORC-17.2"));
			c.Add(new Component("Name of Coding System", "ORC-17.3"));
			c.Add(new Component("Alternate Identifier", "ORC-17.4"));
			c.Add(new Component("Alternate Text", "ORC-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-17.6"));
			f.Components = c;
			return f;
		}
		private Field ORC18()
		{
			Field f = new Field("Entering Device");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-18.1"));
			c.Add(new Component("", "ORC-18.2"));
			c.Add(new Component("Name of Coding System", "ORC-18.3"));
			c.Add(new Component("Alternate Identifier", "ORC-18.4"));
			c.Add(new Component("Alternate Text", "ORC-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-18.6"));
			f.Components = c;
			return f;
		}
		private Field ORC19()
		{
			Field f = new Field("Action By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "ORC-19.1"));
			c.Add(new Component("Family Name", "ORC-19.2"));
			c.Add(new Component("Given Name", "ORC-19.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "ORC-19.4"));
			c.Add(new Component("Suffix", "ORC-19.5"));
			c.Add(new Component("Prefix", "ORC-19.6"));
			c.Add(new Component("Degree", "ORC-19.7"));
			c.Add(new Component("Source Table", "ORC-19.8"));
			c.Add(new Component("Assigning Authority", "ORC-19.9"));
			c.Add(new Component("Name Type Code", "ORC-19.10"));
			c.Add(new Component("Identifier Check Digit", "ORC-19.11"));
			c.Add(new Component("Check Digit Scheme", "ORC-19.12"));
			c.Add(new Component("Identifier Type Code", "ORC-19.13"));
			c.Add(new Component("Assigning Facility", "ORC-19.14"));
			c.Add(new Component("Name Respresentation Code", "ORC-19.15"));
			c.Add(new Component("Name Context", "ORC-19.16"));
			c.Add(new Component("Name Validity Range", "ORC-19.17"));
			c.Add(new Component("Name Assembly Order", "ORC-19.18"));
			c.Add(new Component("Effective Date", "ORC-19.19"));
			c.Add(new Component("Expiration Date", "ORC-19.20"));
			c.Add(new Component("Professional Suffix", "ORC-19.21"));
			c.Add(new Component("Assigning Jurisdiction", "ORC-19.22"));
			c.Add(new Component("Assigning Agency or Department", "ORC-19.23"));
			f.Components = c;
			return f;
		}
		private Field ORC20()
		{
			Field f = new Field("Advanced Beneficiary Notice Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-20.1"));
			c.Add(new Component("", "ORC-20.2"));
			c.Add(new Component("Name of Coding System", "ORC-20.3"));
			c.Add(new Component("Alternate Identifier", "ORC-20.4"));
			c.Add(new Component("Alternate Text", "ORC-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-20.6"));
			f.Components = c;
			return f;
		}
		private Field ORC21()
		{
			Field f = new Field("Ordering Facility Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "ORC-21.1"));
			c.Add(new Component("Organization Name Type Code", "ORC-21.2"));
			c.Add(new Component("ID Number", "ORC-21.3"));
			c.Add(new Component("Check Digit", "ORC-21.4"));
			c.Add(new Component("Check Digit Scheme", "ORC-21.5"));
			c.Add(new Component("Assigning Authority", "ORC-21.6"));
			c.Add(new Component("Identifier Type Code", "ORC-21.7"));
			c.Add(new Component("Assigning Facility", "ORC-21.8"));
			c.Add(new Component("Name Respresentation Code", "ORC-21.9"));
			c.Add(new Component("Organization Identifier", "ORC-21.10"));
			f.Components = c;
			return f;
		}
		private Field ORC22()
		{
			Field f = new Field("Ordering Facility Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "ORC-22.1"));
			c.Add(new Component("Other Designation", "ORC-22.2"));
			c.Add(new Component("City", "ORC-22.3"));
			c.Add(new Component("State or Province", "ORC-22.4"));
			c.Add(new Component("Zip or Postal Code", "ORC-22.5"));
			c.Add(new Component("Country", "ORC-22.6"));
			c.Add(new Component("Address Type", "ORC-22.7"));
			c.Add(new Component("Other Geographic Designation", "ORC-22.8"));
			c.Add(new Component("Country Parish Code", "ORC-22.9"));
			c.Add(new Component("Census Tract", "ORC-22.10"));
			c.Add(new Component("Address Representation Code", "ORC-22.11"));
			c.Add(new Component("Address Validity Range", "ORC-22.12"));
			c.Add(new Component("Effective Date", "ORC-22.13"));
			c.Add(new Component("Expiration Date", "ORC-22.14"));
			f.Components = c;
			return f;
		}
		private Field ORC23()
		{
			Field f = new Field("Ordering Facility Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "ORC-23.1"));
			c.Add(new Component("Tele-Communication Use Code", "ORC-23.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "ORC-23.3"));
			c.Add(new Component("Email Address", "ORC-23.4"));
			c.Add(new Component("Country Code", "ORC-23.5"));
			c.Add(new Component("Area City Code", "ORC-23.6"));
			c.Add(new Component("Local Number", "ORC-23.7"));
			c.Add(new Component("Extension", "ORC-23.8"));
			c.Add(new Component("", "ORC-23.9"));
			c.Add(new Component("Extension Prefix", "ORC-23.10"));
			c.Add(new Component("Speed Dial Code", "ORC-23.11"));
			c.Add(new Component("Unformatted Telephone Number", "ORC-23.12"));
			f.Components = c;
			return f;
		}
		private Field ORC24()
		{
			Field f = new Field("Ordering Provider Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "ORC-24.1"));
			c.Add(new Component("Other Designation", "ORC-24.2"));
			c.Add(new Component("City", "ORC-24.3"));
			c.Add(new Component("State or Province", "ORC-24.4"));
			c.Add(new Component("Zip or Postal Code", "ORC-24.5"));
			c.Add(new Component("Country", "ORC-24.6"));
			c.Add(new Component("Address Type", "ORC-24.7"));
			c.Add(new Component("Other Geographic Designation", "ORC-24.8"));
			c.Add(new Component("Country Parish Code", "ORC-24.9"));
			c.Add(new Component("Census Tract", "ORC-24.10"));
			c.Add(new Component("Address Representation Code", "ORC-24.11"));
			c.Add(new Component("Address Validity Range", "ORC-24.12"));
			c.Add(new Component("Effective Date", "ORC-24.13"));
			c.Add(new Component("Expiration Date", "ORC-24.14"));
			f.Components = c;
			return f;
		}
		private Field ORC25()
		{
			Field f = new Field("Order Status Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-25.1"));
			c.Add(new Component("", "ORC-25.2"));
			c.Add(new Component("Name of Coding System", "ORC-25.3"));
			c.Add(new Component("Alternate Identifier", "ORC-25.4"));
			c.Add(new Component("Alternate Text", "ORC-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-25.6"));
			c.Add(new Component("Coding System Version ID", "ORC-25.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ORC-25.8"));
			c.Add(new Component("Original Text", "ORC-25.9"));
			f.Components = c;
			return f;
		}
		private Field ORC26()
		{
			Field f = new Field("Advanced Beneficiary Notice Override Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-26.1"));
			c.Add(new Component("", "ORC-26.2"));
			c.Add(new Component("Name of Coding System", "ORC-26.3"));
			c.Add(new Component("Alternate Identifier", "ORC-26.4"));
			c.Add(new Component("Alternate Text", "ORC-26.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-26.6"));
			c.Add(new Component("Coding System Version ID", "ORC-26.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ORC-26.8"));
			c.Add(new Component("Original Text", "ORC-26.9"));
			f.Components = c;
			return f;
		}
		private Field ORC27()
		{
			Field f = new Field("Filler's Expected Availability Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "ORC-27.1"));
			c.Add(new Component("Degree of Precision", "ORC-27.2"));
			f.Components = c;
			return f;
		}
		private Field ORC28()
		{
			Field f = new Field("Confidentiality Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-28.1"));
			c.Add(new Component("", "ORC-28.2"));
			c.Add(new Component("Name of Coding System", "ORC-28.3"));
			c.Add(new Component("Alternate Identifier", "ORC-28.4"));
			c.Add(new Component("Alternate Text", "ORC-28.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-28.6"));
			c.Add(new Component("Coding System Version ID", "ORC-28.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ORC-28.8"));
			c.Add(new Component("Original Text", "ORC-28.9"));
			f.Components = c;
			return f;
		}
		private Field ORC29()
		{
			Field f = new Field("Order Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-29.1"));
			c.Add(new Component("", "ORC-29.2"));
			c.Add(new Component("Name of Coding System", "ORC-29.3"));
			c.Add(new Component("Alternate Identifier", "ORC-29.4"));
			c.Add(new Component("Alternate Text", "ORC-29.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-29.6"));
			c.Add(new Component("Coding System Version ID", "ORC-29.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ORC-29.8"));
			c.Add(new Component("Original Text", "ORC-29.9"));
			f.Components = c;
			return f;
		}
		private Field ORC30()
		{
			Field f = new Field("Enterer Authorization Mode");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "ORC-30.1"));
			c.Add(new Component("", "ORC-30.2"));
			c.Add(new Component("Name of Coding System", "ORC-30.3"));
			c.Add(new Component("Alternate Identifier", "ORC-30.4"));
			c.Add(new Component("Alternate Text", "ORC-30.5"));
			c.Add(new Component("Name of Alternate Coding System", "ORC-30.6"));
			c.Add(new Component("Coding System Version ID", "ORC-30.7"));
			c.Add(new Component("Alternate Coding System Version ID", "ORC-30.8"));
			c.Add(new Component("Original Text", "ORC-30.9"));
			f.Components = c;
			return f;
		}
	}
}
