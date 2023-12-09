using Firebase.Database;
using Reserva_Computadoras_Tecsup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Computadoras_Tecsup.Services
{
    public class ReservationService
    {
        private readonly FirebaseClient firebaseClient;

        public ReservationService()
        {
            // Inicializa tu cliente de Firebase aquí
            firebaseClient = new FirebaseClient("https://reservacomputadorastecsup-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Reservation>> GetReservations()
        {
            var reservations = await firebaseClient
                .Child("PastReserves")
                .OnceAsync<Reservation>();

            return reservations.Select(r => r.Object).ToList();
        }
    }
}
