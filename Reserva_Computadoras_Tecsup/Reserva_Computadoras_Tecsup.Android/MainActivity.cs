using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Reserva_Computadoras_Tecsup.Repositories;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Reserva_Computadoras_Tecsup.Droid
{
    [Activity(Label = "Smart Reserve", Icon = "@drawable/iconTecsup", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Obtener la ruta del archivo JSON desde la carpeta "assets"
            string fileName = "reservacomputadorastecsup-firebase-adminsdk-wnbve-c1a33e8a5d.json";
            string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);

            // Copiar el archivo desde la carpeta "assets" a la ubicación del archivo en el dispositivo
            using (var assetStream = Assets.Open(fileName))
            using (var fileStream = System.IO.File.Create(filePath))
            {
                assetStream.CopyTo(fileStream);
            }

            // Establecer la variable de entorno para las credenciales
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
