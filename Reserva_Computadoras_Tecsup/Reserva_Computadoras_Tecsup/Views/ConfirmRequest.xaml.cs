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
	public partial class ConfirmRequest : ContentPage
	{
        public Usuario CurrentUser { get; set; }
        public Computer SelectedComputer { get; set; }
        public ConfirmRequest (string informacionHoras, Computer selectedComputer)
		{
			InitializeComponent ();
            horasLabel.Text = informacionHoras;
            SelectedComputer = selectedComputer;
            CurrentUser = new Usuario { Name = "Danny Castillo" };
            BindingContext = this;
        }
        private async void VolverInicio(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}