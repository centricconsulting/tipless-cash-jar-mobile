using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


