using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingDeviceSimulator.Model
{
    public class TrackingDevice
    {
        // Configurations loaded from an XML file
        public string DriverId { get; set; }

        public int MaxSpeed { get; set; }

        public string DeviceSerial { get; set; }

        public string FirmWareVersion { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }

        public string heading { get; set; }

        public string EW { get; set; }

        public string NS { get; set; }

        public DateTime GpsDateTime { get; set; }

        public int Speed { get; set; }

        public string CompleteRoute { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

    }
}
