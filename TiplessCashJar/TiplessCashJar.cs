using System;

using Xamarin.Forms;


namespace TiplessCashJar
{
	public class App : Application
	{
		private static readonly IBeaconManager _beaconManager;
		public static IBeaconManager BeaconManager { get { return _beaconManager; } }

		static  App() {
			_beaconManager = DependencyService.Get<IBeaconManager> ();

			if (_beaconManager != null) {
			}
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
	}
}

