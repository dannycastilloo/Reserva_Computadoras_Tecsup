using Reserva_Computadoras_Tecsup.Models;
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
        private Computer selectedComputer;
        public SelectDatetime (Computer computer)
        {
			InitializeComponent ();
            selectedComputer = computer;
        }

        private async void Confirmar(object sender, EventArgs e)
        {

            DateTime fechaSeleccionada = datepicker.Date;
            DateTime horaInicio = DateTime.Today.Add(horaInicioPicker.Time);
            DateTime horaFin = DateTime.Today.Add(horaFinPicker.Time);

            string fecha = fechaSeleccionada.ToString("dd/MM");
            string horaInicioTexto = horaInicio.ToString("hh:mm tt");
            string horaFinTexto = horaFin.ToString("hh:mm tt");

            string informacionHoras = $"{fecha} {horaInicioTexto} - {horaFinTexto}";

            await Navigation.PushModalAsync(new ConfirmRequest(informacionHoras, selectedComputer));
        }
    }
}