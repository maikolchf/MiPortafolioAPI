using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.ENT
{
    public class Respuesta<T>
    {
        public bool hayError { get; set; }
        public string? mensaje { get; set; }
        public T? objetoRespuesta { get; set; }
    }
}
