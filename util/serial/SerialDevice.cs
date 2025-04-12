using System;
using System.Collections.Generic;

namespace GMLanDebug.util.serial
{
    public class SerialDevice
    {
        public string Port { get; set; }
        public string ProductID { get; set; }
        public string VendorID { get; set; }


        public bool IsArduino => VendorID?.Equals("2341", StringComparison.OrdinalIgnoreCase) ?? false;

        public override string ToString()
        {
            return $"Port: {Port}, Vendor ID: {VendorID}, Product ID: {ProductID}";
        }
    }
}