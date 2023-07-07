using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.Repositories;
using System.Collections.Generic;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class ComputerViewModel
    {
        private readonly ComputerRepository computerRepository;

        public ComputerViewModel()
        {
            computerRepository = new ComputerRepository();
        }

        public List<Computer> GetAllComputers()
        {
            return computerRepository.GetComputersAsync().Result;
        }
    }
}
