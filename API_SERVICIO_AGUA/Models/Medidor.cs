using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SERVICIO_AGUA.Models
{
    public class Medidor
    {
        public int id_medidor { get; set; }
        public string no_medidor { get; set; }

        public int id_cliente { get; set; }

    }
}
