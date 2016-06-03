using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class LoginPage : ContentPage
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

		public LoginPage ()
		{
			this.Title = "Tipless Cash Jar";

			Content = new StackLayout { 
				Children = {
					username,
					password,
					loginButton
				}
			};

			loginButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new DashboardPage());
			};

		}
	}
}


