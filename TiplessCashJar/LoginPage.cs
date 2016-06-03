using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			this.Title = "Login";

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


