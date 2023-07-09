using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reserva_Computadoras_Tecsup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPc : ContentPage
    {
        private ReservasViewModel viewModel;

        public SelectPc()
        {
            InitializeComponent();
            viewModel = new ReservasViewModel();
            BindingContext = viewModel;

            LoadComputers();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadComputers();

            try
            {
                // Cargar las computadoras en el modelo de vista al mostrar la página
                await viewModel.LoadComputers();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al cargar los datos: {ex.Message}", "Aceptar");
            }
        }
        private async Task LoadComputers()
        {
            // Llamar al método LoadComputers() del ReservasViewModel
            await viewModel.LoadComputers();
        }

        private async void SelectPC(object sender, EventArgs e)
        {
            var selectedComputer = viewModel.SelectedComputer;
            await Navigation.PushModalAsync(new SelectDatetime(selectedComputer));
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Computer selectedItem = e.SelectedItem as Computer;
            if (selectedItem != null)
                viewModel.SelectedComputer = selectedItem;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Computer tappedItem = e.Item as Computer;
            if (tappedItem != null)
                viewModel.SelectedComputer = tappedItem;
        }
    }
}
