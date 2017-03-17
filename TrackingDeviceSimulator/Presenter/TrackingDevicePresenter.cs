﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TrackingDeviceSimulator.Model;
using TrackingDeviceSimulator.View;
using Newtonsoft.Json;
using System.Diagnostics;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Drawing;
using System.Device.Location;
using System.Threading;

namespace TrackingDeviceSimulator.Presenter
{

    class TrackingDevicePresenter
    {
        private readonly ITrackingDviceView _view;

        public TrackingDeviceReading currReading;
        public List<GeoCoordinate> currentRoutePoints;

        private RouteTransferObject RTO;

        public TrackingDevicePresenter(ITrackingDviceView view)
        {
            _view = view;
            _view.presenter = this;

            InitializeView();
        }

        //Get device configuration from xml and display them
        private void InitializeView()
        {
            var configs = XDocument.Load("TrackerConfigurations.xml");
            var configItems = configs.Root.Descendants();
            Dictionary<string, string> configDict = new Dictionary<string, string>();

            foreach (var item in configItems)
            {
                configDict.Add(item.Name.ToString(), item.Value);
            }
            _view.DriverId = configDict["DriverID"];
            _view.DeviceSerial = configDict["DeviceSerial"];
            _view.MaxSpeed = configDict["MaxSpeed"];
            _view.FirmWareVersion = configDict["FirmWareVersion"];

            currReading = new TrackingDeviceReading();
            updateSpeed(120);

        }

        //Update the vehicle's speed
        public void updateSpeed(int newSpeed)
        {
            currReading.Speed = newSpeed;
            int maxSpeed = Int32.Parse(_view.MaxSpeed);
            if (newSpeed > maxSpeed) _view.speedWarning(true);
            else _view.speedWarning(false);
        }

        // Initiate the route when the user inputs the coordinates
        // gets called when the "Simulate" button is clicked
        public void initRoute(string from, string to)
        {
            var json = new WebClient().DownloadString("http://maps.googleapis.com/maps/api/directions/json?origin=" + from
                                                        + "&destination=" + to + "&sensor=false");
            RTO = JsonConvert.DeserializeObject<RouteTransferObject>(json);
            int numberSteps = RTO.routes[0].legs[0].steps.Length;
            currentRoutePoints = drawRoute(RTO.routes[0].legs[0].steps);
            Bearing currBearing = calculateBearing(currentRoutePoints[0].Longitude, currentRoutePoints[0].Latitude, currentRoutePoints[1].Longitude, currentRoutePoints[1].Latitude);
            updateCurrentReading(currentRoutePoints[0].Latitude, currentRoutePoints[0].Longitude, currBearing.EW, currBearing.NS, currBearing.heading);
            //Thread thread = new Thread(() => drive(currentRoutePoints, currReading));
            //thread.Start();
            //drive(currentRoutePoints, currReading);
        }

        //Draw the overall Route on the map
        public List<GeoCoordinate> drawRoute(Step[] steps)
        {
            Debug.WriteLine("drawing routes");
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            List<GeoCoordinate> allPoints = new List<GeoCoordinate>();
            foreach (Step step in steps)
            {
                List<GeoCoordinate> locations = DecodePolylinePoints(step.polyline.points);
                allPoints = allPoints.Concat(locations).ToList();
                foreach (GeoCoordinate loc in locations)
                {
                    points.Add(new PointLatLng(loc.Latitude, loc.Longitude));
                }
            }
            GMapRoute route = new GMapRoute(points, "Commute home");
            route.Stroke = new Pen(Color.Red, 3);
            routes.Routes.Add(route);
            _view.drawRoute(routes);
            return allPoints;
        }

        //Update the current reading object then pass it to the view to display it
        public void updateCurrentReading(double latitude, double longitude, EastWest ew, NorthSouth ns, string heading)
        {
            Debug.WriteLine("updating current reading");
            currReading.GpsDateTime = DateTime.Now;
            currReading.Latitude = latitude;
            currReading.Longitude = longitude;
            currReading.NS = ns;
            currReading.EW = ew;
            currReading.Heading = heading;
            _view.updateReading(currReading);
        }

        //Get usable information from each polyline object in each step in the form of 
        //a list of coordinates.
        //https://www.codeproject.com/tips/312248/google-maps-direction-api-v3-polyline-decoder
        private List<GeoCoordinate> DecodePolylinePoints(string encodedPoints)
        {
            if (encodedPoints == null || encodedPoints == "") return null;
            List<GeoCoordinate> poly = new List<GeoCoordinate>();
            char[] polylinechars = encodedPoints.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            try
            {
                while (index < polylinechars.Length)
                {
                    // calculate next latitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length)
                        break;

                    currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                    //calculate next longitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length && next5bits >= 32)
                        break;

                    currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                    GeoCoordinate p = new GeoCoordinate();
                    p.Latitude = Convert.ToDouble(currentLat) / 100000.0;
                    p.Longitude = Convert.ToDouble(currentLng) / 100000.0;
                    poly.Add(p);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return poly;
        }

        // Direction and angle
        public Bearing calculateBearing(double x1, double y1, double x2, double y2)
        {
            Bearing currBearing = new Bearing();

            //x2 > x1 east y2 > y1 north
            if (x2 > x1) currBearing.EW = EastWest.East;
            else if (x2 < x1) currBearing.EW = EastWest.West;

            if (y2 > y1) currBearing.NS = NorthSouth.North;
            else if (y2 < y1) currBearing.NS = NorthSouth.South;

            currBearing.heading = calculateHeading(x1, y1, x2, y2).ToString();

            return currBearing;
        }

        // angle
        public double calculateHeading(double x1, double y1, double x2, double y2)
        {
            //Difference in lng
            double dx = x2 - x1;

            //Difference in lat
            double dy = y2 - y1;
            
            var y = Math.Sin(dx) * Math.Cos(y2);
            var x = (Math.Cos(y1) * Math.Sin(y2)) -
                    (Math.Sin(y1) * Math.Cos(y2) * Math.Cos(dx));
            var angle = Math.Atan2(y, x) * (180 / Math.PI);
            var bearing = (angle + 360) % 360;
            return bearing;
        }

        public void drive(List<GeoCoordinate> route, TrackingDeviceReading reading)
        {
            GeoCoordinate curr = route[0];
            double distance = 0;
            int step = 0;

            // meters per millisecond
            double speed = reading.Speed * 0.000277778;
            // in milliseconds
            double timeTil = 0;

            while (step < route.Count){
                curr = route[step];
                Bearing currBearing = calculateBearing(curr.Longitude, curr.Latitude, curr.Longitude, curr.Latitude);
                updateCurrentReading(curr.Latitude, curr.Longitude, currBearing.EW, currBearing.NS, currBearing.heading);
                //Calculate distance in meters
                distance = curr.GetDistanceTo(route[step+1]);
                //calculate time to distance
                timeTil = distance / speed;
                //wait then update
                Debug.WriteLine("step = " + step + " speed = " + Convert.ToInt32(timeTil) + " total steps " + route.Count);
                System.Threading.Thread.Sleep(Convert.ToInt32(timeTil));
                //System.Threading.Thread.Sleep(timeTil);
                step++;
            }
            //last point
            //curr = route[step];
        }
    }
}