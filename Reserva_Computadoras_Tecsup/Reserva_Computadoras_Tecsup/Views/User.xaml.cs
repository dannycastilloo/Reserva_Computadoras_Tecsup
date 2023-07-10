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
        private void LogOut_Clicked(object sender, EventArgs e)
        {
            // Realizar el cierre de sesión y volver a la página de inicio de sesión (Login)
            Application.Current.MainPage = new Login();
        }
    }
}