using Google.Cloud.Firestore;
using Google.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.ENT
{
    [FirestoreData]
    public class ExpeLaboral
    {
        [FirestoreProperty]
        public string? Id { get; set; }
        [FirestoreProperty]
        public string? Id_Usuario { get; set; }
        [FirestoreProperty]
        public string? Imagen { get; set; }
        [FirestoreProperty]
        public string? Titulo { get; set; }
        [FirestoreProperty]
        public string? Descripcion { get; set; }
        [FirestoreProperty]
        public string? Link { get; set; }
        [FirestoreProperty]
        public string? FechaInicio { get; set; }
        [FirestoreProperty]
        public string? FechaFin { get; set; }
    }
}
