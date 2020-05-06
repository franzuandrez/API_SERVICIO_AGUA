using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_SERVICIO_AGUA.Models;
namespace API_SERVICIO_AGUA.Data
{
    public class OrdenContext :DbContext
    {
        public OrdenContext(DbContextOptions<OrdenContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orden>()
                .HasOne(p => p.UsuarioAsignador)
                .WithMany(b => b.OrdenesAsignadas);

            modelBuilder.Entity<Orden>()
               .HasOne(p => p.UsuarioDespacha)
               .WithMany(b => b.OrdenesDespachadas);
        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Medidor> Medidor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Motivo> Motivo { get; set; }

        public DbSet<Orden> Orden { get; set; }
        public DbSet<Foto> Foto { get; set; }

    }
}
