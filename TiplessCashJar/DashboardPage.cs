using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace TiplessCashJar
{
	public class DashboardPage : ContentPage
	{
		static double alertDistance = 0.5;

		List<Beacon> beacons = new List<Beacon> ();

		Button donateButton = new Button {
			Text = "Donate"
		};

		Button profileButton = new Button {
			Text = "Profile"
		};

		Button beaconsButton = new Button {
			Text = "Beacons"
		};

		public DashboardPage ()
		{

			Content = new StackLayout { 
				Children = {
//					donateButton,
					profileButton,
					beaconsButton
				}
			};

			donateButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new DonatePage());
			};

			profileButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new ProfilePage());
			};

			beaconsButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new BeaconListPage());
			};
		}

		protected override void OnAppearing()
		{            
			base.OnAppearing();

			// test beacons
			beacons.Add(new Beacon("badge 1", 0, "DD915E3B-072C-4223-9A54-308390986793", 57497, 25695, Beacon.Proximity.VeryFar));
			beacons.Add(new Beacon("badge 2", 0, "DD915E3B-072C-4223-9A54-308390986793", 17356, 56347, Beacon.Proximity.VeryFar));

			if (App.BeaconManager != null) {
				App.BeaconManager.BeaconsFound += BeaconsFound;
				App.BeaconManager.StartScanning (beacons);
			}
		}

		protected override void OnDisappearing ()
		{
			if (App.BeaconManager != null)
				App.BeaconManager.StopScanning ();
			base.OnDisappearing ();
		}

		#region BeaconManager callbacks
		async void BeaconsFound (object sender, BeaconsFoundEventArgs e)
		{
			if (e.Beacons.Count > 0) {
				List<Beacon> SortedBeacons = e.Beacons.OrderBy(o=>o.Distance).ToList();
				Beacon closest = SortedBeacons [0];

				if (closest.Distance < alertDistance) {
					var myBeacon = beacons.Find (Beacon.Matcher (closest));
					var name = "";
					if (myBeacon != null)
						name = myBeacon.Name;

					var answer = await DisplayAlert ("Tipless Cash Jar", "Would you like to donate to " + name + "?", "Yes", "No");
					if (answer) {
						App.BeaconManager.StopScanning ();
						Navigation.PushAsync (new DonatePage ());
					}
				}
			}
		}

		#endregion

	}
}


