﻿using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingDeviceSimulator.Model;

namespace TrackingDeviceSimulator.View
{
    interface ITrackingDviceView
    {
        string DriverId { get; set; }

        string MaxSpeed { get; set; }

        string DeviceSerial { get; set; }

        string FirmWareVersion { get; set; }

        Presenter.TrackingDevicePresenter presenter { set; }

        void speedWarning(bool alert);

        void updateReading(TrackingDevice device);

        void drawRoute(GMapOverlay routes);

        void placeMarkers(GMapOverlay markers);

        void startSimulation(Simulation obj);

        void displayErrorMessage(string msg);
    }
}
