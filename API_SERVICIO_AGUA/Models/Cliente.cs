using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SERVICIO_AGUA.Models
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string nit { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }

        public List<Medidor> medidores { get; set; }
    }
}
