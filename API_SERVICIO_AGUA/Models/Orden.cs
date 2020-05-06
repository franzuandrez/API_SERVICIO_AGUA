using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SERVICIO_AGUA.Models
{
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }
        public string NoOrden { get; set; }

        public int Estado { get; set; }

        public DateTime Fecha { get; set; }

        public int IdMotivo { get; set; }
        public Motivo Motivo { get; set; }


        public int IdMedidor { get; set; }
        public Medidor Medidor { get; set; }


        public int IdUsuarioAsignador { get; set; }
        public Usuario UsuarioAsignador { get; set; }

        public int IdUsuarioDespacha { get; set; }
        public Usuario UsuarioDespacha { get; set; }


        public List<Foto> Fotos { get; set; }

    }
}
