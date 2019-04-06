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
/// PV1 Class: Constructs an HL7 PV1 Segment Object
/// </summary>
public class PV1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PV1()
		{
			Name = "PV1";
			Description = "Patient Visit";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PV11());
			fs.Add(PV12());
			fs.Add(PV13());
			fs.Add(PV14());
			fs.Add(PV15());
			fs.Add(PV16());
			fs.Add(PV17());
			fs.Add(PV18());
			fs.Add(PV19());
			fs.Add(PV110());
			fs.Add(PV111());
			fs.Add(PV112());
			fs.Add(PV113());
			fs.Add(PV114());
			fs.Add(PV115());
			fs.Add(PV116());
			fs.Add(PV117());
			fs.Add(PV118());
			fs.Add(PV119());
			fs.Add(PV120());
			fs.Add(PV121());
			fs.Add(PV122());
			fs.Add(PV123());
			fs.Add(PV124());
			fs.Add(PV125());
			fs.Add(PV126());
			fs.Add(PV127());
			fs.Add(PV128());
			fs.Add(PV129());
			fs.Add(PV130());
			fs.Add(PV131());
			fs.Add(PV132());
			fs.Add(PV133());
			fs.Add(PV134());
			fs.Add(PV135());
			fs.Add(PV136());
			fs.Add(PV137());
			fs.Add(PV138());
			fs.Add(PV139());
			fs.Add(PV140());
			fs.Add(PV141());
			fs.Add(PV142());
			fs.Add(PV143());
			fs.Add(PV144());
			fs.Add(PV145());
			fs.Add(PV146());
			fs.Add(PV147());
			fs.Add(PV148());
			fs.Add(PV149());
			fs.Add(PV150());
			fs.Add(PV151());
			fs.Add(PV152());
			Fields = fs;
		}
		private Field PV11()
		{
			Field f = new Field("Set ID - PV1");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "PV1-1.1"));
			f.Components = c;
			return f;
		}
		private Field PV12()
		{
			Field f = new Field("Patient Class");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-2.1"));
			f.Components = c;
			return f;
		}
		private Field PV13()
		{
			Field f = new Field("Assigned Patient Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "PV1-3.1"));
			c.Add(new Component("Room", "PV1-3.2"));
			c.Add(new Component("Bed", "PV1-3.3"));
			c.Add(new Component("Facility", "PV1-3.4"));
			c.Add(new Component("Location Status", "PV1-3.5"));
			c.Add(new Component("Person Location Type", "PV1-3.6"));
			c.Add(new Component("Building", "PV1-3.7"));
			c.Add(new Component("Floor Number", "PV1-3.8"));
			c.Add(new Component("Location Description", "PV1-3.9"));
			c.Add(new Component("Comprehensive Location Identifier", "PV1-3.10"));
			c.Add(new Component("Assigning Authority for Location", "PV1-3.11"));
			f.Components = c;
			return f;
		}
		private Field PV14()
		{
			Field f = new Field("Admission Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-4.1"));
			f.Components = c;
			return f;
		}
		private Field PV15()
		{
			Field f = new Field("Preadmit Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV1-5.1"));
			c.Add(new Component("Check Digit", "PV1-5.2"));
			c.Add(new Component("Check Digit Scheme", "PV1-5.3"));
			c.Add(new Component("Assigning Authority", "PV1-5.4"));
			c.Add(new Component("Identifier Type Code", "PV1-5.5"));
			c.Add(new Component("Assigning Facility", "PV1-5.6"));
			c.Add(new Component("Effective Date", "PV1-5.7"));
			c.Add(new Component("Expiration Date", "PV1-5.8"));
			c.Add(new Component("Assigning Jurisdiction", "PV1-5.9"));
			c.Add(new Component("Assigning Agency or Department", "PV1-5.10"));
			f.Components = c;
			return f;
		}
		private Field PV16()
		{
			Field f = new Field("Prior Patient Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "PV1-6.1"));
			c.Add(new Component("Room", "PV1-6.2"));
			c.Add(new Component("Bed", "PV1-6.3"));
			c.Add(new Component("Facility", "PV1-6.4"));
			c.Add(new Component("Location Status", "PV1-6.5"));
			c.Add(new Component("Person Location Type", "PV1-6.6"));
			c.Add(new Component("Building", "PV1-6.7"));
			c.Add(new Component("Floor Number", "PV1-6.8"));
			c.Add(new Component("Location Description", "PV1-6.9"));
			c.Add(new Component("Comprehensive Location Identifier", "PV1-6.10"));
			c.Add(new Component("Assigning Authority for Location", "PV1-6.11"));
			f.Components = c;
			return f;
		}
		private Field PV17()
		{
			Field f = new Field("Attending Doctor");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV1-7.1"));
			c.Add(new Component("Family Name", "PV1-7.2"));
			c.Add(new Component("Given Name", "PV1-7.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PV1-7.4"));
			c.Add(new Component("Suffix", "PV1-7.5"));
			c.Add(new Component("Prefix", "PV1-7.6"));
			c.Add(new Component("Degree", "PV1-7.7"));
			c.Add(new Component("Source Table", "PV1-7.8"));
			c.Add(new Component("Assigning Authority", "PV1-7.9"));
			c.Add(new Component("Name Type Code", "PV1-7.10"));
			c.Add(new Component("Identifier Check Digit", "PV1-7.11"));
			c.Add(new Component("Check Digit Scheme", "PV1-7.12"));
			c.Add(new Component("Identifier Type Code", "PV1-7.13"));
			c.Add(new Component("Assigning Facility", "PV1-7.14"));
			c.Add(new Component("Name Respresentation Code", "PV1-7.15"));
			c.Add(new Component("Name Context", "PV1-7.16"));
			c.Add(new Component("Name Validity Range", "PV1-7.17"));
			c.Add(new Component("Name Assembly Order", "PV1-7.18"));
			c.Add(new Component("Effective Date", "PV1-7.19"));
			c.Add(new Component("Expiration Date", "PV1-7.20"));
			c.Add(new Component("Professional Suffix", "PV1-7.21"));
			c.Add(new Component("Assigning Jurisdiction", "PV1-7.22"));
			c.Add(new Component("Assigning Agency or Department", "PV1-7.23"));
			f.Components = c;
			return f;
		}
		private Field PV18()
		{
			Field f = new Field("Referring Doctor");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV1-8.1"));
			c.Add(new Component("Family Name", "PV1-8.2"));
			c.Add(new Component("Given Name", "PV1-8.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PV1-8.4"));
			c.Add(new Component("Suffix", "PV1-8.5"));
			c.Add(new Component("Prefix", "PV1-8.6"));
			c.Add(new Component("Degree", "PV1-8.7"));
			c.Add(new Component("Source Table", "PV1-8.8"));
			c.Add(new Component("Assigning Authority", "PV1-8.9"));
			c.Add(new Component("Name Type Code", "PV1-8.10"));
			c.Add(new Component("Identifier Check Digit", "PV1-8.11"));
			c.Add(new Component("Check Digit Scheme", "PV1-8.12"));
			c.Add(new Component("Identifier Type Code", "PV1-8.13"));
			c.Add(new Component("Assigning Facility", "PV1-8.14"));
			c.Add(new Component("Name Respresentation Code", "PV1-8.15"));
			c.Add(new Component("Name Context", "PV1-8.16"));
			c.Add(new Component("Name Validity Range", "PV1-8.17"));
			c.Add(new Component("Name Assembly Order", "PV1-8.18"));
			c.Add(new Component("Effective Date", "PV1-8.19"));
			c.Add(new Component("Expiration Date", "PV1-8.20"));
			c.Add(new Component("Professional Suffix", "PV1-8.21"));
			c.Add(new Component("Assigning Jurisdiction", "PV1-8.22"));
			c.Add(new Component("Assigning Agency or Department", "PV1-8.23"));
			f.Components = c;
			return f;
		}
		private Field PV19()
		{
			Field f = new Field("Consulting Doctor");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV1-9.1"));
			c.Add(new Component("Family Name", "PV1-9.2"));
			c.Add(new Component("Given Name", "PV1-9.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PV1-9.4"));
			c.Add(new Component("Suffix", "PV1-9.5"));
			c.Add(new Component("Prefix", "PV1-9.6"));
			c.Add(new Component("Degree", "PV1-9.7"));
			c.Add(new Component("Source Table", "PV1-9.8"));
			c.Add(new Component("Assigning Authority", "PV1-9.9"));
			c.Add(new Component("Name Type Code", "PV1-9.10"));
			c.Add(new Component("Identifier Check Digit", "PV1-9.11"));
			c.Add(new Component("Check Digit Scheme", "PV1-9.12"));
			c.Add(new Component("Identifier Type Code", "PV1-9.13"));
			c.Add(new Component("Assigning Facility", "PV1-9.14"));
			c.Add(new Component("Name Respresentation Code", "PV1-9.15"));
			c.Add(new Component("Name Context", "PV1-9.16"));
			c.Add(new Component("Name Validity Range", "PV1-9.17"));
			c.Add(new Component("Name Assembly Order", "PV1-9.18"));
			c.Add(new Component("Effective Date", "PV1-9.19"));
			c.Add(new Component("Expiration Date", "PV1-9.20"));
			c.Add(new Component("Professional Suffix", "PV1-9.21"));
			c.Add(new Component("Assigning Jurisdiction", "PV1-9.22"));
			c.Add(new Component("Assigning Agency or Department", "PV1-9.23"));
			f.Components = c;
			return f;
		}
		private Field PV110()
		{
			Field f = new Field("Hospital Service");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-10.1"));
			f.Components = c;
			return f;
		}
		private Field PV111()
		{
			Field f = new Field("Temporary Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "PV1-11.1"));
			c.Add(new Component("Room", "PV1-11.2"));
			c.Add(new Component("Bed", "PV1-11.3"));
			c.Add(new Component("Facility", "PV1-11.4"));
			c.Add(new Component("Location Status", "PV1-11.5"));
			c.Add(new Component("Person Location Type", "PV1-11.6"));
			c.Add(new Component("Building", "PV1-11.7"));
			c.Add(new Component("Floor Number", "PV1-11.8"));
			c.Add(new Component("Location Description", "PV1-11.9"));
			c.Add(new Component("Comprehensive Location Identifier", "PV1-11.10"));
			c.Add(new Component("Assigning Authority for Location", "PV1-11.11"));
			f.Components = c;
			return f;
		}
		private Field PV112()
		{
			Field f = new Field("Preadmit Test Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-12.1"));
			f.Components = c;
			return f;
		}
		private Field PV113()
		{
			Field f = new Field("Re-admission Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-13.1"));
			f.Components = c;
			return f;
		}
		private Field PV114()
		{
			Field f = new Field("Admit Source");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-14.1"));
			f.Components = c;
			return f;
		}
		private Field PV115()
		{
			Field f = new Field("Ambulatory Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-15.1"));
			f.Components = c;
			return f;
		}
		private Field PV116()
		{
			Field f = new Field("VIP Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-16.1"));
			f.Components = c;
			return f;
		}
		private Field PV117()
		{
			Field f = new Field("Admitting Doctor");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV1-17.1"));
			c.Add(new Component("Family Name", "PV1-17.2"));
			c.Add(new Component("Given Name", "PV1-17.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PV1-17.4"));
			c.Add(new Component("Suffix", "PV1-17.5"));
			c.Add(new Component("Prefix", "PV1-17.6"));
			c.Add(new Component("Degree", "PV1-17.7"));
			c.Add(new Component("Source Table", "PV1-17.8"));
			c.Add(new Component("Assigning Authority", "PV1-17.9"));
			c.Add(new Component("Name Type Code", "PV1-17.10"));
			c.Add(new Component("Identifier Check Digit", "PV1-17.11"));
			c.Add(new Component("Check Digit Scheme", "PV1-17.12"));
			c.Add(new Component("Identifier Type Code", "PV1-17.13"));
			c.Add(new Component("Assigning Facility", "PV1-17.14"));
			c.Add(new Component("Name Respresentation Code", "PV1-17.15"));
			c.Add(new Component("Name Context", "PV1-17.16"));
			c.Add(new Component("Name Validity Range", "PV1-17.17"));
			c.Add(new Component("Name Assembly Order", "PV1-17.18"));
			c.Add(new Component("Effective Date", "PV1-17.19"));
			c.Add(new Component("Expiration Date", "PV1-17.20"));
			c.Add(new Component("Professional Suffix", "PV1-17.21"));
			c.Add(new Component("Assigning Jurisdiction", "PV1-17.22"));
			c.Add(new Component("Assigning Agency or Department", "PV1-17.23"));
			f.Components = c;
			return f;
		}
		private Field PV118()
		{
			Field f = new Field("Patient Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-18.1"));
			f.Components = c;
			return f;
		}
		private Field PV119()
		{
			Field f = new Field("Visit Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV1-19.1"));
			c.Add(new Component("Check Digit", "PV1-19.2"));
			c.Add(new Component("Check Digit Scheme", "PV1-19.3"));
			c.Add(new Component("Assigning Authority", "PV1-19.4"));
			c.Add(new Component("Identifier Type Code", "PV1-19.5"));
			c.Add(new Component("Assigning Facility", "PV1-19.6"));
			c.Add(new Component("Effective Date", "PV1-19.7"));
			c.Add(new Component("Expiration Date", "PV1-19.8"));
			c.Add(new Component("Assigning Jurisdiction", "PV1-19.9"));
			c.Add(new Component("Assigning Agency or Department", "PV1-19.10"));
			f.Components = c;
			return f;
		}
		private Field PV120()
		{
			Field f = new Field("Financial Class");
			List<Component> c = new List<Component>();
			c.Add(new Component("Financial Class Code", "PV1-20.1"));
			c.Add(new Component("Effective Date", "PV1-20.2"));
			f.Components = c;
			return f;
		}
		private Field PV121()
		{
			Field f = new Field("Charge Price Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-21.1"));
			f.Components = c;
			return f;
		}
		private Field PV122()
		{
			Field f = new Field("Courtesy Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-22.1"));
			f.Components = c;
			return f;
		}
		private Field PV123()
		{
			Field f = new Field("Credit Rating");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-23.1"));
			f.Components = c;
			return f;
		}
		private Field PV124()
		{
			Field f = new Field("Contract Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-24.1"));
			f.Components = c;
			return f;
		}
		private Field PV125()
		{
			Field f = new Field("Contract Effective Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-25.1"));
			f.Components = c;
			return f;
		}
		private Field PV126()
		{
			Field f = new Field("Contract Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-26.1"));
			f.Components = c;
			return f;
		}
		private Field PV127()
		{
			Field f = new Field("Contract Period");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-27.1"));
			f.Components = c;
			return f;
		}
		private Field PV128()
		{
			Field f = new Field("Interest Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-28.1"));
			f.Components = c;
			return f;
		}
		private Field PV129()
		{
			Field f = new Field("Transfer to Bad Debt Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-29.1"));
			f.Components = c;
			return f;
		}
		private Field PV130()
		{
			Field f = new Field("Transfer to Bad Debt Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-30.1"));
			f.Components = c;
			return f;
		}
		private Field PV131()
		{
			Field f = new Field("Bad Debt Agency Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-31.1"));
			f.Components = c;
			return f;
		}
		private Field PV132()
		{
			Field f = new Field("Bad Debt Transfer Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-32.1"));
			f.Components = c;
			return f;
		}
		private Field PV133()
		{
			Field f = new Field("Bad Debt Recovery Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-33.1"));
			f.Components = c;
			return f;
		}
		private Field PV134()
		{
			Field f = new Field("Delete Account Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-34.1"));
			f.Components = c;
			return f;
		}
		private Field PV135()
		{
			Field f = new Field("Delete Account Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-35.1"));
			f.Components = c;
			return f;
		}
		private Field PV136()
		{
			Field f = new Field("Discharge Disposition");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-36.1"));
			f.Components = c;
			return f;
		}
		private Field PV137()
		{
			Field f = new Field("Discharged to Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Discharge Location", "PV1-37.1"));
			c.Add(new Component("Effective Date", "PV1-37.2"));
			f.Components = c;
			return f;
		}
		private Field PV138()
		{
			Field f = new Field("Diet Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV1-38.1"));
			c.Add(new Component("", "PV1-38.2"));
			c.Add(new Component("Name of Coding System", "PV1-38.3"));
			c.Add(new Component("Alternate Identifier", "PV1-38.4"));
			c.Add(new Component("Alternate Text", "PV1-38.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV1-38.6"));
			f.Components = c;
			return f;
		}
		private Field PV139()
		{
			Field f = new Field("Servicing Facility");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-39.1"));
			f.Components = c;
			return f;
		}
		private Field PV140()
		{
			Field f = new Field("Bed Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-40.1"));
			f.Components = c;
			return f;
		}
		private Field PV141()
		{
			Field f = new Field("Account Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-41.1"));
			f.Components = c;
			return f;
		}
		private Field PV142()
		{
			Field f = new Field("Pending Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "PV1-42.1"));
			c.Add(new Component("Room", "PV1-42.2"));
			c.Add(new Component("Bed", "PV1-42.3"));
			c.Add(new Component("Facility", "PV1-42.4"));
			c.Add(new Component("Location Status", "PV1-42.5"));
			c.Add(new Component("Person Location Type", "PV1-42.6"));
			c.Add(new Component("Building", "PV1-42.7"));
			c.Add(new Component("Floor Number", "PV1-42.8"));
			c.Add(new Component("Location Description", "PV1-42.9"));
			c.Add(new Component("Comprehensive Location Identifier", "PV1-42.10"));
			c.Add(new Component("Assigning Authority for Location", "PV1-42.11"));
			f.Components = c;
			return f;
		}
		private Field PV143()
		{
			Field f = new Field("Prior Temporary Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "PV1-43.1"));
			c.Add(new Component("Room", "PV1-43.2"));
			c.Add(new Component("Bed", "PV1-43.3"));
			c.Add(new Component("Facility", "PV1-43.4"));
			c.Add(new Component("Location Status", "PV1-43.5"));
			c.Add(new Component("Person Location Type", "PV1-43.6"));
			c.Add(new Component("Building", "PV1-43.7"));
			c.Add(new Component("Floor Number", "PV1-43.8"));
			c.Add(new Component("Location Description", "PV1-43.9"));
			c.Add(new Component("Comprehensive Location Identifier", "PV1-43.10"));
			c.Add(new Component("Assigning Authority for Location", "PV1-43.11"));
			f.Components = c;
			return f;
		}
		private Field PV144()
		{
			Field f = new Field("Admit Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PV1-44.1"));
			c.Add(new Component("Degree of Precision", "PV1-44.2"));
			f.Components = c;
			return f;
		}
		private Field PV145()
		{
			Field f = new Field("Discharge Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PV1-45.1"));
			c.Add(new Component("Degree of Precision", "PV1-45.2"));
			f.Components = c;
			return f;
		}
		private Field PV146()
		{
			Field f = new Field("Current Patient Balance");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-46.1"));
			f.Components = c;
			return f;
		}
		private Field PV147()
		{
			Field f = new Field("Total Charges");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-47.1"));
			f.Components = c;
			return f;
		}
		private Field PV148()
		{
			Field f = new Field("Total Adjustments");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-48.1"));
			f.Components = c;
			return f;
		}
		private Field PV149()
		{
			Field f = new Field("Total Payments");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-49.1"));
			f.Components = c;
			return f;
		}
		private Field PV150()
		{
			Field f = new Field("Alternate Visit ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV1-50.1"));
			c.Add(new Component("Check Digit", "PV1-50.2"));
			c.Add(new Component("Check Digit Scheme", "PV1-50.3"));
			c.Add(new Component("Assigning Authority", "PV1-50.4"));
			c.Add(new Component("Identifier Type Code", "PV1-50.5"));
			c.Add(new Component("Assigning Facility", "PV1-50.6"));
			c.Add(new Component("Effective Date", "PV1-50.7"));
			c.Add(new Component("Expiration Date", "PV1-50.8"));
			c.Add(new Component("Assigning Jurisdiction", "PV1-50.9"));
			c.Add(new Component("Assigning Agency or Department", "PV1-50.10"));
			f.Components = c;
			return f;
		}
		private Field PV151()
		{
			Field f = new Field("Visit Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV1-51.1"));
			f.Components = c;
			return f;
		}
		private Field PV152()
		{
			Field f = new Field("Other Healthcare Provider");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV1-52.1"));
			c.Add(new Component("Family Name", "PV1-52.2"));
			c.Add(new Component("Given Name", "PV1-52.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PV1-52.4"));
			c.Add(new Component("Suffix", "PV1-52.5"));
			c.Add(new Component("Prefix", "PV1-52.6"));
			c.Add(new Component("Degree", "PV1-52.7"));
			c.Add(new Component("Source Table", "PV1-52.8"));
			c.Add(new Component("Assigning Authority", "PV1-52.9"));
			c.Add(new Component("Name Type Code", "PV1-52.10"));
			c.Add(new Component("Identifier Check Digit", "PV1-52.11"));
			c.Add(new Component("Check Digit Scheme", "PV1-52.12"));
			c.Add(new Component("Identifier Type Code", "PV1-52.13"));
			c.Add(new Component("Assigning Facility", "PV1-52.14"));
			c.Add(new Component("Name Respresentation Code", "PV1-52.15"));
			c.Add(new Component("Name Context", "PV1-52.16"));
			c.Add(new Component("Name Validity Range", "PV1-52.17"));
			c.Add(new Component("Name Assembly Order", "PV1-52.18"));
			c.Add(new Component("Effective Date", "PV1-52.19"));
			c.Add(new Component("Expiration Date", "PV1-52.20"));
			c.Add(new Component("Professional Suffix", "PV1-52.21"));
			c.Add(new Component("Assigning Jurisdiction", "PV1-52.22"));
			c.Add(new Component("Assigning Agency or Department", "PV1-52.23"));
			f.Components = c;
			return f;
		}
	}
}
