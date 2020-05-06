using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SERVICIO_AGUA.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }

        public List<Medidor> Medidores { get; set; }
    }
}
