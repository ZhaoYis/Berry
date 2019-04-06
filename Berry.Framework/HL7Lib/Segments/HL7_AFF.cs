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
    /// AFF Class: Constructs an HL7 AFF Segment Object
    /// </summary>
	public class AFF
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public AFF()
		{
			Name = "AFF";
			Description = "Professional Affiliation";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(AFF1());
			fs.Add(AFF2());
			fs.Add(AFF3());
			fs.Add(AFF4());
			fs.Add(AFF5());
			Fields = fs;
		}
		private Field AFF1()
		{
			Field f = new Field("Set ID _ AFF");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "AFF-1.1"));
			f.Components = c;
			return f;
		}
		private Field AFF2()
		{
			Field f = new Field("Professional Organization");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "AFF-2.1"));
			c.Add(new Component("Organization Name Type Code", "AFF-2.2"));
			c.Add(new Component("ID Number", "AFF-2.3"));
			c.Add(new Component("Check Digit", "AFF-2.4"));
			c.Add(new Component("Check Digit Scheme", "AFF-2.5"));
			c.Add(new Component("Assigning Authority", "AFF-2.6"));
			c.Add(new Component("Identifier Type Code", "AFF-2.7"));
			c.Add(new Component("Assigning Facility", "AFF-2.8"));
			c.Add(new Component("Name Respresentation Code", "AFF-2.9"));
			c.Add(new Component("Organization Identifier", "AFF-2.10"));
			f.Components = c;
			return f;
		}
		private Field AFF3()
		{
			Field f = new Field("Professional Organization Address");
			List<Component> c = new List<Component>();
			c.Add(new Component("Street Address", "AFF-3.1"));
			c.Add(new Component("Other Designation", "AFF-3.2"));
			c.Add(new Component("City", "AFF-3.3"));
			c.Add(new Component("State or Province", "AFF-3.4"));
			c.Add(new Component("Zip or Postal Code", "AFF-3.5"));
			c.Add(new Component("Country", "AFF-3.6"));
			c.Add(new Component("Address Type", "AFF-3.7"));
			c.Add(new Component("Other Geographic Designation", "AFF-3.8"));
			c.Add(new Component("Country Parish Code", "AFF-3.9"));
			c.Add(new Component("Census Tract", "AFF-3.10"));
			c.Add(new Component("Address Representation Code", "AFF-3.11"));
			c.Add(new Component("Address Validity Range", "AFF-3.12"));
			c.Add(new Component("Effective Date", "AFF-3.13"));
			c.Add(new Component("Expiration Date", "AFF-3.14"));
			f.Components = c;
			return f;
		}
		private Field AFF4()
		{
			Field f = new Field("Professional Organization Affiliation Date Range");
			List<Component> c = new List<Component>();
			c.Add(new Component("Range Start Date/Time", "AFF-4.1"));
			c.Add(new Component("Range End Date/Time", "AFF-4.2"));
			f.Components = c;
			return f;
		}
		private Field AFF5()
		{
			Field f = new Field("Professional Affiliation Additional Information");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "AFF-5.1"));
			f.Components = c;
			return f;
		}
	}
}
