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
			this.Title = "Account Activity";

            this.BackgroundColor = Color.FromHex("#C3CFF7");
            Content = new StackLayout { 
				Padding = new Thickness(20),
				Children = {
					accountListView
				}
			};

			Transactions = new ObservableCollection<DonationTransaction>();

			var transactionsTask = Task.Run(async () => {
				_transactions = await GetTransactionsFromServer ().ConfigureAwait(false);

				Transactions.Clear ();
				foreach (var transaction in _transactions) {
					Transactions.Add (transaction);
				}

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
			String urlRoot = "https://tipless-cash-jar-dev.azurewebsites.net/api/donations";

			HttpClient client = new HttpClient ();
			Uri uri = new Uri (urlRoot);

			client.DefaultRequestHeaders
				.Accept
				.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response =  await client.GetAsync (uri);

			if (response.IsSuccessStatusCode) {
				if (response.Content != null) {
					/*
					 *
					 *[{"Amount":2,"TxDate":"2016-06-04T17:18:17.72","Id":"80749f33-27d5-4048-a6af-1263c211eaa6"},{"Amount":2,"TxDate":"2016-06-04T17:33:56.44","Id":"b5785287-faf1-4dcb-aa4e-21b0ba65aaef"},{"Amount":2,"TxDate":"2016-06-04T02:22:32.747","Id":"5283f2a5-7a71-4697-b29a-2b02ea61d48e"},{"Amount":2,"TxDate":"2016-06-04T17:21:32.407","Id":"6bd60039-aece-4dd0-9300-2f4dc8b19dfd"},{"Amount":2,"TxDate":"2016-06-04T21:06:20.253","Id":"6158e905-2e1e-4a89-859e-4d2c513c5b61"},{"Amount":1000000,"TxDate":"2016-06-04T17:32:22.737","Id":"f1b9c9e5-1f08-4e1b-9598-624133388ac1"},{"Amount":2,"TxDate":"2016-06-04T17:18:20.947","Id":"586cf309-88c8-40c7-8f6e-8ce1dc878c19"},{"Amount":4,"TxDate":"2016-06-04T21:37:05.283","Id":"ca13607e-8143-4888-8a35-8d30ad4c1e49"},{"Amount":1,"TxDate":"2016-06-04T15:13:15.6","Id":"564ab08f-81cf-4ebb-a9ad-8e02d88a6ab3"},{"Amount":2,"TxDate":"2016-06-04T17:19:15.173","Id":"ea9a3cfa-3ccc-4fdf-8f4c-99acdca1e24a"},{"Amount":2,"TxDate":"2016-06-04T21:00:32.393","Id":"a4ea1150-1b27-4b96-aa67-c12033090578"},{"Amount":1,"TxDate":"2016-06-04T15:13:15.6","Id":"ab80200c-2d84-4111-a08a-dddae5f124d6"},{"Amount":2,"TxDate":"2016-06-04T21:18:42.02","Id":"37940773-2a67-475a-b14a-e749f35db175"}]
					*/
					String json =  await response.Content.ReadAsStringAsync ();
					List<DonationTransaction> transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DonationTransaction>>(json);

					if (transactions != null)
						return transactions;
				}
			}

			return null;
		}

	}
}


