using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TiplessCashJar
{
	public class BeaconListPage : ContentPage
	{
		ListView deviceListView = new ListView();
		public ObservableCollection<Beacon> DiscoveredBeacons { get; private set; }
		List<Beacon> beacons = new List<Beacon> ();

		public BeaconListPage ()
		{
            this.BackgroundColor = Color.FromHex("#C3CFF7");

            Content = new StackLayout {
                Padding = new Thickness(20),
                Children = {
					deviceListView
				}
			};

			DiscoveredBeacons = new ObservableCollection<Beacon>();

			deviceListView.ItemsSource = DiscoveredBeacons;
			deviceListView.ItemSelected += BeaconSelected;

			// test beacons
			beacons.Add(new Beacon("badge 1", 0, "DD915E3B-072C-4223-9A54-308390986793", 57497, 25695, Beacon.Proximity.VeryFar));
			beacons.Add(new Beacon("badge 2", 0, "DD915E3B-072C-4223-9A54-308390986793", 17356, 56347, Beacon.Proximity.VeryFar));

			if (App.BeaconManager != null) {
				App.BeaconManager.BeaconsFound += BeaconsFound;
				App.BeaconManager.StartScanning (beacons);
			}
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
			if (App.BeaconManager != null)
				App.BeaconManager.StopScanning ();
			base.OnDisappearing ();
		}

		#region BeaconManager callbacks
		void BeaconsFound (object sender, BeaconsFoundEventArgs e)
		{
			if (e.Beacons.Count > 0) {
				List<Beacon> SortedBeacons = e.Beacons.OrderBy(o=>o.Distance).ToList();
				DiscoveredBeacons.Clear ();
				foreach (var beacon in SortedBeacons) {
					var myBeacon = beacons.Find (Beacon.Matcher (beacon));

					if (myBeacon != null) {
						myBeacon.Distance = beacon.Distance;
						DiscoveredBeacons.Add (myBeacon);
					}
				}
			}
		}
			
		#endregion
	}
}


