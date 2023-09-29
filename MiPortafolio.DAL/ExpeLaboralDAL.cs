using Google.Cloud.Firestore;
using Google.Type;
using MiPortafolio.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.DAL
{
    public class ExpeLaboralDAL
    {
        FirestoreDb DB;
        public ExpeLaboralDAL(FirestoreDb _db)
        {
            DB = _db;
        }

        public async Task<Respuesta<ExpeLaboral>> InsertarExpeLaboral(ExpeLaboral expeLaboral)
        {
            Respuesta<ExpeLaboral> respuesta = new Respuesta<ExpeLaboral>();
            try
            {
                CollectionReference reference = DB.Collection("ExpeLaboral");
                DocumentReference nuevoRegistro = reference.Document();
                expeLaboral.Id = nuevoRegistro.Id;
                await nuevoRegistro.SetAsync(expeLaboral);

                respuesta.hayError = false;
                respuesta.mensaje = "Registro insertado correctamente";
                respuesta.objetoRespuesta = expeLaboral;

            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "Ah acurrido un error al realizar el proceso";
                respuesta.objetoRespuesta = expeLaboral;
            }

            return respuesta;
        }

        public async Task<Respuesta<ExpeLaboral>> EliminarExpeLaboral(ExpeLaboral expeLaboral)
        {
            Respuesta<ExpeLaboral> respuesta = new Respuesta<ExpeLaboral>();
            try
            {
                DocumentReference reference = DB.Collection("ExpeLaboral").Document(expeLaboral.Id);
                await reference.DeleteAsync();

                respuesta.hayError = false;
                respuesta.mensaje = "Registro eliminado correctamente";
                respuesta.objetoRespuesta = expeLaboral;

            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "Ah acurrido un error al realizar el proceso";
                respuesta.objetoRespuesta = expeLaboral;
            }

            return respuesta;
        }

        public async Task<Respuesta<List<ExpeLaboral>>> ObtenerExpeLaboral()
        {
            Respuesta<List<ExpeLaboral>> respuesta = new Respuesta<List<ExpeLaboral>>();
            respuesta.objetoRespuesta = new List<ExpeLaboral>();
            try
            {
                CollectionReference reference = DB.Collection("ExpeLaboral");
                QuerySnapshot documents = await reference.GetSnapshotAsync();

                foreach (DocumentSnapshot document in documents.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> dict = document.ToDictionary();
                        ExpeLaboral expe = new ExpeLaboral()
                        {
                            Id = dict["Id"].ToString(),
                            Id_Usuario = dict["Id_Usuario"].ToString(),
                            Descripcion = dict["Descripcion"].ToString(),
                            Titulo = dict["Titulo"].ToString(),
                            Imagen = dict["Imagen"].ToString(),
                            Link = dict["Link"].ToString(),
                            FechaFin =dict["FechaFin"].ToString(),
                            FechaInicio = dict["FechaInicio"].ToString(),
                        };

                        respuesta.objetoRespuesta.Add(expe);
                    }
                }

                respuesta.hayError = false;
                respuesta.mensaje = "Datos obtenidos correctamente";

            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "Ah acurrido un error al realizar el proceso";
                respuesta.objetoRespuesta = new List<ExpeLaboral>();
            }
            return respuesta;
        }
    }
}
