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
/// PRB Class: Constructs an HL7 PRB Segment Object
/// </summary>
public class PRB
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PRB()
		{
			Name = "PRB";
			Description = "Problem Details";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PRB1());
			fs.Add(PRB2());
			fs.Add(PRB3());
			fs.Add(PRB4());
			fs.Add(PRB5());
			fs.Add(PRB6());
			fs.Add(PRB7());
			fs.Add(PRB8());
			fs.Add(PRB9());
			fs.Add(PRB10());
			fs.Add(PRB11());
			fs.Add(PRB12());
			fs.Add(PRB13());
			fs.Add(PRB14());
			fs.Add(PRB15());
			fs.Add(PRB16());
			fs.Add(PRB17());
			fs.Add(PRB18());
			fs.Add(PRB19());
			fs.Add(PRB20());
			fs.Add(PRB21());
			fs.Add(PRB22());
			fs.Add(PRB23());
			fs.Add(PRB24());
			fs.Add(PRB25());
			Fields = fs;
		}
		private Field PRB1()
		{
			Field f = new Field("Action Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRB-1.1"));
			f.Components = c;
			return f;
		}
		private Field PRB2()
		{
			Field f = new Field("Action Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRB-2.1"));
			c.Add(new Component("Degree of Precision", "PRB-2.2"));
			f.Components = c;
			return f;
		}
		private Field PRB3()
		{
			Field f = new Field("Problem ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-3.1"));
			c.Add(new Component("", "PRB-3.2"));
			c.Add(new Component("Name of Coding System", "PRB-3.3"));
			c.Add(new Component("Alternate Identifier", "PRB-3.4"));
			c.Add(new Component("Alternate Text", "PRB-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-3.6"));
			f.Components = c;
			return f;
		}
		private Field PRB4()
		{
			Field f = new Field("Problem Instance ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "PRB-4.1"));
			c.Add(new Component("Namespace ID", "PRB-4.2"));
			c.Add(new Component("Universal ID", "PRB-4.3"));
			c.Add(new Component("Universal ID Type", "PRB-4.4"));
			f.Components = c;
			return f;
		}
		private Field PRB5()
		{
			Field f = new Field("Episode of Care ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "PRB-5.1"));
			c.Add(new Component("Namespace ID", "PRB-5.2"));
			c.Add(new Component("Universal ID", "PRB-5.3"));
			c.Add(new Component("Universal ID Type", "PRB-5.4"));
			f.Components = c;
			return f;
		}
		private Field PRB6()
		{
			Field f = new Field("Problem List Priority");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRB-6.1"));
			f.Components = c;
			return f;
		}
		private Field PRB7()
		{
			Field f = new Field("Problem Established Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRB-7.1"));
			c.Add(new Component("Degree of Precision", "PRB-7.2"));
			f.Components = c;
			return f;
		}
		private Field PRB8()
		{
			Field f = new Field("Anticipated Problem Resolution Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRB-8.1"));
			c.Add(new Component("Degree of Precision", "PRB-8.2"));
			f.Components = c;
			return f;
		}
		private Field PRB9()
		{
			Field f = new Field("Actual Problem Resolution Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRB-9.1"));
			c.Add(new Component("Degree of Precision", "PRB-9.2"));
			f.Components = c;
			return f;
		}
		private Field PRB10()
		{
			Field f = new Field("Problem Classification");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-10.1"));
			c.Add(new Component("", "PRB-10.2"));
			c.Add(new Component("Name of Coding System", "PRB-10.3"));
			c.Add(new Component("Alternate Identifier", "PRB-10.4"));
			c.Add(new Component("Alternate Text", "PRB-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-10.6"));
			f.Components = c;
			return f;
		}
		private Field PRB11()
		{
			Field f = new Field("Problem Management Discipline");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-11.1"));
			c.Add(new Component("", "PRB-11.2"));
			c.Add(new Component("Name of Coding System", "PRB-11.3"));
			c.Add(new Component("Alternate Identifier", "PRB-11.4"));
			c.Add(new Component("Alternate Text", "PRB-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-11.6"));
			f.Components = c;
			return f;
		}
		private Field PRB12()
		{
			Field f = new Field("Problem Persistence");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-12.1"));
			c.Add(new Component("", "PRB-12.2"));
			c.Add(new Component("Name of Coding System", "PRB-12.3"));
			c.Add(new Component("Alternate Identifier", "PRB-12.4"));
			c.Add(new Component("Alternate Text", "PRB-12.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-12.6"));
			f.Components = c;
			return f;
		}
		private Field PRB13()
		{
			Field f = new Field("Problem Confirmation Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-13.1"));
			c.Add(new Component("", "PRB-13.2"));
			c.Add(new Component("Name of Coding System", "PRB-13.3"));
			c.Add(new Component("Alternate Identifier", "PRB-13.4"));
			c.Add(new Component("Alternate Text", "PRB-13.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-13.6"));
			f.Components = c;
			return f;
		}
		private Field PRB14()
		{
			Field f = new Field("Problem Life Cycle Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-14.1"));
			c.Add(new Component("", "PRB-14.2"));
			c.Add(new Component("Name of Coding System", "PRB-14.3"));
			c.Add(new Component("Alternate Identifier", "PRB-14.4"));
			c.Add(new Component("Alternate Text", "PRB-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-14.6"));
			f.Components = c;
			return f;
		}
		private Field PRB15()
		{
			Field f = new Field("Problem Life Cycle Status Date/Time");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRB-15.1"));
			c.Add(new Component("Degree of Precision", "PRB-15.2"));
			f.Components = c;
			return f;
		}
		private Field PRB16()
		{
			Field f = new Field("Problem Date of Onset");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PRB-16.1"));
			c.Add(new Component("Degree of Precision", "PRB-16.2"));
			f.Components = c;
			return f;
		}
		private Field PRB17()
		{
			Field f = new Field("Problem Onset Text");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRB-17.1"));
			f.Components = c;
			return f;
		}
		private Field PRB18()
		{
			Field f = new Field("Problem Ranking");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-18.1"));
			c.Add(new Component("", "PRB-18.2"));
			c.Add(new Component("Name of Coding System", "PRB-18.3"));
			c.Add(new Component("Alternate Identifier", "PRB-18.4"));
			c.Add(new Component("Alternate Text", "PRB-18.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-18.6"));
			f.Components = c;
			return f;
		}
		private Field PRB19()
		{
			Field f = new Field("Certainty of Problem");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-19.1"));
			c.Add(new Component("", "PRB-19.2"));
			c.Add(new Component("Name of Coding System", "PRB-19.3"));
			c.Add(new Component("Alternate Identifier", "PRB-19.4"));
			c.Add(new Component("Alternate Text", "PRB-19.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-19.6"));
			f.Components = c;
			return f;
		}
		private Field PRB20()
		{
			Field f = new Field("Probability of Problem (0-1)");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRB-20.1"));
			f.Components = c;
			return f;
		}
		private Field PRB21()
		{
			Field f = new Field("Individual Awareness of Problem");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-21.1"));
			c.Add(new Component("", "PRB-21.2"));
			c.Add(new Component("Name of Coding System", "PRB-21.3"));
			c.Add(new Component("Alternate Identifier", "PRB-21.4"));
			c.Add(new Component("Alternate Text", "PRB-21.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-21.6"));
			f.Components = c;
			return f;
		}
		private Field PRB22()
		{
			Field f = new Field("Problem Prognosis");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-22.1"));
			c.Add(new Component("", "PRB-22.2"));
			c.Add(new Component("Name of Coding System", "PRB-22.3"));
			c.Add(new Component("Alternate Identifier", "PRB-22.4"));
			c.Add(new Component("Alternate Text", "PRB-22.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-22.6"));
			f.Components = c;
			return f;
		}
		private Field PRB23()
		{
			Field f = new Field("Individual Awareness of Prognosis");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-23.1"));
			c.Add(new Component("", "PRB-23.2"));
			c.Add(new Component("Name of Coding System", "PRB-23.3"));
			c.Add(new Component("Alternate Identifier", "PRB-23.4"));
			c.Add(new Component("Alternate Text", "PRB-23.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-23.6"));
			f.Components = c;
			return f;
		}
		private Field PRB24()
		{
			Field f = new Field("Family/Significant Other Awareness of Problem/Prognosis");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PRB-24.1"));
			f.Components = c;
			return f;
		}
		private Field PRB25()
		{
			Field f = new Field("Security/Sensitivity");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PRB-25.1"));
			c.Add(new Component("", "PRB-25.2"));
			c.Add(new Component("Name of Coding System", "PRB-25.3"));
			c.Add(new Component("Alternate Identifier", "PRB-25.4"));
			c.Add(new Component("Alternate Text", "PRB-25.5"));
			c.Add(new Component("Name of Alternate Coding System", "PRB-25.6"));
			f.Components = c;
			return f;
		}
	}
}
