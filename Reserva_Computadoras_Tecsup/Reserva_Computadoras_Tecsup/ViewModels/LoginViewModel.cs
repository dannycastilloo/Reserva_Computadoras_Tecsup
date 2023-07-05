using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.Views;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool _loginSuccessful;
        private Usuario _usuario;

        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }
        // bool que cambia si el usuario fue validado o no
        public bool LoginSuccessful
        {
            get { return _loginSuccessful; }
            set
            {
                _loginSuccessful = value;
                OnPropertyChanged(nameof(LoginSuccessful));
            }
        }

        public ICommand IniciarSesionCommand { get; }

        public LoginViewModel()
        {
            Usuario = new Usuario();
            IniciarSesionCommand = new Command(async () => await IniciarSesionAsync());
        }

        private async Task IniciarSesionAsync()
        {
            if (Usuario.Correo.EndsWith("@tecsup.edu.pe"))
            {
                var config = new FirebaseAuthConfig
                {
                    ApiKey = "AIzaSyD5JuYhNdWuB5G5Xy_D3Uo3oyzTqjXk974",
                    AuthDomain = "reservacomputadorastecsup.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                    {
                        new EmailProvider()
                    }
                };

                var client = new FirebaseAuthClient(config);

                try
                {
                    var userCredential = await client.SignInWithEmailAndPasswordAsync(Usuario.Correo, Usuario.Password);
                    // Autenticación de usuario exitosa, realizar acciones necesarias

                    // Mostrar mensaje de inicio de sesión exitoso
                    await App.Current.MainPage.DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");

                    // Continuar con las operaciones necesarias después de la autenticación exitosa

                    //var homePage = new Home();
                    //await App.Current.MainPage.Navigation.PushAsync(homePage);
                    LoginSuccessful = true;

                }
                catch (FirebaseAuthException ex)
                {
                    if (ex.Reason == AuthErrorReason.UnknownEmailAddress)
                    {
                        // El correo no existe
                        await App.Current.MainPage.DisplayAlert("Error", "El correo no existe", "OK");
                    }
                    else if (ex.Reason == AuthErrorReason.WrongPassword)
                    {
                        // Contraseña incorrecta
                        await App.Current.MainPage.DisplayAlert("Error", "Contraseña incorrecta", "OK");
                    }
                    else
                    {
                        // Otro error de autenticación
                        await App.Current.MainPage.DisplayAlert("Error", "No se pudo iniciar sesión: " + ex.Message, "OK");
                    }
                }
                catch (Exception ex)
                {
                    // Otro error
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudo iniciar sesión: " + ex.Message, "OK");
                }
            }
            else
            {
                // El correo no es válido
                await App.Current.MainPage.DisplayAlert("Error", "Se requiere un correo de Tecsup para continuar.", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
