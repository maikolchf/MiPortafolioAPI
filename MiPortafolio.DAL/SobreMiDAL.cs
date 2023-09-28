using Google.Cloud.Firestore;
using MiPortafolio.ENT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.DAL
{

    public class SobreMiDAL
    {
        FirestoreDb DB;
        public SobreMiDAL(FirestoreDb _db)
        {
            DB = _db;
        }

        public async Task<Respuesta<SobreMi>> InsertarSobreMi(SobreMi sobreMi)
        {
            Respuesta<SobreMi> respuesta = new Respuesta<SobreMi>();
            try
            {
                CollectionReference reference = DB.Collection("SobreMi");
                DocumentReference nuevoRegistro = reference.Document();
                sobreMi.Id = nuevoRegistro.Id;
                await nuevoRegistro.SetAsync(sobreMi);

                respuesta.hayError = false;
                respuesta.mensaje = "Registro insertado correctamente";
                respuesta.objetoRespuesta = sobreMi;

            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "Ah acurrido un error al realizar el proceso";
                respuesta.objetoRespuesta = sobreMi;
            }

            return respuesta;
        }

        public async Task<Respuesta<SobreMi>> EliminarSobreMi(SobreMi sobreMi)
        {
            Respuesta<SobreMi> respuesta = new Respuesta<SobreMi>();
            try
            {
                DocumentReference reference = DB.Collection("SobreMi").Document(sobreMi.Id);
                await reference.DeleteAsync();

                respuesta.hayError = false;
                respuesta.mensaje = "Registro eliminado correctamente";
                respuesta.objetoRespuesta = sobreMi;

            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "Ah acurrido un error al realizar el proceso";
                respuesta.objetoRespuesta = sobreMi;
            }

            return respuesta;
        }

        public async Task<Respuesta<List<SobreMi>>> ObtenerSobreMi()
        {
            Respuesta<List<SobreMi>> respuesta = new Respuesta<List<SobreMi>>();
            respuesta.objetoRespuesta = new List<SobreMi>();
            try
            {
                CollectionReference reference = DB.Collection("SobreMi");
                QuerySnapshot documents = await reference.GetSnapshotAsync();

                foreach (DocumentSnapshot document in documents.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> dict = document.ToDictionary();
                        SobreMi user = new SobreMi()
                        {
                            Id = dict["Id"].ToString(),
                            Id_Usuario = dict["Id_Usuario"].ToString(),
                            Descripcion = dict["Descripcion"].ToString(),
                            Posicion = Convert.ToInt32(dict["Posicion"])
                        };

                        respuesta.objetoRespuesta.Add(user);
                    }
                }

                respuesta.hayError = false;
                respuesta.mensaje = "Datos obtenidos correctamente";

            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "Ah acurrido un error al realizar el proceso";
                respuesta.objetoRespuesta = new List<SobreMi>();
            }
            return respuesta;
        }
    }
}
