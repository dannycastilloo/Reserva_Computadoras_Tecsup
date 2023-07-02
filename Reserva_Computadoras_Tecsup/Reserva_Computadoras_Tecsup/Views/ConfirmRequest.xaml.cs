﻿using System;
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
		public ConfirmRequest ()
		{
			InitializeComponent ();
		}
        private async void VolverInicio(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}