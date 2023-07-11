using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Mail;
using System.Net;

namespace Reserva_Computadoras_Tecsup.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Contact : ContentPage
	{
		public Contact ()
		{
			InitializeComponent ();
		}
        private void EnviarMensaje_Clicked(object sender, EventArgs e)
        {
            string nombres = NombresEntry.Text;
            string apellidos = ApellidosEntry.Text;
            string correo = CorreoEntry.Text;
            string asunto = AsuntoEntry.Text;
            string descripcion = DescripcionEditor.Text;

            // Detalles del gmail
            string remitente = "danny.castillo@gmail.com"; // Cambia esto por tu gmail
            string contraseña = "tupassword"; // Cambia esto por tu contraseña de gmail
            string destinatario = "danny.castillo@gmail.com"; // Cambia esto por el gmail del q envias

            MailMessage mensaje = new MailMessage(remitente, destinatario, asunto, descripcion);
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
            clienteSmtp.EnableSsl = true;
            clienteSmtp.UseDefaultCredentials = false;
            clienteSmtp.Credentials = new NetworkCredential(remitente, contraseña);

            try
            {
                clienteSmtp.Send(mensaje);
                DisplayAlert("Éxito", "El mensaje ha sido enviado correctamente.", "Aceptar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "No se pudo enviar el mensaje. Error: " + ex.Message, "Aceptar");
            }
        }
    }
}