using System.Windows.Forms;
using GMLanDebug.util.serial;

namespace GMLanDebug.ui
{
    public class SerialDeviceListViewItem : ListViewItem
    {

        public SerialDevice SerialDevice;

        public SerialDeviceListViewItem(SerialDevice device) : base(device.Port)
        {
            SerialDevice = device;
            if (device.IsArduino)
            {
                Text += " (Arduino)";
                var ardType = SerialUtils.GetArduinoName(device.ProductID);
                if (ardType != null) Text += $" [{ardType}]";
            }
        }

        public SerialDevice GetDevice()
        {
            return SerialDevice;
        }
    }
}