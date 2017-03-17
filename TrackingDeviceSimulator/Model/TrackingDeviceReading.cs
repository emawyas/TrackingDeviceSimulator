using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingDeviceSimulator.Model
{
    public enum EastWest { East, West }
    public enum NorthSouth { North, South }

    public class TrackingDeviceReading
    {
        public DateTime GpsDateTime { get; set; }

        public EastWest EW { get; set; }

        public NorthSouth NS { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Heading { get; set; }

        public int Speed { get; set; }
    }
}
