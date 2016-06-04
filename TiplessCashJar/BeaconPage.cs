using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TiplessCashJar
{
	public class BeaconPage : ContentPage
	{
		private readonly Beacon beacon;

		Label name = new Label {
			Text = "name",
			TextColor = Color.White
        };

		Label id = new Label {
			Text = "id",
			TextColor = Color.White
        };

		Label distance = new Label {
			Text = "distance",
            TextColor = Color.White
        };

		public BeaconPage (Beacon beacon)
		{
            this.beacon = beacon;
            this.BackgroundColor = Color.FromHex("#C3CFF7");

            name.Text = beacon.Name;
			id.Text = beacon.UUID;
			Double myDistance = beacon.Distance;
			distance.Text = myDistance.ToString();

			Content = new StackLayout {
                Padding = new Thickness(20),
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


