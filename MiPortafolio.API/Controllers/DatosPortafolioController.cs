using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using MiPortafolio.BL;
using MiPortafolio.ENT;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiPortafolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosPortafolioController : ControllerBase
    {
        private DatosPortafolioBL datosPortafolio;
        public DatosPortafolioController(FirestoreDb _db) {
            datosPortafolio = new DatosPortafolioBL(_db);
        }    
        
        [HttpGet("{id}")]
        public Respuesta<DatoPortafolio> Get(string id)
        {
            return datosPortafolio.ObtenerDatos(id);
        }     
    }
}
