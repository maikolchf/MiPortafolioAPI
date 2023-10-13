using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using MiPortafolio.ENT;
using Newtonsoft.Json;

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
                usuario.Id = nuevoRegistro.Id;
                await nuevoRegistro.SetAsync(usuario);

                respuesta.hayError = false;
                respuesta.mensaje = "¡Registro insertado correctamente!";
                respuesta.objetoRespuesta = usuario;

            }
            catch(Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "¡Ah acurrido un error al realizar el proceso!";
                respuesta.objetoRespuesta = usuario;
            }

            return respuesta; 
        }

        public async Task<Respuesta<Usuario>> ModificarUsuario(Usuario usuario)
        {
            Respuesta<Usuario> respuesta = new Respuesta<Usuario>();
            try
            {                
                DocumentReference reference = DB.Collection("usuario").Document(usuario.Id);

                string jsonUsuario = JsonConvert.SerializeObject(usuario);

                Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string,object>>(jsonUsuario);

                await reference.UpdateAsync(dict);

                respuesta.hayError = false;
                respuesta.mensaje = "¡Registro modificado correctamente!";
                respuesta.objetoRespuesta = usuario;

            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "¡Ah acurrido un error al realizar el proceso!";
                respuesta.objetoRespuesta = usuario;
            }

            return respuesta;
        }

        public async Task<Respuesta<List<Usuario>>> ObtenerUsuarios(Usuario usuario)
        {
            Respuesta<List<Usuario>> respuesta = new Respuesta<List<Usuario>>();
            respuesta.objetoRespuesta = new List<Usuario>();
            try
            {
                CollectionReference reference = DB.Collection("usuario");
                QuerySnapshot documents = await reference.GetSnapshotAsync();

                foreach (DocumentSnapshot document in documents.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> dict = document.ToDictionary();
                        Usuario user = new Usuario()
                        {
                            Celular = dict["Celular"].ToString(),
                            Contrasenna = dict["Contrasenna"].ToString(),
                            CorreoElectronico = dict["CorreoElectronico"].ToString(),
                            Id = dict["Id"].ToString(),
                            Nombre = dict["Nombre"].ToString(),
                            PrimerApellido = dict["PrimerApellido"].ToString(),
                            SegundoApellido = dict["SegundoApellido"].ToString(),
                            Imagen = dict["Imagen"].ToString(),
                            PuestoLaboral = dict["PuestoLaboral"].ToString(),
                            ImagenPerfil = dict["ImagenPerfil"].ToString()

                        };

                        respuesta.objetoRespuesta.Add(user);
                    }
                }

                respuesta.hayError = false;
                respuesta.mensaje = "¡Datos obtenidos correctamente!";

            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "¡Ah acurrido un error al realizar el proceso!";
                respuesta.objetoRespuesta = null;
            }

            return respuesta;
        }
    }
}
