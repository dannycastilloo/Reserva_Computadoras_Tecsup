using Reserva_Computadoras_Tecsup.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class ReservasViewModel : INotifyPropertyChanged
    {
        private Computer selectedComputer;
        private ComputerRepository computerRepository;

        public event PropertyChangedEventHandler PropertyChanged;

        public IList<Computer> Computers { get; private set; }

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


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
