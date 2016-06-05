using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class TransactionPage : ContentPage
	{
		Label name = new Label {
			Text = "name",
			TextColor = Color.White
		};

		Label amount = new Label {
			Text = "amount",
			TextColor = Color.White
        };

		Label date = new Label {
			Text = "date",
			TextColor = Color.White
        };

		public TransactionPage (DonationTransaction transaction)
		{
            this.BackgroundColor = Color.FromHex("#C3CFF7");

            name.Text = transaction.Id;
			date.Text = transaction.TxDate;
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


