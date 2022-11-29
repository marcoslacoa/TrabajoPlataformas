using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic.ApplicationServices;

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
//        public Contexto(string connectionString)

//        {

//            _connectionString = connectionString;
//// add resources string1
//            _connectionString = r

//        }
        public Contexto() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(Properties.Resources.String1);

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
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

            modelBuilder.Entity<Pago>()
            .HasOne(D => D.usuario)
            .WithMany(U => U.pagos)
            .HasForeignKey(D => D.id)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
       
            modelBuilder.Entity<Movimiento>()
            .HasOne(D => D.caja)
            .WithMany(U => U.movimientos)
            .HasForeignKey(D => D.id)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

            modelBuilder.Entity<TarjetaCredito>()
            .HasOne(D => D.titular)
            .WithMany(U => U.tarjetas)
            .HasForeignKey(D => D.id)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);


            //RELACIONES MANY TO MANY

            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.listaCajas)
                .WithMany(P => P.titulares)
                .UsingEntity<UsuarioCaja>(
                    eup => eup.HasOne(up => up.caja).WithMany(p => p.UserCaja).HasForeignKey(u => u.id),
                    eup => eup.HasOne(up => up.usuario).WithMany(u => u.UserCaja).HasForeignKey(u => u.num_usr),
                    eup => eup.HasKey(k => new { k.num_usr, k.id })
                );

            //propiedades de los datos
            modelBuilder.Entity<Usuario>(
            usr =>
            {
                    usr.Property(u => u.id).HasColumnType("int");
                    usr.Property(u => u.id).IsRequired(true);
                    usr.Property(u => u.nombre).HasColumnType("varchar(50)");
                     usr.Property(u => u.nombre).IsRequired(true);
                     usr.Property(u => u.apellido).HasColumnType("varchar(50)");
                    usr.Property(u => u.apellido).IsRequired(true);
                    usr.Property(u => u.dni).HasColumnType("int");
                    usr.Property(u => u.dni).IsRequired(true);
                    usr.Property(u => u.mail).HasColumnType("varchar(512)");
                    usr.Property(u => u.mail).IsRequired(true);
                    usr.Property(u => u.contra).HasColumnType("varchar(50)");
                    usr.Property(u => u.contra).IsRequired(true);
                    usr.Property(u => u.intentosFallidos).HasColumnType("int");
                    usr.Property(u => u.esADM).HasColumnType("bit");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                });

            modelBuilder.Entity<CajaAhorro>(
                usr =>
                {
                    usr.Property(u => u.id).HasColumnType("int");
                    usr.Property(u => u.id).IsRequired(true);
                    usr.Property(u => u.cbu).HasColumnType("int");
                    usr.Property(u => u.cbu).IsRequired(true);
                    usr.Property(u => u.saldo).HasColumnType("float");
                    usr.Property(u => u.saldo).IsRequired(true);
                });

            modelBuilder.Entity<TarjetaCredito>(
                usr =>
                {
                    //usr.Property(u => u.titular).HasColumnType("int");
                    usr.Property(u => u.id).HasColumnType("int");
                    usr.Property(u => u.id).IsRequired(true);
                    usr.Property(u => u.numero).HasColumnType("int");
                    usr.Property(u => u.numero).IsRequired(true);
                    usr.Property(u => u.consumos).HasColumnType("float");
                    usr.Property(u => u.consumos).IsRequired(true);
                    usr.Property(u => u.limite).HasColumnType("int");
                    usr.Property(u => u.limite).IsRequired(true);
                    usr.Property(u => u.codigoSeguridad).HasColumnType("int");
                    usr.Property(u => u.codigoSeguridad).IsRequired(true);
                });

            modelBuilder.Entity<Pago>(
                usr =>
                {
                    usr.Property(u => u.id).HasColumnType("int");
                    usr.Property(u => u.id).IsRequired(true);
                    usr.Property(u => u.detalle).HasColumnType("varchar(50)");
                    usr.Property(u => u.detalle).IsRequired(true);
                    //usr.Property(u => u.usuario).HasColumnType("varchar(50)");
                    usr.Property(u => u.monto).HasColumnType("float");
                    usr.Property(u => u.monto).IsRequired(true);
                    usr.Property(u => u.pagado).HasColumnType("bit");
                    usr.Property(u => u.pagado).IsRequired(true);
                });

            modelBuilder.Entity<PlazoFijo>(
               usr =>
               {
                   //usr.Property(u => u.titular).HasColumnType("varchar(50)");
                   usr.Property(u => u.id).HasColumnType("int");
                   usr.Property(u => u.id).IsRequired(true);
                   usr.Property(u => u.tasa).HasColumnType("int");
                   usr.Property(u => u.tasa).IsRequired(true);
                   usr.Property(u => u.fechaIni).HasColumnType("datetime");
                   usr.Property(u => u.fechaIni).IsRequired(true);
                   usr.Property(u => u.FechaFin).HasColumnType("datetime");
                   usr.Property(u => u.FechaFin).IsRequired(true);
                   usr.Property(u => u.pagado).HasColumnType("bit");
                   usr.Property(u => u.pagado).IsRequired(true);
                   usr.Property(u => u.monto).HasColumnType("float");
                   usr.Property(u => u.monto).IsRequired(true);
               });

            modelBuilder.Entity<Movimiento>(
               usr =>
               {
                   //usr.Property(u => u.caja).HasColumnType("varchar(50)");
                   usr.Property(u => u.id).HasColumnType("int");
                   usr.Property(u => u.id).IsRequired(true);
                   usr.Property(u => u.detalle).HasColumnType("varchar(50)");
                   usr.Property(u => u.detalle).IsRequired(true);
                   usr.Property(u => u.monto).HasColumnType("float");
                   usr.Property(u => u.monto).IsRequired(true);
                   usr.Property(u => u.fecha).HasColumnType("datetime");
                   usr.Property(u => u.fecha).IsRequired(true);
               });

            // EXCLUIR
            modelBuilder.Ignore<Banco>();

            
        }
    }
}


