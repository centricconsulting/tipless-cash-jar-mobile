using System;

using Xamarin.Forms;
using BluetoothLE.Core;


namespace TiplessCashJar
{
	public class App : Application
	{
		private static readonly IAdapter _bluetoothAdapter;
		public static IAdapter BluetoothAdapter { get { return _bluetoothAdapter; } }

		static  App() {
			_bluetoothAdapter = DependencyService.Get<IAdapter>();

			if (_bluetoothAdapter != null) {
				_bluetoothAdapter.ScanTimeout = TimeSpan.FromSeconds (10);
				_bluetoothAdapter.ConnectionTimeout = TimeSpan.FromSeconds (10);
			}
		}

		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage( new TiplessCashJar.LoginPage());
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

