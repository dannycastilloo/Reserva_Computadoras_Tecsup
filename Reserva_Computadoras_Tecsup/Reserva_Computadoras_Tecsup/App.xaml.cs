using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Reserva_Computadoras_Tecsup.Views;

namespace Reserva_Computadoras_Tecsup
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Login
            MainPage = new Views.Login();

            //App sin login
            //MainPage = new NavigationPage(new Home());

            //App sin login
            //MainPage = new ComputerForm();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
