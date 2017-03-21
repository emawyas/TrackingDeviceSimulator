using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingDeviceSimulator.Model
{

    public class RouteTransferObject
    {
        public Geocoded_Waypoints[] geocoded_waypoints { get; set; }
        public Route[] routes { get; set; }
        public string status { get; set; }
    }

    public class Geocoded_Waypoints
    {
        public string geocoder_status { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
    }

    public class Route
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public Leg[] legs { get; set; }
        public Overview_Polyline overview_polyline { get; set; }
        public string summary { get; set; }
        public object[] warnings { get; set; }
        public object[] waypoint_order { get; set; }
    }

    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public Location end_location { get; set; }
        public string start_address { get; set; }
        public Location start_location { get; set; }
        public Step[] steps { get; set; }
        public object[] traffic_speed_entry { get; set; }
        public object[] via_waypoint { get; set; }
    }

    public class Step
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public Location end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public Location start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }

    public class Bearing
    {
        public string heading { get; set; }
        public NorthSouth NS { get; set; }
        public EastWest EW { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Southwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Overview_Polyline
    {
        public string points { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }

    public class Simulation
    {
        public Simulation(List<GeoCoordinate> route, TrackingDeviceReading reading)
        {
            entireRoute = route;
            currReading = reading;
        }
        public List<GeoCoordinate> entireRoute { get; set; }
        public TrackingDeviceReading currReading { get; set; }
    }

    public class RouteProgress
    {
        public GMapOverlay markers { get; set; }
        public GeoCoordinate[] coords { get; set; }
    }

}
