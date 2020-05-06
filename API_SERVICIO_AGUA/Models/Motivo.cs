using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SERVICIO_AGUA.Models
{
    public class Motivo
    {
        [Key]
        public int IdMotivo { get; set; }
        public string Descripcion { get; set; }

        public List<Orden> Ordenes { get; set; }
    }
}
