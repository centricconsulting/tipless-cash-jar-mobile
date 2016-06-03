using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class MainPage : ContentPage
	{
		Button loginButton = new Button {
			Text = "Login"
		};

		Entry username = new Entry {
			Placeholder = "Username"
		};

		Entry password = new Entry  {
			IsPassword = true,
			Placeholder = "Password"
		};

		public MainPage ()
		{

			loginButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync (new LoginPage ());
			};

			Content = new StackLayout { 
				Children = {
					username,
					password,
					loginButton,
				}
			};
		}
	}
}


