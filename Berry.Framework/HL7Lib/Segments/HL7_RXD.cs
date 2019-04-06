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
/// RXD Class: Constructs an HL7 RXD Segment Object
/// </summary>
public class RXD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RXD()
		{
			Name = "RXD";
			Description = "Pharmacy/Treatment Dispense";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RXD1());
			fs.Add(RXD2());
			fs.Add(RXD3());
			fs.Add(RXD4());
			fs.Add(RXD5());
			fs.Add(RXD6());
			fs.Add(RXD7());
			fs.Add(RXD8());
			fs.Add(RXD9());
			fs.Add(RXD10());
			fs.Add(RXD11());
			fs.Add(RXD12());
			fs.Add(RXD13());
			fs.Add(RXD14());
			fs.Add(RXD15());
			fs.Add(RXD16());
			fs.Add(RXD17());
			fs.Add(RXD18());
			fs.Add(RXD19());
			fs.Add(RXD20());
			fs.Add(RXD21());
			fs.Add(RXD22());
			fs.Add(RXD23());
			fs.Add(RXD24());
			fs.Add(RXD25());
			fs.Add(RXD26());
			fs.Add(RXD27());
			fs.Add(RXD28());
			fs.Add(RXD29());
			fs.Add(RXD30());
			fs.Add(RXD31());
			fs.Add(RXD32());
			fs.Add(RXD33());
			Fields = fs;
		}
		private Field RXD1()
		{
			Field f = new Field("Dispense Sub-ID Counter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-1.1"));
			f.Components = c;
			return f;
		}
		private Field RXD2()
		{
			Field f = new Field("Dispense/Give Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-2.1"));
			c.Add(new Component("", "RXD-2.2"));
			c.Add(new Component("Name of Coding System", "RXD-2.3"));
			c.Add(new Component("Alternate Identifier", "RXD-2.4"));
			c.Add(new Component("Alternate Text", "RXD-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-2.6"));
			f.Components = c;
			return f;
		}
		private Field RXD3()
		{
			Field f = new Field("Date/Time Dispensed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXD-3.1"));
			c.Add(new Component("Degree of Precision", "RXD-3.2"));
			f.Components = c;
			return f;
		}
		private Field RXD4()
		{
			Field f = new Field("Actual Dispense Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-4.1"));
			f.Components = c;
			return f;
		}
		private Field RXD5()
		{
			Field f = new Field("Actual Dispense Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-5.1"));
			c.Add(new Component("", "RXD-5.2"));
			c.Add(new Component("Name of Coding System", "RXD-5.3"));
			c.Add(new Component("Alternate Identifier", "RXD-5.4"));
			c.Add(new Component("Alternate Text", "RXD-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-5.6"));
			f.Components = c;
			return f;
		}
		private Field RXD6()
		{
			Field f = new Field("Actual Dosage Form");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-6.1"));
			c.Add(new Component("", "RXD-6.2"));
			c.Add(new Component("Name of Coding System", "RXD-6.3"));
			c.Add(new Component("Alternate Identifier", "RXD-6.4"));
			c.Add(new Component("Alternate Text", "RXD-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-6.6"));
			f.Components = c;
			return f;
		}
		private Field RXD7()
		{
			Field f = new Field("Prescription Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-7.1"));
			f.Components = c;
			return f;
		}
		private Field RXD8()
		{
			Field f = new Field("Number of Refills Remaining");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-8.1"));
			f.Components = c;
			return f;
		}
		private Field RXD9()
		{
			Field f = new Field("Dispense Notes");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-9.1"));
			f.Components = c;
			return f;
		}
		private Field RXD10()
		{
			Field f = new Field("Dispensing Provider");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "RXD-10.1"));
			c.Add(new Component("Family Name", "RXD-10.2"));
			c.Add(new Component("Given Name", "RXD-10.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "RXD-10.4"));
			c.Add(new Component("Suffix", "RXD-10.5"));
			c.Add(new Component("Prefix", "RXD-10.6"));
			c.Add(new Component("Degree", "RXD-10.7"));
			c.Add(new Component("Source Table", "RXD-10.8"));
			c.Add(new Component("Assigning Authority", "RXD-10.9"));
			c.Add(new Component("Name Type Code", "RXD-10.10"));
			c.Add(new Component("Identifier Check Digit", "RXD-10.11"));
			c.Add(new Component("Check Digit Scheme", "RXD-10.12"));
			c.Add(new Component("Identifier Type Code", "RXD-10.13"));
			c.Add(new Component("Assigning Facility", "RXD-10.14"));
			c.Add(new Component("Name Respresentation Code", "RXD-10.15"));
			c.Add(new Component("Name Context", "RXD-10.16"));
			c.Add(new Component("Name Validity Range", "RXD-10.17"));
			c.Add(new Component("Name Assembly Order", "RXD-10.18"));
			c.Add(new Component("Effective Date", "RXD-10.19"));
			c.Add(new Component("Expiration Date", "RXD-10.20"));
			c.Add(new Component("Professional Suffix", "RXD-10.21"));
			c.Add(new Component("Assigning Jurisdiction", "RXD-10.22"));
			c.Add(new Component("Assigning Agency or Department", "RXD-10.23"));
			f.Components = c;
			return f;
		}
		private Field RXD11()
		{
			Field f = new Field("Substitution Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-11.1"));
			f.Components = c;
			return f;
		}
		private Field RXD12()
		{
			Field f = new Field("Total Daily Dose");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "RXD-12.1"));
			c.Add(new Component("Units", "RXD-12.2"));
			f.Components = c;
			return f;
		}
		private Field RXD13()
		{
			Field f = new Field("Dispense-to Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "RXD-13.1"));
			c.Add(new Component("Room", "RXD-13.2"));
			c.Add(new Component("Bed", "RXD-13.3"));
			c.Add(new Component("Facility", "RXD-13.4"));
			c.Add(new Component("Location Status", "RXD-13.5"));
			c.Add(new Component("Patient Location Type", "RXD-13.6"));
			c.Add(new Component("Building", "RXD-13.7"));
			c.Add(new Component("Floor Number", "RXD-13.8"));
			c.Add(new Component("Street Address", "RXD-13.9"));
			c.Add(new Component("Other Designation", "RXD-13.10"));
			c.Add(new Component("City", "RXD-13.11"));
			c.Add(new Component("State or Province", "RXD-13.12"));
			c.Add(new Component("Zip or Postal Code", "RXD-13.13"));
			c.Add(new Component("Country", "RXD-13.14"));
			c.Add(new Component("Address Type", "RXD-13.15"));
			c.Add(new Component("Other Geographic Designation", "RXD-13.16"));
			f.Components = c;
			return f;
		}
		private Field RXD14()
		{
			Field f = new Field("Needs Human Review");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-14.1"));
			f.Components = c;
			return f;
		}
		private Field RXD15()
		{
			Field f = new Field("Pharmacy/Treatment Supplier's Special Dispensing Instructions");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-15.1"));
			c.Add(new Component("", "RXD-15.2"));
			c.Add(new Component("Name of Coding System", "RXD-15.3"));
			c.Add(new Component("Alternate Identifier", "RXD-15.4"));
			c.Add(new Component("Alternate Text", "RXD-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-15.6"));
			f.Components = c;
			return f;
		}
		private Field RXD16()
		{
			Field f = new Field("Actual Strength");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-16.1"));
			f.Components = c;
			return f;
		}
		private Field RXD17()
		{
			Field f = new Field("Actual Strength Unit");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-17.1"));
			c.Add(new Component("", "RXD-17.2"));
			c.Add(new Component("Name of Coding System", "RXD-17.3"));
			c.Add(new Component("Alternate Identifier", "RXD-17.4"));
			c.Add(new Component("Alternate Text", "RXD-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-17.6"));
			f.Components = c;
			return f;
		}
		private Field RXD18()
		{
			Field f = new Field("Substance Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-18.1"));
			f.Components = c;
			return f;
		}
		private Field RXD19()
		{
			Field f = new Field("Substance Expiration Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXD-19.1"));
			c.Add(new Component("Degree of Precision", "RXD-19.2"));
			f.Components = c;
			return f;
		}
		private Field RXD20()
		{
			Field f = new Field("Substance Manufacturer Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-20.1"));
			c.Add(new Component("", "RXD-20.2"));
			c.Add(new Component("Name of Coding System", "RXD-20.3"));
			c.Add(new Component("Alternate Identifier", "RXD-20.4"));
			c.Add(new Component("Alternate Text", "RXD-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-20.6"));
			f.Components = c;
			return f;
		}
		private Field RXD21()
		{
			Field f = new Field("Indication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-21.1"));
			c.Add(new Component("", "RXD-21.2"));
			c.Add(new Component("Name of Coding System", "RXD-21.3"));
			c.Add(new Component("Alternate Identifier", "RXD-21.4"));
			c.Add(new Component("Alternate Text", "RXD-21.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-21.6"));
			f.Components = c;
			return f;
		}
		private Field RXD22()
		{
			Field f = new Field("Dispense Package Size");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-22.1"));
			f.Components = c;
			return f;
		}
		private Field RXD23()
		{
			Field f = new Field("Dispense Package Size Unit");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-23.1"));
			c.Add(new Component("", "RXD-23.2"));
			c.Add(new Component("Name of Coding System", "RXD-23.3"));
			c.Add(new Component("Alternate Identifier", "RXD-23.4"));
			c.Add(new Component("Alternate Text", "RXD-23.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-23.6"));
			f.Components = c;
			return f;
		}
		private Field RXD24()
		{
			Field f = new Field("Dispense Package Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-24.1"));
			f.Components = c;
			return f;
		}
		private Field RXD25()
		{
			Field f = new Field("Supplementary Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-25.1"));
			c.Add(new Component("", "RXD-25.2"));
			c.Add(new Component("Name of Coding System", "RXD-25.3"));
			c.Add(new Component("Alternate Identifier", "RXD-25.4"));
			c.Add(new Component("Alternate Text", "RXD-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-25.6"));
			f.Components = c;
			return f;
		}
		private Field RXD26()
		{
			Field f = new Field("Initiating Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-26.1"));
			c.Add(new Component("", "RXD-26.2"));
			c.Add(new Component("Name of Coding System", "RXD-26.3"));
			c.Add(new Component("Alternate Identifier", "RXD-26.4"));
			c.Add(new Component("Alternate Text", "RXD-26.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-26.6"));
			f.Components = c;
			return f;
		}
		private Field RXD27()
		{
			Field f = new Field("Packaging/Assembly Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-27.1"));
			c.Add(new Component("", "RXD-27.2"));
			c.Add(new Component("Name of Coding System", "RXD-27.3"));
			c.Add(new Component("Alternate Identifier", "RXD-27.4"));
			c.Add(new Component("Alternate Text", "RXD-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-27.6"));
			f.Components = c;
			return f;
		}
		private Field RXD28()
		{
			Field f = new Field("Actual Drug Strength Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-28.1"));
			f.Components = c;
			return f;
		}
		private Field RXD29()
		{
			Field f = new Field("Actual Drug Strength Volume Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-29.1"));
			c.Add(new Component("", "RXD-29.2"));
			c.Add(new Component("Name of Coding System", "RXD-29.3"));
			c.Add(new Component("Alternate Identifier", "RXD-29.4"));
			c.Add(new Component("Alternate Text", "RXD-29.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-29.6"));
			c.Add(new Component("Coding System Version ID", "RXD-29.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXD-29.8"));
			c.Add(new Component("Original Text", "RXD-29.9"));
			f.Components = c;
			return f;
		}
		private Field RXD30()
		{
			Field f = new Field("Dispense to Pharmacy");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-30.1"));
			c.Add(new Component("", "RXD-30.2"));
			c.Add(new Component("Name of Coding System", "RXD-30.3"));
			c.Add(new Component("Alternate Identifier", "RXD-30.4"));
			c.Add(new Component("Alternate Text", "RXD-30.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-30.6"));
			c.Add(new Component("Coding System Version ID", "RXD-30.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXD-30.8"));
			c.Add(new Component("Original Text", "RXD-30.9"));
			f.Components = c;
			return f;
		}
		private Field RXD31()
		{
			Field f = new Field("Dispense to Pharmacy Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "RXD-31.1"));
			c.Add(new Component("Other Designation", "RXD-31.2"));
			c.Add(new Component("City", "RXD-31.3"));
			c.Add(new Component("State or Province", "RXD-31.4"));
			c.Add(new Component("Zip or Postal Code", "RXD-31.5"));
			c.Add(new Component("Country", "RXD-31.6"));
			c.Add(new Component("Address Type", "RXD-31.7"));
			c.Add(new Component("Other Geographic Designation", "RXD-31.8"));
			c.Add(new Component("Country Parish Code", "RXD-31.9"));
			c.Add(new Component("Census Tract", "RXD-31.10"));
			c.Add(new Component("Address Representation Code", "RXD-31.11"));
			c.Add(new Component("Address Validity Range", "RXD-31.12"));
			c.Add(new Component("Effective Date", "RXD-31.13"));
			c.Add(new Component("Expiration Date", "RXD-31.14"));
			f.Components = c;
			return f;
		}
		private Field RXD32()
		{
			Field f = new Field("Pharmacy Order Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXD-32.1"));
			f.Components = c;
			return f;
		}
		private Field RXD33()
		{
			Field f = new Field("Dispense Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXD-33.1"));
			c.Add(new Component("", "RXD-33.2"));
			c.Add(new Component("Name of Coding System", "RXD-33.3"));
			c.Add(new Component("Alternate Identifier", "RXD-33.4"));
			c.Add(new Component("Alternate Text", "RXD-33.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXD-33.6"));
			c.Add(new Component("Coding System Version ID", "RXD-33.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXD-33.8"));
			c.Add(new Component("Original Text", "RXD-33.9"));
			f.Components = c;
			return f;
		}
	}
}
