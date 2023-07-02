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
	public partial class SelectDatetime : ContentPage
	{
		public SelectDatetime ()
		{
			InitializeComponent ();
		}
		public void ShowDate(object obj, EventArgs args)
		{
			DisplayAlert("DATE", datepicker.Date.ToString(),"OK");
		}
        private async void Confirmar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ConfirmRequest());
        }
    }
}