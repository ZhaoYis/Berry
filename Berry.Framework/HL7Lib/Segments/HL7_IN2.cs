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
/// IN2 Class: Constructs an HL7 IN2 Segment Object
/// </summary>
public class IN2
	{
		public string Name {get; set;}
		public string Description {get; set;}
		public List<Field> Fields {get; set;}

		public IN2()
		{
			Name = "IN2";
			Description = "Insurance Additional Information";
			List<Field> fs = new List<Field>();
			fs.Add(Field.SegName());
			fs.Add(IN21());
			fs.Add(IN22());
			fs.Add(IN23());
			fs.Add(IN24());
			fs.Add(IN25());
			fs.Add(IN26());
			fs.Add(IN27());
			fs.Add(IN28());
			fs.Add(IN29());
			fs.Add(IN210());
			fs.Add(IN211());
			fs.Add(IN212());
			fs.Add(IN213());
			fs.Add(IN214());
			fs.Add(IN215());
			fs.Add(IN216());
			fs.Add(IN217());
			fs.Add(IN218());
			fs.Add(IN219());
			fs.Add(IN220());
			fs.Add(IN221());
			fs.Add(IN222());
			fs.Add(IN223());
			fs.Add(IN224());
			fs.Add(IN225());
			fs.Add(IN226());
			fs.Add(IN227());
			fs.Add(IN228());
			fs.Add(IN229());
			fs.Add(IN230());
			fs.Add(IN231());
			fs.Add(IN232());
			fs.Add(IN233());
			fs.Add(IN234());
			fs.Add(IN235());
			fs.Add(IN236());
			fs.Add(IN237());
			fs.Add(IN238());
			fs.Add(IN239());
			fs.Add(IN240());
			fs.Add(IN241());
			fs.Add(IN242());
			fs.Add(IN243());
			fs.Add(IN244());
			fs.Add(IN245());
			fs.Add(IN246());
			fs.Add(IN247());
			fs.Add(IN248());
			fs.Add(IN249());
			fs.Add(IN250());
			fs.Add(IN251());
			fs.Add(IN252());
			fs.Add(IN253());
			fs.Add(IN254());
			fs.Add(IN255());
			fs.Add(IN256());
			fs.Add(IN257());
			fs.Add(IN258());
			fs.Add(IN259());
			fs.Add(IN260());
			fs.Add(IN261());
			fs.Add(IN262());
			fs.Add(IN263());
			fs.Add(IN264());
			fs.Add(IN265());
			fs.Add(IN266());
			fs.Add(IN267());
			fs.Add(IN268());
			fs.Add(IN269());
			fs.Add(IN270());
			fs.Add(IN271());
			fs.Add(IN272());
			Fields = fs;
		}
		private Field IN21()
		{
			Field f = new Field("Insured's Employee ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN2-1.1"));
			c.Add(new Component("Check Digit", "IN2-1.2"));
			c.Add(new Component("Check Digit Scheme", "IN2-1.3"));
			c.Add(new Component("Assigning Authority", "IN2-1.4"));
			c.Add(new Component("Identifier Type Code", "IN2-1.5"));
			c.Add(new Component("Assigning Facility", "IN2-1.6"));
			c.Add(new Component("Effective Date", "IN2-1.7"));
			c.Add(new Component("Expiration Date", "IN2-1.8"));
			c.Add(new Component("Assigning Jurisdiction", "IN2-1.9"));
			c.Add(new Component("Assigning Agency or Department", "IN2-1.10"));
			f.Components = c;
			return f;
		}
		private Field IN22()
		{
			Field f = new Field("Insured's Social Security Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-2.1"));
			f.Components = c;
			return f;
		}
		private Field IN23()
		{
			Field f = new Field("Insured's Employer's Name and ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN2-3.1"));
			c.Add(new Component("Family Name", "IN2-3.2"));
			c.Add(new Component("Given Name", "IN2-3.3"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN2-3.4"));
			c.Add(new Component("Suffix", "IN2-3.5"));
			c.Add(new Component("Prefix", "IN2-3.6"));
			c.Add(new Component("Degree", "IN2-3.7"));
			c.Add(new Component("Source Table", "IN2-3.8"));
			c.Add(new Component("Assigning Authority", "IN2-3.9"));
			c.Add(new Component("Name Type Code", "IN2-3.10"));
			c.Add(new Component("Identifier Check Digit", "IN2-3.11"));
			c.Add(new Component("Check Digit Scheme", "IN2-3.12"));
			c.Add(new Component("Identifier Type Code", "IN2-3.13"));
			c.Add(new Component("Assigning Facility", "IN2-3.14"));
			c.Add(new Component("Name Respresentation Code", "IN2-3.15"));
			c.Add(new Component("Name Context", "IN2-3.16"));
			c.Add(new Component("Name Validity Range", "IN2-3.17"));
			c.Add(new Component("Name Assembly Order", "IN2-3.18"));
			c.Add(new Component("Effective Date", "IN2-3.19"));
			c.Add(new Component("Expiration Date", "IN2-3.20"));
			c.Add(new Component("Professional Suffix", "IN2-3.21"));
			c.Add(new Component("Assigning Jurisdiction", "IN2-3.22"));
			c.Add(new Component("Assigning Agency or Department", "IN2-3.23"));
			f.Components = c;
			return f;
		}
		private Field IN24()
		{
			Field f = new Field("Employer Information Data");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-4.1"));
			f.Components = c;
			return f;
		}
		private Field IN25()
		{
			Field f = new Field("Mail Claim Party");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-5.1"));
			f.Components = c;
			return f;
		}
		private Field IN26()
		{
			Field f = new Field("Medicare Health Ins Card Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-6.1"));
			f.Components = c;
			return f;
		}
		private Field IN27()
		{
			Field f = new Field("Medicaid Case Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IN2-7.1"));
			c.Add(new Component("Given Name", "IN2-7.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN2-7.3"));
			c.Add(new Component("Suffix", "IN2-7.4"));
			c.Add(new Component("Prefix", "IN2-7.5"));
			c.Add(new Component("Degree", "IN2-7.6"));
			c.Add(new Component("Name Type Code", "IN2-7.7"));
			c.Add(new Component("Name Respresentation Code", "IN2-7.8"));
			c.Add(new Component("Name Context", "IN2-7.9"));
			c.Add(new Component("Name Validity Range", "IN2-7.10"));
			c.Add(new Component("Name Assembly Order", "IN2-7.11"));
			c.Add(new Component("Effective Date", "IN2-7.12"));
			c.Add(new Component("Expiration Date", "IN2-7.13"));
			c.Add(new Component("Professional Suffix", "IN2-7.14"));
			f.Components = c;
			return f;
		}
		private Field IN28()
		{
			Field f = new Field("Medicaid Case Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-8.1"));
			f.Components = c;
			return f;
		}
		private Field IN29()
		{
			Field f = new Field("Military Sponsor Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IN2-9.1"));
			c.Add(new Component("Given Name", "IN2-9.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN2-9.3"));
			c.Add(new Component("Suffix", "IN2-9.4"));
			c.Add(new Component("Prefix", "IN2-9.5"));
			c.Add(new Component("Degree", "IN2-9.6"));
			c.Add(new Component("Name Type Code", "IN2-9.7"));
			c.Add(new Component("Name Respresentation Code", "IN2-9.8"));
			c.Add(new Component("Name Context", "IN2-9.9"));
			c.Add(new Component("Name Validity Range", "IN2-9.10"));
			c.Add(new Component("Name Assembly Order", "IN2-9.11"));
			c.Add(new Component("Effective Date", "IN2-9.12"));
			c.Add(new Component("Expiration Date", "IN2-9.13"));
			c.Add(new Component("Professional Suffix", "IN2-9.14"));
			f.Components = c;
			return f;
		}
		private Field IN210()
		{
			Field f = new Field("Military ID Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-10.1"));
			f.Components = c;
			return f;
		}
		private Field IN211()
		{
			Field f = new Field("Dependent Of Military Recipient");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-11.1"));
			c.Add(new Component("", "IN2-11.2"));
			c.Add(new Component("Name of Coding System", "IN2-11.3"));
			c.Add(new Component("Alternate Identifier", "IN2-11.4"));
			c.Add(new Component("Alternate Text", "IN2-11.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-11.6"));
			f.Components = c;
			return f;
		}
		private Field IN212()
		{
			Field f = new Field("Military Organization");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-12.1"));
			f.Components = c;
			return f;
		}
		private Field IN213()
		{
			Field f = new Field("Military Station");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-13.1"));
			f.Components = c;
			return f;
		}
		private Field IN214()
		{
			Field f = new Field("Military Service");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-14.1"));
			f.Components = c;
			return f;
		}
		private Field IN215()
		{
			Field f = new Field("Military Rank/Grade");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-15.1"));
			f.Components = c;
			return f;
		}
		private Field IN216()
		{
			Field f = new Field("Military Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-16.1"));
			f.Components = c;
			return f;
		}
		private Field IN217()
		{
			Field f = new Field("Military Retire Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-17.1"));
			f.Components = c;
			return f;
		}
		private Field IN218()
		{
			Field f = new Field("Military Non-Avail Cert On File");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-18.1"));
			f.Components = c;
			return f;
		}
		private Field IN219()
		{
			Field f = new Field("Baby Coverage");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-19.1"));
			f.Components = c;
			return f;
		}
		private Field IN220()
		{
			Field f = new Field("Combine Baby Bill");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-20.1"));
			f.Components = c;
			return f;
		}
		private Field IN221()
		{
			Field f = new Field("Blood Deductible");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-21.1"));
			f.Components = c;
			return f;
		}
		private Field IN222()
		{
			Field f = new Field("Special Coverage Approval Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IN2-22.1"));
			c.Add(new Component("Given Name", "IN2-22.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN2-22.3"));
			c.Add(new Component("Suffix", "IN2-22.4"));
			c.Add(new Component("Prefix", "IN2-22.5"));
			c.Add(new Component("Degree", "IN2-22.6"));
			c.Add(new Component("Name Type Code", "IN2-22.7"));
			c.Add(new Component("Name Respresentation Code", "IN2-22.8"));
			c.Add(new Component("Name Context", "IN2-22.9"));
			c.Add(new Component("Name Validity Range", "IN2-22.10"));
			c.Add(new Component("Name Assembly Order", "IN2-22.11"));
			c.Add(new Component("Effective Date", "IN2-22.12"));
			c.Add(new Component("Expiration Date", "IN2-22.13"));
			c.Add(new Component("Professional Suffix", "IN2-22.14"));
			f.Components = c;
			return f;
		}
		private Field IN223()
		{
			Field f = new Field("Special Coverage Approval Title");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-23.1"));
			f.Components = c;
			return f;
		}
		private Field IN224()
		{
			Field f = new Field("Non-Covered Insurance Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-24.1"));
			f.Components = c;
			return f;
		}
		private Field IN225()
		{
			Field f = new Field("Payor ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN2-25.1"));
			c.Add(new Component("Check Digit", "IN2-25.2"));
			c.Add(new Component("Check Digit Scheme", "IN2-25.3"));
			c.Add(new Component("Assigning Authority", "IN2-25.4"));
			c.Add(new Component("Identifier Type Code", "IN2-25.5"));
			c.Add(new Component("Assigning Facility", "IN2-25.6"));
			c.Add(new Component("Effective Date", "IN2-25.7"));
			c.Add(new Component("Expiration Date", "IN2-25.8"));
			c.Add(new Component("Assigning Jurisdiction", "IN2-25.9"));
			c.Add(new Component("Assigning Agency or Department", "IN2-25.10"));
			f.Components = c;
			return f;
		}
		private Field IN226()
		{
			Field f = new Field("Payor Subscriber ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN2-26.1"));
			c.Add(new Component("Check Digit", "IN2-26.2"));
			c.Add(new Component("Check Digit Scheme", "IN2-26.3"));
			c.Add(new Component("Assigning Authority", "IN2-26.4"));
			c.Add(new Component("Identifier Type Code", "IN2-26.5"));
			c.Add(new Component("Assigning Facility", "IN2-26.6"));
			c.Add(new Component("Effective Date", "IN2-26.7"));
			c.Add(new Component("Expiration Date", "IN2-26.8"));
			c.Add(new Component("Assigning Jurisdiction", "IN2-26.9"));
			c.Add(new Component("Assigning Agency or Department", "IN2-26.10"));
			f.Components = c;
			return f;
		}
		private Field IN227()
		{
			Field f = new Field("Eligibility Source");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-27.1"));
			f.Components = c;
			return f;
		}
		private Field IN228()
		{
			Field f = new Field("Room Coverage Type/Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("Room Type", "IN2-28.1"));
			c.Add(new Component("Amount Type", "IN2-28.2"));
			c.Add(new Component("Coverage Amount", "IN2-28.3"));
			c.Add(new Component("Money or Percentage", "IN2-28.4"));
			f.Components = c;
			return f;
		}
		private Field IN229()
		{
			Field f = new Field("Policy Type/Amount");
			List<Component> c = new List<Component>();
			c.Add(new Component("Policy Type", "IN2-29.1"));
			c.Add(new Component("Amount Class", "IN2-29.2"));
			c.Add(new Component("MoneyorPercentageQuantity", "IN2-29.3"));
			c.Add(new Component("Money or Percentage", "IN2-29.4"));
			f.Components = c;
			return f;
		}
		private Field IN230()
		{
			Field f = new Field("Daily Deductible");
			List<Component> c = new List<Component>();
			c.Add(new Component("Delay Days", "IN2-30.1"));
			c.Add(new Component("Monetary Amount", "IN2-30.2"));
			c.Add(new Component("Number of Days", "IN2-30.3"));
			f.Components = c;
			return f;
		}
		private Field IN231()
		{
			Field f = new Field("Living Dependency");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-31.1"));
			f.Components = c;
			return f;
		}
		private Field IN232()
		{
			Field f = new Field("Ambulatory Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-32.1"));
			f.Components = c;
			return f;
		}
		private Field IN233()
		{
			Field f = new Field("Citizenship");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-33.1"));
			c.Add(new Component("", "IN2-33.2"));
			c.Add(new Component("Name of Coding System", "IN2-33.3"));
			c.Add(new Component("Alternate Identifier", "IN2-33.4"));
			c.Add(new Component("Alternate Text", "IN2-33.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-33.6"));
			f.Components = c;
			return f;
		}
		private Field IN234()
		{
			Field f = new Field("Primary Language");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-34.1"));
			c.Add(new Component("", "IN2-34.2"));
			c.Add(new Component("Name of Coding System", "IN2-34.3"));
			c.Add(new Component("Alternate Identifier", "IN2-34.4"));
			c.Add(new Component("Alternate Text", "IN2-34.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-34.6"));
			f.Components = c;
			return f;
		}
		private Field IN235()
		{
			Field f = new Field("Living Arrangement");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-35.1"));
			f.Components = c;
			return f;
		}
		private Field IN236()
		{
			Field f = new Field("Publicity Code");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-36.1"));
			c.Add(new Component("", "IN2-36.2"));
			c.Add(new Component("Name of Coding System", "IN2-36.3"));
			c.Add(new Component("Alternate Identifier", "IN2-36.4"));
			c.Add(new Component("Alternate Text", "IN2-36.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-36.6"));
			f.Components = c;
			return f;
		}
		private Field IN237()
		{
			Field f = new Field("Protection Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-37.1"));
			f.Components = c;
			return f;
		}
		private Field IN238()
		{
			Field f = new Field("Student Indicator");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-38.1"));
			f.Components = c;
			return f;
		}
		private Field IN239()
		{
			Field f = new Field("Religion");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-39.1"));
			c.Add(new Component("", "IN2-39.2"));
			c.Add(new Component("Name of Coding System", "IN2-39.3"));
			c.Add(new Component("Alternate Identifier", "IN2-39.4"));
			c.Add(new Component("Alternate Text", "IN2-39.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-39.6"));
			f.Components = c;
			return f;
		}
		private Field IN240()
		{
			Field f = new Field("Mother's Maiden Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IN2-40.1"));
			c.Add(new Component("Given Name", "IN2-40.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN2-40.3"));
			c.Add(new Component("Suffix", "IN2-40.4"));
			c.Add(new Component("Prefix", "IN2-40.5"));
			c.Add(new Component("Degree", "IN2-40.6"));
			c.Add(new Component("Name Type Code", "IN2-40.7"));
			c.Add(new Component("Name Respresentation Code", "IN2-40.8"));
			c.Add(new Component("Name Context", "IN2-40.9"));
			c.Add(new Component("Name Validity Range", "IN2-40.10"));
			c.Add(new Component("Name Assembly Order", "IN2-40.11"));
			c.Add(new Component("Effective Date", "IN2-40.12"));
			c.Add(new Component("Expiration Date", "IN2-40.13"));
			c.Add(new Component("Professional Suffix", "IN2-40.14"));
			f.Components = c;
			return f;
		}
		private Field IN241()
		{
			Field f = new Field("Nationality");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-41.1"));
			c.Add(new Component("", "IN2-41.2"));
			c.Add(new Component("Name of Coding System", "IN2-41.3"));
			c.Add(new Component("Alternate Identifier", "IN2-41.4"));
			c.Add(new Component("Alternate Text", "IN2-41.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-41.6"));
			f.Components = c;
			return f;
		}
		private Field IN242()
		{
			Field f = new Field("Ethnic Group");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-42.1"));
			c.Add(new Component("", "IN2-42.2"));
			c.Add(new Component("Name of Coding System", "IN2-42.3"));
			c.Add(new Component("Alternate Identifier", "IN2-42.4"));
			c.Add(new Component("Alternate Text", "IN2-42.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-42.6"));
			f.Components = c;
			return f;
		}
		private Field IN243()
		{
			Field f = new Field("Marital Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-43.1"));
			c.Add(new Component("", "IN2-43.2"));
			c.Add(new Component("Name of Coding System", "IN2-43.3"));
			c.Add(new Component("Alternate Identifier", "IN2-43.4"));
			c.Add(new Component("Alternate Text", "IN2-43.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-43.6"));
			f.Components = c;
			return f;
		}
		private Field IN244()
		{
			Field f = new Field("Insured's Employment Start Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-44.1"));
			f.Components = c;
			return f;
		}
		private Field IN245()
		{
			Field f = new Field("Employment Stop Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-45.1"));
			f.Components = c;
			return f;
		}
		private Field IN246()
		{
			Field f = new Field("Job Title");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-46.1"));
			f.Components = c;
			return f;
		}
		private Field IN247()
		{
			Field f = new Field("Job Code/Class");
			List<Component> c = new List<Component>();
			c.Add(new Component("Job Code", "IN2-47.1"));
			c.Add(new Component("Job Class", "IN2-47.2"));
			c.Add(new Component("Job Description", "IN2-47.3"));
			f.Components = c;
			return f;
		}
		private Field IN248()
		{
			Field f = new Field("Job Status");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-48.1"));
			f.Components = c;
			return f;
		}
		private Field IN249()
		{
			Field f = new Field("Employer Contact Person Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IN2-49.1"));
			c.Add(new Component("Given Name", "IN2-49.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN2-49.3"));
			c.Add(new Component("Suffix", "IN2-49.4"));
			c.Add(new Component("Prefix", "IN2-49.5"));
			c.Add(new Component("Degree", "IN2-49.6"));
			c.Add(new Component("Name Type Code", "IN2-49.7"));
			c.Add(new Component("Name Respresentation Code", "IN2-49.8"));
			c.Add(new Component("Name Context", "IN2-49.9"));
			c.Add(new Component("Name Validity Range", "IN2-49.10"));
			c.Add(new Component("Name Assembly Order", "IN2-49.11"));
			c.Add(new Component("Effective Date", "IN2-49.12"));
			c.Add(new Component("Expiration Date", "IN2-49.13"));
			c.Add(new Component("Professional Suffix", "IN2-49.14"));
			f.Components = c;
			return f;
		}
		private Field IN250()
		{
			Field f = new Field("Employer Contact Person Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "IN2-50.1"));
			c.Add(new Component("Tele-Communication Use Code", "IN2-50.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "IN2-50.3"));
			c.Add(new Component("Email Address", "IN2-50.4"));
			c.Add(new Component("Country Code", "IN2-50.5"));
			c.Add(new Component("Area City Code", "IN2-50.6"));
			c.Add(new Component("Local Number", "IN2-50.7"));
			c.Add(new Component("Extension", "IN2-50.8"));
			c.Add(new Component("", "IN2-50.9"));
			c.Add(new Component("Extension Prefix", "IN2-50.10"));
			c.Add(new Component("Speed Dial Code", "IN2-50.11"));
			c.Add(new Component("Unformatted Telephone Number", "IN2-50.12"));
			f.Components = c;
			return f;
		}
		private Field IN251()
		{
			Field f = new Field("Employer Contact Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-51.1"));
			f.Components = c;
			return f;
		}
		private Field IN252()
		{
			Field f = new Field("Insured's Contact Person's Name");
			List<Component> c = new List<Component>();
			c.Add(new Component("Family Name", "IN2-52.1"));
			c.Add(new Component("Given Name", "IN2-52.2"));
			c.Add(new Component("Second and Further Given Names or Initials Thereof", "IN2-52.3"));
			c.Add(new Component("Suffix", "IN2-52.4"));
			c.Add(new Component("Prefix", "IN2-52.5"));
			c.Add(new Component("Degree", "IN2-52.6"));
			c.Add(new Component("Name Type Code", "IN2-52.7"));
			c.Add(new Component("Name Respresentation Code", "IN2-52.8"));
			c.Add(new Component("Name Context", "IN2-52.9"));
			c.Add(new Component("Name Validity Range", "IN2-52.10"));
			c.Add(new Component("Name Assembly Order", "IN2-52.11"));
			c.Add(new Component("Effective Date", "IN2-52.12"));
			c.Add(new Component("Expiration Date", "IN2-52.13"));
			c.Add(new Component("Professional Suffix", "IN2-52.14"));
			f.Components = c;
			return f;
		}
		private Field IN253()
		{
			Field f = new Field("Insured's Contact Person Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "IN2-53.1"));
			c.Add(new Component("Tele-Communication Use Code", "IN2-53.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "IN2-53.3"));
			c.Add(new Component("Email Address", "IN2-53.4"));
			c.Add(new Component("Country Code", "IN2-53.5"));
			c.Add(new Component("Area City Code", "IN2-53.6"));
			c.Add(new Component("Local Number", "IN2-53.7"));
			c.Add(new Component("Extension", "IN2-53.8"));
			c.Add(new Component("", "IN2-53.9"));
			c.Add(new Component("Extension Prefix", "IN2-53.10"));
			c.Add(new Component("Speed Dial Code", "IN2-53.11"));
			c.Add(new Component("Unformatted Telephone Number", "IN2-53.12"));
			f.Components = c;
			return f;
		}
		private Field IN254()
		{
			Field f = new Field("Insured's Contact Person Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-54.1"));
			f.Components = c;
			return f;
		}
		private Field IN255()
		{
			Field f = new Field("Relationship to the Patient Start Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-55.1"));
			f.Components = c;
			return f;
		}
		private Field IN256()
		{
			Field f = new Field("Relationship to the Patient Stop Date");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-56.1"));
			f.Components = c;
			return f;
		}
		private Field IN257()
		{
			Field f = new Field("Insurance Co. Contact Reason");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-57.1"));
			f.Components = c;
			return f;
		}
		private Field IN258()
		{
			Field f = new Field("Insurance Co Contact Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "IN2-58.1"));
			c.Add(new Component("Tele-Communication Use Code", "IN2-58.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "IN2-58.3"));
			c.Add(new Component("Email Address", "IN2-58.4"));
			c.Add(new Component("Country Code", "IN2-58.5"));
			c.Add(new Component("Area City Code", "IN2-58.6"));
			c.Add(new Component("Local Number", "IN2-58.7"));
			c.Add(new Component("Extension", "IN2-58.8"));
			c.Add(new Component("", "IN2-58.9"));
			c.Add(new Component("Extension Prefix", "IN2-58.10"));
			c.Add(new Component("Speed Dial Code", "IN2-58.11"));
			c.Add(new Component("Unformatted Telephone Number", "IN2-58.12"));
			f.Components = c;
			return f;
		}
		private Field IN259()
		{
			Field f = new Field("Policy Scope");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-59.1"));
			f.Components = c;
			return f;
		}
		private Field IN260()
		{
			Field f = new Field("Policy Source");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-60.1"));
			f.Components = c;
			return f;
		}
		private Field IN261()
		{
			Field f = new Field("Patient Member Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("ID Number", "IN2-61.1"));
			c.Add(new Component("Check Digit", "IN2-61.2"));
			c.Add(new Component("Check Digit Scheme", "IN2-61.3"));
			c.Add(new Component("Assigning Authority", "IN2-61.4"));
			c.Add(new Component("Identifier Type Code", "IN2-61.5"));
			c.Add(new Component("Assigning Facility", "IN2-61.6"));
			c.Add(new Component("Effective Date", "IN2-61.7"));
			c.Add(new Component("Expiration Date", "IN2-61.8"));
			c.Add(new Component("Assigning Jurisdiction", "IN2-61.9"));
			c.Add(new Component("Assigning Agency or Department", "IN2-61.10"));
			f.Components = c;
			return f;
		}
		private Field IN262()
		{
			Field f = new Field("Guarantor's Relationship To Insured");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-62.1"));
			c.Add(new Component("", "IN2-62.2"));
			c.Add(new Component("Name of Coding System", "IN2-62.3"));
			c.Add(new Component("Alternate Identifier", "IN2-62.4"));
			c.Add(new Component("Alternate Text", "IN2-62.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-62.6"));
			f.Components = c;
			return f;
		}
		private Field IN263()
		{
			Field f = new Field("Insured's Phone Number - Home");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "IN2-63.1"));
			c.Add(new Component("Tele-Communication Use Code", "IN2-63.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "IN2-63.3"));
			c.Add(new Component("Email Address", "IN2-63.4"));
			c.Add(new Component("Country Code", "IN2-63.5"));
			c.Add(new Component("Area City Code", "IN2-63.6"));
			c.Add(new Component("Local Number", "IN2-63.7"));
			c.Add(new Component("Extension", "IN2-63.8"));
			c.Add(new Component("", "IN2-63.9"));
			c.Add(new Component("Extension Prefix", "IN2-63.10"));
			c.Add(new Component("Speed Dial Code", "IN2-63.11"));
			c.Add(new Component("Unformatted Telephone Number", "IN2-63.12"));
			f.Components = c;
			return f;
		}
		private Field IN264()
		{
			Field f = new Field("Insured's Employer Phone Number");
			List<Component> c = new List<Component>();
			c.Add(new Component("Telephone Number", "IN2-64.1"));
			c.Add(new Component("Tele-Communication Use Code", "IN2-64.2"));
			c.Add(new Component("Tele-Communication Equipment Type", "IN2-64.3"));
			c.Add(new Component("Email Address", "IN2-64.4"));
			c.Add(new Component("Country Code", "IN2-64.5"));
			c.Add(new Component("Area City Code", "IN2-64.6"));
			c.Add(new Component("Local Number", "IN2-64.7"));
			c.Add(new Component("Extension", "IN2-64.8"));
			c.Add(new Component("", "IN2-64.9"));
			c.Add(new Component("Extension Prefix", "IN2-64.10"));
			c.Add(new Component("Speed Dial Code", "IN2-64.11"));
			c.Add(new Component("Unformatted Telephone Number", "IN2-64.12"));
			f.Components = c;
			return f;
		}
		private Field IN265()
		{
			Field f = new Field("Military Handicapped Program");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-65.1"));
			c.Add(new Component("", "IN2-65.2"));
			c.Add(new Component("Name of Coding System", "IN2-65.3"));
			c.Add(new Component("Alternate Identifier", "IN2-65.4"));
			c.Add(new Component("Alternate Text", "IN2-65.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-65.6"));
			f.Components = c;
			return f;
		}
		private Field IN266()
		{
			Field f = new Field("Suspend Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-66.1"));
			f.Components = c;
			return f;
		}
		private Field IN267()
		{
			Field f = new Field("Copay Limit Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-67.1"));
			f.Components = c;
			return f;
		}
		private Field IN268()
		{
			Field f = new Field("Stoploss Limit Flag");
			List<Component> c = new List<Component>();
			c.Add(new Component("", "IN2-68.1"));
			f.Components = c;
			return f;
		}
		private Field IN269()
		{
			Field f = new Field("Insured Organization Name and ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "IN2-69.1"));
			c.Add(new Component("Organization Name Type Code", "IN2-69.2"));
			c.Add(new Component("ID Number", "IN2-69.3"));
			c.Add(new Component("Check Digit", "IN2-69.4"));
			c.Add(new Component("Check Digit Scheme", "IN2-69.5"));
			c.Add(new Component("Assigning Authority", "IN2-69.6"));
			c.Add(new Component("Identifier Type Code", "IN2-69.7"));
			c.Add(new Component("Assigning Facility", "IN2-69.8"));
			c.Add(new Component("Name Respresentation Code", "IN2-69.9"));
			c.Add(new Component("Organization Identifier", "IN2-69.10"));
			f.Components = c;
			return f;
		}
		private Field IN270()
		{
			Field f = new Field("Insured Employer Organization Name and ID");
			List<Component> c = new List<Component>();
			c.Add(new Component("Organization Name", "IN2-70.1"));
			c.Add(new Component("Organization Name Type Code", "IN2-70.2"));
			c.Add(new Component("ID Number", "IN2-70.3"));
			c.Add(new Component("Check Digit", "IN2-70.4"));
			c.Add(new Component("Check Digit Scheme", "IN2-70.5"));
			c.Add(new Component("Assigning Authority", "IN2-70.6"));
			c.Add(new Component("Identifier Type Code", "IN2-70.7"));
			c.Add(new Component("Assigning Facility", "IN2-70.8"));
			c.Add(new Component("Name Respresentation Code", "IN2-70.9"));
			c.Add(new Component("Organization Identifier", "IN2-70.10"));
			f.Components = c;
			return f;
		}
		private Field IN271()
		{
			Field f = new Field("Race");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-71.1"));
			c.Add(new Component("", "IN2-71.2"));
			c.Add(new Component("Name of Coding System", "IN2-71.3"));
			c.Add(new Component("Alternate Identifier", "IN2-71.4"));
			c.Add(new Component("Alternate Text", "IN2-71.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-71.6"));
			f.Components = c;
			return f;
		}
		private Field IN272()
		{
			Field f = new Field("CMS Patient_s Relationship to Insured");
			List<Component> c = new List<Component>();
			c.Add(new Component("Identifier", "IN2-72.1"));
			c.Add(new Component("", "IN2-72.2"));
			c.Add(new Component("Name of Coding System", "IN2-72.3"));
			c.Add(new Component("Alternate Identifier", "IN2-72.4"));
			c.Add(new Component("Alternate Text", "IN2-72.5"));
			c.Add(new Component("Name of Alternate Coding System", "IN2-72.6"));
			f.Components = c;
			return f;
		}
	}
}
