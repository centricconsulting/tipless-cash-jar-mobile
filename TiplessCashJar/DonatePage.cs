using System;

using Xamarin.Forms;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
				
		private string beaconName;

		public DonatePage (string beaconName)
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

			this.beaconName = beaconName;

			oneDollarButton.Clicked += async (object sender, EventArgs e) => {
				await ConfirmDontation(1);
			};

			twoDollarButton.Clicked += async (object sender, EventArgs e) => {
				await ConfirmDontation(2);
			};

			fourDollarButton.Clicked += async (object sender, EventArgs e) => {
				await ConfirmDontation(4);
			};

			customDollarButton.Clicked += async (object sender, EventArgs e) => {
				int custom = 0;
				Int32.TryParse(customDollarEntry.Text, out custom);

				if (custom > 0)
					await ConfirmDontation(custom);
				else
					DisplayAlert("OpenAlms", "Please enter an amount", "OK");
			};

			noThanksButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PopAsync();
			};
		}

		protected async Task ConfirmDontation(int amount) {
			Int32 myAmount = amount;
			var answer = await DisplayAlert ("OpenAlms", "Are you sure you would like to donate $" + myAmount.ToString() + " to " + beaconName + "?", "Yes", "No");
			if (answer) {
				await callDonateWebservice (beaconName, amount);
			}
		}

		protected async Task callDonateWebservice(String beaconNumber, int amount) {
			String urlRoot = "https://tipless-cash-jar-dev.azurewebsites.net/api/donate";
			Int32 myAmount = amount;
			String json = "{\"BeaconNumber\": \"" + beaconNumber + "\",  \"Amount\":" + myAmount.ToString() + "}";

			HttpClient client = new HttpClient ();
			Uri uri = new Uri (urlRoot);
			StringContent queryString = new StringContent(json, Encoding.UTF8, "application/json");

			client.DefaultRequestHeaders
				.Accept
				.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.PostAsync (uri, queryString);

			if (response.IsSuccessStatusCode) {
				String confirmation = await response.Content.ReadAsStringAsync ();
				await Navigation.PushAsync(new ConfirmDonationPage(amount));
			}
		}
	}
}


