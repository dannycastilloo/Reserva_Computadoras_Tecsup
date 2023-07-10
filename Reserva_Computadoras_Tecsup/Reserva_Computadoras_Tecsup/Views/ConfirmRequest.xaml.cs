using Reserva_Computadoras_Tecsup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Reserva_Computadoras_Tecsup.ViewModels;

namespace Reserva_Computadoras_Tecsup.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmRequest : ContentPage
	{
        private Reservation reservation;
        public Usuario CurrentUser { get; set; }
        public Computer selectedComputer { get; set; }
        public ConfirmRequest(Computer selectedComputer, Reservation reservation)
        {
            InitializeComponent();
            this.selectedComputer = selectedComputer;
            this.reservation = reservation;
            CurrentUser = new Usuario { Nombres = "Danny Castillo" };
            BindingContext = new ConfirmRequestViewModel(selectedComputer, reservation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Actualiza la etiqueta de horas con los datos de la reserva
            horasLabel.Text = $"Fecha de reserva: {reservation.FechaHoraInicio.ToString("dd/MM")} \n" +
                              $"Hora de inicio: {reservation.FechaHoraInicio.ToString("HH:mm tt")} \n" +
                              $"Hora de fin: {reservation.FechaHoraFin.ToString("HH:mm tt")}";
        }

        private void VolverInicio(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Home();
        }
    }
}