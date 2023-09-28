using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.ENT
{
    [FirestoreData]
    public class SobreMi
    {
        [FirestoreProperty]
        public string? Id { get; set; }
        [FirestoreProperty]
        public string? Id_Usuario { get; set; }
        [FirestoreProperty]
        public string? Descripcion { get; set; }
        [FirestoreProperty]
        public int Posicion { get; set; }
    }
}
