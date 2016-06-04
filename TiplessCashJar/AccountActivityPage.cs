using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TiplessCashJar
{
	public class AccountActivityPage : ContentPage
	{
		ListView accountListView = new ListView();
		public ObservableCollection<DonationTransaction> Transactions { get; private set; }
		List<DonationTransaction> _transactions = new List<DonationTransaction> ();

		public AccountActivityPage ()
		{
			Content = new StackLayout { 
				Padding = new Thickness(20),
				Children = {
					accountListView
				}
			};

			Transactions = new ObservableCollection<DonationTransaction>();

			var transactionsTask = Task.Run( () => {
				_transactions = GetTransactionsFromServer ().Result;
			});

			accountListView.ItemsSource = Transactions;
			accountListView.ItemSelected += TransactionSelected;
		}

		void TransactionSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var transaction = e.SelectedItem as DonationTransaction;
			if (transaction != null) {
				Navigation.PushAsync (new TransactionPage (transaction));
			}
		}

		protected async Task<List<DonationTransaction>> GetTransactionsFromServer() {
			String urlRoot = "https://tipless-cash-jar-dev.azurewebsites.net/api/donateAll";

			HttpClient client = new HttpClient ();
			Uri uri = new Uri (urlRoot);

			client.DefaultRequestHeaders
				.Accept
				.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response =  await client.GetAsync (uri);

			if (response.IsSuccessStatusCode) {
				if (response.Content != null) {
					// [{"Major":57497,"Minor":25695,"Name":"badge 1","Uuid":"DD915E3B-072C-4223-9A54-30839098679"},{"Major":17356,"Minor":56347,"Name":"badge 2","Uuid":"DD915E3B-072C-4223-9A54-308390986793"}]

					String json =  await response.Content.ReadAsStringAsync ();
					List<DonationTransaction> transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DonationTransaction>>(json);

					if (transactions != null)
						return _transactions;
				}
			}

			return null;
		}

	}
}


