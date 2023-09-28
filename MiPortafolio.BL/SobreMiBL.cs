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
    public class SobreMiBL
    {
        SobreMiDAL sobreMiDAL;
        public SobreMiBL(FirestoreDb _db)
        {
            sobreMiDAL = new SobreMiDAL(_db);
        }

        public async Task<Respuesta<SobreMi>> InsertarSobreMi(SobreMi sobreMi)
        {       
            return await sobreMiDAL.InsertarSobreMi(sobreMi);
        }

        public async Task<Respuesta<SobreMi>> EliminarSobreMi(SobreMi sobreMi)
        {            
            return await sobreMiDAL.EliminarSobreMi(sobreMi);
        }

        public async Task<Respuesta<List<SobreMi>>> ObtenerSobreMi(Usuario usuario)
        {
            var respuesta = await sobreMiDAL.ObtenerSobreMi();

            List<SobreMi> filtrado = respuesta.objetoRespuesta.Where(item =>

                (item.Id_Usuario == usuario.Id || string.IsNullOrEmpty(usuario.Id))
            ).OrderBy(item => item.Posicion).ToList();
            respuesta.objetoRespuesta = filtrado;
            return respuesta;
        }
    }
}
