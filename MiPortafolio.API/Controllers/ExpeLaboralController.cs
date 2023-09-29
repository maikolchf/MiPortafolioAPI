using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using MiPortafolio.BL;
using MiPortafolio.ENT;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiPortafolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpeLaboralController : ControllerBase
    {
        private ExpeLaboralBL expeLaboralBL;
        public ExpeLaboralController(FirestoreDb _db)
        {
            expeLaboralBL = new ExpeLaboralBL(_db);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<ExpeLaboral>> InsertarExpeLaboral([FromBody] ExpeLaboral expeLaboral)
        {
            return await expeLaboralBL.InsertarExpeLaboral(expeLaboral);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<ExpeLaboral>> EliminarExpeLaboral([FromBody] ExpeLaboral expeLaboral)
        {
            return await expeLaboralBL.EliminarExpeLaboral(expeLaboral);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Respuesta<List<ExpeLaboral>>> ObtenerExpeLaboral([FromBody] Usuario usuario)
        {
            return await expeLaboralBL.ObtenerExpeLaboral(usuario);
        }
    }
}
