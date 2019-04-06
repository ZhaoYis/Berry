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
/// IPC Class: Constructs an HL7 IPC Segment Object
/// </summary>
public class IPC
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public IPC()
		{
			Name = "IPC";
			Description = "Imaging Procedure Control Segment";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(IPC1());
			fs.Add(IPC2());
			fs.Add(IPC3());
			fs.Add(IPC4());
			fs.Add(IPC5());
			fs.Add(IPC6());
			fs.Add(IPC7());
			fs.Add(IPC8());
			fs.Add(IPC9());
			Fields = fs;
		}
		private Field IPC1()
		{
			Field f = new Field("Accession Identifier");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "IPC-1.1"));
			c.Add(new Component("Namespace ID", "IPC-1.2"));
			c.Add(new Component("Universal ID", "IPC-1.3"));
			c.Add(new Component("Universal ID Type", "IPC-1.4"));
			f.Components = c;
			return f;
		}
		private Field IPC2()
		{
			Field f = new Field("Requested Procedure ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "IPC-2.1"));
			c.Add(new Component("Namespace ID", "IPC-2.2"));
			c.Add(new Component("Universal ID", "IPC-2.3"));
			c.Add(new Component("Universal ID Type", "IPC-2.4"));
			f.Components = c;
			return f;
		}
		private Field IPC3()
		{
			Field f = new Field("Study Instance UID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "IPC-3.1"));
			c.Add(new Component("Namespace ID", "IPC-3.2"));
			c.Add(new Component("Universal ID", "IPC-3.3"));
			c.Add(new Component("Universal ID Type", "IPC-3.4"));
			f.Components = c;
			return f;
		}
		private Field IPC4()
		{
			Field f = new Field("Scheduled Procedure Step ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "IPC-4.1"));
			c.Add(new Component("Namespace ID", "IPC-4.2"));
			c.Add(new Component("Universal ID", "IPC-4.3"));
			c.Add(new Component("Universal ID Type", "IPC-4.4"));
			f.Components = c;
			return f;
		}
		private Field IPC5()
		{
			Field f = new Field("Modality");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IPC-5.1"));
			c.Add(new Component("", "IPC-5.2"));
			c.Add(new Component("Name of Coding System", "IPC-5.3"));
			c.Add(new Component("Alternate Identifier", "IPC-5.4"));
			c.Add(new Component("Alternate Text", "IPC-5.5"));
			c.Add(new Component("Name of Alternate Coding System", "IPC-5.6"));
			f.Components = c;
			return f;
		}
		private Field IPC6()
		{
			Field f = new Field("Protocol Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IPC-6.1"));
			c.Add(new Component("", "IPC-6.2"));
			c.Add(new Component("Name of Coding System", "IPC-6.3"));
			c.Add(new Component("Alternate Identifier", "IPC-6.4"));
			c.Add(new Component("Alternate Text", "IPC-6.5"));
			c.Add(new Component("Name of Alternate Coding System", "IPC-6.6"));
			f.Components = c;
			return f;
		}
		private Field IPC7()
		{
			Field f = new Field("Scheduled Station Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Entity Identifier", "IPC-7.1"));
			c.Add(new Component("Namespace ID", "IPC-7.2"));
			c.Add(new Component("Universal ID", "IPC-7.3"));
			c.Add(new Component("Universal ID Type", "IPC-7.4"));
			f.Components = c;
			return f;
		}
		private Field IPC8()
		{
			Field f = new Field("Scheduled Procedure Step Location");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IPC-8.1"));
			c.Add(new Component("", "IPC-8.2"));
			c.Add(new Component("Name of Coding System", "IPC-8.3"));
			c.Add(new Component("Alternate Identifier", "IPC-8.4"));
			c.Add(new Component("Alternate Text", "IPC-8.5"));
			c.Add(new Component("Name of Alternate Coding System", "IPC-8.6"));
			f.Components = c;
			return f;
		}
		private Field IPC9()
		{
			Field f = new Field("Scheduled AE Title");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IPC-9.1"));
			f.Components = c;
			return f;
		}
	}
}
