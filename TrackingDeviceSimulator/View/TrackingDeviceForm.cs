using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public void initMap()
        {
            this.gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            Debug.WriteLine("iniating map");
            gMap.SetPositionByKeywords("Riyadh, Saudi Arabia");
        }

        public void drawRoute(GMapOverlay routes)
        {
            this.gMap.Overlays.Add(routes);
            this.gMap.Zoom = 13;
        }

        private void gMap_Load(object sender, EventArgs e)
        {
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            this.gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            Debug.WriteLine("iniating map");
            gMap.SetPositionByKeywords("Riyadh, Saudi Arabia");
        }
    }
}
