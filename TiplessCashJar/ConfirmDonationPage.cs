using System;
using System.Net.Http;
using Xamarin.Forms;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace TiplessCashJar
{
	public class ConfirmDonationPage : ContentPage
	{
		Button confirmButton = new Button {
			Text = "Confirm"
		};

		private int amount = 0;

		public ConfirmDonationPage (int amount)
		{
			this.Title = String.Format("Confirm ${0}", amount);
			this.amount = amount;

			Content = new StackLayout { 
				Children = {
					confirmButton
				}
			};

			confirmButton.Clicked += async (object sender, EventArgs e) => {
				// call web service with dollar amount
				callDonateWebservice("beacon", amount);
				};

		}

		async void callDonateWebservice(String beaconNumber, int amount) {
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
				DisplayAlert("Tipless Cash Jar", "Thank you for donating $" + myAmount.ToString(), "OK");
				//-TODO Navigate back to dashboard
			}
		}
			
	}
}


