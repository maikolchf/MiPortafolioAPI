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
        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<Respuesta<Usuario>> Post([FromBody] Usuario value)
        {
            return await usuarioBL.InsertarUsuario(value);
        }

    }
}
