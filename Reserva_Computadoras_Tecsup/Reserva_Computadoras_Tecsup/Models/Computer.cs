//using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Models
{
    public class Computer
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Specs { get; set; }
        public string Marca { get; set; }
        public bool Disponibilidad { get; set; }
    }
}
