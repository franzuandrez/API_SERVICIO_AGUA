using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SERVICIO_AGUA.Models
{
    public class Foto
    {
        [Key]
        public int IdFoto { get; set; }
        public string Path { get; set; }

        public int IdOrden { get; set; }

        public Orden Orden { get; set; }
    }
}
