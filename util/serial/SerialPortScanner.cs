using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;


namespace GMLanDebug.util.serial
{
    public class SerialPortScanner
    {
        
        public static List<SerialDevice> GetSerialDevices()
        {
            var devices = new List<SerialDevice>();
        
            try
            {
                // Query WMI for serial port information
                using (var searcher = new ManagementObjectSearcher(
                           "SELECT * FROM Win32_PnPEntity WHERE (PnPClass = 'Ports' OR Name LIKE '%COM%')"))
                {
                    foreach (var o in searcher.Get())
                    {
                        var device = (ManagementObject)o;
                        try
                        {
                            if (!IsLoggingDevice(device)) continue;
                            var port = ExtractComPort(device["caption"].ToString());
                            var ids = ExtractIds(device["DeviceID"].ToString());
                            devices.Add(new SerialDevice()
                            {
                                Port = port,
                                ProductID = ids.Item2,
                                VendorID = ids.Item1
                            });
                        }
                        catch (Exception ex)
                        {
                            // todo more explicit error logging
                            Console.WriteLine($"Error processing device: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // todo more explicit error logging
                Console.WriteLine($"Error scanning for serial devices: {ex.Message}");
            }

            return devices;
        }
        
        /// <summary>
        /// Extract the VID and PID from PNPDeviceID String.
        /// VID is device manufacturer.
        /// PID is specific to the type of device (per-manufacturer).
        /// </summary>
        /// <param name="data">PNPDeviceID String</param>
        /// <returns>VID & PID tuple</returns>
        private static (string, string) ExtractIds(string data)
        {
            var match = Regex.Match(data, @"VID_([0-9A-Fa-f]+)&PID_([0-9A-Fa-f]+)");
            return match.Success ? (match.Groups[1].Value, match.Groups[2].Value) : (null, null);
        }

        private static string ExtractComPort(string data)
        {
            var port = data.Split().Last().Trim().Replace("(", "").Replace(")", "");
            return port;
        }

        private static bool IsLoggingDevice(ManagementObject data)
        {
            // this will pick up any arduino, and is what i use for my logging setup (uno R3 + Seeed Studio CANBUS Shield)
            if (data["Caption"].ToString().Contains("Arduino")) return true;
            // this might need work to recognize other devices/setups
            return data["PNPClass"].ToString().Contains("Ports") && data["Caption"].ToString().Contains("USB");
        }
        
    }
        
        // todo equivalent bluetooth stuff
        
        // if we want to do bluetooth logging, we need to figure out how to use the ELM327 for logging
        // a decent amount of stuff online says it could lag / not catch everything
        // the command to start dumping/logging traffic is ATMA, do more research for how to set it up
        
        //  if we do get fancy enough , we could implement the filtering from FilterControlWindow at a hardware level
        //  i know we can filter for single headers/ids , but not sure if filtering for a group would work
        //  also need to see what the commands are for that (ignore all but this header/only this header)
}