using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class ReservasViewModel : INotifyPropertyChanged
    {
        private Computer selectedComputer;
        private ComputerService computerService;
        private FirebaseService firebaseService;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public IList<Computer> Computers { get; private set; }

        public ReservasViewModel()
        {
            computerService = new ComputerService();
            LoadComputersAsync();
            firebaseService = new FirebaseService();
        }
        private async Task LoadComputersAsync()
        {
            Computers = await computerService.GetComputers(); // Utilizar await para esperar a que la tarea se complete
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task AddReservation(Reservation reservation)
        {
            await firebaseService.AddReservation(reservation);
        }
        public async Task<IList<Reservation>> GetReservationsByUserId(int userId)
        {
            return await firebaseService.GetReservationsByUserId(userId);
        }
    }
}
