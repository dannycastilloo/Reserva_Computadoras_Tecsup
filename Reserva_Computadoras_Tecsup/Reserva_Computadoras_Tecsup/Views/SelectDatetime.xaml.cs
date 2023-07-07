using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
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

        private async void Confirmar(object sender, EventArgs e)
        {

            DateTime horaInicio = DateTime.Today.Add(horaInicioPicker.Time);
            DateTime horaFin = DateTime.Today.Add(horaFinPicker.Time);

            CultureInfo cultura = new CultureInfo("es-ES");
            string informacionHoras = $"{horaInicio.ToString("dd 'de' MMMM   hh:mm tt", cultura)} - {horaFin.ToString("HH:mm tt", cultura)}";

            await Navigation.PushModalAsync(new ConfirmRequest(informacionHoras));
        }
    }
}