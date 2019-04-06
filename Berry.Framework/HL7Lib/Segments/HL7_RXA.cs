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
/// RXA Class: Constructs an HL7 RXA Segment Object
/// </summary>
public class RXA
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RXA()
		{
			Name = "RXA";
			Description = "Pharmacy/Treatment Administration";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RXA1());
			fs.Add(RXA2());
			fs.Add(RXA3());
			fs.Add(RXA4());
			fs.Add(RXA5());
			fs.Add(RXA6());
			fs.Add(RXA7());
			fs.Add(RXA8());
			fs.Add(RXA9());
			fs.Add(RXA10());
			fs.Add(RXA11());
			fs.Add(RXA12());
			fs.Add(RXA13());
			fs.Add(RXA14());
			fs.Add(RXA15());
			fs.Add(RXA16());
			fs.Add(RXA17());
			fs.Add(RXA18());
			fs.Add(RXA19());
			fs.Add(RXA20());
			fs.Add(RXA21());
			fs.Add(RXA22());
			fs.Add(RXA23());
			fs.Add(RXA24());
			fs.Add(RXA25());
			fs.Add(RXA26());
			Fields = fs;
		}
		private Field RXA1()
		{
			Field f = new Field("Give Sub-ID Counter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-1.1"));
			f.Components = c;
			return f;
		}
		private Field RXA2()
		{
			Field f = new Field("Administration Sub-ID Counter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-2.1"));
			f.Components = c;
			return f;
		}
		private Field RXA3()
		{
			Field f = new Field("Date/Time Start of Administration");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXA-3.1"));
			c.Add(new Component("Degree of Precision", "RXA-3.2"));
			f.Components = c;
			return f;
		}
		private Field RXA4()
		{
			Field f = new Field("Date/Time End of Administration");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXA-4.1"));
			c.Add(new Component("Degree of Precision", "RXA-4.2"));
			f.Components = c;
			return f;
		}
		private Field RXA5()
		{
			Field f = new Field("Administered Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-5.1"));
			c.Add(new Component("", "RXA-5.2"));
			c.Add(new Component("Name of Coding System", "RXA-5.3"));
			c.Add(new Component("Alternate Identifier", "RXA-5.4"));
			c.Add(new Component("Alternate Text", "RXA-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-5.6"));
			f.Components = c;
			return f;
		}
		private Field RXA6()
		{
			Field f = new Field("Administered Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-6.1"));
			f.Components = c;
			return f;
		}
		private Field RXA7()
		{
			Field f = new Field("Administered Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-7.1"));
			c.Add(new Component("", "RXA-7.2"));
			c.Add(new Component("Name of Coding System", "RXA-7.3"));
			c.Add(new Component("Alternate Identifier", "RXA-7.4"));
			c.Add(new Component("Alternate Text", "RXA-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-7.6"));
			f.Components = c;
			return f;
		}
		private Field RXA8()
		{
			Field f = new Field("Administered Dosage Form");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-8.1"));
			c.Add(new Component("", "RXA-8.2"));
			c.Add(new Component("Name of Coding System", "RXA-8.3"));
			c.Add(new Component("Alternate Identifier", "RXA-8.4"));
			c.Add(new Component("Alternate Text", "RXA-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-8.6"));
			f.Components = c;
			return f;
		}
		private Field RXA9()
		{
			Field f = new Field("Administration Notes");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-9.1"));
			c.Add(new Component("", "RXA-9.2"));
			c.Add(new Component("Name of Coding System", "RXA-9.3"));
			c.Add(new Component("Alternate Identifier", "RXA-9.4"));
			c.Add(new Component("Alternate Text", "RXA-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-9.6"));
			f.Components = c;
			return f;
		}
		private Field RXA10()
		{
			Field f = new Field("Administering Provider");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "RXA-10.1"));
			c.Add(new Component("Family Name", "RXA-10.2"));
			c.Add(new Component("Given Name", "RXA-10.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "RXA-10.4"));
			c.Add(new Component("Suffix", "RXA-10.5"));
			c.Add(new Component("Prefix", "RXA-10.6"));
			c.Add(new Component("Degree", "RXA-10.7"));
			c.Add(new Component("Source Table", "RXA-10.8"));
			c.Add(new Component("Assigning Authority", "RXA-10.9"));
			c.Add(new Component("Name Type Code", "RXA-10.10"));
			c.Add(new Component("Identifier Check Digit", "RXA-10.11"));
			c.Add(new Component("Check Digit Scheme", "RXA-10.12"));
			c.Add(new Component("Identifier Type Code", "RXA-10.13"));
			c.Add(new Component("Assigning Facility", "RXA-10.14"));
			c.Add(new Component("Name Respresentation Code", "RXA-10.15"));
			c.Add(new Component("Name Context", "RXA-10.16"));
			c.Add(new Component("Name Validity Range", "RXA-10.17"));
			c.Add(new Component("Name Assembly Order", "RXA-10.18"));
			c.Add(new Component("Effective Date", "RXA-10.19"));
			c.Add(new Component("Expiration Date", "RXA-10.20"));
			c.Add(new Component("Professional Suffix", "RXA-10.21"));
			c.Add(new Component("Assigning Jurisdiction", "RXA-10.22"));
			c.Add(new Component("Assigning Agency or Department", "RXA-10.23"));
			f.Components = c;
			return f;
		}
		private Field RXA11()
		{
			Field f = new Field("Administered-at Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "RXA-11.1"));
			c.Add(new Component("Room", "RXA-11.2"));
			c.Add(new Component("Bed", "RXA-11.3"));
			c.Add(new Component("Facility", "RXA-11.4"));
			c.Add(new Component("Location Status", "RXA-11.5"));
			c.Add(new Component("Patient Location Type", "RXA-11.6"));
			c.Add(new Component("Building", "RXA-11.7"));
			c.Add(new Component("Floor Number", "RXA-11.8"));
			c.Add(new Component("Street Address", "RXA-11.9"));
			c.Add(new Component("Other Designation", "RXA-11.10"));
			c.Add(new Component("City", "RXA-11.11"));
			c.Add(new Component("State or Province", "RXA-11.12"));
			c.Add(new Component("Zip or Postal Code", "RXA-11.13"));
			c.Add(new Component("Country", "RXA-11.14"));
			c.Add(new Component("Address Type", "RXA-11.15"));
			c.Add(new Component("Other Geographic Designation", "RXA-11.16"));
			f.Components = c;
			return f;
		}
		private Field RXA12()
		{
			Field f = new Field("Administered Per (Time Unit)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-12.1"));
			f.Components = c;
			return f;
		}
		private Field RXA13()
		{
			Field f = new Field("Administered Strength");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-13.1"));
			f.Components = c;
			return f;
		}
		private Field RXA14()
		{
			Field f = new Field("Administered Strength Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-14.1"));
			c.Add(new Component("", "RXA-14.2"));
			c.Add(new Component("Name of Coding System", "RXA-14.3"));
			c.Add(new Component("Alternate Identifier", "RXA-14.4"));
			c.Add(new Component("Alternate Text", "RXA-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-14.6"));
			f.Components = c;
			return f;
		}
		private Field RXA15()
		{
			Field f = new Field("Substance Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-15.1"));
			f.Components = c;
			return f;
		}
		private Field RXA16()
		{
			Field f = new Field("Substance Expiration Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXA-16.1"));
			c.Add(new Component("Degree of Precision", "RXA-16.2"));
			f.Components = c;
			return f;
		}
		private Field RXA17()
		{
			Field f = new Field("Substance Manufacturer Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-17.1"));
			c.Add(new Component("", "RXA-17.2"));
			c.Add(new Component("Name of Coding System", "RXA-17.3"));
			c.Add(new Component("Alternate Identifier", "RXA-17.4"));
			c.Add(new Component("Alternate Text", "RXA-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-17.6"));
			f.Components = c;
			return f;
		}
		private Field RXA18()
		{
			Field f = new Field("Substance/Treatment Refusal Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-18.1"));
			c.Add(new Component("", "RXA-18.2"));
			c.Add(new Component("Name of Coding System", "RXA-18.3"));
			c.Add(new Component("Alternate Identifier", "RXA-18.4"));
			c.Add(new Component("Alternate Text", "RXA-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-18.6"));
			f.Components = c;
			return f;
		}
		private Field RXA19()
		{
			Field f = new Field("Indication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-19.1"));
			c.Add(new Component("", "RXA-19.2"));
			c.Add(new Component("Name of Coding System", "RXA-19.3"));
			c.Add(new Component("Alternate Identifier", "RXA-19.4"));
			c.Add(new Component("Alternate Text", "RXA-19.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-19.6"));
			f.Components = c;
			return f;
		}
		private Field RXA20()
		{
			Field f = new Field("Completion Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-20.1"));
			f.Components = c;
			return f;
		}
		private Field RXA21()
		{
			Field f = new Field("Action Code - RXA");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-21.1"));
			f.Components = c;
			return f;
		}
		private Field RXA22()
		{
			Field f = new Field("System Entry Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXA-22.1"));
			c.Add(new Component("Degree of Precision", "RXA-22.2"));
			f.Components = c;
			return f;
		}
		private Field RXA23()
		{
			Field f = new Field("Administered Drug Strength Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-23.1"));
			f.Components = c;
			return f;
		}
		private Field RXA24()
		{
			Field f = new Field("Administered Drug Strength Volume Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-24.1"));
			c.Add(new Component("", "RXA-24.2"));
			c.Add(new Component("Name of Coding System", "RXA-24.3"));
			c.Add(new Component("Alternate Identifier", "RXA-24.4"));
			c.Add(new Component("Alternate Text", "RXA-24.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-24.6"));
			c.Add(new Component("Coding System Version ID", "RXA-24.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXA-24.8"));
			c.Add(new Component("Original Text", "RXA-24.9"));
			f.Components = c;
			return f;
		}
		private Field RXA25()
		{
			Field f = new Field("Administered Barcode Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXA-25.1"));
			c.Add(new Component("", "RXA-25.2"));
			c.Add(new Component("Name of Coding System", "RXA-25.3"));
			c.Add(new Component("Alternate Identifier", "RXA-25.4"));
			c.Add(new Component("Alternate Text", "RXA-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXA-25.6"));
			c.Add(new Component("Coding System Version ID", "RXA-25.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXA-25.8"));
			c.Add(new Component("Original Text", "RXA-25.9"));
			f.Components = c;
			return f;
		}
		private Field RXA26()
		{
			Field f = new Field("Pharmacy Order Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXA-26.1"));
			f.Components = c;
			return f;
		}
	}
}
