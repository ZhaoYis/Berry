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
/// RXO Class: Constructs an HL7 RXO Segment Object
/// </summary>
public class RXO
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RXO()
		{
			Name = "RXO";
			Description = "Pharmacy/Treatment Order";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RXO1());
			fs.Add(RXO2());
			fs.Add(RXO3());
			fs.Add(RXO4());
			fs.Add(RXO5());
			fs.Add(RXO6());
			fs.Add(RXO7());
			fs.Add(RXO8());
			fs.Add(RXO9());
			fs.Add(RXO10());
			fs.Add(RXO11());
			fs.Add(RXO12());
			fs.Add(RXO13());
			fs.Add(RXO14());
			fs.Add(RXO15());
			fs.Add(RXO16());
			fs.Add(RXO17());
			fs.Add(RXO18());
			fs.Add(RXO19());
			fs.Add(RXO20());
			fs.Add(RXO21());
			fs.Add(RXO22());
			fs.Add(RXO23());
			fs.Add(RXO24());
			fs.Add(RXO25());
			fs.Add(RXO26());
			fs.Add(RXO27());
			fs.Add(RXO28());
			Fields = fs;
		}
		private Field RXO1()
		{
			Field f = new Field("Requested Give Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-1.1"));
			c.Add(new Component("", "RXO-1.2"));
			c.Add(new Component("Name of Coding System", "RXO-1.3"));
			c.Add(new Component("Alternate Identifier", "RXO-1.4"));
			c.Add(new Component("Alternate Text", "RXO-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-1.6"));
			f.Components = c;
			return f;
		}
		private Field RXO2()
		{
			Field f = new Field("Requested Give Amount - Minimum");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-2.1"));
			f.Components = c;
			return f;
		}
		private Field RXO3()
		{
			Field f = new Field("Requested Give Amount - Maximum");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-3.1"));
			f.Components = c;
			return f;
		}
		private Field RXO4()
		{
			Field f = new Field("Requested Give Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-4.1"));
			c.Add(new Component("", "RXO-4.2"));
			c.Add(new Component("Name of Coding System", "RXO-4.3"));
			c.Add(new Component("Alternate Identifier", "RXO-4.4"));
			c.Add(new Component("Alternate Text", "RXO-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-4.6"));
			f.Components = c;
			return f;
		}
		private Field RXO5()
		{
			Field f = new Field("Requested Dosage Form");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-5.1"));
			c.Add(new Component("", "RXO-5.2"));
			c.Add(new Component("Name of Coding System", "RXO-5.3"));
			c.Add(new Component("Alternate Identifier", "RXO-5.4"));
			c.Add(new Component("Alternate Text", "RXO-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-5.6"));
			f.Components = c;
			return f;
		}
		private Field RXO6()
		{
			Field f = new Field("Provider's Pharmacy/Treatment Instructions");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-6.1"));
			c.Add(new Component("", "RXO-6.2"));
			c.Add(new Component("Name of Coding System", "RXO-6.3"));
			c.Add(new Component("Alternate Identifier", "RXO-6.4"));
			c.Add(new Component("Alternate Text", "RXO-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-6.6"));
			f.Components = c;
			return f;
		}
		private Field RXO7()
		{
			Field f = new Field("Provider's Administration Instructions");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-7.1"));
			c.Add(new Component("", "RXO-7.2"));
			c.Add(new Component("Name of Coding System", "RXO-7.3"));
			c.Add(new Component("Alternate Identifier", "RXO-7.4"));
			c.Add(new Component("Alternate Text", "RXO-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-7.6"));
			f.Components = c;
			return f;
		}
		private Field RXO8()
		{
			Field f = new Field("Deliver-To Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "RXO-8.1"));
			c.Add(new Component("Room", "RXO-8.2"));
			c.Add(new Component("Bed", "RXO-8.3"));
			c.Add(new Component("Facility", "RXO-8.4"));
			c.Add(new Component("Location Status", "RXO-8.5"));
			c.Add(new Component("Patient Location Type", "RXO-8.6"));
			c.Add(new Component("Building", "RXO-8.7"));
			c.Add(new Component("Floor Number", "RXO-8.8"));
			c.Add(new Component("Address", "RXO-8.9"));
			f.Components = c;
			return f;
		}
		private Field RXO9()
		{
			Field f = new Field("Allow Substitutions");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-9.1"));
			f.Components = c;
			return f;
		}
		private Field RXO10()
		{
			Field f = new Field("Requested Dispense Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-10.1"));
			c.Add(new Component("", "RXO-10.2"));
			c.Add(new Component("Name of Coding System", "RXO-10.3"));
			c.Add(new Component("Alternate Identifier", "RXO-10.4"));
			c.Add(new Component("Alternate Text", "RXO-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-10.6"));
			f.Components = c;
			return f;
		}
		private Field RXO11()
		{
			Field f = new Field("Requested Dispense Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-11.1"));
			f.Components = c;
			return f;
		}
		private Field RXO12()
		{
			Field f = new Field("Requested Dispense Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-12.1"));
			c.Add(new Component("", "RXO-12.2"));
			c.Add(new Component("Name of Coding System", "RXO-12.3"));
			c.Add(new Component("Alternate Identifier", "RXO-12.4"));
			c.Add(new Component("Alternate Text", "RXO-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-12.6"));
			f.Components = c;
			return f;
		}
		private Field RXO13()
		{
			Field f = new Field("Number Of Refills");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-13.1"));
			f.Components = c;
			return f;
		}
		private Field RXO14()
		{
			Field f = new Field("Ordering Provider's DEA Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "RXO-14.1"));
			c.Add(new Component("Family Name", "RXO-14.2"));
			c.Add(new Component("Given Name", "RXO-14.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "RXO-14.4"));
			c.Add(new Component("Suffix", "RXO-14.5"));
			c.Add(new Component("Prefix", "RXO-14.6"));
			c.Add(new Component("Degree", "RXO-14.7"));
			c.Add(new Component("Source Table", "RXO-14.8"));
			c.Add(new Component("Assigning Authority", "RXO-14.9"));
			c.Add(new Component("Name Type Code", "RXO-14.10"));
			c.Add(new Component("Identifier Check Digit", "RXO-14.11"));
			c.Add(new Component("Check Digit Scheme", "RXO-14.12"));
			c.Add(new Component("Identifier Type Code", "RXO-14.13"));
			c.Add(new Component("Assigning Facility", "RXO-14.14"));
			c.Add(new Component("Name Respresentation Code", "RXO-14.15"));
			c.Add(new Component("Name Context", "RXO-14.16"));
			c.Add(new Component("Name Validity Range", "RXO-14.17"));
			c.Add(new Component("Name Assembly Order", "RXO-14.18"));
			c.Add(new Component("Effective Date", "RXO-14.19"));
			c.Add(new Component("Expiration Date", "RXO-14.20"));
			c.Add(new Component("Professional Suffix", "RXO-14.21"));
			c.Add(new Component("Assigning Jurisdiction", "RXO-14.22"));
			c.Add(new Component("Assigning Agency or Department", "RXO-14.23"));
			f.Components = c;
			return f;
		}
		private Field RXO15()
		{
			Field f = new Field("Pharmacist/Treatment Supplier's Verifier ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "RXO-15.1"));
			c.Add(new Component("Family Name", "RXO-15.2"));
			c.Add(new Component("Given Name", "RXO-15.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "RXO-15.4"));
			c.Add(new Component("Suffix", "RXO-15.5"));
			c.Add(new Component("Prefix", "RXO-15.6"));
			c.Add(new Component("Degree", "RXO-15.7"));
			c.Add(new Component("Source Table", "RXO-15.8"));
			c.Add(new Component("Assigning Authority", "RXO-15.9"));
			c.Add(new Component("Name Type Code", "RXO-15.10"));
			c.Add(new Component("Identifier Check Digit", "RXO-15.11"));
			c.Add(new Component("Check Digit Scheme", "RXO-15.12"));
			c.Add(new Component("Identifier Type Code", "RXO-15.13"));
			c.Add(new Component("Assigning Facility", "RXO-15.14"));
			c.Add(new Component("Name Respresentation Code", "RXO-15.15"));
			c.Add(new Component("Name Context", "RXO-15.16"));
			c.Add(new Component("Name Validity Range", "RXO-15.17"));
			c.Add(new Component("Name Assembly Order", "RXO-15.18"));
			c.Add(new Component("Effective Date", "RXO-15.19"));
			c.Add(new Component("Expiration Date", "RXO-15.20"));
			c.Add(new Component("Professional Suffix", "RXO-15.21"));
			c.Add(new Component("Assigning Jurisdiction", "RXO-15.22"));
			c.Add(new Component("Assigning Agency or Department", "RXO-15.23"));
			f.Components = c;
			return f;
		}
		private Field RXO16()
		{
			Field f = new Field("Needs Human Review");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-16.1"));
			f.Components = c;
			return f;
		}
		private Field RXO17()
		{
			Field f = new Field("Requested Give Per (Time Unit)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-17.1"));
			f.Components = c;
			return f;
		}
		private Field RXO18()
		{
			Field f = new Field("Requested Give Strength");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-18.1"));
			f.Components = c;
			return f;
		}
		private Field RXO19()
		{
			Field f = new Field("Requested Give Strength Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-19.1"));
			c.Add(new Component("", "RXO-19.2"));
			c.Add(new Component("Name of Coding System", "RXO-19.3"));
			c.Add(new Component("Alternate Identifier", "RXO-19.4"));
			c.Add(new Component("Alternate Text", "RXO-19.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-19.6"));
			f.Components = c;
			return f;
		}
		private Field RXO20()
		{
			Field f = new Field("Indication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-20.1"));
			c.Add(new Component("", "RXO-20.2"));
			c.Add(new Component("Name of Coding System", "RXO-20.3"));
			c.Add(new Component("Alternate Identifier", "RXO-20.4"));
			c.Add(new Component("Alternate Text", "RXO-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-20.6"));
			f.Components = c;
			return f;
		}
		private Field RXO21()
		{
			Field f = new Field("Requested Give Rate Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-21.1"));
			f.Components = c;
			return f;
		}
		private Field RXO22()
		{
			Field f = new Field("Requested Give Rate Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-22.1"));
			c.Add(new Component("", "RXO-22.2"));
			c.Add(new Component("Name of Coding System", "RXO-22.3"));
			c.Add(new Component("Alternate Identifier", "RXO-22.4"));
			c.Add(new Component("Alternate Text", "RXO-22.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-22.6"));
			f.Components = c;
			return f;
		}
		private Field RXO23()
		{
			Field f = new Field("Total Daily Dose");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "RXO-23.1"));
			c.Add(new Component("Units", "RXO-23.2"));
			f.Components = c;
			return f;
		}
		private Field RXO24()
		{
			Field f = new Field("Supplementary Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-24.1"));
			c.Add(new Component("", "RXO-24.2"));
			c.Add(new Component("Name of Coding System", "RXO-24.3"));
			c.Add(new Component("Alternate Identifier", "RXO-24.4"));
			c.Add(new Component("Alternate Text", "RXO-24.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-24.6"));
			f.Components = c;
			return f;
		}
		private Field RXO25()
		{
			Field f = new Field("Requested Drug Strength Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-25.1"));
			f.Components = c;
			return f;
		}
		private Field RXO26()
		{
			Field f = new Field("Requested Drug Strength Volume Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXO-26.1"));
			c.Add(new Component("", "RXO-26.2"));
			c.Add(new Component("Name of Coding System", "RXO-26.3"));
			c.Add(new Component("Alternate Identifier", "RXO-26.4"));
			c.Add(new Component("Alternate Text", "RXO-26.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXO-26.6"));
			c.Add(new Component("Coding System Version ID", "RXO-26.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXO-26.8"));
			c.Add(new Component("Original Text", "RXO-26.9"));
			f.Components = c;
			return f;
		}
		private Field RXO27()
		{
			Field f = new Field("Pharmacy Order Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-27.1"));
			f.Components = c;
			return f;
		}
		private Field RXO28()
		{
			Field f = new Field("Dispensing Interval");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXO-28.1"));
			f.Components = c;
			return f;
		}
	}
}
