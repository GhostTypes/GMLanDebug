using System;
using System.Windows.Forms;
using GMLanDebug.util.serial;

namespace GMLanDebug.ui
{
    public partial class SerialDevicePicker : Form
    {
        public SerialDevicePicker()
        {
            InitializeComponent();
        }

        public SerialDevice SelectedDevice => selectedDevice;

        private SerialDevice selectedDevice;
        

        public void ScanAndPopulate()
        {
            var scan = SerialPortScanner.GetSerialDevices();
            if (scan.Count < 1)
            {
                // todo no devices found
                return;
            }

            foreach (var device in scan)
            {
                serialDeviceList.Items.Add(new SerialDeviceListViewItem(device));
            }
        }

        private void SerialDevicePicker_Load(object sender, EventArgs e)
        {
            
        }
        
        private void SerialDevicePicker_Shown(object sender, EventArgs e)
        {
            ScanAndPopulate();
        }

        private void serialDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        { // update selected device
            if (serialDeviceList.SelectedItems.Count == 0) return; // this seems silly
            selectedDevice = ((SerialDeviceListViewItem)serialDeviceList.SelectedItems[0]).SerialDevice;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (selectedDevice != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No device selected!", "Cannot connect");
            }
        }
    }
}