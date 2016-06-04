using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class MainPage : ContentPage
	{
		Button loginButton = new Button {
			Text = "Login"
		};
				
		public MainPage ()
		{
			this.Title = "OpenAlms";

			loginButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync (new LoginPage ());
			};

			Content = new StackLayout { 
				Children = {
					loginButton,
				}
			};
		}
	}
}


