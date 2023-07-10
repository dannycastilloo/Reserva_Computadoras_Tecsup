using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class ComputersViewModel
    {
        public IList<Computer> Computers { get; private set; }

        public async Task LoadComputersAsync()
        {
            var computerService = new ComputerService();
            Computers = await computerService.GetComputers();
        }
    }
}
