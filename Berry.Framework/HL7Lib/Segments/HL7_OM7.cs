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
/// OM7 Class: Constructs an HL7 OM7 Segment Object
/// </summary>
public class OM7
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OM7()
		{
			Name = "OM7";
			Description = "Additional Basic Attributes";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OM71());
			fs.Add(OM72());
			fs.Add(OM73());
			fs.Add(OM74());
			fs.Add(OM75());
			fs.Add(OM76());
			fs.Add(OM77());
			fs.Add(OM78());
			fs.Add(OM79());
			fs.Add(OM710());
			fs.Add(OM711());
			fs.Add(OM712());
			fs.Add(OM713());
			fs.Add(OM714());
			fs.Add(OM715());
			fs.Add(OM716());
			fs.Add(OM717());
			fs.Add(OM718());
			fs.Add(OM719());
			fs.Add(OM720());
			fs.Add(OM721());
			fs.Add(OM722());
			fs.Add(OM723());
			fs.Add(OM724());
			Fields = fs;
		}
		private Field OM71()
		{
			Field f = new Field("Sequence Number - Test/Observation Master File");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-1.1"));
			f.Components = c;
			return f;
		}
		private Field OM72()
		{
			Field f = new Field("Universal Service Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM7-2.1"));
			c.Add(new Component("", "OM7-2.2"));
			c.Add(new Component("Name of Coding System", "OM7-2.3"));
			c.Add(new Component("Alternate Identifier", "OM7-2.4"));
			c.Add(new Component("Alternate Text", "OM7-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM7-2.6"));
			f.Components = c;
			return f;
		}
		private Field OM73()
		{
			Field f = new Field("Category Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM7-3.1"));
			c.Add(new Component("", "OM7-3.2"));
			c.Add(new Component("Name of Coding System", "OM7-3.3"));
			c.Add(new Component("Alternate Identifier", "OM7-3.4"));
			c.Add(new Component("Alternate Text", "OM7-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM7-3.6"));
			f.Components = c;
			return f;
		}
		private Field OM74()
		{
			Field f = new Field("Category Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-4.1"));
			f.Components = c;
			return f;
		}
		private Field OM75()
		{
			Field f = new Field("Category Synonym");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-5.1"));
			f.Components = c;
			return f;
		}
		private Field OM76()
		{
			Field f = new Field("Effective Test/Service Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OM7-6.1"));
			c.Add(new Component("Degree of Precision", "OM7-6.2"));
			f.Components = c;
			return f;
		}
		private Field OM77()
		{
			Field f = new Field("Effective Test/Service End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OM7-7.1"));
			c.Add(new Component("Degree of Precision", "OM7-7.2"));
			f.Components = c;
			return f;
		}
		private Field OM78()
		{
			Field f = new Field("Test/Service Default Duration Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-8.1"));
			f.Components = c;
			return f;
		}
		private Field OM79()
		{
			Field f = new Field("Test/Service Default Duration Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM7-9.1"));
			c.Add(new Component("", "OM7-9.2"));
			c.Add(new Component("Name of Coding System", "OM7-9.3"));
			c.Add(new Component("Alternate Identifier", "OM7-9.4"));
			c.Add(new Component("Alternate Text", "OM7-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM7-9.6"));
			f.Components = c;
			return f;
		}
		private Field OM710()
		{
			Field f = new Field("Test/Service Default Frequency");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-10.1"));
			f.Components = c;
			return f;
		}
		private Field OM711()
		{
			Field f = new Field("Consent Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-11.1"));
			f.Components = c;
			return f;
		}
		private Field OM712()
		{
			Field f = new Field("Consent Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM7-12.1"));
			c.Add(new Component("", "OM7-12.2"));
			c.Add(new Component("Name of Coding System", "OM7-12.3"));
			c.Add(new Component("Alternate Identifier", "OM7-12.4"));
			c.Add(new Component("Alternate Text", "OM7-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM7-12.6"));
			f.Components = c;
			return f;
		}
		private Field OM713()
		{
			Field f = new Field("Consent Effective Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OM7-13.1"));
			c.Add(new Component("Degree of Precision", "OM7-13.2"));
			f.Components = c;
			return f;
		}
		private Field OM714()
		{
			Field f = new Field("Consent Effective End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OM7-14.1"));
			c.Add(new Component("Degree of Precision", "OM7-14.2"));
			f.Components = c;
			return f;
		}
		private Field OM715()
		{
			Field f = new Field("Consent Interval Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-15.1"));
			f.Components = c;
			return f;
		}
		private Field OM716()
		{
			Field f = new Field("Consent Interval Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM7-16.1"));
			c.Add(new Component("", "OM7-16.2"));
			c.Add(new Component("Name of Coding System", "OM7-16.3"));
			c.Add(new Component("Alternate Identifier", "OM7-16.4"));
			c.Add(new Component("Alternate Text", "OM7-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM7-16.6"));
			f.Components = c;
			return f;
		}
		private Field OM717()
		{
			Field f = new Field("Consent Waiting Period Quantity");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-17.1"));
			f.Components = c;
			return f;
		}
		private Field OM718()
		{
			Field f = new Field("Consent Waiting Period Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM7-18.1"));
			c.Add(new Component("", "OM7-18.2"));
			c.Add(new Component("Name of Coding System", "OM7-18.3"));
			c.Add(new Component("Alternate Identifier", "OM7-18.4"));
			c.Add(new Component("Alternate Text", "OM7-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM7-18.6"));
			f.Components = c;
			return f;
		}
		private Field OM719()
		{
			Field f = new Field("Effective Date/Time of Change");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OM7-19.1"));
			c.Add(new Component("Degree of Precision", "OM7-19.2"));
			f.Components = c;
			return f;
		}
		private Field OM720()
		{
			Field f = new Field("Entered By");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "OM7-20.1"));
			c.Add(new Component("Family Name", "OM7-20.2"));
			c.Add(new Component("Given Name", "OM7-20.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "OM7-20.4"));
			c.Add(new Component("Suffix", "OM7-20.5"));
			c.Add(new Component("Prefix", "OM7-20.6"));
			c.Add(new Component("Degree", "OM7-20.7"));
			c.Add(new Component("Source Table", "OM7-20.8"));
			c.Add(new Component("Assigning Authority", "OM7-20.9"));
			c.Add(new Component("Name Type Code", "OM7-20.10"));
			c.Add(new Component("Identifier Check Digit", "OM7-20.11"));
			c.Add(new Component("Check Digit Scheme", "OM7-20.12"));
			c.Add(new Component("Identifier Type Code", "OM7-20.13"));
			c.Add(new Component("Assigning Facility", "OM7-20.14"));
			c.Add(new Component("Name Respresentation Code", "OM7-20.15"));
			c.Add(new Component("Name Context", "OM7-20.16"));
			c.Add(new Component("Name Validity Range", "OM7-20.17"));
			c.Add(new Component("Name Assembly Order", "OM7-20.18"));
			c.Add(new Component("Effective Date", "OM7-20.19"));
			c.Add(new Component("Expiration Date", "OM7-20.20"));
			c.Add(new Component("Professional Suffix", "OM7-20.21"));
			c.Add(new Component("Assigning Jurisdiction", "OM7-20.22"));
			c.Add(new Component("Assigning Agency or Department", "OM7-20.23"));
			f.Components = c;
			return f;
		}
		private Field OM721()
		{
			Field f = new Field("Orderable-at Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "OM7-21.1"));
			c.Add(new Component("Room", "OM7-21.2"));
			c.Add(new Component("Bed", "OM7-21.3"));
			c.Add(new Component("Facility", "OM7-21.4"));
			c.Add(new Component("Location Status", "OM7-21.5"));
			c.Add(new Component("Person Location Type", "OM7-21.6"));
			c.Add(new Component("Building", "OM7-21.7"));
			c.Add(new Component("Floor Number", "OM7-21.8"));
			c.Add(new Component("Location Description", "OM7-21.9"));
			c.Add(new Component("Comprehensive Location Identifier", "OM7-21.10"));
			c.Add(new Component("Assigning Authority for Location", "OM7-21.11"));
			f.Components = c;
			return f;
		}
		private Field OM722()
		{
			Field f = new Field("Formulary Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-22.1"));
			f.Components = c;
			return f;
		}
		private Field OM723()
		{
			Field f = new Field("Special Order Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM7-23.1"));
			f.Components = c;
			return f;
		}
		private Field OM724()
		{
			Field f = new Field("Primary Key Value - CDM");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM7-24.1"));
			c.Add(new Component("", "OM7-24.2"));
			c.Add(new Component("Name of Coding System", "OM7-24.3"));
			c.Add(new Component("Alternate Identifier", "OM7-24.4"));
			c.Add(new Component("Alternate Text", "OM7-24.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM7-24.6"));
			f.Components = c;
			return f;
		}
	}
}
