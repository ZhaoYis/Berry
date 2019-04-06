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
/// RF1 Class: Constructs an HL7 RF1 Segment Object
/// </summary>
public class RF1
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public RF1()
		{
			Name = "RF1";
			Description = "Referral Information";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(RF11());
			fs.Add(RF12());
			fs.Add(RF13());
			fs.Add(RF14());
			fs.Add(RF15());
			fs.Add(RF16());
			fs.Add(RF17());
			fs.Add(RF18());
			fs.Add(RF19());
			fs.Add(RF110());
			fs.Add(RF111());
			Fields = fs;
		}
		private Field RF11()
		{
			Field f = new Field("Referral Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RF1-1.1"));
			c.Add(new Component("", "RF1-1.2"));
			c.Add(new Component("Name of Coding System", "RF1-1.3"));
			c.Add(new Component("Alternate Identifier", "RF1-1.4"));
			c.Add(new Component("Alternate Text", "RF1-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "RF1-1.6"));
			f.Components = c;
			return f;
		}
		private Field RF12()
		{
			Field f = new Field("Referral Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RF1-2.1"));
			c.Add(new Component("", "RF1-2.2"));
			c.Add(new Component("Name of Coding System", "RF1-2.3"));
			c.Add(new Component("Alternate Identifier", "RF1-2.4"));
			c.Add(new Component("Alternate Text", "RF1-2.5"));
			c.Add(new Component("Name of Alternate Coding System", "RF1-2.6"));
			f.Components = c;
			return f;
		}
		private Field RF13()
		{
			Field f = new Field("Referral Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RF1-3.1"));
			c.Add(new Component("", "RF1-3.2"));
			c.Add(new Component("Name of Coding System", "RF1-3.3"));
			c.Add(new Component("Alternate Identifier", "RF1-3.4"));
			c.Add(new Component("Alternate Text", "RF1-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "RF1-3.6"));
			f.Components = c;
			return f;
		}
		private Field RF14()
		{
			Field f = new Field("Referral Disposition");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RF1-4.1"));
			c.Add(new Component("", "RF1-4.2"));
			c.Add(new Component("Name of Coding System", "RF1-4.3"));
			c.Add(new Component("Alternate Identifier", "RF1-4.4"));
			c.Add(new Component("Alternate Text", "RF1-4.5"));
			c.Add(new Component("Name of Alternate Coding System", "RF1-4.6"));
			f.Components = c;
			return f;
		}
		private Field RF15()
		{
			Field f = new Field("Referral Category");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RF1-5.1"));
			c.Add(new Component("", "RF1-5.2"));
			c.Add(new Component("Name of Coding System", "RF1-5.3"));
			c.Add(new Component("Alternate Identifier", "RF1-5.4"));
			c.Add(new Component("Alternate Text", "RF1-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "RF1-5.6"));
			f.Components = c;
			return f;
		}
		private Field RF16()
		{
			Field f = new Field("Originating Referral Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "RF1-6.1"));
			c.Add(new Component("Namespace ID", "RF1-6.2"));
			c.Add(new Component("Universal ID", "RF1-6.3"));
			c.Add(new Component("Universal ID Type", "RF1-6.4"));
			f.Components = c;
			return f;
		}
		private Field RF17()
		{
			Field f = new Field("Effective Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RF1-7.1"));
			c.Add(new Component("Degree of Precision", "RF1-7.2"));
			f.Components = c;
			return f;
		}
		private Field RF18()
		{
			Field f = new Field("Expiration Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RF1-8.1"));
			c.Add(new Component("Degree of Precision", "RF1-8.2"));
			f.Components = c;
			return f;
		}
		private Field RF19()
		{
			Field f = new Field("Process Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "RF1-9.1"));
			c.Add(new Component("Degree of Precision", "RF1-9.2"));
			f.Components = c;
			return f;
		}
		private Field RF110()
		{
			Field f = new Field("Referral Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "RF1-10.1"));
			c.Add(new Component("", "RF1-10.2"));
			c.Add(new Component("Name of Coding System", "RF1-10.3"));
			c.Add(new Component("Alternate Identifier", "RF1-10.4"));
			c.Add(new Component("Alternate Text", "RF1-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "RF1-10.6"));
			f.Components = c;
			return f;
		}
		private Field RF111()
		{
			Field f = new Field("External Referral Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "RF1-11.1"));
			c.Add(new Component("Namespace ID", "RF1-11.2"));
			c.Add(new Component("Universal ID", "RF1-11.3"));
			c.Add(new Component("Universal ID Type", "RF1-11.4"));
			f.Components = c;
			return f;
		}
	}
}
