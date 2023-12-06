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
                    Model = "Intel i9 12900k - 64GB RAM",
                    Brand = "Dell"
                },
                new Models.Computer
                {
                    Codigo = "Computadora 2",
                    Model = "Intel i9 12900k - 32GB RAM",
                    Brand= "Dell"
                },
                new Models.Computer
                {
                    Codigo = "Computadora 3",
                    Model = "Intel i9 12900k - 32GB RAM",
                    Brand="Dell"
                },
                new Models.Computer
                {
                    Codigo = "Computadora 4",
                    Model = "Intel i9 12900k - 64GB RAM",
                    Brand= "Dell"
                }
            };
        }
    }
}
