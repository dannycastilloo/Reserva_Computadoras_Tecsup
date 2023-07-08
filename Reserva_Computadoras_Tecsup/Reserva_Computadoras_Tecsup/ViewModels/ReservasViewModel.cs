using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class ReservasViewModel : INotifyPropertyChanged
    {
        private Computer selectedComputer;
        public event PropertyChangedEventHandler PropertyChanged;

        public IList<Computer> Computer { get; private set; }

        public Computer SelectedComputer
        {
            get { return selectedComputer; }
            set
            {
                if (selectedComputer != value)
                {
                    selectedComputer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ReservasViewModel()
        {
            Computer = ComputerService.GetComputers();
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
