using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiPortafolio.DAL;
using MiPortafolio.ENT;

namespace MiPortafolio.BL
{
    public class UsuarioBL
    {        
        UsuarioDAL usuarioDAL;
        public UsuarioBL(FirestoreDb _db)
        {
            usuarioDAL = new UsuarioDAL(_db);
        }

        public async Task<Respuesta<Usuario>> InsertarUsuario(Usuario usuario)
        {           
            return await usuarioDAL.InsertarUsuario(usuario);
        }

        public async Task<Respuesta<List<Usuario>>> ObtenerUsuarios(Usuario usuario)
        {
            var respuesta = await usuarioDAL.ObtenerUsuarios(usuario);            

            List<Usuario> filtrado = respuesta.objetoRespuesta.Where( item =>
            
                (item.Nombre == usuario.Nombre || string.IsNullOrEmpty(usuario.Nombre)) &&
                (item.PrimerApellido == usuario.PrimerApellido || string.IsNullOrEmpty(usuario.PrimerApellido)) &&
                (item.SegundoApellido == usuario.SegundoApellido || string.IsNullOrEmpty(usuario.SegundoApellido)) &&
                (item.Celular == usuario.Celular || string.IsNullOrEmpty(usuario.Celular)) &&
                (item.CorreoElectronico == usuario.CorreoElectronico || string.IsNullOrEmpty(usuario.CorreoElectronico))
            ).ToList();

            respuesta.objetoRespuesta = filtrado;
            return respuesta;
        }
        public async Task<Respuesta<Usuario>> ModificarUsuario(Usuario usuario)
        {
            return await usuarioDAL.ModificarUsuario(usuario);
        }
    }
}
