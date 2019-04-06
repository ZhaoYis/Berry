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
using System.Text;
using System.Collections.Generic;

namespace HL7Lib.Base
{
    /// <summary>
    /// Helper Class: Used to setup helper objects
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Sets a random first name for the PID segment, used to de-identify the HL7 message
        /// </summary>
        /// <param name="Sex">The sex in the PID segment</param>
        /// <returns>Returns a randomly selected name from a list of names based on the sex of the patient</returns>
        public static string RandomFirstName(string Sex)
        {
            Random rand = new Random();
            if (!String.IsNullOrEmpty(Sex))
            {                
                if (Sex.ToUpper() == "MALE" || Sex.ToUpper() == "M")
                {
                    string[] names = HL7Lib.Properties.Resources.Boy_Names.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    return names.GetValue(rand.Next(names.Length)).ToString();
                }
                else if (Sex.ToUpper() == "FEMALE" || Sex.ToUpper() == "F")
                {
                    string[] names = HL7Lib.Properties.Resources.Girl_Names.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    return names.GetValue(rand.Next(names.Length)).ToString();
                }
                else
                {
                    string[] names = HL7Lib.Properties.Resources.Boy_Names.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    return names.GetValue(rand.Next(names.Length)).ToString();
                }
            }
            else
            {
                string[] names = HL7Lib.Properties.Resources.Boy_Names.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                return names.GetValue(rand.Next(names.Length)).ToString();
            }
        }
        /// <summary>
        /// Sets a random last name for the PID segment, used to de-identify the HL7 message.
        /// </summary>
        /// <returns>Returns a randomly selected name from a list of names</returns>
        public static string RandomLastName()
        {            
            string[] names = HL7Lib.Properties.Resources.Last_Names.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);            
            Random rand = new Random();
            return names.GetValue(rand.Next(names.Length)).ToString();
        }
        /// <summary>
        /// Sets a random street address, used to de-identify the HL7 message.
        /// </summary>
        /// <returns>Returns a randomly selected street address</returns>
        public static string RandomAddress()
        {
            Random houseRand = new Random();
            Random addressRand = new Random();
            Random streetRand = new Random();
            int house = houseRand.Next(99999);
            string[] addresses = HL7Lib.Properties.Resources.Address_Names.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] streets = { "Street", "Drive", "Avenue", "Lane", "Way" };
            string StreetAddress = String.Format("{0} {1} {2}", house.ToString().Trim(), addresses.GetValue(addressRand.Next(addresses.Length)).ToString().Trim(), streets.GetValue(streetRand.Next(streets.Length)).ToString().Trim());
            return StreetAddress;
        }
        /// <summary>
        /// Sets a random MRN for the patient, used to de-identify the HL7 message
        /// </summary>
        /// <returns>Returns a randomly selected MRN</returns>
        public static string RandomMRN()
        {
            Random rand = new Random();
            return rand.Next(99999999).ToString();
        }
        /// <summary>
        /// Creates an ACK from the MSH segment of the associated message
        /// </summary>
        /// <param name="InboundMessage">The inbound message</param>
        /// <returns>The ack</returns>
        public static HL7Message CreateAck(HL7Message InboundMessage)
        {
            if (InboundMessage.Segments.Get("MSH").Count == 1)
            {
                Segment msh = InboundMessage.Segments.Get("MSH")[0];
                List<object> args = new List<object>();
                args.Add((object)msh.GetByID("MSH-3.1").Value);//String.Format Arg 0
                args.Add((object)msh.GetByID("MSH-4.1").Value);//String.Format Arg 1
                args.Add((object)msh.GetByID("MSH-5.1").Value);//String.Format Arg 2
                args.Add((object)msh.GetByID("MSH-6.1").Value);//String.Format Arg 3
                args.Add((object)msh.GetByID("MSH-7.1").Value);//String.Format Arg 4
                args.Add((object)msh.GetByID("MSH-9.2").Value);//String.Format Arg 5
                args.Add((object)msh.GetByID("MSH-10.1").Value);//String.Format Arg 6
                args.Add((object)msh.GetByID("MSH-11.1").Value);//String.Format Arg 7
                args.Add((object)msh.GetByID("MSH-12.1").Value);//String.Format Arg 8
                string msg = String.Format("MSH|^~\\&|{0}|{1}|{2}|{3}|{4}||ACK^{5}|{6}|{7}|{8}\r\nMSA|AA|{6}", args.ToArray());
                HL7Message m = new HL7Message(msg);
                return m;
            }
            else
            {
                throw new Exception("No MSH Segment Present in Inbound Message.");
            }
        }
        /// <summary>
        /// Validates the ack against the message
        /// </summary>
        /// <param name="OutboundMessage">The message to use</param>
        /// <param name="AckMessage">The ack to use</param>
        /// <returns></returns>
        public static bool ValidateAck(HL7Message OutboundMessage, HL7Message AckMessage)
        {
            bool returnValue = false;
            if (OutboundMessage.Segments.Get("MSH").Count == 1 && AckMessage.Segments.Get("MSA").Count == 1)
            {
                Segment msh = OutboundMessage.Segments.Get("MSH")[0];
                Segment msa = AckMessage.Segments.Get("MSA")[0];

                if (msh.GetByID("MSH-10.1").Value == msa.GetByID("MSA-2.1").Value && msa.GetByID("MSA-1.1").Value == "AA")
                    returnValue = true;
            }
            else
            {
                returnValue = false;
            }
            return returnValue;
        }
    }
}
