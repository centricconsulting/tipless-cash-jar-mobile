using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TiplessCashJar.Models;
using Xamarin.Forms;

namespace TiplessCashJar
{
    public class BankAcountInformationPage : ContentPage
    {

        #region Controls
        Entry bankName = new Entry
        {
            Placeholder = "Name Of Bank"
        };

        Entry routingNumber = new Entry
        {
            Placeholder = "Routing Number"
        };

        Entry accountNumber = new Entry
        {
            Placeholder = "Account Number"
        };

        Button saveBankAccountButton = new Button
        {
            Text = "Save Profile",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

        Button deleteBankAccountButton = new Button
        {
            Text = "Delete Account",
            BackgroundColor = Color.FromHex("#A1B5F7")
        };

        #endregion

        public BankAcountInformationPage()
        {
            this.Title = "Add Bank Account";
            this.BackgroundColor = Color.FromHex("#C3CFF7");

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children = {
                    bankName,
                    routingNumber,
                    accountNumber,
                    saveBankAccountButton,
                    deleteBankAccountButton
                }
            };

            saveBankAccountButton.Clicked += async (object sender, EventArgs e) => {
                var bankAccount = new BankAccount
                {
                    BankName = bankName.Text,
                    RoutingNumber = Convert.ToInt32(routingNumber.Text),
                    AccountNumber = Convert.ToInt32(accountNumber.Text)
                };
                //To-Do post changes to database
                //Display notification alert
                await Navigation.PushAsync(new BankAcountInformationPage());
            };

            deleteBankAccountButton.Clicked += async (object sender, EventArgs e) =>
            {
                //To-Do delete information from database
                //Display notification alert
                await Navigation.PushAsync(new BankAcountInformationPage());
            };
        }
    }
}
