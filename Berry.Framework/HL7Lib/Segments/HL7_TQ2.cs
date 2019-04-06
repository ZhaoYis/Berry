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
/// TQ2 Class: Constructs an HL7 TQ2 Segment Object
/// </summary>
public class TQ2
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public TQ2()
		{
			Name = "TQ2";
			Description = "Timing/Quantity Relationship";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(TQ21());
			fs.Add(TQ22());
			fs.Add(TQ23());
			fs.Add(TQ24());
			fs.Add(TQ25());
			fs.Add(TQ26());
			fs.Add(TQ27());
			fs.Add(TQ28());
			fs.Add(TQ29());
			fs.Add(TQ210());
			Fields = fs;
		}
		private Field TQ21()
		{
			Field f = new Field("Set ID - TQ2");
			List<Component> c = new List<Component>();
			c.Add(new Component("Sequence ID", "TQ2-1.1"));
			f.Components = c;
			return f;
		}
		private Field TQ22()
		{
			Field f = new Field("Sequence/Results Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ2-2.1"));
			f.Components = c;
			return f;
		}
		private Field TQ23()
		{
			Field f = new Field("Related Placer Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "TQ2-3.1"));
			c.Add(new Component("Namespace ID", "TQ2-3.2"));
			c.Add(new Component("Universal ID", "TQ2-3.3"));
			c.Add(new Component("Universal ID Type", "TQ2-3.4"));
			f.Components = c;
			return f;
		}
		private Field TQ24()
		{
			Field f = new Field("Related Filler Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "TQ2-4.1"));
			c.Add(new Component("Namespace ID", "TQ2-4.2"));
			c.Add(new Component("Universal ID", "TQ2-4.3"));
			c.Add(new Component("Universal ID Type", "TQ2-4.4"));
			f.Components = c;
			return f;
		}
		private Field TQ25()
		{
			Field f = new Field("Related Placer Group Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "TQ2-5.1"));
			c.Add(new Component("Namespace ID", "TQ2-5.2"));
			c.Add(new Component("Universal ID", "TQ2-5.3"));
			c.Add(new Component("Universal ID Type", "TQ2-5.4"));
			f.Components = c;
			return f;
		}
		private Field TQ26()
		{
			Field f = new Field("Sequence Condition Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ2-6.1"));
			f.Components = c;
			return f;
		}
		private Field TQ27()
		{
			Field f = new Field("Cyclic Entry/Exit Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ2-7.1"));
			f.Components = c;
			return f;
		}
		private Field TQ28()
		{
			Field f = new Field("Sequence Condition Time Interval");
			List<Component> c = new List<Component>();
			c.Add(new Component("Quantity", "TQ2-8.1"));
			c.Add(new Component("Units", "TQ2-8.2"));
			f.Components = c;
			return f;
		}
		private Field TQ29()
		{
			Field f = new Field("Cyclic Group Maximum Number of Repeats");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ2-9.1"));
			f.Components = c;
			return f;
		}
		private Field TQ210()
		{
			Field f = new Field("Special Service Request Relationship");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "TQ2-10.1"));
			f.Components = c;
			return f;
		}
	}
}
