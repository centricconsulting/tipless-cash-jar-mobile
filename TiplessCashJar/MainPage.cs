using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class MainPage : ContentPage
	{
		Button loginButton = new Button {
			Text = "Login",
            BackgroundColor = Color.FromHex("#9eade0")

        };
				
		public MainPage ()
		{
			this.Title = "Tipless Cash Jar";
            this.BackgroundColor = Color.FromHex("#d0d9f7");

            loginButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync (new LoginPage ());
			};

			Content = new StackLayout {
                Padding = new Thickness(20),
                Children = {
					loginButton,
				}
			};
		}
	}
}


