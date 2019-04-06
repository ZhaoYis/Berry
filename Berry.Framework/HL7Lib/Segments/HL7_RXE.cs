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
/// RXE Class: Constructs an HL7 RXE Segment Object
/// </summary>
public class RXE
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RXE()
		{
			Name = "RXE";
			Description = "Pharmacy/Treatment Encoded Order";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RXE1());
			fs.Add(RXE2());
			fs.Add(RXE3());
			fs.Add(RXE4());
			fs.Add(RXE5());
			fs.Add(RXE6());
			fs.Add(RXE7());
			fs.Add(RXE8());
			fs.Add(RXE9());
			fs.Add(RXE10());
			fs.Add(RXE11());
			fs.Add(RXE12());
			fs.Add(RXE13());
			fs.Add(RXE14());
			fs.Add(RXE15());
			fs.Add(RXE16());
			fs.Add(RXE17());
			fs.Add(RXE18());
			fs.Add(RXE19());
			fs.Add(RXE20());
			fs.Add(RXE21());
			fs.Add(RXE22());
			fs.Add(RXE23());
			fs.Add(RXE24());
			fs.Add(RXE25());
			fs.Add(RXE26());
			fs.Add(RXE27());
			fs.Add(RXE28());
			fs.Add(RXE29());
			fs.Add(RXE30());
			fs.Add(RXE31());
			fs.Add(RXE32());
			fs.Add(RXE33());
			fs.Add(RXE34());
			fs.Add(RXE35());
			fs.Add(RXE36());
			fs.Add(RXE37());
			fs.Add(RXE38());
			fs.Add(RXE39());
			fs.Add(RXE40());
			fs.Add(RXE41());
			fs.Add(RXE42());
			fs.Add(RXE43());
			fs.Add(RXE44());
			Fields = fs;
		}
		private Field RXE1()
		{
			Field f = new Field("Quantity/Timing");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "RXE-1.1"));
			c.Add(new Component("Interval", "RXE-1.2"));
			c.Add(new Component("Duration", "RXE-1.3"));
			c.Add(new Component("Start Date/Time", "RXE-1.4"));
			c.Add(new Component("End Date Time", "RXE-1.5"));
			c.Add(new Component("Priority", "RXE-1.6"));
			c.Add(new Component("Condition", "RXE-1.7"));
			c.Add(new Component("", "RXE-1.8"));
			c.Add(new Component("Conjunction", "RXE-1.9"));
			c.Add(new Component("Order Sequencing", "RXE-1.10"));
			c.Add(new Component("Occurrence Duration", "RXE-1.11"));
			c.Add(new Component("Total Occurrences", "RXE-1.12"));
			f.Components = c;
			return f;
		}
		private Field RXE2()
		{
			Field f = new Field("Give Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-2.1"));
			c.Add(new Component("", "RXE-2.2"));
			c.Add(new Component("Name of Coding System", "RXE-2.3"));
			c.Add(new Component("Alternate Identifier", "RXE-2.4"));
			c.Add(new Component("Alternate Text", "RXE-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-2.6"));
			f.Components = c;
			return f;
		}
		private Field RXE3()
		{
			Field f = new Field("Give Amount - Minimum");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-3.1"));
			f.Components = c;
			return f;
		}
		private Field RXE4()
		{
			Field f = new Field("Give Amount - Maximum");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-4.1"));
			f.Components = c;
			return f;
		}
		private Field RXE5()
		{
			Field f = new Field("Give Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-5.1"));
			c.Add(new Component("", "RXE-5.2"));
			c.Add(new Component("Name of Coding System", "RXE-5.3"));
			c.Add(new Component("Alternate Identifier", "RXE-5.4"));
			c.Add(new Component("Alternate Text", "RXE-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-5.6"));
			f.Components = c;
			return f;
		}
		private Field RXE6()
		{
			Field f = new Field("Give Dosage Form");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-6.1"));
			c.Add(new Component("", "RXE-6.2"));
			c.Add(new Component("Name of Coding System", "RXE-6.3"));
			c.Add(new Component("Alternate Identifier", "RXE-6.4"));
			c.Add(new Component("Alternate Text", "RXE-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-6.6"));
			f.Components = c;
			return f;
		}
		private Field RXE7()
		{
			Field f = new Field("Provider's Administration Instructions");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-7.1"));
			c.Add(new Component("", "RXE-7.2"));
			c.Add(new Component("Name of Coding System", "RXE-7.3"));
			c.Add(new Component("Alternate Identifier", "RXE-7.4"));
			c.Add(new Component("Alternate Text", "RXE-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-7.6"));
			f.Components = c;
			return f;
		}
		private Field RXE8()
		{
			Field f = new Field("Deliver-To Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "RXE-8.1"));
			c.Add(new Component("Room", "RXE-8.2"));
			c.Add(new Component("Bed", "RXE-8.3"));
			c.Add(new Component("Facility", "RXE-8.4"));
			c.Add(new Component("Location Status", "RXE-8.5"));
			c.Add(new Component("Patient Location Type", "RXE-8.6"));
			c.Add(new Component("Building", "RXE-8.7"));
			c.Add(new Component("Floor Number", "RXE-8.8"));
			c.Add(new Component("Address", "RXE-8.9"));
			f.Components = c;
			return f;
		}
		private Field RXE9()
		{
			Field f = new Field("Substitution Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-9.1"));
			f.Components = c;
			return f;
		}
		private Field RXE10()
		{
			Field f = new Field("Dispense Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-10.1"));
			f.Components = c;
			return f;
		}
		private Field RXE11()
		{
			Field f = new Field("Dispense Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-11.1"));
			c.Add(new Component("", "RXE-11.2"));
			c.Add(new Component("Name of Coding System", "RXE-11.3"));
			c.Add(new Component("Alternate Identifier", "RXE-11.4"));
			c.Add(new Component("Alternate Text", "RXE-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-11.6"));
			f.Components = c;
			return f;
		}
		private Field RXE12()
		{
			Field f = new Field("Number Of Refills");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-12.1"));
			f.Components = c;
			return f;
		}
		private Field RXE13()
		{
			Field f = new Field("Ordering Provider's DEA Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "RXE-13.1"));
			c.Add(new Component("Family Name", "RXE-13.2"));
			c.Add(new Component("Given Name", "RXE-13.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "RXE-13.4"));
			c.Add(new Component("Suffix", "RXE-13.5"));
			c.Add(new Component("Prefix", "RXE-13.6"));
			c.Add(new Component("Degree", "RXE-13.7"));
			c.Add(new Component("Source Table", "RXE-13.8"));
			c.Add(new Component("Assigning Authority", "RXE-13.9"));
			c.Add(new Component("Name Type Code", "RXE-13.10"));
			c.Add(new Component("Identifier Check Digit", "RXE-13.11"));
			c.Add(new Component("Check Digit Scheme", "RXE-13.12"));
			c.Add(new Component("Identifier Type Code", "RXE-13.13"));
			c.Add(new Component("Assigning Facility", "RXE-13.14"));
			c.Add(new Component("Name Respresentation Code", "RXE-13.15"));
			c.Add(new Component("Name Context", "RXE-13.16"));
			c.Add(new Component("Name Validity Range", "RXE-13.17"));
			c.Add(new Component("Name Assembly Order", "RXE-13.18"));
			c.Add(new Component("Effective Date", "RXE-13.19"));
			c.Add(new Component("Expiration Date", "RXE-13.20"));
			c.Add(new Component("Professional Suffix", "RXE-13.21"));
			c.Add(new Component("Assigning Jurisdiction", "RXE-13.22"));
			c.Add(new Component("Assigning Agency or Department", "RXE-13.23"));
			f.Components = c;
			return f;
		}
		private Field RXE14()
		{
			Field f = new Field("Pharmacist/Treatment Supplier's Verifier ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "RXE-14.1"));
			c.Add(new Component("Family Name", "RXE-14.2"));
			c.Add(new Component("Given Name", "RXE-14.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "RXE-14.4"));
			c.Add(new Component("Suffix", "RXE-14.5"));
			c.Add(new Component("Prefix", "RXE-14.6"));
			c.Add(new Component("Degree", "RXE-14.7"));
			c.Add(new Component("Source Table", "RXE-14.8"));
			c.Add(new Component("Assigning Authority", "RXE-14.9"));
			c.Add(new Component("Name Type Code", "RXE-14.10"));
			c.Add(new Component("Identifier Check Digit", "RXE-14.11"));
			c.Add(new Component("Check Digit Scheme", "RXE-14.12"));
			c.Add(new Component("Identifier Type Code", "RXE-14.13"));
			c.Add(new Component("Assigning Facility", "RXE-14.14"));
			c.Add(new Component("Name Respresentation Code", "RXE-14.15"));
			c.Add(new Component("Name Context", "RXE-14.16"));
			c.Add(new Component("Name Validity Range", "RXE-14.17"));
			c.Add(new Component("Name Assembly Order", "RXE-14.18"));
			c.Add(new Component("Effective Date", "RXE-14.19"));
			c.Add(new Component("Expiration Date", "RXE-14.20"));
			c.Add(new Component("Professional Suffix", "RXE-14.21"));
			c.Add(new Component("Assigning Jurisdiction", "RXE-14.22"));
			c.Add(new Component("Assigning Agency or Department", "RXE-14.23"));
			f.Components = c;
			return f;
		}
		private Field RXE15()
		{
			Field f = new Field("Prescription Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-15.1"));
			f.Components = c;
			return f;
		}
		private Field RXE16()
		{
			Field f = new Field("Number of Refills Remaining");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-16.1"));
			f.Components = c;
			return f;
		}
		private Field RXE17()
		{
			Field f = new Field("Number of Refills/Doses Dispensed");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-17.1"));
			f.Components = c;
			return f;
		}
		private Field RXE18()
		{
			Field f = new Field("D/T of Most Recent Refill or Dose Dispensed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXE-18.1"));
			c.Add(new Component("Degree of Precision", "RXE-18.2"));
			f.Components = c;
			return f;
		}
		private Field RXE19()
		{
			Field f = new Field("Total Daily Dose");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "RXE-19.1"));
			c.Add(new Component("Units", "RXE-19.2"));
			f.Components = c;
			return f;
		}
		private Field RXE20()
		{
			Field f = new Field("Needs Human Review");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-20.1"));
			f.Components = c;
			return f;
		}
		private Field RXE21()
		{
			Field f = new Field("Pharmacy/Treatment Supplier's Special Dispensing Instructions");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-21.1"));
			c.Add(new Component("", "RXE-21.2"));
			c.Add(new Component("Name of Coding System", "RXE-21.3"));
			c.Add(new Component("Alternate Identifier", "RXE-21.4"));
			c.Add(new Component("Alternate Text", "RXE-21.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-21.6"));
			f.Components = c;
			return f;
		}
		private Field RXE22()
		{
			Field f = new Field("Give Per (Time Unit)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-22.1"));
			f.Components = c;
			return f;
		}
		private Field RXE23()
		{
			Field f = new Field("Give Rate Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-23.1"));
			f.Components = c;
			return f;
		}
		private Field RXE24()
		{
			Field f = new Field("Give Rate Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-24.1"));
			c.Add(new Component("", "RXE-24.2"));
			c.Add(new Component("Name of Coding System", "RXE-24.3"));
			c.Add(new Component("Alternate Identifier", "RXE-24.4"));
			c.Add(new Component("Alternate Text", "RXE-24.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-24.6"));
			f.Components = c;
			return f;
		}
		private Field RXE25()
		{
			Field f = new Field("Give Strength");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-25.1"));
			f.Components = c;
			return f;
		}
		private Field RXE26()
		{
			Field f = new Field("Give Strength Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-26.1"));
			c.Add(new Component("", "RXE-26.2"));
			c.Add(new Component("Name of Coding System", "RXE-26.3"));
			c.Add(new Component("Alternate Identifier", "RXE-26.4"));
			c.Add(new Component("Alternate Text", "RXE-26.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-26.6"));
			f.Components = c;
			return f;
		}
		private Field RXE27()
		{
			Field f = new Field("Give Indication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-27.1"));
			c.Add(new Component("", "RXE-27.2"));
			c.Add(new Component("Name of Coding System", "RXE-27.3"));
			c.Add(new Component("Alternate Identifier", "RXE-27.4"));
			c.Add(new Component("Alternate Text", "RXE-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-27.6"));
			f.Components = c;
			return f;
		}
		private Field RXE28()
		{
			Field f = new Field("Dispense Package Size");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-28.1"));
			f.Components = c;
			return f;
		}
		private Field RXE29()
		{
			Field f = new Field("Dispense Package Size Unit");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-29.1"));
			c.Add(new Component("", "RXE-29.2"));
			c.Add(new Component("Name of Coding System", "RXE-29.3"));
			c.Add(new Component("Alternate Identifier", "RXE-29.4"));
			c.Add(new Component("Alternate Text", "RXE-29.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-29.6"));
			f.Components = c;
			return f;
		}
		private Field RXE30()
		{
			Field f = new Field("Dispense Package Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-30.1"));
			f.Components = c;
			return f;
		}
		private Field RXE31()
		{
			Field f = new Field("Supplementary Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-31.1"));
			c.Add(new Component("", "RXE-31.2"));
			c.Add(new Component("Name of Coding System", "RXE-31.3"));
			c.Add(new Component("Alternate Identifier", "RXE-31.4"));
			c.Add(new Component("Alternate Text", "RXE-31.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-31.6"));
			f.Components = c;
			return f;
		}
		private Field RXE32()
		{
			Field f = new Field("Original Order Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXE-32.1"));
			c.Add(new Component("Degree of Precision", "RXE-32.2"));
			f.Components = c;
			return f;
		}
		private Field RXE33()
		{
			Field f = new Field("Give Drug Strength Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-33.1"));
			f.Components = c;
			return f;
		}
		private Field RXE34()
		{
			Field f = new Field("Give Drug Strength Volume Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-34.1"));
			c.Add(new Component("", "RXE-34.2"));
			c.Add(new Component("Name of Coding System", "RXE-34.3"));
			c.Add(new Component("Alternate Identifier", "RXE-34.4"));
			c.Add(new Component("Alternate Text", "RXE-34.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-34.6"));
			c.Add(new Component("Coding System Version ID", "RXE-34.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXE-34.8"));
			c.Add(new Component("Original Text", "RXE-34.9"));
			f.Components = c;
			return f;
		}
		private Field RXE35()
		{
			Field f = new Field("Controlled Substance Schedule");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-35.1"));
			c.Add(new Component("", "RXE-35.2"));
			c.Add(new Component("Name of Coding System", "RXE-35.3"));
			c.Add(new Component("Alternate Identifier", "RXE-35.4"));
			c.Add(new Component("Alternate Text", "RXE-35.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-35.6"));
			c.Add(new Component("Coding System Version ID", "RXE-35.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXE-35.8"));
			c.Add(new Component("Original Text", "RXE-35.9"));
			f.Components = c;
			return f;
		}
		private Field RXE36()
		{
			Field f = new Field("Formulary Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-36.1"));
			f.Components = c;
			return f;
		}
		private Field RXE37()
		{
			Field f = new Field("Pharmaceutical Substance Alternative");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-37.1"));
			c.Add(new Component("", "RXE-37.2"));
			c.Add(new Component("Name of Coding System", "RXE-37.3"));
			c.Add(new Component("Alternate Identifier", "RXE-37.4"));
			c.Add(new Component("Alternate Text", "RXE-37.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-37.6"));
			c.Add(new Component("Coding System Version ID", "RXE-37.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXE-37.8"));
			c.Add(new Component("Original Text", "RXE-37.9"));
			f.Components = c;
			return f;
		}
		private Field RXE38()
		{
			Field f = new Field("Pharmacy of Most Recent Fill");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-38.1"));
			c.Add(new Component("", "RXE-38.2"));
			c.Add(new Component("Name of Coding System", "RXE-38.3"));
			c.Add(new Component("Alternate Identifier", "RXE-38.4"));
			c.Add(new Component("Alternate Text", "RXE-38.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-38.6"));
			c.Add(new Component("Coding System Version ID", "RXE-38.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXE-38.8"));
			c.Add(new Component("Original Text", "RXE-38.9"));
			f.Components = c;
			return f;
		}
		private Field RXE39()
		{
			Field f = new Field("Initial Dispense Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-39.1"));
			f.Components = c;
			return f;
		}
		private Field RXE40()
		{
			Field f = new Field("Dispensing Pharmacy");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXE-40.1"));
			c.Add(new Component("", "RXE-40.2"));
			c.Add(new Component("Name of Coding System", "RXE-40.3"));
			c.Add(new Component("Alternate Identifier", "RXE-40.4"));
			c.Add(new Component("Alternate Text", "RXE-40.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXE-40.6"));
			c.Add(new Component("Coding System Version ID", "RXE-40.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXE-40.8"));
			c.Add(new Component("Original Text", "RXE-40.9"));
			f.Components = c;
			return f;
		}
		private Field RXE41()
		{
			Field f = new Field("Dispensing Pharmacy Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "RXE-41.1"));
			c.Add(new Component("Other Designation", "RXE-41.2"));
			c.Add(new Component("City", "RXE-41.3"));
			c.Add(new Component("State or Province", "RXE-41.4"));
			c.Add(new Component("Zip or Postal Code", "RXE-41.5"));
			c.Add(new Component("Country", "RXE-41.6"));
			c.Add(new Component("Address Type", "RXE-41.7"));
			c.Add(new Component("Other Geographic Designation", "RXE-41.8"));
			c.Add(new Component("Country Parish Code", "RXE-41.9"));
			c.Add(new Component("Census Tract", "RXE-41.10"));
			c.Add(new Component("Address Representation Code", "RXE-41.11"));
			c.Add(new Component("Address Validity Range", "RXE-41.12"));
			c.Add(new Component("Effective Date", "RXE-41.13"));
			c.Add(new Component("Expiration Date", "RXE-41.14"));
			f.Components = c;
			return f;
		}
		private Field RXE42()
		{
			Field f = new Field("Deliver-to Patient Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "RXE-42.1"));
			c.Add(new Component("Room", "RXE-42.2"));
			c.Add(new Component("Bed", "RXE-42.3"));
			c.Add(new Component("Facility", "RXE-42.4"));
			c.Add(new Component("Location Status", "RXE-42.5"));
			c.Add(new Component("Person Location Type", "RXE-42.6"));
			c.Add(new Component("Building", "RXE-42.7"));
			c.Add(new Component("Floor Number", "RXE-42.8"));
			c.Add(new Component("Location Description", "RXE-42.9"));
			c.Add(new Component("Comprehensive Location Identifier", "RXE-42.10"));
			c.Add(new Component("Assigning Authority for Location", "RXE-42.11"));
			f.Components = c;
			return f;
		}
		private Field RXE43()
		{
			Field f = new Field("Deliver-to Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "RXE-43.1"));
			c.Add(new Component("Other Designation", "RXE-43.2"));
			c.Add(new Component("City", "RXE-43.3"));
			c.Add(new Component("State or Province", "RXE-43.4"));
			c.Add(new Component("Zip or Postal Code", "RXE-43.5"));
			c.Add(new Component("Country", "RXE-43.6"));
			c.Add(new Component("Address Type", "RXE-43.7"));
			c.Add(new Component("Other Geographic Designation", "RXE-43.8"));
			c.Add(new Component("Country Parish Code", "RXE-43.9"));
			c.Add(new Component("Census Tract", "RXE-43.10"));
			c.Add(new Component("Address Representation Code", "RXE-43.11"));
			c.Add(new Component("Address Validity Range", "RXE-43.12"));
			c.Add(new Component("Effective Date", "RXE-43.13"));
			c.Add(new Component("Expiration Date", "RXE-43.14"));
			f.Components = c;
			return f;
		}
		private Field RXE44()
		{
			Field f = new Field("Pharmacy Order Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXE-44.1"));
			f.Components = c;
			return f;
		}
	}
}
