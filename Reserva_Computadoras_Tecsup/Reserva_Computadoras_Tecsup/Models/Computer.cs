//using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Software { get; set; }
        public bool Available { get; set; }
    }
}
