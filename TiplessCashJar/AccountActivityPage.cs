using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class AccountActivityPage : ContentPage
	{
		ListView accountListView = new ListView();

		public AccountActivityPage ()
		{
			Content = new StackLayout { 
				Padding = new Thickness(20),
				Children = {
					accountListView
				}
			};
		}
	}
}


