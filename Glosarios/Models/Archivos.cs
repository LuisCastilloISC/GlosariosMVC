using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosarios.Models
{
    public class Archivos
    {
        public int idArchivo { get; set; }
        public string direccion { get; set; }
        public int idUsuario { get; set; }
        public string nombreDoc { get; set; }
        public string fecha { get; set; }
    }
}
