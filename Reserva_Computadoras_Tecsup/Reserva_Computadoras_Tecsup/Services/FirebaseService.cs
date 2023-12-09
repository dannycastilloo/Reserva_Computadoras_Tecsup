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
            return (await firebase.Child("Computers").OnceAsync<Computer>()).Select(item => new Computer
            {
                Id = int.Parse(item.Key),
                Codigo = item.Object.Codigo,
                Model = item.Object.Model,
                Brand = item.Object.Brand,
                Software = item.Object.Software,
                Available = item.Object.Available
            }).ToList();
        }

        public async Task AddReservation(Reservation reservation)
        {
            var result = await firebase.Child("PastReserves").PostAsync(reservation);
            reservation.ReserveId = int.Parse(result.Key);
        }

        public async Task<IList<Reservation>> GetReservationsByUserId(int userId)
        {
            return (await firebase.Child("PastReserves").OrderBy("UserId").EqualTo(userId).OnceAsync<Reservation>()).Select(item => new Reservation
            {

                ReserveId = int.Parse(item.Key),
                UserId = item.Object.UserId,
                ComputerId = item.Object.ComputerId,
                State = item.Object.State,
                FechaHoraInicio = item.Object.FechaHoraInicio,
                FechaHoraFin = item.Object.FechaHoraFin,
                Active = item.Object.Active
                
            }).ToList();
        }
    }
}
