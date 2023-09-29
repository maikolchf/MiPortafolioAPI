using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPortafolio.ENT
{
    public class DatoPortafolio
    {
        public Usuario? usuario { get; set; }
        public List<SobreMi>? sobreMi { get; set; }
        public List<ExpeLaboral>? expeLaboral { get; set;}
    }
}
