using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TiplessCashJar.Models;
using Xamarin.Forms;

namespace TiplessCashJar
{
    public class CreditCardInformationPage : ContentPage
    {
        #region Controls
        Entry nameAsAppearsOnCard = new Entry
        {
            Placeholder = "Name As It Appear On Your Card"
        };
        Entry cardNumber = new Entry
        {
            Placeholder = "Card Number"
        };
        Entry expDate = new Entry
        {
            Placeholder = "Exp MM/YY"
        };
        Entry csvNumber = new Entry
        {
            Placeholder = "CSV"
        };

        Button saveProfileButton = new Button
        {
            Text = "Save Profile"
        };

        Button deleteCardButton = new Button
        {
            Text = "Delete Card"
        };
        #endregion

        public CreditCardInformationPage()
        {
            this.Title = "Add Credit Card";

            Content = new StackLayout
            {
                Children = {
                    nameAsAppearsOnCard,
                    cardNumber,
                    expDate,
                    csvNumber,
                    saveProfileButton,
                    deleteCardButton
                }
            };

            saveProfileButton.Clicked += async (object sender, EventArgs e) => {
                var creditCard = new CreditCard
                {
                    NameAsAppearsOnCard = nameAsAppearsOnCard.Text,
                    CardNumber = Convert.ToInt32(cardNumber.Text),
                    ExpDate = expDate.Text,
                    CSVNumber = Convert.ToInt32(csvNumber)
                };
                //To-Do add post to database
                //Diplay notification
                await Navigation.PushAsync(new CreditCardInformationPage());
            };

            deleteCardButton.Clicked += async (object sender, EventArgs e) =>
            {
                //To-Do add post to database
                //Diplay notification
                await Navigation.PushAsync(new CreditCardInformationPage());
            };
        }

    }
}
