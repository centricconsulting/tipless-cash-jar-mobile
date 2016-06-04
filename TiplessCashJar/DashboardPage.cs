using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TiplessCashJar
{
	public class DashboardPage : ContentPage
	{
		static double alertDistance = 0.5;

		List<Beacon> beacons = new List<Beacon> ();

		Button donateButton = new Button {
			Text = "Donate",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

		Button profileButton = new Button {
			Text = "Profile",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

        Button accountActivityButton = new Button
        {
            Text = "Account Activity",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

        Button beaconsButton = new Button {
			Text = "Beacons",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

		public DashboardPage ()
		{
            this.BackgroundColor = Color.FromHex("#C3CFF7");
            
            Content = new StackLayout {
                Padding = new Thickness(20),
            Children = {
//					donateButton,
					profileButton,
                    accountActivityButton,
                    beaconsButton
				}
			};

			donateButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new DonatePage(""));
			};

			profileButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new ProfilePage());
			};

            accountActivityButton.Clicked += async (object sender, EventArgs e) => {
                await Navigation.PushAsync(new AccountActivityPage());
            };

            beaconsButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new BeaconListPage());
			};
		}

		protected override void OnAppearing()
		{            
			base.OnAppearing();

			// test beacons
			//beacons.Add(new Beacon("badge 1", 0, "DD915E3B-072C-4223-9A54-308390986793", 57497, 25695, Beacon.Proximity.VeryFar));
			//beacons.Add(new Beacon("badge 2", 0, "DD915E3B-072C-4223-9A54-308390986793", 17356, 56347, Beacon.Proximity.VeryFar));
			beacons = App.Beacons;

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

					var answer = await DisplayAlert ("OpenAlms", "Would you like to donate to " + name + "?", "Yes", "No");
					if (answer) {
						App.BeaconManager.StopScanning ();
						Navigation.PushAsync (new DonatePage (myBeacon.Name));
					} else {
						await callRefusalWebservice (myBeacon.Name);
					}
				}
			}
		}

		#endregion

		protected async Task callRefusalWebservice(String beaconNumber) {
			String urlRoot = "https://tipless-cash-jar-dev.azurewebsites.net/api/refuse/" + beaconNumber;

			HttpClient client = new HttpClient ();
			Uri uri = new Uri (urlRoot);

			client.DefaultRequestHeaders
				.Accept
				.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.PostAsync (uri, null);

			if (response.IsSuccessStatusCode) {
				String confirmation = await response.Content.ReadAsStringAsync ();
			}
		}
	}
}


