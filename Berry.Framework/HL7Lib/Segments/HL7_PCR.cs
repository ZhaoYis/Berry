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
/// PCR Class: Constructs an HL7 PCR Segment Object
/// </summary>
public class PCR
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public PCR()
		{
			Name = "PCR";
			Description = "Possible Causal Relationship";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(PCR1());
			fs.Add(PCR2());
			fs.Add(PCR3());
			fs.Add(PCR4());
			fs.Add(PCR5());
			fs.Add(PCR6());
			fs.Add(PCR7());
			fs.Add(PCR8());
			fs.Add(PCR9());
			fs.Add(PCR10());
			fs.Add(PCR11());
			fs.Add(PCR12());
			fs.Add(PCR13());
			fs.Add(PCR14());
			fs.Add(PCR15());
			fs.Add(PCR16());
			fs.Add(PCR17());
			fs.Add(PCR18());
			fs.Add(PCR19());
			fs.Add(PCR20());
			fs.Add(PCR21());
			fs.Add(PCR22());
			fs.Add(PCR23());
			Fields = fs;
		}
		private Field PCR1()
		{
			Field f = new Field("Implicated Product");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PCR-1.1"));
			c.Add(new Component("", "PCR-1.2"));
			c.Add(new Component("Name of Coding System", "PCR-1.3"));
			c.Add(new Component("Alternate Identifier", "PCR-1.4"));
			c.Add(new Component("Alternate Text", "PCR-1.5"));
			c.Add(new Component("Name of Alternate Coding System", "PCR-1.6"));
			f.Components = c;
			return f;
		}
		private Field PCR2()
		{
			Field f = new Field("Generic Product");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-2.1"));
			f.Components = c;
			return f;
		}
		private Field PCR3()
		{
			Field f = new Field("Product Class");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PCR-3.1"));
			c.Add(new Component("", "PCR-3.2"));
			c.Add(new Component("Name of Coding System", "PCR-3.3"));
			c.Add(new Component("Alternate Identifier", "PCR-3.4"));
			c.Add(new Component("Alternate Text", "PCR-3.5"));
			c.Add(new Component("Name of Alternate Coding System", "PCR-3.6"));
			f.Components = c;
			return f;
		}
		private Field PCR4()
		{
			Field f = new Field("Total Duration Of Therapy");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "PCR-4.1"));
			c.Add(new Component("Units", "PCR-4.2"));
			f.Components = c;
			return f;
		}
		private Field PCR5()
		{
			Field f = new Field("Product Manufacture Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PCR-5.1"));
			c.Add(new Component("Degree of Precision", "PCR-5.2"));
			f.Components = c;
			return f;
		}
		private Field PCR6()
		{
			Field f = new Field("Product Expiration Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PCR-6.1"));
			c.Add(new Component("Degree of Precision", "PCR-6.2"));
			f.Components = c;
			return f;
		}
		private Field PCR7()
		{
			Field f = new Field("Product Implantation Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PCR-7.1"));
			c.Add(new Component("Degree of Precision", "PCR-7.2"));
			f.Components = c;
			return f;
		}
		private Field PCR8()
		{
			Field f = new Field("Product Explantation Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PCR-8.1"));
			c.Add(new Component("Degree of Precision", "PCR-8.2"));
			f.Components = c;
			return f;
		}
		private Field PCR9()
		{
			Field f = new Field("Single Use Device");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-9.1"));
			f.Components = c;
			return f;
		}
		private Field PCR10()
		{
			Field f = new Field("Indication For Product Use");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PCR-10.1"));
			c.Add(new Component("", "PCR-10.2"));
			c.Add(new Component("Name of Coding System", "PCR-10.3"));
			c.Add(new Component("Alternate Identifier", "PCR-10.4"));
			c.Add(new Component("Alternate Text", "PCR-10.5"));
			c.Add(new Component("Name of Alternate Coding System", "PCR-10.6"));
			f.Components = c;
			return f;
		}
		private Field PCR11()
		{
			Field f = new Field("Product Problem");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-11.1"));
			f.Components = c;
			return f;
		}
		private Field PCR12()
		{
			Field f = new Field("Product Serial/Lot Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-12.1"));
			f.Components = c;
			return f;
		}
		private Field PCR13()
		{
			Field f = new Field("Product Available For Inspection");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-13.1"));
			f.Components = c;
			return f;
		}
		private Field PCR14()
		{
			Field f = new Field("Product Evaluation Performed");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PCR-14.1"));
			c.Add(new Component("", "PCR-14.2"));
			c.Add(new Component("Name of Coding System", "PCR-14.3"));
			c.Add(new Component("Alternate Identifier", "PCR-14.4"));
			c.Add(new Component("Alternate Text", "PCR-14.5"));
			c.Add(new Component("Name of Alternate Coding System", "PCR-14.6"));
			f.Components = c;
			return f;
		}
		private Field PCR15()
		{
			Field f = new Field("Product Evaluation Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PCR-15.1"));
			c.Add(new Component("", "PCR-15.2"));
			c.Add(new Component("Name of Coding System", "PCR-15.3"));
			c.Add(new Component("Alternate Identifier", "PCR-15.4"));
			c.Add(new Component("Alternate Text", "PCR-15.5"));
			c.Add(new Component("Name of Alternate Coding System", "PCR-15.6"));
			f.Components = c;
			return f;
		}
		private Field PCR16()
		{
			Field f = new Field("Product Evaluation Results");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "PCR-16.1"));
			c.Add(new Component("", "PCR-16.2"));
			c.Add(new Component("Name of Coding System", "PCR-16.3"));
			c.Add(new Component("Alternate Identifier", "PCR-16.4"));
			c.Add(new Component("Alternate Text", "PCR-16.5"));
			c.Add(new Component("Name of Alternate Coding System", "PCR-16.6"));
			f.Components = c;
			return f;
		}
		private Field PCR17()
		{
			Field f = new Field("Evaluated Product Source");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-17.1"));
			f.Components = c;
			return f;
		}
		private Field PCR18()
		{
			Field f = new Field("Date Product Returned To Manufacturer");
			List<Component> c = new List<Component>();
			c.Add(new Component("Time", "PCR-18.1"));
			c.Add(new Component("Degree of Precision", "PCR-18.2"));
			f.Components = c;
			return f;
		}
		private Field PCR19()
		{
			Field f = new Field("Device Operator Qualifications");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-19.1"));
			f.Components = c;
			return f;
		}
		private Field PCR20()
		{
			Field f = new Field("Relatedness Assessment");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-20.1"));
			f.Components = c;
			return f;
		}
		private Field PCR21()
		{
			Field f = new Field("Action Taken In Response To The Event");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-21.1"));
			f.Components = c;
			return f;
		}
		private Field PCR22()
		{
			Field f = new Field("Event Causality Observations");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-22.1"));
			f.Components = c;
			return f;
		}
		private Field PCR23()
		{
			Field f = new Field("Indirect Exposure Mechanism");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "PCR-23.1"));
			f.Components = c;
			return f;
		}
	}
}
