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
/// RXG Class: Constructs an HL7 RXG Segment Object
/// </summary>
public class RXG
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RXG()
		{
			Name = "RXG";
			Description = "Pharmacy/Treatment Give";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RXG1());
			fs.Add(RXG2());
			fs.Add(RXG3());
			fs.Add(RXG4());
			fs.Add(RXG5());
			fs.Add(RXG6());
			fs.Add(RXG7());
			fs.Add(RXG8());
			fs.Add(RXG9());
			fs.Add(RXG10());
			fs.Add(RXG11());
			fs.Add(RXG12());
			fs.Add(RXG13());
			fs.Add(RXG14());
			fs.Add(RXG15());
			fs.Add(RXG16());
			fs.Add(RXG17());
			fs.Add(RXG18());
			fs.Add(RXG19());
			fs.Add(RXG20());
			fs.Add(RXG21());
			fs.Add(RXG22());
			fs.Add(RXG23());
			fs.Add(RXG24());
			fs.Add(RXG25());
			fs.Add(RXG26());
			Fields = fs;
		}
		private Field RXG1()
		{
			Field f = new Field("Give Sub-ID Counter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-1.1"));
			f.Components = c;
			return f;
		}
		private Field RXG2()
		{
			Field f = new Field("Dispense Sub-ID Counter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-2.1"));
			f.Components = c;
			return f;
		}
		private Field RXG3()
		{
			Field f = new Field("Quantity/Timing");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "RXG-3.1"));
			c.Add(new Component("Interval", "RXG-3.2"));
			c.Add(new Component("Duration", "RXG-3.3"));
			c.Add(new Component("Start Date/Time", "RXG-3.4"));
			c.Add(new Component("End Date Time", "RXG-3.5"));
			c.Add(new Component("Priority", "RXG-3.6"));
			c.Add(new Component("Condition", "RXG-3.7"));
			c.Add(new Component("", "RXG-3.8"));
			c.Add(new Component("Conjunction", "RXG-3.9"));
			c.Add(new Component("Order Sequencing", "RXG-3.10"));
			c.Add(new Component("Occurrence Duration", "RXG-3.11"));
			c.Add(new Component("Total Occurrences", "RXG-3.12"));
			f.Components = c;
			return f;
		}
		private Field RXG4()
		{
			Field f = new Field("Give Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-4.1"));
			c.Add(new Component("", "RXG-4.2"));
			c.Add(new Component("Name of Coding System", "RXG-4.3"));
			c.Add(new Component("Alternate Identifier", "RXG-4.4"));
			c.Add(new Component("Alternate Text", "RXG-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-4.6"));
			f.Components = c;
			return f;
		}
		private Field RXG5()
		{
			Field f = new Field("Give Amount - Minimum");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-5.1"));
			f.Components = c;
			return f;
		}
		private Field RXG6()
		{
			Field f = new Field("Give Amount - Maximum");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-6.1"));
			f.Components = c;
			return f;
		}
		private Field RXG7()
		{
			Field f = new Field("Give Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-7.1"));
			c.Add(new Component("", "RXG-7.2"));
			c.Add(new Component("Name of Coding System", "RXG-7.3"));
			c.Add(new Component("Alternate Identifier", "RXG-7.4"));
			c.Add(new Component("Alternate Text", "RXG-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-7.6"));
			f.Components = c;
			return f;
		}
		private Field RXG8()
		{
			Field f = new Field("Give Dosage Form");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-8.1"));
			c.Add(new Component("", "RXG-8.2"));
			c.Add(new Component("Name of Coding System", "RXG-8.3"));
			c.Add(new Component("Alternate Identifier", "RXG-8.4"));
			c.Add(new Component("Alternate Text", "RXG-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-8.6"));
			f.Components = c;
			return f;
		}
		private Field RXG9()
		{
			Field f = new Field("Administration Notes");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-9.1"));
			c.Add(new Component("", "RXG-9.2"));
			c.Add(new Component("Name of Coding System", "RXG-9.3"));
			c.Add(new Component("Alternate Identifier", "RXG-9.4"));
			c.Add(new Component("Alternate Text", "RXG-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-9.6"));
			f.Components = c;
			return f;
		}
		private Field RXG10()
		{
			Field f = new Field("Substitution Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-10.1"));
			f.Components = c;
			return f;
		}
		private Field RXG11()
		{
			Field f = new Field("Dispense-to Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "RXG-11.1"));
			c.Add(new Component("Room", "RXG-11.2"));
			c.Add(new Component("Bed", "RXG-11.3"));
			c.Add(new Component("Facility", "RXG-11.4"));
			c.Add(new Component("Location Status", "RXG-11.5"));
			c.Add(new Component("Patient Location Type", "RXG-11.6"));
			c.Add(new Component("Building", "RXG-11.7"));
			c.Add(new Component("Floor Number", "RXG-11.8"));
			c.Add(new Component("Street Address", "RXG-11.9"));
			c.Add(new Component("Other Designation", "RXG-11.10"));
			c.Add(new Component("City", "RXG-11.11"));
			c.Add(new Component("State or Province", "RXG-11.12"));
			c.Add(new Component("Zip or Postal Code", "RXG-11.13"));
			c.Add(new Component("Country", "RXG-11.14"));
			c.Add(new Component("Address Type", "RXG-11.15"));
			c.Add(new Component("Other Geographic Designation", "RXG-11.16"));
			f.Components = c;
			return f;
		}
		private Field RXG12()
		{
			Field f = new Field("Needs Human Review");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-12.1"));
			f.Components = c;
			return f;
		}
		private Field RXG13()
		{
			Field f = new Field("Pharmacy/Treatment Supplier's Special Administration Instructions");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-13.1"));
			c.Add(new Component("", "RXG-13.2"));
			c.Add(new Component("Name of Coding System", "RXG-13.3"));
			c.Add(new Component("Alternate Identifier", "RXG-13.4"));
			c.Add(new Component("Alternate Text", "RXG-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-13.6"));
			f.Components = c;
			return f;
		}
		private Field RXG14()
		{
			Field f = new Field("Give Per (Time Unit)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-14.1"));
			f.Components = c;
			return f;
		}
		private Field RXG15()
		{
			Field f = new Field("Give Rate Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-15.1"));
			f.Components = c;
			return f;
		}
		private Field RXG16()
		{
			Field f = new Field("Give Rate Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-16.1"));
			c.Add(new Component("", "RXG-16.2"));
			c.Add(new Component("Name of Coding System", "RXG-16.3"));
			c.Add(new Component("Alternate Identifier", "RXG-16.4"));
			c.Add(new Component("Alternate Text", "RXG-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-16.6"));
			f.Components = c;
			return f;
		}
		private Field RXG17()
		{
			Field f = new Field("Give Strength");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-17.1"));
			f.Components = c;
			return f;
		}
		private Field RXG18()
		{
			Field f = new Field("Give Strength Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-18.1"));
			c.Add(new Component("", "RXG-18.2"));
			c.Add(new Component("Name of Coding System", "RXG-18.3"));
			c.Add(new Component("Alternate Identifier", "RXG-18.4"));
			c.Add(new Component("Alternate Text", "RXG-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-18.6"));
			f.Components = c;
			return f;
		}
		private Field RXG19()
		{
			Field f = new Field("Substance Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-19.1"));
			f.Components = c;
			return f;
		}
		private Field RXG20()
		{
			Field f = new Field("Substance Expiration Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RXG-20.1"));
			c.Add(new Component("Degree of Precision", "RXG-20.2"));
			f.Components = c;
			return f;
		}
		private Field RXG21()
		{
			Field f = new Field("Substance Manufacturer Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-21.1"));
			c.Add(new Component("", "RXG-21.2"));
			c.Add(new Component("Name of Coding System", "RXG-21.3"));
			c.Add(new Component("Alternate Identifier", "RXG-21.4"));
			c.Add(new Component("Alternate Text", "RXG-21.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-21.6"));
			f.Components = c;
			return f;
		}
		private Field RXG22()
		{
			Field f = new Field("Indication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-22.1"));
			c.Add(new Component("", "RXG-22.2"));
			c.Add(new Component("Name of Coding System", "RXG-22.3"));
			c.Add(new Component("Alternate Identifier", "RXG-22.4"));
			c.Add(new Component("Alternate Text", "RXG-22.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-22.6"));
			f.Components = c;
			return f;
		}
		private Field RXG23()
		{
			Field f = new Field("Give Drug Strength Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-23.1"));
			f.Components = c;
			return f;
		}
		private Field RXG24()
		{
			Field f = new Field("Give Drug Strength Volume Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-24.1"));
			c.Add(new Component("", "RXG-24.2"));
			c.Add(new Component("Name of Coding System", "RXG-24.3"));
			c.Add(new Component("Alternate Identifier", "RXG-24.4"));
			c.Add(new Component("Alternate Text", "RXG-24.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-24.6"));
			c.Add(new Component("Coding System Version ID", "RXG-24.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXG-24.8"));
			c.Add(new Component("Original Text", "RXG-24.9"));
			f.Components = c;
			return f;
		}
		private Field RXG25()
		{
			Field f = new Field("Give Barcode Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RXG-25.1"));
			c.Add(new Component("", "RXG-25.2"));
			c.Add(new Component("Name of Coding System", "RXG-25.3"));
			c.Add(new Component("Alternate Identifier", "RXG-25.4"));
			c.Add(new Component("Alternate Text", "RXG-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "RXG-25.6"));
			c.Add(new Component("Coding System Version ID", "RXG-25.7"));
			c.Add(new Component("Alternate Coding System Version ID", "RXG-25.8"));
			c.Add(new Component("Original Text", "RXG-25.9"));
			f.Components = c;
			return f;
		}
		private Field RXG26()
		{
			Field f = new Field("Pharmacy Order Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "RXG-26.1"));
			f.Components = c;
			return f;
		}
	}
}
