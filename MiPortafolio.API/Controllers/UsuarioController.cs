using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using MiPortafolio.BL;
using MiPortafolio.ENT;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiPortafolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioBL usuarioBL;
        public UsuarioController(FirestoreDb firestore)
        {
            usuarioBL = new UsuarioBL(firestore);
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<Usuario>> PostInsertarUsuario([FromBody] Usuario value)
        {
            return await usuarioBL.InsertarUsuario(value);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<List<Usuario>>> PostObtenerUsuario([FromBody] Usuario value)
        {
            return await usuarioBL.ObtenerUsuarios(value);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<Usuario>> PostModificarUsuario([FromBody] Usuario value)
        {
            return await usuarioBL.ModificarUsuario(value);
        }
    }
}
