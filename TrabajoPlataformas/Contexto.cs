using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrabajoPlataformas
{
    internal class Contexto : DbContext
    {
        private readonly string _connectionString;
        public Contexto(string connectionString)

        {

            _connectionString = connectionString;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(_connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}

