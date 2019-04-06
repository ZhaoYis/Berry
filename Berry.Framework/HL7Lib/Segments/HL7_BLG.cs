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
/// BLG Class: Constructs an HL7 BLG Segment Object
/// </summary>
public class BLG
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public BLG()
		{
			Name = "BLG";
			Description = "Billing";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(BLG1());
			fs.Add(BLG2());
			fs.Add(BLG3());
			fs.Add(BLG4());
			Fields = fs;
		}
		private Field BLG1()
		{
			Field f = new Field("When to Charge");
			List<Component> c = new List<Component>();
			c.Add(new Component("Invocation Event", "BLG-1.1"));
			c.Add(new Component("", "BLG-1.2"));
			f.Components = c;
			return f;
		}
		private Field BLG2()
		{
			Field f = new Field("Charge Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "BLG-2.1"));
			f.Components = c;
			return f;
		}
		private Field BLG3()
		{
			Field f = new Field("Account ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "BLG-3.1"));
			c.Add(new Component("Check Digit", "BLG-3.2"));
			c.Add(new Component("Check Digit Scheme", "BLG-3.3"));
			c.Add(new Component("Assigning Authority", "BLG-3.4"));
			c.Add(new Component("Identifier Type Code", "BLG-3.5"));
			c.Add(new Component("Assigning Facility", "BLG-3.6"));
			c.Add(new Component("Effective Date", "BLG-3.7"));
			c.Add(new Component("Expiration Date", "BLG-3.8"));
			c.Add(new Component("Assigning Jurisdiction", "BLG-3.9"));
			c.Add(new Component("Assigning Agency or Department", "BLG-3.10"));
			f.Components = c;
			return f;
		}
		private Field BLG4()
		{
			Field f = new Field("Charge Type Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "BLG-4.1"));
			c.Add(new Component("", "BLG-4.2"));
			c.Add(new Component("Name of Coding System", "BLG-4.3"));
			c.Add(new Component("Alternate Identifier", "BLG-4.4"));
			c.Add(new Component("Alternate Text", "BLG-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "BLG-4.6"));
			c.Add(new Component("Coding System Version ID", "BLG-4.7"));
			c.Add(new Component("Alternate Coding System Version ID", "BLG-4.8"));
			c.Add(new Component("Original Text", "BLG-4.9"));
			f.Components = c;
			return f;
		}
	}
}
