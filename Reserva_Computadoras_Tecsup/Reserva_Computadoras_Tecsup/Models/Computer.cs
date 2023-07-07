using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Reserva_Computadoras_Tecsup.Models
{
    [FirestoreData]
    public class Computer : FirebaseDocument
    {
        [FirestoreProperty]
        public string Codigo { get; set; }

        [FirestoreProperty]
        public string Specs { get; set; }

        [FirestoreProperty]
        public string Marca { get; set; }

        [FirestoreProperty]
        public bool Disponibilidad { get; set; }

    }
}
