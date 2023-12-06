using System;
using System.Collections.Generic;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Models
{
    public class Reservation
    {
        public int ReserveId { get; set; }
        public int UserId { get; set; }
        public int ComputerId { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string State { get; set; }
        public string key { get; set; }
        public bool Active { get; set; }

    }
}
