using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace TrackingDeviceSimulator
{
    partial class TrackingDeviceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackingConfigs = new System.Windows.Forms.GroupBox();
            this.firmWareTextBox = new System.Windows.Forms.TextBox();
            this.deviceSerialTextBox = new System.Windows.Forms.TextBox();
            this.maxSpeedTextBox = new System.Windows.Forms.TextBox();
            this.firmwareLabel = new System.Windows.Forms.Label();
            this.deviceSerialLabel = new System.Windows.Forms.Label();
            this.maxSpeedLabel = new System.Windows.Forms.Label();
            this.driverIdTextBox = new System.Windows.Forms.TextBox();
            this.driverId = new System.Windows.Forms.Label();
            this.tripBox = new System.Windows.Forms.GroupBox();
            this.simulateButton = new System.Windows.Forms.Button();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.speedBox = new System.Windows.Forms.GroupBox();
            this.updateSpeedButton = new System.Windows.Forms.Button();
            this.kmLabel = new System.Windows.Forms.Label();
            this.currSpeedTextBox = new System.Windows.Forms.TextBox();
            this.positionBox = new System.Windows.Forms.GroupBox();
            this.headingLabel = new System.Windows.Forms.Label();
            this.latLabel = new System.Windows.Forms.Label();
            this.headingTextBox = new System.Windows.Forms.TextBox();
            this.latTextBox = new System.Windows.Forms.TextBox();
            this.longTextBox = new System.Windows.Forms.TextBox();
            this.nsTextBox = new System.Windows.Forms.TextBox();
            this.ewTextBox = new System.Windows.Forms.TextBox();
            this.longLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ewLabel = new System.Windows.Forms.Label();
            this.gpsTimeTextBox = new System.Windows.Forms.TextBox();
            this.gpdDateTimeLabel = new System.Windows.Forms.Label();
            this.speedWarningLabel = new System.Windows.Forms.Label();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.trackingConfigs.SuspendLayout();
            this.tripBox.SuspendLayout();
            this.speedBox.SuspendLayout();
            this.positionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackingConfigs
            // 
            this.trackingConfigs.Controls.Add(this.firmWareTextBox);
            this.trackingConfigs.Controls.Add(this.deviceSerialTextBox);
            this.trackingConfigs.Controls.Add(this.maxSpeedTextBox);
            this.trackingConfigs.Controls.Add(this.firmwareLabel);
            this.trackingConfigs.Controls.Add(this.deviceSerialLabel);
            this.trackingConfigs.Controls.Add(this.maxSpeedLabel);
            this.trackingConfigs.Controls.Add(this.driverIdTextBox);
            this.trackingConfigs.Controls.Add(this.driverId);
            this.trackingConfigs.Location = new System.Drawing.Point(28, 21);
            this.trackingConfigs.Name = "trackingConfigs";
            this.trackingConfigs.Size = new System.Drawing.Size(254, 144);
            this.trackingConfigs.TabIndex = 0;
            this.trackingConfigs.TabStop = false;
            this.trackingConfigs.Text = "Tracking Device Configurations";
            // 
            // firmWareTextBox
            // 
            this.firmWareTextBox.Enabled = false;
            this.firmWareTextBox.Location = new System.Drawing.Point(119, 96);
            this.firmWareTextBox.Name = "firmWareTextBox";
            this.firmWareTextBox.Size = new System.Drawing.Size(123, 20);
            this.firmWareTextBox.TabIndex = 7;
            // 
            // deviceSerialTextBox
            // 
            this.deviceSerialTextBox.Enabled = false;
            this.deviceSerialTextBox.Location = new System.Drawing.Point(119, 70);
            this.deviceSerialTextBox.Name = "deviceSerialTextBox";
            this.deviceSerialTextBox.Size = new System.Drawing.Size(123, 20);
            this.deviceSerialTextBox.TabIndex = 6;
            // 
            // maxSpeedTextBox
            // 
            this.maxSpeedTextBox.Enabled = false;
            this.maxSpeedTextBox.Location = new System.Drawing.Point(119, 44);
            this.maxSpeedTextBox.Name = "maxSpeedTextBox";
            this.maxSpeedTextBox.Size = new System.Drawing.Size(123, 20);
            this.maxSpeedTextBox.TabIndex = 5;
            // 
            // firmwareLabel
            // 
            this.firmwareLabel.AutoSize = true;
            this.firmwareLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firmwareLabel.Location = new System.Drawing.Point(6, 96);
            this.firmwareLabel.Name = "firmwareLabel";
            this.firmwareLabel.Size = new System.Drawing.Size(112, 16);
            this.firmwareLabel.TabIndex = 4;
            this.firmwareLabel.Text = "Firmware Version";
            // 
            // deviceSerialLabel
            // 
            this.deviceSerialLabel.AutoSize = true;
            this.deviceSerialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceSerialLabel.Location = new System.Drawing.Point(6, 70);
            this.deviceSerialLabel.Name = "deviceSerialLabel";
            this.deviceSerialLabel.Size = new System.Drawing.Size(89, 16);
            this.deviceSerialLabel.TabIndex = 3;
            this.deviceSerialLabel.Text = "Device Serial";
            // 
            // maxSpeedLabel
            // 
            this.maxSpeedLabel.AutoSize = true;
            this.maxSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxSpeedLabel.Location = new System.Drawing.Point(6, 44);
            this.maxSpeedLabel.Name = "maxSpeedLabel";
            this.maxSpeedLabel.Size = new System.Drawing.Size(107, 16);
            this.maxSpeedLabel.TabIndex = 2;
            this.maxSpeedLabel.Text = "Max Speed Limit";
            // 
            // driverIdTextBox
            // 
            this.driverIdTextBox.Enabled = false;
            this.driverIdTextBox.Location = new System.Drawing.Point(119, 16);
            this.driverIdTextBox.Name = "driverIdTextBox";
            this.driverIdTextBox.Size = new System.Drawing.Size(123, 20);
            this.driverIdTextBox.TabIndex = 1;
            // 
            // driverId
            // 
            this.driverId.AutoSize = true;
            this.driverId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driverId.Location = new System.Drawing.Point(6, 16);
            this.driverId.Name = "driverId";
            this.driverId.Size = new System.Drawing.Size(60, 16);
            this.driverId.TabIndex = 0;
            this.driverId.Text = "Driver ID";
            // 
            // tripBox
            // 
            this.tripBox.Controls.Add(this.simulateButton);
            this.tripBox.Controls.Add(this.toTextBox);
            this.tripBox.Controls.Add(this.toLabel);
            this.tripBox.Controls.Add(this.fromTextBox);
            this.tripBox.Controls.Add(this.fromLabel);
            this.tripBox.Location = new System.Drawing.Point(30, 171);
            this.tripBox.Name = "tripBox";
            this.tripBox.Size = new System.Drawing.Size(252, 90);
            this.tripBox.TabIndex = 1;
            this.tripBox.TabStop = false;
            this.tripBox.Text = "Trip";
            // 
            // simulateButton
            // 
            this.simulateButton.Location = new System.Drawing.Point(163, 67);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(77, 23);
            this.simulateButton.TabIndex = 10;
            this.simulateButton.Text = "Simulate Trip";
            this.simulateButton.UseVisualStyleBackColor = true;
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(50, 41);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(190, 20);
            this.toTextBox.TabIndex = 9;
            this.toTextBox.Text = "24.816248,46.629549";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLabel.Location = new System.Drawing.Point(5, 41);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(25, 16);
            this.toLabel.TabIndex = 8;
            this.toLabel.Text = "To";
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(50, 12);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(190, 20);
            this.fromTextBox.TabIndex = 7;
            this.fromTextBox.Text = "24.961306,46.733994";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(5, 13);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(39, 16);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "From";
            // 
            // speedBox
            // 
            this.speedBox.Controls.Add(this.updateSpeedButton);
            this.speedBox.Controls.Add(this.kmLabel);
            this.speedBox.Controls.Add(this.currSpeedTextBox);
            this.speedBox.Location = new System.Drawing.Point(28, 267);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(254, 48);
            this.speedBox.TabIndex = 2;
            this.speedBox.TabStop = false;
            this.speedBox.Text = "Current Speed";
            // 
            // updateSpeedButton
            // 
            this.updateSpeedButton.Location = new System.Drawing.Point(162, 21);
            this.updateSpeedButton.Name = "updateSpeedButton";
            this.updateSpeedButton.Size = new System.Drawing.Size(80, 21);
            this.updateSpeedButton.TabIndex = 2;
            this.updateSpeedButton.Text = "Update";
            this.updateSpeedButton.UseVisualStyleBackColor = true;
            this.updateSpeedButton.Click += new System.EventHandler(this.updateSpeedButton_Click);
            // 
            // kmLabel
            // 
            this.kmLabel.AutoSize = true;
            this.kmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kmLabel.Location = new System.Drawing.Point(107, 21);
            this.kmLabel.Name = "kmLabel";
            this.kmLabel.Size = new System.Drawing.Size(41, 16);
            this.kmLabel.TabIndex = 1;
            this.kmLabel.Text = "KM/H";
            // 
            // currSpeedTextBox
            // 
            this.currSpeedTextBox.Location = new System.Drawing.Point(11, 21);
            this.currSpeedTextBox.Name = "currSpeedTextBox";
            this.currSpeedTextBox.Size = new System.Drawing.Size(90, 20);
            this.currSpeedTextBox.TabIndex = 0;
            this.currSpeedTextBox.Text = "120";
            // 
            // positionBox
            // 
            this.positionBox.Controls.Add(this.headingLabel);
            this.positionBox.Controls.Add(this.latLabel);
            this.positionBox.Controls.Add(this.headingTextBox);
            this.positionBox.Controls.Add(this.latTextBox);
            this.positionBox.Controls.Add(this.longTextBox);
            this.positionBox.Controls.Add(this.nsTextBox);
            this.positionBox.Controls.Add(this.ewTextBox);
            this.positionBox.Controls.Add(this.longLabel);
            this.positionBox.Controls.Add(this.label2);
            this.positionBox.Controls.Add(this.ewLabel);
            this.positionBox.Controls.Add(this.gpsTimeTextBox);
            this.positionBox.Controls.Add(this.gpdDateTimeLabel);
            this.positionBox.Location = new System.Drawing.Point(28, 321);
            this.positionBox.Name = "positionBox";
            this.positionBox.Size = new System.Drawing.Size(254, 189);
            this.positionBox.TabIndex = 3;
            this.positionBox.TabStop = false;
            this.positionBox.Text = "Current Info";
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.Location = new System.Drawing.Point(6, 157);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(60, 16);
            this.headingLabel.TabIndex = 19;
            this.headingLabel.Text = "Heading";
            // 
            // latLabel
            // 
            this.latLabel.AutoSize = true;
            this.latLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latLabel.Location = new System.Drawing.Point(6, 131);
            this.latLabel.Name = "latLabel";
            this.latLabel.Size = new System.Drawing.Size(55, 16);
            this.latLabel.TabIndex = 18;
            this.latLabel.Text = "Latitude";
            // 
            // headingTextBox
            // 
            this.headingTextBox.Enabled = false;
            this.headingTextBox.Location = new System.Drawing.Point(120, 157);
            this.headingTextBox.Name = "headingTextBox";
            this.headingTextBox.Size = new System.Drawing.Size(122, 20);
            this.headingTextBox.TabIndex = 17;
            // 
            // latTextBox
            // 
            this.latTextBox.Enabled = false;
            this.latTextBox.Location = new System.Drawing.Point(120, 131);
            this.latTextBox.Name = "latTextBox";
            this.latTextBox.Size = new System.Drawing.Size(122, 20);
            this.latTextBox.TabIndex = 16;
            // 
            // longTextBox
            // 
            this.longTextBox.Enabled = false;
            this.longTextBox.Location = new System.Drawing.Point(119, 105);
            this.longTextBox.Name = "longTextBox";
            this.longTextBox.Size = new System.Drawing.Size(123, 20);
            this.longTextBox.TabIndex = 15;
            // 
            // nsTextBox
            // 
            this.nsTextBox.Enabled = false;
            this.nsTextBox.Location = new System.Drawing.Point(119, 79);
            this.nsTextBox.Name = "nsTextBox";
            this.nsTextBox.Size = new System.Drawing.Size(123, 20);
            this.nsTextBox.TabIndex = 14;
            // 
            // ewTextBox
            // 
            this.ewTextBox.Enabled = false;
            this.ewTextBox.Location = new System.Drawing.Point(119, 53);
            this.ewTextBox.Name = "ewTextBox";
            this.ewTextBox.Size = new System.Drawing.Size(123, 20);
            this.ewTextBox.TabIndex = 13;
            // 
            // longLabel
            // 
            this.longLabel.AutoSize = true;
            this.longLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longLabel.Location = new System.Drawing.Point(6, 105);
            this.longLabel.Name = "longLabel";
            this.longLabel.Size = new System.Drawing.Size(67, 16);
            this.longLabel.TabIndex = 12;
            this.longLabel.Text = "Longitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "North/South";
            // 
            // ewLabel
            // 
            this.ewLabel.AutoSize = true;
            this.ewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewLabel.Location = new System.Drawing.Point(6, 53);
            this.ewLabel.Name = "ewLabel";
            this.ewLabel.Size = new System.Drawing.Size(70, 16);
            this.ewLabel.TabIndex = 10;
            this.ewLabel.Text = "East/West";
            // 
            // gpsTimeTextBox
            // 
            this.gpsTimeTextBox.Enabled = false;
            this.gpsTimeTextBox.Location = new System.Drawing.Point(119, 25);
            this.gpsTimeTextBox.Name = "gpsTimeTextBox";
            this.gpsTimeTextBox.Size = new System.Drawing.Size(123, 20);
            this.gpsTimeTextBox.TabIndex = 9;
            // 
            // gpdDateTimeLabel
            // 
            this.gpdDateTimeLabel.AutoSize = true;
            this.gpdDateTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpdDateTimeLabel.Location = new System.Drawing.Point(6, 25);
            this.gpdDateTimeLabel.Name = "gpdDateTimeLabel";
            this.gpdDateTimeLabel.Size = new System.Drawing.Size(102, 16);
            this.gpdDateTimeLabel.TabIndex = 8;
            this.gpdDateTimeLabel.Text = "GPS Date Time";
            // 
            // speedWarningLabel
            // 
            this.speedWarningLabel.AutoSize = true;
            this.speedWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.speedWarningLabel.Location = new System.Drawing.Point(23, 527);
            this.speedWarningLabel.Name = "speedWarningLabel";
            this.speedWarningLabel.Size = new System.Drawing.Size(247, 50);
            this.speedWarningLabel.TabIndex = 4;
            this.speedWarningLabel.Text = "Warning: \r\nSpeed Limit Exceeded\r\n";
            this.speedWarningLabel.Visible = false;
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(302, 21);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 14;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(792, 556);
            this.gMap.TabIndex = 5;
            this.gMap.Zoom = 10D;
            this.gMap.Load += new System.EventHandler(this.gMap_Load);
            // 
            // TrackingDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 587);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.speedWarningLabel);
            this.Controls.Add(this.positionBox);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.tripBox);
            this.Controls.Add(this.trackingConfigs);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "TrackingDeviceForm";
            this.Text = "Teacking Device Simulator";
            this.trackingConfigs.ResumeLayout(false);
            this.trackingConfigs.PerformLayout();
            this.tripBox.ResumeLayout(false);
            this.tripBox.PerformLayout();
            this.speedBox.ResumeLayout(false);
            this.speedBox.PerformLayout();
            this.positionBox.ResumeLayout(false);
            this.positionBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox trackingConfigs;
        private System.Windows.Forms.TextBox firmWareTextBox;
        private System.Windows.Forms.TextBox deviceSerialTextBox;
        private System.Windows.Forms.TextBox maxSpeedTextBox;
        private System.Windows.Forms.Label firmwareLabel;
        private System.Windows.Forms.Label deviceSerialLabel;
        private System.Windows.Forms.Label maxSpeedLabel;
        private System.Windows.Forms.TextBox driverIdTextBox;
        private System.Windows.Forms.Label driverId;
        private System.Windows.Forms.GroupBox tripBox;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.GroupBox speedBox;
        private System.Windows.Forms.Label kmLabel;
        private System.Windows.Forms.TextBox currSpeedTextBox;
        private System.Windows.Forms.Button updateSpeedButton;
        private System.Windows.Forms.GroupBox positionBox;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Label latLabel;
        private System.Windows.Forms.TextBox headingTextBox;
        private System.Windows.Forms.TextBox latTextBox;
        private System.Windows.Forms.TextBox longTextBox;
        private System.Windows.Forms.TextBox nsTextBox;
        private System.Windows.Forms.TextBox ewTextBox;
        private System.Windows.Forms.Label longLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ewLabel;
        private System.Windows.Forms.TextBox gpsTimeTextBox;
        private System.Windows.Forms.Label gpdDateTimeLabel;
        private System.Windows.Forms.Label speedWarningLabel;
        private GMap.NET.WindowsForms.GMapControl gMap;
    }
}

