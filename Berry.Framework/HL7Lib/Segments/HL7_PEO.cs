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
/// PEO Class: Constructs an HL7 PEO Segment Object
/// </summary>
public class PEO
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PEO()
		{
			Name = "PEO";
			Description = "Product Experience Observation";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PEO1());
			fs.Add(PEO2());
			fs.Add(PEO3());
			fs.Add(PEO4());
			fs.Add(PEO5());
			fs.Add(PEO6());
			fs.Add(PEO7());
			fs.Add(PEO8());
			fs.Add(PEO9());
			fs.Add(PEO10());
			fs.Add(PEO11());
			fs.Add(PEO12());
			fs.Add(PEO13());
			fs.Add(PEO14());
			fs.Add(PEO15());
			fs.Add(PEO16());
			fs.Add(PEO17());
			fs.Add(PEO18());
			fs.Add(PEO19());
			fs.Add(PEO20());
			fs.Add(PEO21());
			fs.Add(PEO22());
			fs.Add(PEO23());
			fs.Add(PEO24());
			fs.Add(PEO25());
			Fields = fs;
		}
		private Field PEO1()
		{
			Field f = new Field("Event Identifiers Used");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PEO-1.1"));
			c.Add(new Component("", "PEO-1.2"));
			c.Add(new Component("Name of Coding System", "PEO-1.3"));
			c.Add(new Component("Alternate Identifier", "PEO-1.4"));
			c.Add(new Component("Alternate Text", "PEO-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "PEO-1.6"));
			f.Components = c;
			return f;
		}
		private Field PEO2()
		{
			Field f = new Field("Event Symptom/Diagnosis Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PEO-2.1"));
			c.Add(new Component("", "PEO-2.2"));
			c.Add(new Component("Name of Coding System", "PEO-2.3"));
			c.Add(new Component("Alternate Identifier", "PEO-2.4"));
			c.Add(new Component("Alternate Text", "PEO-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "PEO-2.6"));
			f.Components = c;
			return f;
		}
		private Field PEO3()
		{
			Field f = new Field("Event Onset Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PEO-3.1"));
			c.Add(new Component("Degree of Precision", "PEO-3.2"));
			f.Components = c;
			return f;
		}
		private Field PEO4()
		{
			Field f = new Field("Event Exacerbation Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PEO-4.1"));
			c.Add(new Component("Degree of Precision", "PEO-4.2"));
			f.Components = c;
			return f;
		}
		private Field PEO5()
		{
			Field f = new Field("Event Improved Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PEO-5.1"));
			c.Add(new Component("Degree of Precision", "PEO-5.2"));
			f.Components = c;
			return f;
		}
		private Field PEO6()
		{
			Field f = new Field("Event Ended Data/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PEO-6.1"));
			c.Add(new Component("Degree of Precision", "PEO-6.2"));
			f.Components = c;
			return f;
		}
		private Field PEO7()
		{
			Field f = new Field("Event Location Occurred Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "PEO-7.1"));
			c.Add(new Component("Other Designation", "PEO-7.2"));
			c.Add(new Component("City", "PEO-7.3"));
			c.Add(new Component("State or Province", "PEO-7.4"));
			c.Add(new Component("Zip or Postal Code", "PEO-7.5"));
			c.Add(new Component("Country", "PEO-7.6"));
			c.Add(new Component("Address Type", "PEO-7.7"));
			c.Add(new Component("Other Geographic Designation", "PEO-7.8"));
			c.Add(new Component("Country Parish Code", "PEO-7.9"));
			c.Add(new Component("Census Tract", "PEO-7.10"));
			c.Add(new Component("Address Representation Code", "PEO-7.11"));
			c.Add(new Component("Address Validity Range", "PEO-7.12"));
			c.Add(new Component("Effective Date", "PEO-7.13"));
			c.Add(new Component("Expiration Date", "PEO-7.14"));
			f.Components = c;
			return f;
		}
		private Field PEO8()
		{
			Field f = new Field("Event Qualification");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-8.1"));
			f.Components = c;
			return f;
		}
		private Field PEO9()
		{
			Field f = new Field("Event Serious");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-9.1"));
			f.Components = c;
			return f;
		}
		private Field PEO10()
		{
			Field f = new Field("Event Expected");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-10.1"));
			f.Components = c;
			return f;
		}
		private Field PEO11()
		{
			Field f = new Field("Event Outcome");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-11.1"));
			f.Components = c;
			return f;
		}
		private Field PEO12()
		{
			Field f = new Field("Patient Outcome");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-12.1"));
			f.Components = c;
			return f;
		}
		private Field PEO13()
		{
			Field f = new Field("Event Description From Others");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-13.1"));
			f.Components = c;
			return f;
		}
		private Field PEO14()
		{
			Field f = new Field("Event From Original Reporter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-14.1"));
			f.Components = c;
			return f;
		}
		private Field PEO15()
		{
			Field f = new Field("Event Description From Patient");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-15.1"));
			f.Components = c;
			return f;
		}
		private Field PEO16()
		{
			Field f = new Field("Event Description From Practitioner");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-16.1"));
			f.Components = c;
			return f;
		}
		private Field PEO17()
		{
			Field f = new Field("Event Description From Autopsy");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-17.1"));
			f.Components = c;
			return f;
		}
		private Field PEO18()
		{
			Field f = new Field("Cause Of Death");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PEO-18.1"));
			c.Add(new Component("", "PEO-18.2"));
			c.Add(new Component("Name of Coding System", "PEO-18.3"));
			c.Add(new Component("Alternate Identifier", "PEO-18.4"));
			c.Add(new Component("Alternate Text", "PEO-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "PEO-18.6"));
			f.Components = c;
			return f;
		}
		private Field PEO19()
		{
			Field f = new Field("Primary Observer Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "PEO-19.1"));
			c.Add(new Component("Given Name", "PEO-19.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PEO-19.3"));
			c.Add(new Component("Suffix", "PEO-19.4"));
			c.Add(new Component("Prefix", "PEO-19.5"));
			c.Add(new Component("Degree", "PEO-19.6"));
			c.Add(new Component("Name Type Code", "PEO-19.7"));
			c.Add(new Component("Name Respresentation Code", "PEO-19.8"));
			c.Add(new Component("Name Context", "PEO-19.9"));
			c.Add(new Component("Name Validity Range", "PEO-19.10"));
			c.Add(new Component("Name Assembly Order", "PEO-19.11"));
			c.Add(new Component("Effective Date", "PEO-19.12"));
			c.Add(new Component("Expiration Date", "PEO-19.13"));
			c.Add(new Component("Professional Suffix", "PEO-19.14"));
			f.Components = c;
			return f;
		}
		private Field PEO20()
		{
			Field f = new Field("Primary Observer Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "PEO-20.1"));
			c.Add(new Component("Other Designation", "PEO-20.2"));
			c.Add(new Component("City", "PEO-20.3"));
			c.Add(new Component("State or Province", "PEO-20.4"));
			c.Add(new Component("Zip or Postal Code", "PEO-20.5"));
			c.Add(new Component("Country", "PEO-20.6"));
			c.Add(new Component("Address Type", "PEO-20.7"));
			c.Add(new Component("Other Geographic Designation", "PEO-20.8"));
			c.Add(new Component("Country Parish Code", "PEO-20.9"));
			c.Add(new Component("Census Tract", "PEO-20.10"));
			c.Add(new Component("Address Representation Code", "PEO-20.11"));
			c.Add(new Component("Address Validity Range", "PEO-20.12"));
			c.Add(new Component("Effective Date", "PEO-20.13"));
			c.Add(new Component("Expiration Date", "PEO-20.14"));
			f.Components = c;
			return f;
		}
		private Field PEO21()
		{
			Field f = new Field("Primary Observer Telephone");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "PEO-21.1"));
			c.Add(new Component("Tele-Communication Use Code", "PEO-21.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "PEO-21.3"));
			c.Add(new Component("Email Address", "PEO-21.4"));
			c.Add(new Component("Country Code", "PEO-21.5"));
			c.Add(new Component("Area City Code", "PEO-21.6"));
			c.Add(new Component("Local Number", "PEO-21.7"));
			c.Add(new Component("Extension", "PEO-21.8"));
			c.Add(new Component("", "PEO-21.9"));
			c.Add(new Component("Extension Prefix", "PEO-21.10"));
			c.Add(new Component("Speed Dial Code", "PEO-21.11"));
			c.Add(new Component("Unformatted Telephone Number", "PEO-21.12"));
			f.Components = c;
			return f;
		}
		private Field PEO22()
		{
			Field f = new Field("Primary Observer's Qualification");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-22.1"));
			f.Components = c;
			return f;
		}
		private Field PEO23()
		{
			Field f = new Field("Confirmation Provided By");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-23.1"));
			f.Components = c;
			return f;
		}
		private Field PEO24()
		{
			Field f = new Field("Primary Observer Aware Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PEO-24.1"));
			c.Add(new Component("Degree of Precision", "PEO-24.2"));
			f.Components = c;
			return f;
		}
		private Field PEO25()
		{
			Field f = new Field("Primary Observer's identity May Be Divulged");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PEO-25.1"));
			f.Components = c;
			return f;
		}
	}
}
