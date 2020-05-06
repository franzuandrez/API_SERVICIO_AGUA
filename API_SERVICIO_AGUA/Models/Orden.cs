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
        public int id_orden { get; set; }
        public string no_orden { get; set; }

        public int estado { get; set; }

        public DateTime fecha { get; set; }

        public int id_motivo { get; set; }
        public Motivo motivo { get; set; }


        public int id_medidor { get; set; }
        public Medidor medidor { get; set; }


        public int id_usuario_asignador { get; set; }
        public Usuario usuario_asignador { get; set; }

        public int id_usuario_despacha { get; set; }
        public Usuario usuario_despacha { get; set; }


        public List<Foto> fotos { get; set; }

    }
}
