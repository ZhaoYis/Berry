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
/// FT1 Class: Constructs an HL7 FT1 Segment Object
/// </summary>
public class FT1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public FT1()
		{
			Name = "FT1";
			Description = "Financial Transaction";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(FT11());
			fs.Add(FT12());
			fs.Add(FT13());
			fs.Add(FT14());
			fs.Add(FT15());
			fs.Add(FT16());
			fs.Add(FT17());
			fs.Add(FT18());
			fs.Add(FT19());
			fs.Add(FT110());
			fs.Add(FT111());
			fs.Add(FT112());
			fs.Add(FT113());
			fs.Add(FT114());
			fs.Add(FT115());
			fs.Add(FT116());
			fs.Add(FT117());
			fs.Add(FT118());
			fs.Add(FT119());
			fs.Add(FT120());
			fs.Add(FT121());
			fs.Add(FT122());
			fs.Add(FT123());
			fs.Add(FT124());
			fs.Add(FT125());
			fs.Add(FT126());
			fs.Add(FT127());
			fs.Add(FT128());
			fs.Add(FT129());
			fs.Add(FT130());
			fs.Add(FT131());
			Fields = fs;
		}
		private Field FT11()
		{
			Field f = new Field("Set ID - FT1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "FT1-1.1"));
			f.Components = c;
			return f;
		}
		private Field FT12()
		{
			Field f = new Field("Transaction ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FT1-2.1"));
			f.Components = c;
			return f;
		}
		private Field FT13()
		{
			Field f = new Field("Transaction Batch ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FT1-3.1"));
			f.Components = c;
			return f;
		}
		private Field FT14()
		{
			Field f = new Field("Transaction Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Range Start Date/Time", "FT1-4.1"));
			c.Add(new Component("Range End Date/Time", "FT1-4.2"));
			f.Components = c;
			return f;
		}
		private Field FT15()
		{
			Field f = new Field("Transaction Posting Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "FT1-5.1"));
			c.Add(new Component("Degree of Precision", "FT1-5.2"));
			f.Components = c;
			return f;
		}
		private Field FT16()
		{
			Field f = new Field("Transaction Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FT1-6.1"));
			f.Components = c;
			return f;
		}
		private Field FT17()
		{
			Field f = new Field("Transaction Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-7.1"));
			c.Add(new Component("", "FT1-7.2"));
			c.Add(new Component("Name of Coding System", "FT1-7.3"));
			c.Add(new Component("Alternate Identifier", "FT1-7.4"));
			c.Add(new Component("Alternate Text", "FT1-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-7.6"));
			f.Components = c;
			return f;
		}
		private Field FT18()
		{
			Field f = new Field("Transaction Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FT1-8.1"));
			f.Components = c;
			return f;
		}
		private Field FT19()
		{
			Field f = new Field("Transaction Description - Alt");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FT1-9.1"));
			f.Components = c;
			return f;
		}
		private Field FT110()
		{
			Field f = new Field("Transaction Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FT1-10.1"));
			f.Components = c;
			return f;
		}
		private Field FT111()
		{
			Field f = new Field("Transaction Amount - Extended");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "FT1-11.1"));
			c.Add(new Component("Price Type", "FT1-11.2"));
			c.Add(new Component("From Value", "FT1-11.3"));
			c.Add(new Component("To Value", "FT1-11.4"));
			c.Add(new Component("Range Units", "FT1-11.5"));
			c.Add(new Component("Range Type", "FT1-11.6"));
			f.Components = c;
			return f;
		}
		private Field FT112()
		{
			Field f = new Field("Transaction Amount - Unit");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "FT1-12.1"));
			c.Add(new Component("Price Type", "FT1-12.2"));
			c.Add(new Component("From Value", "FT1-12.3"));
			c.Add(new Component("To Value", "FT1-12.4"));
			c.Add(new Component("Range Units", "FT1-12.5"));
			c.Add(new Component("Range Type", "FT1-12.6"));
			f.Components = c;
			return f;
		}
		private Field FT113()
		{
			Field f = new Field("Department Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-13.1"));
			c.Add(new Component("", "FT1-13.2"));
			c.Add(new Component("Name of Coding System", "FT1-13.3"));
			c.Add(new Component("Alternate Identifier", "FT1-13.4"));
			c.Add(new Component("Alternate Text", "FT1-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-13.6"));
			f.Components = c;
			return f;
		}
		private Field FT114()
		{
			Field f = new Field("Insurance Plan ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-14.1"));
			c.Add(new Component("", "FT1-14.2"));
			c.Add(new Component("Name of Coding System", "FT1-14.3"));
			c.Add(new Component("Alternate Identifier", "FT1-14.4"));
			c.Add(new Component("Alternate Text", "FT1-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-14.6"));
			f.Components = c;
			return f;
		}
		private Field FT115()
		{
			Field f = new Field("Insurance Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "FT1-15.1"));
			c.Add(new Component("Price Type", "FT1-15.2"));
			c.Add(new Component("From Value", "FT1-15.3"));
			c.Add(new Component("To Value", "FT1-15.4"));
			c.Add(new Component("Range Units", "FT1-15.5"));
			c.Add(new Component("Range Type", "FT1-15.6"));
			f.Components = c;
			return f;
		}
		private Field FT116()
		{
			Field f = new Field("Assigned Patient Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "FT1-16.1"));
			c.Add(new Component("Room", "FT1-16.2"));
			c.Add(new Component("Bed", "FT1-16.3"));
			c.Add(new Component("Facility", "FT1-16.4"));
			c.Add(new Component("Location Status", "FT1-16.5"));
			c.Add(new Component("Person Location Type", "FT1-16.6"));
			c.Add(new Component("Building", "FT1-16.7"));
			c.Add(new Component("Floor Number", "FT1-16.8"));
			c.Add(new Component("Location Description", "FT1-16.9"));
			c.Add(new Component("Comprehensive Location Identifier", "FT1-16.10"));
			c.Add(new Component("Assigning Authority for Location", "FT1-16.11"));
			f.Components = c;
			return f;
		}
		private Field FT117()
		{
			Field f = new Field("Fee Schedule");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FT1-17.1"));
			f.Components = c;
			return f;
		}
		private Field FT118()
		{
			Field f = new Field("Patient Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "FT1-18.1"));
			f.Components = c;
			return f;
		}
		private Field FT119()
		{
			Field f = new Field("Diagnosis Code - FT1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-19.1"));
			c.Add(new Component("", "FT1-19.2"));
			c.Add(new Component("Name of Coding System", "FT1-19.3"));
			c.Add(new Component("Alternate Identifier", "FT1-19.4"));
			c.Add(new Component("Alternate Text", "FT1-19.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-19.6"));
			f.Components = c;
			return f;
		}
		private Field FT120()
		{
			Field f = new Field("Performed By Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "FT1-20.1"));
			c.Add(new Component("Family Name", "FT1-20.2"));
			c.Add(new Component("Given Name", "FT1-20.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "FT1-20.4"));
			c.Add(new Component("Suffix", "FT1-20.5"));
			c.Add(new Component("Prefix", "FT1-20.6"));
			c.Add(new Component("Degree", "FT1-20.7"));
			c.Add(new Component("Source Table", "FT1-20.8"));
			c.Add(new Component("Assigning Authority", "FT1-20.9"));
			c.Add(new Component("Name Type Code", "FT1-20.10"));
			c.Add(new Component("Identifier Check Digit", "FT1-20.11"));
			c.Add(new Component("Check Digit Scheme", "FT1-20.12"));
			c.Add(new Component("Identifier Type Code", "FT1-20.13"));
			c.Add(new Component("Assigning Facility", "FT1-20.14"));
			c.Add(new Component("Name Respresentation Code", "FT1-20.15"));
			c.Add(new Component("Name Context", "FT1-20.16"));
			c.Add(new Component("Name Validity Range", "FT1-20.17"));
			c.Add(new Component("Name Assembly Order", "FT1-20.18"));
			c.Add(new Component("Effective Date", "FT1-20.19"));
			c.Add(new Component("Expiration Date", "FT1-20.20"));
			c.Add(new Component("Professional Suffix", "FT1-20.21"));
			c.Add(new Component("Assigning Jurisdiction", "FT1-20.22"));
			c.Add(new Component("Assigning Agency or Department", "FT1-20.23"));
			f.Components = c;
			return f;
		}
		private Field FT121()
		{
			Field f = new Field("Ordered By Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "FT1-21.1"));
			c.Add(new Component("Family Name", "FT1-21.2"));
			c.Add(new Component("Given Name", "FT1-21.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "FT1-21.4"));
			c.Add(new Component("Suffix", "FT1-21.5"));
			c.Add(new Component("Prefix", "FT1-21.6"));
			c.Add(new Component("Degree", "FT1-21.7"));
			c.Add(new Component("Source Table", "FT1-21.8"));
			c.Add(new Component("Assigning Authority", "FT1-21.9"));
			c.Add(new Component("Name Type Code", "FT1-21.10"));
			c.Add(new Component("Identifier Check Digit", "FT1-21.11"));
			c.Add(new Component("Check Digit Scheme", "FT1-21.12"));
			c.Add(new Component("Identifier Type Code", "FT1-21.13"));
			c.Add(new Component("Assigning Facility", "FT1-21.14"));
			c.Add(new Component("Name Respresentation Code", "FT1-21.15"));
			c.Add(new Component("Name Context", "FT1-21.16"));
			c.Add(new Component("Name Validity Range", "FT1-21.17"));
			c.Add(new Component("Name Assembly Order", "FT1-21.18"));
			c.Add(new Component("Effective Date", "FT1-21.19"));
			c.Add(new Component("Expiration Date", "FT1-21.20"));
			c.Add(new Component("Professional Suffix", "FT1-21.21"));
			c.Add(new Component("Assigning Jurisdiction", "FT1-21.22"));
			c.Add(new Component("Assigning Agency or Department", "FT1-21.23"));
			f.Components = c;
			return f;
		}
		private Field FT122()
		{
			Field f = new Field("Unit Cost");
			List<Component> c = new List<Component>();
			c.Add(new Component("Price", "FT1-22.1"));
			c.Add(new Component("Price Type", "FT1-22.2"));
			c.Add(new Component("From Value", "FT1-22.3"));
			c.Add(new Component("To Value", "FT1-22.4"));
			c.Add(new Component("Range Units", "FT1-22.5"));
			c.Add(new Component("Range Type", "FT1-22.6"));
			f.Components = c;
			return f;
		}
		private Field FT123()
		{
			Field f = new Field("Filler Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "FT1-23.1"));
			c.Add(new Component("Namespace ID", "FT1-23.2"));
			c.Add(new Component("Universal ID", "FT1-23.3"));
			c.Add(new Component("Universal ID Type", "FT1-23.4"));
			f.Components = c;
			return f;
		}
		private Field FT124()
		{
			Field f = new Field("Entered By Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "FT1-24.1"));
			c.Add(new Component("Family Name", "FT1-24.2"));
			c.Add(new Component("Given Name", "FT1-24.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "FT1-24.4"));
			c.Add(new Component("Suffix", "FT1-24.5"));
			c.Add(new Component("Prefix", "FT1-24.6"));
			c.Add(new Component("Degree", "FT1-24.7"));
			c.Add(new Component("Source Table", "FT1-24.8"));
			c.Add(new Component("Assigning Authority", "FT1-24.9"));
			c.Add(new Component("Name Type Code", "FT1-24.10"));
			c.Add(new Component("Identifier Check Digit", "FT1-24.11"));
			c.Add(new Component("Check Digit Scheme", "FT1-24.12"));
			c.Add(new Component("Identifier Type Code", "FT1-24.13"));
			c.Add(new Component("Assigning Facility", "FT1-24.14"));
			c.Add(new Component("Name Respresentation Code", "FT1-24.15"));
			c.Add(new Component("Name Context", "FT1-24.16"));
			c.Add(new Component("Name Validity Range", "FT1-24.17"));
			c.Add(new Component("Name Assembly Order", "FT1-24.18"));
			c.Add(new Component("Effective Date", "FT1-24.19"));
			c.Add(new Component("Expiration Date", "FT1-24.20"));
			c.Add(new Component("Professional Suffix", "FT1-24.21"));
			c.Add(new Component("Assigning Jurisdiction", "FT1-24.22"));
			c.Add(new Component("Assigning Agency or Department", "FT1-24.23"));
			f.Components = c;
			return f;
		}
		private Field FT125()
		{
			Field f = new Field("Procedure Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-25.1"));
			c.Add(new Component("", "FT1-25.2"));
			c.Add(new Component("Name of Coding System", "FT1-25.3"));
			c.Add(new Component("Alternate Identifier", "FT1-25.4"));
			c.Add(new Component("Alternate Text", "FT1-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-25.6"));
			f.Components = c;
			return f;
		}
		private Field FT126()
		{
			Field f = new Field("Procedure Code Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-26.1"));
			c.Add(new Component("", "FT1-26.2"));
			c.Add(new Component("Name of Coding System", "FT1-26.3"));
			c.Add(new Component("Alternate Identifier", "FT1-26.4"));
			c.Add(new Component("Alternate Text", "FT1-26.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-26.6"));
			f.Components = c;
			return f;
		}
		private Field FT127()
		{
			Field f = new Field("Advanced Beneficiary Notice Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-27.1"));
			c.Add(new Component("", "FT1-27.2"));
			c.Add(new Component("Name of Coding System", "FT1-27.3"));
			c.Add(new Component("Alternate Identifier", "FT1-27.4"));
			c.Add(new Component("Alternate Text", "FT1-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-27.6"));
			f.Components = c;
			return f;
		}
		private Field FT128()
		{
			Field f = new Field("Medically Necessary Duplicate Procedure Reason.");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-28.1"));
			c.Add(new Component("", "FT1-28.2"));
			c.Add(new Component("Name of Coding System", "FT1-28.3"));
			c.Add(new Component("Alternate Identifier", "FT1-28.4"));
			c.Add(new Component("Alternate Text", "FT1-28.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-28.6"));
			c.Add(new Component("Coding System Version ID", "FT1-28.7"));
			c.Add(new Component("Alternate Coding System Version ID", "FT1-28.8"));
			c.Add(new Component("Original Text", "FT1-28.9"));
			f.Components = c;
			return f;
		}
		private Field FT129()
		{
			Field f = new Field("NDC Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "FT1-29.1"));
			c.Add(new Component("", "FT1-29.2"));
			c.Add(new Component("Name of Coding System", "FT1-29.3"));
			c.Add(new Component("Alternate Identifier", "FT1-29.4"));
			c.Add(new Component("Alternate Text", "FT1-29.5"));
			c.Add(new Component("Name of Alternate Coding System", "FT1-29.6"));
			c.Add(new Component("Coding System Version ID", "FT1-29.7"));
			c.Add(new Component("Alternate Coding System Version ID", "FT1-29.8"));
			c.Add(new Component("Original Text", "FT1-29.9"));
			f.Components = c;
			return f;
		}
		private Field FT130()
		{
			Field f = new Field("Payment Reference ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "FT1-30.1"));
			c.Add(new Component("Check Digit", "FT1-30.2"));
			c.Add(new Component("Check Digit Scheme", "FT1-30.3"));
			c.Add(new Component("Assigning Authority", "FT1-30.4"));
			c.Add(new Component("Identifier Type Code", "FT1-30.5"));
			c.Add(new Component("Assigning Facility", "FT1-30.6"));
			c.Add(new Component("Effective Date", "FT1-30.7"));
			c.Add(new Component("Expiration Date", "FT1-30.8"));
			c.Add(new Component("Assigning Jurisdiction", "FT1-30.9"));
			c.Add(new Component("Assigning Agency or Department", "FT1-30.10"));
			f.Components = c;
			return f;
		}
		private Field FT131()
		{
			Field f = new Field("Transaction Reference Key");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "FT1-31.1"));
			f.Components = c;
			return f;
		}
	}
}
