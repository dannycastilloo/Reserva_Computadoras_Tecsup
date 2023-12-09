using Firebase.Database;
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
        private FirebaseClient firebaseClient;
        private Computer selectedComputer;
        public SelectDatetime(Computer selectedComputer)
        {
            InitializeComponent();
            this.selectedComputer = selectedComputer;

            // Configura el cliente de Firebase Realtime Database
            firebaseClient = new FirebaseClient("https://reservacomputadorastecsup-default-rtdb.firebaseio.com/");
        }
        private async void Confirmar(object sender, EventArgs e)
        {
            // Valida los campos de fecha y hora
            if (datepicker.Date == default || horaInicioPicker.Time == default || horaFinPicker.Time == default)
            {
                await DisplayAlert("Error", "Debes seleccionar una fecha y hora válida.", "OK");
                return;
            }

            // Crea un objeto Reservation con los datos de reserva
            var reservation = new Reservation
            {
                UserId = 1, // Id del usuario actual, debes ajustarlo según tu lógica de autenticación
                ComputerId = selectedComputer.Id,
                FechaHoraInicio = new DateTime(datepicker.Date.Year, datepicker.Date.Month, datepicker.Date.Day,
                    horaInicioPicker.Time.Hours, horaInicioPicker.Time.Minutes, horaInicioPicker.Time.Seconds),
                FechaHoraFin = new DateTime(datepicker.Date.Year, datepicker.Date.Month, datepicker.Date.Day,
                    horaFinPicker.Time.Hours, horaFinPicker.Time.Minutes, horaFinPicker.Time.Seconds)
            };

            try
            {
                // Agrega la reserva a Firebase Realtime Database
                await firebaseClient.Child("PastReserves").PostAsync(reservation);

                await DisplayAlert("Éxito", "La reserva se ha creado correctamente.", "OK");

                // Navega a la vista Home o a donde desees después de crear la reserva
                await Navigation.PushModalAsync(new ConfirmRequest(selectedComputer, reservation));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ha ocurrido un error al crear la reserva: {ex.Message}", "OK");
            }
        }
    }
}