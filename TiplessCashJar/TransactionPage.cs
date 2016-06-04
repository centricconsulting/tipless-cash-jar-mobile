using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class TransactionPage : ContentPage
	{
		Label name = new Label {
			Text = "name",
			TextColor = Color.FromHex("#d4d2d2")
		};

		Label amount = new Label {
			Text = "amount",
			TextColor = Color.FromHex("#d4d2d2")
		};

		Label date = new Label {
			Text = "date",
			TextColor = Color.FromHex("#d4d2d2")
		};

		public TransactionPage (DonationTransaction transaction)
		{
			name.Text = transaction.Name;
			date.Text = transaction.Date;
			Int32 myAmount = transaction.Amount;
			amount.Text = myAmount.ToString();

			Content = new StackLayout { 
				Children = {
					name,
					amount,
					date
				}
			};
		}
	}
}


