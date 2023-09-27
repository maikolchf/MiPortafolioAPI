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
    }
}
