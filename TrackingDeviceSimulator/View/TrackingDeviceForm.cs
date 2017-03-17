using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackingDeviceSimulator.Model;
using TrackingDeviceSimulator.Presenter;
using TrackingDeviceSimulator.View;

namespace TrackingDeviceSimulator
{
    internal partial class TrackingDeviceForm : Form, ITrackingDviceView
    {

        public TrackingDeviceForm()
        {
            InitializeComponent();
        }

        public string DeviceSerial
        {
            get { return this.deviceSerialTextBox.Text; }

            set { this.deviceSerialTextBox.Text = value; }
        }

        public string DriverId
        {
            get { return this.driverIdTextBox.Text; }

            set { this.driverIdTextBox.Text = value; }
        }

        public string FirmWareVersion
        {
            get { return this.firmWareTextBox.Text; }

            set { this.firmWareTextBox.Text = value; }
        }

        public string MaxSpeed
        {
            get { return this.maxSpeedTextBox.Text; }

            set { this.maxSpeedTextBox.Text = value; }
        }

        public TrackingDevicePresenter presenter
        {
            private get; set;
        }


        private void updateSpeedButton_Click(object sender, EventArgs e)
        {
            var value = this.currSpeedTextBox.Text;
            int newSpeed = 0;
            if (value.Length > 0 && Int32.TryParse(value, out newSpeed) && newSpeed > 0)
            {
                newSpeed = Int32.Parse(this.currSpeedTextBox.Text);
                presenter.updateSpeed(newSpeed);
            }
            else
            {
                MessageBox.Show("Please eneter a valid value");
            }
        }

        //Show speed warning
        public void speedWarning(bool alert)
        {
            this.speedWarningLabel.Visible = alert;
        }

        // Start route simulation
        private void simulateButton_Click(object sender, EventArgs e)
        {
            var from = this.fromTextBox.Text.Split(',');
            var to = this.toTextBox.Text.Split(',');

            double sourceLat, sourceLong, destLat, destLong;

            if ((from.Length ==2 && to.Length == 2)
                && (Double.TryParse(from[0], out sourceLat) && Double.TryParse(from[1], out sourceLong))
                && (Double.TryParse(to[0], out destLat) && Double.TryParse(to[1], out destLong)))
            {
                presenter.initRoute(sourceLat + "," + sourceLong, destLat + "," + destLong);
                this.fromTextBox.Enabled = false;
                this.toTextBox.Enabled = false;
                this.simulateButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please eneter valid values");
            }
        }

        public void updateReading(TrackingDeviceReading reading)
        {
            this.gpsTimeTextBox.Text = reading.GpsDateTime.ToString();
            this.latTextBox.Text = reading.Latitude.ToString();
            this.longTextBox.Text = reading.Longitude.ToString();
            this.ewTextBox.Text = reading.EW.ToString();
            this.nsTextBox.Text = reading.NS.ToString();
            this.headingTextBox.Text = reading.Heading;
            this.gMap.Position = new GMap.NET.PointLatLng(reading.Latitude, reading.Longitude);
        }

        public void drawRoute(GMapOverlay routes)
        {
            this.gMap.Overlays.Add(routes);
            this.gMap.Zoom = 13;
        }

        public void placeMarkers(GMapOverlay markers)
        {
            gMap.Overlays.Add(markers);
        }

        public void startSimulation(Simulation obj)
        {
            simulateDrive.RunWorkerAsync(obj);
        }

        private void gMap_Load(object sender, EventArgs e)
        {
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            this.gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.ShowCenter = false;
            Debug.WriteLine("iniating map");
            gMap.SetPositionByKeywords("Riyadh, Saudi Arabia");
        }

        private void simulateDrive_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine("prog changed");
            RouteProgress routeProgress = (RouteProgress)e.UserState;
            var coords = routeProgress.coords;
            var markers = routeProgress.markers;

            Bearing currBearing = presenter.calculateBearing(coords[0].Longitude, coords[0].Latitude, coords[1].Longitude, coords[1].Latitude);
            presenter.updateCurrentReading(coords[0].Latitude, coords[0].Longitude, currBearing.EW, currBearing.NS, currBearing.heading);

            placeMarkers(markers);
        }

        private void simulateDrive_DoWork(object sender, DoWorkEventArgs e)
        {
            Simulation sim = (Simulation) e.Argument;
            List<GeoCoordinate> route = sim.entireRoute;
            TrackingDeviceReading reading = sim.currReading;

            BackgroundWorker reporter = (BackgroundWorker)sender;

            GeoCoordinate curr = route[0];
            double distance = 0;
            int step = 0;

            // meters per millisecond
            double speed = reading.Speed * 0.000277778;
            // in milliseconds
            double timeTil = 0;

            //Return Values
            GeoCoordinate[] coords = new GeoCoordinate[2];
            GMapOverlay markers = new GMapOverlay("markers");

            RouteProgress routeProgress = new RouteProgress();

            while (step < route.Count-1)
            {
                curr = route[step];

                // move to on progress
                //Bearing currBearing = calculateBearing(curr.Longitude, curr.Latitude, curr.Longitude, curr.Latitude);
                //updateCurrentReading(curr.Latitude, curr.Longitude, currBearing.EW, currBearing.NS, currBearing.heading);

                coords[0] = new GeoCoordinate(curr.Latitude, curr.Longitude);
                coords[1] = new GeoCoordinate(route[step++].Latitude, route[step++].Longitude);

                //Calculate distance in meters
                if (step + 1 < route.Count)
                    distance = curr.GetDistanceTo(route[step + 1]);
                else
                    distance = 0;
                //calculate time to distance
                timeTil = distance / speed;
                //wait then update
                Debug.WriteLine("step = " + step + " speed = " + Convert.ToInt32(timeTil) + " total steps " + route.Count);

                //place the marker on the map
                GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(route[step].Latitude, route[step].Longitude),
                GMarkerGoogleType.arrow);
                markers.Clear();
                markers.Markers.Add(marker);
                
                // Prepare and send the progress report
                routeProgress.markers = markers;
                routeProgress.coords = coords;
                reporter.ReportProgress(0, routeProgress);

                if (step + 1 < route.Count)
                    System.Threading.Thread.Sleep(Convert.ToInt32(timeTil));

                step++;
            }
        }
    }
}
