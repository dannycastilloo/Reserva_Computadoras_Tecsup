using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class ComputerViewModel
    {
        private readonly ComputerRepository computerRepository;

        public ObservableCollection<Computer> Computers { get; private set; }

        public ComputerViewModel()
        {
            computerRepository = new ComputerRepository();
            Computers = new ObservableCollection<Computer>(GetAllComputers());
        }

        public List<Computer> GetAllComputers()
        {
            return computerRepository.GetComputersAsync().Result;
        }
    }
}
