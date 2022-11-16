using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace TrabajoPlataformas
{
    internal class Contexto : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<CajaAhorro> cajas { get; set; }
        public DbSet<PlazoFijo> plazos { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<Movimiento> movimientos { get; set; }
        public DbSet<TarjetaCredito> tarjetas { get; set; }
        


        private readonly string _connectionString;
        public Contexto(string connectionString)

        {

            _connectionString = connectionString;

        }
        public Contexto() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(_connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CREACIONES DE CLASES 
            
            modelBuilder.Entity<Usuario>()
               .ToTable("Usuarios")
               .HasKey(u => u.id);
            modelBuilder.Entity<CajaAhorro>()
                .ToTable("Cajas")
                .HasKey(d => d.id);
            modelBuilder.Entity<PlazoFijo>()
                .ToTable("Plazos")
                .HasKey(d => d.id);
            modelBuilder.Entity<Pago>()
                .ToTable("Pagos")
                .HasKey(d => d.id);
            modelBuilder.Entity<Movimiento>()
                .ToTable("Movimientos")
                .HasKey(d => d.id);
            modelBuilder.Entity<TarjetaCredito>()
                .ToTable("Tarjetas")
                .HasKey(d => d.id);

            // RELACIONES ONE TO MANY // CHECKEAR
            
            modelBuilder.Entity<PlazoFijo>()
            .HasOne(D => D.titular)
            .WithMany(U => U.plazoFijo)
            .HasForeignKey(D => D.id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pago>()
            .HasOne(D => D.usuario)
            .WithMany(U => U.pagos)
            .HasForeignKey(D => D.id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Movimiento>()
            .HasOne(D => D.caja)
            .WithMany(U => U.movimientos)
            .HasForeignKey(D => D.id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TarjetaCredito>()
            .HasOne(D => D.titular)
            .WithMany(U => U.tarjetas)
            .HasForeignKey(D => D.id)
            .OnDelete(DeleteBehavior.Cascade);

            // EXCLUIR
            modelBuilder.Ignore<Banco>();
        }
    }
}

