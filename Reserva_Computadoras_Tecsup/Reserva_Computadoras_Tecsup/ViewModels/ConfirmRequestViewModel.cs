using Reserva_Computadoras_Tecsup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class ConfirmRequestViewModel : INotifyPropertyChanged
    {
        private Computer selectedComputer;
        private Reservation reservation;

        public event PropertyChangedEventHandler PropertyChanged;

        public Computer SelectedComputer
        {
            get { return selectedComputer; }
        }
        public string CurrentUserName
        {
            get { return reservation?.IdUsuario.ToString(); }
        }

        public ConfirmRequestViewModel(Computer selectedComputer, Reservation reservation)
        {
            this.selectedComputer = selectedComputer;
            this.reservation = reservation;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
