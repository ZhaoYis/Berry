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
/// QRF Class: Constructs an HL7 QRF Segment Object
/// </summary>
public class QRF
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public QRF()
		{
			Name = "QRF";
			Description = "Original style query filter";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(QRF1());
			fs.Add(QRF2());
			fs.Add(QRF3());
			fs.Add(QRF4());
			fs.Add(QRF5());
			fs.Add(QRF6());
			fs.Add(QRF7());
			fs.Add(QRF8());
			fs.Add(QRF9());
			fs.Add(QRF10());
			Fields = fs;
		}
		private Field QRF1()
		{
			Field f = new Field("Where Subject Filter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRF-1.1"));
			f.Components = c;
			return f;
		}
		private Field QRF2()
		{
			Field f = new Field("When Data Start Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "QRF-2.1"));
			c.Add(new Component("Degree of Precision", "QRF-2.2"));
			f.Components = c;
			return f;
		}
		private Field QRF3()
		{
			Field f = new Field("When Data End Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "QRF-3.1"));
			c.Add(new Component("Degree of Precision", "QRF-3.2"));
			f.Components = c;
			return f;
		}
		private Field QRF4()
		{
			Field f = new Field("What User Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRF-4.1"));
			f.Components = c;
			return f;
		}
		private Field QRF5()
		{
			Field f = new Field("Other QRY Subject Filter");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRF-5.1"));
			f.Components = c;
			return f;
		}
		private Field QRF6()
		{
			Field f = new Field("Which Date/Time Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRF-6.1"));
			f.Components = c;
			return f;
		}
		private Field QRF7()
		{
			Field f = new Field("Which Date/Time Status Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRF-7.1"));
			f.Components = c;
			return f;
		}
		private Field QRF8()
		{
			Field f = new Field("Date/Time Selection Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRF-8.1"));
			f.Components = c;
			return f;
		}
		private Field QRF9()
		{
			Field f = new Field("When Quantity/Timing Qualifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "QRF-9.1"));
			c.Add(new Component("Interval", "QRF-9.2"));
			c.Add(new Component("Duration", "QRF-9.3"));
			c.Add(new Component("Start Date/Time", "QRF-9.4"));
			c.Add(new Component("End Date Time", "QRF-9.5"));
			c.Add(new Component("Priority", "QRF-9.6"));
			c.Add(new Component("Condition", "QRF-9.7"));
			c.Add(new Component("", "QRF-9.8"));
			c.Add(new Component("Conjunction", "QRF-9.9"));
			c.Add(new Component("Order Sequencing", "QRF-9.10"));
			c.Add(new Component("Occurrence Duration", "QRF-9.11"));
			c.Add(new Component("Total Occurrences", "QRF-9.12"));
			f.Components = c;
			return f;
		}
		private Field QRF10()
		{
			Field f = new Field("Search Confidence Threshold");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "QRF-10.1"));
			f.Components = c;
			return f;
		}
	}
}
