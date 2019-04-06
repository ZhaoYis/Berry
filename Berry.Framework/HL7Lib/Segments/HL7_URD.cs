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
/// URD Class: Constructs an HL7 URD Segment Object
/// </summary>
public class URD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public URD()
		{
			Name = "URD";
			Description = "Results/update Definition";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(URD1());
			fs.Add(URD2());
			fs.Add(URD3());
			fs.Add(URD4());
			fs.Add(URD5());
			fs.Add(URD6());
			fs.Add(URD7());
			Fields = fs;
		}
		private Field URD1()
		{
			Field f = new Field("R/U Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "URD-1.1"));
			c.Add(new Component("Degree of Precision", "URD-1.2"));
			f.Components = c;
			return f;
		}
		private Field URD2()
		{
			Field f = new Field("Report Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URD-2.1"));
			f.Components = c;
			return f;
		}
		private Field URD3()
		{
			Field f = new Field("R/U Who Subject Definition");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "URD-3.1"));
			c.Add(new Component("Family Name", "URD-3.2"));
			c.Add(new Component("Given Name", "URD-3.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "URD-3.4"));
			c.Add(new Component("Suffix", "URD-3.5"));
			c.Add(new Component("Prefix", "URD-3.6"));
			c.Add(new Component("Degree", "URD-3.7"));
			c.Add(new Component("Source Table", "URD-3.8"));
			c.Add(new Component("Assigning Authority", "URD-3.9"));
			c.Add(new Component("Name Type Code", "URD-3.10"));
			c.Add(new Component("Identifier Check Digit", "URD-3.11"));
			c.Add(new Component("Check Digit Scheme", "URD-3.12"));
			c.Add(new Component("Identifier Type Code", "URD-3.13"));
			c.Add(new Component("Assigning Facility", "URD-3.14"));
			c.Add(new Component("Name Respresentation Code", "URD-3.15"));
			c.Add(new Component("Name Context", "URD-3.16"));
			c.Add(new Component("Name Validity Range", "URD-3.17"));
			c.Add(new Component("Name Assembly Order", "URD-3.18"));
			c.Add(new Component("Effective Date", "URD-3.19"));
			c.Add(new Component("Expiration Date", "URD-3.20"));
			c.Add(new Component("Professional Suffix", "URD-3.21"));
			c.Add(new Component("Assigning Jurisdiction", "URD-3.22"));
			c.Add(new Component("Assigning Agency or Department", "URD-3.23"));
			f.Components = c;
			return f;
		}
		private Field URD4()
		{
			Field f = new Field("R/U What Subject Definition");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "URD-4.1"));
			c.Add(new Component("", "URD-4.2"));
			c.Add(new Component("Name of Coding System", "URD-4.3"));
			c.Add(new Component("Alternate Identifier", "URD-4.4"));
			c.Add(new Component("Alternate Text", "URD-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "URD-4.6"));
			f.Components = c;
			return f;
		}
		private Field URD5()
		{
			Field f = new Field("R/U What Department Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "URD-5.1"));
			c.Add(new Component("", "URD-5.2"));
			c.Add(new Component("Name of Coding System", "URD-5.3"));
			c.Add(new Component("Alternate Identifier", "URD-5.4"));
			c.Add(new Component("Alternate Text", "URD-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "URD-5.6"));
			f.Components = c;
			return f;
		}
		private Field URD6()
		{
			Field f = new Field("R/U Display/Print Locations");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URD-6.1"));
			f.Components = c;
			return f;
		}
		private Field URD7()
		{
			Field f = new Field("R/U Results Level");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "URD-7.1"));
			f.Components = c;
			return f;
		}
	}
}
