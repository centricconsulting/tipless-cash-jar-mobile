using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using BluetoothLE.Core;
using BluetoothLE.Droid;

namespace TiplessCashJar.Droid
{
	[Activity (Label = "TiplessCashJar.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			DependencyService.Register<BluetoothLE.Core.IAdapter, BluetoothLE.Droid.Adapter> ();

			LoadApplication (new App ());
		}
	}
}

