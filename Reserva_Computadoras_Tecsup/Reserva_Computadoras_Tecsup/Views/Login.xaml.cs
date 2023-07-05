using Reserva_Computadoras_Tecsup;
using Reserva_Computadoras_Tecsup.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reserva_Computadoras_Tecsup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private LoginViewModel viewModel;
        public Login()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.LoginSuccessful) && viewModel.LoginSuccessful)
            {
                // Cambiar la página principal a un TabbedPage
                App.Current.MainPage = new MainPage();
            }
        }
    }
}