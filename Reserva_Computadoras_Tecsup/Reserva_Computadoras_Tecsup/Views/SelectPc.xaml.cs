using Firebase.Database;
using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private FirebaseClient firebaseClient;
        private IList<Computer> computers;

        private Computer selectedComputer;
        private ReservasViewModel viewModel;
        public Computer SelectedComputer
        {
            get { return selectedComputer; }
            set
            {
                if (selectedComputer != value)
                {
                    selectedComputer = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public SelectPc()
        {
            InitializeComponent();

            // Configura el cliente de Firebase Realtime Database
            firebaseClient = new FirebaseClient("https://reservacomputadorastecsup-default-rtdb.firebaseio.com/");

            // Carga los datos de las computadoras desde Firebase
            LoadComputers();
        }

        private async void LoadComputers()
        {
            try
            {
                // Obtiene los datos de las computadoras desde Firebase
                computers = await GetComputersFromFirebase();

                // Asigna la lista de computadoras al origen de datos del ListView
                listView.ItemsSource = computers;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ha ocurrido un error al cargar los datos de las computadoras: {ex.Message}", "OK");
            }
        }
        private async Task<IList<Computer>> GetComputersFromFirebase()
        {
            // Obtiene la lista de computadoras desde Firebase
            var snapshot = await firebaseClient.Child("computadoras").OnceAsync<Computer>();

            var computers = new List<Computer>();

            foreach (var item in snapshot)
            {
                var computer = item.Object;
                int id;
                if (int.TryParse(item.Key, out id))
                {
                    computer.Id = id;
                }
                computers.Add(computer);
            }

            return computers;
        }

        private async void SelectPC(object sender, EventArgs e)
        {
            if (SelectedComputer == null)
            {
                await DisplayAlert("Error", "Debes seleccionar una computadora.", "OK");
                return;
            }

            await Navigation.PushModalAsync(new SelectDatetime(SelectedComputer));
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Computer selectedItem = e.SelectedItem as Computer;
            if (selectedItem != null)
                SelectedComputer = selectedItem;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Computer tappedItem = e.Item as Computer;
            if (tappedItem != null)
                SelectedComputer = tappedItem;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}