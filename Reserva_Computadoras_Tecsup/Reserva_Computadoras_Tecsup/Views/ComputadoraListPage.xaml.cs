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
    public partial class ComputadoraListPage : ContentPage
    {
        ComputerRepository computerRepository = new ComputerRepository();
        ListView listView; // Agrega esta variable para acceder al ListView

        public ComputadoraListPage()
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
    }
}
