using System;
using System.Collections.Generic;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Carrera { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
