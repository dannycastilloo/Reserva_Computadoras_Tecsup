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
    public partial class Reservar1 : ContentPage
    {
        public Reservar1()
        {
            InitializeComponent();
            List<string> computadoras = new List<string>
            {
                "PC-01",
                "PC-02",
                "PC-03",
                "PC-04",
                "PC-05",
                "PC-06",
                "PC-07",
                "PC-08",
                "PC-09",
                "PC-10",
                "PC-01",
                "PC-02",
                "PC-03",
                "PC-04",
                "PC-05",
                "PC-06",
                "PC-07",
                "PC-08",
                "PC-09",
                "PC-10"
            };
            misComputadoras.ItemsSource = computadoras;
        }
    }
}