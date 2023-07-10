using Firebase.Database;
using Firebase.Database.Query;
using Reserva_Computadoras_Tecsup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Computadoras_Tecsup.Services
{
    public class FirebaseService
    {
        private FirebaseClient firebase;

        public FirebaseService()
        {
            firebase = new FirebaseClient("https://reservacomputadorastecsup-default-rtdb.firebaseio.com/");
        }

        public async Task<IList<Computer>> GetComputers()
        {
            return (await firebase.Child("computers").OnceAsync<Computer>()).Select(item => new Computer
            {
                Id = int.Parse(item.Key),
                Codigo = item.Object.Codigo,
                Specs = item.Object.Specs,
                Marca = item.Object.Marca,
                Disponibilidad = item.Object.Disponibilidad
            }).ToList();
        }

        public async Task AddReservation(Reservation reservation)
        {
            var result = await firebase.Child("reservations").PostAsync(reservation);
            reservation.Id = int.Parse(result.Key);
        }

        public async Task<IList<Reservation>> GetReservationsByUserId(int userId)
        {
            return (await firebase.Child("reservations").OrderBy("IdUsuario").EqualTo(userId).OnceAsync<Reservation>()).Select(item => new Reservation
            {
                Id = int.Parse(item.Key),
                IdUsuario = item.Object.IdUsuario,
                IdComputer = item.Object.IdComputer,
                FechaHoraInicio = item.Object.FechaHoraInicio,
                FechaHoraFin = item.Object.FechaHoraFin
            }).ToList();
        }
    }
}
