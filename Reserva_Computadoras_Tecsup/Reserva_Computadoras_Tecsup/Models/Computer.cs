//using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Models
{
    class Computer
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specs { get; set; }
    }
}
