using Reserva_Computadoras_Tecsup.Models;
using Reserva_Computadoras_Tecsup.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reserva_Computadoras_Tecsup.ViewModels
{
    public class ComputersViewModel
    {
        public IList<Computer> Computers { get; private set; }

        public ComputersViewModel()
        {
            Computers = ComputerService.GetComputers();
        }
    }
}
