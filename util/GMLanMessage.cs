using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GMLanDebug.util
{
    public class GMLanMessage
    {

        public readonly string Id; // represents the full id like 0x0C030040
        public readonly bool IsExtended;
        public readonly string Header; // would be 0C0300
        public readonly string Sender; // would be 40
        public readonly string Priority; // would be OC
        public readonly string SenderName;
        public readonly string DLC; // todo maybe make this an int? (size of the data)
        public readonly string Data; // data bytes

        public GMLanMessage(string rawMessage)
        {
            IsExtended = rawMessage.Contains("Extended ID: ");
            var pattern = IsExtended ? @"Extended ID: (0x[\dA-Fa-f]+).*?DLC: (\d+).*?Data: (.+)" : @"Standard ID: (0x[\dA-Fa-f]+).*?DLC: (\d+).*?Data: (.+)";
            var match = Regex.Match(rawMessage, pattern);

            if (!match.Success) throw new Exception($"Incoming message does not match GMLan format: {rawMessage}");
            try
            {
                Id = match.Groups[1].Value; // 0x0C030040
                Header = StripSenderFromId(Id).Replace("0x", ""); // 0C0300
                Priority = GetPriority(Header); // 0C
                Sender = GetSenderId(Id); // 40
                var translation = IsExtended ? LsLan.GetMappedName(Header) : HsLan.GetMappedName(Header); // map Header to KNOWN_SENDER
                SenderName = translation ?? MapSenderToECU(Sender); // or KNOWN_ECU
                DLC = match.Groups[2].Value; // 1-8
                Data = match.Groups[3].Value; // 0x0 0x0 0x0 etc.
            }
            catch (Exception)
            {
                throw new Exception($"Cannot parse to GMLan message: {rawMessage}");
            }

        }
        
        private string StripSenderFromId(string extId)
        {
            return extId.Length > 2 ? extId.Substring(0, extId.Length - 2) : extId;
        }

        private string GetSenderId(string extId)
        {
            if (extId.Length < 2) throw new ArgumentException("extId must have at least 2 characters.");
            return Convert.ToInt32(extId.Substring(extId.Length - 2, 2), 16).ToString();
        }
        
        private string GetPriority(string extId)
        {
            if (extId.Length < 2) throw new ArgumentException("extId must have at least 2 characters.");
            return extId.Substring(0, 2);
        }


        private string MapSenderToECU(string sender)
        {
            var senderId = int.Parse(sender); // todo error handling?
            var ecuRanges = new Dictionary<(int Start, int End), string>
            {
                { (0x00, 0x10), "Powertrain - Integration / Manufacturer Expansion" },
                { (0x10, 0x18), "Powertrain - Engine Controllers" },
                { (0x18, 0x20), "Powertrain - Transmission Controllers" },
                { (0x20, 0x28), "Chassis - Integration / Manufacturer Expansion" },
                { (0x28, 0x30), "Chassis - Brake Controllers" },
                { (0x30, 0x38), "Chassis - Steering Controllers" },
                { (0x38, 0x40), "Chassis - Suspension Controllers" },
                { (0x40, 0x58), "Body - Integration / Manufacturer Expansion" },
                { (0x58, 0x60), "Body - Restraints" },
                { (0x60, 0x70), "Body - Driver Information / Displays" },
                { (0x70, 0x80), "Body - Lighting" },
                { (0x80, 0x90), "Body - Entertainment / Audio" },
                { (0x90, 0x98), "Body - Personal Communication" },
                { (0x98, 0xA0), "Body - Climate Control (HVAC)" },
                { (0xA0, 0xC0), "Body - Convenience (Doors, Seats, Windows, etc.)" },
                { (0xC0, 0xC8), "Body - Security" },
            };

            
            foreach (var range in ecuRanges)
            {
                if (senderId >= range.Key.Start && senderId < range.Key.End)
                {
                    return range.Value;
                }
            }
            return "Unknown ECU";
        }


    }
}