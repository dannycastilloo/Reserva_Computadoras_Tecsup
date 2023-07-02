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
    public partial class SelectPc : ContentPage
    {
        public SelectPc()
        {
            InitializeComponent();
        }
        private async void SelectPC(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SelectDatetime());
        }
    }
}