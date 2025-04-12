using System.Collections.Generic;

namespace GMLanDebug.util
{
    public class HsLan
    {
        private static readonly List<GMLanMapping> Translations = new List<GMLanMapping>();


        public static string GetMappedName(string header)
        {
            foreach (var translation in Translations)
            {
                if (translation.Header.Equals(header)) return translation.Name;
            }

            return null;
        }

        public static void Init()
        {
            PopulateTranslations();
        }

        private static void PopulateTranslations()
        {
            Translations.Add(new GMLanMapping("0C1", "Driven Wheel Rotational Status"));
            Translations.Add(new GMLanMapping("0C5", "Non Driven Wheel Rotational Status"));
            Translations.Add(new GMLanMapping("0C7", "Transmission Output Rotational Status"));
            Translations.Add(new GMLanMapping("0C9", "Engine General Status 1"));
            Translations.Add(new GMLanMapping("0F1", "Brake Apply Status"));
            Translations.Add(new GMLanMapping("0F9", "Transmission General Status 1"));
            Translations.Add(new GMLanMapping("150", "High Voltage Battery Information 1"));
            Translations.Add(new GMLanMapping("154", "High Voltage Battery Information 2"));
            Translations.Add(new GMLanMapping("158", "High Voltage Battery Information 3"));
            Translations.Add(new GMLanMapping("17D", "Antilock_Brake_and_TC_Status_HS"));
            Translations.Add(new GMLanMapping("1A1", "PTEI Engine General Status"));
            Translations.Add(new GMLanMapping("1C3", "Engine Torque Status 2"));
            Translations.Add(new GMLanMapping("1C4", "Torque Request Status"));
            Translations.Add(new GMLanMapping("1C5", "Driver Intended Axle Torque Status"));
            Translations.Add(new GMLanMapping("1C7", "Chassis Engine Torque Request 1"));
            Translations.Add(new GMLanMapping("1C8", "Launch Control Request"));
            Translations.Add(new GMLanMapping("1CC", "Secondary Axle Status"));
            Translations.Add(new GMLanMapping("1CE", "Secondary Axle Control"));
            Translations.Add(new GMLanMapping("1CF", "Secondary Axle General Information"));
            Translations.Add(new GMLanMapping("1D0", "Front Axle Status"));
            Translations.Add(new GMLanMapping("1D1", "Rear Axle Status"));
            Translations.Add(new GMLanMapping("1E1", "Cruise Control Switch Status"));
            Translations.Add(new GMLanMapping("1E5", "Steering Wheel Angle"));
            Translations.Add(new GMLanMapping("1E9", "Chassis General Status 1"));
            Translations.Add(new GMLanMapping("1EA", "Alternative Fuel System Status"));
            Translations.Add(new GMLanMapping("1EB", "Fuel System Status"));
            Translations.Add(new GMLanMapping("1ED", "Fuel System Request"));
            Translations.Add(new GMLanMapping("1EF", "Fuel System Request 2"));
            Translations.Add(new GMLanMapping("1F1", "Platform General Status"));
            Translations.Add(new GMLanMapping("1F3", "Platform Transmission Requests"));
            Translations.Add(new GMLanMapping("1F5", "Transmission General Status 2"));
            Translations.Add(new GMLanMapping("1F9", "PTO Command Data"));
            Translations.Add(new GMLanMapping("2B0", "Starter_Generator_Status_3"));
            Translations.Add(new GMLanMapping("2C3", "Engine Torque Status 3"));
            Translations.Add(new GMLanMapping("2CB", "Adaptive Cruise Axle Torque Request"));
            Translations.Add(new GMLanMapping("2F9", "Chassis General Status 2"));
            Translations.Add(new GMLanMapping("3C1", "Powertrain Immobilizer Data"));
            Translations.Add(new GMLanMapping("3C9", "Platform Immobilizer Data"));
            Translations.Add(new GMLanMapping("3D1", "Engine General Status 2"));
            Translations.Add(new GMLanMapping("3E1", "PPEI_Engine_BAS_Status_1"));
            Translations.Add(new GMLanMapping("3E9", "Vehicle Speed and Distance"));
            Translations.Add(new GMLanMapping("3ED", "Vehicle_Limit_Speed_Control_Cmd"));
            Translations.Add(new GMLanMapping("3F1", "Platform Engine Control Request"));
            Translations.Add(new GMLanMapping("3F9", "Engine General Status 3"));
            Translations.Add(new GMLanMapping("3FB", "Engine Fuel Status"));
            Translations.Add(new GMLanMapping("451", "Gateway LS General Information"));
            Translations.Add(new GMLanMapping("4C1", "Engine General Status 4"));
            Translations.Add(new GMLanMapping("4C9", "Transmission General Status 3"));
            Translations.Add(new GMLanMapping("4D1", "Engine General Status 5"));
            Translations.Add(new GMLanMapping("4D9", "Fuel System General Status"));
            Translations.Add(new GMLanMapping("4E1", "Vehicle Identification Digits 10 thru 17"));
            Translations.Add(new GMLanMapping("4E9", "Platform Configuration Data"));
            Translations.Add(new GMLanMapping("4F1", "Powertrain Configuration Data"));
            Translations.Add(new GMLanMapping("4F3", "Powertrain Configuration Data 2"));
            Translations.Add(new GMLanMapping("772", "Diagnostic Trouble Code Information Extended"));
            Translations.Add(new GMLanMapping("77A", "Diagnostic Trouble Code Information Extended"));
            Translations.Add(new GMLanMapping("77F", "Diagnostic Trouble Code Information Extended"));
            Translations.Add(new GMLanMapping("3F3", "Power Pack General Status"));
            Translations.Add(new GMLanMapping("3F7", "Hybrid Temperature Status"));
            Translations.Add(new GMLanMapping("1D9", "Hybrid Balancing Request"));
            Translations.Add(new GMLanMapping("1DE", "Hybrid Battery General Status"));
        }
    }
}