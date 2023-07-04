using Reserva_Computadoras_Tecsup.Models;
using System;
using System.Collections.Generic;
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
        public IList<Computer> Computers { get; private set; }
        public SelectPc()
        {
            InitializeComponent();
            Computers = new List<Computer>
            {
                new Computer
                {
                    Name = "Computadora1",
                    Specs = "Intel i9 12900k - 64GB RAM"
                },
                new Computer
                {
                    Name = "Computadora1",
                    Specs = "Intel i9 12900k - 32GB RAM"
                },
                new Computer
                {
                    Name = "Computadora1",
                    Specs = "Intel i9 12900k - 32GB RAM"
                },
                new Computer
                {
                    Name = "Computadora1",
                    Specs = "Intel i9 12900k - 64GB RAM"
                }
            };
            BindingContext = this;
        }
        
        private async void SelectPC(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SelectDatetime());
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Computer selectedItem = e.SelectedItem as Computer;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Computer tappedItem = e.Item as Computer;
        }
    }
}