using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using MiPortafolio.ENT;

namespace MiPortafolio.DAL
{
    public  class UsuarioDAL
    {
        FirestoreDb DB;
        public UsuarioDAL(FirestoreDb _db) {
            DB = _db;
        }

        public async Task<Respuesta<Usuario>> InsertarUsuario( Usuario usuario )
        {
            Respuesta<Usuario> respuesta = new Respuesta<Usuario>();
            try
            {
                CollectionReference reference = DB.Collection("usuario");
                DocumentReference nuevoRegistro = reference.Document();

                await nuevoRegistro.SetAsync(usuario);

                respuesta.hayError = false;
                respuesta.mensaje = "Registro insertado correctamente";
                respuesta.objetoRespuesta = usuario;

            }
            catch(Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "Ah acurrido un error al realizar el proceso";
                respuesta.objetoRespuesta = usuario;
            }

            return respuesta; 
        }

    }
}
