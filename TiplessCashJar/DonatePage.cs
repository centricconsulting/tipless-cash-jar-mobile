using System;

using Xamarin.Forms;

namespace TiplessCashJar
{
	public class DonatePage : ContentPage
	{
		public DonatePage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


