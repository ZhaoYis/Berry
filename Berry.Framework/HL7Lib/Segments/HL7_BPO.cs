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
/// BPO Class: Constructs an HL7 BPO Segment Object
/// </summary>
public class BPO
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public BPO()
		{
			Name = "BPO";
			Description = "Blood product order";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(BPO1());
			fs.Add(BPO2());
			fs.Add(BPO3());
			fs.Add(BPO4());
			fs.Add(BPO5());
			fs.Add(BPO6());
			fs.Add(BPO7());
			fs.Add(BPO8());
			fs.Add(BPO9());
			fs.Add(BPO10());
			fs.Add(BPO11());
			fs.Add(BPO12());
			fs.Add(BPO13());
			fs.Add(BPO14());
			Fields = fs;
		}
		private Field BPO1()
		{
			Field f = new Field("Set ID _ BPO");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "BPO-1.1"));
			f.Components = c;
			return f;
		}
		private Field BPO2()
		{
			Field f = new Field("BP Universal Service ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPO-2.1"));
			c.Add(new Component("", "BPO-2.2"));
			c.Add(new Component("Name of Coding System", "BPO-2.3"));
			c.Add(new Component("Alternate Identifier", "BPO-2.4"));
			c.Add(new Component("Alternate Text", "BPO-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPO-2.6"));
			c.Add(new Component("Coding System Version ID", "BPO-2.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPO-2.8"));
			c.Add(new Component("Original Text", "BPO-2.9"));
			f.Components = c;
			return f;
		}
		private Field BPO3()
		{
			Field f = new Field("BP Processing Requirements");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPO-3.1"));
			c.Add(new Component("", "BPO-3.2"));
			c.Add(new Component("Name of Coding System", "BPO-3.3"));
			c.Add(new Component("Alternate Identifier", "BPO-3.4"));
			c.Add(new Component("Alternate Text", "BPO-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPO-3.6"));
			c.Add(new Component("Coding System Version ID", "BPO-3.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPO-3.8"));
			c.Add(new Component("Original Text", "BPO-3.9"));
			f.Components = c;
			return f;
		}
		private Field BPO4()
		{
			Field f = new Field("BP Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BPO-4.1"));
			f.Components = c;
			return f;
		}
		private Field BPO5()
		{
			Field f = new Field("BP Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BPO-5.1"));
			f.Components = c;
			return f;
		}
		private Field BPO6()
		{
			Field f = new Field("BP Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPO-6.1"));
			c.Add(new Component("", "BPO-6.2"));
			c.Add(new Component("Name of Coding System", "BPO-6.3"));
			c.Add(new Component("Alternate Identifier", "BPO-6.4"));
			c.Add(new Component("Alternate Text", "BPO-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPO-6.6"));
			f.Components = c;
			return f;
		}
		private Field BPO7()
		{
			Field f = new Field("BP Intended Use Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "BPO-7.1"));
			c.Add(new Component("Degree of Precision", "BPO-7.2"));
			f.Components = c;
			return f;
		}
		private Field BPO8()
		{
			Field f = new Field("BP Intended Dispense From Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "BPO-8.1"));
			c.Add(new Component("Room", "BPO-8.2"));
			c.Add(new Component("Bed", "BPO-8.3"));
			c.Add(new Component("Facility", "BPO-8.4"));
			c.Add(new Component("Location Status", "BPO-8.5"));
			c.Add(new Component("Person Location Type", "BPO-8.6"));
			c.Add(new Component("Building", "BPO-8.7"));
			c.Add(new Component("Floor Number", "BPO-8.8"));
			c.Add(new Component("Location Description", "BPO-8.9"));
			c.Add(new Component("Comprehensive Location Identifier", "BPO-8.10"));
			c.Add(new Component("Assigning Authority for Location", "BPO-8.11"));
			f.Components = c;
			return f;
		}
		private Field BPO9()
		{
			Field f = new Field("BP Intended Dispense From Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "BPO-9.1"));
			c.Add(new Component("Other Designation", "BPO-9.2"));
			c.Add(new Component("City", "BPO-9.3"));
			c.Add(new Component("State or Province", "BPO-9.4"));
			c.Add(new Component("Zip or Postal Code", "BPO-9.5"));
			c.Add(new Component("Country", "BPO-9.6"));
			c.Add(new Component("Address Type", "BPO-9.7"));
			c.Add(new Component("Other Geographic Designation", "BPO-9.8"));
			c.Add(new Component("Country Parish Code", "BPO-9.9"));
			c.Add(new Component("Census Tract", "BPO-9.10"));
			c.Add(new Component("Address Representation Code", "BPO-9.11"));
			c.Add(new Component("Address Validity Range", "BPO-9.12"));
			c.Add(new Component("Effective Date", "BPO-9.13"));
			c.Add(new Component("Expiration Date", "BPO-9.14"));
			f.Components = c;
			return f;
		}
		private Field BPO10()
		{
			Field f = new Field("BP Requested Dispense Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "BPO-10.1"));
			c.Add(new Component("Degree of Precision", "BPO-10.2"));
			f.Components = c;
			return f;
		}
		private Field BPO11()
		{
			Field f = new Field("BP Requested Dispense To Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "BPO-11.1"));
			c.Add(new Component("Room", "BPO-11.2"));
			c.Add(new Component("Bed", "BPO-11.3"));
			c.Add(new Component("Facility", "BPO-11.4"));
			c.Add(new Component("Location Status", "BPO-11.5"));
			c.Add(new Component("Person Location Type", "BPO-11.6"));
			c.Add(new Component("Building", "BPO-11.7"));
			c.Add(new Component("Floor Number", "BPO-11.8"));
			c.Add(new Component("Location Description", "BPO-11.9"));
			c.Add(new Component("Comprehensive Location Identifier", "BPO-11.10"));
			c.Add(new Component("Assigning Authority for Location", "BPO-11.11"));
			f.Components = c;
			return f;
		}
		private Field BPO12()
		{
			Field f = new Field("BP Requested Dispense To Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "BPO-12.1"));
			c.Add(new Component("Other Designation", "BPO-12.2"));
			c.Add(new Component("City", "BPO-12.3"));
			c.Add(new Component("State or Province", "BPO-12.4"));
			c.Add(new Component("Zip or Postal Code", "BPO-12.5"));
			c.Add(new Component("Country", "BPO-12.6"));
			c.Add(new Component("Address Type", "BPO-12.7"));
			c.Add(new Component("Other Geographic Designation", "BPO-12.8"));
			c.Add(new Component("Country Parish Code", "BPO-12.9"));
			c.Add(new Component("Census Tract", "BPO-12.10"));
			c.Add(new Component("Address Representation Code", "BPO-12.11"));
			c.Add(new Component("Address Validity Range", "BPO-12.12"));
			c.Add(new Component("Effective Date", "BPO-12.13"));
			c.Add(new Component("Expiration Date", "BPO-12.14"));
			f.Components = c;
			return f;
		}
		private Field BPO13()
		{
			Field f = new Field("BP Indication for Use");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BPO-13.1"));
			c.Add(new Component("", "BPO-13.2"));
			c.Add(new Component("Name of Coding System", "BPO-13.3"));
			c.Add(new Component("Alternate Identifier", "BPO-13.4"));
			c.Add(new Component("Alternate Text", "BPO-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "BPO-13.6"));
			c.Add(new Component("Coding System Version ID", "BPO-13.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BPO-13.8"));
			c.Add(new Component("Original Text", "BPO-13.9"));
			f.Components = c;
			return f;
		}
		private Field BPO14()
		{
			Field f = new Field("BP Informed Consent Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BPO-14.1"));
			f.Components = c;
			return f;
		}
	}
}
