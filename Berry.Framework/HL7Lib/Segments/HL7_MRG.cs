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
/// MRG Class: Constructs an HL7 MRG Segment Object
/// </summary>
public class MRG
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public MRG()
		{
			Name = "MRG";
			Description = "Merge Patient Information";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(MRG1());
			fs.Add(MRG2());
			fs.Add(MRG3());
			fs.Add(MRG4());
			fs.Add(MRG5());
			fs.Add(MRG6());
			fs.Add(MRG7());
			Fields = fs;
		}
		private Field MRG1()
		{
			Field f = new Field("Prior Patient Identifier List");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "MRG-1.1"));
			c.Add(new Component("Check Digit", "MRG-1.2"));
			c.Add(new Component("Check Digit Scheme", "MRG-1.3"));
			c.Add(new Component("Assigning Authority", "MRG-1.4"));
			c.Add(new Component("Identifier Type Code", "MRG-1.5"));
			c.Add(new Component("Assigning Facility", "MRG-1.6"));
			c.Add(new Component("Effective Date", "MRG-1.7"));
			c.Add(new Component("Expiration Date", "MRG-1.8"));
			c.Add(new Component("Assigning Jurisdiction", "MRG-1.9"));
			c.Add(new Component("Assigning Agency or Department", "MRG-1.10"));
			f.Components = c;
			return f;
		}
		private Field MRG2()
		{
			Field f = new Field("Prior Alternate Patient ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "MRG-2.1"));
			c.Add(new Component("Check Digit", "MRG-2.2"));
			c.Add(new Component("Check Digit Scheme", "MRG-2.3"));
			c.Add(new Component("Assigning Authority", "MRG-2.4"));
			c.Add(new Component("Identifier Type Code", "MRG-2.5"));
			c.Add(new Component("Assigning Facility", "MRG-2.6"));
			c.Add(new Component("Effective Date", "MRG-2.7"));
			c.Add(new Component("Expiration Date", "MRG-2.8"));
			c.Add(new Component("Assigning Jurisdiction", "MRG-2.9"));
			c.Add(new Component("Assigning Agency or Department", "MRG-2.10"));
			f.Components = c;
			return f;
		}
		private Field MRG3()
		{
			Field f = new Field("Prior Patient Account Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "MRG-3.1"));
			c.Add(new Component("Check Digit", "MRG-3.2"));
			c.Add(new Component("Check Digit Scheme", "MRG-3.3"));
			c.Add(new Component("Assigning Authority", "MRG-3.4"));
			c.Add(new Component("Identifier Type Code", "MRG-3.5"));
			c.Add(new Component("Assigning Facility", "MRG-3.6"));
			c.Add(new Component("Effective Date", "MRG-3.7"));
			c.Add(new Component("Expiration Date", "MRG-3.8"));
			c.Add(new Component("Assigning Jurisdiction", "MRG-3.9"));
			c.Add(new Component("Assigning Agency or Department", "MRG-3.10"));
			f.Components = c;
			return f;
		}
		private Field MRG4()
		{
			Field f = new Field("Prior Patient ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "MRG-4.1"));
			c.Add(new Component("Check Digit", "MRG-4.2"));
			c.Add(new Component("Check Digit Scheme", "MRG-4.3"));
			c.Add(new Component("Assigning Authority", "MRG-4.4"));
			c.Add(new Component("Identifier Type Code", "MRG-4.5"));
			c.Add(new Component("Assigning Facility", "MRG-4.6"));
			c.Add(new Component("Effective Date", "MRG-4.7"));
			c.Add(new Component("Expiration Date", "MRG-4.8"));
			c.Add(new Component("Assigning Jurisdiction", "MRG-4.9"));
			c.Add(new Component("Assigning Agency or Department", "MRG-4.10"));
			f.Components = c;
			return f;
		}
		private Field MRG5()
		{
			Field f = new Field("Prior Visit Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "MRG-5.1"));
			c.Add(new Component("Check Digit", "MRG-5.2"));
			c.Add(new Component("Check Digit Scheme", "MRG-5.3"));
			c.Add(new Component("Assigning Authority", "MRG-5.4"));
			c.Add(new Component("Identifier Type Code", "MRG-5.5"));
			c.Add(new Component("Assigning Facility", "MRG-5.6"));
			c.Add(new Component("Effective Date", "MRG-5.7"));
			c.Add(new Component("Expiration Date", "MRG-5.8"));
			c.Add(new Component("Assigning Jurisdiction", "MRG-5.9"));
			c.Add(new Component("Assigning Agency or Department", "MRG-5.10"));
			f.Components = c;
			return f;
		}
		private Field MRG6()
		{
			Field f = new Field("Prior Alternate Visit ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "MRG-6.1"));
			c.Add(new Component("Check Digit", "MRG-6.2"));
			c.Add(new Component("Check Digit Scheme", "MRG-6.3"));
			c.Add(new Component("Assigning Authority", "MRG-6.4"));
			c.Add(new Component("Identifier Type Code", "MRG-6.5"));
			c.Add(new Component("Assigning Facility", "MRG-6.6"));
			c.Add(new Component("Effective Date", "MRG-6.7"));
			c.Add(new Component("Expiration Date", "MRG-6.8"));
			c.Add(new Component("Assigning Jurisdiction", "MRG-6.9"));
			c.Add(new Component("Assigning Agency or Department", "MRG-6.10"));
			f.Components = c;
			return f;
		}
		private Field MRG7()
		{
			Field f = new Field("Prior Patient Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "MRG-7.1"));
			c.Add(new Component("Given Name", "MRG-7.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "MRG-7.3"));
			c.Add(new Component("Suffix", "MRG-7.4"));
			c.Add(new Component("Prefix", "MRG-7.5"));
			c.Add(new Component("Degree", "MRG-7.6"));
			c.Add(new Component("Name Type Code", "MRG-7.7"));
			c.Add(new Component("Name Respresentation Code", "MRG-7.8"));
			c.Add(new Component("Name Context", "MRG-7.9"));
			c.Add(new Component("Name Validity Range", "MRG-7.10"));
			c.Add(new Component("Name Assembly Order", "MRG-7.11"));
			c.Add(new Component("Effective Date", "MRG-7.12"));
			c.Add(new Component("Expiration Date", "MRG-7.13"));
			c.Add(new Component("Professional Suffix", "MRG-7.14"));
			f.Components = c;
			return f;
		}
	}
}
