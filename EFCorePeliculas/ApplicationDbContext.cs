using EFCorePeliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Este es el metodo del API Fluente, permite configurar las entidades y propiedades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //De esta manera se indica que el identificador es una llave primaria
            modelBuilder.Entity<Genero>().HasKey(prop => prop.Identificador);
            modelBuilder.Entity<Genero>().Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
        }

        public DbSet<Genero> Generos { get; set; }
    }
}
