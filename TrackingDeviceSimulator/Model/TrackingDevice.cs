using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingDeviceSimulator.Model
{
    class TrackingDevice
    {
        // Configurations loaded from an XML file
        public string DriverId { get; set; }

        public int MaxSpeed { get; set; }

        public string DeviceSerial { get; set; }

        public string FirmWareVersion { get; set; }
    }
}
