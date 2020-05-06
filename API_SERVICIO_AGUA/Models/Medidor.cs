using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SERVICIO_AGUA.Models
{
    public class Medidor

    {
        [Key]
        public int IdMedidor { get; set; }
        public string NoMedidor { get; set; }

        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }


    }
}
