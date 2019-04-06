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
/// PV2 Class: Constructs an HL7 PV2 Segment Object
/// </summary>
public class PV2
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PV2()
		{
			Name = "PV2";
			Description = "Patient Visit - Additional Information";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PV21());
			fs.Add(PV22());
			fs.Add(PV23());
			fs.Add(PV24());
			fs.Add(PV25());
			fs.Add(PV26());
			fs.Add(PV27());
			fs.Add(PV28());
			fs.Add(PV29());
			fs.Add(PV210());
			fs.Add(PV211());
			fs.Add(PV212());
			fs.Add(PV213());
			fs.Add(PV214());
			fs.Add(PV215());
			fs.Add(PV216());
			fs.Add(PV217());
			fs.Add(PV218());
			fs.Add(PV219());
			fs.Add(PV220());
			fs.Add(PV221());
			fs.Add(PV222());
			fs.Add(PV223());
			fs.Add(PV224());
			fs.Add(PV225());
			fs.Add(PV226());
			fs.Add(PV227());
			fs.Add(PV228());
			fs.Add(PV229());
			fs.Add(PV230());
			fs.Add(PV231());
			fs.Add(PV232());
			fs.Add(PV233());
			fs.Add(PV234());
			fs.Add(PV235());
			fs.Add(PV236());
			fs.Add(PV237());
			fs.Add(PV238());
			fs.Add(PV239());
			fs.Add(PV240());
			fs.Add(PV241());
			fs.Add(PV242());
			fs.Add(PV243());
			fs.Add(PV244());
			fs.Add(PV245());
			fs.Add(PV246());
			fs.Add(PV247());
			fs.Add(PV248());
			fs.Add(PV249());
			Fields = fs;
		}
		private Field PV21()
		{
			Field f = new Field("Prior Pending Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Point of Care", "PV2-1.1"));
			c.Add(new Component("Room", "PV2-1.2"));
			c.Add(new Component("Bed", "PV2-1.3"));
			c.Add(new Component("Facility", "PV2-1.4"));
			c.Add(new Component("Location Status", "PV2-1.5"));
			c.Add(new Component("Person Location Type", "PV2-1.6"));
			c.Add(new Component("Building", "PV2-1.7"));
			c.Add(new Component("Floor Number", "PV2-1.8"));
			c.Add(new Component("Location Description", "PV2-1.9"));
			c.Add(new Component("Comprehensive Location Identifier", "PV2-1.10"));
			c.Add(new Component("Assigning Authority for Location", "PV2-1.11"));
			f.Components = c;
			return f;
		}
		private Field PV22()
		{
			Field f = new Field("Accommodation Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-2.1"));
			c.Add(new Component("", "PV2-2.2"));
			c.Add(new Component("Name of Coding System", "PV2-2.3"));
			c.Add(new Component("Alternate Identifier", "PV2-2.4"));
			c.Add(new Component("Alternate Text", "PV2-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-2.6"));
			f.Components = c;
			return f;
		}
		private Field PV23()
		{
			Field f = new Field("Admit Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-3.1"));
			c.Add(new Component("", "PV2-3.2"));
			c.Add(new Component("Name of Coding System", "PV2-3.3"));
			c.Add(new Component("Alternate Identifier", "PV2-3.4"));
			c.Add(new Component("Alternate Text", "PV2-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-3.6"));
			f.Components = c;
			return f;
		}
		private Field PV24()
		{
			Field f = new Field("Transfer Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-4.1"));
			c.Add(new Component("", "PV2-4.2"));
			c.Add(new Component("Name of Coding System", "PV2-4.3"));
			c.Add(new Component("Alternate Identifier", "PV2-4.4"));
			c.Add(new Component("Alternate Text", "PV2-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-4.6"));
			f.Components = c;
			return f;
		}
		private Field PV25()
		{
			Field f = new Field("Patient Valuables");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-5.1"));
			f.Components = c;
			return f;
		}
		private Field PV26()
		{
			Field f = new Field("Patient Valuables Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-6.1"));
			f.Components = c;
			return f;
		}
		private Field PV27()
		{
			Field f = new Field("Visit User Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-7.1"));
			f.Components = c;
			return f;
		}
		private Field PV28()
		{
			Field f = new Field("Expected Admit Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PV2-8.1"));
			c.Add(new Component("Degree of Precision", "PV2-8.2"));
			f.Components = c;
			return f;
		}
		private Field PV29()
		{
			Field f = new Field("Expected Discharge Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PV2-9.1"));
			c.Add(new Component("Degree of Precision", "PV2-9.2"));
			f.Components = c;
			return f;
		}
		private Field PV210()
		{
			Field f = new Field("Estimated Length of Inpatient Stay");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-10.1"));
			f.Components = c;
			return f;
		}
		private Field PV211()
		{
			Field f = new Field("Actual Length of Inpatient Stay");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-11.1"));
			f.Components = c;
			return f;
		}
		private Field PV212()
		{
			Field f = new Field("Visit Description");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-12.1"));
			f.Components = c;
			return f;
		}
		private Field PV213()
		{
			Field f = new Field("Referral Source Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "PV2-13.1"));
			c.Add(new Component("Family Name", "PV2-13.2"));
			c.Add(new Component("Given Name", "PV2-13.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "PV2-13.4"));
			c.Add(new Component("Suffix", "PV2-13.5"));
			c.Add(new Component("Prefix", "PV2-13.6"));
			c.Add(new Component("Degree", "PV2-13.7"));
			c.Add(new Component("Source Table", "PV2-13.8"));
			c.Add(new Component("Assigning Authority", "PV2-13.9"));
			c.Add(new Component("Name Type Code", "PV2-13.10"));
			c.Add(new Component("Identifier Check Digit", "PV2-13.11"));
			c.Add(new Component("Check Digit Scheme", "PV2-13.12"));
			c.Add(new Component("Identifier Type Code", "PV2-13.13"));
			c.Add(new Component("Assigning Facility", "PV2-13.14"));
			c.Add(new Component("Name Respresentation Code", "PV2-13.15"));
			c.Add(new Component("Name Context", "PV2-13.16"));
			c.Add(new Component("Name Validity Range", "PV2-13.17"));
			c.Add(new Component("Name Assembly Order", "PV2-13.18"));
			c.Add(new Component("Effective Date", "PV2-13.19"));
			c.Add(new Component("Expiration Date", "PV2-13.20"));
			c.Add(new Component("Professional Suffix", "PV2-13.21"));
			c.Add(new Component("Assigning Jurisdiction", "PV2-13.22"));
			c.Add(new Component("Assigning Agency or Department", "PV2-13.23"));
			f.Components = c;
			return f;
		}
		private Field PV214()
		{
			Field f = new Field("Previous Service Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-14.1"));
			f.Components = c;
			return f;
		}
		private Field PV215()
		{
			Field f = new Field("Employment Illness Related Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-15.1"));
			f.Components = c;
			return f;
		}
		private Field PV216()
		{
			Field f = new Field("Purge Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-16.1"));
			f.Components = c;
			return f;
		}
		private Field PV217()
		{
			Field f = new Field("Purge Status Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-17.1"));
			f.Components = c;
			return f;
		}
		private Field PV218()
		{
			Field f = new Field("Special Program Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-18.1"));
			f.Components = c;
			return f;
		}
		private Field PV219()
		{
			Field f = new Field("Retention Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-19.1"));
			f.Components = c;
			return f;
		}
		private Field PV220()
		{
			Field f = new Field("Expected Number of Insurance Plans");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-20.1"));
			f.Components = c;
			return f;
		}
		private Field PV221()
		{
			Field f = new Field("Visit Publicity Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-21.1"));
			f.Components = c;
			return f;
		}
		private Field PV222()
		{
			Field f = new Field("Visit Protection Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-22.1"));
			f.Components = c;
			return f;
		}
		private Field PV223()
		{
			Field f = new Field("Clinic Organization Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "PV2-23.1"));
			c.Add(new Component("Organization Name Type Code", "PV2-23.2"));
			c.Add(new Component("ID Number", "PV2-23.3"));
			c.Add(new Component("Check Digit", "PV2-23.4"));
			c.Add(new Component("Check Digit Scheme", "PV2-23.5"));
			c.Add(new Component("Assigning Authority", "PV2-23.6"));
			c.Add(new Component("Identifier Type Code", "PV2-23.7"));
			c.Add(new Component("Assigning Facility", "PV2-23.8"));
			c.Add(new Component("Name Respresentation Code", "PV2-23.9"));
			c.Add(new Component("Organization Identifier", "PV2-23.10"));
			f.Components = c;
			return f;
		}
		private Field PV224()
		{
			Field f = new Field("Patient Status Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-24.1"));
			f.Components = c;
			return f;
		}
		private Field PV225()
		{
			Field f = new Field("Visit Priority Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-25.1"));
			f.Components = c;
			return f;
		}
		private Field PV226()
		{
			Field f = new Field("Previous Treatment Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-26.1"));
			f.Components = c;
			return f;
		}
		private Field PV227()
		{
			Field f = new Field("Expected Discharge Disposition");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-27.1"));
			f.Components = c;
			return f;
		}
		private Field PV228()
		{
			Field f = new Field("Signature on File Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-28.1"));
			f.Components = c;
			return f;
		}
		private Field PV229()
		{
			Field f = new Field("First Similar Illness Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-29.1"));
			f.Components = c;
			return f;
		}
		private Field PV230()
		{
			Field f = new Field("Patient Charge Adjustment Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-30.1"));
			c.Add(new Component("", "PV2-30.2"));
			c.Add(new Component("Name of Coding System", "PV2-30.3"));
			c.Add(new Component("Alternate Identifier", "PV2-30.4"));
			c.Add(new Component("Alternate Text", "PV2-30.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-30.6"));
			f.Components = c;
			return f;
		}
		private Field PV231()
		{
			Field f = new Field("Recurring Service Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-31.1"));
			f.Components = c;
			return f;
		}
		private Field PV232()
		{
			Field f = new Field("Billing Media Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-32.1"));
			f.Components = c;
			return f;
		}
		private Field PV233()
		{
			Field f = new Field("Expected Surgery Date and Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PV2-33.1"));
			c.Add(new Component("Degree of Precision", "PV2-33.2"));
			f.Components = c;
			return f;
		}
		private Field PV234()
		{
			Field f = new Field("Military Partnership Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-34.1"));
			f.Components = c;
			return f;
		}
		private Field PV235()
		{
			Field f = new Field("Military Non-Availability Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-35.1"));
			f.Components = c;
			return f;
		}
		private Field PV236()
		{
			Field f = new Field("Newborn Baby Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-36.1"));
			f.Components = c;
			return f;
		}
		private Field PV237()
		{
			Field f = new Field("Baby Detained Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-37.1"));
			f.Components = c;
			return f;
		}
		private Field PV238()
		{
			Field f = new Field("Mode of Arrival Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-38.1"));
			c.Add(new Component("", "PV2-38.2"));
			c.Add(new Component("Name of Coding System", "PV2-38.3"));
			c.Add(new Component("Alternate Identifier", "PV2-38.4"));
			c.Add(new Component("Alternate Text", "PV2-38.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-38.6"));
			f.Components = c;
			return f;
		}
		private Field PV239()
		{
			Field f = new Field("Recreational Drug Use Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-39.1"));
			c.Add(new Component("", "PV2-39.2"));
			c.Add(new Component("Name of Coding System", "PV2-39.3"));
			c.Add(new Component("Alternate Identifier", "PV2-39.4"));
			c.Add(new Component("Alternate Text", "PV2-39.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-39.6"));
			f.Components = c;
			return f;
		}
		private Field PV240()
		{
			Field f = new Field("Admission Level of Care Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-40.1"));
			c.Add(new Component("", "PV2-40.2"));
			c.Add(new Component("Name of Coding System", "PV2-40.3"));
			c.Add(new Component("Alternate Identifier", "PV2-40.4"));
			c.Add(new Component("Alternate Text", "PV2-40.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-40.6"));
			f.Components = c;
			return f;
		}
		private Field PV241()
		{
			Field f = new Field("Precaution Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-41.1"));
			c.Add(new Component("", "PV2-41.2"));
			c.Add(new Component("Name of Coding System", "PV2-41.3"));
			c.Add(new Component("Alternate Identifier", "PV2-41.4"));
			c.Add(new Component("Alternate Text", "PV2-41.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-41.6"));
			f.Components = c;
			return f;
		}
		private Field PV242()
		{
			Field f = new Field("Patient Condition Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-42.1"));
			c.Add(new Component("", "PV2-42.2"));
			c.Add(new Component("Name of Coding System", "PV2-42.3"));
			c.Add(new Component("Alternate Identifier", "PV2-42.4"));
			c.Add(new Component("Alternate Text", "PV2-42.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-42.6"));
			f.Components = c;
			return f;
		}
		private Field PV243()
		{
			Field f = new Field("Living Will Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-43.1"));
			f.Components = c;
			return f;
		}
		private Field PV244()
		{
			Field f = new Field("Organ Donor Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-44.1"));
			f.Components = c;
			return f;
		}
		private Field PV245()
		{
			Field f = new Field("Advance Directive Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PV2-45.1"));
			c.Add(new Component("", "PV2-45.2"));
			c.Add(new Component("Name of Coding System", "PV2-45.3"));
			c.Add(new Component("Alternate Identifier", "PV2-45.4"));
			c.Add(new Component("Alternate Text", "PV2-45.5"));
			c.Add(new Component("Name of Alternate Coding System", "PV2-45.6"));
			f.Components = c;
			return f;
		}
		private Field PV246()
		{
			Field f = new Field("Patient Status Effective Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-46.1"));
			f.Components = c;
			return f;
		}
		private Field PV247()
		{
			Field f = new Field("Expected LOA Return Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PV2-47.1"));
			c.Add(new Component("Degree of Precision", "PV2-47.2"));
			f.Components = c;
			return f;
		}
		private Field PV248()
		{
			Field f = new Field("Expected Pre-admission Testing Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PV2-48.1"));
			c.Add(new Component("Degree of Precision", "PV2-48.2"));
			f.Components = c;
			return f;
		}
		private Field PV249()
		{
			Field f = new Field("Notify Clergy Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PV2-49.1"));
			f.Components = c;
			return f;
		}
	}
}
