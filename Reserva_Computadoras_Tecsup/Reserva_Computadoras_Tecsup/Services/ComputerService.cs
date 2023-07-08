using System;
using System.Collections.Generic;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Services
{
    public class ComputerService
    {
        public static IList<Models.Computer> GetComputers()
        {
            return new List<Models.Computer>
            {
                new Models.Computer
                {
                    Codigo = "Computadora 1",
                    Specs = "Intel i9 12900k - 64GB RAM"
                },
                new Models.Computer
                {
                    Codigo = "Computadora 2",
                    Specs = "Intel i9 12900k - 32GB RAM"
                },
                new Models.Computer
                {
                    Codigo = "Computadora 3",
                    Specs = "Intel i9 12900k - 32GB RAM"
                },
                new Models.Computer
                {
                    Codigo = "Computadora 4",
                    Specs = "Intel i9 12900k - 64GB RAM"
                }
            };
        }
    }
}
