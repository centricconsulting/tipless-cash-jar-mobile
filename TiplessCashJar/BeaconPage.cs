using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class BeaconPage : ContentPage
	{
		public BeaconPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


