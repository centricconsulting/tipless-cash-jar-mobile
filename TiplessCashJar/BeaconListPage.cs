﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TiplessCashJar
{
	public class BeaconListPage : ContentPage
	{
		ListView deviceListView = new ListView();
		public ObservableCollection<Beacon> DiscoveredBeacons { get; private set; }

		public BeaconListPage ()
		{
			Content = new StackLayout { 
				Children = {
					deviceListView
				}
			};

			DiscoveredBeacons = new ObservableCollection<Beacon>();

			deviceListView.ItemsSource = DiscoveredBeacons;
			deviceListView.ItemSelected += BeaconSelected;

//			App.BluetoothAdapter.DeviceDiscovered += DeviceDiscovered;
//			App.BluetoothAdapter.DeviceConnected += DeviceConnected;
//			App.BluetoothAdapter.StartScanningForDevices();

			App.BeaconManager.BeaconsFound += BeaconsFound;

			List<Beacon> beacons = new List<Beacon> ();
			// test beacon
			beacons.Add(new Beacon("badge 1", 0, "DD915E3B-072C-4223-9A54-308390986793", 57497, 25695, Beacon.Proximity.VeryFar));
			beacons.Add(new Beacon("badge 2", 0, "DD915E3B-072C-4223-9A54-308390986793", 17356, 56347, Beacon.Proximity.VeryFar));

			App.BeaconManager.StartScanning (beacons);
		}

		void BeaconSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var beacon = e.SelectedItem as Beacon;
			if (beacon != null) {
				Navigation.PushAsync (new BeaconPage (beacon));
			}
		}

		protected override void OnDisappearing ()
		{
			App.BeaconManager.StopScanning ();
			base.OnDisappearing ();
		}

		#region BeaconManager callbacks
		void BeaconsFound (object sender, BeaconsFoundEventArgs e)
		{
			if (e.Beacons.Count > 0) {
				DiscoveredBeacons.Clear ();

				foreach (var beacon in e.Beacons) {
					DiscoveredBeacons.Add (beacon);
				}
			}
		}
			
		#endregion
	}
}


