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

        ComputerRepository computerRepository = new ComputerRepository();
        ListView listView;

        public SelectPc()
        {
            InitializeComponent();
            listView = ComputadoraListView; // Asigna el ListView al nuevo identificador "listView"

            listView.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }

        protected override async void OnAppearing()
        {
            var computers = await computerRepository.GetAll();
            listView.ItemsSource = null;
            listView.ItemsSource = computers;
            listView.IsRefreshing = false;
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
