//using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Models
{
    public class Computer
    {
        public string Name { get; set; }
        public string Specs { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
