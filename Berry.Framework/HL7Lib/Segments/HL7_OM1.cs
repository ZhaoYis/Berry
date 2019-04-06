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
/// OM1 Class: Constructs an HL7 OM1 Segment Object
/// </summary>
public class OM1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OM1()
		{
			Name = "OM1";
			Description = "General Segment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OM11());
			fs.Add(OM12());
			fs.Add(OM13());
			fs.Add(OM14());
			fs.Add(OM15());
			fs.Add(OM16());
			fs.Add(OM17());
			fs.Add(OM18());
			fs.Add(OM19());
			fs.Add(OM110());
			fs.Add(OM111());
			fs.Add(OM112());
			fs.Add(OM113());
			fs.Add(OM114());
			fs.Add(OM115());
			fs.Add(OM116());
			fs.Add(OM117());
			fs.Add(OM118());
			fs.Add(OM119());
			fs.Add(OM120());
			fs.Add(OM121());
			fs.Add(OM122());
			fs.Add(OM123());
			fs.Add(OM124());
			fs.Add(OM125());
			fs.Add(OM126());
			fs.Add(OM127());
			fs.Add(OM128());
			fs.Add(OM129());
			fs.Add(OM130());
			fs.Add(OM131());
			fs.Add(OM132());
			fs.Add(OM133());
			fs.Add(OM134());
			fs.Add(OM135());
			fs.Add(OM136());
			fs.Add(OM137());
			fs.Add(OM138());
			fs.Add(OM139());
			fs.Add(OM140());
			fs.Add(OM141());
			fs.Add(OM142());
			fs.Add(OM143());
			fs.Add(OM144());
			fs.Add(OM145());
			fs.Add(OM146());
			fs.Add(OM147());
			Fields = fs;
		}
		private Field OM11()
		{
			Field f = new Field("Sequence Number - Test/Observation Master File");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-1.1"));
			f.Components = c;
			return f;
		}
		private Field OM12()
		{
			Field f = new Field("Producer's Service/Test/Observation ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-2.1"));
			c.Add(new Component("", "OM1-2.2"));
			c.Add(new Component("Name of Coding System", "OM1-2.3"));
			c.Add(new Component("Alternate Identifier", "OM1-2.4"));
			c.Add(new Component("Alternate Text", "OM1-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-2.6"));
			f.Components = c;
			return f;
		}
		private Field OM13()
		{
			Field f = new Field("Permitted Data Types");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-3.1"));
			f.Components = c;
			return f;
		}
		private Field OM14()
		{
			Field f = new Field("Specimen Required");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-4.1"));
			f.Components = c;
			return f;
		}
		private Field OM15()
		{
			Field f = new Field("Producer ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-5.1"));
			c.Add(new Component("", "OM1-5.2"));
			c.Add(new Component("Name of Coding System", "OM1-5.3"));
			c.Add(new Component("Alternate Identifier", "OM1-5.4"));
			c.Add(new Component("Alternate Text", "OM1-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-5.6"));
			f.Components = c;
			return f;
		}
		private Field OM16()
		{
			Field f = new Field("Observation Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-6.1"));
			f.Components = c;
			return f;
		}
		private Field OM17()
		{
			Field f = new Field("Other Service/Test/Observation IDs for the Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-7.1"));
			c.Add(new Component("", "OM1-7.2"));
			c.Add(new Component("Name of Coding System", "OM1-7.3"));
			c.Add(new Component("Alternate Identifier", "OM1-7.4"));
			c.Add(new Component("Alternate Text", "OM1-7.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-7.6"));
			f.Components = c;
			return f;
		}
		private Field OM18()
		{
			Field f = new Field("Other Names");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-8.1"));
			f.Components = c;
			return f;
		}
		private Field OM19()
		{
			Field f = new Field("Preferred Report Name for the Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-9.1"));
			f.Components = c;
			return f;
		}
		private Field OM110()
		{
			Field f = new Field("Preferred Short Name or Mnemonic for Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-10.1"));
			f.Components = c;
			return f;
		}
		private Field OM111()
		{
			Field f = new Field("Preferred Long Name for the Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-11.1"));
			f.Components = c;
			return f;
		}
		private Field OM112()
		{
			Field f = new Field("Orderability");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-12.1"));
			f.Components = c;
			return f;
		}
		private Field OM113()
		{
			Field f = new Field("Identity of Instrument Used to Perform this Study");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-13.1"));
			c.Add(new Component("", "OM1-13.2"));
			c.Add(new Component("Name of Coding System", "OM1-13.3"));
			c.Add(new Component("Alternate Identifier", "OM1-13.4"));
			c.Add(new Component("Alternate Text", "OM1-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-13.6"));
			f.Components = c;
			return f;
		}
		private Field OM114()
		{
			Field f = new Field("Coded Representation of Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-14.1"));
			c.Add(new Component("", "OM1-14.2"));
			c.Add(new Component("Name of Coding System", "OM1-14.3"));
			c.Add(new Component("Alternate Identifier", "OM1-14.4"));
			c.Add(new Component("Alternate Text", "OM1-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-14.6"));
			f.Components = c;
			return f;
		}
		private Field OM115()
		{
			Field f = new Field("Portable Device Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-15.1"));
			f.Components = c;
			return f;
		}
		private Field OM116()
		{
			Field f = new Field("Observation Producing Department/Section");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-16.1"));
			c.Add(new Component("", "OM1-16.2"));
			c.Add(new Component("Name of Coding System", "OM1-16.3"));
			c.Add(new Component("Alternate Identifier", "OM1-16.4"));
			c.Add(new Component("Alternate Text", "OM1-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-16.6"));
			f.Components = c;
			return f;
		}
		private Field OM117()
		{
			Field f = new Field("Telephone Number of Section");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "OM1-17.1"));
			c.Add(new Component("Tele-Communication Use Code", "OM1-17.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "OM1-17.3"));
			c.Add(new Component("Email Address", "OM1-17.4"));
			c.Add(new Component("Country Code", "OM1-17.5"));
			c.Add(new Component("Area City Code", "OM1-17.6"));
			c.Add(new Component("Local Number", "OM1-17.7"));
			c.Add(new Component("Extension", "OM1-17.8"));
			c.Add(new Component("", "OM1-17.9"));
			c.Add(new Component("Extension Prefix", "OM1-17.10"));
			c.Add(new Component("Speed Dial Code", "OM1-17.11"));
			c.Add(new Component("Unformatted Telephone Number", "OM1-17.12"));
			f.Components = c;
			return f;
		}
		private Field OM118()
		{
			Field f = new Field("Nature of Service/Test/Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-18.1"));
			f.Components = c;
			return f;
		}
		private Field OM119()
		{
			Field f = new Field("Report Subheader");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-19.1"));
			c.Add(new Component("", "OM1-19.2"));
			c.Add(new Component("Name of Coding System", "OM1-19.3"));
			c.Add(new Component("Alternate Identifier", "OM1-19.4"));
			c.Add(new Component("Alternate Text", "OM1-19.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-19.6"));
			f.Components = c;
			return f;
		}
		private Field OM120()
		{
			Field f = new Field("Report Display Order");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-20.1"));
			f.Components = c;
			return f;
		}
		private Field OM121()
		{
			Field f = new Field("Date/Time Stamp for any change in Definition for the Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OM1-21.1"));
			c.Add(new Component("Degree of Precision", "OM1-21.2"));
			f.Components = c;
			return f;
		}
		private Field OM122()
		{
			Field f = new Field("Effective Date/Time of Change");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OM1-22.1"));
			c.Add(new Component("Degree of Precision", "OM1-22.2"));
			f.Components = c;
			return f;
		}
		private Field OM123()
		{
			Field f = new Field("Typical Turn-Around Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-23.1"));
			f.Components = c;
			return f;
		}
		private Field OM124()
		{
			Field f = new Field("Processing Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-24.1"));
			f.Components = c;
			return f;
		}
		private Field OM125()
		{
			Field f = new Field("Processing Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-25.1"));
			f.Components = c;
			return f;
		}
		private Field OM126()
		{
			Field f = new Field("Reporting Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-26.1"));
			f.Components = c;
			return f;
		}
		private Field OM127()
		{
			Field f = new Field("Outside Site(s) Where Observation may be Performed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-27.1"));
			c.Add(new Component("", "OM1-27.2"));
			c.Add(new Component("Name of Coding System", "OM1-27.3"));
			c.Add(new Component("Alternate Identifier", "OM1-27.4"));
			c.Add(new Component("Alternate Text", "OM1-27.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-27.6"));
			f.Components = c;
			return f;
		}
		private Field OM128()
		{
			Field f = new Field("Address of Outside Site(s)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "OM1-28.1"));
			c.Add(new Component("Other Designation", "OM1-28.2"));
			c.Add(new Component("City", "OM1-28.3"));
			c.Add(new Component("State or Province", "OM1-28.4"));
			c.Add(new Component("Zip or Postal Code", "OM1-28.5"));
			c.Add(new Component("Country", "OM1-28.6"));
			c.Add(new Component("Address Type", "OM1-28.7"));
			c.Add(new Component("Other Geographic Designation", "OM1-28.8"));
			c.Add(new Component("Country Parish Code", "OM1-28.9"));
			c.Add(new Component("Census Tract", "OM1-28.10"));
			c.Add(new Component("Address Representation Code", "OM1-28.11"));
			c.Add(new Component("Address Validity Range", "OM1-28.12"));
			c.Add(new Component("Effective Date", "OM1-28.13"));
			c.Add(new Component("Expiration Date", "OM1-28.14"));
			f.Components = c;
			return f;
		}
		private Field OM129()
		{
			Field f = new Field("Phone Number of Outside Site");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "OM1-29.1"));
			c.Add(new Component("Tele-Communication Use Code", "OM1-29.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "OM1-29.3"));
			c.Add(new Component("Email Address", "OM1-29.4"));
			c.Add(new Component("Country Code", "OM1-29.5"));
			c.Add(new Component("Area City Code", "OM1-29.6"));
			c.Add(new Component("Local Number", "OM1-29.7"));
			c.Add(new Component("Extension", "OM1-29.8"));
			c.Add(new Component("", "OM1-29.9"));
			c.Add(new Component("Extension Prefix", "OM1-29.10"));
			c.Add(new Component("Speed Dial Code", "OM1-29.11"));
			c.Add(new Component("Unformatted Telephone Number", "OM1-29.12"));
			f.Components = c;
			return f;
		}
		private Field OM130()
		{
			Field f = new Field("Confidentiality Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-30.1"));
			c.Add(new Component("", "OM1-30.2"));
			c.Add(new Component("Name of Coding System", "OM1-30.3"));
			c.Add(new Component("Alternate Identifier", "OM1-30.4"));
			c.Add(new Component("Alternate Text", "OM1-30.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-30.6"));
			c.Add(new Component("Coding System Version ID", "OM1-30.7"));
			c.Add(new Component("Alternate Coding System Version ID", "OM1-30.8"));
			c.Add(new Component("Original Text", "OM1-30.9"));
			f.Components = c;
			return f;
		}
		private Field OM131()
		{
			Field f = new Field("Observations Required to Interpret the Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-31.1"));
			c.Add(new Component("", "OM1-31.2"));
			c.Add(new Component("Name of Coding System", "OM1-31.3"));
			c.Add(new Component("Alternate Identifier", "OM1-31.4"));
			c.Add(new Component("Alternate Text", "OM1-31.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-31.6"));
			f.Components = c;
			return f;
		}
		private Field OM132()
		{
			Field f = new Field("Interpretation of Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-32.1"));
			f.Components = c;
			return f;
		}
		private Field OM133()
		{
			Field f = new Field("Contraindications to Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-33.1"));
			c.Add(new Component("", "OM1-33.2"));
			c.Add(new Component("Name of Coding System", "OM1-33.3"));
			c.Add(new Component("Alternate Identifier", "OM1-33.4"));
			c.Add(new Component("Alternate Text", "OM1-33.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-33.6"));
			f.Components = c;
			return f;
		}
		private Field OM134()
		{
			Field f = new Field("Reflex Tests/Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-34.1"));
			c.Add(new Component("", "OM1-34.2"));
			c.Add(new Component("Name of Coding System", "OM1-34.3"));
			c.Add(new Component("Alternate Identifier", "OM1-34.4"));
			c.Add(new Component("Alternate Text", "OM1-34.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-34.6"));
			f.Components = c;
			return f;
		}
		private Field OM135()
		{
			Field f = new Field("Rules that Trigger Reflex Testing");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-35.1"));
			f.Components = c;
			return f;
		}
		private Field OM136()
		{
			Field f = new Field("Fixed Canned Message");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-36.1"));
			c.Add(new Component("", "OM1-36.2"));
			c.Add(new Component("Name of Coding System", "OM1-36.3"));
			c.Add(new Component("Alternate Identifier", "OM1-36.4"));
			c.Add(new Component("Alternate Text", "OM1-36.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-36.6"));
			f.Components = c;
			return f;
		}
		private Field OM137()
		{
			Field f = new Field("Patient Preparation");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-37.1"));
			f.Components = c;
			return f;
		}
		private Field OM138()
		{
			Field f = new Field("Procedure Medication");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-38.1"));
			c.Add(new Component("", "OM1-38.2"));
			c.Add(new Component("Name of Coding System", "OM1-38.3"));
			c.Add(new Component("Alternate Identifier", "OM1-38.4"));
			c.Add(new Component("Alternate Text", "OM1-38.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-38.6"));
			f.Components = c;
			return f;
		}
		private Field OM139()
		{
			Field f = new Field("Factors that may Affect the Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-39.1"));
			f.Components = c;
			return f;
		}
		private Field OM140()
		{
			Field f = new Field("Service/Test/Observation Performance Schedule");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-40.1"));
			f.Components = c;
			return f;
		}
		private Field OM141()
		{
			Field f = new Field("Description of Test Methods");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-41.1"));
			f.Components = c;
			return f;
		}
		private Field OM142()
		{
			Field f = new Field("Kind of Quantity Observed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-42.1"));
			c.Add(new Component("", "OM1-42.2"));
			c.Add(new Component("Name of Coding System", "OM1-42.3"));
			c.Add(new Component("Alternate Identifier", "OM1-42.4"));
			c.Add(new Component("Alternate Text", "OM1-42.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-42.6"));
			f.Components = c;
			return f;
		}
		private Field OM143()
		{
			Field f = new Field("Point Versus Interval");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-43.1"));
			c.Add(new Component("", "OM1-43.2"));
			c.Add(new Component("Name of Coding System", "OM1-43.3"));
			c.Add(new Component("Alternate Identifier", "OM1-43.4"));
			c.Add(new Component("Alternate Text", "OM1-43.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-43.6"));
			f.Components = c;
			return f;
		}
		private Field OM144()
		{
			Field f = new Field("Challenge Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OM1-44.1"));
			f.Components = c;
			return f;
		}
		private Field OM145()
		{
			Field f = new Field("Relationship Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-45.1"));
			c.Add(new Component("", "OM1-45.2"));
			c.Add(new Component("Name of Coding System", "OM1-45.3"));
			c.Add(new Component("Alternate Identifier", "OM1-45.4"));
			c.Add(new Component("Alternate Text", "OM1-45.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-45.6"));
			f.Components = c;
			return f;
		}
		private Field OM146()
		{
			Field f = new Field("Target Anatomic Site Of Test");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-46.1"));
			c.Add(new Component("", "OM1-46.2"));
			c.Add(new Component("Name of Coding System", "OM1-46.3"));
			c.Add(new Component("Alternate Identifier", "OM1-46.4"));
			c.Add(new Component("Alternate Text", "OM1-46.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-46.6"));
			f.Components = c;
			return f;
		}
		private Field OM147()
		{
			Field f = new Field("Modality Of Imaging Measurement");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OM1-47.1"));
			c.Add(new Component("", "OM1-47.2"));
			c.Add(new Component("Name of Coding System", "OM1-47.3"));
			c.Add(new Component("Alternate Identifier", "OM1-47.4"));
			c.Add(new Component("Alternate Text", "OM1-47.5"));
			c.Add(new Component("Name of Alternate Coding System", "OM1-47.6"));
			f.Components = c;
			return f;
		}
	}
}
