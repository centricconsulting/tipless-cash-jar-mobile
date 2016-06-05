using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace TiplessCashJar
{
	public class App : Application
	{
		private static readonly IBeaconManager _beaconManager;
		public static IBeaconManager BeaconManager { get { return _beaconManager; } }
		private static  List<Beacon> _beacons;
		public static List<Beacon> Beacons { get { return _beacons; } }

		static  App() {
			_beaconManager = DependencyService.Get<IBeaconManager> ();

			if (_beaconManager != null) {
			}

			var beaconsTask = Task.Run( async () => {
				_beacons = await GetBeaconsFromServer ().ConfigureAwait(false);
			});
		}

		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new TiplessCashJar.LoginPage()) {BarBackgroundColor = Color.FromHex("#A1B5F7") };
            MainPage.BackgroundColor = Color.FromHex("#BBC7F2");            
        }
			
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
			
		protected async static Task<List<Beacon>> GetBeaconsFromServer() {
			String urlRoot = "https://tipless-cash-jar-dev.azurewebsites.net/api/beacons";

			HttpClient client = new HttpClient ();
			Uri uri = new Uri (urlRoot);

			client.DefaultRequestHeaders
				.Accept
				.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response =  await client.GetAsync (uri);

			if (response.IsSuccessStatusCode) {
				if (response.Content != null) {
					// [{"Major":57497,"Minor":25695,"Name":"badge 1","Uuid":"DD915E3B-072C-4223-9A54-30839098679"},{"Major":17356,"Minor":56347,"Name":"badge 2","Uuid":"DD915E3B-072C-4223-9A54-308390986793"}]

					String json =  await response.Content.ReadAsStringAsync ();
					List<Beacon> beacons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Beacon>>(json);

					if (beacons != null)
						return beacons;
				}
			}

			return null;
		}
	}
}

