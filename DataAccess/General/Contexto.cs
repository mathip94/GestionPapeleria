using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Dtos;
 

namespace DataAccess
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Direccion> Direccions { get; set; }
        public DbSet<Parametro> Parametro { get; set; }  
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoComun> PedidoComun { get; set; }
        public DbSet<PedidoExpress> PedidoExpresse { get; set; }
        public DbSet<LineaPedido> LineaPedidos { get; set; }
        public DbSet<Articulo> Articulo { get; set; }   

        

        public Contexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetPrecisionForDecimal(modelBuilder);

            modelBuilder.Entity<Parametro>(p => p.HasKey(p => p.Clave));

            //definir FK de direccion en Cliente
            modelBuilder.Entity<Cliente>()
                .HasOne(a => a.Direccion)  // Un Cliente tiene una Direccion
                .WithMany()     // Una Direccion tiene un Cliente
                .HasForeignKey(a => a.DireccionId);  // Clave foránea en Autor

            modelBuilder.Entity<Pedido>()
                  .HasOne(p => p.Cliente)
                  .WithMany()
                  .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<LineaPedido>()
                .HasOne(p => p.Pedido)
                .WithMany(f => f.LineaPedidos)
                .HasForeignKey(a => a.PedidoId);

            modelBuilder.Entity<LineaPedido>()
                .HasOne(p => p.Articulo)
                .WithMany()
                .HasForeignKey(a => a.ArticuloId);

             

            modelBuilder.Entity<PedidoComun>().ToTable("PedidoComun");
            modelBuilder.Entity<PedidoExpress>().ToTable("PedidoExpress");

            base.OnModelCreating(modelBuilder);
        }

        private void SetPrecisionForDecimal(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(12);
                property.SetScale(2);
            }
        }
    }
}
