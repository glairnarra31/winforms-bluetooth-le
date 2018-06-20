using SDKTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;

namespace BleSirLo
{
    public partial class Form1 : Form
    {

        private List<DeviceInformation> UnknownDevices = new List<DeviceInformation>();
        private List<DeviceInformation> _knownDevices = new List<DeviceInformation>();
        private IReadOnlyList<GattCharacteristic> characteristics;
        private IReadOnlyList<GattDeviceService> services;

        private GattDeviceService currentSelectedService = null;
        private GattCharacteristic currentSelectedCharacteristic = null;

        private DeviceWatcher deviceWatcher;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void StartBleDeviceWatcher()
        {
            // Additional properties we would like about the device.
            // Property strings are documented here https://msdn.microsoft.com/en-us/library/windows/desktop/ff521659(v=vs.85).aspx
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected", "System.Devices.Aep.Bluetooth.Le.IsConnectable" };

            // BT_Code: Example showing paired and non-paired in a single query.
            string aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

            deviceWatcher =
                    DeviceInformation.CreateWatcher(
                        aqsAllBluetoothLEDevices,
                        requestedProperties,
                        DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            //deviceWatcher.Removed += DeviceWatcher_Removed;
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            //deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start over with an empty collection.
            _knownDevices.Clear();
            deviceWatcher.Start();
        }

        private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            return;
        }

        private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {
            Respond("Device Enumeration Completed");
            ScanBtn.Enabled = true;
        }

        private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            //Debug.WriteLine(String.Format("Device Found!" + Environment.NewLine + "ID:{0}" + Environment.NewLine + "Name:{1}", deviceInfo.Id, deviceInfo.Name));

            //notify user for every device that is found
            Respond(String.Format("Device Found!" + Environment.NewLine + "ID:{0}" + Environment.NewLine + "Name:{1}", deviceInfo.Id, deviceInfo.Name));

            if (sender == deviceWatcher)
            {
                if (!_knownDevices.Contains(deviceInfo))
                {
                    if (deviceInfo.Name != string.Empty)
                    {
                        _knownDevices.Add(deviceInfo);
                        DevicesComboBox.Items.Add(deviceInfo.Name);
                    }
                    else
                    {
                        UnknownDevices.Add(deviceInfo);
                    }
                }
            }
        }

        //trigger StartBleDeviceWatcher() to start bluetoothLe Operation
        private void ScanBtn_Click(object sender, EventArgs e)
        {
            //empty bluetooth inputs
            DevicesComboBox.Items.Clear();
            CharacteristicsTxtBox.Clear();
            ServiceTxtBox.Clear();

            //empty devices list
            _knownDevices.Clear();
            UnknownDevices.Clear();

            //notify user
            Respond("Scanning nearby devices...");

            //disable scan button
            ScanBtn.Enabled = false;

            //finally, start scanning
            StartBleDeviceWatcher();
        }

        //function that handles printing messages to the textbox
        public void Respond(string message)
        {
            //append text to current text + new line
            Response.AppendText(message + Environment.NewLine);
            //scroll to the bottom most
            Response.ScrollToCaret();
        }

        //function that handles the connect click event when there is a selected device
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (DevicesComboBox.SelectedIndex != -1 && ServiceTxtBox.Text != "" && CharacteristicsTxtBox.Text != "")
            {
                //start connecting to device
                ConnectDevice(_knownDevices[DevicesComboBox.SelectedIndex]);
            }
            else
            {
                //conditions not met
                Respond("Please select a device and fill up characterics and services textbox!");
            }
        }

        private async void ConnectDevice(DeviceInformation deviceInfo)
        {
            //disable connect button
            ConnectBtn.Enabled = false;

            Respond("Connecting to device...");

            //get bluetooth device information
            BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
            //Respond(bluetoothLeDevice.ConnectionStatus.ToString());

            //get its services
            GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();

            //verify if getting success 
            if (result.Status == GattCommunicationStatus.Success)
            {
                //store device services to list
                services = result.Services;

                //loop each services in list
                foreach (var serv in services)
                {
                    //get serviceName by converting the service UUID
                    string ServiceName = Utilities.ConvertUuidToShortId(serv.Uuid).ToString();

                    //if current servicename matches the input service name
                    if (ServiceName == ServiceTxtBox.Text)
                    {
                        //notify the user that it found the service
                        Respond("Service found...");

                        //store the current service
                        currentSelectedService = serv;

                        //get the current service characteristics
                        GattCharacteristicsResult resultCharacterics = await serv.GetCharacteristicsAsync();

                        //verify if getting characteristics is success 
                        if (resultCharacterics.Status == GattCommunicationStatus.Success)
                        {
                            //store device services to list
                            characteristics = resultCharacterics.Characteristics;

                            //loop through its characteristics
                            foreach (var chara in characteristics)
                            {
                                //get CharacteristicName by converting the current characteristic UUID
                                string CharacteristicName = Utilities.ConvertUuidToShortId(chara.Uuid).ToString();

                                //if current CharacteristicName matches the input characteristic name
                                if (CharacteristicName == CharacteristicsTxtBox.Text)
                                {
                                    //notify the user that it found the characteristicName
                                    Respond("Characteristic found...");

                                    //store the current characteristic
                                    currentSelectedCharacteristic = chara;

                                    //notify the user that it has connected successfully to the device
                                    Respond("Connected Successfully!");

                                    //stop method execution
                                    return;
                                }
                            }
                            //notify that no characteristicname matched the input characteristic
                            Respond("Characteristic not found...");
                        }
                        else
                        {
                            //notify the user that it has problem getting current service characteristics
                            Respond("Unable to get device service characterics!");
                        }
                    }
                }
                //notify that no servicename matched the input service
                Respond("Service not found...");
            }
            else
            {
                //notify the user that it has problem getting its services
                Respond("Unable to get device services!");
            }

            //if unable to connect set enable connectbtn again
            ConnectBtn.Enabled = true;
        }

        //function that handles write event
        private async void WriteBtn_Click(object sender, EventArgs e)
        {
            if (currentSelectedService != null && currentSelectedCharacteristic != null)
            {
                GattCharacteristicProperties properties = currentSelectedCharacteristic.CharacteristicProperties;
                if (properties.HasFlag(GattCharacteristicProperties.Write))
                {
                    var writer = new DataWriter();
                    var startCommand = Encoding.ASCII.GetBytes(InputTxtBox.Text);
                    writer.WriteBytes(startCommand);

                    GattCommunicationStatus result = await currentSelectedCharacteristic.WriteValueAsync(writer.DetachBuffer());
                    if (result == GattCommunicationStatus.Success)
                    {
                        Respond("message sent successfully");
                    }
                    else
                    {
                        Respond("Error encountered on writing to characteristic!");
                    }
                }
                else
                {
                    Respond("No write property for this characteristic!");
                }
            }
            else
            {
                Respond("Please connect to a device first!");
            }
        }

        //if devices change disconnect
        private void DevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSelectedService = null;
            currentSelectedCharacteristic = null;
            ConnectBtn.Enabled = true;
            CharacteristicsTxtBox.Clear();
            ServiceTxtBox.Clear();
        }

        //function that handles the read button event
        private async void ReadBtn_Click(object sender, EventArgs e)
        {
            if (currentSelectedService != null && currentSelectedCharacteristic != null)
            {
                GattCharacteristicProperties properties = currentSelectedCharacteristic.CharacteristicProperties;

                //if selected characteristics has read property
                if (properties.HasFlag(GattCharacteristicProperties.Read))
                {
                    //read value asynchronously
                    GattReadResult result = await currentSelectedCharacteristic.ReadValueAsync();
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        var reader = DataReader.FromBuffer(result.Value);
                        byte[] input = new byte[reader.UnconsumedBufferLength];
                        reader.ReadBytes(input);
                        Respond(Encoding.ASCII.GetString(input));
                    }
                    else
                    {
                        Respond("Error encountered on reading characteristic value!");
                    }
                }
                else
                {
                    Respond("No read property for this characteristic!");
                }
            }
            else
            {
                Respond("Please connect to a device first!");
            }
        }

    }
}
