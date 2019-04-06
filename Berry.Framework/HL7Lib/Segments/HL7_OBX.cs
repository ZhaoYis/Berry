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
/// OBX Class: Constructs an HL7 OBX Segment Object
/// </summary>
public class OBX
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public OBX()
		{
			Name = "OBX";
			Description = "Observation/Result";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(OBX1());
			fs.Add(OBX2());
			fs.Add(OBX3());
			fs.Add(OBX4());
            fs.Add(OBX5());
			fs.Add(OBX6());
			fs.Add(OBX7());
			fs.Add(OBX8());
			fs.Add(OBX9());
			fs.Add(OBX10());
			fs.Add(OBX11());
			fs.Add(OBX12());
			fs.Add(OBX13());
			fs.Add(OBX14());
			fs.Add(OBX15());
			fs.Add(OBX16());
			fs.Add(OBX17());
			fs.Add(OBX18());
			fs.Add(OBX19());
			Fields = fs;
		}
		private Field OBX1()
		{
			Field f = new Field("Set ID - OBX");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "OBX-1.1"));
			f.Components = c;
			return f;
		}
		private Field OBX2()
		{
			Field f = new Field("Value Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBX-2.1"));
			f.Components = c;
			return f;
		}
		private Field OBX3()
		{
			Field f = new Field("Observation Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBX-3.1"));
			c.Add(new Component("", "OBX-3.2"));
			c.Add(new Component("Name of Coding System", "OBX-3.3"));
			c.Add(new Component("Alternate Identifier", "OBX-3.4"));
			c.Add(new Component("Alternate Text", "OBX-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBX-3.6"));
			f.Components = c;
			return f;
		}
		private Field OBX4()
		{
			Field f = new Field("Observation Sub-ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBX-4.1"));
			f.Components = c;
			return f;
		}
        private Field OBX5()
        {
            Field f = new Field("Observation Value");
            List<Component> c = new List<Component>();
            c.Add(new Component("", "OBX-5.1"));
            c.Add(new Component("Value", "OBX-5.2"));
            f.Components = c;
            return f;

        }
		private Field OBX6()
		{
			Field f = new Field("Units");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBX-6.1"));
			c.Add(new Component("", "OBX-6.2"));
			c.Add(new Component("Name of Coding System", "OBX-6.3"));
			c.Add(new Component("Alternate Identifier", "OBX-6.4"));
			c.Add(new Component("Alternate Text", "OBX-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBX-6.6"));
			f.Components = c;
			return f;
		}
		private Field OBX7()
		{
			Field f = new Field("References Range");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBX-7.1"));
			f.Components = c;
			return f;
		}
		private Field OBX8()
		{
			Field f = new Field("Abnormal Flags");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBX-8.1"));
			f.Components = c;
			return f;
		}
		private Field OBX9()
		{
			Field f = new Field("Probability");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBX-9.1"));
			f.Components = c;
			return f;
		}
		private Field OBX10()
		{
			Field f = new Field("Nature of Abnormal Test");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBX-10.1"));
			f.Components = c;
			return f;
		}
		private Field OBX11()
		{
			Field f = new Field("Observation Result Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBX-11.1"));
			f.Components = c;
			return f;
		}
		private Field OBX12()
		{
			Field f = new Field("Effective Date of Reference Range");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBX-12.1"));
			c.Add(new Component("Degree of Precision", "OBX-11.2"));
			f.Components = c;
			return f;
		}
		private Field OBX13()
		{
			Field f = new Field("User Defined Access Checks");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "OBX-13.1"));
			f.Components = c;
			return f;
		}
		private Field OBX14()
		{
			Field f = new Field("Date/Time of the Observation");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBX-14.1"));
			c.Add(new Component("Degree of Precision", "OBX-14.2"));
			f.Components = c;
			return f;
		}
		private Field OBX15()
		{
			Field f = new Field("Producer's ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBX-15.1"));
			c.Add(new Component("", "OBX-15.2"));
			c.Add(new Component("Name of Coding System", "OBX-15.3"));
			c.Add(new Component("Alternate Identifier", "OBX-15.4"));
			c.Add(new Component("Alternate Text", "OBX-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBX-15.6"));
			f.Components = c;
			return f;
		}
		private Field OBX16()
		{
			Field f = new Field("Responsible Observer");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "OBX-16.1"));
			c.Add(new Component("Family Name", "OBX-16.2"));
			c.Add(new Component("Given Name", "OBX-16.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "OBX-16.4"));
			c.Add(new Component("Suffix", "OBX-16.5"));
			c.Add(new Component("Prefix", "OBX-16.6"));
			c.Add(new Component("Degree", "OBX-16.7"));
			c.Add(new Component("Source Table", "OBX-16.8"));
			c.Add(new Component("Assigning Authority", "OBX-16.9"));
			c.Add(new Component("Name Type Code", "OBX-16.10"));
			c.Add(new Component("Identifier Check Digit", "OBX-16.11"));
			c.Add(new Component("Check Digit Scheme", "OBX-16.12"));
			c.Add(new Component("Identifier Type Code", "OBX-16.13"));
			c.Add(new Component("Assigning Facility", "OBX-16.14"));
			c.Add(new Component("Name Respresentation Code", "OBX-16.15"));
			c.Add(new Component("Name Context", "OBX-16.16"));
			c.Add(new Component("Name Validity Range", "OBX-16.17"));
			c.Add(new Component("Name Assembly Order", "OBX-16.18"));
			c.Add(new Component("Effective Date", "OBX-16.19"));
			c.Add(new Component("Expiration Date", "OBX-16.20"));
			c.Add(new Component("Professional Suffix", "OBX-16.21"));
			c.Add(new Component("Assigning Jurisdiction", "OBX-16.22"));
			c.Add(new Component("Assigning Agency or Department", "OBX-16.23"));
			f.Components = c;
			return f;
		}
		private Field OBX17()
		{
			Field f = new Field("Observation Method");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "OBX-17.1"));
			c.Add(new Component("", "OBX-17.2"));
			c.Add(new Component("Name of Coding System", "OBX-17.3"));
			c.Add(new Component("Alternate Identifier", "OBX-17.4"));
			c.Add(new Component("Alternate Text", "OBX-17.5"));
			c.Add(new Component("Name of Alternate Coding System", "OBX-17.6"));
			f.Components = c;
			return f;
		}
		private Field OBX18()
		{
			Field f = new Field("Equipment Instance Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "OBX-18.1"));
			c.Add(new Component("Namespace ID", "OBX-18.2"));
			c.Add(new Component("Universal ID", "OBX-18.3"));
			c.Add(new Component("Universal ID Type", "OBX-18.4"));
			f.Components = c;
			return f;
		}
		private Field OBX19()
		{
			Field f = new Field("Date/Time of the Analysis");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "OBX-19.1"));
			c.Add(new Component("Degree of Precision", "OBX-19.2"));
			f.Components = c;
			return f;
		}
	}
}
