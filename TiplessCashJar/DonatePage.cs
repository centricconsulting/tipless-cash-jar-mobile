using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class DonatePage : ContentPage
	{
		Button oneDollarButton = new Button {
			Text = "$1"
		};

		Button twoDollarButton = new Button {
			Text = "$2"
		};

		Button fourDollarButton = new Button {
			Text = "$4"
		};

		Label customLabel = new Label {
			Text = "Custom"
		};

		Entry customDollarEntry = new Entry {
			Placeholder = "Custom"
		};

		Button customDollarButton = new Button {
			Text = "Custom"
		};

		Button noThanksButton = new Button {
			Text = "No Thanks!"
		};
				
		public DonatePage ()
		{
			Content = new StackLayout { 
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
				await Navigation.PushAsync(new ConfirmDonationPage( custom));
			};

			noThanksButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new DashboardPage());
			};
		}
	}
}


