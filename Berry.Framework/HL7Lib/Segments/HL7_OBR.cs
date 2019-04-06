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
/// OBR Class: Constructs an HL7 OBR Segment Object
/// </summary>
public class OBR
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OBR()
		{
			Name = "OBR";
			Description = "Observation Request";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OBR1());
			fs.Add(OBR2());
			fs.Add(OBR3());
			fs.Add(OBR4());
			fs.Add(OBR5());
			fs.Add(OBR6());
			fs.Add(OBR7());
			fs.Add(OBR8());
			fs.Add(OBR9());
			fs.Add(OBR10());
			fs.Add(OBR11());
			fs.Add(OBR12());
			fs.Add(OBR13());
			fs.Add(OBR14());
			fs.Add(OBR15());
			fs.Add(OBR16());
			fs.Add(OBR17());
			fs.Add(OBR18());
			fs.Add(OBR19());
			fs.Add(OBR20());
			fs.Add(OBR21());
			fs.Add(OBR22());
			fs.Add(OBR23());
			fs.Add(OBR24());
			fs.Add(OBR25());
			fs.Add(OBR26());
			fs.Add(OBR27());
			fs.Add(OBR28());
			fs.Add(OBR29());
			fs.Add(OBR30());
			fs.Add(OBR31());
			fs.Add(OBR32());
			fs.Add(OBR33());
			fs.Add(OBR34());
			fs.Add(OBR35());
			fs.Add(OBR36());
			fs.Add(OBR37());
			fs.Add(OBR38());
			fs.Add(OBR39());
			fs.Add(OBR40());
			fs.Add(OBR41());
			fs.Add(OBR42());
			fs.Add(OBR43());
			fs.Add(OBR44());
			fs.Add(OBR45());
			fs.Add(OBR46());
			fs.Add(OBR47());
			fs.Add(OBR48());
			fs.Add(OBR49());
			Fields = fs;
		}
		private Field OBR1()
		{
			Field f = new Field("Set ID - OBR");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "OBR-1.1"));
			f.Components = c;
			return f;
		}
		private Field OBR2()
		{
			Field f = new Field("Placer Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "OBR-2.1"));
			c.Add(new Component("Namespace ID", "OBR-2.2"));
			c.Add(new Component("Universal ID", "OBR-2.3"));
			c.Add(new Component("Universal ID Type", "OBR-2.4"));
			f.Components = c;
			return f;
		}
		private Field OBR3()
		{
			Field f = new Field("Filler Order Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "OBR-3.1"));
			c.Add(new Component("Namespace ID", "OBR-3.2"));
			c.Add(new Component("Universal ID", "OBR-3.3"));
			c.Add(new Component("Universal ID Type", "OBR-3.4"));
			f.Components = c;
			return f;
		}
		private Field OBR4()
		{
			Field f = new Field("Universal Service Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-4.1"));
			c.Add(new Component("", "OBR-4.2"));
			c.Add(new Component("Name of Coding System", "OBR-4.3"));
			c.Add(new Component("Alternate Identifier", "OBR-4.4"));
			c.Add(new Component("Alternate Text", "OBR-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-4.6"));
			f.Components = c;
			return f;
		}
		private Field OBR5()
		{
			Field f = new Field("Priority _ OBR");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-5.1"));
			f.Components = c;
			return f;
		}
		private Field OBR6()
		{
			Field f = new Field("Requested Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBR-6.1"));
			c.Add(new Component("Degree of Precision", "OBR-6.2"));
			f.Components = c;
			return f;
		}
		private Field OBR7()
		{
			Field f = new Field("Observation Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBR-7.1"));
			c.Add(new Component("Degree of Precision", "OBR-7.2"));
			f.Components = c;
			return f;
		}
		private Field OBR8()
		{
			Field f = new Field("Observation End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBR-8.1"));
			c.Add(new Component("Degree of Precision", "OBR-8.2"));
			f.Components = c;
			return f;
		}
		private Field OBR9()
		{
			Field f = new Field("Collection Volume");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "OBR-9.1"));
			c.Add(new Component("Units", "OBR-9.2"));
			f.Components = c;
			return f;
		}
		private Field OBR10()
		{
			Field f = new Field("Collector Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "OBR-10.1"));
			c.Add(new Component("Family Name", "OBR-10.2"));
			c.Add(new Component("Given Name", "OBR-10.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "OBR-10.4"));
			c.Add(new Component("Suffix", "OBR-10.5"));
			c.Add(new Component("Prefix", "OBR-10.6"));
			c.Add(new Component("Degree", "OBR-10.7"));
			c.Add(new Component("Source Table", "OBR-10.8"));
			c.Add(new Component("Assigning Authority", "OBR-10.9"));
			c.Add(new Component("Name Type Code", "OBR-10.10"));
			c.Add(new Component("Identifier Check Digit", "OBR-10.11"));
			c.Add(new Component("Check Digit Scheme", "OBR-10.12"));
			c.Add(new Component("Identifier Type Code", "OBR-10.13"));
			c.Add(new Component("Assigning Facility", "OBR-10.14"));
			c.Add(new Component("Name Respresentation Code", "OBR-10.15"));
			c.Add(new Component("Name Context", "OBR-10.16"));
			c.Add(new Component("Name Validity Range", "OBR-10.17"));
			c.Add(new Component("Name Assembly Order", "OBR-10.18"));
			c.Add(new Component("Effective Date", "OBR-10.19"));
			c.Add(new Component("Expiration Date", "OBR-10.20"));
			c.Add(new Component("Professional Suffix", "OBR-10.21"));
			c.Add(new Component("Assigning Jurisdiction", "OBR-10.22"));
			c.Add(new Component("Assigning Agency or Department", "OBR-10.23"));
			f.Components = c;
			return f;
		}
		private Field OBR11()
		{
			Field f = new Field("Specimen Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-11.1"));
			f.Components = c;
			return f;
		}
		private Field OBR12()
		{
			Field f = new Field("Danger Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-12.1"));
			c.Add(new Component("", "OBR-12.2"));
			c.Add(new Component("Name of Coding System", "OBR-12.3"));
			c.Add(new Component("Alternate Identifier", "OBR-12.4"));
			c.Add(new Component("Alternate Text", "OBR-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-12.6"));
			f.Components = c;
			return f;
		}
		private Field OBR13()
		{
			Field f = new Field("Relevant Clinical Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-13.1"));
			f.Components = c;
			return f;
		}
		private Field OBR14()
		{
			Field f = new Field("Specimen Received Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBR-14.1"));
			c.Add(new Component("Degree of Precision", "OBR-14.2"));
			f.Components = c;
			return f;
		}
		private Field OBR15()
		{
			Field f = new Field("Specimen Source");
			List<Component> c = new List<Component>();
			c.Add(new Component("Specimen Source Name or Code", "OBR-15.1"));
			c.Add(new Component("Additives", "OBR-15.2"));
			c.Add(new Component("Specimen Collection Method", "OBR-15.3"));
			c.Add(new Component("Body Site", "OBR-15.4"));
			c.Add(new Component("Site Modifier", "OBR-15.5"));
			c.Add(new Component("Collection Method Modifier Code", "OBR-15.6"));
			c.Add(new Component("Specimen Role", "OBR-15.7"));
			f.Components = c;
			return f;
		}
		private Field OBR16()
		{
			Field f = new Field("Ordering Provider");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "OBR-16.1"));
			c.Add(new Component("Family Name", "OBR-16.2"));
			c.Add(new Component("Given Name", "OBR-16.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "OBR-16.4"));
			c.Add(new Component("Suffix", "OBR-16.5"));
			c.Add(new Component("Prefix", "OBR-16.6"));
			c.Add(new Component("Degree", "OBR-16.7"));
			c.Add(new Component("Source Table", "OBR-16.8"));
			c.Add(new Component("Assigning Authority", "OBR-16.9"));
			c.Add(new Component("Name Type Code", "OBR-16.10"));
			c.Add(new Component("Identifier Check Digit", "OBR-16.11"));
			c.Add(new Component("Check Digit Scheme", "OBR-16.12"));
			c.Add(new Component("Identifier Type Code", "OBR-16.13"));
			c.Add(new Component("Assigning Facility", "OBR-16.14"));
			c.Add(new Component("Name Respresentation Code", "OBR-16.15"));
			c.Add(new Component("Name Context", "OBR-16.16"));
			c.Add(new Component("Name Validity Range", "OBR-16.17"));
			c.Add(new Component("Name Assembly Order", "OBR-16.18"));
			c.Add(new Component("Effective Date", "OBR-16.19"));
			c.Add(new Component("Expiration Date", "OBR-16.20"));
			c.Add(new Component("Professional Suffix", "OBR-16.21"));
			c.Add(new Component("Assigning Jurisdiction", "OBR-16.22"));
			c.Add(new Component("Assigning Agency or Department", "OBR-16.23"));
			f.Components = c;
			return f;
		}
		private Field OBR17()
		{
			Field f = new Field("Order Callback Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "OBR-17.1"));
			c.Add(new Component("Tele-Communication Use Code", "OBR-17.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "OBR-17.3"));
			c.Add(new Component("Email Address", "OBR-17.4"));
			c.Add(new Component("Country Code", "OBR-17.5"));
			c.Add(new Component("Area City Code", "OBR-17.6"));
			c.Add(new Component("Local Number", "OBR-17.7"));
			c.Add(new Component("Extension", "OBR-17.8"));
			c.Add(new Component("", "OBR-17.9"));
			c.Add(new Component("Extension Prefix", "OBR-17.10"));
			c.Add(new Component("Speed Dial Code", "OBR-17.11"));
			c.Add(new Component("Unformatted Telephone Number", "OBR-17.12"));
			f.Components = c;
			return f;
		}
		private Field OBR18()
		{
			Field f = new Field("Placer Field 1");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-18.1"));
			f.Components = c;
			return f;
		}
		private Field OBR19()
		{
			Field f = new Field("Placer Field 2");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-19.1"));
			f.Components = c;
			return f;
		}
		private Field OBR20()
		{
			Field f = new Field("Filler Field 1");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-20.1"));
			f.Components = c;
			return f;
		}
		private Field OBR21()
		{
			Field f = new Field("Filler Field 2");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-21.1"));
			f.Components = c;
			return f;
		}
		private Field OBR22()
		{
			Field f = new Field("Results Rpt/Status Chng - Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBR-22.1"));
			c.Add(new Component("Degree of Precision", "OBR-22.2"));
			f.Components = c;
			return f;
		}
		private Field OBR23()
		{
			Field f = new Field("Charge to Practice");
			List<Component> c = new List<Component>();
			c.Add(new Component("Monetary Amount", "OBR-23.1"));
			c.Add(new Component("Charge Code", "OBR-23.2"));
			f.Components = c;
			return f;
		}
		private Field OBR24()
		{
			Field f = new Field("Diagnostic Serv Sect ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-24.1"));
			f.Components = c;
			return f;
		}
		private Field OBR25()
		{
			Field f = new Field("Result Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-25.1"));
			f.Components = c;
			return f;
		}
		private Field OBR26()
		{
			Field f = new Field("Parent Result");
			List<Component> c = new List<Component>();
			c.Add(new Component("Parent Observation Identifier", "OBR-26.1"));
			c.Add(new Component("Parent Observation Sub-Identifier", "OBR-26.2"));
			c.Add(new Component("Parent Observation Value Descriptor", "OBR-26.3"));
			f.Components = c;
			return f;
		}
		private Field OBR27()
		{
			Field f = new Field("Quantity/Timing");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "OBR-27.1"));
			c.Add(new Component("Interval", "OBR-27.2"));
			c.Add(new Component("Duration", "OBR-27.3"));
			c.Add(new Component("Start Date/Time", "OBR-27.4"));
			c.Add(new Component("End Date Time", "OBR-27.5"));
			c.Add(new Component("Priority", "OBR-27.6"));
			c.Add(new Component("Condition", "OBR-27.7"));
			c.Add(new Component("", "OBR-27.8"));
			c.Add(new Component("Conjunction", "OBR-27.9"));
			c.Add(new Component("Order Sequencing", "OBR-27.10"));
			c.Add(new Component("Occurrence Duration", "OBR-27.11"));
			c.Add(new Component("Total Occurrences", "OBR-27.12"));
			f.Components = c;
			return f;
		}
		private Field OBR28()
		{
			Field f = new Field("Result Copies To");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "OBR-28.1"));
			c.Add(new Component("Family Name", "OBR-28.2"));
			c.Add(new Component("Given Name", "OBR-28.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "OBR-28.4"));
			c.Add(new Component("Suffix", "OBR-28.5"));
			c.Add(new Component("Prefix", "OBR-28.6"));
			c.Add(new Component("Degree", "OBR-28.7"));
			c.Add(new Component("Source Table", "OBR-28.8"));
			c.Add(new Component("Assigning Authority", "OBR-28.9"));
			c.Add(new Component("Name Type Code", "OBR-28.10"));
			c.Add(new Component("Identifier Check Digit", "OBR-28.11"));
			c.Add(new Component("Check Digit Scheme", "OBR-28.12"));
			c.Add(new Component("Identifier Type Code", "OBR-28.13"));
			c.Add(new Component("Assigning Facility", "OBR-28.14"));
			c.Add(new Component("Name Respresentation Code", "OBR-28.15"));
			c.Add(new Component("Name Context", "OBR-28.16"));
			c.Add(new Component("Name Validity Range", "OBR-28.17"));
			c.Add(new Component("Name Assembly Order", "OBR-28.18"));
			c.Add(new Component("Effective Date", "OBR-28.19"));
			c.Add(new Component("Expiration Date", "OBR-28.20"));
			c.Add(new Component("Professional Suffix", "OBR-28.21"));
			c.Add(new Component("Assigning Jurisdiction", "OBR-28.22"));
			c.Add(new Component("Assigning Agency or Department", "OBR-28.23"));
			f.Components = c;
			return f;
		}
		private Field OBR29()
		{
			Field f = new Field("Parent");
			List<Component> c = new List<Component>();
			c.Add(new Component("Placer Assigned Identifier", "OBR-29.1"));
			c.Add(new Component("Filler Assigned Identifier", "OBR-29.2"));
			f.Components = c;
			return f;
		}
		private Field OBR30()
		{
			Field f = new Field("Transportation Mode");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-30.1"));
			f.Components = c;
			return f;
		}
		private Field OBR31()
		{
			Field f = new Field("Reason for Study");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-31.1"));
			c.Add(new Component("", "OBR-31.2"));
			c.Add(new Component("Name of Coding System", "OBR-31.3"));
			c.Add(new Component("Alternate Identifier", "OBR-31.4"));
			c.Add(new Component("Alternate Text", "OBR-31.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-31.6"));
			f.Components = c;
			return f;
		}
		private Field OBR32()
		{
			Field f = new Field("Principal Result Interpreter");
			List<Component> c = new List<Component>();
			c.Add(new Component("Name", "OBR-32.1"));
			c.Add(new Component("Start Date/Time", "OBR-32.2"));
			c.Add(new Component("End Date Time", "OBR-32.3"));
			c.Add(new Component("Point of Care", "OBR-32.4"));
			c.Add(new Component("Room", "OBR-32.5"));
			c.Add(new Component("Bed", "OBR-32.6"));
			c.Add(new Component("Facility", "OBR-32.7"));
			c.Add(new Component("Location Status", "OBR-32.8"));
			c.Add(new Component("Patient Location Type", "OBR-32.9"));
			c.Add(new Component("Building", "OBR-32.10"));
			c.Add(new Component("Floor Number", "OBR-32.11"));
			f.Components = c;
			return f;
		}
		private Field OBR33()
		{
			Field f = new Field("Assistant Result Interpreter");
			List<Component> c = new List<Component>();
			c.Add(new Component("Name", "OBR-33.1"));
			c.Add(new Component("Start Date/Time", "OBR-33.2"));
			c.Add(new Component("End Date Time", "OBR-33.3"));
			c.Add(new Component("Point of Care", "OBR-33.4"));
			c.Add(new Component("Room", "OBR-33.5"));
			c.Add(new Component("Bed", "OBR-33.6"));
			c.Add(new Component("Facility", "OBR-33.7"));
			c.Add(new Component("Location Status", "OBR-33.8"));
			c.Add(new Component("Patient Location Type", "OBR-33.9"));
			c.Add(new Component("Building", "OBR-33.10"));
			c.Add(new Component("Floor Number", "OBR-33.11"));
			f.Components = c;
			return f;
		}
		private Field OBR34()
		{
			Field f = new Field("Technician");
			List<Component> c = new List<Component>();
			c.Add(new Component("Name", "OBR-34.1"));
			c.Add(new Component("Start Date/Time", "OBR-34.2"));
			c.Add(new Component("End Date Time", "OBR-34.3"));
			c.Add(new Component("Point of Care", "OBR-34.4"));
			c.Add(new Component("Room", "OBR-34.5"));
			c.Add(new Component("Bed", "OBR-34.6"));
			c.Add(new Component("Facility", "OBR-34.7"));
			c.Add(new Component("Location Status", "OBR-34.8"));
			c.Add(new Component("Patient Location Type", "OBR-34.9"));
			c.Add(new Component("Building", "OBR-34.10"));
			c.Add(new Component("Floor Number", "OBR-34.11"));
			f.Components = c;
			return f;
		}
		private Field OBR35()
		{
			Field f = new Field("Transcriptionist");
			List<Component> c = new List<Component>();
			c.Add(new Component("Name", "OBR-35.1"));
			c.Add(new Component("Start Date/Time", "OBR-35.2"));
			c.Add(new Component("End Date Time", "OBR-35.3"));
			c.Add(new Component("Point of Care", "OBR-35.4"));
			c.Add(new Component("Room", "OBR-35.5"));
			c.Add(new Component("Bed", "OBR-35.6"));
			c.Add(new Component("Facility", "OBR-35.7"));
			c.Add(new Component("Location Status", "OBR-35.8"));
			c.Add(new Component("Patient Location Type", "OBR-35.9"));
			c.Add(new Component("Building", "OBR-35.10"));
			c.Add(new Component("Floor Number", "OBR-35.11"));
			f.Components = c;
			return f;
		}
		private Field OBR36()
		{
			Field f = new Field("Scheduled Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBR-36.1"));
			c.Add(new Component("Degree of Precision", "OBR-36.2"));
			f.Components = c;
			return f;
		}
		private Field OBR37()
		{
			Field f = new Field("Number of Sample Containers *");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-37.1"));
			f.Components = c;
			return f;
		}
		private Field OBR38()
		{
			Field f = new Field("Transport Logistics of Collected Sample");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-38.1"));
			c.Add(new Component("", "OBR-38.2"));
			c.Add(new Component("Name of Coding System", "OBR-38.3"));
			c.Add(new Component("Alternate Identifier", "OBR-38.4"));
			c.Add(new Component("Alternate Text", "OBR-38.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-38.6"));
			f.Components = c;
			return f;
		}
		private Field OBR39()
		{
			Field f = new Field("Collector's Comment *");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-39.1"));
			c.Add(new Component("", "OBR-39.2"));
			c.Add(new Component("Name of Coding System", "OBR-39.3"));
			c.Add(new Component("Alternate Identifier", "OBR-39.4"));
			c.Add(new Component("Alternate Text", "OBR-39.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-39.6"));
			f.Components = c;
			return f;
		}
		private Field OBR40()
		{
			Field f = new Field("Transport Arrangement Responsibility");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-40.1"));
			c.Add(new Component("", "OBR-40.2"));
			c.Add(new Component("Name of Coding System", "OBR-40.3"));
			c.Add(new Component("Alternate Identifier", "OBR-40.4"));
			c.Add(new Component("Alternate Text", "OBR-40.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-40.6"));
			f.Components = c;
			return f;
		}
		private Field OBR41()
		{
			Field f = new Field("Transport Arranged");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-41.1"));
			f.Components = c;
			return f;
		}
		private Field OBR42()
		{
			Field f = new Field("Escort Required");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-42.1"));
			f.Components = c;
			return f;
		}
		private Field OBR43()
		{
			Field f = new Field("Planned Patient Transport Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-43.1"));
			c.Add(new Component("", "OBR-43.2"));
			c.Add(new Component("Name of Coding System", "OBR-43.3"));
			c.Add(new Component("Alternate Identifier", "OBR-43.4"));
			c.Add(new Component("Alternate Text", "OBR-43.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-43.6"));
			f.Components = c;
			return f;
		}
		private Field OBR44()
		{
			Field f = new Field("Procedure Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-44.1"));
			c.Add(new Component("", "OBR-44.2"));
			c.Add(new Component("Name of Coding System", "OBR-44.3"));
			c.Add(new Component("Alternate Identifier", "OBR-44.4"));
			c.Add(new Component("Alternate Text", "OBR-44.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-44.6"));
			f.Components = c;
			return f;
		}
		private Field OBR45()
		{
			Field f = new Field("Procedure Code Modifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-45.1"));
			c.Add(new Component("", "OBR-45.2"));
			c.Add(new Component("Name of Coding System", "OBR-45.3"));
			c.Add(new Component("Alternate Identifier", "OBR-45.4"));
			c.Add(new Component("Alternate Text", "OBR-45.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-45.6"));
			f.Components = c;
			return f;
		}
		private Field OBR46()
		{
			Field f = new Field("Placer Supplemental Service Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-46.1"));
			c.Add(new Component("", "OBR-46.2"));
			c.Add(new Component("Name of Coding System", "OBR-46.3"));
			c.Add(new Component("Alternate Identifier", "OBR-46.4"));
			c.Add(new Component("Alternate Text", "OBR-46.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-46.6"));
			f.Components = c;
			return f;
		}
		private Field OBR47()
		{
			Field f = new Field("Filler Supplemental Service Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-47.1"));
			c.Add(new Component("", "OBR-47.2"));
			c.Add(new Component("Name of Coding System", "OBR-47.3"));
			c.Add(new Component("Alternate Identifier", "OBR-47.4"));
			c.Add(new Component("Alternate Text", "OBR-47.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-47.6"));
			f.Components = c;
			return f;
		}
		private Field OBR48()
		{
			Field f = new Field("Medically Necessary Duplicate Procedure Reason.");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBR-48.1"));
			c.Add(new Component("", "OBR-48.2"));
			c.Add(new Component("Name of Coding System", "OBR-48.3"));
			c.Add(new Component("Alternate Identifier", "OBR-48.4"));
			c.Add(new Component("Alternate Text", "OBR-48.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBR-48.6"));
			c.Add(new Component("Coding System Version ID", "OBR-48.7"));
			c.Add(new Component("Alternate Coding System Version ID", "OBR-48.8"));
			c.Add(new Component("Original Text", "OBR-48.9"));
			f.Components = c;
			return f;
		}
		private Field OBR49()
		{
			Field f = new Field("Result Handling");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBR-49.1"));
			f.Components = c;
			return f;
		}
	}
}
