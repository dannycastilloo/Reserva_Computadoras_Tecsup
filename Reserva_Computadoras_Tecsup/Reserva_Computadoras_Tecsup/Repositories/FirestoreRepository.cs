using Google.Cloud.Firestore;
using Reserva_Computadoras_Tecsup.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Repositories
{
    public class FirestoreRepository 
    {
        private readonly string CollectionName;
        public FirestoreDb firestoreDb;

        public FirestoreRepository(string CollectionName)
        {
            string filePath = "/Users/diegu/reservacomputadorastecsup-firebase-adminsdk-wnbve-c1a33e8a5d.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            firestoreDb = FirestoreDb.Create("reservacomputadorastecsup");
            this.CollectionName = CollectionName;
        }
        public T Get<T>(T record) where T : FirebaseDocument
        {
            DocumentReference docRef = firestoreDb.Collection(CollectionName).Document(record.Id);
            DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();
            if (snapshot.Exists)
            {
                T usr = snapshot.ConvertTo<T>();
                usr.Id = snapshot.Id;
                return usr;
            }
            else
            {
                return null;
            }
        }
    }
}
