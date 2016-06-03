using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class DashboardPage : ContentPage
	{
		Button donateButton = new Button {
			Text = "Donate"
		};

		Button profileButton = new Button {
			Text = "Profile"
		};

		public DashboardPage ()
		{

			Content = new StackLayout { 
				Children = {
					donateButton,
					profileButton
				}
			};

			donateButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new DonatePage());
			};

			profileButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new ProfilePage());
			};

		}
	}
}


