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

		Label distance = new Label {
			Text = "distance"
		};

		public BeaconPage (Beacon beacon)
		{

			this.beacon = beacon;

			name.Text = beacon.Name;
			id.Text = beacon.UUID;
			Double myDistance = beacon.Distance;
			distance.Text = myDistance.ToString();

			Content = new StackLayout {
				Children = {
					name,
					id, 
					distance
				}
			};

			BindingContext = beacon;
		}
	}
}


