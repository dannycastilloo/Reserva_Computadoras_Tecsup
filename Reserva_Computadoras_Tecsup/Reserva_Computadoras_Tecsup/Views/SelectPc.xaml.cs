using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reserva_Computadoras_Tecsup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPc : ContentPage
    {
        public ObservableCollection<Computer> Computers { get; private set; }
        private readonly ComputerViewModel viewModel;

        public SelectPc()
        {
            InitializeComponent();
            viewModel = new ComputerViewModel();
           

            var computers = viewModel.GetAllComputers();
            Computers = new ObservableCollection<Computer>(computers);
            BindingContext = viewModel;
        }

        private async void SelectPC(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SelectDatetime());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Computer selectedItem = e.SelectedItem as Computer;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Computer tappedItem = e.Item as Computer;
        }
    }
}
