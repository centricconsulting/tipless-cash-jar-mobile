using System;
using TiplessCashJar.Models;
using Xamarin.Forms;

namespace TiplessCashJar
{
	public class ProfilePage : ContentPage
	{
        #region Controls
        Entry firstName = new Entry
        {
            Placeholder = "First"
        };

        Entry lastName = new Entry
        {
            Placeholder = "Last"
        };

        Entry email = new Entry
        {
            Placeholder = "email@email.com"
        };

        Entry address1 = new Entry
        {
            Placeholder = "address 1"
        };

        Entry address2 = new Entry
        {
            Placeholder = "address 2"
        };

        Entry city = new Entry
        {
            Placeholder = "City"
        };

        Entry state = new Entry
        {
            Placeholder = "State"
        };

        Entry zip = new Entry
        {
            Placeholder = "Zip" 
        };

        Button saveProfileButton = new Button
        {
            Text = "Save Button"
        };

        Button addBankButton = new Button
        {
            Text = "Add Bank"
        };

        Button addCreditButton = new Button
        {
            Text = "Add Credit"
        };
        #endregion


        public ProfilePage ()
		{
            this.Title = "Profile";

            StackLayout stack = new StackLayout();
            stack.Children.Add(firstName);
            stack.Children.Add(lastName);
            stack.Children.Add(email);
            stack.Children.Add(address1);
            stack.Children.Add(address2);
            stack.Children.Add(city);
            stack.Children.Add(state);
            stack.Children.Add(zip);
            stack.Children.Add(saveProfileButton);
            stack.Children.Add(addBankButton);
            stack.Children.Add(addCreditButton);
            stack.Padding = 20;

            var scrollView = new ScrollView
            {
                Content = stack
            };

            Content = scrollView;
            
            saveProfileButton.Clicked += async (object sender, EventArgs e) => {
                var userProfile = new UserProfile {
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Email = email.Text,
                    Address1 = address1.Text,
                    Address2 = address1.Text,
                    City = city.Text,
                    State = state.Text,
                    Zip = Convert.ToInt32(zip.Text)
                };
                await Navigation.PushAsync(new ProfilePage());
            };

            addBankButton.Clicked += async (object sender, EventArgs e) =>
            {
                await Navigation.PushAsync(new BankAcountInformationPage());
            };

            addCreditButton.Clicked += async (object sender, EventArgs e) =>
            {
                await Navigation.PushAsync(new CreditCardInformationPage());
            };
        }
	}
}


