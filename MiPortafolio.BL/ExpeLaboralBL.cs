using Google.Cloud.Firestore;
using MiPortafolio.DAL;
using MiPortafolio.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.BL
{
    public class ExpeLaboralBL
    {
        private ExpeLaboralDAL expeLaboralDAL;
        public ExpeLaboralBL(FirestoreDb _db)
        {
            expeLaboralDAL = new ExpeLaboralDAL(_db);
        }
        public async Task<Respuesta<ExpeLaboral>> InsertarExpeLaboral(ExpeLaboral expeLaboral)
        {
            return await expeLaboralDAL.InsertarExpeLaboral(expeLaboral);
        }

        public async Task<Respuesta<ExpeLaboral>> EliminarExpeLaboral(ExpeLaboral expeLaboral)
        {
            return await expeLaboralDAL.EliminarExpeLaboral(expeLaboral);
        }

        public async Task<Respuesta<List<ExpeLaboral>>> ObtenerExpeLaboral(Usuario usuario)
        {
            var respuesta = await expeLaboralDAL.ObtenerExpeLaboral();

            List<ExpeLaboral> filtrado = respuesta.objetoRespuesta.Where(item =>

                (item.Id_Usuario == usuario.Id || string.IsNullOrEmpty(usuario.Id))
            ).ToList();
            respuesta.objetoRespuesta = filtrado;
            return respuesta;
        }
    }
}
