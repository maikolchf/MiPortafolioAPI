using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using MiPortafolio.BL;
using MiPortafolio.ENT;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiPortafolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobreMiController : ControllerBase
    {
        SobreMiBL sobreMiBL;
        public SobreMiController(FirestoreDb _db)
        {
            sobreMiBL = new SobreMiBL(_db);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<SobreMi>> InsertarSobreMi([FromBody] SobreMi sobreMi)
        {
            return await sobreMiBL.InsertarSobreMi(sobreMi);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<SobreMi>> EliminarSobreMi([FromBody] SobreMi sobreMi)
        {
            return await sobreMiBL.EliminarSobreMi(sobreMi);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<List<SobreMi>>> ObtenerSobreMi([FromBody] Usuario usuario)
        {
            return await sobreMiBL.ObtenerSobreMi(usuario);
        }
    }
}
