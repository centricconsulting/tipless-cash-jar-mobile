using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TiplessCashJar
{
	public class BeaconPage : ContentPage
	{
		private readonly Beacon beacon;

		Label name = new Label {
			Text = "name"
		};

		Label id = new Label {
			Text = "id"
		};

		public BeaconPage (Beacon beacon)
		{

			this.beacon = beacon;

			name.Text = beacon.Name;
			id.Text = beacon.UUID;

			Content = new StackLayout {
				Children = {
					name,
					id
				}
			};

			BindingContext = beacon;
		}
	}
}


