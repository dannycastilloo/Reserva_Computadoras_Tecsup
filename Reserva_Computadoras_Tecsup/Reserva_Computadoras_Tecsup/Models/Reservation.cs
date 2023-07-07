using System;
using System.Collections.Generic;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdComputer { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }
}
