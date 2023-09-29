using Google.Cloud.Firestore;
using MiPortafolio.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.BL
{
    public class DatosPortafolioBL
    {
        private UsuarioBL usuarioBL;
        private SobreMiBL sobreMiBL;
        private ExpeLaboralBL expeLaboralBL;
        public DatosPortafolioBL(FirestoreDb _db)
        {
            usuarioBL = new UsuarioBL(_db);
            sobreMiBL = new SobreMiBL(_db);
            expeLaboralBL = new ExpeLaboralBL(_db);
        }

        public Respuesta<DatoPortafolio> ObtenerDatos(string idUsuario)
        {
            Respuesta<DatoPortafolio> respuesta = new Respuesta<DatoPortafolio>();
            DatoPortafolio datoPortafolio = new DatoPortafolio();

            try
            {
                Usuario filtro = new Usuario { Id = idUsuario };

                datoPortafolio.usuario = usuarioBL.ObtenerUsuarios(filtro).Result.objetoRespuesta?.FirstOrDefault();
                datoPortafolio.sobreMi = sobreMiBL.ObtenerSobreMi(filtro).Result.objetoRespuesta;
                datoPortafolio.expeLaboral = expeLaboralBL.ObtenerExpeLaboral(filtro).Result.objetoRespuesta;

                respuesta.objetoRespuesta= datoPortafolio;
                respuesta.hayError = false;
                respuesta.mensaje = "Datos obtenidos correctamente";
            }
            catch (Exception)
            {
                respuesta.hayError = true;
                respuesta.mensaje = "Ah acurrido un error al realizar el proceso";
                respuesta.objetoRespuesta = datoPortafolio;
            }

            return respuesta;
        }
    }
}
