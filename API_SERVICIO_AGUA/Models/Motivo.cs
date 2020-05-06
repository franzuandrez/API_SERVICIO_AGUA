using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SERVICIO_AGUA.Models
{
    public class Motivo
    {
        public int id_motivo { get; set; }
        public string descripcion { get; set; }

        public List<Orden> ordenes { get; set; }
    }
}
