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
/// GOL Class: Constructs an HL7 GOL Segment Object
/// </summary>
public class GOL
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public GOL()
		{
			Name = "GOL";
			Description = "Goal Detail";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(GOL1());
			fs.Add(GOL2());
			fs.Add(GOL3());
			fs.Add(GOL4());
			fs.Add(GOL5());
			fs.Add(GOL6());
			fs.Add(GOL7());
			fs.Add(GOL8());
			fs.Add(GOL9());
			fs.Add(GOL10());
			fs.Add(GOL11());
			fs.Add(GOL12());
			fs.Add(GOL13());
			fs.Add(GOL14());
			fs.Add(GOL15());
			fs.Add(GOL16());
			fs.Add(GOL17());
			fs.Add(GOL18());
			fs.Add(GOL19());
			fs.Add(GOL20());
			fs.Add(GOL21());
			Fields = fs;
		}
		private Field GOL1()
		{
			Field f = new Field("Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GOL-1.1"));
			f.Components = c;
			return f;
		}
		private Field GOL2()
		{
			Field f = new Field("Action Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GOL-2.1"));
			c.Add(new Component("Degree of Precision", "GOL-2.2"));
			f.Components = c;
			return f;
		}
		private Field GOL3()
		{
			Field f = new Field("Goal ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GOL-3.1"));
			c.Add(new Component("", "GOL-3.2"));
			c.Add(new Component("Name of Coding System", "GOL-3.3"));
			c.Add(new Component("Alternate Identifier", "GOL-3.4"));
			c.Add(new Component("Alternate Text", "GOL-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "GOL-3.6"));
			f.Components = c;
			return f;
		}
		private Field GOL4()
		{
			Field f = new Field("Goal Instance ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "GOL-4.1"));
			c.Add(new Component("Namespace ID", "GOL-4.2"));
			c.Add(new Component("Universal ID", "GOL-4.3"));
			c.Add(new Component("Universal ID Type", "GOL-4.4"));
			f.Components = c;
			return f;
		}
		private Field GOL5()
		{
			Field f = new Field("Episode of Care ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "GOL-5.1"));
			c.Add(new Component("Namespace ID", "GOL-5.2"));
			c.Add(new Component("Universal ID", "GOL-5.3"));
			c.Add(new Component("Universal ID Type", "GOL-5.4"));
			f.Components = c;
			return f;
		}
		private Field GOL6()
		{
			Field f = new Field("Goal List Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GOL-6.1"));
			f.Components = c;
			return f;
		}
		private Field GOL7()
		{
			Field f = new Field("Goal Established Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GOL-7.1"));
			c.Add(new Component("Degree of Precision", "GOL-7.2"));
			f.Components = c;
			return f;
		}
		private Field GOL8()
		{
			Field f = new Field("Expected Goal Achieve Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GOL-8.1"));
			c.Add(new Component("Degree of Precision", "GOL-8.2"));
			f.Components = c;
			return f;
		}
		private Field GOL9()
		{
			Field f = new Field("Goal Classification");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GOL-9.1"));
			c.Add(new Component("", "GOL-9.2"));
			c.Add(new Component("Name of Coding System", "GOL-9.3"));
			c.Add(new Component("Alternate Identifier", "GOL-9.4"));
			c.Add(new Component("Alternate Text", "GOL-9.5"));
			c.Add(new Component("Name of Alternate Coding System", "GOL-9.6"));
			f.Components = c;
			return f;
		}
		private Field GOL10()
		{
			Field f = new Field("Goal Management Discipline");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GOL-10.1"));
			c.Add(new Component("", "GOL-10.2"));
			c.Add(new Component("Name of Coding System", "GOL-10.3"));
			c.Add(new Component("Alternate Identifier", "GOL-10.4"));
			c.Add(new Component("Alternate Text", "GOL-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "GOL-10.6"));
			f.Components = c;
			return f;
		}
		private Field GOL11()
		{
			Field f = new Field("Current Goal Review Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GOL-11.1"));
			c.Add(new Component("", "GOL-11.2"));
			c.Add(new Component("Name of Coding System", "GOL-11.3"));
			c.Add(new Component("Alternate Identifier", "GOL-11.4"));
			c.Add(new Component("Alternate Text", "GOL-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "GOL-11.6"));
			f.Components = c;
			return f;
		}
		private Field GOL12()
		{
			Field f = new Field("Current Goal Review Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GOL-12.1"));
			c.Add(new Component("Degree of Precision", "GOL-12.2"));
			f.Components = c;
			return f;
		}
		private Field GOL13()
		{
			Field f = new Field("Next Goal Review Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GOL-13.1"));
			c.Add(new Component("Degree of Precision", "GOL-13.2"));
			f.Components = c;
			return f;
		}
		private Field GOL14()
		{
			Field f = new Field("Previous Goal Review Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GOL-14.1"));
			c.Add(new Component("Degree of Precision", "GOL-14.2"));
			f.Components = c;
			return f;
		}
		private Field GOL15()
		{
			Field f = new Field("Goal Review Interval");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "GOL-15.1"));
			c.Add(new Component("Interval", "GOL-15.2"));
			c.Add(new Component("Duration", "GOL-15.3"));
			c.Add(new Component("Start Date/Time", "GOL-15.4"));
			c.Add(new Component("End Date Time", "GOL-15.5"));
			c.Add(new Component("Priority", "GOL-15.6"));
			c.Add(new Component("Condition", "GOL-15.7"));
			c.Add(new Component("", "GOL-15.8"));
			c.Add(new Component("Conjunction", "GOL-15.9"));
			c.Add(new Component("Order Sequencing", "GOL-15.10"));
			c.Add(new Component("Occurrence Duration", "GOL-15.11"));
			c.Add(new Component("Total Occurrences", "GOL-15.12"));
			f.Components = c;
			return f;
		}
		private Field GOL16()
		{
			Field f = new Field("Goal Evaluation");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GOL-16.1"));
			c.Add(new Component("", "GOL-16.2"));
			c.Add(new Component("Name of Coding System", "GOL-16.3"));
			c.Add(new Component("Alternate Identifier", "GOL-16.4"));
			c.Add(new Component("Alternate Text", "GOL-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "GOL-16.6"));
			f.Components = c;
			return f;
		}
		private Field GOL17()
		{
			Field f = new Field("Goal Evaluation Comment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "GOL-17.1"));
			f.Components = c;
			return f;
		}
		private Field GOL18()
		{
			Field f = new Field("Goal Life Cycle Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GOL-18.1"));
			c.Add(new Component("", "GOL-18.2"));
			c.Add(new Component("Name of Coding System", "GOL-18.3"));
			c.Add(new Component("Alternate Identifier", "GOL-18.4"));
			c.Add(new Component("Alternate Text", "GOL-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "GOL-18.6"));
			f.Components = c;
			return f;
		}
		private Field GOL19()
		{
			Field f = new Field("Goal Life Cycle Status Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "GOL-19.1"));
			c.Add(new Component("Degree of Precision", "GOL-19.2"));
			f.Components = c;
			return f;
		}
		private Field GOL20()
		{
			Field f = new Field("Goal Target Type");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "GOL-20.1"));
			c.Add(new Component("", "GOL-20.2"));
			c.Add(new Component("Name of Coding System", "GOL-20.3"));
			c.Add(new Component("Alternate Identifier", "GOL-20.4"));
			c.Add(new Component("Alternate Text", "GOL-20.5"));
			c.Add(new Component("Name of Alternate Coding System", "GOL-20.6"));
			f.Components = c;
			return f;
		}
		private Field GOL21()
		{
			Field f = new Field("Goal Target Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "GOL-21.1"));
			c.Add(new Component("Given Name", "GOL-21.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "GOL-21.3"));
			c.Add(new Component("Suffix", "GOL-21.4"));
			c.Add(new Component("Prefix", "GOL-21.5"));
			c.Add(new Component("Degree", "GOL-21.6"));
			c.Add(new Component("Name Type Code", "GOL-21.7"));
			c.Add(new Component("Name Respresentation Code", "GOL-21.8"));
			c.Add(new Component("Name Context", "GOL-21.9"));
			c.Add(new Component("Name Validity Range", "GOL-21.10"));
			c.Add(new Component("Name Assembly Order", "GOL-21.11"));
			c.Add(new Component("Effective Date", "GOL-21.12"));
			c.Add(new Component("Expiration Date", "GOL-21.13"));
			c.Add(new Component("Professional Suffix", "GOL-21.14"));
			f.Components = c;
			return f;
		}
	}
}
