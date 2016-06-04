using System;
using System.Net.Http;
using Xamarin.Forms;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace TiplessCashJar
{
    public class ConfirmDonationPage : ContentPage
    {
        Image backgroundImage = new Image
        {
            Aspect = Aspect.AspectFit,
            Source = FileImageSource.FromResource("TiplessCashJar.check.png")
        };
        	
		public ConfirmDonationPage (int amount)
		{
			this.Title = String.Format("Thank you for your donation of ${0}", amount);

			Content = new StackLayout { 
				Children = {
					backgroundImage
				}
			};
		}
	}
}


