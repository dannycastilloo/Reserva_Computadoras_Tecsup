using Reserva_Computadoras_Tecsup.Services;
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
    public partial class Home : ContentPage
    {
        private ReservationService reservationService;
        public Home()
        {
            InitializeComponent();
            reservationService = new ReservationService();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Obtener las reservas desde el servicio
            var reservations = await reservationService.GetReservations();

            // Asignar las reservas al ListView
            listView.ItemsSource = reservations;
        }
        private async void Reservar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SelectPc());
        }
    }
}