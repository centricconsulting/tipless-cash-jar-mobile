using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class DonatePage : ContentPage
	{
		Button oneDollarButton = new Button {
			Text = "$1",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

		Button twoDollarButton = new Button {
			Text = "$2",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

		Button fourDollarButton = new Button {
			Text = "$4",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

		Label customLabel = new Label {
			Text = "Custom",
            TextColor = Color.FromHex("#d4d2d2")
        };

		Entry customDollarEntry = new Entry {
			Placeholder = "Custom"
        };

		Button customDollarButton = new Button {
			Text = "Custom",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

		Button noThanksButton = new Button {
			Text = "No Thanks!",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };
				
		public DonatePage ()
		{
            this.BackgroundColor = Color.FromHex("#C3CFF7");

            Content = new StackLayout {
                Padding = new Thickness(20),
                Children = {
					oneDollarButton,
					twoDollarButton,
					fourDollarButton,
					customLabel,
					customDollarEntry,
					customDollarButton,
					noThanksButton
				}
			};

			oneDollarButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new ConfirmDonationPage(1));
			};

			twoDollarButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new ConfirmDonationPage(2));
			};

			fourDollarButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new ConfirmDonationPage(4));
			};

			customDollarButton.Clicked += async (object sender, EventArgs e) => {
				int custom = 0;
				Int32.TryParse(customDollarEntry.Text, out custom);

				if (custom > 0)
					await Navigation.PushAsync(new ConfirmDonationPage( custom));
				else
					DisplayAlert("Tipless Cash Jar", "Please enter an amount", "OK");
			};

			noThanksButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new DashboardPage());
			};
		}
	}
}


