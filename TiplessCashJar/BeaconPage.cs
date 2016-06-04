using System;

using Xamarin.Forms;
using BluetoothLE.Core;
using System.Collections.ObjectModel;
using BluetoothLE.Core.Events;

namespace TiplessCashJar
{
	public class BeaconPage : ContentPage
	{
		private readonly IDevice _device;

		Label name = new Label {
			Text = "name"
		};

		Label id = new Label {
			Text = "id"
		};

		public BeaconPage (IDevice device)
		{

			_device = device;

			name.Text = device.Name;
			id.Text = device.Id.ToString();

			Content = new StackLayout {
				Children = {
					name,
					id
				}
			};

			BindingContext = _device;

			App.BluetoothAdapter.DeviceDisconnected += DeviceDisconnected;
		}


		void DeviceDisconnected (object sender, DeviceConnectionEventArgs e)
		{
			// todo: stale
		}

		protected override bool OnBackButtonPressed()
		{
			App.BluetoothAdapter.DeviceDisconnected -= DeviceDisconnected;
			App.BluetoothAdapter.DisconnectDevice(_device);

			return base.OnBackButtonPressed();
		}			
	}
}


