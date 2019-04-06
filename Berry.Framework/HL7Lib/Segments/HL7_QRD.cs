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
/// QRD Class: Constructs an HL7 QRD Segment Object
/// </summary>
public class QRD
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public QRD()
		{
			Name = "QRD";
			Description = "Original-Style Query Definition";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(QRD1());
			fs.Add(QRD2());
			fs.Add(QRD3());
			fs.Add(QRD4());
			fs.Add(QRD5());
			fs.Add(QRD6());
			fs.Add(QRD7());
			fs.Add(QRD8());
			fs.Add(QRD9());
			fs.Add(QRD10());
			fs.Add(QRD11());
			fs.Add(QRD12());
			Fields = fs;
		}
		private Field QRD1()
		{
			Field f = new Field("Query Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "QRD-1.1"));
			c.Add(new Component("Degree of Precision", "QRD-1.2"));
			f.Components = c;
			return f;
		}
		private Field QRD2()
		{
			Field f = new Field("Query Format Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRD-2.1"));
			f.Components = c;
			return f;
		}
		private Field QRD3()
		{
			Field f = new Field("Query Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRD-3.1"));
			f.Components = c;
			return f;
		}
		private Field QRD4()
		{
			Field f = new Field("Query ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRD-4.1"));
			f.Components = c;
			return f;
		}
		private Field QRD5()
		{
			Field f = new Field("Deferred Response Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRD-5.1"));
			f.Components = c;
			return f;
		}
		private Field QRD6()
		{
			Field f = new Field("Deferred Response Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "QRD-6.1"));
			c.Add(new Component("Degree of Precision", "QRD-6.2"));
			f.Components = c;
			return f;
		}
		private Field QRD7()
		{
			Field f = new Field("Quantity Limited Request");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "QRD-7.1"));
			c.Add(new Component("Units", "QRD-7.2"));
			f.Components = c;
			return f;
		}
		private Field QRD8()
		{
			Field f = new Field("Who Subject Filter");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "QRD-8.1"));
			c.Add(new Component("Family Name", "QRD-8.2"));
			c.Add(new Component("Given Name", "QRD-8.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "QRD-8.4"));
			c.Add(new Component("Suffix", "QRD-8.5"));
			c.Add(new Component("Prefix", "QRD-8.6"));
			c.Add(new Component("Degree", "QRD-8.7"));
			c.Add(new Component("Source Table", "QRD-8.8"));
			c.Add(new Component("Assigning Authority", "QRD-8.9"));
			c.Add(new Component("Name Type Code", "QRD-8.10"));
			c.Add(new Component("Identifier Check Digit", "QRD-8.11"));
			c.Add(new Component("Check Digit Scheme", "QRD-8.12"));
			c.Add(new Component("Identifier Type Code", "QRD-8.13"));
			c.Add(new Component("Assigning Facility", "QRD-8.14"));
			c.Add(new Component("Name Respresentation Code", "QRD-8.15"));
			c.Add(new Component("Name Context", "QRD-8.16"));
			c.Add(new Component("Name Validity Range", "QRD-8.17"));
			c.Add(new Component("Name Assembly Order", "QRD-8.18"));
			c.Add(new Component("Effective Date", "QRD-8.19"));
			c.Add(new Component("Expiration Date", "QRD-8.20"));
			c.Add(new Component("Professional Suffix", "QRD-8.21"));
			c.Add(new Component("Assigning Jurisdiction", "QRD-8.22"));
			c.Add(new Component("Assigning Agency or Department", "QRD-8.23"));
			f.Components = c;
			return f;
		}
		private Field QRD9()
		{
			Field f = new Field("What Subject Filter");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "QRD-9.1"));
			c.Add(new Component("", "QRD-9.2"));
			c.Add(new Component("Name of Coding System", "QRD-9.3"));
			c.Add(new Component("Alternate Identifier", "QRD-9.4"));
			c.Add(new Component("Alternate Text", "QRD-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "QRD-9.6"));
			f.Components = c;
			return f;
		}
		private Field QRD10()
		{
			Field f = new Field("What Department Data Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "QRD-10.1"));
			c.Add(new Component("", "QRD-10.2"));
			c.Add(new Component("Name of Coding System", "QRD-10.3"));
			c.Add(new Component("Alternate Identifier", "QRD-10.4"));
			c.Add(new Component("Alternate Text", "QRD-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "QRD-10.6"));
			f.Components = c;
			return f;
		}
		private Field QRD11()
		{
			Field f = new Field("What Data Code Value Qual.");
			List<Component> c = new List<Component>();
			c.Add(new Component("First Data Code Value", "QRD-11.1"));
			c.Add(new Component("Last Data Code Value", "QRD-11.2"));
			f.Components = c;
			return f;
		}
		private Field QRD12()
		{
			Field f = new Field("Query Results Level");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRD-12.1"));
			f.Components = c;
			return f;
		}
	}
}
