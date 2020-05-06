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
        public int id_foto { get; set; }
        public string path { get; set; }

        public int id_orden { get; set; }

        public Orden orden { get; set; }
    }
}
