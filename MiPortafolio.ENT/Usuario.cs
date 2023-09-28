using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.ENT
{
    [FirestoreData]
    public class Usuario
    {
        [FirestoreProperty]
        public string? Id { get; set; }

        [FirestoreProperty]
        public string? Nombre { get; set; }

        [FirestoreProperty]
        public string? PrimerApellido { get; set; }

        [FirestoreProperty]
        public string? SegundoApellido { get; set; }

        [FirestoreProperty]
        public string? PuestoLaboral { get; set; }

        [FirestoreProperty]
        public string? Celular { get; set; }

        [FirestoreProperty]
        public string? CorreoElectronico { get; set; }

        [FirestoreProperty]
        public string? Contrasenna { get; set; }

        [FirestoreProperty]
        public string? Imagen { get; set; }

        [FirestoreProperty]
        public string? ImagenPerfil { get; set; }

    }
}
