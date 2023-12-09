using Firebase.Database;
using Reserva_Computadoras_Tecsup.Models;
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
    public partial class ComputerForm : ContentPage
    {
        private FirebaseClient firebaseClient;
        public ComputerForm()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient("https://reservacomputadorastecsup-default-rtdb.firebaseio.com/");
        }
        private async void RegistrarComputadora(object sender, EventArgs e)
        {
            string codigo = codigoEntry.Text;
            string model = modelEntry.Text;
            string brand = brandEntry.Text;
            string software = softwareEntry.Text;

            bool available = availableSwitch.IsToggled;

            // Crear objeto Computer con los datos ingresados
            Computer nuevaComputadora = new Computer
            {
                Codigo = codigo,
                Model = model,
                Brand = brand,
                Software = software,
               
                Available = available
            };

            try
            {
                // Enviar el objeto a Firebase Realtime Database para crear el registro de la computadora
                var result = await firebaseClient.Child("Computers").PostAsync(nuevaComputadora);

                await DisplayAlert("Éxito", "La computadora ha sido registrada correctamente", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ha ocurrido un error al registrar la computadora: {ex.Message}", "OK");
            }
        }
    }
}