using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class LoginPage : ContentPage
	{
		Entry username = new Entry {            
			Placeholder = "Username",
            TextColor = Color.FromHex("#A1B5F7")
        };

		Entry password = new Entry  {
			IsPassword = true,
			Placeholder = "Password",
            TextColor = Color.FromHex("#A1B5F7")
        };

        Button loginButton = new Button
        {
            Text = "Login",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

        Button createProfileButton = new Button {
            Text = "Create Profile",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

		public LoginPage ()
		{           
			this.Title = "Tipless Cash Jar";
            this.BackgroundColor = Color.FromHex("#C3CFF7");

            Content = new StackLayout {
                Padding = new Thickness(40),
				Children = {                    
					username,
					password,
					loginButton,
                    createProfileButton
				}
			};

			loginButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new DashboardPage());
			};

            createProfileButton.Clicked += async (object sender, EventArgs e) =>
            {
                await Navigation.PushAsync(new ProfilePage());
            };

		}
	}
}


