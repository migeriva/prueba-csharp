using Microsoft.EntityFrameworkCore;
using PruebaTecnicaInicial.Models;

namespace PruebaTecnicaInicial.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions options) : base(options) { }

        // agregar valores al iniciar el proyecto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MarcaAuto>().HasData(
                new MarcaAuto { Name="Audi", Id = 1},
                new MarcaAuto { Name = "Kia", Id = 2 },
                new MarcaAuto { Name = "Toyota", Id = 3 }
            );

        }

        public DbSet<MarcaAuto> MarcaAutos { get; set; }

    }
}
