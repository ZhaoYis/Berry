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
/// CER Class: Constructs an HL7 CER Segment Object
/// </summary>
public class CER
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public CER()
		{
			Name = "CER";
			Description = "Certificate Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(CER1());
			fs.Add(CER2());
			fs.Add(CER3());
			fs.Add(CER4());
			fs.Add(CER5());
			fs.Add(CER6());
			fs.Add(CER7());
			fs.Add(CER8());
			fs.Add(CER9());
			fs.Add(CER10());
			fs.Add(CER11());
			fs.Add(CER12());
			fs.Add(CER13());
			fs.Add(CER14());
			fs.Add(CER15());
			fs.Add(CER16());
			fs.Add(CER17());
			fs.Add(CER18());
			fs.Add(CER19());
			fs.Add(CER20());
			fs.Add(CER21());
			fs.Add(CER22());
			fs.Add(CER23());
			fs.Add(CER24());
			fs.Add(CER25());
			fs.Add(CER26());
			fs.Add(CER27());
			fs.Add(CER28());
			fs.Add(CER29());
			fs.Add(CER30());
			fs.Add(CER31());
			Fields = fs;
		}
		private Field CER1()
		{
			Field f = new Field("Set ID _ CER");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "CER-1.1"));
			f.Components = c;
			return f;
		}
		private Field CER2()
		{
			Field f = new Field("Serial Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CER-2.1"));
			f.Components = c;
			return f;
		}
		private Field CER3()
		{
			Field f = new Field("Version");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CER-3.1"));
			f.Components = c;
			return f;
		}
		private Field CER4()
		{
			Field f = new Field("Granting Authority");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "CER-4.1"));
			c.Add(new Component("Organization Name Type Code", "CER-4.2"));
			c.Add(new Component("ID Number", "CER-4.3"));
			c.Add(new Component("Check Digit", "CER-4.4"));
			c.Add(new Component("Check Digit Scheme", "CER-4.5"));
			c.Add(new Component("Assigning Authority", "CER-4.6"));
			c.Add(new Component("Identifier Type Code", "CER-4.7"));
			c.Add(new Component("Assigning Facility", "CER-4.8"));
			c.Add(new Component("Name Respresentation Code", "CER-4.9"));
			c.Add(new Component("Organization Identifier", "CER-4.10"));
			f.Components = c;
			return f;
		}
		private Field CER5()
		{
			Field f = new Field("Issuing Authority");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "CER-5.1"));
			c.Add(new Component("Family Name", "CER-5.2"));
			c.Add(new Component("Given Name", "CER-5.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "CER-5.4"));
			c.Add(new Component("Suffix", "CER-5.5"));
			c.Add(new Component("Prefix", "CER-5.6"));
			c.Add(new Component("Degree", "CER-5.7"));
			c.Add(new Component("Source Table", "CER-5.8"));
			c.Add(new Component("Assigning Authority", "CER-5.9"));
			c.Add(new Component("Name Type Code", "CER-5.10"));
			c.Add(new Component("Identifier Check Digit", "CER-5.11"));
			c.Add(new Component("Check Digit Scheme", "CER-5.12"));
			c.Add(new Component("Identifier Type Code", "CER-5.13"));
			c.Add(new Component("Assigning Facility", "CER-5.14"));
			c.Add(new Component("Name Respresentation Code", "CER-5.15"));
			c.Add(new Component("Name Context", "CER-5.16"));
			c.Add(new Component("Name Validity Range", "CER-5.17"));
			c.Add(new Component("Name Assembly Order", "CER-5.18"));
			c.Add(new Component("Effective Date", "CER-5.19"));
			c.Add(new Component("Expiration Date", "CER-5.20"));
			c.Add(new Component("Professional Suffix", "CER-5.21"));
			c.Add(new Component("Assigning Jurisdiction", "CER-5.22"));
			c.Add(new Component("Assigning Agency or Department", "CER-5.23"));
			f.Components = c;
			return f;
		}
		private Field CER6()
		{
			Field f = new Field("Signature of Issuing Authority");
			List<Component> c = new List<Component>();
			c.Add(new Component("Source Application", "CER-6.1"));
			c.Add(new Component("Type of Data", "CER-6.2"));
			c.Add(new Component("Data Subtype", "CER-6.3"));
			c.Add(new Component("Encoding", "CER-6.4"));
			c.Add(new Component("", "CER-6.5"));
			f.Components = c;
			return f;
		}
		private Field CER7()
		{
			Field f = new Field("Granting Country");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CER-7.1"));
			f.Components = c;
			return f;
		}
		private Field CER8()
		{
			Field f = new Field("Granting State/Province");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-8.1"));
			c.Add(new Component("", "CER-8.2"));
			c.Add(new Component("Name of Coding System", "CER-8.3"));
			c.Add(new Component("Alternate Identifier", "CER-8.4"));
			c.Add(new Component("Alternate Text", "CER-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-8.6"));
			c.Add(new Component("Coding System Version ID", "CER-8.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-8.8"));
			c.Add(new Component("Original Text", "CER-8.9"));
			f.Components = c;
			return f;
		}
		private Field CER9()
		{
			Field f = new Field("Granting County/Parish");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-9.1"));
			c.Add(new Component("", "CER-9.2"));
			c.Add(new Component("Name of Coding System", "CER-9.3"));
			c.Add(new Component("Alternate Identifier", "CER-9.4"));
			c.Add(new Component("Alternate Text", "CER-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-9.6"));
			c.Add(new Component("Coding System Version ID", "CER-9.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-9.8"));
			c.Add(new Component("Original Text", "CER-9.9"));
			f.Components = c;
			return f;
		}
		private Field CER10()
		{
			Field f = new Field("Certificate Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-10.1"));
			c.Add(new Component("", "CER-10.2"));
			c.Add(new Component("Name of Coding System", "CER-10.3"));
			c.Add(new Component("Alternate Identifier", "CER-10.4"));
			c.Add(new Component("Alternate Text", "CER-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-10.6"));
			c.Add(new Component("Coding System Version ID", "CER-10.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-10.8"));
			c.Add(new Component("Original Text", "CER-10.9"));
			f.Components = c;
			return f;
		}
		private Field CER11()
		{
			Field f = new Field("Certificate Domain");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-11.1"));
			c.Add(new Component("", "CER-11.2"));
			c.Add(new Component("Name of Coding System", "CER-11.3"));
			c.Add(new Component("Alternate Identifier", "CER-11.4"));
			c.Add(new Component("Alternate Text", "CER-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-11.6"));
			c.Add(new Component("Coding System Version ID", "CER-11.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-11.8"));
			c.Add(new Component("Original Text", "CER-11.9"));
			f.Components = c;
			return f;
		}
		private Field CER12()
		{
			Field f = new Field("Subject ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CER-12.1"));
			f.Components = c;
			return f;
		}
		private Field CER13()
		{
			Field f = new Field("Subject Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CER-13.1"));
			f.Components = c;
			return f;
		}
		private Field CER14()
		{
			Field f = new Field("Subject Directory Attribute Extension (Health Professional Data)");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-14.1"));
			c.Add(new Component("", "CER-14.2"));
			c.Add(new Component("Name of Coding System", "CER-14.3"));
			c.Add(new Component("Alternate Identifier", "CER-14.4"));
			c.Add(new Component("Alternate Text", "CER-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-14.6"));
			c.Add(new Component("Coding System Version ID", "CER-14.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-14.8"));
			c.Add(new Component("Original Text", "CER-14.9"));
			f.Components = c;
			return f;
		}
		private Field CER15()
		{
			Field f = new Field("Subject Public Key Info");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-15.1"));
			c.Add(new Component("", "CER-15.2"));
			c.Add(new Component("Name of Coding System", "CER-15.3"));
			c.Add(new Component("Alternate Identifier", "CER-15.4"));
			c.Add(new Component("Alternate Text", "CER-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-15.6"));
			c.Add(new Component("Coding System Version ID", "CER-15.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-15.8"));
			c.Add(new Component("Original Text", "CER-15.9"));
			f.Components = c;
			return f;
		}
		private Field CER16()
		{
			Field f = new Field("Authority Key Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-16.1"));
			c.Add(new Component("", "CER-16.2"));
			c.Add(new Component("Name of Coding System", "CER-16.3"));
			c.Add(new Component("Alternate Identifier", "CER-16.4"));
			c.Add(new Component("Alternate Text", "CER-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-16.6"));
			c.Add(new Component("Coding System Version ID", "CER-16.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-16.8"));
			c.Add(new Component("Original Text", "CER-16.9"));
			f.Components = c;
			return f;
		}
		private Field CER17()
		{
			Field f = new Field("Basic Constraint");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CER-17.1"));
			f.Components = c;
			return f;
		}
		private Field CER18()
		{
			Field f = new Field("CRL Distribution Point");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-18.1"));
			c.Add(new Component("", "CER-18.2"));
			c.Add(new Component("Name of Coding System", "CER-18.3"));
			c.Add(new Component("Alternate Identifier", "CER-18.4"));
			c.Add(new Component("Alternate Text", "CER-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-18.6"));
			c.Add(new Component("Coding System Version ID", "CER-18.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-18.8"));
			c.Add(new Component("Original Text", "CER-18.9"));
			f.Components = c;
			return f;
		}
		private Field CER19()
		{
			Field f = new Field("Jurisdiction Country");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "CER-19.1"));
			f.Components = c;
			return f;
		}
		private Field CER20()
		{
			Field f = new Field("Jurisdiction State/Province");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-20.1"));
			c.Add(new Component("", "CER-20.2"));
			c.Add(new Component("Name of Coding System", "CER-20.3"));
			c.Add(new Component("Alternate Identifier", "CER-20.4"));
			c.Add(new Component("Alternate Text", "CER-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-20.6"));
			c.Add(new Component("Coding System Version ID", "CER-20.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-20.8"));
			c.Add(new Component("Original Text", "CER-20.9"));
			f.Components = c;
			return f;
		}
		private Field CER21()
		{
			Field f = new Field("Jurisdiction County/Parish");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-21.1"));
			c.Add(new Component("", "CER-21.2"));
			c.Add(new Component("Name of Coding System", "CER-21.3"));
			c.Add(new Component("Alternate Identifier", "CER-21.4"));
			c.Add(new Component("Alternate Text", "CER-21.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-21.6"));
			c.Add(new Component("Coding System Version ID", "CER-21.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-21.8"));
			c.Add(new Component("Original Text", "CER-21.9"));
			f.Components = c;
			return f;
		}
		private Field CER22()
		{
			Field f = new Field("Jurisdiction Breadth");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-22.1"));
			c.Add(new Component("", "CER-22.2"));
			c.Add(new Component("Name of Coding System", "CER-22.3"));
			c.Add(new Component("Alternate Identifier", "CER-22.4"));
			c.Add(new Component("Alternate Text", "CER-22.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-22.6"));
			c.Add(new Component("Coding System Version ID", "CER-22.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-22.8"));
			c.Add(new Component("Original Text", "CER-22.9"));
			f.Components = c;
			return f;
		}
		private Field CER23()
		{
			Field f = new Field("Granting Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CER-23.1"));
			c.Add(new Component("Degree of Precision", "CER-23.2"));
			f.Components = c;
			return f;
		}
		private Field CER24()
		{
			Field f = new Field("Issuing Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CER-24.1"));
			c.Add(new Component("Degree of Precision", "CER-24.2"));
			f.Components = c;
			return f;
		}
		private Field CER25()
		{
			Field f = new Field("Activation Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CER-25.1"));
			c.Add(new Component("Degree of Precision", "CER-25.2"));
			f.Components = c;
			return f;
		}
		private Field CER26()
		{
			Field f = new Field("Inactivation Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CER-26.1"));
			c.Add(new Component("Degree of Precision", "CER-26.2"));
			f.Components = c;
			return f;
		}
		private Field CER27()
		{
			Field f = new Field("Expiration Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CER-27.1"));
			c.Add(new Component("Degree of Precision", "CER-27.2"));
			f.Components = c;
			return f;
		}
		private Field CER28()
		{
			Field f = new Field("Renewal Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CER-28.1"));
			c.Add(new Component("Degree of Precision", "CER-28.2"));
			f.Components = c;
			return f;
		}
		private Field CER29()
		{
			Field f = new Field("Revocation Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "CER-29.1"));
			c.Add(new Component("Degree of Precision", "CER-29.2"));
			f.Components = c;
			return f;
		}
		private Field CER30()
		{
			Field f = new Field("Revocation Reason Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-30.1"));
			c.Add(new Component("", "CER-30.2"));
			c.Add(new Component("Name of Coding System", "CER-30.3"));
			c.Add(new Component("Alternate Identifier", "CER-30.4"));
			c.Add(new Component("Alternate Text", "CER-30.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-30.6"));
			f.Components = c;
			return f;
		}
		private Field CER31()
		{
			Field f = new Field("Certificate Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "CER-31.1"));
			c.Add(new Component("", "CER-31.2"));
			c.Add(new Component("Name of Coding System", "CER-31.3"));
			c.Add(new Component("Alternate Identifier", "CER-31.4"));
			c.Add(new Component("Alternate Text", "CER-31.5"));
			c.Add(new Component("Name of Alternate Coding System", "CER-31.6"));
			c.Add(new Component("Coding System Version ID", "CER-31.7"));
			c.Add(new Component("Alternate Coding System Version ID", "CER-31.8"));
			c.Add(new Component("Original Text", "CER-31.9"));
			f.Components = c;
			return f;
		}
	}
}
