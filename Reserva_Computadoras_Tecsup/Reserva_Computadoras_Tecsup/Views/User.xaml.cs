using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reserva_Computadoras_Tecsup.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class User : ContentPage
	{
		public User ()
		{
			InitializeComponent ();
		}
        private async void ViewMails(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Mails());
        }
        private async void ViewRules(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Rules());
        }
    }
}