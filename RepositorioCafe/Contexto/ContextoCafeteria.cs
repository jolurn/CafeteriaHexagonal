using Microsoft.EntityFrameworkCore;
using RepositorioCafe.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioCafe.Contexto
{
    /// CONTEXTO DE BASE DE DATOS - Conexión con SQL Server
    public class ContextoCafeteria : DbContext
    {
        public DbSet<CafeModelo> Cafes { get; set; }

        public ContextoCafeteria(DbContextOptions<ContextoCafeteria> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CafeModelo>()
                .ToTable("Cafes")
                .Property(c => c.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<CafeModelo>()
                .HasIndex(c => c.Nombre)
                .HasDatabaseName("IX_Cafes_Nombre");
        }
    }
}
