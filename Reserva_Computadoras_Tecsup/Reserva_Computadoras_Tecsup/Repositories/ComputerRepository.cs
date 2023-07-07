using Google.Cloud.Firestore;
using Reserva_Computadoras_Tecsup.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reserva_Computadoras_Tecsup.Repositories
{
    public class ComputerRepository : IFirestoreRepository<Computer>
    {
        private readonly string CollectionName = "Computadoras";
        private readonly FirestoreDb firestoreDb;

        public ComputerRepository()
        {
            firestoreDb = FirestoreDb.Create("reservacomputadorastecsup");
        }

        public async Task<List<Computer>> GetComputersAsync()
        {
            CollectionReference collectionRef = firestoreDb.Collection(CollectionName);
            QuerySnapshot snapshot = await collectionRef.GetSnapshotAsync();

            List<Computer> computers = new List<Computer>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    Computer computer = document.ConvertTo<Computer>();
                    computer.Id = document.Id;
                    computers.Add(computer);
                }
            }

            return computers;
        }

        public Computer Get(Computer record)
        {
            throw new System.NotImplementedException();
        }
    }
}
